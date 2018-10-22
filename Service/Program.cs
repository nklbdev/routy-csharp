using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Threading;
using Autofac;
using Autofac.Features.AttributeFilters;
using Service.Controllers;
using Service.Forms;
using Service.Views;
using Routy;

using MN = Service.HttpMethodNames;

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
            cb.RegisterType<ShmIndexView>().AsSelf();
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
            cb.Register<Func<int, ICollection<string>, View>>(ctxt =>
            {
                var cwer = ctxt.Resolve<IComponentContext>();
                return (shm, answers) =>
                {
                    var view = cwer.Resolve<ShmIndexView>();
                    view.Answers = answers;
                    view.Shm = shm;
                    return view.Show;
                };
            }).Keyed<Func<int, ICollection<string>, View>>("ShmIndex");
            return cb.Build();
        }

        private static int ParseInt(NameValueCollection nvc)
        {
            return 3;
        }

        private static int ParseIntFromContext(HttpListenerRequest r)
        {
            return 1000;
        }

        public static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            var c = CreateContainer();

            var handler = RequestHandlerFactory<HttpListenerRequest, View>
                .Create(c.Resolve<HomeController>,
                    methods => methods
                        .Method(MN.Get, queries => queries
                            .Sync(parameters => parameters.Context(), cf => cf().EreIndex))
                        .Method(MN.Post, queries => queries
                            .Sync(ct => Deserialization.DeserializeFormUrlencoded<SimpleForm>(ct.InputStream),
                                parameters => parameters.Context(),
                                cp => cp().PostAnswer)),
                    rootResources => rootResources
                        .Named("about", methods => methods
                            .Method(MN.Get, queries => queries
                                .Sync(parameters => parameters,
                                    cp => () => c.ResolveKeyed<ViewProvider>("About")().Invoke)))
                        .Named("news", c.Resolve<NewsController>,
                            methods => methods
                                .Method(MN.Get, queries => queries
                                    .Sync(parameters => parameters
                                            .Single("page", int.Parse, 0)
                                            .Multiple("order", bool.Parse)
                                            .Object(ParseInt),
                                        cp => cp().Index)),
                            newsResources => newsResources
                                .Valued(int.Parse,
                                    methods => methods
                                        .Method(MN.Get, queries => queries
                                            .Sync(parameters => parameters, cp => cp().Get)))));

            new Server(handler)
                .RunAsync(cts.Token).Wait();
        }
    }

    public static class HttpMethodNames
    {
        public const string Get = "get";
        public const string Post = "post";
    }
}
