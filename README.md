# Better REST API library for c#

You can build your routing in this way:

```cs
var ioc = new IoC();

new Server(ResourceCollector.Root((HttpListenerRequest r) => ioc.Resolve<HomeController>(r),
        get: h => h.Handle(q => q, c => c.WithDefault().By(a => a.Index)),
        nested: root => root
            .Named("about",
                get: h => h.Handle(q => q, c => c.WithDefault().By(a => a.About)))
            .Named("news", r => ioc.Resolve<NewsController>(r),
                get: h => h
                    .Handle(q => q
                            .Single<int?>("page", s => int.Parse(s), null)
                            .Single<bool?>("order", s => bool.Parse(s), null),
                        c => c.WithDefault().By(a => a.Index))
                    .Handle(q => q
                            .Single("page", int.Parse, 0)
                            .Single("order", bool.Parse, false),
                        c => c.WithDefault().ByAsync(a => a.IndexAsync))
                    .Handle(q => q
                            .Single("page", int.Parse, 0)
                            .Single("order", bool.Parse, false),
                        c => c.WithDefault().ByAsyncCanc(a => a.IndexAsync))
                    .Handle(q => q
                            .Single("page", int.Parse, 0),
                        c => c.With(ioc.Resolve<ArticleController>).By(a => a.Index))
                    .Handle(q => q
                            .Single("page", int.Parse, 0),
                        c => c.With(ioc.Resolve<ArticleController>).ByAsync(a => a.IndexAsync))
                    .Handle(q => q
                            .Single("page", int.Parse, 0),
                        c => c.With(ioc.Resolve<ArticleController>).ByAsyncCanc(a => a.IndexAsync)),
                post: h => h.Handle(q => q.Single("title", s => s).Single("content", s => s),
                    c => c.WithDefault().By(a => a.Add)),
                nested: news => news
                    .Valued(int.Parse,
                        get: h => h
                            .Handle(q => q, c => c.WithDefault().By(a => a.Get)),
                        put: h => h.Handle(q => q
                                .Single("title", s => s)
                                .Single("content", s => s),
                            c => c.WithDefault().By(a => a.Change)),
                        delete: h => h.Handle(q => q, c => c.WithDefault().By(a => a.Delete)),
                        nested: cNews => cNews
                            .Named("comments", r => ioc.Resolve<CommentController>(r),
                                get: h => h.Handle(q => q
                                        .Single<int?>("page", s => int.Parse(s), 0),
                                    c => c.WithDefault().By(a => a.Index)),
                                post: h => h.Handle(q => q
                                        .Single("title", s => s).Single("content", s => s),
                                    c => c.WithDefault().By(a => a.Add)),
                                nested: comment => comment
                                    .Valued(int.Parse,
                                        get: h => h.Handle(q => q, c => c.WithDefault().By(a => a.Get)),
                                        put: h => h.Handle(q => q
                                                .Single("content", s => s),
                                            c => c.WithDefault().By(a => a.Change)),
                                        delete: h =>
                                            h.Handle(q => q, c => c.WithDefault().By(a => a.Delete))))))
            .Named("articles", ioc.Resolve<ArticleController>,
                get: h => h.Handle(q => q.Single("page", int.Parse, 0),
                    c => c.WithDefault().By(a => a.Index)),
                post: h => h.Handle(q => q.Single("title", s => s).Single("content", s => s),
                    c => c.WithDefault().By(a => a.Add)),
                nested: article => article
                    .Valued(int.Parse,
                        get: h => h.Handle(q => q, c => c.WithDefault().By(a => a.Get)),
                        put: h => h.Handle(q => q.Single("title", s => s).Single("content", s => s),
                            c => c.WithDefault().By(a => a.Change)),
                        delete: h => h.Handle(q => q, c => c.WithDefault().By(a => a.Delete))))
    )
).Run(_cts.Token).Wait();
```
