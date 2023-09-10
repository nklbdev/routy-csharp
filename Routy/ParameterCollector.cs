
using System;
using System.Collections.Specialized;

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
            new(_controllerProvider)
                {
                    Q1 = valueExtractor
                };
        public ParameterCollector<TContext, TContext, TResult, TController> Context() =>
            CreateNext(ValueExtractors.Context<TContext>());

        public ParameterCollector<TContext, TParsedContext, TResult, TController> Context<TParsedContext>(Func<TContext, TParsedContext> contextParser) =>
            CreateNext(ValueExtractors.Context(contextParser));

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

        public ParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TResult> handler) =>
            (query, context) => handler();

        public ParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Func<TController>, Func<TResult>> handlerProvider) =>
            (query, context) => handlerProvider(_controllerProvider)();

        public ParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<TP1, TResult> handler) =>
            (query, context, p1) => handler(p1);

        public ParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<Func<TController>, Func<TP1, TResult>> handlerProvider) =>
            (query, context, p1) => handlerProvider(_controllerProvider)(p1);

        public ParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<TP1, TP2, TResult> handler) =>
            (query, context, p1, p2) => handler(p1, p2);

        public ParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<Func<TController>, Func<TP1, TP2, TResult>> handlerProvider) =>
            (query, context, p1, p2) => handlerProvider(_controllerProvider)(p1, p2);

        public ParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<TP1, TP2, TP3, TResult> handler) =>
            (query, context, p1, p2, p3) => handler(p1, p2, p3);

        public ParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<Func<TController>, Func<TP1, TP2, TP3, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3) => handlerProvider(_controllerProvider)(p1, p2, p3);

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
            new(_controllerProvider)
                {
                    Q1 = Q1,
                    Q2 = valueExtractor
                };
        public ParameterCollector<TContext, TQ1, TContext, TResult, TController> Context() =>
            CreateNext(ValueExtractors.Context<TContext>());

        public ParameterCollector<TContext, TQ1, TParsedContext, TResult, TController> Context<TParsedContext>(Func<TContext, TParsedContext> contextParser) =>
            CreateNext(ValueExtractors.Context(contextParser));

        public ParameterCollector<TContext, TQ1, T, TResult, TController> Single<T>(string name, Func<string, T> parser) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser));

        public ParameterCollector<TContext, TQ1, string, TResult, TController> Single(string name) =>
            CreateNext(ValueExtractors.Single<TContext, string>(name, x => x));

        public ParameterCollector<TContext, TQ1, T, TResult, TController> Single<T>(string name, Func<string, T> parser, T def) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser, def));

        public ParameterCollector<TContext, TQ1, string, TResult, TController> Single(string name, string def) =>
            CreateNext(ValueExtractors.Single<TContext, string>(name, x => x, def));

        public ParameterCollector<TContext, TQ1, T[], TResult, TController> Multiple<T>(string name, Func<string, T> parser) =>
            CreateNext(ValueExtractors.Multiple<TContext, T>(name, parser));

        public ParameterCollector<TContext, TQ1, string[], TResult, TController> Multiple(string name) =>
            CreateNext(ValueExtractors.Multiple<TContext, string>(name, x => x));

        public ParameterCollector<TContext, TQ1, T, TResult, TController> Custom<T>(Func<NameValueCollection, T> parser) =>
            CreateNext(ValueExtractors.Custom<TContext, T>(parser));

        public ParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TQ1, TResult> handler) =>
            (query, context) => handler(Q1(context, query));

        public ParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Func<TController>, Func<TQ1, TResult>> handlerProvider) =>
            (query, context) => handlerProvider(_controllerProvider)(Q1(context, query));

        public ParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<TP1, TQ1, TResult> handler) =>
            (query, context, p1) => handler(p1, Q1(context, query));

        public ParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<Func<TController>, Func<TP1, TQ1, TResult>> handlerProvider) =>
            (query, context, p1) => handlerProvider(_controllerProvider)(p1, Q1(context, query));

        public ParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<TP1, TP2, TQ1, TResult> handler) =>
            (query, context, p1, p2) => handler(p1, p2, Q1(context, query));

        public ParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<Func<TController>, Func<TP1, TP2, TQ1, TResult>> handlerProvider) =>
            (query, context, p1, p2) => handlerProvider(_controllerProvider)(p1, p2, Q1(context, query));

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
            new(_controllerProvider)
                {
                    Q1 = Q1,
                    Q2 = Q2,
                    Q3 = valueExtractor
                };
        public ParameterCollector<TContext, TQ1, TQ2, TContext, TResult, TController> Context() =>
            CreateNext(ValueExtractors.Context<TContext>());

        public ParameterCollector<TContext, TQ1, TQ2, TParsedContext, TResult, TController> Context<TParsedContext>(Func<TContext, TParsedContext> contextParser) =>
            CreateNext(ValueExtractors.Context(contextParser));

        public ParameterCollector<TContext, TQ1, TQ2, T, TResult, TController> Single<T>(string name, Func<string, T> parser) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser));

        public ParameterCollector<TContext, TQ1, TQ2, string, TResult, TController> Single(string name) =>
            CreateNext(ValueExtractors.Single<TContext, string>(name, x => x));

        public ParameterCollector<TContext, TQ1, TQ2, T, TResult, TController> Single<T>(string name, Func<string, T> parser, T def) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser, def));

        public ParameterCollector<TContext, TQ1, TQ2, string, TResult, TController> Single(string name, string def) =>
            CreateNext(ValueExtractors.Single<TContext, string>(name, x => x, def));

        public ParameterCollector<TContext, TQ1, TQ2, T[], TResult, TController> Multiple<T>(string name, Func<string, T> parser) =>
            CreateNext(ValueExtractors.Multiple<TContext, T>(name, parser));

        public ParameterCollector<TContext, TQ1, TQ2, string[], TResult, TController> Multiple(string name) =>
            CreateNext(ValueExtractors.Multiple<TContext, string>(name, x => x));

        public ParameterCollector<TContext, TQ1, TQ2, T, TResult, TController> Custom<T>(Func<NameValueCollection, T> parser) =>
            CreateNext(ValueExtractors.Custom<TContext, T>(parser));

        public ParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TQ1, TQ2, TResult> handler) =>
            (query, context) => handler(Q1(context, query), Q2(context, query));

        public ParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Func<TController>, Func<TQ1, TQ2, TResult>> handlerProvider) =>
            (query, context) => handlerProvider(_controllerProvider)(Q1(context, query), Q2(context, query));

        public ParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<TP1, TQ1, TQ2, TResult> handler) =>
            (query, context, p1) => handler(p1, Q1(context, query), Q2(context, query));

        public ParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<Func<TController>, Func<TP1, TQ1, TQ2, TResult>> handlerProvider) =>
            (query, context, p1) => handlerProvider(_controllerProvider)(p1, Q1(context, query), Q2(context, query));

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


        public ParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TQ1, TQ2, TQ3, TResult> handler) =>
            (query, context) => handler(Q1(context, query), Q2(context, query), Q3(context, query));

        public ParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Func<TController>, Func<TQ1, TQ2, TQ3, TResult>> handlerProvider) =>
            (query, context) => handlerProvider(_controllerProvider)(Q1(context, query), Q2(context, query), Q3(context, query));

    }

}
