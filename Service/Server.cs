using System;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Routy;
using Service.Views;

namespace Service
{
    public class Server
    {
        private readonly HttpListener _httpListener;
        private readonly MainHandler<HttpListenerRequest, View> _handler;

        public Server(MainHandler<HttpListenerRequest, View> handler)
        {
            _httpListener = new HttpListener();
            _handler = handler;
        }

        public async Task Run()
        {
            await RunAsync(new CancellationToken());
        }
        
        public async Task RunAsync(CancellationToken ct)
        {
            var b = new BufferBlock<HttpListenerContext>(new DataflowBlockOptions { CancellationToken = ct });
            
            var a = new ActionBlock<HttpListenerContext>(async context =>
            {
                var request = context.Request;
                using (var response = context.Response)
                    try
                    {
                        (await _handler(request.HttpMethod, request.Url, request, ct))(response);
                    }
                    catch (Exception e)
                    {
                        var bytes = Encoding.UTF8.GetBytes("Page not found");
                        response.StatusCode = 404;
                        using(var s = response.OutputStream)
                            s.Write(bytes, 0, bytes.Length);
                    }
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
        
        
//        public async Task Run(CancellationToken ct)
//        {
//            _httpListener.Prefixes.Add("http://127.0.0.1:3000/");
//            _httpListener.Prefixes.Add("http://localhost:3000/");
//            _httpListener.Start();
//            while (true)
//            {
//                ct.ThrowIfCancellationRequested();
//                var context = await _httpListener.GetContextAsync();
//                
//                var request = context.Request;
//                
//                using (var response = context.Response)
//                    try
//                    {
//                        (await _handler(request.HttpMethod, request.Url, request, ct))(response);
//                    }
//                    catch (Exception e)
//                    {
//                        var bytes = Encoding.UTF8.GetBytes("Page not found");
//                        response.StatusCode = 404;
//                        using(var s = response.OutputStream)
//                            s.Write(bytes, 0, bytes.Length);
//                    }
//            }
//        }
    }
}