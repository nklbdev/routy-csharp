using System;
using System.Net;
using System.Threading.Tasks;
using WebExperiment;

namespace Service.Controllers
{
    internal class CommentController
    {
        public Func<HttpListenerResponse, Task> Index(int arg1, int? arg2)
        {
            throw new NotImplementedException("1");
        }

        public Func<HttpListenerResponse, Task> Add(int arg1, string arg2, string arg3)
        {
            throw new NotImplementedException("2");
        }

        public Func<HttpListenerResponse, Task> Get(int arg1, int arg2)
        {
            throw new NotImplementedException("3");
        }

        public Func<HttpListenerResponse, Task> Change(int arg1, int arg2, string arg3)
        {
            throw new NotImplementedException("4");
        }

        public Func<HttpListenerResponse, Task> Delete(int arg1, int arg2)
        {
            throw new NotImplementedException("5");
        }
    }
}