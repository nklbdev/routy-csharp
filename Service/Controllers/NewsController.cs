using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Service.Controllers
{
    internal class NewsController
    {
        public System.Action<HttpListenerResponse> Index(int page, bool order) => r =>
        {
            var bytes = Encoding.UTF8.GetBytes($"News int page: {page}, bool order: {order}");
            using(var s = r.OutputStream)
                s.Write(bytes, 0, bytes.Length);
        };
        
        public System.Action<HttpListenerResponse> Add(string title, string content)
        {
            throw new NotImplementedException("11");
        }

        public System.Action<HttpListenerResponse> Get(int arg) => r =>
        {
            var bytes = Encoding.UTF8.GetBytes($"Concrete news page: {arg}");
            using (var s = r.OutputStream)
                s.Write(bytes, 0, bytes.Length);
        };

        public Func<HttpListenerResponse, Task> Change(int arg1, string arg2, string arg3)
        {
            throw new NotImplementedException("13");
        }

        public Func<HttpListenerResponse, Task> Delete(int arg)
        {
            throw new NotImplementedException("14");
        }
    }
}