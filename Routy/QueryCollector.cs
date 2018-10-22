using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using System.Threading.Tasks;

namespace Routy
{
    public class QueryCollector<TContext, TResult, TController>
    {
        private readonly Provider<TController> _controllerProvider;
        private readonly List<ParameterCollectorHandler<TContext, TResult>> _handlers = new List<ParameterCollectorHandler<TContext, TResult>>();

        public QueryCollector(Provider<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }
        
        // sync
        public QueryCollector<TContext, TResult, TController> Query(
            ParameterCollectorFiller<TContext, TContext, TResult, TController> filler,
            HandlerProvider<TController, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TContext, TResult, TController>(_controllerProvider, ctx => ctx)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Query<TParsedContext>(
            Transformer<TContext, TParsedContext> contextParser,
            ParameterCollectorFiller<TContext, TParsedContext, TResult, TController> filler,
            HandlerProvider<TController, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TParsedContext, TResult, TController>(_controllerProvider, contextParser)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TResult, TController> Query(
            ParameterCollectorFiller<TContext, TContext, TResult, TController> filler,
            AsyncHandlerProvider<TController, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TContext, TResult, TController>(_controllerProvider, ctx => ctx)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Query<TParsedContext>(
            Transformer<TContext, TParsedContext> contextParser,
            ParameterCollectorFiller<TContext, TParsedContext, TResult, TController> filler,
            AsyncHandlerProvider<TController, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TParsedContext, TResult, TController>(_controllerProvider, contextParser)).CreateHandler(handlerProvider));
            return this;
        }
        
        // sync
        public QueryCollector<TContext, TResult, TController> Query<TQ1>(
            ParameterCollectorFiller<TContext, TContext, TQ1, TResult, TController> filler,
            HandlerProvider<TController, TQ1, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TContext, TResult, TController>(_controllerProvider, ctx => ctx)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Query<TParsedContext, TQ1>(
            Transformer<TContext, TParsedContext> contextParser,
            ParameterCollectorFiller<TContext, TParsedContext, TQ1, TResult, TController> filler,
            HandlerProvider<TController, TQ1, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TParsedContext, TResult, TController>(_controllerProvider, contextParser)).CreateHandler(handlerProvider));
            return this;
        }
        
        // async
        public QueryCollector<TContext, TResult, TController> Query<TQ1>(
            ParameterCollectorFiller<TContext, TContext, TQ1, TResult, TController> filler,
            AsyncHandlerProvider<TController, TQ1, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TContext, TResult, TController>(_controllerProvider, ctx => ctx)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Query<TParsedContext, TQ1>(
            Transformer<TContext, TParsedContext> contextParser,
            ParameterCollectorFiller<TContext, TParsedContext, TQ1, TResult, TController> filler,
            AsyncHandlerProvider<TController, TQ1, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TParsedContext, TResult, TController>(_controllerProvider, contextParser)).CreateHandler(handlerProvider));
            return this;
        }
        
