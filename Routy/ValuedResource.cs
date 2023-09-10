
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Routy;

public class ValuedResource<TContext, TValue, TResult>
{
    private readonly Parser<TValue, bool> _parser;
    private readonly HttpMethodCollectorHandler<TContext, TValue, TResult> _methodCollectorHandler;
    private readonly ResourceCollectorHandler<TContext, TValue, TResult> _nestedResourceCollectorHandler;

    public ValuedResource(
        Parser<TValue, bool> parser,
        HttpMethodCollectorHandler<TContext, TValue, TResult> methodCollectorHandler,
        ResourceCollectorHandler<TContext, TValue, TResult> nestedResourceCollectorHandler)
    {
        _parser = parser;
        _methodCollectorHandler = methodCollectorHandler;
        _nestedResourceCollectorHandler = nestedResourceCollectorHandler;
    }

    public TResult Handle(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context)
    {
        if (!uriSegments.Any())
            throw new NotImplementedException("1");

        var head = uriSegments.First();
        var tail = uriSegments.Skip(1).ToArray();

        if (_parser(head, out var value))
            return tail.Any()
                ? _nestedResourceCollectorHandler(httpMethod, tail, query, context, value)
                : _methodCollectorHandler(httpMethod, query, context, value);

        throw new NotImplementedException("2");
    }
}

public class ValuedResource<TContext, TP1, TValue, TResult>
{
    private readonly Parser<TValue, bool> _parser;
    private readonly HttpMethodCollectorHandler<TContext, TP1, TValue, TResult> _methodCollectorHandler;
    private readonly ResourceCollectorHandler<TContext, TP1, TValue, TResult> _nestedResourceCollectorHandler;

    public ValuedResource(
        Parser<TValue, bool> parser,
        HttpMethodCollectorHandler<TContext, TP1, TValue, TResult> methodCollectorHandler,
        ResourceCollectorHandler<TContext, TP1, TValue, TResult> nestedResourceCollectorHandler)
    {
        _parser = parser;
        _methodCollectorHandler = methodCollectorHandler;
        _nestedResourceCollectorHandler = nestedResourceCollectorHandler;
    }

    public TResult Handle(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, TP1 p1)
    {
        if (!uriSegments.Any())
            throw new NotImplementedException("1");

        var head = uriSegments.First();
        var tail = uriSegments.Skip(1).ToArray();

        if (_parser(head, out var value))
            return tail.Any()
                ? _nestedResourceCollectorHandler(httpMethod, tail, query, context, p1, value)
                : _methodCollectorHandler(httpMethod, query, context, p1, value);

        throw new NotImplementedException("2");
    }
}

public class ValuedResource<TContext, TP1, TP2, TValue, TResult>
{
    private readonly Parser<TValue, bool> _parser;
    private readonly HttpMethodCollectorHandler<TContext, TP1, TP2, TValue, TResult> _methodCollectorHandler;
    private readonly ResourceCollectorHandler<TContext, TP1, TP2, TValue, TResult> _nestedResourceCollectorHandler;

    public ValuedResource(
        Parser<TValue, bool> parser,
        HttpMethodCollectorHandler<TContext, TP1, TP2, TValue, TResult> methodCollectorHandler,
        ResourceCollectorHandler<TContext, TP1, TP2, TValue, TResult> nestedResourceCollectorHandler)
    {
        _parser = parser;
        _methodCollectorHandler = methodCollectorHandler;
        _nestedResourceCollectorHandler = nestedResourceCollectorHandler;
    }

    public TResult Handle(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, TP1 p1, TP2 p2)
    {
        if (!uriSegments.Any())
            throw new NotImplementedException("1");

        var head = uriSegments.First();
        var tail = uriSegments.Skip(1).ToArray();

        if (_parser(head, out var value))
            return tail.Any()
                ? _nestedResourceCollectorHandler(httpMethod, tail, query, context, p1, p2, value)
                : _methodCollectorHandler(httpMethod, query, context, p1, p2, value);

        throw new NotImplementedException("2");
    }
}

