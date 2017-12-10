# Better REST API library for c#

You can build your routing in this way:

```cs
public static void Main(string[] args)
{
    var cts = new CancellationTokenSource();
    var ioc = new IoC();

    new Server(Resource<HttpListenerRequest, System.Action<HttpListenerResponse>>
            // Pass default controller factory to root resource
            .Root(ioc.Resolve<HomeController>,
                methods => methods
                    // You can declare HTTP methods with many handlers
                    // (Declare simple handlers first)
                    .Method("get", h => h
                        // You can bind controller method
                        .Query(q => q, cf => cf().Index)
                        // or other controller method
                        .Query(q => q, cf => ioc.Resolve<HomeController>().Index)
                        // or async controller method
                        .Query(q => q, cf => cf().IndexAsync)
                        // or pass cancellation token to async method
                        .Query(q => q.CancellationToken(), cf => cf().IndexAsync)
                        // You also can bind another static method
                        .Query(q => q, cf => Index)
                        // or static asyncs
                        .Query(q => q, cf => IndexAsync)
                        .Query(q => q.CancellationToken(), cf => IndexAsync)
                        // You can declare required query parameters
                        .Query(q => q.Single("a", int.Parse), cf => Index)
                        // Or not required with default value
                        .Query(q => q.Single("a", int.Parse, 0), cf => Index)
                        // You can extract any data from context by your own extractor
                        // and declare it as parameter for your method
                        .Query(q => q.Context(ct => ParseEntity(ct.InputStream), 4), cf => Index)
                    ),
                // Declare nested resources
                root => root
                    // With concrete name
                    // And with default controller factory from parent resource
                    .Named("about", methods => methods
                        .Method("get", h => h
                            .Query(q => q, cf => cf().About)))
                    // Or with other controller factory
                    .Named("news", ioc.Resolve<NewsController>,
                        methods => methods
                            .Method("get", h => h
                                .Query(q => q
                                        .Single("page", int.Parse, 0)
                                        .Single("order", bool.Parse, false),
                                    cf => cf().Index)),
                        news => news
                            // Or use a value as a name
                            // (with controller factory from parent resource or new)
                            .Valued(int.Parse,
                                methods => methods
                                    .Method("get", h => h
                                        .Query(q => q, cf => cf().Get))))))
        .Run(cts.Token).Wait();
}
```
