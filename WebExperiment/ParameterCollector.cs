using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebExperiment
{
    public static class ParValExtBldr
    {
        public static ValueExtractor<TContext, T> CreateContext<TContext, T>(Func<TContext, T> parser) => (context, parameters, ct) =>
            parser(context);
        
        public static ValueExtractor<TContext, T> CreateSingle<TContext, T>(string name, Func<string, T> parser) => (context, parameters, ct) =>
            parser(parameters[name]);

        public static ValueExtractor<TContext, T> CreateSingle<TContext, T>(string name, Func<string, T> parser, T def) => (context, parameters, ct) =>
        {
            var str = (parameters.GetValues(name) ?? Enumerable.Empty<string>()).LastOrDefault();
            return str == null ? def : parser(str);
        };

        public static ValueExtractor<TContext, IEnumerable<T>> CreateArray<TContext, T>(string name, Func<string, T> parser) => (context, parameters, ct) =>
            (parameters.GetValues(name) ?? Enumerable.Empty<string>()).Select(parser);
        
        public static ValueExtractor<TContext, CancellationToken> CreateCancellationToken<TContext>() => (context, parameters, ct) => ct;
    }
    
    public class ParameterCollector<TContext, TResult, TController>
    {
        private readonly Factory<TController> _controllerFactory;

        public ParameterCollector(Factory<TController> controllerFactory)
        {
            _controllerFactory = controllerFactory;
        }

        public ParameterCollector<TContext, T, TResult, TController> Context<T>(Func<TContext, T> f, uint priority = 0) =>
            new ParameterCollector<TContext, T, TResult, TController>(_controllerFactory) { Q1 = ParValExtBldr.CreateContext(f)};
        
        public ParameterCollector<TContext, T, TResult, TController> Single<T>(string name, Func<string, T> parser) =>
            new ParameterCollector<TContext, T, TResult, TController>(_controllerFactory) { Q1 = ParValExtBldr.CreateSingle<TContext, T>(name, parser)};

        public ParameterCollector<TContext, T, TResult, TController> Single<T>(string name, Func<string, T> parser, T def) =>
            new ParameterCollector<TContext, T, TResult, TController>(_controllerFactory) { Q1 = ParValExtBldr.CreateSingle<TContext, T>(name, parser, def)};

        public ParameterCollector<TContext, IEnumerable<T>, TResult, TController> Array<T>(string name, Func<string, T> parser) =>
            new ParameterCollector<TContext, IEnumerable<T>, TResult, TController>(_controllerFactory) { Q1 = ParValExtBldr.CreateArray<TContext, T>(name, parser)};

        public ParameterCollectorHandle<TContext, TResult> CreateHandler(ActionFactory<TController, TResult> actionFactory) =>
            (query, context, ct) => Task.FromResult(actionFactory(_controllerFactory)());

        public ParameterCollectorHandle<TContext, TResult> CreateHandler(AsyncActionFactory<TController, TResult> actionFactory) =>
            (query, context, ct) => actionFactory(_controllerFactory)();
        
        public ParameterCollectorHandle<TContext, TResult, TP1> CreateHandler<TP1>(ActionFactory<TController, TP1, TResult> actionFactory) =>
            (query, context, p1, ct) => Task.FromResult(actionFactory(_controllerFactory)(p1));
        
        public ParameterCollectorHandle<TContext, TResult, TP1> CreateHandler<TP1>(AsyncActionFactory<TController, TP1, TResult> actionFactory) =>
            (query, context, p1, ct) => actionFactory(_controllerFactory)(p1);
        
        public ParameterCollectorHandle<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(ActionFactory<TController, TP1, TP2, TResult> actionFactory) =>
            (query, context, p1, p2, ct) => Task.FromResult(actionFactory(_controllerFactory)(p1, p2));
        
        public ParameterCollectorHandle<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(AsyncActionFactory<TController, TP1, TP2, TResult> actionFactory) =>
            (query, context, p1, p2, ct) => actionFactory(_controllerFactory)(p1, p2);
    }

    public class ParameterCollector<TContext, TQ1, TResult, TController>
    {
        private readonly Factory<TController> _controllerFactory;

        public ParameterCollector(Factory<TController> controllerFactory)
        {
            _controllerFactory = controllerFactory;
        }
        
        public ValueExtractor<TContext, TQ1> Q1 { get; set; }
        
        public ParameterCollector<TContext, TQ1, T, TResult, TController> Context<T>(Func<TContext, T> f, uint priority = 0) =>
            new ParameterCollector<TContext, TQ1, T, TResult, TController>(_controllerFactory) { Q1 = Q1, Q2 = ParValExtBldr.CreateContext(f)};

        public ParameterCollector<TContext, TQ1, T, TResult, TController> Single<T>(string name, Func<string, T> parser) =>
            new ParameterCollector<TContext, TQ1, T, TResult, TController>(_controllerFactory) { Q1 = Q1, Q2 = ParValExtBldr.CreateSingle<TContext, T>(name, parser) };
        
        public ParameterCollector<TContext, TQ1, T, TResult, TController> Single<T>(string name, Func<string, T> parser, T def) =>
            new ParameterCollector<TContext, TQ1, T, TResult, TController>(_controllerFactory) { Q1 = Q1, Q2 = ParValExtBldr.CreateSingle<TContext, T>(name, parser, def) };
        
        public ParameterCollector<TContext, TQ1, IEnumerable<T>, TResult, TController> Array<T>(string name, Func<string, T> parser) =>
            new ParameterCollector<TContext, TQ1, IEnumerable<T>, TResult, TController>(_controllerFactory) { Q1 = Q1, Q2 = ParValExtBldr.CreateArray<TContext, T>(name, parser) };
        
        public ParameterCollector<TContext, TQ1, CancellationToken, TResult, TController> CancellationToken() =>
            new ParameterCollector<TContext, TQ1, CancellationToken, TResult, TController>(_controllerFactory) { Q1 = Q1, Q2 = ParValExtBldr.CreateCancellationToken<TContext>()};
        
        public ParameterCollectorHandle<TContext, TResult> CreateHandler(ActionFactory<TController, TQ1, TResult> actionFactory) =>
            (query, context, ct) => Task.FromResult(actionFactory(_controllerFactory)(Q1(context, query, ct)));
        
        public ParameterCollectorHandle<TContext, TResult> CreateHandler(AsyncActionFactory<TController, TQ1, TResult> actionFactory) =>
            (query, context, ct) => actionFactory(_controllerFactory)(Q1(context, query, ct));
        
        public ParameterCollectorHandle<TContext, TResult, TP1> CreateHandler<TP1>(ActionFactory<TController, TP1, TQ1, TResult> actionFactory) =>
            (query, context, p1, ct) => Task.FromResult(actionFactory(_controllerFactory)(p1, Q1(context, query, ct)));
        
        public ParameterCollectorHandle<TContext, TResult, TP1> CreateHandler<TP1>(AsyncActionFactory<TController, TP1, TQ1, TResult> actionFactory) =>
            (query, context, p1, ct) => actionFactory(_controllerFactory)(p1, Q1(context, query, ct));
        
        public ParameterCollectorHandle<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(ActionFactory<TController, TP1, TP2, TQ1, TResult> actionFactory) =>
            (query, context, p1, p2, ct) => Task.FromResult(actionFactory(_controllerFactory)(p1, p2, Q1(context, query, ct)));
        
        public ParameterCollectorHandle<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(AsyncActionFactory<TController, TP1, TP2, TQ1, TResult> actionFactory) =>
            (query, context, p1, p2, ct) => actionFactory(_controllerFactory)(p1, p2, Q1(context, query, ct));
    }

    public class ParameterCollector<TContext, TQ1, TQ2, TResult, TController>
    {
        private readonly Factory<TController> _controllerFactory;

        public ParameterCollector(Factory<TController> controllerFactory)
        {
            _controllerFactory = controllerFactory;
        }
        
        public ValueExtractor<TContext, TQ1> Q1 { get; set; }
        public ValueExtractor<TContext, TQ2> Q2 { get; set; }
        
        public ParameterCollectorHandle<TContext, TResult> CreateHandler(ActionFactory<TController, TQ1, TQ2, TResult> actionFactory) =>
            (query, context, ct) => Task.FromResult(actionFactory(_controllerFactory)(Q1(context, query, ct), Q2(context, query, ct)));
        
        public ParameterCollectorHandle<TContext, TResult> CreateHandler(AsyncActionFactory<TController, TQ1, TQ2, TResult> actionFactory) =>
            (query, context, ct) => actionFactory(_controllerFactory)(Q1(context, query, ct), Q2(context, query, ct));
        
        public ParameterCollectorHandle<TContext, TResult, TP1> CreateHandler<TP1>(ActionFactory<TController, TP1, TQ1, TQ2, TResult> actionFactory) =>
            (query, context, p1, ct) => Task.FromResult(actionFactory(_controllerFactory)(p1, Q1(context, query, ct), Q2(context, query, ct)));
        
        public ParameterCollectorHandle<TContext, TResult, TP1> CreateHandler<TP1>(AsyncActionFactory<TController, TP1, TQ1, TQ2, TResult> actionFactory) =>
            (query, context, p1, ct) => actionFactory(_controllerFactory)(p1, Q1(context, query, ct), Q2(context, query, ct));
        
        public ParameterCollectorHandle<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(ActionFactory<TController, TP1, TP2, TQ1, TQ2, TResult> actionFactory) =>
            (query, context, p1, p2, ct) => Task.FromResult(actionFactory(_controllerFactory)(p1, p2, Q1(context, query, ct), Q2(context, query, ct)));
        
        public ParameterCollectorHandle<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(AsyncActionFactory<TController, TP1, TP2, TQ1, TQ2, TResult> actionFactory) =>
            (query, context, p1, p2, ct) => actionFactory(_controllerFactory)(p1, p2, Q1(context, query, ct), Q2(context, query, ct));
    }
}
