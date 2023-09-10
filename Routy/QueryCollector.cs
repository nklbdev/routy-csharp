
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Routy;

public class QueryCollector<TContext, TResult, TController>
{
    private readonly Func<TController> _controllerProvider;
    private readonly List<ParameterCollectorHandler<TContext, TResult>> _handlers = new();

    public QueryCollector(Func<TController> controllerProvider)
    {
        _controllerProvider = controllerProvider;
    }


    public QueryCollector<TContext, TResult, TController> Handle(
        ParameterCollectorFiller<TContext, TResult, TController> filler,
        Func<TResult> handler)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
        return this;
    }

    public QueryCollector<TContext, TResult, TController> Handle(
        ParameterCollectorFiller<TContext, TResult, TController> filler,
        Func<Func<TController>, Func<TResult>> handlerProvider)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
        return this;
    }

    // TODO: Understand what the MappedContext is and why I'm not using it
    public QueryCollector<TContext, TResult, TController> Handle<TMappedContext>(
        Func<TContext, TMappedContext> contextMapper,
        ParameterCollectorFiller<TContext, TResult, TController> filler,
        Func<TResult> handler)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
        return this;
    }

    // TODO: Understand what the MappedContext is and why I'm not using it
    public QueryCollector<TContext, TResult, TController> Handle<TMappedContext>(
        Func<TContext, TMappedContext> contextMapper,
        ParameterCollectorFiller<TContext, TResult, TController> filler,
        Func<Func<TController>, Func<TResult>> handlerProvider)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
        return this;
    }


    public QueryCollector<TContext, TResult, TController> Handle<TQ1>(
        ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
        Func<TQ1, TResult> handler)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
        return this;
    }

    public QueryCollector<TContext, TResult, TController> Handle<TQ1>(
        ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
        Func<Func<TController>, Func<TQ1, TResult>> handlerProvider)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
        return this;
    }

    // TODO: Understand what the MappedContext is and why I'm not using it
    public QueryCollector<TContext, TResult, TController> Handle<TMappedContext, TQ1>(
        Func<TContext, TMappedContext> contextMapper,
        ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
        Func<TQ1, TResult> handler)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
        return this;
    }

    // TODO: Understand what the MappedContext is and why I'm not using it
    public QueryCollector<TContext, TResult, TController> Handle<TMappedContext, TQ1>(
        Func<TContext, TMappedContext> contextMapper,
        ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
        Func<Func<TController>, Func<TQ1, TResult>> handlerProvider)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
        return this;
    }


    public QueryCollector<TContext, TResult, TController> Handle<TQ1, TQ2>(
        ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
        Func<TQ1, TQ2, TResult> handler)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
        return this;
    }

    public QueryCollector<TContext, TResult, TController> Handle<TQ1, TQ2>(
        ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
        Func<Func<TController>, Func<TQ1, TQ2, TResult>> handlerProvider)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
        return this;
    }

    // TODO: Understand what the MappedContext is and why I'm not using it
    public QueryCollector<TContext, TResult, TController> Handle<TMappedContext, TQ1, TQ2>(
        Func<TContext, TMappedContext> contextMapper,
        ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
        Func<TQ1, TQ2, TResult> handler)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
        return this;
    }

    // TODO: Understand what the MappedContext is and why I'm not using it
    public QueryCollector<TContext, TResult, TController> Handle<TMappedContext, TQ1, TQ2>(
        Func<TContext, TMappedContext> contextMapper,
        ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
        Func<Func<TController>, Func<TQ1, TQ2, TResult>> handlerProvider)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
        return this;
    }


    public QueryCollector<TContext, TResult, TController> Handle<TQ1, TQ2, TQ3>(
        ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
        Func<TQ1, TQ2, TQ3, TResult> handler)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
        return this;
    }

    public QueryCollector<TContext, TResult, TController> Handle<TQ1, TQ2, TQ3>(
        ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
        Func<Func<TController>, Func<TQ1, TQ2, TQ3, TResult>> handlerProvider)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
        return this;
    }

    // TODO: Understand what the MappedContext is and why I'm not using it
    public QueryCollector<TContext, TResult, TController> Handle<TMappedContext, TQ1, TQ2, TQ3>(
        Func<TContext, TMappedContext> contextMapper,
        ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
        Func<TQ1, TQ2, TQ3, TResult> handler)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
        return this;
    }

    // TODO: Understand what the MappedContext is and why I'm not using it
    public QueryCollector<TContext, TResult, TController> Handle<TMappedContext, TQ1, TQ2, TQ3>(
        Func<TContext, TMappedContext> contextMapper,
        ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
        Func<Func<TController>, Func<TQ1, TQ2, TQ3, TResult>> handlerProvider)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
        return this;
    }

    public TResult Handle(NameValueCollection query, TContext context)
    {
        foreach (var some in _handlers)
        {
            try
            {
                return some(query, context);
            }
            catch
            {
            }
        }
        throw new NotImplementedException("26");
    }

}

