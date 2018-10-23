using System;
using System.Collections.Specialized;
using System.Threading;
using System.Threading.Tasks;

namespace Routy
{
    public class ParameterCollector<TContext, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;

        public ParameterCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        private ParameterCollector<TContext, T, TResult, TController> CreateNext<T>(ValueExtractor<TContext, T> valueExtractor) =>
            new ParameterCollector<TContext, T, TResult, TController>(
            _controllerProvider) {Q1 = valueExtractor};

        public ParameterCollector<TContext, TContext, TResult, TController> Context() =>
            CreateNext(ValueExtractors.Context<TContext>());

        public ParameterCollector<TContext, TParsedContext, TResult, TController> Context<TParsedContext>(Func<TContext, TParsedContext> contextParser) =>
            CreateNext(ValueExtractors.Context(contextParser));

        public ParameterCollector<TContext, TParsedContext, TResult, TController> Context<TParsedContext>(Func<TContext, CancellationToken, TParsedContext> contextParser) =>
            CreateNext(ValueExtractors.Context(contextParser));

        public ParameterCollector<TContext, CancellationToken, TResult, TController> CancellationToken() =>
            CreateNext(ValueExtractors.CancellationToken<TContext>());

        public ParameterCollector<TContext, T, TResult, TController> Single<T>(string name, Func<string, T> parser) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser));

        public ParameterCollector<TContext, string, TResult, TController> Single(string name) =>
            CreateNext(ValueExtractors.Single<TContext, string>(name, x => x));

        public ParameterCollector<TContext, T, TResult, TController> Single<T>(string name, Func<string, T> parser, T def) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser, def));

        public ParameterCollector<TContext, string, TResult, TController> Single(string name, string def) =>
            CreateNext(ValueExtractors.Single<TContext, string>(name, x => x, def));

        public ParameterCollector<TContext, T[], TResult, TController> Multiple<T>(string name, Func<string, T> parser) =>
            CreateNext(ValueExtractors.Multiple<TContext, T>(name, parser));

        public ParameterCollector<TContext, string[], TResult, TController> Multiple(string name) =>
            CreateNext(ValueExtractors.Multiple<TContext, string>(name, x => x));

        public ParameterCollector<TContext, T, TResult, TController> Custom<T>(Func<NameValueCollection, T> parser) =>
            CreateNext(ValueExtractors.Custom<TContext, T>(parser));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TResult> handler) =>
            (query, context, ct) => Task.FromResult(handler());

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(HandlerProvider<TController, TResult> handlerProvider) =>
            (query, context, ct) => Task.FromResult(handlerProvider(_controllerProvider)());

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Task<TResult>> handler) =>
            (query, context, ct) => handler();

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(AsyncHandlerProvider<TController, TResult> handlerProvider) =>
            (query, context, ct) => handlerProvider(_controllerProvider)();

        public AsyncParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(Handler<TP1, TResult> handler) =>
            (query, context, p1, ct) => Task.FromResult(handler(p1));

        public AsyncParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(HandlerProvider<TController, TP1, TResult> handlerProvider) =>
            (query, context, p1, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1));

        public AsyncParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(Func<TP1, Task<TResult>> handler) =>
            (query, context, p1, ct) => handler(p1);

        public AsyncParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(AsyncHandlerProvider<TController, TP1, TResult> handlerProvider) =>
            (query, context, p1, ct) => handlerProvider(_controllerProvider)(p1);

        public AsyncParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(Handler<TP1, TP2, TResult> handler) =>
            (query, context, p1, p2, ct) => Task.FromResult(handler(p1, p2));

        public AsyncParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(HandlerProvider<TController, TP1, TP2, TResult> handlerProvider) =>
            (query, context, p1, p2, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2));

        public AsyncParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(Func<TP1, TP2, Task<TResult>> handler) =>
            (query, context, p1, p2, ct) => handler(p1, p2);

        public AsyncParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(AsyncHandlerProvider<TController, TP1, TP2, TResult> handlerProvider) =>
            (query, context, p1, p2, ct) => handlerProvider(_controllerProvider)(p1, p2);

        public AsyncParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(Handler<TP1, TP2, TP3, TResult> handler) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handler(p1, p2, p3));

        public AsyncParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(HandlerProvider<TController, TP1, TP2, TP3, TResult> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3));

        public AsyncParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(Func<TP1, TP2, TP3, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, ct) => handler(p1, p2, p3);

        public AsyncParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(AsyncHandlerProvider<TController, TP1, TP2, TP3, TResult> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => handlerProvider(_controllerProvider)(p1, p2, p3);
    }

    public class ParameterCollector<TContext, TQ1, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;

        public ParameterCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }
        
        public ValueExtractor<TContext, TQ1> Q1 { get; set; }
        
        private ParameterCollector<TContext, TQ1, T, TResult, TController> CreateNext<T>(ValueExtractor<TContext, T> valueExtractor) =>
            new ParameterCollector<TContext, TQ1, T, TResult, TController>(_controllerProvider) { Q1 = Q1, Q2 = valueExtractor};
        
        public ParameterCollector<TContext, TQ1, TContext, TResult, TController> Context() =>
            CreateNext(ValueExtractors.Context<TContext>());

        public ParameterCollector<TContext, TQ1, TParsedContext, TResult, TController> Context<TParsedContext>(Func<TContext, TParsedContext> contextParser) =>
            CreateNext(ValueExtractors.Context(contextParser));

        public ParameterCollector<TContext, TQ1, TParsedContext, TResult, TController> Context<TParsedContext>(Func<TContext, CancellationToken, TParsedContext> contextParser) =>
            CreateNext(ValueExtractors.Context(contextParser));

        public ParameterCollector<TContext, TQ1, CancellationToken, TResult, TController> CancellationToken() =>
            CreateNext(ValueExtractors.CancellationToken<TContext>());
        
        public ParameterCollector<TContext, TQ1, T, TResult, TController> Single<T>(string name, Func<string, T> parser) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser));
        
        public ParameterCollector<TContext, TQ1, T, TResult, TController> Single<T>(string name, Func<string, T> parser, T def) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser, def));
        
        public ParameterCollector<TContext, TQ1, T[], TResult, TController> Multiple<T>(string name, Func<string, T> parser) =>
            CreateNext(ValueExtractors.Multiple<TContext, T>(name, parser));

        public ParameterCollector<TContext, TQ1, T, TResult, TController> Custom<T>(Func<NameValueCollection, T> parser) =>
            CreateNext(ValueExtractors.Custom<TContext, T>(parser));
        
        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Handler<TQ1, TResult> handler) =>
            (query, context, ct) => Task.FromResult(handler(Q1(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(HandlerProvider<TController, TQ1, TResult> handlerProvider) =>
            (query, context, ct) => Task.FromResult(handlerProvider(_controllerProvider)(Q1(context, query, ct)));
        
        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TQ1, Task<TResult>> handler) =>
            (query, context, ct) => handler(Q1(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(AsyncHandlerProvider<TController, TQ1, TResult> handlerProvider) =>
            (query, context, ct) => handlerProvider(_controllerProvider)(Q1(context, query, ct));
        
        public AsyncParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(Handler<TP1, TQ1, TResult> handler) =>
            (query, context, p1, ct) => Task.FromResult(handler(p1, Q1(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(HandlerProvider<TController, TP1, TQ1, TResult> handlerProvider) =>
            (query, context, p1, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, Q1(context, query, ct)));
        
        public AsyncParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(Func<TP1, TQ1, Task<TResult>> handler) =>
            (query, context, p1, ct) => handler(p1, Q1(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(AsyncHandlerProvider<TController, TP1, TQ1, TResult> handlerProvider) =>
            (query, context, p1, ct) => handlerProvider(_controllerProvider)(p1, Q1(context, query, ct));
        
        public AsyncParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(Handler<TP1, TP2, TQ1, TResult> handler) =>
            (query, context, p1, p2, ct) => Task.FromResult(handler(p1, p2, Q1(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(HandlerProvider<TController, TP1, TP2, TQ1, TResult> handlerProvider) =>
            (query, context, p1, p2, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct)));
        
        public AsyncParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(Func<TP1, TP2, TQ1, Task<TResult>> handler) =>
            (query, context, p1, p2, ct) => handler(p1, p2, Q1(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(AsyncHandlerProvider<TController, TP1, TP2, TQ1, TResult> handlerProvider) =>
            (query, context, p1, p2, ct) => handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct));
        
        public AsyncParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(Handler<TP1, TP2, TP3, TQ1, TResult> handler) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handler(p1, p2, p3, Q1(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(HandlerProvider<TController, TP1, TP2, TP3, TQ1, TResult> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, Q1(context, query, ct)));
        
        public AsyncParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(Func<TP1, TP2, TP3, TQ1, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, ct) => handler(p1, p2, p3, Q1(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(AsyncHandlerProvider<TController, TP1, TP2, TP3, TQ1, TResult> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, Q1(context, query, ct));
        
        public AsyncParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15> CreateHandler2<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TQ1, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, Q1(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15> CreateHandler2<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15>(AsyncHandlerProvider<TController, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TQ1, TResult> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, Q1(context, query, ct));
    }

    public class ParameterCollector<TContext, TQ1, TQ2, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;

        public ParameterCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }
        
        public ValueExtractor<TContext, TQ1> Q1 { get; set; }
        public ValueExtractor<TContext, TQ2> Q2 { get; set; }
        
        private ParameterCollector<TContext, TQ1, TQ2, T, TResult, TController> CreateNext<T>(ValueExtractor<TContext, T> valueExtractor) =>
            new ParameterCollector<TContext, TQ1, TQ2, T, TResult, TController>(_controllerProvider) { Q1 = Q1, Q2 = Q2, Q3 = valueExtractor};
        
        public ParameterCollector<TContext, TQ1, TQ2, TContext, TResult, TController> Context() =>
            CreateNext(ValueExtractors.Context<TContext>());

        public ParameterCollector<TContext, TQ1, TQ2, TParsedContext, TResult, TController> Context<TParsedContext>(Func<TContext, TParsedContext> contextParser) =>
            CreateNext(ValueExtractors.Context(contextParser));

        public ParameterCollector<TContext, TQ1, TQ2, TParsedContext, TResult, TController> Context<TParsedContext>(Func<TContext, CancellationToken, TParsedContext> contextParser) =>
            CreateNext(ValueExtractors.Context(contextParser));
        
        public ParameterCollector<TContext, TQ1, TQ2, CancellationToken, TResult, TController> CancellationToken() =>
            CreateNext(ValueExtractors.CancellationToken<TContext>());
        
        public ParameterCollector<TContext, TQ1, TQ2, T, TResult, TController> Single<T>(string name, Func<string, T> parser) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser));
        
        public ParameterCollector<TContext, TQ1, TQ2, T, TResult, TController> Single<T>(string name, Func<string, T> parser, T def) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser, def));
        
        public ParameterCollector<TContext, TQ1, TQ2, T[], TResult, TController> Multiple<T>(string name, Func<string, T> parser) =>
            CreateNext(ValueExtractors.Multiple<TContext, T>(name, parser));

        public ParameterCollector<TContext, TQ1, TQ2, T, TResult, TController> Custom<T>(Func<NameValueCollection, T> parser) =>
            CreateNext(ValueExtractors.Custom<TContext, T>(parser));
        
        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Handler<TQ1, TQ2, TResult> handler) =>
            (query, context, ct) => Task.FromResult(handler(Q1(context, query, ct), Q2(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(HandlerProvider<TController, TQ1, TQ2, TResult> handlerProvider) =>
            (query, context, ct) => Task.FromResult(handlerProvider(_controllerProvider)(Q1(context, query, ct), Q2(context, query, ct)));
        
        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TQ1, TQ2, Task<TResult>> handler) =>
            (query, context, ct) => handler(Q1(context, query, ct), Q2(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(AsyncHandlerProvider<TController, TQ1, TQ2, TResult> handlerProvider) =>
            (query, context, ct) => handlerProvider(_controllerProvider)(Q1(context, query, ct), Q2(context, query, ct));
        
        public AsyncParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(Handler<TP1, TQ1, TQ2, TResult> handler) =>
            (query, context, p1, ct) => Task.FromResult(handler(p1, Q1(context, query, ct), Q2(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(HandlerProvider<TController, TP1, TQ1, TQ2, TResult> handlerProvider) =>
            (query, context, p1, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, Q1(context, query, ct), Q2(context, query, ct)));
        
        public AsyncParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(Func<TP1, TQ1, TQ2, Task<TResult>> handler) =>
            (query, context, p1, ct) => handler(p1, Q1(context, query, ct), Q2(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(AsyncHandlerProvider<TController, TP1, TQ1, TQ2, TResult> handlerProvider) =>
            (query, context, p1, ct) => handlerProvider(_controllerProvider)(p1, Q1(context, query, ct), Q2(context, query, ct));
        
        public AsyncParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(Handler<TP1, TP2, TQ1, TQ2, TResult> handler) =>
            (query, context, p1, p2, ct) => Task.FromResult(handler(p1, p2, Q1(context, query, ct), Q2(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(HandlerProvider<TController, TP1, TP2, TQ1, TQ2, TResult> handlerProvider) =>
            (query, context, p1, p2, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct), Q2(context, query, ct)));
        
        public AsyncParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(Func<TP1, TP2, TQ1, TQ2, Task<TResult>> handler) =>
            (query, context, p1, p2, ct) => handler(p1, p2, Q1(context, query, ct), Q2(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(AsyncHandlerProvider<TController, TP1, TP2, TQ1, TQ2, TResult> handlerProvider) =>
            (query, context, p1, p2, ct) => handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct), Q2(context, query, ct));
        
        public AsyncParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(Handler<TP1, TP2, TP3, TQ1, TQ2, TResult> handler) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handler(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(HandlerProvider<TController, TP1, TP2, TP3, TQ1, TQ2, TResult> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct)));
        
        public AsyncParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(Func<TP1, TP2, TP3, TQ1, TQ2, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, ct) => handler(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(AsyncHandlerProvider<TController, TP1, TP2, TP3, TQ1, TQ2, TResult> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct));
    }

    public class ParameterCollector<TContext, TQ1, TQ2, TQ3, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;

        public ParameterCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        public ValueExtractor<TContext, TQ1> Q1 { get; set; }
        public ValueExtractor<TContext, TQ2> Q2 { get; set; }
        public ValueExtractor<TContext, TQ3> Q3 { get; set; }
        
        //public ParameterCollector<TContext, TQ1, TQ2, TQ3, T, TResult, TController> CreateNext<T>(ContextualValueExtractor<TContext, T> valueExtractor) =>
        //    new ContextualParameterCollector<TContext, TQ1, TQ2, TQ3, T, TResult, TController>(_controllerProvider) { Q1 = Q1, Q2 = Q2, Q3 = Q3, Q4 = valueExtractor};
        
        //public ParameterCollector<TContext, TQ1, TQ2, TQ3, T, TResult, TController> Context<T>(Func<TContext, T> f) =>
        //    CreateNext(ValueExtractors.Context(f));
        
        //public ParameterCollector<TContext, TQ1, TQ2, TQ3, CancellationToken, TResult, TController> CancellationToken() =>
        //    CreateNext(ValueExtractors.CancellationToken<TContext>());
        
        //public ParameterCollector<TContext, TQ1, TQ2, TQ3, T, TResult, TController> Single<T>(string name, Func<string, T> parser) =>
        //    CreateNext(ValueExtractors.Single<TContext, T>(name, parser));
        
        //public ParameterCollector<TContext, TQ1, TQ2, TQ3, T, TResult, TController> Single<T>(string name, Func<string, T> parser, T def) =>
        //    CreateNext(ValueExtractors.Single<TContext, T>(name, parser, def));
        
        //public ParameterCollector<TContext, TQ1, TQ2, TQ3, T[], TResult, TController> Multiple<T>(string name, Func<string, T> parser) =>
        //    CreateNext(ValueExtractors.Multiple<TContext, T>(name, parser));

        //public ParameterCollector<TContext, TQ1, TQ2, TQ3, T, TResult, TController> Custom<T>(Func<NameValueCollection, T> parser) =>
        //    CreateNext(ValueExtractors.Custom<TContext, T>(parser));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Handler<TQ1, TQ2, TQ3, TResult> handler) =>
            (query, context, ct) => Task.FromResult(handler(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));
        
        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TQ1, TQ2, TQ3, Task<TResult>> handler) =>
            (query, context, ct) => handler(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));
        
        public AsyncParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(Handler<TP1, TQ1, TQ2, TQ3, TResult> handler) =>
            (query, context, p1, ct) => Task.FromResult(handler(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));
        
        public AsyncParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(Func<TP1, TQ1, TQ2, TQ3, Task<TResult>> handler) =>
            (query, context, p1, ct) => handler(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));
        
        public AsyncParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(Handler<TP1, TP2, TQ1, TQ2, TQ3, TResult> handler) =>
            (query, context, p1, p2, ct) => Task.FromResult(handler(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));
        
        public AsyncParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(Func<TP1, TP2, TQ1, TQ2, TQ3, Task<TResult>> handler) =>
            (query, context, p1, p2, ct) => handler(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));
        
        public AsyncParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(Handler<TP1, TP2, TP3, TQ1, TQ2, TQ3, TResult> handler) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handler(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));
        
        public AsyncParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, ct) => handler(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));



        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(HandlerProvider<TController, TQ1, TQ2, TQ3, TResult> handlerProvider) =>
            (query, context, ct) => Task.FromResult(handlerProvider(_controllerProvider)(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));
        
        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(AsyncHandlerProvider<TController, TQ1, TQ2, TQ3, TResult> handlerProvider) =>
            (query, context, ct) => handlerProvider(_controllerProvider)(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));
        
        public AsyncParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(HandlerProvider<TController, TP1, TQ1, TQ2, TQ3, TResult> handlerProvider) =>
            (query, context, p1, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));
        
        public AsyncParameterCollectorHandler<TContext, TResult, TP1> CreateHandler<TP1>(AsyncHandlerProvider<TController, TP1, TQ1, TQ2, TQ3, TResult> handlerProvider) =>
            (query, context, p1, ct) => handlerProvider(_controllerProvider)(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));
        
        public AsyncParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(HandlerProvider<TController, TP1, TP2, TQ1, TQ2, TQ3, TResult> handlerProvider) =>
            (query, context, p1, p2, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));
        
        public AsyncParameterCollectorHandler<TContext, TResult, TP1, TP2> CreateHandler<TP1, TP2>(AsyncHandlerProvider<TController, TP1, TP2, TQ1, TQ2, TQ3, TResult> handlerProvider) =>
            (query, context, p1, p2, ct) => handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));
        
        public AsyncParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(HandlerProvider<TController, TP1, TP2, TP3, TQ1, TQ2, TQ3, TResult> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));
        
        public AsyncParameterCollectorHandler<TContext, TResult, TP1, TP2, TP3> CreateHandler<TP1, TP2, TP3>(AsyncHandlerProvider<TController, TP1, TP2, TP3, TQ1, TQ2, TQ3, TResult> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));
    }
}
