using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace WebExperiment
{
    public class ParameterCollector<TContext, TResult, TController>
    {
        private readonly Factory<TController> _controllerFactory;

        public ParameterCollector(Factory<TController> controllerFactory)
        {
            _controllerFactory = controllerFactory;
        }

        private ParameterCollector<TContext, T, TResult, TController> CreateNext<T>(ValueExtractor<TContext, T> valueExtractor) =>
            new ParameterCollector<TContext, T, TResult, TController>(_controllerFactory) { Q1 = valueExtractor};

        public ParameterCollector<TContext, T, TResult, TController> Context<T>(Transformer<TContext, T> f, uint priority = 0) =>
            CreateNext(ValueExtractors.Context(f));
        
        public ParameterCollector<TContext, CancellationToken, TResult, TController> CancellationToken() =>
            CreateNext(ValueExtractors.CancellationToken<TContext>());
        
        public ParameterCollector<TContext, T, TResult, TController> Single<T>(string name, Parser<T> parser) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser));

        public ParameterCollector<TContext, T, TResult, TController> Single<T>(string name, Parser<T> parser, T def) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser, def));

        public ParameterCollector<TContext, IEnumerable<T>, TResult, TController> Array<T>(string name, Parser<T> parser) =>
            CreateNext(ValueExtractors.Array<TContext, T>(name, parser));

        public ParameterCollectorHandler<TContext, TResult> CreateHandler(ActionFactory<TController, TResult> actionFactory) =>
            (query, context, ct) => Task.FromResult(actionFactory(_controllerFactory)());

        public ParameterCollectorHandler<TContext, TResult> CreateHandler(AsyncActionFactory<TController, TResult> actionFactory) =>
            (query, context, ct) => actionFactory(_controllerFactory)();
        
        public ParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(ActionFactory<TController, TP1, TResult> actionFactory) =>
            (query, context, p1, ct) => Task.FromResult(actionFactory(_controllerFactory)(p1));
        
        public ParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(AsyncActionFactory<TController, TP1, TResult> actionFactory) =>
            (query, context, p1, ct) => actionFactory(_controllerFactory)(p1);
        
        public ParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(ActionFactory<TController, TP1, TP2, TResult> actionFactory) =>
            (query, context, p1, p2, ct) => Task.FromResult(actionFactory(_controllerFactory)(p1, p2));
        
        public ParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(AsyncActionFactory<TController, TP1, TP2, TResult> actionFactory) =>
            (query, context, p1, p2, ct) => actionFactory(_controllerFactory)(p1, p2);
        
        public ParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(ActionFactory<TController, TP1, TP2, TP3, TResult> actionFactory) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(actionFactory(_controllerFactory)(p1, p2, p3));
        
        public ParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(AsyncActionFactory<TController, TP1, TP2, TP3, TResult> actionFactory) =>
            (query, context, p1, p2, p3, ct) => actionFactory(_controllerFactory)(p1, p2, p3);
    }

    public class ParameterCollector<TContext, TQ1, TResult, TController>
    {
        private readonly Factory<TController> _controllerFactory;

        public ParameterCollector(Factory<TController> controllerFactory)
        {
            _controllerFactory = controllerFactory;
        }
        
        public ValueExtractor<TContext, TQ1> Q1 { get; set; }
        
        private ParameterCollector<TContext, TQ1, T, TResult, TController> CreateNext<T>(ValueExtractor<TContext, T> valueExtractor) =>
            new ParameterCollector<TContext, TQ1, T, TResult, TController>(_controllerFactory) { Q1 = Q1, Q2 = valueExtractor};
        
        public ParameterCollector<TContext, TQ1, T, TResult, TController> Context<T>(Transformer<TContext, T> f, uint priority = 0) =>
            CreateNext(ValueExtractors.Context(f));
        
        public ParameterCollector<TContext, TQ1, CancellationToken, TResult, TController> CancellationToken() =>
            CreateNext(ValueExtractors.CancellationToken<TContext>());
        
        public ParameterCollector<TContext, TQ1, T, TResult, TController> Single<T>(string name, Parser<T> parser) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser));
        
        public ParameterCollector<TContext, TQ1, T, TResult, TController> Single<T>(string name, Parser<T> parser, T def) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser, def));
        
        public ParameterCollector<TContext, TQ1, IEnumerable<T>, TResult, TController> Array<T>(string name, Parser<T> parser) =>
            CreateNext(ValueExtractors.Array<TContext, T>(name, parser));
        
        public ParameterCollectorHandler<TContext, TResult> CreateHandler(ActionFactory<TController, TQ1, TResult> actionFactory) =>
            (query, context, ct) => Task.FromResult(actionFactory(_controllerFactory)(Q1(context, query, ct)));
        
        public ParameterCollectorHandler<TContext, TResult> CreateHandler(AsyncActionFactory<TController, TQ1, TResult> actionFactory) =>
            (query, context, ct) => actionFactory(_controllerFactory)(Q1(context, query, ct));
        
        public ParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(ActionFactory<TController, TP1, TQ1, TResult> actionFactory) =>
            (query, context, p1, ct) => Task.FromResult(actionFactory(_controllerFactory)(p1, Q1(context, query, ct)));
        
        public ParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(AsyncActionFactory<TController, TP1, TQ1, TResult> actionFactory) =>
            (query, context, p1, ct) => actionFactory(_controllerFactory)(p1, Q1(context, query, ct));
        
        public ParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(ActionFactory<TController, TP1, TP2, TQ1, TResult> actionFactory) =>
            (query, context, p1, p2, ct) => Task.FromResult(actionFactory(_controllerFactory)(p1, p2, Q1(context, query, ct)));
        
        public ParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(AsyncActionFactory<TController, TP1, TP2, TQ1, TResult> actionFactory) =>
            (query, context, p1, p2, ct) => actionFactory(_controllerFactory)(p1, p2, Q1(context, query, ct));
        
        public ParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(ActionFactory<TController, TP1, TP2, TP3, TQ1, TResult> actionFactory) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(actionFactory(_controllerFactory)(p1, p2, p3, Q1(context, query, ct)));
        
        public ParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(AsyncActionFactory<TController, TP1, TP2, TP3, TQ1, TResult> actionFactory) =>
            (query, context, p1, p2, p3, ct) => actionFactory(_controllerFactory)(p1, p2, p3, Q1(context, query, ct));
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
        
        
        
        private ParameterCollector<TContext, TQ1, TQ2, T, TResult, TController> CreateNext<T>(ValueExtractor<TContext, T> valueExtractor) =>
            new ParameterCollector<TContext, TQ1, TQ2, T, TResult, TController>(_controllerFactory) { Q1 = Q1, Q2 = Q2, Q3 = valueExtractor};
        
        public ParameterCollector<TContext, TQ1, TQ2, T, TResult, TController> Context<T>(Transformer<TContext, T> f, uint priority = 0) =>
            CreateNext(ValueExtractors.Context(f));
        
        public ParameterCollector<TContext, TQ1, TQ2, CancellationToken, TResult, TController> CancellationToken() =>
            CreateNext(ValueExtractors.CancellationToken<TContext>());
        
        public ParameterCollector<TContext, TQ1, TQ2, T, TResult, TController> Single<T>(string name, Parser<T> parser) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser));
        
        public ParameterCollector<TContext, TQ1, TQ2, T, TResult, TController> Single<T>(string name, Parser<T> parser, T def) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser, def));
        
        public ParameterCollector<TContext, TQ1, TQ2, IEnumerable<T>, TResult, TController> Array<T>(string name, Parser<T> parser) =>
            CreateNext(ValueExtractors.Array<TContext, T>(name, parser));
        
        public ParameterCollectorHandler<TContext, TResult> CreateHandler(ActionFactory<TController, TQ1, TQ2, TResult> actionFactory) =>
            (query, context, ct) => Task.FromResult(actionFactory(_controllerFactory)(Q1(context, query, ct), Q2(context, query, ct)));
        
        public ParameterCollectorHandler<TContext, TResult> CreateHandler(AsyncActionFactory<TController, TQ1, TQ2, TResult> actionFactory) =>
            (query, context, ct) => actionFactory(_controllerFactory)(Q1(context, query, ct), Q2(context, query, ct));
        
        public ParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(ActionFactory<TController, TP1, TQ1, TQ2, TResult> actionFactory) =>
            (query, context, p1, ct) => Task.FromResult(actionFactory(_controllerFactory)(p1, Q1(context, query, ct), Q2(context, query, ct)));
        
        public ParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(AsyncActionFactory<TController, TP1, TQ1, TQ2, TResult> actionFactory) =>
            (query, context, p1, ct) => actionFactory(_controllerFactory)(p1, Q1(context, query, ct), Q2(context, query, ct));
        
        public ParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(ActionFactory<TController, TP1, TP2, TQ1, TQ2, TResult> actionFactory) =>
            (query, context, p1, p2, ct) => Task.FromResult(actionFactory(_controllerFactory)(p1, p2, Q1(context, query, ct), Q2(context, query, ct)));
        
        public ParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(AsyncActionFactory<TController, TP1, TP2, TQ1, TQ2, TResult> actionFactory) =>
            (query, context, p1, p2, ct) => actionFactory(_controllerFactory)(p1, p2, Q1(context, query, ct), Q2(context, query, ct));
        
        public ParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(ActionFactory<TController, TP1, TP2, TP3, TQ1, TQ2, TResult> actionFactory) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(actionFactory(_controllerFactory)(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct)));
        
        public ParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(AsyncActionFactory<TController, TP1, TP2, TP3, TQ1, TQ2, TResult> actionFactory) =>
            (query, context, p1, p2, p3, ct) => actionFactory(_controllerFactory)(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct));
    }

    public class ParameterCollector<TContext, TQ1, TQ2, TQ3, TResult, TController>
    {
        private readonly Factory<TController> _controllerFactory;

        public ParameterCollector(Factory<TController> controllerFactory)
        {
            _controllerFactory = controllerFactory;
        }

        public ValueExtractor<TContext, TQ1> Q1 { get; set; }
        public ValueExtractor<TContext, TQ2> Q2 { get; set; }
        public ValueExtractor<TContext, TQ3> Q3 { get; set; }
        
//        private ParameterCollector<TContext, TQ1, TQ2, TQ3, T, TResult, TController> CreateNext<T>(ValueExtractor<TContext, T> valueExtractor) =>
//            new ParameterCollector<TContext, TQ1, TQ2, TQ3, T, TResult, TController>(_controllerFactory) { Q1 = Q1, Q2 = Q2, Q3 = Q3, Q4 = valueExtractor};
//        
//        public ParameterCollector<TContext, TQ1, TQ2, TQ3, T, TResult, TController> Context<T>(Transformer<TContext, T> f, uint priority = 0) =>
//            CreateNext(ParValExtBldr.CreateContext(f));
//        
//        public ParameterCollector<TContext, TQ1, TQ2, TQ3, CancellationToken, TResult, TController> CancellationToken() =>
//            CreateNext(ParValExtBldr.CreateCancellationToken<TContext>());
//        
//        public ParameterCollector<TContext, TQ1, TQ2, TQ3, T, TResult, TController> Single<T>(string name, Parser<T> parser) =>
//            CreateNext(ParValExtBldr.CreateSingle<TContext, T>(name, parser));
//        
//        public ParameterCollector<TContext, TQ1, TQ2, TQ3, T, TResult, TController> Single<T>(string name, Parser<T> parser, T def) =>
//            CreateNext(ParValExtBldr.CreateSingle<TContext, T>(name, parser, def));
//        
//        public ParameterCollector<TContext, TQ1, TQ2, TQ3, IEnumerable<T>, TResult, TController> Array<T>(string name, Parser<T> parser) =>
//            CreateNext(ParValExtBldr.CreateArray<TContext, T>(name, parser));
        
        public ParameterCollectorHandler<TContext, TResult> CreateHandler(ActionFactory<TController, TQ1, TQ2, TQ3, TResult> actionFactory) =>
            (query, context, ct) => Task.FromResult(actionFactory(_controllerFactory)(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));
        
        public ParameterCollectorHandler<TContext, TResult> CreateHandler(AsyncActionFactory<TController, TQ1, TQ2, TQ3, TResult> actionFactory) =>
            (query, context, ct) => actionFactory(_controllerFactory)(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));
        
        public ParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(ActionFactory<TController, TP1, TQ1, TQ2, TQ3, TResult> actionFactory) =>
            (query, context, p1, ct) => Task.FromResult(actionFactory(_controllerFactory)(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));
        
        public ParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(AsyncActionFactory<TController, TP1, TQ1, TQ2, TQ3, TResult> actionFactory) =>
            (query, context, p1, ct) => actionFactory(_controllerFactory)(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));
        
        public ParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(ActionFactory<TController, TP1, TP2, TQ1, TQ2, TQ3, TResult> actionFactory) =>
            (query, context, p1, p2, ct) => Task.FromResult(actionFactory(_controllerFactory)(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));
        
        public ParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(AsyncActionFactory<TController, TP1, TP2, TQ1, TQ2, TQ3, TResult> actionFactory) =>
            (query, context, p1, p2, ct) => actionFactory(_controllerFactory)(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));
        
        public ParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(ActionFactory<TController, TP1, TP2, TP3, TQ1, TQ2, TQ3, TResult> actionFactory) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(actionFactory(_controllerFactory)(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));
        
        public ParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(AsyncActionFactory<TController, TP1, TP2, TP3, TQ1, TQ2, TQ3, TResult> actionFactory) =>
            (query, context, p1, p2, p3, ct) => actionFactory(_controllerFactory)(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));
    }
}
