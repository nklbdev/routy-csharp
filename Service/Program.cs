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
            cb.Register<ViewProvider>(ctxt =>
            {
                var cwer = ctxt.Resolve<IComponentContext>();
                return () => cwer.Resolve<AboutView>().Show;
            }).Keyed<ViewProvider>("About");
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

            var handler = RequestHandlerFactory<HttpListenerRequest, View>
                .Create(c.Resolve<HomeController>,
                    methods => methods
                        .Method("get", queries => queries.Query(parameters => parameters, cf => cf().Index))
                        .Method("post",
                            queries => queries.Query(parameters => parameters.Context(ct => Deserialization.DeserializeFormUrlencoded<SimpleForm>(ct.InputStream)),
                                cp => cp().PostAnswer)),
                    rootResources => rootResources
                        .Named("about", methods => methods
                            .Method("get", queries => queries
                                .Query(parameters => parameters, cp => () => c.ResolveKeyed<ViewProvider>("About")().Invoke)))
                        .Named("news", c.Resolve<NewsController>,
                            methods => methods
                                .Method("get", queries => queries
                                    .Query(parameters => parameters
                                            .Single("page", int.Parse, 0)
                                            .Single("order", bool.Parse, false),
                                        cp => cp().Index)),
                            newsResources => newsResources
                                .Valued(int.Parse,
                                    methods => methods
                                        .Method("get", queries => queries
                                            .Query(parameters => parameters, cp => cp().Get)))));

            new Server(handler)
                .RunAsync(cts.Token).Wait();
        }
    }
}