public class QueryCollector<TContext, TP1, TResult, TController>
{
    private readonly Func<TController> _controllerProvider;
    private readonly List<ParameterCollectorHandler<TContext, TP1, TResult>> _handlers = new();

    public QueryCollector(Func<TController> controllerProvider)
    {
        _controllerProvider = controllerProvider;
    }


    public QueryCollector<TContext, TP1, TResult, TController> Handle(
        ParameterCollectorFiller<TContext, TResult, TController> filler,
        Func<TP1, TResult> handler)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
        return this;
    }

    public QueryCollector<TContext, TP1, TResult, TController> Handle(
        ParameterCollectorFiller<TContext, TResult, TController> filler,
        Func<Func<TController>, Func<TP1, TResult>> handlerProvider)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
        return this;
    }

    // TODO: Understand what the MappedContext is and why I'm not using it
    public QueryCollector<TContext, TP1, TResult, TController> Handle<TMappedContext>(
        Func<TContext, TMappedContext> contextMapper,
        ParameterCollectorFiller<TContext, TResult, TController> filler,
        Func<TP1, TResult> handler)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
        return this;
    }

    // TODO: Understand what the MappedContext is and why I'm not using it
    public QueryCollector<TContext, TP1, TResult, TController> Handle<TMappedContext>(
        Func<TContext, TMappedContext> contextMapper,
        ParameterCollectorFiller<TContext, TResult, TController> filler,
        Func<Func<TController>, Func<TP1, TResult>> handlerProvider)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
        return this;
    }


    public QueryCollector<TContext, TP1, TResult, TController> Handle<TQ1>(
        ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
        Func<TP1, TQ1, TResult> handler)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
        return this;
    }

    public QueryCollector<TContext, TP1, TResult, TController> Handle<TQ1>(
        ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
        Func<Func<TController>, Func<TP1, TQ1, TResult>> handlerProvider)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
        return this;
    }

    // TODO: Understand what the MappedContext is and why I'm not using it
    public QueryCollector<TContext, TP1, TResult, TController> Handle<TMappedContext, TQ1>(
        Func<TContext, TMappedContext> contextMapper,
        ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
        Func<TP1, TQ1, TResult> handler)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
        return this;
    }

    // TODO: Understand what the MappedContext is and why I'm not using it
    public QueryCollector<TContext, TP1, TResult, TController> Handle<TMappedContext, TQ1>(
        Func<TContext, TMappedContext> contextMapper,
        ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
        Func<Func<TController>, Func<TP1, TQ1, TResult>> handlerProvider)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
        return this;
    }


    public QueryCollector<TContext, TP1, TResult, TController> Handle<TQ1, TQ2>(
        ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
        Func<TP1, TQ1, TQ2, TResult> handler)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
        return this;
    }

    public QueryCollector<TContext, TP1, TResult, TController> Handle<TQ1, TQ2>(
        ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
        Func<Func<TController>, Func<TP1, TQ1, TQ2, TResult>> handlerProvider)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
        return this;
    }

    // TODO: Understand what the MappedContext is and why I'm not using it
    public QueryCollector<TContext, TP1, TResult, TController> Handle<TMappedContext, TQ1, TQ2>(
        Func<TContext, TMappedContext> contextMapper,
        ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
        Func<TP1, TQ1, TQ2, TResult> handler)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
        return this;
    }

    // TODO: Understand what the MappedContext is and why I'm not using it
    public QueryCollector<TContext, TP1, TResult, TController> Handle<TMappedContext, TQ1, TQ2>(
        Func<TContext, TMappedContext> contextMapper,
        ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
        Func<Func<TController>, Func<TP1, TQ1, TQ2, TResult>> handlerProvider)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
        return this;
    }

    public TResult Handle(NameValueCollection query, TContext context, TP1 p1)
    {
        foreach (var some in _handlers)
        {
            try
            {
                return some(query, context, p1);
            }
            catch
            {
            }
        }
        throw new NotImplementedException("26");
    }

}

public class QueryCollector<TContext, TP1, TP2, TResult, TController>
{
    private readonly Func<TController> _controllerProvider;
    private readonly List<ParameterCollectorHandler<TContext, TP1, TP2, TResult>> _handlers = new();

