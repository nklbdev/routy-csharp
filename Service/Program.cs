using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Service.Controllers;
using WebExperiment;

namespace Service
{
    public class Entity
    {
        //
    }
    
    public static class Program
    {
        public static T Resolve<T>(object par)
        {
            throw new NotImplementedException();
        }

        public static Entity EntityParser(Stream stream)
        {
            throw new NotImplementedException();
        }
        
        public static T Extract<T>(HttpListenerRequest request)
        {
            throw new NotImplementedException();
        }

        public delegate Func<HttpListenerResponse, Task> Ind(int a, bool b);
        
        public static Func<HttpListenerResponse, Task> Index(int arg1, bool arg2)
        {
            throw new NotImplementedException();
        }
        
        public static System.Action<HttpListenerResponse> Index()
        {
            throw new NotImplementedException();
        }
        
        public static System.Action<HttpListenerResponse> Index(int a)
        {
            throw new NotImplementedException();
        }
        
        public static System.Action<HttpListenerResponse> Index(Entity entity, int a)
        {
            throw new NotImplementedException();
        }
        
        public static async Task<System.Action<HttpListenerResponse>> IndexAsync(Entity entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public static Entity ParseEntity(Stream req)
        {
            throw new NotImplementedException();
        }

        public static async Task<System.Action<HttpListenerResponse>> IndexAsync()
        {
            throw new NotImplementedException();
        }

        public static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            var ioc = new IoC();

            new Server(Resource<HttpListenerRequest, System.Action<HttpListenerResponse>>
                    .Root(ioc.Resolve<HomeController>,
                        methods => methods
                            .Method("get", h => h
                                .Query(q => q, cf => cf().Index)
                                .Query(q => q, cf => Index)
                                .Query(q => q.Single("a", int.Parse), cf => Index)
                                .Query(q => q
                                    .Context(ct => ParseEntity(ct.InputStream), 4)
                                    .CancellationToken(),
                                    cf => IndexAsync)
                                .Query(q => q, cf => IndexAsync)
                                .Query(q => q, cf => ioc.Resolve<HomeController>().Index)
                                .Query(q => q, cf => cf().IndexAsync)
                            ),
                        root => root
                            .Named("about", methods => methods
                                .Method("get", h => h
                                    .Query(q => q, cf => cf().About)))
                            .Named("news", ioc.Resolve<NewsController>,
                                methods => methods
                                    .Method("get", h => h
                                        .Query(q => q
                                                .Single("page", int.Parse)
                                                .Single("order", bool.Parse),
                                            cf => cf().Index))
                                    .Method("get", h => h
                                        .Query(q => q.Context(Extract<Entity>),
                                            cf => cf().Add)),
                                news => news
                                    .Valued(int.Parse,
                                        methods => methods
                                            .Method("get", h => h
                                                .Query(q => q, cf => cf().Get))))))
                .Run(cts.Token).Wait();
        }
    }
}