        // sync
        public QueryCollector<TContext, TResult, TController> Query<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TContext, TQ1, TQ2, TResult, TController> filler,
            HandlerProvider<TController, TQ1, TQ2, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TContext, TResult, TController>(_controllerProvider, ctx => ctx)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Query<TParsedContext, TQ1, TQ2>(
            Transformer<TContext, TParsedContext> contextParser,
            ParameterCollectorFiller<TContext, TParsedContext, TQ1, TQ2, TResult, TController> filler,
            HandlerProvider<TController, TQ1, TQ2, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TParsedContext, TResult, TController>(_controllerProvider, contextParser)).CreateHandler(handlerProvider));
            return this;
        }
        
        // async
        public QueryCollector<TContext, TResult, TController> Query<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TContext, TQ1, TQ2, TResult, TController> filler,
            AsyncHandlerProvider<TController, TQ1, TQ2, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TContext, TResult, TController>(_controllerProvider, ctx => ctx)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Query<TParsedContext, TQ1, TQ2>(
            Transformer<TContext, TParsedContext> contextParser,
            ParameterCollectorFiller<TContext, TParsedContext, TQ1, TQ2, TResult, TController> filler,
            AsyncHandlerProvider<TController, TQ1, TQ2, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TParsedContext, TResult, TController>(_controllerProvider, contextParser)).CreateHandler(handlerProvider));
            return this;
        }
        
        // sync
        public QueryCollector<TContext, TResult, TController> Query<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            HandlerProvider<TController, TQ1, TQ2, TQ3, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TContext, TResult, TController>(_controllerProvider, ctx => ctx)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Query<TParsedContext, TQ1, TQ2, TQ3>(
            Transformer<TContext, TParsedContext> contextParser,
            ParameterCollectorFiller<TContext, TParsedContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            HandlerProvider<TController, TQ1, TQ2, TQ3, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TParsedContext, TResult, TController>(_controllerProvider, contextParser)).CreateHandler(handlerProvider));
            return this;
        }
        
        // async
        public QueryCollector<TContext, TResult, TController> Query<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            AsyncHandlerProvider<TController, TQ1, TQ2, TQ3, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TContext, TResult, TController>(_controllerProvider, ctx => ctx)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Query<TParsedContext, TQ1, TQ2, TQ4>(
            Transformer<TContext, TParsedContext> contextParser,
            ParameterCollectorFiller<TContext, TParsedContext, TQ1, TQ2, TQ4, TResult, TController> filler,
            AsyncHandlerProvider<TController, TQ1, TQ2, TQ4, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TParsedContext, TResult, TController>(_controllerProvider, contextParser)).CreateHandler(handlerProvider));
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
        private readonly Provider<TController> _controllerProvider;
        private readonly List<ParameterCollectorHandler<TContext, TResult, TP1>> _handlers = new List<ParameterCollectorHandler<TContext, TResult, TP1>>();

        public QueryCollector(Provider<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1> Query(
            ParameterCollectorFiller<TContext, TContext, TResult, TController> filler,
            HandlerProvider<TController, TP1, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TContext, TResult, TController>(_controllerProvider, ctx => ctx)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController, TP1> Query(
            ParameterCollectorFiller<TContext, TContext, TResult, TController> filler,
            AsyncHandlerProvider<TController, TP1, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TContext, TResult, TController>(_controllerProvider, ctx => ctx)).CreateHandler(handlerProvider));
            return this;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1> Query<TQ1>(
            ParameterCollectorFiller<TContext, TContext, TQ1, TResult, TController> filler,
            HandlerProvider<TController, TP1, TQ1, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TContext, TResult, TController>(_controllerProvider, ctx => ctx)).CreateHandler(handlerProvider));
            return this;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1> Query<TQ1>(
            ParameterCollectorFiller<TContext, TContext, TQ1, TResult, TController> filler,
            AsyncHandlerProvider<TController, TP1, TQ1, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TContext, TResult, TController>(_controllerProvider, ctx => ctx)).CreateHandler(handlerProvider));
            return this;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1> Query<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TContext, TQ1, TQ2, TResult, TController> filler,
            HandlerProvider<TController, TP1, TQ1, TQ2, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TContext, TResult, TController>(_controllerProvider, ctx => ctx)).CreateHandler(handlerProvider));
            return this;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1> Query<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TContext, TQ1, TQ2, TResult, TController> filler,
            AsyncHandlerProvider<TController, TP1, TQ1, TQ2, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TContext, TResult, TController>(_controllerProvider, ctx => ctx)).CreateHandler(handlerProvider));
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
        private readonly Provider<TController> _controllerProvider;
        private readonly List<ParameterCollectorHandler<TContext, TResult, TP1, TP2>> _handlers = new List<ParameterCollectorHandler<TContext, TResult, TP1, TP2>>();

        public QueryCollector(Provider<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1, TP2> Query(
            ParameterCollectorFiller<TContext, TContext, TResult, TController> filler,
            HandlerProvider<TController, TP1, TP2, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TContext, TResult, TController>(_controllerProvider, ctx => ctx)).CreateHandler(handlerProvider));
            return this;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1, TP2> Query(
            ParameterCollectorFiller<TContext, TContext, TResult, TController> filler,
            AsyncHandlerProvider<TController, TP1, TP2, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TContext, TResult, TController>(_controllerProvider, ctx => ctx)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController, TP1, TP2> Query<TQ1>(
            ParameterCollectorFiller<TContext, TContext, TQ1, TResult, TController> filler,
            HandlerProvider<TController, TP1, TP2, TQ1, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TContext, TResult, TController>(_controllerProvider, ctx => ctx)).CreateHandler(handlerProvider));
            return this;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1, TP2> Query<TQ1>(
            ParameterCollectorFiller<TContext, TContext, TQ1, TResult, TController> filler,
            AsyncHandlerProvider<TController, TP1, TP2, TQ1, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TContext, TResult, TController>(_controllerProvider, ctx => ctx)).CreateHandler(handlerProvider));
            return this;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1, TP2> Query<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TContext, TQ1, TQ2, TResult, TController> filler,
            HandlerProvider<TController, TP1, TP2, TQ1, TQ2, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TContext, TResult, TController>(_controllerProvider, ctx => ctx)).CreateHandler(handlerProvider));
            return this;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1, TP2> Query<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TContext, TQ1, TQ2, TResult, TController> filler,
            AsyncHandlerProvider<TController, TP1, TP2, TQ1, TQ2, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TContext, TResult, TController>(_controllerProvider, ctx => ctx)).CreateHandler(handlerProvider));
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
        private readonly Provider<TController> _controllerProvider;
        private readonly List<ParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3>> _handlers = new List<ParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3>>();

        public QueryCollector(Provider<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1, TP2, TP3> Query(
            ParameterCollectorFiller<TContext, TContext, TResult, TController> filler,
            HandlerProvider<TController, TP1, TP2, TP3, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TContext, TResult, TController>(_controllerProvider, ctx => ctx)).CreateHandler(handlerProvider));
            return this;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1, TP2, TP3> Query(
            ParameterCollectorFiller<TContext, TContext, TResult, TController> filler,
            AsyncHandlerProvider<TController, TP1, TP2, TP3, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TContext, TResult, TController>(_controllerProvider, ctx => ctx)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController, TP1, TP2, TP3> Query<TQ1>(
            ParameterCollectorFiller<TContext, TContext, TQ1, TResult, TController> filler,
            HandlerProvider<TController, TP1, TP2, TP3, TQ1, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TContext, TResult, TController>(_controllerProvider, ctx => ctx)).CreateHandler(handlerProvider));
            return this;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1, TP2, TP3> Query<TQ1>(
            ParameterCollectorFiller<TContext, TContext, TQ1, TResult, TController> filler,
            AsyncHandlerProvider<TController, TP1, TP2, TP3, TQ1, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TContext, TResult, TController>(_controllerProvider, ctx => ctx)).CreateHandler(handlerProvider));
            return this;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1, TP2, TP3> Query<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TContext, TQ1, TQ2, TResult, TController> filler,
            HandlerProvider<TController, TP1, TP2, TP3, TQ1, TQ2, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TContext, TResult, TController>(_controllerProvider, ctx => ctx)).CreateHandler(handlerProvider));
            return this;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1, TP2, TP3> Query<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TContext, TQ1, TQ2, TResult, TController> filler,
            AsyncHandlerProvider<TController, TP1, TP2, TP3, TQ1, TQ2, TResult> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TContext, TResult, TController>(_controllerProvider, ctx => ctx)).CreateHandler(handlerProvider));
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
