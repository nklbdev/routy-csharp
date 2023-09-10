
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Routy;

public class ResourceCollector<TContext, TResult, TController>
{
    private readonly Func<TController> _controllerProvider;
    private readonly Dictionary<string, ResourceCollectorHandler<TContext, TResult>> _namedResourceHandlers = new();
    private readonly List<ResourceCollectorHandler<TContext, TResult>> _valuedResourceHandlers = new();

    public ResourceCollector(Func<TController> controllerProvider)
    {
        _controllerProvider = controllerProvider;
    }

    public ResourceCollector<TContext, TResult, TController> Named(string name,
        Mutator<HttpMethodCollector<TContext, TResult, TController>>? httpMethodCollectorFiller = null,
        Mutator<ResourceCollector<TContext, TResult, TController>>? nestedResourceCollectorFiller = null
        ) => Named(name, _controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);

    public ResourceCollector<TContext, TResult, TController> Named<TNewController>(string name,
        Func<TNewController?> controllerProvider,
        Mutator<HttpMethodCollector<TContext, TResult, TNewController>>? httpMethodCollectorFiller = null,
        Mutator<ResourceCollector<TContext, TResult, TNewController>>? nestedResourceCollectorFiller = null
        )
    {
        httpMethodCollectorFiller ??= x => x;
        nestedResourceCollectorFiller ??= x => x;
        _namedResourceHandlers[name] = new NamedResource<TContext, TResult>(
            httpMethodCollectorFiller(new HttpMethodCollector<TContext, TResult, TNewController>(controllerProvider!)).Handle,
            nestedResourceCollectorFiller(new ResourceCollector<TContext, TResult, TNewController>(controllerProvider!)).Handle).Handle;
        return this;
    }

    public ResourceCollector<TContext, TResult, TController> Valued<TValue>(Parser<TValue, bool> parser,
        Mutator<HttpMethodCollector<TContext, TValue, TResult, TController>>? httpMethodCollectorFiller = null,
        Mutator<ResourceCollector<TContext, TValue, TResult, TController>>? nestedResourceCollectorFiller = null
        ) => Valued(parser, _controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);

    public ResourceCollector<TContext, TResult, TController> Valued<TValue, TNewController>(Parser<TValue, bool> parser,
        Func<TNewController?> controllerProvider,
        Mutator<HttpMethodCollector<TContext, TValue, TResult, TNewController>>? httpMethodCollectorFiller = null,
        Mutator<ResourceCollector<TContext, TValue, TResult, TNewController>>? nestedResourceCollectorFiller = null
        )
    {
        httpMethodCollectorFiller ??= x => x;
        nestedResourceCollectorFiller ??= x => x;
        _valuedResourceHandlers.Add(new ValuedResource<TContext, TValue, TResult>(
            parser,
            httpMethodCollectorFiller(new HttpMethodCollector<TContext, TValue, TResult, TNewController>(controllerProvider!)).Handle,
            nestedResourceCollectorFiller(new ResourceCollector<TContext, TValue, TResult, TNewController>(controllerProvider!)).Handle).Handle);
        return this;
    }

    public TResult Handle(string httpMethod, ICollection<string> urlSegments, NameValueCollection queryParameters, TContext context)
    {
        if (!urlSegments.Any())
            throw new NotImplementedException("15");

        var urlHead = urlSegments.First();

        if (_namedResourceHandlers.TryGetValue(urlHead, out var namedResourceHandler))
            return namedResourceHandler(httpMethod, urlSegments, queryParameters, context);

        foreach (var valuedResourceHandler in _valuedResourceHandlers)
            try
            {
                return valuedResourceHandler(httpMethod, urlSegments, queryParameters, context);
            }
            catch
            {

            }

        throw new NotImplementedException("16");
    }
}

public class ResourceCollector<TContext, TP1, TResult, TController>
{
    private readonly Func<TController> _controllerProvider;
    private readonly Dictionary<string, ResourceCollectorHandler<TContext, TP1, TResult>> _namedResourceHandlers = new();
    private readonly List<ResourceCollectorHandler<TContext, TP1, TResult>> _valuedResourceHandlers = new();

    public ResourceCollector(Func<TController> controllerProvider)
    {
        _controllerProvider = controllerProvider;
    }

