# Better REST API library for c#

You can build your routing in this way:

```cs
var ioc = new IoC();
new Server(ResourceCollector.Root(ioc.Resolve<HomeController>,
        get: h => h.WithDefault().By(a => a.Index),
        nested: root => root
            .Named("about",
                get: h => h.WithDefault().By(a => a.Index))
            .Named("news", ioc.Resolve<NewsController>,
                get: h => h
                    .WithNothing().By(GetStaticPage)
                    .WithNothing().ByAsync(GetStaticPageAsync)
                    .WithNothing().ByAsyncCanc(GetStaticPageAsync)
                    .WithDefault().By<int?, bool?>(a => a.Index)
                    .WithDefault().ByAsync<int?, bool?>(a => a.IndexAsync)
                    .WithDefault().ByAsyncCanc<int?, bool?>(a => a.IndexAsync)
                    .With(ioc.Resolve<ArticleController>).By<int?>(a => a.Index)
                    .With(ioc.Resolve<ArticleController>).ByAsync<int?>(a => a.IndexAsync)
                    .With(ioc.Resolve<ArticleController>).ByAsyncCanc<int?>(a => a.IndexAsync),
                post: h => h.WithDefault().By<string, string>(a => a.Add),
                nested: news => news
                    .Valued<int>(
                        get: h => h
                            .WithNothing().By(GetNewsById)
                            .WithNothing().ByAsync(GetNewsByIdAsync)
                            .WithNothing().ByAsyncCanc(GetNewsByIdAsync)
                            .WithDefault().By(a => a.Get),
                        put: h => h.WithDefault().By<string, string>(a => a.Change),
                        delete: h => h.WithDefault().By(a => a.Delete)))
            .Named("articles", ioc.Resolve<ArticleController>,
                get: h => h.WithDefault().By<int?>(a => a.Index),
                post: h => h.WithDefault().By<string, string>(a => a.Add),
                nested: article => article
                    .Valued<int>(
                        get: h => h.WithDefault().By(a => a.Get),
                        put: h => h.WithDefault().By<string, string>(a => a.Change),
                        delete: h => h.WithDefault().By(a => a.Delete)))
    ).Build()
).Run(_cts.Token).Wait();
```
