using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Routy;
using Service.Views;

namespace Service;

public class Server
{
    private readonly HttpListener _httpListener;
    private readonly RequestHandler<HttpListenerRequest, View> _handler;

    public Server(RequestHandler<HttpListenerRequest, View> handler)
    {
        _httpListener = new HttpListener();
        _handler = handler;
    }

    private static byte[] _pageNotFoundMessage = "Page not found"u8.ToArray();
    public async Task RunAsync(CancellationToken ct)
    {
        var bufferingBlock = new BufferBlock<HttpListenerContext>(new DataflowBlockOptions { CancellationToken = ct });

        var processingBlock = new ActionBlock<HttpListenerContext>(async context =>
        {
            var request = context.Request;
            using var response = context.Response;
            try
            {
                await _handler(request.HttpMethod, request.Url, request)(response, ct);
            }
            catch (Exception e)
            {
                response.StatusCode = (int)HttpStatusCode.NotFound;
                await using var stream = response.OutputStream;
                await stream.WriteAsync(_pageNotFoundMessage, ct);
            }
        }, new ExecutionDataflowBlockOptions { CancellationToken = ct });

        bufferingBlock.LinkTo(processingBlock);

        _httpListener.Prefixes.Add("http://127.0.0.1:3000/");
        _httpListener.Prefixes.Add("http://localhost:3000/");
        _httpListener.Start();
        while (!ct.IsCancellationRequested)
            bufferingBlock.Post(await _httpListener.GetContextAsync());
    }
}
