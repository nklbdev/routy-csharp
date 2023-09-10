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

using Mn = Service.HttpMethodNames;

namespace Service;

public static class Program
{
    private static IContainer CreateContainer()
    {
        var cb = new ContainerBuilder();
        cb.RegisterType<HomeController>().AsSelf().WithAttributeFiltering();
        cb.RegisterType<NewsController>().AsSelf();
        cb.RegisterType<IndexView>().AsSelf();
        cb.RegisterType<ShmIndexView>().AsSelf();
        cb.RegisterType<AboutView>().AsSelf();
        cb.Register<Func<View>>(context =>
        {
            var componentContext = context.Resolve<IComponentContext>();
            return () => componentContext.Resolve<AboutView>().ShowAsync;
        }).Keyed<Func<View>>("About");
        cb.Register<Func<ICollection<string>, View>>(context =>
        {
            var componentContext = context.Resolve<IComponentContext>();
            return answers =>
            {
                var view = componentContext.Resolve<IndexView>();
                view.Answers = answers;
                return view.ShowAsync;
            };
        }).Keyed<Func<ICollection<string>, View>>("Index");
        cb.Register<Func<int, ICollection<string>, View>>(context =>
        {
            var componentContext = context.Resolve<IComponentContext>();
            return (shm, answers) =>
            {
                var view = componentContext.Resolve<ShmIndexView>();
                view.Answers = answers;
                view.Shm = shm;
                return view.ShowAsync;
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

    private static readonly Parser<int, bool> TryParseInt = int.TryParse;

    public static void Main(string[] args)
    {
        var cts = new CancellationTokenSource();
        var c = CreateContainer();

        var handler = RequestHandlerFactory<HttpListenerRequest, View>.CreateHandler(c.Resolve<HomeController>,
            ms => ms
                .Method(Mn.Get, qs => qs
                    .Handle(ps => ps.Context(), cf => cf().EreIndex)
                    .Handle(ps => ps.Context(), cf => cf().EreIndex)
                    .Handle(ps => ps.Context(), cf => cf().EreIndex)
                    .Handle(ps => ps.Context(), cf => cf().EreIndex)
                )
                .Method(Mn.Get, qs => qs
                    .Handle(ps => ps.Single("name"), cf => cf().EreIndex))
                .Method(Mn.Get, qs => qs
                    .Handle(ps => ps.Single("name", "default"), cf => cf().EreIndex))
                .Method(Mn.Post, queries => queries
                    .Handle(ps => ps.Context(Deserialize<SimpleForm>), cp => cp().PostAnswer)),
            rs0 => rs0
                .Named("about", ms => ms
                        .Method(Mn.Get, qs => qs
                            .Handle(ps => ps, c.ResolveKeyed<Func<View>>("About"))),
                    rs1 => rs1
                        .Named("organization", ms => ms
                                .Method(Mn.Get, qs => qs
                                    .Handle(ps => ps, c.ResolveKeyed<Func<View>>("About"))),
                            rs2 => rs2
                                .Valued(TryParseInt, c.Resolve<NewsController>, ms => ms
                                    .Method(Mn.Get, qs => qs
                                        .Handle(ps => ps.Multiple("order", bool.Parse)
                                            .Custom(ParseInt), cp => cp().Index))
                                )
                            )
                    )
                .Named("news", c.Resolve<NewsController>, ms => ms
                        .Method(Mn.Get, qs => qs
                            .Handle(ps => ps.Single("page", int.Parse, 0).Multiple("order", bool.Parse)
                                .Custom(ParseInt), cp => cp().Index)),
                    rs1 => rs1
                        .Valued(TryParseInt, ms => ms
                            .Method(Mn.Get, qs => qs
                                .Handle(ps => ps, cp => cp().Get)))));

        new Server(handler)
            .RunAsync(cts.Token).Wait(cts.Token);
    }
}

public static class HttpMethodNames
{
    public const string Get = "get";
    public const string Post = "post";
}
