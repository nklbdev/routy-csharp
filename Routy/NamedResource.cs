
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Routy;

public class NamedResource<TContext, TResult>
{
    private readonly HttpMethodCollectorHandler<TContext, TResult> _methodCollectorHandler;
    private readonly ResourceCollectorHandler<TContext, TResult> _nestedResourceCollectorHandler;

    public NamedResource(
        HttpMethodCollectorHandler<TContext, TResult> methodCollectorHandler,
        ResourceCollectorHandler<TContext, TResult> nestedResourceCollectorHandler)
    {
        _methodCollectorHandler = methodCollectorHandler;
        _nestedResourceCollectorHandler = nestedResourceCollectorHandler;
    }

    public TResult Handle(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context)
    {
        if (!uriSegments.Any())
            throw new NotImplementedException("6");

        var tail = uriSegments.Skip(1).ToArray();

        return tail.Any()
            ? _nestedResourceCollectorHandler(httpMethod, tail, query, context)
            : _methodCollectorHandler(httpMethod, query, context);
    }
}

public class NamedResource<TContext, TP1, TResult>
{
    private readonly HttpMethodCollectorHandler<TContext, TP1, TResult> _methodCollectorHandler;
    private readonly ResourceCollectorHandler<TContext, TP1, TResult> _nestedResourceCollectorHandler;

    public NamedResource(
        HttpMethodCollectorHandler<TContext, TP1, TResult> methodCollectorHandler,
        ResourceCollectorHandler<TContext, TP1, TResult> nestedResourceCollectorHandler)
    {
        _methodCollectorHandler = methodCollectorHandler;
        _nestedResourceCollectorHandler = nestedResourceCollectorHandler;
    }

    public TResult Handle(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, TP1 p1)
    {
        if (!uriSegments.Any())
            throw new NotImplementedException("6");

        var tail = uriSegments.Skip(1).ToArray();

        return tail.Any()
            ? _nestedResourceCollectorHandler(httpMethod, tail, query, context, p1)
            : _methodCollectorHandler(httpMethod, query, context, p1);
    }
}

public class NamedResource<TContext, TP1, TP2, TResult>
{
    private readonly HttpMethodCollectorHandler<TContext, TP1, TP2, TResult> _methodCollectorHandler;
    private readonly ResourceCollectorHandler<TContext, TP1, TP2, TResult> _nestedResourceCollectorHandler;

    public NamedResource(
        HttpMethodCollectorHandler<TContext, TP1, TP2, TResult> methodCollectorHandler,
        ResourceCollectorHandler<TContext, TP1, TP2, TResult> nestedResourceCollectorHandler)
    {
        _methodCollectorHandler = methodCollectorHandler;
        _nestedResourceCollectorHandler = nestedResourceCollectorHandler;
    }

    public TResult Handle(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, TP1 p1, TP2 p2)
    {
        if (!uriSegments.Any())
            throw new NotImplementedException("6");

        var tail = uriSegments.Skip(1).ToArray();

        return tail.Any()
            ? _nestedResourceCollectorHandler(httpMethod, tail, query, context, p1, p2)
            : _methodCollectorHandler(httpMethod, query, context, p1, p2);
    }
}

public class NamedResource<TContext, TP1, TP2, TP3, TResult>
{
    private readonly HttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TResult> _methodCollectorHandler;
    private readonly ResourceCollectorHandler<TContext, TP1, TP2, TP3, TResult> _nestedResourceCollectorHandler;

    public NamedResource(
        HttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TResult> methodCollectorHandler,
        ResourceCollectorHandler<TContext, TP1, TP2, TP3, TResult> nestedResourceCollectorHandler)
    {
        _methodCollectorHandler = methodCollectorHandler;
        _nestedResourceCollectorHandler = nestedResourceCollectorHandler;
    }

    public TResult Handle(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3)
    {
        if (!uriSegments.Any())
            throw new NotImplementedException("6");

        var tail = uriSegments.Skip(1).ToArray();

        return tail.Any()
            ? _nestedResourceCollectorHandler(httpMethod, tail, query, context, p1, p2, p3)
            : _methodCollectorHandler(httpMethod, query, context, p1, p2, p3);
    }
}