    public QueryCollector(Func<TController> controllerProvider)
    {
        _controllerProvider = controllerProvider;
    }


    public QueryCollector<TContext, TP1, TP2, TResult, TController> Handle(
        ParameterCollectorFiller<TContext, TResult, TController> filler,
        Func<TP1, TP2, TResult> handler)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
        return this;
    }

    public QueryCollector<TContext, TP1, TP2, TResult, TController> Handle(
        ParameterCollectorFiller<TContext, TResult, TController> filler,
        Func<Func<TController>, Func<TP1, TP2, TResult>> handlerProvider)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
        return this;
    }

    // TODO: Understand what the MappedContext is and why I'm not using it
    public QueryCollector<TContext, TP1, TP2, TResult, TController> Handle<TMappedContext>(
        Func<TContext, TMappedContext> contextMapper,
        ParameterCollectorFiller<TContext, TResult, TController> filler,
        Func<TP1, TP2, TResult> handler)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
        return this;
    }

    // TODO: Understand what the MappedContext is and why I'm not using it
    public QueryCollector<TContext, TP1, TP2, TResult, TController> Handle<TMappedContext>(
        Func<TContext, TMappedContext> contextMapper,
        ParameterCollectorFiller<TContext, TResult, TController> filler,
        Func<Func<TController>, Func<TP1, TP2, TResult>> handlerProvider)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
        return this;
    }


    public QueryCollector<TContext, TP1, TP2, TResult, TController> Handle<TQ1>(
        ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
        Func<TP1, TP2, TQ1, TResult> handler)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
        return this;
    }

    public QueryCollector<TContext, TP1, TP2, TResult, TController> Handle<TQ1>(
        ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
        Func<Func<TController>, Func<TP1, TP2, TQ1, TResult>> handlerProvider)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
        return this;
    }

    // TODO: Understand what the MappedContext is and why I'm not using it
    public QueryCollector<TContext, TP1, TP2, TResult, TController> Handle<TMappedContext, TQ1>(
        Func<TContext, TMappedContext> contextMapper,
        ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
        Func<TP1, TP2, TQ1, TResult> handler)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
        return this;
    }

    // TODO: Understand what the MappedContext is and why I'm not using it
    public QueryCollector<TContext, TP1, TP2, TResult, TController> Handle<TMappedContext, TQ1>(
        Func<TContext, TMappedContext> contextMapper,
        ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
        Func<Func<TController>, Func<TP1, TP2, TQ1, TResult>> handlerProvider)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
        return this;
    }

    public TResult Handle(NameValueCollection query, TContext context, TP1 p1, TP2 p2)
    {
        foreach (var some in _handlers)
        {
            try
            {
                return some(query, context, p1, p2);
            }
            catch
            {
            }
        }
        throw new NotImplementedException("26");
    }

}

public class QueryCollector<TContext, TP1, TP2, TP3, TResult, TController>
{
    private readonly Func<TController> _controllerProvider;
    private readonly List<ParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult>> _handlers = new();

    public QueryCollector(Func<TController> controllerProvider)
    {
        _controllerProvider = controllerProvider;
    }


    public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Handle(
        ParameterCollectorFiller<TContext, TResult, TController> filler,
        Func<TP1, TP2, TP3, TResult> handler)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
        return this;
    }

    public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Handle(
        ParameterCollectorFiller<TContext, TResult, TController> filler,
        Func<Func<TController>, Func<TP1, TP2, TP3, TResult>> handlerProvider)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
        return this;
    }

    // TODO: Understand what the MappedContext is and why I'm not using it
    public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Handle<TMappedContext>(
        Func<TContext, TMappedContext> contextMapper,
        ParameterCollectorFiller<TContext, TResult, TController> filler,
        Func<TP1, TP2, TP3, TResult> handler)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
        return this;
    }

    // TODO: Understand what the MappedContext is and why I'm not using it
    public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Handle<TMappedContext>(
        Func<TContext, TMappedContext> contextMapper,
        ParameterCollectorFiller<TContext, TResult, TController> filler,
        Func<Func<TController>, Func<TP1, TP2, TP3, TResult>> handlerProvider)
    {
        _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
        return this;
    }

    public TResult Handle(NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3)
    {
        foreach (var some in _handlers)
        {
            try
            {
                return some(query, context, p1, p2, p3);
            }
            catch
            {
            }
        }
        throw new NotImplementedException("26");
    }

}

