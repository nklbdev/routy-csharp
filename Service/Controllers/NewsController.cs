using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using WebExperiment;

namespace Service.Controllers
{
    internal class NewsController
    {
        public System.Action<HttpListenerResponse> Index(int arg1, bool arg2)
        {
            throw new NotImplementedException();
        }
        
        public Func<HttpListenerResponse, Task> Index2(HttpListenerRequest r, int arg1, bool arg2)
        {
            throw new NotImplementedException();
        }
        
        public Task<Func<HttpListenerResponse, Task>> IndexAsync(int arg1, bool arg2)
        {
            throw new NotImplementedException();
        }
        
        public Task<Func<HttpListenerResponse, Task>> IndexAsync(int arg1, bool arg2, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
        
        public System.Action<HttpListenerResponse> Add(Entity entity)
        {
            throw new NotImplementedException();
        }

        public System.Action<HttpListenerResponse> Get(int arg)
        {
            throw new NotImplementedException();
        }

        public Func<HttpListenerResponse, Task> Change(int arg1, string arg2, string arg3)
        {
            throw new NotImplementedException();
        }

        public Func<HttpListenerResponse, Task> Delete(int arg)
        {
            throw new NotImplementedException();
        }
    }
}