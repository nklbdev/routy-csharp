using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Web;
using Autofac;
using Autofac.Features.AttributeFilters;
using Service.Controllers;
using Service.Forms;
using Service.Views;
using WebExperiment;

namespace Service
{
    public class Entity
    {
        //
    }
    
    public static class Program
    {
        private static readonly Dictionary<Type, Parser<object>> _parsers = new Dictionary<Type, Parser<object>>
        {
            [typeof(string)] = s => s,
            [typeof(bool)] = s => bool.Parse(s),
            [typeof(int)] = s => int.Parse(s)
        };
        
        public static T FormUrlencodedDeserialize<T>(Stream stream) where T : new()
        {
            using (var reader = new StreamReader(stream))
            {
                var content = reader.ReadToEnd();
                var decodedContent = HttpUtility.UrlDecode(content);
                var nvc = HttpUtility.ParseQueryString(decodedContent);
                var t = new T();
                foreach (var kvp in nvc.AllKeys)
                {
                    var pi = typeof(T).GetProperty(kvp, BindingFlags.Public | BindingFlags.Instance);
                    if (pi == null)
                        continue;
                    
                    if (_parsers.TryGetValue(pi.PropertyType, out var parser))
                        pi.SetValue(t, parser(nvc[kvp]), null);
                    else
                        throw new NotImplementedException("21");
                }
                return t;
            }
        }
        
        public static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();

            var cb = new ContainerBuilder();
            cb.RegisterType<HomeController>().AsSelf().WithAttributeFiltering();
            cb.RegisterType<NewsController>().AsSelf();
            cb.RegisterType<IndexView>().AsSelf();
            cb.RegisterType<AboutView>().AsSelf();
            cb.Register<ViewFactory>(ctxt =>
            {
                var cwer = ctxt.Resolve<IComponentContext>();
                return () => cwer.Resolve<AboutView>().Show;
            }).Keyed<ViewFactory>("About");
            cb.Register<Func<ICollection<string>, View>>(ctxt =>
            {
                var cwer = ctxt.Resolve<IComponentContext>();
                return answers =>
                {
                    var view = cwer.Resolve<IndexView>();
                    view.Answers = answers;
                    return view.Show;
                };
            }).Keyed<Func<ICollection<string>, View>>("Index");
            var c = cb.Build();

            new Server(Resource<HttpListenerRequest, System.Action<HttpListenerResponse>>
                    .Root(c.Resolve<HomeController>,
                        methods => methods
                            .Method("get", h => h.Query(q => q, cf => cf().Index))
                            .Method("post", h => h.Query(q => q.Context(ct => FormUrlencodedDeserialize<SimpleForm>(ct.InputStream)), cf => cf().PostAnswer)),
                        root => root
                            .Named("about", methods => methods
                                .Method("get", h => h
                                    .Query(q => q, cf => cf().About)))
                            .Named("news", c.Resolve<NewsController>,
                                methods => methods
                                    .Method("get", h => h
                                        .Query(q => q
                                                .Single("page", int.Parse, 0)
                                                .Single("order", bool.Parse, false),
                                            cf => cf().Index)),
                                news => news
                                    .Valued(int.Parse,
                                        methods => methods
                                            .Method("get", h => h
                                                .Query(q => q, cf => cf().Get))))))
                .RunAsync(cts.Token).Wait();
        }
    }
}