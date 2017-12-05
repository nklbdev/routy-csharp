using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using WebExperiment;

namespace Service.Controllers
{
    internal class NewsController
    {
        public Responder<HttpListenerResponse> Index(int? arg1, bool? arg2)
        {
            throw new NotImplementedException();
        }
        
        public Task<Responder<HttpListenerResponse>> IndexAsync(int arg1, bool arg2)
        {
            throw new NotImplementedException();
        }
        
        public Task<Responder<HttpListenerResponse>> IndexAsync(int arg1, bool arg2, CancellationToken ct)
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