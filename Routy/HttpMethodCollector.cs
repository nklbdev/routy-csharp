
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Routy;

public class HttpMethodCollector<TContext, TResult, TController>
{
    private readonly Func<TController> _controllerProvider;
    private readonly Dictionary<string, QueryCollector<TContext, TResult, TController>> _queryCollectors = new();

    public HttpMethodCollector(Func<TController> controllerProvider)
    {
        _controllerProvider = controllerProvider;
    }

    public HttpMethodCollector<TContext, TResult, TController> Method(
        string method,
        Mutator<QueryCollector<TContext, TResult, TController>> filler)
    {
        _queryCollectors[method] = filler(new QueryCollector<TContext, TResult, TController>(_controllerProvider));
        return this;
    }

    public TResult Handle(string httpMethod, NameValueCollection query, TContext context)
    {
        if (_queryCollectors.TryGetValue(httpMethod.ToLower(), out var queryCollector))
            return queryCollector.Handle(query, context);
        throw new NotImplementedException("23");
    }
}

public class HttpMethodCollector<TContext, TP1, TResult, TController>
{
    private readonly Func<TController> _controllerProvider;
    private readonly Dictionary<string, QueryCollector<TContext, TP1, TResult, TController>> _queryCollectors = new();

    public HttpMethodCollector(Func<TController> controllerProvider)
    {
        _controllerProvider = controllerProvider;
    }

    public HttpMethodCollector<TContext, TP1, TResult, TController> Method(
        string method,
        Mutator<QueryCollector<TContext, TP1, TResult, TController>> filler)
    {
        _queryCollectors[method] = filler(new QueryCollector<TContext, TP1, TResult, TController>(_controllerProvider));
        return this;
    }

    public TResult Handle(string httpMethod, NameValueCollection query, TContext context, TP1 p1)
    {
        if (_queryCollectors.TryGetValue(httpMethod.ToLower(), out var queryCollector))
            return queryCollector.Handle(query, context, p1);
        throw new NotImplementedException("23");
    }
}

public class HttpMethodCollector<TContext, TP1, TP2, TResult, TController>
{
    private readonly Func<TController> _controllerProvider;
    private readonly Dictionary<string, QueryCollector<TContext, TP1, TP2, TResult, TController>> _queryCollectors = new();

    public HttpMethodCollector(Func<TController> controllerProvider)
    {
        _controllerProvider = controllerProvider;
    }

    public HttpMethodCollector<TContext, TP1, TP2, TResult, TController> Method(
        string method,
        Mutator<QueryCollector<TContext, TP1, TP2, TResult, TController>> filler)
    {
        _queryCollectors[method] = filler(new QueryCollector<TContext, TP1, TP2, TResult, TController>(_controllerProvider));
        return this;
    }

    public TResult Handle(string httpMethod, NameValueCollection query, TContext context, TP1 p1, TP2 p2)
    {
        if (_queryCollectors.TryGetValue(httpMethod.ToLower(), out var queryCollector))
            return queryCollector.Handle(query, context, p1, p2);
        throw new NotImplementedException("23");
    }
}

public class HttpMethodCollector<TContext, TP1, TP2, TP3, TResult, TController>
{
    private readonly Func<TController> _controllerProvider;
    private readonly Dictionary<string, QueryCollector<TContext, TP1, TP2, TP3, TResult, TController>> _queryCollectors = new();

    public HttpMethodCollector(Func<TController> controllerProvider)
    {
        _controllerProvider = controllerProvider;
    }

    public HttpMethodCollector<TContext, TP1, TP2, TP3, TResult, TController> Method(
        string method,
        Mutator<QueryCollector<TContext, TP1, TP2, TP3, TResult, TController>> filler)
    {
        _queryCollectors[method] = filler(new QueryCollector<TContext, TP1, TP2, TP3, TResult, TController>(_controllerProvider));
        return this;
    }

    public TResult Handle(string httpMethod, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3)
    {
        if (_queryCollectors.TryGetValue(httpMethod.ToLower(), out var queryCollector))
            return queryCollector.Handle(query, context, p1, p2, p3);
        throw new NotImplementedException("23");
    }
}