    public ResourceCollector<TContext, TP1, TResult, TController> Named(string name,
        Mutator<HttpMethodCollector<TContext, TP1, TResult, TController>>? httpMethodCollectorFiller = null,
        Mutator<ResourceCollector<TContext, TP1, TResult, TController>>? nestedResourceCollectorFiller = null
        ) => Named(name, _controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);

    public ResourceCollector<TContext, TP1, TResult, TController> Named<TNewController>(string name,
        Func<TNewController?> controllerProvider,
        Mutator<HttpMethodCollector<TContext, TP1, TResult, TNewController>>? httpMethodCollectorFiller = null,
        Mutator<ResourceCollector<TContext, TP1, TResult, TNewController>>? nestedResourceCollectorFiller = null
        )
    {
        httpMethodCollectorFiller ??= x => x;
        nestedResourceCollectorFiller ??= x => x;
        _namedResourceHandlers[name] = new NamedResource<TContext, TP1, TResult>(
            httpMethodCollectorFiller(new HttpMethodCollector<TContext, TP1, TResult, TNewController>(controllerProvider!)).Handle,
            nestedResourceCollectorFiller(new ResourceCollector<TContext, TP1, TResult, TNewController>(controllerProvider!)).Handle).Handle;
        return this;
    }

    public ResourceCollector<TContext, TP1, TResult, TController> Valued<TValue>(Parser<TValue, bool> parser,
        Mutator<HttpMethodCollector<TContext, TP1, TValue, TResult, TController>>? httpMethodCollectorFiller = null,
        Mutator<ResourceCollector<TContext, TP1, TValue, TResult, TController>>? nestedResourceCollectorFiller = null
        ) => Valued(parser, _controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);

    public ResourceCollector<TContext, TP1, TResult, TController> Valued<TValue, TNewController>(Parser<TValue, bool> parser,
        Func<TNewController?> controllerProvider,
        Mutator<HttpMethodCollector<TContext, TP1, TValue, TResult, TNewController>>? httpMethodCollectorFiller = null,
        Mutator<ResourceCollector<TContext, TP1, TValue, TResult, TNewController>>? nestedResourceCollectorFiller = null
        )
    {
        httpMethodCollectorFiller ??= x => x;
        nestedResourceCollectorFiller ??= x => x;
        _valuedResourceHandlers.Add(new ValuedResource<TContext, TP1, TValue, TResult>(
            parser,
            httpMethodCollectorFiller(new HttpMethodCollector<TContext, TP1, TValue, TResult, TNewController>(controllerProvider!)).Handle,
            nestedResourceCollectorFiller(new ResourceCollector<TContext, TP1, TValue, TResult, TNewController>(controllerProvider!)).Handle).Handle);
        return this;
    }

    public TResult Handle(string httpMethod, ICollection<string> urlSegments, NameValueCollection queryParameters, TContext context, TP1 p1)
    {
        if (!urlSegments.Any())
            throw new NotImplementedException("15");

        var urlHead = urlSegments.First();

        if (_namedResourceHandlers.TryGetValue(urlHead, out var namedResourceHandler))
            return namedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1);

        foreach (var valuedResourceHandler in _valuedResourceHandlers)
            try
            {
                return valuedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1);
            }
            catch
            {

            }

        throw new NotImplementedException("16");
    }
}

public class ResourceCollector<TContext, TP1, TP2, TResult, TController>
{
    private readonly Func<TController> _controllerProvider;
    private readonly Dictionary<string, ResourceCollectorHandler<TContext, TP1, TP2, TResult>> _namedResourceHandlers = new();
    private readonly List<ResourceCollectorHandler<TContext, TP1, TP2, TResult>> _valuedResourceHandlers = new();

    public ResourceCollector(Func<TController> controllerProvider)
    {
        _controllerProvider = controllerProvider;
    }

    public ResourceCollector<TContext, TP1, TP2, TResult, TController> Named(string name,
        Mutator<HttpMethodCollector<TContext, TP1, TP2, TResult, TController>>? httpMethodCollectorFiller = null,
        Mutator<ResourceCollector<TContext, TP1, TP2, TResult, TController>>? nestedResourceCollectorFiller = null
        ) => Named(name, _controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);

