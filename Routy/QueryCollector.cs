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
            Func<Func<TController>, Func<TResult>> handlerProvider)
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
            Func<Func<TController>, Func<TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TResult, TController> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<Task<TResult>>> handlerProvider)
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

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TResult, TController> Sync<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TQ1, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TQ1, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TResult, TController> Async<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TQ1, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TQ1, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TResult, TController> Sync<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TQ1, TQ2, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TQ1, TQ2, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TResult, TController> Async<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TQ1, TQ2, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TQ1, TQ2, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TResult, TController> Sync<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TResult, TController> Async<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TQ16>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TQ16, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TQ16, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TQ16>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TQ16, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TQ16, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TQ16>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TQ16, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TQ16, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TQ16>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TQ16, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TQ16, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TQ16>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TQ16, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TQ16, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TQ16>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TQ16, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TQ16, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TQ16>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TQ16, TResult, TController> filler,
            Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TQ16, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TQ16>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TQ16, TResult, TController> filler,
            Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TQ16, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public async Task<TResult> Handle(NameValueCollection query, TContext context, CancellationToken ct)
        {
            foreach (var some in _handlers)
            {
                try
                {
                    return await some(query, context, ct);
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
        private readonly List<AsyncParameterCollectorHandler<TContext, TP1, TResult>> _handlers = new List<AsyncParameterCollectorHandler<TContext, TP1, TResult>>();

        public QueryCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        // sync
        public QueryCollector<TContext, TP1, TResult, TController> Sync(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TResult, TController> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TResult, TController> Sync<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TQ1, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TQ1, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TResult, TController> Async<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TQ1, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TQ1, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TResult, TController> Sync<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TResult, TController> Async<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TResult, TController> Sync<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TResult, TController> Async<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TResult, TController> filler,
            Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, Task<TResult>>> handlerProvider)
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

    public class QueryCollector<TContext, TP1, TP2, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly List<AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult>> _handlers = new List<AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult>>();

        public QueryCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TQ1, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TQ1, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult, TController> filler,
            Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, Task<TResult>>> handlerProvider)
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
            throw new NotImplementedException("26");
        }

    }

    public class QueryCollector<TContext, TP1, TP2, TP3, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly List<AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult>> _handlers = new List<AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult>>();

        public QueryCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult, TController> filler,
            Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, Task<TResult>>> handlerProvider)
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
            throw new NotImplementedException("26");
        }

    }

    public class QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly List<AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult>> _handlers = new List<AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult>>();

        public QueryCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public async Task<TResult> Handle(NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, CancellationToken ct)
        {
            foreach (var some in _handlers)
            {
                try
                {
                    return await some(query, context, p1, p2, p3, p4, ct);
                }
                catch
                {
                }
            }
            throw new NotImplementedException("26");
        }

    }

    public class QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly List<AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult>> _handlers = new List<AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult>>();

        public QueryCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public async Task<TResult> Handle(NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, CancellationToken ct)
        {
            foreach (var some in _handlers)
            {
                try
                {
                    return await some(query, context, p1, p2, p3, p4, p5, ct);
                }
                catch
                {
                }
            }
            throw new NotImplementedException("26");
        }

    }

    public class QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly List<AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult>> _handlers = new List<AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult>>();

        public QueryCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public async Task<TResult> Handle(NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, CancellationToken ct)
        {
            foreach (var some in _handlers)
            {
                try
                {
                    return await some(query, context, p1, p2, p3, p4, p5, p6, ct);
                }
                catch
                {
                }
            }
            throw new NotImplementedException("26");
        }

    }

    public class QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly List<AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult>> _handlers = new List<AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult>>();

        public QueryCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public async Task<TResult> Handle(NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, CancellationToken ct)
        {
            foreach (var some in _handlers)
            {
                try
                {
                    return await some(query, context, p1, p2, p3, p4, p5, p6, p7, ct);
                }
                catch
                {
                }
            }
            throw new NotImplementedException("26");
        }

    }

    public class QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly List<AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult>> _handlers = new List<AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult>>();

        public QueryCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Sync(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Sync(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Sync<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Sync<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Async<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Async<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Sync<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Sync<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Sync<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Sync<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Async<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Async<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Async<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Async<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Sync<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Sync<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Sync<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Sync<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Async<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Async<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Async<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Async<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Sync<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Sync<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Async<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Async<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public async Task<TResult> Handle(NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, CancellationToken ct)
        {
            foreach (var some in _handlers)
            {
                try
                {
                    return await some(query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct);
                }
                catch
                {
                }
            }
            throw new NotImplementedException("26");
        }

    }

    public class QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly List<AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult>> _handlers = new List<AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult>>();

        public QueryCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Sync(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Sync(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Sync<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Sync<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Async<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Async<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Sync<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Sync<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Sync<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Sync<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Async<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Async<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Async<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Async<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Sync<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Sync<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Sync<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Sync<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Async<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Async<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Async<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Async<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Sync<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Sync<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Async<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Async<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TQ5, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TQ5, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TQ5, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TQ5, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public async Task<TResult> Handle(NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, CancellationToken ct)
        {
            foreach (var some in _handlers)
            {
                try
                {
                    return await some(query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, ct);
                }
                catch
                {
                }
            }
            throw new NotImplementedException("26");
        }

    }

    public class QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly List<AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult>> _handlers = new List<AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult>>();

        public QueryCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Sync(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Sync(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Sync<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Sync<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Async<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Async<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Sync<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Sync<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Sync<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Sync<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Async<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Async<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Async<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Async<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Sync<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Sync<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Sync<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Sync<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Async<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Async<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Async<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Async<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Sync<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Sync<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Async<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Async<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TQ4, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TQ4, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TQ4, TQ5, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TQ4, TQ5, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TQ4, TQ5, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TQ4, TQ5, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public async Task<TResult> Handle(NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, TP10 p10, CancellationToken ct)
        {
            foreach (var some in _handlers)
            {
                try
                {
                    return await some(query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, ct);
                }
                catch
                {
                }
            }
            throw new NotImplementedException("26");
        }

    }

    public class QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly List<AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult>> _handlers = new List<AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult>>();

        public QueryCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Sync(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Sync(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Sync<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Sync<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Async<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Async<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Sync<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Sync<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Sync<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Sync<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Async<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Async<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Async<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Async<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Sync<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Sync<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Sync<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Sync<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Async<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Async<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Async<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Async<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Sync<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TQ3, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Sync<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TQ3, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TQ3, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TQ3, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Async<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TQ3, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Async<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TQ3, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TQ3, TQ4, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TQ3, TQ4, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TQ3, TQ4, TQ5, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TQ3, TQ4, TQ5, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TQ3, TQ4, TQ5, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TQ3, TQ4, TQ5, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4, TQ5>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4, TQ5>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public async Task<TResult> Handle(NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, TP10 p10, TP11 p11, CancellationToken ct)
        {
            foreach (var some in _handlers)
            {
                try
                {
                    return await some(query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, ct);
                }
                catch
                {
                }
            }
            throw new NotImplementedException("26");
        }

    }

    public class QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly List<AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult>> _handlers = new List<AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult>>();

        public QueryCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Sync(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Sync(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Sync<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Sync<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Async<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Async<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Sync<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Sync<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Sync<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Sync<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Async<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Async<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Async<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Async<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Sync<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TQ2, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Sync<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TQ2, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Sync<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TQ2, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Sync<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TQ2, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Async<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TQ2, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Async<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TQ2, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Async<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TQ2, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Async<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TQ2, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Sync<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TQ2, TQ3, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Sync<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TQ2, TQ3, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TQ2, TQ3, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TQ2, TQ3, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Async<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TQ2, TQ3, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Async<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TQ2, TQ3, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TQ2, TQ3, TQ4, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Sync<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TQ2, TQ3, TQ4, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Async<TQ1, TQ2, TQ3, TQ4>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3, TQ4>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public async Task<TResult> Handle(NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, TP10 p10, TP11 p11, TP12 p12, CancellationToken ct)
        {
            foreach (var some in _handlers)
            {
                try
                {
                    return await some(query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, ct);
                }
                catch
                {
                }
            }
            throw new NotImplementedException("26");
        }

    }

    public class QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly List<AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult>> _handlers = new List<AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult>>();

        public QueryCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController> Sync(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController> Sync(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController> Sync<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController> Sync<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController> Async<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController> Async<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController> Sync<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TQ1, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController> Sync<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TQ1, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController> Sync<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TQ1, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController> Sync<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TQ1, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController> Async<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TQ1, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController> Async<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TQ1, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController> Async<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TQ1, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController> Async<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TQ1, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController> Sync<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TQ1, TQ2, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController> Sync<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TQ1, TQ2, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController> Sync<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TQ1, TQ2, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController> Sync<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TQ1, TQ2, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController> Async<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TQ1, TQ2, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController> Async<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TQ1, TQ2, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController> Async<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TQ1, TQ2, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController> Async<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TQ1, TQ2, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController> Sync<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TQ1, TQ2, TQ3, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController> Sync<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TQ1, TQ2, TQ3, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TQ1, TQ2, TQ3, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController> Sync<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TQ1, TQ2, TQ3, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController> Async<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TQ1, TQ2, TQ3, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController> Async<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TQ1, TQ2, TQ3, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController> Async<TParsedContext, TQ1, TQ2, TQ3>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public async Task<TResult> Handle(NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, TP10 p10, TP11 p11, TP12 p12, TP13 p13, CancellationToken ct)
        {
            foreach (var some in _handlers)
            {
                try
                {
                    return await some(query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, ct);
                }
                catch
                {
                }
            }
            throw new NotImplementedException("26");
        }

    }

    public class QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly List<AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult>> _handlers = new List<AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult>>();

        public QueryCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TController> Sync(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TController> Sync(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TController> Sync<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TController> Sync<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TController> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TController> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TController> Async<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TController> Async<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TController> Sync<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TQ1, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TController> Sync<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TQ1, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TController> Sync<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TQ1, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TController> Sync<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TQ1, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TController> Async<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TQ1, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TController> Async<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TQ1, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TController> Async<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TQ1, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TController> Async<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TQ1, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TController> Sync<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TQ1, TQ2, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TController> Sync<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TQ1, TQ2, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TController> Sync<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TQ1, TQ2, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TController> Sync<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TQ1, TQ2, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TController> Async<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TQ1, TQ2, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TController> Async<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TQ1, TQ2, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TController> Async<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TQ1, TQ2, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TController> Async<TParsedContext, TQ1, TQ2>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TQ1, TQ2, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public async Task<TResult> Handle(NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, TP10 p10, TP11 p11, TP12 p12, TP13 p13, TP14 p14, CancellationToken ct)
        {
            foreach (var some in _handlers)
            {
                try
                {
                    return await some(query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, ct);
                }
                catch
                {
                }
            }
            throw new NotImplementedException("26");
        }

    }

    public class QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly List<AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult>> _handlers = new List<AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult>>();

        public QueryCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult, TController> Sync(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult, TController> Sync(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult, TController> Sync<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult, TController> Sync<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult, TController> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult, TController> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult, TController> Async<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult, TController> Async<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult, TController> Sync<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TQ1, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult, TController> Sync<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TQ1, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult, TController> Sync<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TQ1, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult, TController> Sync<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TQ1, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult, TController> Async<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TQ1, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult, TController> Async<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TQ1, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult, TController> Async<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TQ1, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult, TController> Async<TParsedContext, TQ1>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TQ1, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public async Task<TResult> Handle(NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, TP10 p10, TP11 p11, TP12 p12, TP13 p13, TP14 p14, TP15 p15, CancellationToken ct)
        {
            foreach (var some in _handlers)
            {
                try
                {
                    return await some(query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, ct);
                }
                catch
                {
                }
            }
            throw new NotImplementedException("26");
        }

    }

    public class QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly List<AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TResult>> _handlers = new List<AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TResult>>();

        public QueryCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        // sync
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TResult, TController> Sync(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TResult, TController> Sync(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TResult, TController> Sync<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TResult> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TResult, TController> Sync<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TResult>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        // async
        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TResult, TController> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TResult, TController> Async(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TResult, TController> Async<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, Task<TResult>> handler)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handler));
            return this;
        }

        public QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TResult, TController> Async<TParsedContext>(
            Func<TContext> contextParser,
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, Task<TResult>>> handlerProvider)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerProvider)).CreateHandler(handlerProvider));
            return this;
        }

        public async Task<TResult> Handle(NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, TP10 p10, TP11 p11, TP12 p12, TP13 p13, TP14 p14, TP15 p15, TP16 p16, CancellationToken ct)
        {
            foreach (var some in _handlers)
            {
                try
                {
                    return await some(query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, ct);
                }
                catch
                {
                }
            }
            throw new NotImplementedException("26");
        }

    }

}
