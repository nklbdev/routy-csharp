using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Autofac.Features.AttributeFilters;
using Service.Controllers;
using Service.Forms;
using Service.Views;
using Routy;

using Mn = Service.HttpMethodNames;

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
            cb.Register<Func<View>>(ctxt =>
            {
                var cwer = ctxt.Resolve<IComponentContext>();
                return () => cwer.Resolve<AboutView>().Show;
            }).Keyed<Func<View>>("About");
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

        private static T Deserialize<T>(HttpListenerRequest context) where T : new() =>
            Deserialization.DeserializeFormUrlencoded<T>(context.InputStream);

        private static Task<T> DeserializeAsync<T>(HttpListenerRequest context, CancellationToken ct) where T : new() =>
            Task.FromResult(Deserialization.DeserializeFormUrlencoded<T>(context.InputStream));

        public static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            var c = CreateContainer();

            var handler = RequestHandlerFactory<HttpListenerRequest, View>.CreateHandler(c.Resolve<HomeController>,
                ms => ms
                    .Method(Mn.Get, qs => qs
                        .Sync(ps => ps.Context(), cf => cf().EreIndex))
                    .Method(Mn.Post, queries => queries
                        .Sync(ps => ps.Context(DeserializeAsync<SimpleForm>), cp => cp().PostAnswer)),
                rs0 => rs0
                    .Named("about", ms => ms
                        .Method(Mn.Get, qs => qs
                            .Sync(ps => ps, c.ResolveKeyed<Func<View>>("About"))))
                    .Named("news", c.Resolve<NewsController>, ms => ms
                            .Method(Mn.Get, qs => qs
                                .Sync(ps => ps.Single("page", int.Parse, 0).Multiple("order", bool.Parse).Custom(ParseInt), cp => cp().Index)),
                        rs1 => rs1
                            .Valued(int.Parse, ms => ms
                                .Method(Mn.Get, qs => qs
                                    .Sync(ps => ps, cp => cp().Get)))));

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
