using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using System.Threading.Tasks;

namespace WebExperiment
{
    public class QueryCollector<TContext, TResult, TController>
    {
        private readonly Factory<TController> _controllerFactory;
        private readonly List<ParameterCollectorHandle<TContext, TResult>> _handlers = new List<ParameterCollectorHandle<TContext, TResult>>();

        public QueryCollector(Factory<TController> controllerFactory)
        {
            _controllerFactory = controllerFactory;
        }
        
        // sync
        public QueryCollector<TContext, TResult, TController> Query(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            ActionFactory<TController, TResult> actionFactory)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerFactory)).CreateHandler(actionFactory));
            return this;
        }
        
        // async
        public QueryCollector<TContext, TResult, TController> Query(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            AsyncActionFactory<TController, TResult> actionFactory)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerFactory)).CreateHandler(actionFactory));
            return this;
        }
        
        // sync
        public QueryCollector<TContext, TResult, TController> Query<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            ActionFactory<TController, TQ1, TResult> actionFactory)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerFactory)).CreateHandler(actionFactory));
            return this;
        }
        
        // async
        public QueryCollector<TContext, TResult, TController> Query<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            AsyncActionFactory<TController, TQ1, TResult> actionFactory)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerFactory)).CreateHandler(actionFactory));
            return this;
        }
        
        // sync
        public QueryCollector<TContext, TResult, TController> Query<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            ActionFactory<TController, TQ1, TQ2, TResult> actionFactory)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerFactory)).CreateHandler(actionFactory));
            return this;
        }
        
        // async
        public QueryCollector<TContext, TResult, TController> Query<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            AsyncActionFactory<TController, TQ1, TQ2, TResult> actionFactory)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerFactory)).CreateHandler(actionFactory));
            return this;
        }
        
        // sync
        public QueryCollector<TContext, TResult, TController> Query<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            ActionFactory<TController, TQ1, TQ2, TQ3, TResult> actionFactory)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerFactory)).CreateHandler(actionFactory));
            return this;
        }
        
        // async
        public QueryCollector<TContext, TResult, TController> Query<TQ1, TQ2, TQ3>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController> filler,
            AsyncActionFactory<TController, TQ1, TQ2, TQ3, TResult> actionFactory)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerFactory)).CreateHandler(actionFactory));
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
        private readonly Factory<TController> _controllerFactory;
        private readonly List<ParameterCollectorHandle<TContext, TResult, TP1>> _handlers = new List<ParameterCollectorHandle<TContext, TResult, TP1>>();

        public QueryCollector(Factory<TController> controllerFactory)
        {
            _controllerFactory = controllerFactory;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1> Query(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            ActionFactory<TController, TP1, TResult> actionFactory)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerFactory)).CreateHandler(actionFactory));
            return this;
        }

        public QueryCollector<TContext, TResult, TController, TP1> Query(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            AsyncActionFactory<TController, TP1, TResult> actionFactory)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerFactory)).CreateHandler(actionFactory));
            return this;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1> Query<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            ActionFactory<TController, TP1, TQ1, TResult> actionFactory)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerFactory)).CreateHandler(actionFactory));
            return this;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1> Query<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            AsyncActionFactory<TController, TP1, TQ1, TResult> actionFactory)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerFactory)).CreateHandler(actionFactory));
            return this;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1> Query<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            ActionFactory<TController, TP1, TQ1, TQ2, TResult> actionFactory)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerFactory)).CreateHandler(actionFactory));
            return this;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1> Query<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            AsyncActionFactory<TController, TP1, TQ1, TQ2, TResult> actionFactory)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerFactory)).CreateHandler(actionFactory));
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
        private readonly Factory<TController> _controllerFactory;
        private readonly List<ParameterCollectorHandle<TContext, TResult, TP1, TP2>> _handlers = new List<ParameterCollectorHandle<TContext, TResult, TP1, TP2>>();

        public QueryCollector(Factory<TController> controllerFactory)
        {
            _controllerFactory = controllerFactory;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1, TP2> Query(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            ActionFactory<TController, TP1, TP2, TResult> actionFactory)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerFactory)).CreateHandler(actionFactory));
            return this;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1, TP2> Query(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            AsyncActionFactory<TController, TP1, TP2, TResult> actionFactory)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerFactory)).CreateHandler(actionFactory));
            return this;
        }

        public QueryCollector<TContext, TResult, TController, TP1, TP2> Query<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            ActionFactory<TController, TP1, TP2, TQ1, TResult> actionFactory)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerFactory)).CreateHandler(actionFactory));
            return this;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1, TP2> Query<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            AsyncActionFactory<TController, TP1, TP2, TQ1, TResult> actionFactory)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerFactory)).CreateHandler(actionFactory));
            return this;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1, TP2> Query<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            ActionFactory<TController, TP1, TP2, TQ1, TQ2, TResult> actionFactory)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerFactory)).CreateHandler(actionFactory));
            return this;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1, TP2> Query<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            AsyncActionFactory<TController, TP1, TP2, TQ1, TQ2, TResult> actionFactory)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerFactory)).CreateHandler(actionFactory));
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
        private readonly Factory<TController> _controllerFactory;
        private readonly List<ParameterCollectorHandle<TContext, TResult, TP1, TP2, TP3>> _handlers = new List<ParameterCollectorHandle<TContext, TResult, TP1, TP2, TP3>>();

        public QueryCollector(Factory<TController> controllerFactory)
        {
            _controllerFactory = controllerFactory;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1, TP2, TP3> Query(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            ActionFactory<TController, TP1, TP2, TP3, TResult> actionFactory)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerFactory)).CreateHandler(actionFactory));
            return this;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1, TP2, TP3> Query(
            ParameterCollectorFiller<TContext, TResult, TController> filler,
            AsyncActionFactory<TController, TP1, TP2, TP3, TResult> actionFactory)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerFactory)).CreateHandler(actionFactory));
            return this;
        }

        public QueryCollector<TContext, TResult, TController, TP1, TP2, TP3> Query<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            ActionFactory<TController, TP1, TP2, TP3, TQ1, TResult> actionFactory)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerFactory)).CreateHandler(actionFactory));
            return this;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1, TP2, TP3> Query<TQ1>(
            ParameterCollectorFiller<TContext, TQ1, TResult, TController> filler,
            AsyncActionFactory<TController, TP1, TP2, TP3, TQ1, TResult> actionFactory)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerFactory)).CreateHandler(actionFactory));
            return this;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1, TP2, TP3> Query<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            ActionFactory<TController, TP1, TP2, TP3, TQ1, TQ2, TResult> actionFactory)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerFactory)).CreateHandler(actionFactory));
            return this;
        }
        
        public QueryCollector<TContext, TResult, TController, TP1, TP2, TP3> Query<TQ1, TQ2>(
            ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController> filler,
            AsyncActionFactory<TController, TP1, TP2, TP3, TQ1, TQ2, TResult> actionFactory)
        {
            _handlers.Insert(0, filler(new ParameterCollector<TContext, TResult, TController>(_controllerFactory)).CreateHandler(actionFactory));
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
