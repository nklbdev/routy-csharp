using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Controllers
{
    internal class ArticleController
    {
        public Func<HttpListenerResponse, Task> Index(int arg)
        {
            throw new NotImplementedException("37");
        }
        
        public async Task<Func<HttpListenerResponse, Task>> IndexAsync(int arg)
        {
            throw new NotImplementedException("38");
        }
        
        public async Task<Func<HttpListenerResponse, Task>> IndexAsync(int arg, CancellationToken ct)
        {
            throw new NotImplementedException("39");
        }

        public Func<HttpListenerResponse, Task> Add(string arg1, string arg2)
        {
            throw new NotImplementedException("40");
        }

        public Func<HttpListenerResponse, Task> Get(int arg)
        {
            throw new NotImplementedException("41");
        }

        public Func<HttpListenerResponse, Task> Change(int arg1, string arg2, string arg3)
        {
            throw new NotImplementedException("42");
        }

        public Func<HttpListenerResponse, Task> Delete(int arg)
        {
            throw new NotImplementedException("43");
        }
    }
}