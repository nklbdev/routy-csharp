using System;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Controllers
{
    internal class HomeController
    {
        public Action<HttpListenerResponse> Index() => r =>
        {
            var bytes = Encoding.UTF8.GetBytes("Index");
            using(var s = r.OutputStream)
                s.Write(bytes, 0, bytes.Length);
        };
        
        public async Task<Action<HttpListenerResponse>> IndexAsync() => r =>
        {
            var bytes = Encoding.UTF8.GetBytes("Index");
            using(var s = r.OutputStream)
                s.Write(bytes, 0, bytes.Length);
        };
        
        public async Task<Action<HttpListenerResponse>> IndexAsync(CancellationToken ct) => r =>
        {
            var bytes = Encoding.UTF8.GetBytes("Index");
            using(var s = r.OutputStream)
                s.Write(bytes, 0, bytes.Length);
        };

        public Action<HttpListenerResponse> About() => r =>
        {
            var bytes = Encoding.UTF8.GetBytes("About");
            using(var s = r.OutputStream)
                s.Write(bytes, 0, bytes.Length);
        };
    }
}