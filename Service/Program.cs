using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using Autofac;
using Autofac.Features.AttributeFilters;
using Service.Controllers;
using Service.Forms;
using Service.Views;
using Routy;

namespace Service
{
    public static class Program
    {
        public static IContainer CreateContainer()
        {
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
            return cb.Build();
        }

        public static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            var c = CreateContainer();

            var handler = Resource<HttpListenerRequest, Action<HttpListenerResponse>>
                .Root(c.Resolve<HomeController>,
                    methods => methods
                        .Method("get", h => h.Query(q => q, cf => cf().Index))
                        .Method("post",
                            h => h.Query(q => q.Context(ct => Deserialization.DeserializeFormUrlencoded<SimpleForm>(ct.InputStream)),
                                cf => cf().PostAnswer)),
                    root => root
                        .Named("about", methods => methods
                            .Method("get", h => h
                                .Query(q => q, cf => () => c.ResolveKeyed<ViewFactory>("About")().Invoke)))
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
                                            .Query(q => q, cf => cf().Get)))));
            new Server(handler)
                .RunAsync(cts.Token).Wait();
        }
    }
}
