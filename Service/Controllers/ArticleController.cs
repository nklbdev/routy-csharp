using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using WebExperiment;

namespace Service.Controllers
{
    internal class ArticleController
    {
        public Responder<HttpListenerResponse> Index(int arg)
        {
            throw new NotImplementedException();
        }
        
        public async Task<Responder<HttpListenerResponse>> IndexAsync(int arg)
        {
            throw new NotImplementedException();
        }
        
        public async Task<Responder<HttpListenerResponse>> IndexAsync(int arg, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Responder<HttpListenerResponse> Add(string arg1, string arg2)
        {
            throw new NotImplementedException();
        }

        public Responder<HttpListenerResponse> Get(int arg)
        {
            throw new NotImplementedException();
        }

        public Responder<HttpListenerResponse> Change(int arg1, string arg2, string arg3)
        {
            throw new NotImplementedException();
        }

        public Responder<HttpListenerResponse> Delete(int arg)
        {
            throw new NotImplementedException();
        }
    }
}