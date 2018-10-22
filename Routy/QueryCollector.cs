using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using System.Threading.Tasks;

namespace Routy
{
    public class QueryCollector<TContext, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly List<AsyncParameterCollectorHandler<TContext, TResult>> _handlers = new List<AsyncParameterCollectorHandler<TContext, TResult>>();

        public QueryCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }
        
        // sync
        public QueryCollector<TContext, TResult, TController> Sync(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            HandlerProvider<TController, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            HandlerProvider<TController, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TResult, TController> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            AsyncHandlerProvider<TController, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            AsyncHandlerProvider<TController, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }
        
        // sync
        public QueryCollector<TContext, TResult, TController> Sync<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Handler<TQ1, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            HandlerProvider<TController, TQ1, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }


        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Handler<TQ1, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            HandlerProvider<TController, TQ1, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }
        
        // async
        public QueryCollector<TContext, TResult, TController> Async<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TQ1, Task<TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            AsyncHandlerProvider<TController, TQ1, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TQ1, Task<TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            AsyncHandlerProvider<TController, TQ1, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }
        
        // sync
        public QueryCollector<TContext, TResult, TController> Sync<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Handler<TQ1, TQ2, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            HandlerProvider<TController, TQ1, TQ2, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Handler<TQ1, TQ2, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            HandlerProvider<TController, TQ1, TQ2, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }
        
        // async
        public QueryCollector<TContext, TResult, TController> Async<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TQ1, TQ2, Task<TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            AsyncHandlerProvider<TController, TQ1, TQ2, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TQ1, TQ2, Task<TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            AsyncHandlerProvider<TController, TQ1, TQ2, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }
        
        // sync
        public QueryCollector<TContext, TResult, TController> Sync<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Handler<TQ1, TQ2, TQ3, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            HandlerProvider<TController, TQ1, TQ2, TQ3, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Handler<TQ1, TQ2, TQ3, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            HandlerProvider<TController, TQ1, TQ2, TQ3, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }
        
        // async
        public QueryCollector<TContext, TResult, TController> Async<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, Task<TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            AsyncHandlerProvider<TController, TQ1, TQ2, TQ3, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ4, TResult, TController> filler,
            Func<TQ1, TQ2, TQ4, Task<TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ4, TResult, TController> filler,
            AsyncHandlerProvider<TController, TQ1, TQ2, TQ4, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public async Task<TResult> Handle(NameValueCollection query, TContext context, CancellationToken ct)
        {
            foreach (var handler in _handlers)
            {
                try
                {
                    return await handler(query, context, ct);
                }
                catch(Exception e)
                {
                }
            }
            throw new NotImplementedException("25");
        }
    }

    public class QueryCollector<TContext, TResult, TController, TP1>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly List<AsyncParameterCollectorHandler<TContext, TResult, TP1>> _handlers = new List<AsyncParameterCollectorHandler<TContext, TResult, TP1>>();

        public QueryCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1> Sync(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            HandlerProvider<TController, TP1, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController, TP1> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            AsyncHandlerProvider<TController, TP1, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1> Sync<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            HandlerProvider<TController, TP1, TQ1, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1> Async<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            AsyncHandlerProvider<TController, TP1, TQ1, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1> Sync<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            HandlerProvider<TController, TP1, TQ1, TQ2, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1> Async<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            AsyncHandlerProvider<TController, TP1, TQ1, TQ2, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }
        
        public async Task<TResult> Handle(NameValueCollection query, TContext context, TP1 p1, CancellationToken ct)
        {
            foreach (var some in _handlers)
            {
                try
                {
                    return await some(query, context, p1, ct);
                }
                catch
                {
                }
            }
            throw new NotImplementedException("26");
        }
    }
    
    public class QueryCollector<TContext, TResult, TController, TP1, TP2>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly List<AsyncParameterCollectorHandler<TContext, TResult, TP1, TP2>> _handlers = new List<AsyncParameterCollectorHandler<TContext, TResult, TP1, TP2>>();

        public QueryCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1, TP2> Sync(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            HandlerProvider<TController, TP1, TP2, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1, TP2> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            AsyncHandlerProvider<TController, TP1, TP2, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController, TP1, TP2> Sync<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            HandlerProvider<TController, TP1, TP2, TQ1, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1, TP2> Async<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            AsyncHandlerProvider<TController, TP1, TP2, TQ1, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1, TP2> Sync<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            HandlerProvider<TController, TP1, TP2, TQ1, TQ2, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1, TP2> Async<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            AsyncHandlerProvider<TController, TP1, TP2, TQ1, TQ2, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }
        
        public async Task<TResult> Handle(NameValueCollection query, TContext context, TP1 p1, TP2 p2, CancellationToken ct)
        {
            foreach (var some in _handlers)
            {
                try
                {
                    return await some(query, context, p1, p2, ct);
                }
                catch
                {
                }
            }
            throw new NotImplementedException("27");
        }
    }
    
    public class QueryCollector<TContext, TResult, TController, TP1, TP2, TP3>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly List<AsyncParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3>> _handlers = new List<AsyncParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3>>();

        public QueryCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1, TP2, TP3> Sync(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            HandlerProvider<TController, TP1, TP2, TP3, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1, TP2, TP3> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            AsyncHandlerProvider<TController, TP1, TP2, TP3, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController, TP1, TP2, TP3> Sync<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            HandlerProvider<TController, TP1, TP2, TP3, TQ1, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1, TP2, TP3> Async<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            AsyncHandlerProvider<TController, TP1, TP2, TP3, TQ1, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1, TP2, TP3> Sync<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            HandlerProvider<TController, TP1, TP2, TP3, TQ1, TQ2, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1, TP2, TP3> Async<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            AsyncHandlerProvider<TController, TP1, TP2, TP3, TQ1, TQ2, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }
        
        public async Task<TResult> Handle(NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, CancellationToken ct)
        {
            foreach (var some in _handlers)
            {
                try
                {
                    return await some(query, context, p1, p2, p3, ct);
                }
                catch
                {
                }
            }
            throw new NotImplementedException("28");
        }
    }
}
