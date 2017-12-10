using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace WebExperiment
{
    public class Server
    {
        private readonly HttpListener _httpListener;
        private readonly Func<string, Uri, HttpListenerRequest, CancellationToken, System.Action<HttpListenerResponse>> _handler;

        public Server(Func<string, Uri, HttpListenerRequest, CancellationToken, System.Action<HttpListenerResponse>> handler)
        {
            _httpListener = new HttpListener();
            _handler = handler;
        }

        public Server(MainHandler<HttpListenerRequest, System.Action<HttpListenerResponse>> handler)
        {
            throw new NotImplementedException();
        }

        public async Task Run()
        {
            await Run(new CancellationToken());
        }
        
        public async Task Run(CancellationToken ct)
        {
            var b = new BufferBlock<HttpListenerContext>(new DataflowBlockOptions { CancellationToken = ct });
            
            var a = new ActionBlock<HttpListenerContext>(context =>
            {
                var request = context.Request;
                var responder = _handler(request.HttpMethod, request.Url, request, ct);
                using (var response = context.Response)
                    responder(response);
            }, new ExecutionDataflowBlockOptions { CancellationToken = ct });

            b.LinkTo(a);
            
            _httpListener.Prefixes.Add("http://127.0.0.1:3000/");
            _httpListener.Prefixes.Add("http://localhost:3000/");
            _httpListener.Start();
            while (true)
            {
                ct.ThrowIfCancellationRequested();
                var context = await _httpListener.GetContextAsync();
                b.Post(context);
            }
        }
    }
}