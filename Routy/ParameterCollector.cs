using System.Threading;
using System.Threading.Tasks;

namespace Routy
{
    public class ParameterCollector<TContext, TParsedContext, TResult, TController>
    {
        private readonly Transformer<TContext, TParsedContext> _contextParser;
        private readonly Provider<TController> _controllerProvider;

        public ParameterCollector(Provider<TController> controllerProvider, Transformer<TContext, TParsedContext> contextParser)
        {
            _controllerProvider = controllerProvider;
            _contextParser = contextParser;
        }

        private ParameterCollector<TContext, TParsedContext, T, TResult, TController> CreateNext<T>(ValueExtractor<TContext, T> valueExtractor, Transformer<TContext, TParsedContext> contextParser) =>
            new ParameterCollector<TContext, TParsedContext, T, TResult, TController>(
            _controllerProvider, contextParser) {Q1 = valueExtractor};

        public ParameterCollector<TContext, TParsedContext, TParsedContext, TResult, TController> Context() =>
            CreateNext(ValueExtractors.Context(_contextParser), _contextParser);

        public ParameterCollector<TContext, TParsedContext, CancellationToken, TResult, TController> CancellationToken() =>
            CreateNext(ValueExtractors.CancellationToken<TContext>(), _contextParser);

        public ParameterCollector<TContext, TParsedContext, T, TResult, TController> Single<T>(string name, Parser<T> parser) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser), _contextParser);

        public ParameterCollector<TContext, TParsedContext, T, TResult, TController> Single<T>(string name, Parser<T> parser, T def) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser, def), _contextParser);

        public ParameterCollector<TContext, TParsedContext, T[], TResult, TController> Multiple<T>(string name, Parser<T> parser) =>
            CreateNext(ValueExtractors.Multiple<TContext, T>(name, parser), _contextParser);

        public ParameterCollector<TContext, TParsedContext, T, TResult, TController> Object<T>(NameValueCollectionParser<T> parser) =>
            CreateNext(ValueExtractors.Object<TContext, T>(parser), _contextParser);

        public ParameterCollectorHandler<TContext, TResult> CreateHandler(Handler<TResult> handler) =>
            (query, context, ct) => Task.FromResult(handler());

        public ParameterCollectorHandler<TContext, TResult> CreateHandler(HandlerProvider<TController, TResult> handlerProvider) =>
            (query, context, ct) => Task.FromResult(handlerProvider(_controllerProvider)());

        public ParameterCollectorHandler<TContext, TResult> CreateHandler(AsyncHandler<TResult> handler) =>
            (query, context, ct) => handler();

        public ParameterCollectorHandler<TContext, TResult> CreateHandler(AsyncHandlerProvider<TController, TResult> handlerProvider) =>
            (query, context, ct) => handlerProvider(_controllerProvider)();

        public ParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(Handler<TP1, TResult> handler) =>
            (query, context, p1, ct) => Task.FromResult(handler(p1));

        public ParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(HandlerProvider<TController, TP1, TResult> handlerProvider) =>
            (query, context, p1, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1));

        public ParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(AsyncHandler<TP1, TResult> handler) =>
            (query, context, p1, ct) => handler(p1);

        public ParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(AsyncHandlerProvider<TController, TP1, TResult> handlerProvider) =>
            (query, context, p1, ct) => handlerProvider(_controllerProvider)(p1);

        public ParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(Handler<TP1, TP2, TResult> handler) =>
            (query, context, p1, p2, ct) => Task.FromResult(handler(p1, p2));

        public ParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(HandlerProvider<TController, TP1, TP2, TResult> handlerProvider) =>
            (query, context, p1, p2, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2));

        public ParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(AsyncHandler<TP1, TP2, TResult> handler) =>
            (query, context, p1, p2, ct) => handler(p1, p2);

        public ParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(AsyncHandlerProvider<TController, TP1, TP2, TResult> handlerProvider) =>
            (query, context, p1, p2, ct) => handlerProvider(_controllerProvider)(p1, p2);

        public ParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(Handler<TP1, TP2, TP3, TResult> handler) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handler(p1, p2, p3));

        public ParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(HandlerProvider<TController, TP1, TP2, TP3, TResult> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3));

        public ParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(AsyncHandler<TP1, TP2, TP3, TResult> handler) =>
            (query, context, p1, p2, p3, ct) => handler(p1, p2, p3);

        public ParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(AsyncHandlerProvider<TController, TP1, TP2, TP3, TResult> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => handlerProvider(_controllerProvider)(p1, p2, p3);
    }

    public class ParameterCollector<TContext, TParsedContext, TQ1, TResult, TController>
    {
        private readonly Provider<TController> _controllerProvider;
        private readonly Transformer<TContext, TParsedContext> _contextParser;

        public ParameterCollector(Provider<TController> controllerProvider, Transformer<TContext, TParsedContext> contextParser)
        {
            _controllerProvider = controllerProvider;
            _contextParser = contextParser;
        }
        
        public ValueExtractor<TContext, TQ1> Q1 { get; set; }
        
        private ParameterCollector<TContext, TParsedContext, TQ1, T, TResult, TController> CreateNext<T>(ValueExtractor<TContext, T> valueExtractor, Transformer<TContext, TParsedContext> contextParser) =>
            new ParameterCollector<TContext, TParsedContext, TQ1, T, TResult, TController>(_controllerProvider, contextParser) { Q1 = Q1, Q2 = valueExtractor};
        
        public ParameterCollector<TContext, TParsedContext, TQ1, TParsedContext, TResult, TController> Context() =>
            CreateNext(ValueExtractors.Context(_contextParser), _contextParser);
        
        public ParameterCollector<TContext, TParsedContext, TQ1, CancellationToken, TResult, TController> CancellationToken() =>
            CreateNext(ValueExtractors.CancellationToken<TContext>(), _contextParser);
        
        public ParameterCollector<TContext, TParsedContext, TQ1, T, TResult, TController> Single<T>(string name, Parser<T> parser) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser), _contextParser);
        
        public ParameterCollector<TContext, TParsedContext, TQ1, T, TResult, TController> Single<T>(string name, Parser<T> parser, T def) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser, def), _contextParser);
        
        public ParameterCollector<TContext, TParsedContext, TQ1, T[], TResult, TController> Multiple<T>(string name, Parser<T> parser) =>
            CreateNext(ValueExtractors.Multiple<TContext, T>(name, parser), _contextParser);

        public ParameterCollector<TContext, TParsedContext, TQ1, T, TResult, TController> Object<T>(NameValueCollectionParser<T> parser) =>
            CreateNext(ValueExtractors.Object<TContext, T>(parser), _contextParser);
        
        public ParameterCollectorHandler<TContext, TResult> CreateHandler(Handler<TQ1, TResult> handler) =>
            (query, context, ct) => Task.FromResult(handler(Q1(context, query, ct)));

        public ParameterCollectorHandler<TContext, TResult> CreateHandler(HandlerProvider<TController, TQ1, TResult> handlerProvider) =>
            (query, context, ct) => Task.FromResult(handlerProvider(_controllerProvider)(Q1(context, query, ct)));
        
        public ParameterCollectorHandler<TContext, TResult> CreateHandler(AsyncHandler<TQ1, TResult> handler) =>
            (query, context, ct) => handler(Q1(context, query, ct));

        public ParameterCollectorHandler<TContext, TResult> CreateHandler(AsyncHandlerProvider<TController, TQ1, TResult> handlerProvider) =>
            (query, context, ct) => handlerProvider(_controllerProvider)(Q1(context, query, ct));
        
        public ParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(Handler<TP1, TQ1, TResult> handler) =>
            (query, context, p1, ct) => Task.FromResult(handler(p1, Q1(context, query, ct)));

        public ParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(HandlerProvider<TController, TP1, TQ1, TResult> handlerProvider) =>
            (query, context, p1, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, Q1(context, query, ct)));
        
        public ParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(AsyncHandler<TP1, TQ1, TResult> handler) =>
            (query, context, p1, ct) => handler(p1, Q1(context, query, ct));

        public ParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(AsyncHandlerProvider<TController, TP1, TQ1, TResult> handlerProvider) =>
            (query, context, p1, ct) => handlerProvider(_controllerProvider)(p1, Q1(context, query, ct));
        
        public ParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(Handler<TP1, TP2, TQ1, TResult> handler) =>
            (query, context, p1, p2, ct) => Task.FromResult(handler(p1, p2, Q1(context, query, ct)));

        public ParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(HandlerProvider<TController, TP1, TP2, TQ1, TResult> handlerProvider) =>
            (query, context, p1, p2, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct)));
        
        public ParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(AsyncHandler<TP1, TP2, TQ1, TResult> handler) =>
            (query, context, p1, p2, ct) => handler(p1, p2, Q1(context, query, ct));

        public ParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(AsyncHandlerProvider<TController, TP1, TP2, TQ1, TResult> handlerProvider) =>
            (query, context, p1, p2, ct) => handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct));
        
        public ParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(Handler<TP1, TP2, TP3, TQ1, TResult> handler) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handler(p1, p2, p3, Q1(context, query, ct)));

        public ParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(HandlerProvider<TController, TP1, TP2, TP3, TQ1, TResult> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, Q1(context, query, ct)));
        
        public ParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(AsyncHandler<TP1, TP2, TP3, TQ1, TResult> handler) =>
            (query, context, p1, p2, p3, ct) => handler(p1, p2, p3, Q1(context, query, ct));

        public ParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(AsyncHandlerProvider<TController, TP1, TP2, TP3, TQ1, TResult> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, Q1(context, query, ct));
        
        public ParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TP17, TP18, TP19, TP20> CreateHandler2<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TP17, TP18, TP19, TP20>(AsyncHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TP17, TP18, TP19, TP20, TQ1, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20, Q1(context, query, ct));

        public ParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TP17, TP18, TP19, TP20> CreateHandler2<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TP17, TP18, TP19, TP20>(AsyncHandlerProvider<TController, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TP17, TP18, TP19, TP20, TQ1, TResult> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20, Q1(context, query, ct));
    }

    public class ParameterCollector<TContext, TParsedContext, TQ1, TQ2, TResult, TController>
    {
        private readonly Provider<TController> _controllerProvider;
        private readonly Transformer<TContext, TParsedContext> _contextParser;

        public ParameterCollector(Provider<TController> controllerProvider, Transformer<TContext, TParsedContext> contextParser)
        {
            _controllerProvider = controllerProvider;
            _contextParser = contextParser;
        }
        
        public ValueExtractor<TContext, TQ1> Q1 { get; set; }
        public ValueExtractor<TContext, TQ2> Q2 { get; set; }
        
        
        
        private ParameterCollector<TContext, TParsedContext, TQ1, TQ2, T, TResult, TController> CreateNext<T>(ValueExtractor<TContext, T> valueExtractor, Transformer<TContext, TParsedContext> contextParser) =>
            new ParameterCollector<TContext, TParsedContext, TQ1, TQ2, T, TResult, TController>(_controllerProvider, contextParser) { Q1 = Q1, Q2 = Q2, Q3 = valueExtractor};
        
        public ParameterCollector<TContext, TParsedContext, TQ1, TQ2, T, TResult, TController> Context<T>(Transformer<TContext, T> f) =>
            CreateNext(ValueExtractors.Context(f), _contextParser);
        
        public ParameterCollector<TContext, TParsedContext, TQ1, TQ2, CancellationToken, TResult, TController> CancellationToken() =>
            CreateNext(ValueExtractors.CancellationToken<TContext>(), _contextParser);
        
        public ParameterCollector<TContext, TParsedContext, TQ1, TQ2, T, TResult, TController> Single<T>(string name, Parser<T> parser) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser), _contextParser);
        
        public ParameterCollector<TContext, TParsedContext, TQ1, TQ2, T, TResult, TController> Single<T>(string name, Parser<T> parser, T def) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser, def), _contextParser);
        
        public ParameterCollector<TContext, TParsedContext, TQ1, TQ2, T[], TResult, TController> Multiple<T>(string name, Parser<T> parser) =>
            CreateNext(ValueExtractors.Multiple<TContext, T>(name, parser), _contextParser);

        public ParameterCollector<TContext, TParsedContext, TQ1, TQ2, T, TResult, TController> Object<T>(NameValueCollectionParser<T> parser) =>
            CreateNext(ValueExtractors.Object<TContext, T>(parser), _contextParser);
        
        public ParameterCollectorHandler<TContext, TResult> CreateHandler(Handler<TQ1, TQ2, TResult> handler) =>
            (query, context, ct) => Task.FromResult(handler(Q1(context, query, ct), Q2(context, query, ct)));

        public ParameterCollectorHandler<TContext, TResult> CreateHandler(HandlerProvider<TController, TQ1, TQ2, TResult> handlerProvider) =>
            (query, context, ct) => Task.FromResult(handlerProvider(_controllerProvider)(Q1(context, query, ct), Q2(context, query, ct)));
        
        public ParameterCollectorHandler<TContext, TResult> CreateHandler(AsyncHandler<TQ1, TQ2, TResult> handler) =>
            (query, context, ct) => handler(Q1(context, query, ct), Q2(context, query, ct));

        public ParameterCollectorHandler<TContext, TResult> CreateHandler(AsyncHandlerProvider<TController, TQ1, TQ2, TResult> handlerProvider) =>
            (query, context, ct) => handlerProvider(_controllerProvider)(Q1(context, query, ct), Q2(context, query, ct));
        
        public ParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(Handler<TP1, TQ1, TQ2, TResult> handler) =>
            (query, context, p1, ct) => Task.FromResult(handler(p1, Q1(context, query, ct), Q2(context, query, ct)));

        public ParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(HandlerProvider<TController, TP1, TQ1, TQ2, TResult> handlerProvider) =>
            (query, context, p1, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, Q1(context, query, ct), Q2(context, query, ct)));
        
        public ParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(AsyncHandler<TP1, TQ1, TQ2, TResult> handler) =>
            (query, context, p1, ct) => handler(p1, Q1(context, query, ct), Q2(context, query, ct));

        public ParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(AsyncHandlerProvider<TController, TP1, TQ1, TQ2, TResult> handlerProvider) =>
            (query, context, p1, ct) => handlerProvider(_controllerProvider)(p1, Q1(context, query, ct), Q2(context, query, ct));
        
        public ParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(Handler<TP1, TP2, TQ1, TQ2, TResult> handler) =>
            (query, context, p1, p2, ct) => Task.FromResult(handler(p1, p2, Q1(context, query, ct), Q2(context, query, ct)));

        public ParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(HandlerProvider<TController, TP1, TP2, TQ1, TQ2, TResult> handlerProvider) =>
            (query, context, p1, p2, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct), Q2(context, query, ct)));
        
        public ParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(AsyncHandler<TP1, TP2, TQ1, TQ2, TResult> handler) =>
            (query, context, p1, p2, ct) => handler(p1, p2, Q1(context, query, ct), Q2(context, query, ct));

        public ParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(AsyncHandlerProvider<TController, TP1, TP2, TQ1, TQ2, TResult> handlerProvider) =>
            (query, context, p1, p2, ct) => handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct), Q2(context, query, ct));
        
        public ParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(Handler<TP1, TP2, TP3, TQ1, TQ2, TResult> handler) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handler(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct)));

        public ParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(HandlerProvider<TController, TP1, TP2, TP3, TQ1, TQ2, TResult> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct)));
        
        public ParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(AsyncHandler<TP1, TP2, TP3, TQ1, TQ2, TResult> handler) =>
            (query, context, p1, p2, p3, ct) => handler(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct));

        public ParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(AsyncHandlerProvider<TController, TP1, TP2, TP3, TQ1, TQ2, TResult> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct));
    }

    public class ParameterCollector<TContext, TParsedContext, TQ1, TQ2, TQ3, TResult, TController>
    {
        private readonly Provider<TController> _controllerProvider;
        private readonly Transformer<TContext, TParsedContext> _contextParser;

        public ParameterCollector(Provider<TController> controllerProvider, Transformer<TContext, TParsedContext> contextParser)
        {
            _controllerProvider = controllerProvider;
            _contextParser = contextParser;
        }

        public ValueExtractor<TContext, TQ1> Q1 { get; set; }
        public ValueExtractor<TContext, TQ2> Q2 { get; set; }
        public ValueExtractor<TContext, TQ3> Q3 { get; set; }
        
        //public ParameterCollector<TContext, TQ1, TQ2, TQ3, T, TResult, TController> CreateNext<T>(ContextualValueExtractor<TContext, T> valueExtractor) =>
        //    new ContextualParameterCollector<TContext, TQ1, TQ2, TQ3, T, TResult, TController>(_controllerProvider) { Q1 = Q1, Q2 = Q2, Q3 = Q3, Q4 = valueExtractor};
        
        //public ParameterCollector<TContext, TQ1, TQ2, TQ3, T, TResult, TController> Context<T>(Transformer<TContext, T> f) =>
        //    CreateNext(ValueExtractors.Context(f));
        
        //public ParameterCollector<TContext, TQ1, TQ2, TQ3, CancellationToken, TResult, TController> CancellationToken() =>
        //    CreateNext(ValueExtractors.CancellationToken<TContext>());
        
        //public ParameterCollector<TContext, TQ1, TQ2, TQ3, T, TResult, TController> Single<T>(string name, Parser<T> parser) =>
        //    CreateNext(ValueExtractors.Single<TContext, T>(name, parser));
        
        //public ParameterCollector<TContext, TQ1, TQ2, TQ3, T, TResult, TController> Single<T>(string name, Parser<T> parser, T def) =>
        //    CreateNext(ValueExtractors.Single<TContext, T>(name, parser, def));
        
        //public ParameterCollector<TContext, TQ1, TQ2, TQ3, T[], TResult, TController> Multiple<T>(string name, Parser<T> parser) =>
        //    CreateNext(ValueExtractors.Multiple<TContext, T>(name, parser));

        //public ParameterCollector<TContext, TQ1, TQ2, TQ3, T, TResult, TController> Object<T>(NameValueCollectionParser<T> parser) =>
        //    CreateNext(ValueExtractors.Object<TContext, T>(parser));

        public ParameterCollectorHandler<TContext, TResult> CreateHandler(Handler<TQ1, TQ2, TQ3, TResult> handler) =>
            (query, context, ct) => Task.FromResult(handler(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));
        
        public ParameterCollectorHandler<TContext, TResult> CreateHandler(AsyncHandler<TQ1, TQ2, TQ3, TResult> handler) =>
            (query, context, ct) => handler(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));
        
        public ParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(Handler<TP1, TQ1, TQ2, TQ3, TResult> handler) =>
            (query, context, p1, ct) => Task.FromResult(handler(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));
        
        public ParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(AsyncHandler<TP1, TQ1, TQ2, TQ3, TResult> handler) =>
            (query, context, p1, ct) => handler(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));
        
        public ParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(Handler<TP1, TP2, TQ1, TQ2, TQ3, TResult> handler) =>
            (query, context, p1, p2, ct) => Task.FromResult(handler(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));
        
        public ParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(AsyncHandler<TP1, TP2, TQ1, TQ2, TQ3, TResult> handler) =>
            (query, context, p1, p2, ct) => handler(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));
        
        public ParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(Handler<TP1, TP2, TP3, TQ1, TQ2, TQ3, TResult> handler) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handler(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));
        
        public ParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(AsyncHandler<TP1, TP2, TP3, TQ1, TQ2, TQ3, TResult> handler) =>
            (query, context, p1, p2, p3, ct) => handler(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));



        public ParameterCollectorHandler<TContext, TResult> CreateHandler(HandlerProvider<TController, TQ1, TQ2, TQ3, TResult> handlerProvider) =>
            (query, context, ct) => Task.FromResult(handlerProvider(_controllerProvider)(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));
        
        public ParameterCollectorHandler<TContext, TResult> CreateHandler(AsyncHandlerProvider<TController, TQ1, TQ2, TQ3, TResult> handlerProvider) =>
            (query, context, ct) => handlerProvider(_controllerProvider)(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));
        
        public ParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(HandlerProvider<TController, TP1, TQ1, TQ2, TQ3, TResult> handlerProvider) =>
            (query, context, p1, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));
        
        public ParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(AsyncHandlerProvider<TController, TP1, TQ1, TQ2, TQ3, TResult> handlerProvider) =>
            (query, context, p1, ct) => handlerProvider(_controllerProvider)(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));
        
        public ParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(HandlerProvider<TController, TP1, TP2, TQ1, TQ2, TQ3, TResult> handlerProvider) =>
            (query, context, p1, p2, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));
        
        public ParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(AsyncHandlerProvider<TController, TP1, TP2, TQ1, TQ2, TQ3, TResult> handlerProvider) =>
            (query, context, p1, p2, ct) => handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));
        
        public ParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(HandlerProvider<TController, TP1, TP2, TP3, TQ1, TQ2, TQ3, TResult> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));
        
        public ParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(AsyncHandlerProvider<TController, TP1, TP2, TP3, TQ1, TQ2, TQ3, TResult> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));
    }
}