    public ResourceCollector<TContext, TP1, TP2, TResult, TController> Named<TNewController>(string name,
        Func<TNewController?> controllerProvider,
        Mutator<HttpMethodCollector<TContext, TP1, TP2, TResult, TNewController>>? httpMethodCollectorFiller = null,
        Mutator<ResourceCollector<TContext, TP1, TP2, TResult, TNewController>>? nestedResourceCollectorFiller = null
        )
    {
        httpMethodCollectorFiller ??= x => x;
        nestedResourceCollectorFiller ??= x => x;
        _namedResourceHandlers[name] = new NamedResource<TContext, TP1, TP2, TResult>(
            httpMethodCollectorFiller(new HttpMethodCollector<TContext, TP1, TP2, TResult, TNewController>(controllerProvider!)).Handle,
            nestedResourceCollectorFiller(new ResourceCollector<TContext, TP1, TP2, TResult, TNewController>(controllerProvider!)).Handle).Handle;
        return this;
    }

    public ResourceCollector<TContext, TP1, TP2, TResult, TController> Valued<TValue>(Parser<TValue, bool> parser,
        Mutator<HttpMethodCollector<TContext, TP1, TP2, TValue, TResult, TController>>? httpMethodCollectorFiller = null,
        Mutator<ResourceCollector<TContext, TP1, TP2, TValue, TResult, TController>>? nestedResourceCollectorFiller = null
        ) => Valued(parser, _controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);

    public ResourceCollector<TContext, TP1, TP2, TResult, TController> Valued<TValue, TNewController>(Parser<TValue, bool> parser,
        Func<TNewController?> controllerProvider,
        Mutator<HttpMethodCollector<TContext, TP1, TP2, TValue, TResult, TNewController>>? httpMethodCollectorFiller = null,
        Mutator<ResourceCollector<TContext, TP1, TP2, TValue, TResult, TNewController>>? nestedResourceCollectorFiller = null
        )
    {
        httpMethodCollectorFiller ??= x => x;
        nestedResourceCollectorFiller ??= x => x;
        _valuedResourceHandlers.Add(new ValuedResource<TContext, TP1, TP2, TValue, TResult>(
            parser,
            httpMethodCollectorFiller(new HttpMethodCollector<TContext, TP1, TP2, TValue, TResult, TNewController>(controllerProvider!)).Handle,
            nestedResourceCollectorFiller(new ResourceCollector<TContext, TP1, TP2, TValue, TResult, TNewController>(controllerProvider!)).Handle).Handle);
        return this;
    }

    public TResult Handle(string httpMethod, ICollection<string> urlSegments, NameValueCollection queryParameters, TContext context, TP1 p1, TP2 p2)
    {
        if (!urlSegments.Any())
            throw new NotImplementedException("15");

        var urlHead = urlSegments.First();

        if (_namedResourceHandlers.TryGetValue(urlHead, out var namedResourceHandler))
            return namedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, p2);

        foreach (var valuedResourceHandler in _valuedResourceHandlers)
            try
            {
                return valuedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, p2);
            }
            catch
            {

            }

        throw new NotImplementedException("16");
    }
}

public class ResourceCollector<TContext, TP1, TP2, TP3, TResult, TController>
{
    private readonly Func<TController> _controllerProvider;
    private readonly Dictionary<string, ResourceCollectorHandler<TContext, TP1, TP2, TP3, TResult>> _namedResourceHandlers = new();
    private readonly List<ResourceCollectorHandler<TContext, TP1, TP2, TP3, TResult>> _valuedResourceHandlers = new();

    public ResourceCollector(Func<TController> controllerProvider)
    {
        _controllerProvider = controllerProvider;
    }

    public TResult Handle(string httpMethod, ICollection<string> urlSegments, NameValueCollection queryParameters, TContext context, TP1 p1, TP2 p2, TP3 p3)
    {
        if (!urlSegments.Any())
            throw new NotImplementedException("15");

        var urlHead = urlSegments.First();

        if (_namedResourceHandlers.TryGetValue(urlHead, out var namedResourceHandler))
            return namedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, p2, p3);

        foreach (var valuedResourceHandler in _valuedResourceHandlers)
            try
            {
                return valuedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, p2, p3);
            }
            catch
            {

            }

        throw new NotImplementedException("16");
    }
}

