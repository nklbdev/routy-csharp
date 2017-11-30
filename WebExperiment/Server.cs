using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace WebExperiment
{
    public class Server
    {
        private readonly HttpListener _httpListener;
        private readonly Resource _resource;

        public Server(Resource handler)
        {
            _httpListener = new HttpListener();
        }

        public async Task Run()
        {
            await Run(new CancellationToken());
        }
        
        public async Task Run(CancellationToken ct)
        {
            throw new NotImplementedException();
//            var b = new BufferBlock<HttpListenerContext>(new DataflowBlockOptions { CancellationToken = ct });
//            
//            var a = new ActionBlock<HttpListenerContext>(async context =>
//            {
//                using (var response = context.Response)
//                    await _resource.Handle(context.Request, response, ct);
//            }, new ExecutionDataflowBlockOptions { CancellationToken = ct });
//
//            b.LinkTo(a);
//            
//            _httpListener.Prefixes.Add("http://127.0.0.1:3000/");
//            _httpListener.Prefixes.Add("http://localhost:3000/");
//            _httpListener.Start();
//            while (true)
//            {
//                ct.ThrowIfCancellationRequested();
//                var context = await _httpListener.GetContextAsync();
//                b.Post(context);
//            }
        }
    }
}