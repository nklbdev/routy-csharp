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
            new ParameterCollector<TContext, T, TResult, TController>(_controllerProvider)
                {
                    Q1 = valueExtractor
                };
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

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Func<TController>, Func<TResult>> handlerProvider) =>
            (query, context, ct) => Task.FromResult(handlerProvider(_controllerProvider)());

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Task<TResult>> handler) =>
            (query, context, ct) => handler();

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Func<TController>, Func<Task<TResult>>> handlerProvider) =>
            (query, context, ct) => handlerProvider(_controllerProvider)();

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<TP1, TResult> handler) =>
            (query, context, p1, ct) => Task.FromResult(handler(p1));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<Func<TController>, Func<TP1, TResult>> handlerProvider) =>
            (query, context, p1, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<TP1, Task<TResult>> handler) =>
            (query, context, p1, ct) => handler(p1);

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<Func<TController>, Func<TP1, Task<TResult>>> handlerProvider) =>
            (query, context, p1, ct) => handlerProvider(_controllerProvider)(p1);

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<TP1, TP2, TResult> handler) =>
            (query, context, p1, p2, ct) => Task.FromResult(handler(p1, p2));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<Func<TController>, Func<TP1, TP2, TResult>> handlerProvider) =>
            (query, context, p1, p2, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<TP1, TP2, Task<TResult>> handler) =>
            (query, context, p1, p2, ct) => handler(p1, p2);

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<Func<TController>, Func<TP1, TP2, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, ct) => handlerProvider(_controllerProvider)(p1, p2);

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<TP1, TP2, TP3, TResult> handler) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handler(p1, p2, p3));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<Func<TController>, Func<TP1, TP2, TP3, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<TP1, TP2, TP3, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, ct) => handler(p1, p2, p3);

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<Func<TController>, Func<TP1, TP2, TP3, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => handlerProvider(_controllerProvider)(p1, p2, p3);

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<TP1, TP2, TP3, TP4, TResult> handler) =>
            (query, context, p1, p2, p3, p4, ct) => Task.FromResult(handler(p1, p2, p3, p4));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<TP1, TP2, TP3, TP4, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, ct) => handler(p1, p2, p3, p4);

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4);

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<TP1, TP2, TP3, TP4, TP5, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<TP1, TP2, TP3, TP4, TP5, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, ct) => handler(p1, p2, p3, p4, p5);

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5);

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<TP1, TP2, TP3, TP4, TP5, TP6, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => handler(p1, p2, p3, p4, p5, p6);

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6);

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => handler(p1, p2, p3, p4, p5, p6, p7);

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7);

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8);

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8);

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, p9));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, p9);

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9);

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12);

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12);

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13);

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13);

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14);

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14);

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15);

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15);

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16);

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16);

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
            new ParameterCollector<TContext, TQ1, T, TResult, TController>(_controllerProvider)
                {
                    Q1 = Q1,
                    Q2 = valueExtractor
                };
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

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TQ1, TResult> handler) =>
            (query, context, ct) => Task.FromResult(handler(Q1(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Func<TController>, Func<TQ1, TResult>> handlerProvider) =>
            (query, context, ct) => Task.FromResult(handlerProvider(_controllerProvider)(Q1(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TQ1, Task<TResult>> handler) =>
            (query, context, ct) => handler(Q1(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Func<TController>, Func<TQ1, Task<TResult>>> handlerProvider) =>
            (query, context, ct) => handlerProvider(_controllerProvider)(Q1(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<TP1, TQ1, TResult> handler) =>
            (query, context, p1, ct) => Task.FromResult(handler(p1, Q1(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<Func<TController>, Func<TP1, TQ1, TResult>> handlerProvider) =>
            (query, context, p1, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, Q1(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<TP1, TQ1, Task<TResult>> handler) =>
            (query, context, p1, ct) => handler(p1, Q1(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<Func<TController>, Func<TP1, TQ1, Task<TResult>>> handlerProvider) =>
            (query, context, p1, ct) => handlerProvider(_controllerProvider)(p1, Q1(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<TP1, TP2, TQ1, TResult> handler) =>
            (query, context, p1, p2, ct) => Task.FromResult(handler(p1, p2, Q1(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<Func<TController>, Func<TP1, TP2, TQ1, TResult>> handlerProvider) =>
            (query, context, p1, p2, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<TP1, TP2, TQ1, Task<TResult>> handler) =>
            (query, context, p1, p2, ct) => handler(p1, p2, Q1(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<Func<TController>, Func<TP1, TP2, TQ1, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, ct) => handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<TP1, TP2, TP3, TQ1, TResult> handler) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handler(p1, p2, p3, Q1(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, Q1(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<TP1, TP2, TP3, TQ1, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, ct) => handler(p1, p2, p3, Q1(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, Q1(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<TP1, TP2, TP3, TP4, TQ1, TResult> handler) =>
            (query, context, p1, p2, p3, p4, ct) => Task.FromResult(handler(p1, p2, p3, p4, Q1(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, Q1(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<TP1, TP2, TP3, TP4, TQ1, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, ct) => handler(p1, p2, p3, p4, Q1(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, Q1(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<TP1, TP2, TP3, TP4, TP5, TQ1, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, Q1(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, Q1(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<TP1, TP2, TP3, TP4, TP5, TQ1, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, ct) => handler(p1, p2, p3, p4, p5, Q1(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, Q1(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, Q1(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, Q1(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => handler(p1, p2, p3, p4, p5, p6, Q1(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, Q1(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, Q1(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, Q1(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => handler(p1, p2, p3, p4, p5, p6, p7, Q1(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, Q1(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, Q1(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, Q1(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, Q1(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, Q1(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, Q1(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, Q1(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, Q1(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, Q1(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, Q1(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, Q1(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, Q1(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, Q1(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, Q1(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, Q1(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, Q1(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, Q1(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, Q1(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, Q1(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, Q1(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, Q1(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TQ1, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, Q1(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TQ1, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, Q1(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TQ1, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, Q1(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TQ1, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, Q1(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TQ1, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, Q1(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TQ1, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, Q1(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TQ1, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, Q1(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TQ1, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, Q1(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TQ1, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, Q1(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TQ1, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, Q1(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TQ1, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, Q1(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TQ1, Task<TResult>>> handlerProvider) =>
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
            new ParameterCollector<TContext, TQ1, TQ2, T, TResult, TController>(_controllerProvider)
                {
                    Q1 = Q1,
                    Q2 = Q2,
                    Q3 = valueExtractor
                };
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

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TQ1, TQ2, TResult> handler) =>
            (query, context, ct) => Task.FromResult(handler(Q1(context, query, ct), Q2(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Func<TController>, Func<TQ1, TQ2, TResult>> handlerProvider) =>
            (query, context, ct) => Task.FromResult(handlerProvider(_controllerProvider)(Q1(context, query, ct), Q2(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TQ1, TQ2, Task<TResult>> handler) =>
            (query, context, ct) => handler(Q1(context, query, ct), Q2(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Func<TController>, Func<TQ1, TQ2, Task<TResult>>> handlerProvider) =>
            (query, context, ct) => handlerProvider(_controllerProvider)(Q1(context, query, ct), Q2(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<TP1, TQ1, TQ2, TResult> handler) =>
            (query, context, p1, ct) => Task.FromResult(handler(p1, Q1(context, query, ct), Q2(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<Func<TController>, Func<TP1, TQ1, TQ2, TResult>> handlerProvider) =>
            (query, context, p1, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, Q1(context, query, ct), Q2(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<TP1, TQ1, TQ2, Task<TResult>> handler) =>
            (query, context, p1, ct) => handler(p1, Q1(context, query, ct), Q2(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<Func<TController>, Func<TP1, TQ1, TQ2, Task<TResult>>> handlerProvider) =>
            (query, context, p1, ct) => handlerProvider(_controllerProvider)(p1, Q1(context, query, ct), Q2(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<TP1, TP2, TQ1, TQ2, TResult> handler) =>
            (query, context, p1, p2, ct) => Task.FromResult(handler(p1, p2, Q1(context, query, ct), Q2(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TResult>> handlerProvider) =>
            (query, context, p1, p2, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct), Q2(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<TP1, TP2, TQ1, TQ2, Task<TResult>> handler) =>
            (query, context, p1, p2, ct) => handler(p1, p2, Q1(context, query, ct), Q2(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, ct) => handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct), Q2(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<TP1, TP2, TP3, TQ1, TQ2, TResult> handler) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handler(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<TP1, TP2, TP3, TQ1, TQ2, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, ct) => handler(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TResult> handler) =>
            (query, context, p1, p2, p3, p4, ct) => Task.FromResult(handler(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<TP1, TP2, TP3, TP4, TQ1, TQ2, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, ct) => handler(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, ct) => handler(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, Q1(context, query, ct), Q2(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, Q1(context, query, ct), Q2(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => handler(p1, p2, p3, p4, p5, p6, Q1(context, query, ct), Q2(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, Q1(context, query, ct), Q2(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, Q1(context, query, ct), Q2(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, Q1(context, query, ct), Q2(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => handler(p1, p2, p3, p4, p5, p6, p7, Q1(context, query, ct), Q2(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, Q1(context, query, ct), Q2(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, Q1(context, query, ct), Q2(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, Q1(context, query, ct), Q2(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, Q1(context, query, ct), Q2(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, Q1(context, query, ct), Q2(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, Q1(context, query, ct), Q2(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, Q1(context, query, ct), Q2(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, Q1(context, query, ct), Q2(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, Q1(context, query, ct), Q2(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, Q1(context, query, ct), Q2(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, Q1(context, query, ct), Q2(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, Q1(context, query, ct), Q2(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, Q1(context, query, ct), Q2(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, Q1(context, query, ct), Q2(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, Q1(context, query, ct), Q2(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, Q1(context, query, ct), Q2(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, Q1(context, query, ct), Q2(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TQ2, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, Q1(context, query, ct), Q2(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TQ2, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, Q1(context, query, ct), Q2(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TQ2, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, Q1(context, query, ct), Q2(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TQ2, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, Q1(context, query, ct), Q2(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TQ1, TQ2, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, Q1(context, query, ct), Q2(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TQ1, TQ2, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, Q1(context, query, ct), Q2(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TQ1, TQ2, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, Q1(context, query, ct), Q2(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TQ1, TQ2, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, Q1(context, query, ct), Q2(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TQ1, TQ2, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, Q1(context, query, ct), Q2(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TQ1, TQ2, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, Q1(context, query, ct), Q2(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TQ1, TQ2, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, Q1(context, query, ct), Q2(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TQ1, TQ2, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, Q1(context, query, ct), Q2(context, query, ct));

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

        private ParameterCollector<TContext, TQ1, TQ2, TQ3, T, TResult, TController> CreateNext<T>(ValueExtractor<TContext, T> valueExtractor) =>
            new ParameterCollector<TContext, TQ1, TQ2, TQ3, T, TResult, TController>(_controllerProvider)
                {
                    Q1 = Q1,
                    Q2 = Q2,
                    Q3 = Q3,
                    Q4 = valueExtractor
                };
        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TContext, TResult, TController> Context() =>
            CreateNext(ValueExtractors.Context<TContext>());

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TParsedContext, TResult, TController> Context<TParsedContext>(Func<TContext, TParsedContext> contextParser) =>
            CreateNext(ValueExtractors.Context(contextParser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TParsedContext, TResult, TController> Context<TParsedContext>(Func<TContext, CancellationToken, TParsedContext> contextParser) =>
            CreateNext(ValueExtractors.Context(contextParser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, CancellationToken, TResult, TController> CancellationToken() =>
            CreateNext(ValueExtractors.CancellationToken<TContext>());

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, T, TResult, TController> Single<T>(string name, Func<string, T> parser) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, string, TResult, TController> Single(string name) =>
            CreateNext(ValueExtractors.Single<TContext, string>(name, x => x));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, T, TResult, TController> Single<T>(string name, Func<string, T> parser, T def) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser, def));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, string, TResult, TController> Single(string name, string def) =>
            CreateNext(ValueExtractors.Single<TContext, string>(name, x => x, def));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, T[], TResult, TController> Multiple<T>(string name, Func<string, T> parser) =>
            CreateNext(ValueExtractors.Multiple<TContext, T>(name, parser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, string[], TResult, TController> Multiple(string name) =>
            CreateNext(ValueExtractors.Multiple<TContext, string>(name, x => x));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, T, TResult, TController> Custom<T>(Func<NameValueCollection, T> parser) =>
            CreateNext(ValueExtractors.Custom<TContext, T>(parser));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TQ1, TQ2, TQ3, TResult> handler) =>
            (query, context, ct) => Task.FromResult(handler(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Func<TController>, Func<TQ1, TQ2, TQ3, TResult>> handlerProvider) =>
            (query, context, ct) => Task.FromResult(handlerProvider(_controllerProvider)(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TQ1, TQ2, TQ3, Task<TResult>> handler) =>
            (query, context, ct) => handler(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Func<TController>, Func<TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider) =>
            (query, context, ct) => handlerProvider(_controllerProvider)(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<TP1, TQ1, TQ2, TQ3, TResult> handler) =>
            (query, context, p1, ct) => Task.FromResult(handler(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TResult>> handlerProvider) =>
            (query, context, p1, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<TP1, TQ1, TQ2, TQ3, Task<TResult>> handler) =>
            (query, context, p1, ct) => handler(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider) =>
            (query, context, p1, ct) => handlerProvider(_controllerProvider)(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<TP1, TP2, TQ1, TQ2, TQ3, TResult> handler) =>
            (query, context, p1, p2, ct) => Task.FromResult(handler(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TResult>> handlerProvider) =>
            (query, context, p1, p2, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<TP1, TP2, TQ1, TQ2, TQ3, Task<TResult>> handler) =>
            (query, context, p1, p2, ct) => handler(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, ct) => handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TResult> handler) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handler(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, ct) => handler(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TResult> handler) =>
            (query, context, p1, p2, p3, p4, ct) => Task.FromResult(handler(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, ct) => handler(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, ct) => handler(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => handler(p1, p2, p3, p4, p5, p6, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => handler(p1, p2, p3, p4, p5, p6, p7, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TQ3, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TQ3, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TQ3, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TQ2, TQ3, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TQ2, TQ3, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TQ2, TQ3, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TQ1, TQ2, TQ3, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TQ1, TQ2, TQ3, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TQ1, TQ2, TQ3, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TQ1, TQ2, TQ3, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct));

    }

    public class ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;

        public ParameterCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        public ValueExtractor<TContext, TQ1> Q1 { get; set; }
        public ValueExtractor<TContext, TQ2> Q2 { get; set; }
        public ValueExtractor<TContext, TQ3> Q3 { get; set; }
        public ValueExtractor<TContext, TQ4> Q4 { get; set; }

        private ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, T, TResult, TController> CreateNext<T>(ValueExtractor<TContext, T> valueExtractor) =>
            new ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, T, TResult, TController>(_controllerProvider)
                {
                    Q1 = Q1,
                    Q2 = Q2,
                    Q3 = Q3,
                    Q4 = Q4,
                    Q5 = valueExtractor
                };
        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TContext, TResult, TController> Context() =>
            CreateNext(ValueExtractors.Context<TContext>());

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TParsedContext, TResult, TController> Context<TParsedContext>(Func<TContext, TParsedContext> contextParser) =>
            CreateNext(ValueExtractors.Context(contextParser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TParsedContext, TResult, TController> Context<TParsedContext>(Func<TContext, CancellationToken, TParsedContext> contextParser) =>
            CreateNext(ValueExtractors.Context(contextParser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, CancellationToken, TResult, TController> CancellationToken() =>
            CreateNext(ValueExtractors.CancellationToken<TContext>());

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, T, TResult, TController> Single<T>(string name, Func<string, T> parser) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, string, TResult, TController> Single(string name) =>
            CreateNext(ValueExtractors.Single<TContext, string>(name, x => x));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, T, TResult, TController> Single<T>(string name, Func<string, T> parser, T def) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser, def));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, string, TResult, TController> Single(string name, string def) =>
            CreateNext(ValueExtractors.Single<TContext, string>(name, x => x, def));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, T[], TResult, TController> Multiple<T>(string name, Func<string, T> parser) =>
            CreateNext(ValueExtractors.Multiple<TContext, T>(name, parser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, string[], TResult, TController> Multiple(string name) =>
            CreateNext(ValueExtractors.Multiple<TContext, string>(name, x => x));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, T, TResult, TController> Custom<T>(Func<NameValueCollection, T> parser) =>
            CreateNext(ValueExtractors.Custom<TContext, T>(parser));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TQ1, TQ2, TQ3, TQ4, TResult> handler) =>
            (query, context, ct) => Task.FromResult(handler(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider) =>
            (query, context, ct) => Task.FromResult(handlerProvider(_controllerProvider)(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler) =>
            (query, context, ct) => handler(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider) =>
            (query, context, ct) => handlerProvider(_controllerProvider)(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<TP1, TQ1, TQ2, TQ3, TQ4, TResult> handler) =>
            (query, context, p1, ct) => Task.FromResult(handler(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider) =>
            (query, context, p1, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<TP1, TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler) =>
            (query, context, p1, ct) => handler(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider) =>
            (query, context, p1, ct) => handlerProvider(_controllerProvider)(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TResult> handler) =>
            (query, context, p1, p2, ct) => Task.FromResult(handler(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider) =>
            (query, context, p1, p2, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler) =>
            (query, context, p1, p2, ct) => handler(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, ct) => handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TResult> handler) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handler(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, ct) => handler(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TResult> handler) =>
            (query, context, p1, p2, p3, p4, ct) => Task.FromResult(handler(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, ct) => handler(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, ct) => handler(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => handler(p1, p2, p3, p4, p5, p6, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => handler(p1, p2, p3, p4, p5, p6, p7, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TQ4, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TQ3, TQ4, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TQ2, TQ3, TQ4, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TQ2, TQ3, TQ4, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TQ2, TQ3, TQ4, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TQ1, TQ2, TQ3, TQ4, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct));

    }

    public class ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;

        public ParameterCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        public ValueExtractor<TContext, TQ1> Q1 { get; set; }
        public ValueExtractor<TContext, TQ2> Q2 { get; set; }
        public ValueExtractor<TContext, TQ3> Q3 { get; set; }
        public ValueExtractor<TContext, TQ4> Q4 { get; set; }
        public ValueExtractor<TContext, TQ5> Q5 { get; set; }

        private ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, T, TResult, TController> CreateNext<T>(ValueExtractor<TContext, T> valueExtractor) =>
            new ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, T, TResult, TController>(_controllerProvider)
                {
                    Q1 = Q1,
                    Q2 = Q2,
                    Q3 = Q3,
                    Q4 = Q4,
                    Q5 = Q5,
                    Q6 = valueExtractor
                };
        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TContext, TResult, TController> Context() =>
            CreateNext(ValueExtractors.Context<TContext>());

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TParsedContext, TResult, TController> Context<TParsedContext>(Func<TContext, TParsedContext> contextParser) =>
            CreateNext(ValueExtractors.Context(contextParser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TParsedContext, TResult, TController> Context<TParsedContext>(Func<TContext, CancellationToken, TParsedContext> contextParser) =>
            CreateNext(ValueExtractors.Context(contextParser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, CancellationToken, TResult, TController> CancellationToken() =>
            CreateNext(ValueExtractors.CancellationToken<TContext>());

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, T, TResult, TController> Single<T>(string name, Func<string, T> parser) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, string, TResult, TController> Single(string name) =>
            CreateNext(ValueExtractors.Single<TContext, string>(name, x => x));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, T, TResult, TController> Single<T>(string name, Func<string, T> parser, T def) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser, def));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, string, TResult, TController> Single(string name, string def) =>
            CreateNext(ValueExtractors.Single<TContext, string>(name, x => x, def));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, T[], TResult, TController> Multiple<T>(string name, Func<string, T> parser) =>
            CreateNext(ValueExtractors.Multiple<TContext, T>(name, parser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, string[], TResult, TController> Multiple(string name) =>
            CreateNext(ValueExtractors.Multiple<TContext, string>(name, x => x));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, T, TResult, TController> Custom<T>(Func<NameValueCollection, T> parser) =>
            CreateNext(ValueExtractors.Custom<TContext, T>(parser));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TQ1, TQ2, TQ3, TQ4, TQ5, TResult> handler) =>
            (query, context, ct) => Task.FromResult(handler(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TResult>> handlerProvider) =>
            (query, context, ct) => Task.FromResult(handlerProvider(_controllerProvider)(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>> handler) =>
            (query, context, ct) => handler(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>>> handlerProvider) =>
            (query, context, ct) => handlerProvider(_controllerProvider)(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TResult> handler) =>
            (query, context, p1, ct) => Task.FromResult(handler(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TResult>> handlerProvider) =>
            (query, context, p1, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>> handler) =>
            (query, context, p1, ct) => handler(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>>> handlerProvider) =>
            (query, context, p1, ct) => handlerProvider(_controllerProvider)(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TResult> handler) =>
            (query, context, p1, p2, ct) => Task.FromResult(handler(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TResult>> handlerProvider) =>
            (query, context, p1, p2, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>> handler) =>
            (query, context, p1, p2, ct) => handler(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, ct) => handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TResult> handler) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handler(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, ct) => handler(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TResult> handler) =>
            (query, context, p1, p2, p3, p4, ct) => Task.FromResult(handler(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, ct) => handler(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, ct) => handler(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => handler(p1, p2, p3, p4, p5, p6, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => handler(p1, p2, p3, p4, p5, p6, p7, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TQ5, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TQ5, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TQ4, TQ5, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TQ4, TQ5, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TQ3, TQ4, TQ5, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TQ3, TQ4, TQ5, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TQ1, TQ2, TQ3, TQ4, TQ5, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct));

    }

    public class ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;

        public ParameterCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        public ValueExtractor<TContext, TQ1> Q1 { get; set; }
        public ValueExtractor<TContext, TQ2> Q2 { get; set; }
        public ValueExtractor<TContext, TQ3> Q3 { get; set; }
        public ValueExtractor<TContext, TQ4> Q4 { get; set; }
        public ValueExtractor<TContext, TQ5> Q5 { get; set; }
        public ValueExtractor<TContext, TQ6> Q6 { get; set; }

        private ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, T, TResult, TController> CreateNext<T>(ValueExtractor<TContext, T> valueExtractor) =>
            new ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, T, TResult, TController>(_controllerProvider)
                {
                    Q1 = Q1,
                    Q2 = Q2,
                    Q3 = Q3,
                    Q4 = Q4,
                    Q5 = Q5,
                    Q6 = Q6,
                    Q7 = valueExtractor
                };
        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TContext, TResult, TController> Context() =>
            CreateNext(ValueExtractors.Context<TContext>());

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TParsedContext, TResult, TController> Context<TParsedContext>(Func<TContext, TParsedContext> contextParser) =>
            CreateNext(ValueExtractors.Context(contextParser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TParsedContext, TResult, TController> Context<TParsedContext>(Func<TContext, CancellationToken, TParsedContext> contextParser) =>
            CreateNext(ValueExtractors.Context(contextParser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, CancellationToken, TResult, TController> CancellationToken() =>
            CreateNext(ValueExtractors.CancellationToken<TContext>());

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, T, TResult, TController> Single<T>(string name, Func<string, T> parser) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, string, TResult, TController> Single(string name) =>
            CreateNext(ValueExtractors.Single<TContext, string>(name, x => x));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, T, TResult, TController> Single<T>(string name, Func<string, T> parser, T def) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser, def));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, string, TResult, TController> Single(string name, string def) =>
            CreateNext(ValueExtractors.Single<TContext, string>(name, x => x, def));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, T[], TResult, TController> Multiple<T>(string name, Func<string, T> parser) =>
            CreateNext(ValueExtractors.Multiple<TContext, T>(name, parser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, string[], TResult, TController> Multiple(string name) =>
            CreateNext(ValueExtractors.Multiple<TContext, string>(name, x => x));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, T, TResult, TController> Custom<T>(Func<NameValueCollection, T> parser) =>
            CreateNext(ValueExtractors.Custom<TContext, T>(parser));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult> handler) =>
            (query, context, ct) => Task.FromResult(handler(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult>> handlerProvider) =>
            (query, context, ct) => Task.FromResult(handlerProvider(_controllerProvider)(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>> handler) =>
            (query, context, ct) => handler(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>>> handlerProvider) =>
            (query, context, ct) => handlerProvider(_controllerProvider)(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult> handler) =>
            (query, context, p1, ct) => Task.FromResult(handler(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult>> handlerProvider) =>
            (query, context, p1, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>> handler) =>
            (query, context, p1, ct) => handler(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>>> handlerProvider) =>
            (query, context, p1, ct) => handlerProvider(_controllerProvider)(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult> handler) =>
            (query, context, p1, p2, ct) => Task.FromResult(handler(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult>> handlerProvider) =>
            (query, context, p1, p2, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>> handler) =>
            (query, context, p1, p2, ct) => handler(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, ct) => handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult> handler) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handler(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, ct) => handler(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult> handler) =>
            (query, context, p1, p2, p3, p4, ct) => Task.FromResult(handler(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, ct) => handler(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, ct) => handler(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => handler(p1, p2, p3, p4, p5, p6, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => handler(p1, p2, p3, p4, p5, p6, p7, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct));

    }

    public class ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;

        public ParameterCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        public ValueExtractor<TContext, TQ1> Q1 { get; set; }
        public ValueExtractor<TContext, TQ2> Q2 { get; set; }
        public ValueExtractor<TContext, TQ3> Q3 { get; set; }
        public ValueExtractor<TContext, TQ4> Q4 { get; set; }
        public ValueExtractor<TContext, TQ5> Q5 { get; set; }
        public ValueExtractor<TContext, TQ6> Q6 { get; set; }
        public ValueExtractor<TContext, TQ7> Q7 { get; set; }

        private ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, T, TResult, TController> CreateNext<T>(ValueExtractor<TContext, T> valueExtractor) =>
            new ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, T, TResult, TController>(_controllerProvider)
                {
                    Q1 = Q1,
                    Q2 = Q2,
                    Q3 = Q3,
                    Q4 = Q4,
                    Q5 = Q5,
                    Q6 = Q6,
                    Q7 = Q7,
                    Q8 = valueExtractor
                };
        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TContext, TResult, TController> Context() =>
            CreateNext(ValueExtractors.Context<TContext>());

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TParsedContext, TResult, TController> Context<TParsedContext>(Func<TContext, TParsedContext> contextParser) =>
            CreateNext(ValueExtractors.Context(contextParser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TParsedContext, TResult, TController> Context<TParsedContext>(Func<TContext, CancellationToken, TParsedContext> contextParser) =>
            CreateNext(ValueExtractors.Context(contextParser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, CancellationToken, TResult, TController> CancellationToken() =>
            CreateNext(ValueExtractors.CancellationToken<TContext>());

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, T, TResult, TController> Single<T>(string name, Func<string, T> parser) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, string, TResult, TController> Single(string name) =>
            CreateNext(ValueExtractors.Single<TContext, string>(name, x => x));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, T, TResult, TController> Single<T>(string name, Func<string, T> parser, T def) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser, def));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, string, TResult, TController> Single(string name, string def) =>
            CreateNext(ValueExtractors.Single<TContext, string>(name, x => x, def));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, T[], TResult, TController> Multiple<T>(string name, Func<string, T> parser) =>
            CreateNext(ValueExtractors.Multiple<TContext, T>(name, parser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, string[], TResult, TController> Multiple(string name) =>
            CreateNext(ValueExtractors.Multiple<TContext, string>(name, x => x));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, T, TResult, TController> Custom<T>(Func<NameValueCollection, T> parser) =>
            CreateNext(ValueExtractors.Custom<TContext, T>(parser));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult> handler) =>
            (query, context, ct) => Task.FromResult(handler(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult>> handlerProvider) =>
            (query, context, ct) => Task.FromResult(handlerProvider(_controllerProvider)(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>> handler) =>
            (query, context, ct) => handler(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>>> handlerProvider) =>
            (query, context, ct) => handlerProvider(_controllerProvider)(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult> handler) =>
            (query, context, p1, ct) => Task.FromResult(handler(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult>> handlerProvider) =>
            (query, context, p1, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>> handler) =>
            (query, context, p1, ct) => handler(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>>> handlerProvider) =>
            (query, context, p1, ct) => handlerProvider(_controllerProvider)(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult> handler) =>
            (query, context, p1, p2, ct) => Task.FromResult(handler(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult>> handlerProvider) =>
            (query, context, p1, p2, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>> handler) =>
            (query, context, p1, p2, ct) => handler(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, ct) => handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult> handler) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handler(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, ct) => handler(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult> handler) =>
            (query, context, p1, p2, p3, p4, ct) => Task.FromResult(handler(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, ct) => handler(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, ct) => handler(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => handler(p1, p2, p3, p4, p5, p6, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => handler(p1, p2, p3, p4, p5, p6, p7, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, p9, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, p9, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct));

    }

    public class ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;

        public ParameterCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        public ValueExtractor<TContext, TQ1> Q1 { get; set; }
        public ValueExtractor<TContext, TQ2> Q2 { get; set; }
        public ValueExtractor<TContext, TQ3> Q3 { get; set; }
        public ValueExtractor<TContext, TQ4> Q4 { get; set; }
        public ValueExtractor<TContext, TQ5> Q5 { get; set; }
        public ValueExtractor<TContext, TQ6> Q6 { get; set; }
        public ValueExtractor<TContext, TQ7> Q7 { get; set; }
        public ValueExtractor<TContext, TQ8> Q8 { get; set; }

        private ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, T, TResult, TController> CreateNext<T>(ValueExtractor<TContext, T> valueExtractor) =>
            new ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, T, TResult, TController>(_controllerProvider)
                {
                    Q1 = Q1,
                    Q2 = Q2,
                    Q3 = Q3,
                    Q4 = Q4,
                    Q5 = Q5,
                    Q6 = Q6,
                    Q7 = Q7,
                    Q8 = Q8,
                    Q9 = valueExtractor
                };
        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TContext, TResult, TController> Context() =>
            CreateNext(ValueExtractors.Context<TContext>());

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TParsedContext, TResult, TController> Context<TParsedContext>(Func<TContext, TParsedContext> contextParser) =>
            CreateNext(ValueExtractors.Context(contextParser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TParsedContext, TResult, TController> Context<TParsedContext>(Func<TContext, CancellationToken, TParsedContext> contextParser) =>
            CreateNext(ValueExtractors.Context(contextParser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, CancellationToken, TResult, TController> CancellationToken() =>
            CreateNext(ValueExtractors.CancellationToken<TContext>());

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, T, TResult, TController> Single<T>(string name, Func<string, T> parser) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, string, TResult, TController> Single(string name) =>
            CreateNext(ValueExtractors.Single<TContext, string>(name, x => x));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, T, TResult, TController> Single<T>(string name, Func<string, T> parser, T def) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser, def));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, string, TResult, TController> Single(string name, string def) =>
            CreateNext(ValueExtractors.Single<TContext, string>(name, x => x, def));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, T[], TResult, TController> Multiple<T>(string name, Func<string, T> parser) =>
            CreateNext(ValueExtractors.Multiple<TContext, T>(name, parser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, string[], TResult, TController> Multiple(string name) =>
            CreateNext(ValueExtractors.Multiple<TContext, string>(name, x => x));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, T, TResult, TController> Custom<T>(Func<NameValueCollection, T> parser) =>
            CreateNext(ValueExtractors.Custom<TContext, T>(parser));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult> handler) =>
            (query, context, ct) => Task.FromResult(handler(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult>> handlerProvider) =>
            (query, context, ct) => Task.FromResult(handlerProvider(_controllerProvider)(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>> handler) =>
            (query, context, ct) => handler(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>>> handlerProvider) =>
            (query, context, ct) => handlerProvider(_controllerProvider)(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult> handler) =>
            (query, context, p1, ct) => Task.FromResult(handler(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult>> handlerProvider) =>
            (query, context, p1, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>> handler) =>
            (query, context, p1, ct) => handler(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>>> handlerProvider) =>
            (query, context, p1, ct) => handlerProvider(_controllerProvider)(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult> handler) =>
            (query, context, p1, p2, ct) => Task.FromResult(handler(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult>> handlerProvider) =>
            (query, context, p1, p2, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>> handler) =>
            (query, context, p1, p2, ct) => handler(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, ct) => handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult> handler) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handler(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, ct) => handler(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult> handler) =>
            (query, context, p1, p2, p3, p4, ct) => Task.FromResult(handler(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, ct) => handler(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, ct) => handler(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => handler(p1, p2, p3, p4, p5, p6, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => handler(p1, p2, p3, p4, p5, p6, p7, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, p8, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct) => handler(p1, p2, p3, p4, p5, p6, p7, p8, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, p8, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct));

    }

    public class ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;

        public ParameterCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        public ValueExtractor<TContext, TQ1> Q1 { get; set; }
        public ValueExtractor<TContext, TQ2> Q2 { get; set; }
        public ValueExtractor<TContext, TQ3> Q3 { get; set; }
        public ValueExtractor<TContext, TQ4> Q4 { get; set; }
        public ValueExtractor<TContext, TQ5> Q5 { get; set; }
        public ValueExtractor<TContext, TQ6> Q6 { get; set; }
        public ValueExtractor<TContext, TQ7> Q7 { get; set; }
        public ValueExtractor<TContext, TQ8> Q8 { get; set; }
        public ValueExtractor<TContext, TQ9> Q9 { get; set; }

        private ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, T, TResult, TController> CreateNext<T>(ValueExtractor<TContext, T> valueExtractor) =>
            new ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, T, TResult, TController>(_controllerProvider)
                {
                    Q1 = Q1,
                    Q2 = Q2,
                    Q3 = Q3,
                    Q4 = Q4,
                    Q5 = Q5,
                    Q6 = Q6,
                    Q7 = Q7,
                    Q8 = Q8,
                    Q9 = Q9,
                    Q10 = valueExtractor
                };
        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TContext, TResult, TController> Context() =>
            CreateNext(ValueExtractors.Context<TContext>());

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TParsedContext, TResult, TController> Context<TParsedContext>(Func<TContext, TParsedContext> contextParser) =>
            CreateNext(ValueExtractors.Context(contextParser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TParsedContext, TResult, TController> Context<TParsedContext>(Func<TContext, CancellationToken, TParsedContext> contextParser) =>
            CreateNext(ValueExtractors.Context(contextParser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, CancellationToken, TResult, TController> CancellationToken() =>
            CreateNext(ValueExtractors.CancellationToken<TContext>());

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, T, TResult, TController> Single<T>(string name, Func<string, T> parser) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, string, TResult, TController> Single(string name) =>
            CreateNext(ValueExtractors.Single<TContext, string>(name, x => x));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, T, TResult, TController> Single<T>(string name, Func<string, T> parser, T def) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser, def));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, string, TResult, TController> Single(string name, string def) =>
            CreateNext(ValueExtractors.Single<TContext, string>(name, x => x, def));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, T[], TResult, TController> Multiple<T>(string name, Func<string, T> parser) =>
            CreateNext(ValueExtractors.Multiple<TContext, T>(name, parser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, string[], TResult, TController> Multiple(string name) =>
            CreateNext(ValueExtractors.Multiple<TContext, string>(name, x => x));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, T, TResult, TController> Custom<T>(Func<NameValueCollection, T> parser) =>
            CreateNext(ValueExtractors.Custom<TContext, T>(parser));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult> handler) =>
            (query, context, ct) => Task.FromResult(handler(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult>> handlerProvider) =>
            (query, context, ct) => Task.FromResult(handlerProvider(_controllerProvider)(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>> handler) =>
            (query, context, ct) => handler(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>>> handlerProvider) =>
            (query, context, ct) => handlerProvider(_controllerProvider)(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult> handler) =>
            (query, context, p1, ct) => Task.FromResult(handler(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult>> handlerProvider) =>
            (query, context, p1, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>> handler) =>
            (query, context, p1, ct) => handler(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>>> handlerProvider) =>
            (query, context, p1, ct) => handlerProvider(_controllerProvider)(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult> handler) =>
            (query, context, p1, p2, ct) => Task.FromResult(handler(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult>> handlerProvider) =>
            (query, context, p1, p2, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>> handler) =>
            (query, context, p1, p2, ct) => handler(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, ct) => handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult> handler) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handler(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, ct) => handler(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult> handler) =>
            (query, context, p1, p2, p3, p4, ct) => Task.FromResult(handler(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, ct) => handler(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, ct) => handler(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => handler(p1, p2, p3, p4, p5, p6, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, p7, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => handler(p1, p2, p3, p4, p5, p6, p7, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6, TP7>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, p7, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, p7, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct));

    }

    public class ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;

        public ParameterCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        public ValueExtractor<TContext, TQ1> Q1 { get; set; }
        public ValueExtractor<TContext, TQ2> Q2 { get; set; }
        public ValueExtractor<TContext, TQ3> Q3 { get; set; }
        public ValueExtractor<TContext, TQ4> Q4 { get; set; }
        public ValueExtractor<TContext, TQ5> Q5 { get; set; }
        public ValueExtractor<TContext, TQ6> Q6 { get; set; }
        public ValueExtractor<TContext, TQ7> Q7 { get; set; }
        public ValueExtractor<TContext, TQ8> Q8 { get; set; }
        public ValueExtractor<TContext, TQ9> Q9 { get; set; }
        public ValueExtractor<TContext, TQ10> Q10 { get; set; }

        private ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, T, TResult, TController> CreateNext<T>(ValueExtractor<TContext, T> valueExtractor) =>
            new ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, T, TResult, TController>(_controllerProvider)
                {
                    Q1 = Q1,
                    Q2 = Q2,
                    Q3 = Q3,
                    Q4 = Q4,
                    Q5 = Q5,
                    Q6 = Q6,
                    Q7 = Q7,
                    Q8 = Q8,
                    Q9 = Q9,
                    Q10 = Q10,
                    Q11 = valueExtractor
                };
        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TContext, TResult, TController> Context() =>
            CreateNext(ValueExtractors.Context<TContext>());

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TParsedContext, TResult, TController> Context<TParsedContext>(Func<TContext, TParsedContext> contextParser) =>
            CreateNext(ValueExtractors.Context(contextParser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TParsedContext, TResult, TController> Context<TParsedContext>(Func<TContext, CancellationToken, TParsedContext> contextParser) =>
            CreateNext(ValueExtractors.Context(contextParser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, CancellationToken, TResult, TController> CancellationToken() =>
            CreateNext(ValueExtractors.CancellationToken<TContext>());

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, T, TResult, TController> Single<T>(string name, Func<string, T> parser) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, string, TResult, TController> Single(string name) =>
            CreateNext(ValueExtractors.Single<TContext, string>(name, x => x));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, T, TResult, TController> Single<T>(string name, Func<string, T> parser, T def) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser, def));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, string, TResult, TController> Single(string name, string def) =>
            CreateNext(ValueExtractors.Single<TContext, string>(name, x => x, def));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, T[], TResult, TController> Multiple<T>(string name, Func<string, T> parser) =>
            CreateNext(ValueExtractors.Multiple<TContext, T>(name, parser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, string[], TResult, TController> Multiple(string name) =>
            CreateNext(ValueExtractors.Multiple<TContext, string>(name, x => x));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, T, TResult, TController> Custom<T>(Func<NameValueCollection, T> parser) =>
            CreateNext(ValueExtractors.Custom<TContext, T>(parser));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult> handler) =>
            (query, context, ct) => Task.FromResult(handler(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult>> handlerProvider) =>
            (query, context, ct) => Task.FromResult(handlerProvider(_controllerProvider)(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>> handler) =>
            (query, context, ct) => handler(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>>> handlerProvider) =>
            (query, context, ct) => handlerProvider(_controllerProvider)(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult> handler) =>
            (query, context, p1, ct) => Task.FromResult(handler(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult>> handlerProvider) =>
            (query, context, p1, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>> handler) =>
            (query, context, p1, ct) => handler(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>>> handlerProvider) =>
            (query, context, p1, ct) => handlerProvider(_controllerProvider)(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult> handler) =>
            (query, context, p1, p2, ct) => Task.FromResult(handler(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult>> handlerProvider) =>
            (query, context, p1, p2, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>> handler) =>
            (query, context, p1, p2, ct) => handler(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, ct) => handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult> handler) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handler(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, ct) => handler(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult> handler) =>
            (query, context, p1, p2, p3, p4, ct) => Task.FromResult(handler(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, ct) => handler(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, ct) => handler(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, p6, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => handler(p1, p2, p3, p4, p5, p6, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5, TP6>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TP6, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, p6, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, p6, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct));

    }

    public class ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;

        public ParameterCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        public ValueExtractor<TContext, TQ1> Q1 { get; set; }
        public ValueExtractor<TContext, TQ2> Q2 { get; set; }
        public ValueExtractor<TContext, TQ3> Q3 { get; set; }
        public ValueExtractor<TContext, TQ4> Q4 { get; set; }
        public ValueExtractor<TContext, TQ5> Q5 { get; set; }
        public ValueExtractor<TContext, TQ6> Q6 { get; set; }
        public ValueExtractor<TContext, TQ7> Q7 { get; set; }
        public ValueExtractor<TContext, TQ8> Q8 { get; set; }
        public ValueExtractor<TContext, TQ9> Q9 { get; set; }
        public ValueExtractor<TContext, TQ10> Q10 { get; set; }
        public ValueExtractor<TContext, TQ11> Q11 { get; set; }

        private ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, T, TResult, TController> CreateNext<T>(ValueExtractor<TContext, T> valueExtractor) =>
            new ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, T, TResult, TController>(_controllerProvider)
                {
                    Q1 = Q1,
                    Q2 = Q2,
                    Q3 = Q3,
                    Q4 = Q4,
                    Q5 = Q5,
                    Q6 = Q6,
                    Q7 = Q7,
                    Q8 = Q8,
                    Q9 = Q9,
                    Q10 = Q10,
                    Q11 = Q11,
                    Q12 = valueExtractor
                };
        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TContext, TResult, TController> Context() =>
            CreateNext(ValueExtractors.Context<TContext>());

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TParsedContext, TResult, TController> Context<TParsedContext>(Func<TContext, TParsedContext> contextParser) =>
            CreateNext(ValueExtractors.Context(contextParser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TParsedContext, TResult, TController> Context<TParsedContext>(Func<TContext, CancellationToken, TParsedContext> contextParser) =>
            CreateNext(ValueExtractors.Context(contextParser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, CancellationToken, TResult, TController> CancellationToken() =>
            CreateNext(ValueExtractors.CancellationToken<TContext>());

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, T, TResult, TController> Single<T>(string name, Func<string, T> parser) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, string, TResult, TController> Single(string name) =>
            CreateNext(ValueExtractors.Single<TContext, string>(name, x => x));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, T, TResult, TController> Single<T>(string name, Func<string, T> parser, T def) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser, def));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, string, TResult, TController> Single(string name, string def) =>
            CreateNext(ValueExtractors.Single<TContext, string>(name, x => x, def));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, T[], TResult, TController> Multiple<T>(string name, Func<string, T> parser) =>
            CreateNext(ValueExtractors.Multiple<TContext, T>(name, parser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, string[], TResult, TController> Multiple(string name) =>
            CreateNext(ValueExtractors.Multiple<TContext, string>(name, x => x));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, T, TResult, TController> Custom<T>(Func<NameValueCollection, T> parser) =>
            CreateNext(ValueExtractors.Custom<TContext, T>(parser));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult> handler) =>
            (query, context, ct) => Task.FromResult(handler(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult>> handlerProvider) =>
            (query, context, ct) => Task.FromResult(handlerProvider(_controllerProvider)(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, Task<TResult>> handler) =>
            (query, context, ct) => handler(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, Task<TResult>>> handlerProvider) =>
            (query, context, ct) => handlerProvider(_controllerProvider)(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult> handler) =>
            (query, context, p1, ct) => Task.FromResult(handler(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult>> handlerProvider) =>
            (query, context, p1, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, Task<TResult>> handler) =>
            (query, context, p1, ct) => handler(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, Task<TResult>>> handlerProvider) =>
            (query, context, p1, ct) => handlerProvider(_controllerProvider)(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult> handler) =>
            (query, context, p1, p2, ct) => Task.FromResult(handler(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult>> handlerProvider) =>
            (query, context, p1, p2, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, Task<TResult>> handler) =>
            (query, context, p1, p2, ct) => handler(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, ct) => handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult> handler) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handler(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, ct) => handler(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult> handler) =>
            (query, context, p1, p2, p3, p4, ct) => Task.FromResult(handler(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, ct) => handler(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult> handler) =>
            (query, context, p1, p2, p3, p4, p5, ct) => Task.FromResult(handler(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, p5, ct) => handler(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> CreateHandler<TP1, TP2, TP3, TP4, TP5>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TP5, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, p5, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, p5, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct));

    }

    public class ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;

        public ParameterCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        public ValueExtractor<TContext, TQ1> Q1 { get; set; }
        public ValueExtractor<TContext, TQ2> Q2 { get; set; }
        public ValueExtractor<TContext, TQ3> Q3 { get; set; }
        public ValueExtractor<TContext, TQ4> Q4 { get; set; }
        public ValueExtractor<TContext, TQ5> Q5 { get; set; }
        public ValueExtractor<TContext, TQ6> Q6 { get; set; }
        public ValueExtractor<TContext, TQ7> Q7 { get; set; }
        public ValueExtractor<TContext, TQ8> Q8 { get; set; }
        public ValueExtractor<TContext, TQ9> Q9 { get; set; }
        public ValueExtractor<TContext, TQ10> Q10 { get; set; }
        public ValueExtractor<TContext, TQ11> Q11 { get; set; }
        public ValueExtractor<TContext, TQ12> Q12 { get; set; }

        private ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, T, TResult, TController> CreateNext<T>(ValueExtractor<TContext, T> valueExtractor) =>
            new ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, T, TResult, TController>(_controllerProvider)
                {
                    Q1 = Q1,
                    Q2 = Q2,
                    Q3 = Q3,
                    Q4 = Q4,
                    Q5 = Q5,
                    Q6 = Q6,
                    Q7 = Q7,
                    Q8 = Q8,
                    Q9 = Q9,
                    Q10 = Q10,
                    Q11 = Q11,
                    Q12 = Q12,
                    Q13 = valueExtractor
                };
        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TContext, TResult, TController> Context() =>
            CreateNext(ValueExtractors.Context<TContext>());

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TParsedContext, TResult, TController> Context<TParsedContext>(Func<TContext, TParsedContext> contextParser) =>
            CreateNext(ValueExtractors.Context(contextParser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TParsedContext, TResult, TController> Context<TParsedContext>(Func<TContext, CancellationToken, TParsedContext> contextParser) =>
            CreateNext(ValueExtractors.Context(contextParser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, CancellationToken, TResult, TController> CancellationToken() =>
            CreateNext(ValueExtractors.CancellationToken<TContext>());

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, T, TResult, TController> Single<T>(string name, Func<string, T> parser) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, string, TResult, TController> Single(string name) =>
            CreateNext(ValueExtractors.Single<TContext, string>(name, x => x));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, T, TResult, TController> Single<T>(string name, Func<string, T> parser, T def) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser, def));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, string, TResult, TController> Single(string name, string def) =>
            CreateNext(ValueExtractors.Single<TContext, string>(name, x => x, def));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, T[], TResult, TController> Multiple<T>(string name, Func<string, T> parser) =>
            CreateNext(ValueExtractors.Multiple<TContext, T>(name, parser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, string[], TResult, TController> Multiple(string name) =>
            CreateNext(ValueExtractors.Multiple<TContext, string>(name, x => x));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, T, TResult, TController> Custom<T>(Func<NameValueCollection, T> parser) =>
            CreateNext(ValueExtractors.Custom<TContext, T>(parser));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult> handler) =>
            (query, context, ct) => Task.FromResult(handler(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult>> handlerProvider) =>
            (query, context, ct) => Task.FromResult(handlerProvider(_controllerProvider)(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, Task<TResult>> handler) =>
            (query, context, ct) => handler(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, Task<TResult>>> handlerProvider) =>
            (query, context, ct) => handlerProvider(_controllerProvider)(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult> handler) =>
            (query, context, p1, ct) => Task.FromResult(handler(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult>> handlerProvider) =>
            (query, context, p1, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, Task<TResult>> handler) =>
            (query, context, p1, ct) => handler(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, Task<TResult>>> handlerProvider) =>
            (query, context, p1, ct) => handlerProvider(_controllerProvider)(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult> handler) =>
            (query, context, p1, p2, ct) => Task.FromResult(handler(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult>> handlerProvider) =>
            (query, context, p1, p2, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, Task<TResult>> handler) =>
            (query, context, p1, p2, ct) => handler(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, ct) => handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult> handler) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handler(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, ct) => handler(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult> handler) =>
            (query, context, p1, p2, p3, p4, ct) => Task.FromResult(handler(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, p4, ct) => handler(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> CreateHandler<TP1, TP2, TP3, TP4>(Func<Func<TController>, Func<TP1, TP2, TP3, TP4, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, p4, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, p4, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct));

    }

    public class ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;

        public ParameterCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        public ValueExtractor<TContext, TQ1> Q1 { get; set; }
        public ValueExtractor<TContext, TQ2> Q2 { get; set; }
        public ValueExtractor<TContext, TQ3> Q3 { get; set; }
        public ValueExtractor<TContext, TQ4> Q4 { get; set; }
        public ValueExtractor<TContext, TQ5> Q5 { get; set; }
        public ValueExtractor<TContext, TQ6> Q6 { get; set; }
        public ValueExtractor<TContext, TQ7> Q7 { get; set; }
        public ValueExtractor<TContext, TQ8> Q8 { get; set; }
        public ValueExtractor<TContext, TQ9> Q9 { get; set; }
        public ValueExtractor<TContext, TQ10> Q10 { get; set; }
        public ValueExtractor<TContext, TQ11> Q11 { get; set; }
        public ValueExtractor<TContext, TQ12> Q12 { get; set; }
        public ValueExtractor<TContext, TQ13> Q13 { get; set; }

        private ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, T, TResult, TController> CreateNext<T>(ValueExtractor<TContext, T> valueExtractor) =>
            new ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, T, TResult, TController>(_controllerProvider)
                {
                    Q1 = Q1,
                    Q2 = Q2,
                    Q3 = Q3,
                    Q4 = Q4,
                    Q5 = Q5,
                    Q6 = Q6,
                    Q7 = Q7,
                    Q8 = Q8,
                    Q9 = Q9,
                    Q10 = Q10,
                    Q11 = Q11,
                    Q12 = Q12,
                    Q13 = Q13,
                    Q14 = valueExtractor
                };
        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TContext, TResult, TController> Context() =>
            CreateNext(ValueExtractors.Context<TContext>());

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TParsedContext, TResult, TController> Context<TParsedContext>(Func<TContext, TParsedContext> contextParser) =>
            CreateNext(ValueExtractors.Context(contextParser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TParsedContext, TResult, TController> Context<TParsedContext>(Func<TContext, CancellationToken, TParsedContext> contextParser) =>
            CreateNext(ValueExtractors.Context(contextParser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, CancellationToken, TResult, TController> CancellationToken() =>
            CreateNext(ValueExtractors.CancellationToken<TContext>());

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, T, TResult, TController> Single<T>(string name, Func<string, T> parser) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, string, TResult, TController> Single(string name) =>
            CreateNext(ValueExtractors.Single<TContext, string>(name, x => x));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, T, TResult, TController> Single<T>(string name, Func<string, T> parser, T def) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser, def));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, string, TResult, TController> Single(string name, string def) =>
            CreateNext(ValueExtractors.Single<TContext, string>(name, x => x, def));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, T[], TResult, TController> Multiple<T>(string name, Func<string, T> parser) =>
            CreateNext(ValueExtractors.Multiple<TContext, T>(name, parser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, string[], TResult, TController> Multiple(string name) =>
            CreateNext(ValueExtractors.Multiple<TContext, string>(name, x => x));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, T, TResult, TController> Custom<T>(Func<NameValueCollection, T> parser) =>
            CreateNext(ValueExtractors.Custom<TContext, T>(parser));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult> handler) =>
            (query, context, ct) => Task.FromResult(handler(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult>> handlerProvider) =>
            (query, context, ct) => Task.FromResult(handlerProvider(_controllerProvider)(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, Task<TResult>> handler) =>
            (query, context, ct) => handler(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, Task<TResult>>> handlerProvider) =>
            (query, context, ct) => handlerProvider(_controllerProvider)(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult> handler) =>
            (query, context, p1, ct) => Task.FromResult(handler(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult>> handlerProvider) =>
            (query, context, p1, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, Task<TResult>> handler) =>
            (query, context, p1, ct) => handler(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, Task<TResult>>> handlerProvider) =>
            (query, context, p1, ct) => handlerProvider(_controllerProvider)(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult> handler) =>
            (query, context, p1, p2, ct) => Task.FromResult(handler(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult>> handlerProvider) =>
            (query, context, p1, p2, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, Task<TResult>> handler) =>
            (query, context, p1, p2, ct) => handler(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, ct) => handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult> handler) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handler(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TResult>> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, Task<TResult>> handler) =>
            (query, context, p1, p2, p3, ct) => handler(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TP3, TResult> CreateHandler<TP1, TP2, TP3>(Func<Func<TController>, Func<TP1, TP2, TP3, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, p3, ct) => handlerProvider(_controllerProvider)(p1, p2, p3, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct));

    }

    public class ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;

        public ParameterCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        public ValueExtractor<TContext, TQ1> Q1 { get; set; }
        public ValueExtractor<TContext, TQ2> Q2 { get; set; }
        public ValueExtractor<TContext, TQ3> Q3 { get; set; }
        public ValueExtractor<TContext, TQ4> Q4 { get; set; }
        public ValueExtractor<TContext, TQ5> Q5 { get; set; }
        public ValueExtractor<TContext, TQ6> Q6 { get; set; }
        public ValueExtractor<TContext, TQ7> Q7 { get; set; }
        public ValueExtractor<TContext, TQ8> Q8 { get; set; }
        public ValueExtractor<TContext, TQ9> Q9 { get; set; }
        public ValueExtractor<TContext, TQ10> Q10 { get; set; }
        public ValueExtractor<TContext, TQ11> Q11 { get; set; }
        public ValueExtractor<TContext, TQ12> Q12 { get; set; }
        public ValueExtractor<TContext, TQ13> Q13 { get; set; }
        public ValueExtractor<TContext, TQ14> Q14 { get; set; }

        private ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, T, TResult, TController> CreateNext<T>(ValueExtractor<TContext, T> valueExtractor) =>
            new ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, T, TResult, TController>(_controllerProvider)
                {
                    Q1 = Q1,
                    Q2 = Q2,
                    Q3 = Q3,
                    Q4 = Q4,
                    Q5 = Q5,
                    Q6 = Q6,
                    Q7 = Q7,
                    Q8 = Q8,
                    Q9 = Q9,
                    Q10 = Q10,
                    Q11 = Q11,
                    Q12 = Q12,
                    Q13 = Q13,
                    Q14 = Q14,
                    Q15 = valueExtractor
                };
        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TContext, TResult, TController> Context() =>
            CreateNext(ValueExtractors.Context<TContext>());

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TParsedContext, TResult, TController> Context<TParsedContext>(Func<TContext, TParsedContext> contextParser) =>
            CreateNext(ValueExtractors.Context(contextParser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TParsedContext, TResult, TController> Context<TParsedContext>(Func<TContext, CancellationToken, TParsedContext> contextParser) =>
            CreateNext(ValueExtractors.Context(contextParser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, CancellationToken, TResult, TController> CancellationToken() =>
            CreateNext(ValueExtractors.CancellationToken<TContext>());

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, T, TResult, TController> Single<T>(string name, Func<string, T> parser) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, string, TResult, TController> Single(string name) =>
            CreateNext(ValueExtractors.Single<TContext, string>(name, x => x));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, T, TResult, TController> Single<T>(string name, Func<string, T> parser, T def) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser, def));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, string, TResult, TController> Single(string name, string def) =>
            CreateNext(ValueExtractors.Single<TContext, string>(name, x => x, def));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, T[], TResult, TController> Multiple<T>(string name, Func<string, T> parser) =>
            CreateNext(ValueExtractors.Multiple<TContext, T>(name, parser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, string[], TResult, TController> Multiple(string name) =>
            CreateNext(ValueExtractors.Multiple<TContext, string>(name, x => x));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, T, TResult, TController> Custom<T>(Func<NameValueCollection, T> parser) =>
            CreateNext(ValueExtractors.Custom<TContext, T>(parser));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult> handler) =>
            (query, context, ct) => Task.FromResult(handler(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct), Q14(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult>> handlerProvider) =>
            (query, context, ct) => Task.FromResult(handlerProvider(_controllerProvider)(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct), Q14(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, Task<TResult>> handler) =>
            (query, context, ct) => handler(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct), Q14(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, Task<TResult>>> handlerProvider) =>
            (query, context, ct) => handlerProvider(_controllerProvider)(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct), Q14(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult> handler) =>
            (query, context, p1, ct) => Task.FromResult(handler(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct), Q14(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult>> handlerProvider) =>
            (query, context, p1, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct), Q14(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, Task<TResult>> handler) =>
            (query, context, p1, ct) => handler(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct), Q14(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, Task<TResult>>> handlerProvider) =>
            (query, context, p1, ct) => handlerProvider(_controllerProvider)(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct), Q14(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult> handler) =>
            (query, context, p1, p2, ct) => Task.FromResult(handler(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct), Q14(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TResult>> handlerProvider) =>
            (query, context, p1, p2, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct), Q14(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, Task<TResult>> handler) =>
            (query, context, p1, p2, ct) => handler(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct), Q14(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TP2, TResult> CreateHandler<TP1, TP2>(Func<Func<TController>, Func<TP1, TP2, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, Task<TResult>>> handlerProvider) =>
            (query, context, p1, p2, ct) => handlerProvider(_controllerProvider)(p1, p2, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct), Q14(context, query, ct));

    }

    public class ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;

        public ParameterCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        public ValueExtractor<TContext, TQ1> Q1 { get; set; }
        public ValueExtractor<TContext, TQ2> Q2 { get; set; }
        public ValueExtractor<TContext, TQ3> Q3 { get; set; }
        public ValueExtractor<TContext, TQ4> Q4 { get; set; }
        public ValueExtractor<TContext, TQ5> Q5 { get; set; }
        public ValueExtractor<TContext, TQ6> Q6 { get; set; }
        public ValueExtractor<TContext, TQ7> Q7 { get; set; }
        public ValueExtractor<TContext, TQ8> Q8 { get; set; }
        public ValueExtractor<TContext, TQ9> Q9 { get; set; }
        public ValueExtractor<TContext, TQ10> Q10 { get; set; }
        public ValueExtractor<TContext, TQ11> Q11 { get; set; }
        public ValueExtractor<TContext, TQ12> Q12 { get; set; }
        public ValueExtractor<TContext, TQ13> Q13 { get; set; }
        public ValueExtractor<TContext, TQ14> Q14 { get; set; }
        public ValueExtractor<TContext, TQ15> Q15 { get; set; }

        private ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, T, TResult, TController> CreateNext<T>(ValueExtractor<TContext, T> valueExtractor) =>
            new ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, T, TResult, TController>(_controllerProvider)
                {
                    Q1 = Q1,
                    Q2 = Q2,
                    Q3 = Q3,
                    Q4 = Q4,
                    Q5 = Q5,
                    Q6 = Q6,
                    Q7 = Q7,
                    Q8 = Q8,
                    Q9 = Q9,
                    Q10 = Q10,
                    Q11 = Q11,
                    Q12 = Q12,
                    Q13 = Q13,
                    Q14 = Q14,
                    Q15 = Q15,
                    Q16 = valueExtractor
                };
        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TContext, TResult, TController> Context() =>
            CreateNext(ValueExtractors.Context<TContext>());

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TParsedContext, TResult, TController> Context<TParsedContext>(Func<TContext, TParsedContext> contextParser) =>
            CreateNext(ValueExtractors.Context(contextParser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TParsedContext, TResult, TController> Context<TParsedContext>(Func<TContext, CancellationToken, TParsedContext> contextParser) =>
            CreateNext(ValueExtractors.Context(contextParser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, CancellationToken, TResult, TController> CancellationToken() =>
            CreateNext(ValueExtractors.CancellationToken<TContext>());

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, T, TResult, TController> Single<T>(string name, Func<string, T> parser) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, string, TResult, TController> Single(string name) =>
            CreateNext(ValueExtractors.Single<TContext, string>(name, x => x));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, T, TResult, TController> Single<T>(string name, Func<string, T> parser, T def) =>
            CreateNext(ValueExtractors.Single<TContext, T>(name, parser, def));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, string, TResult, TController> Single(string name, string def) =>
            CreateNext(ValueExtractors.Single<TContext, string>(name, x => x, def));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, T[], TResult, TController> Multiple<T>(string name, Func<string, T> parser) =>
            CreateNext(ValueExtractors.Multiple<TContext, T>(name, parser));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, string[], TResult, TController> Multiple(string name) =>
            CreateNext(ValueExtractors.Multiple<TContext, string>(name, x => x));

        public ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, T, TResult, TController> Custom<T>(Func<NameValueCollection, T> parser) =>
            CreateNext(ValueExtractors.Custom<TContext, T>(parser));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TResult> handler) =>
            (query, context, ct) => Task.FromResult(handler(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct), Q14(context, query, ct), Q15(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TResult>> handlerProvider) =>
            (query, context, ct) => Task.FromResult(handlerProvider(_controllerProvider)(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct), Q14(context, query, ct), Q15(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, Task<TResult>> handler) =>
            (query, context, ct) => handler(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct), Q14(context, query, ct), Q15(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, Task<TResult>>> handlerProvider) =>
            (query, context, ct) => handlerProvider(_controllerProvider)(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct), Q14(context, query, ct), Q15(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TResult> handler) =>
            (query, context, p1, ct) => Task.FromResult(handler(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct), Q14(context, query, ct), Q15(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TResult>> handlerProvider) =>
            (query, context, p1, ct) => Task.FromResult(handlerProvider(_controllerProvider)(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct), Q14(context, query, ct), Q15(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, Task<TResult>> handler) =>
            (query, context, p1, ct) => handler(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct), Q14(context, query, ct), Q15(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TP1, TResult> CreateHandler<TP1>(Func<Func<TController>, Func<TP1, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, Task<TResult>>> handlerProvider) =>
            (query, context, p1, ct) => handlerProvider(_controllerProvider)(p1, Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct), Q14(context, query, ct), Q15(context, query, ct));

    }

    public class ParameterCollector<TContext, TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TQ16, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;

        public ParameterCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        public ValueExtractor<TContext, TQ1> Q1 { get; set; }
        public ValueExtractor<TContext, TQ2> Q2 { get; set; }
        public ValueExtractor<TContext, TQ3> Q3 { get; set; }
        public ValueExtractor<TContext, TQ4> Q4 { get; set; }
        public ValueExtractor<TContext, TQ5> Q5 { get; set; }
        public ValueExtractor<TContext, TQ6> Q6 { get; set; }
        public ValueExtractor<TContext, TQ7> Q7 { get; set; }
        public ValueExtractor<TContext, TQ8> Q8 { get; set; }
        public ValueExtractor<TContext, TQ9> Q9 { get; set; }
        public ValueExtractor<TContext, TQ10> Q10 { get; set; }
        public ValueExtractor<TContext, TQ11> Q11 { get; set; }
        public ValueExtractor<TContext, TQ12> Q12 { get; set; }
        public ValueExtractor<TContext, TQ13> Q13 { get; set; }
        public ValueExtractor<TContext, TQ14> Q14 { get; set; }
        public ValueExtractor<TContext, TQ15> Q15 { get; set; }
        public ValueExtractor<TContext, TQ16> Q16 { get; set; }


        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TQ16, TResult> handler) =>
            (query, context, ct) => Task.FromResult(handler(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct), Q14(context, query, ct), Q15(context, query, ct), Q16(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TQ16, TResult>> handlerProvider) =>
            (query, context, ct) => Task.FromResult(handlerProvider(_controllerProvider)(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct), Q14(context, query, ct), Q15(context, query, ct), Q16(context, query, ct)));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TQ16, Task<TResult>> handler) =>
            (query, context, ct) => handler(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct), Q14(context, query, ct), Q15(context, query, ct), Q16(context, query, ct));

        public AsyncParameterCollectorHandler<TContext, TResult> CreateHandler(Func<Func<TController>, Func<TQ1, TQ2, TQ3, TQ4, TQ5, TQ6, TQ7, TQ8, TQ9, TQ10, TQ11, TQ12, TQ13, TQ14, TQ15, TQ16, Task<TResult>>> handlerProvider) =>
            (query, context, ct) => handlerProvider(_controllerProvider)(Q1(context, query, ct), Q2(context, query, ct), Q3(context, query, ct), Q4(context, query, ct), Q5(context, query, ct), Q6(context, query, ct), Q7(context, query, ct), Q8(context, query, ct), Q9(context, query, ct), Q10(context, query, ct), Q11(context, query, ct), Q12(context, query, ct), Q13(context, query, ct), Q14(context, query, ct), Q15(context, query, ct), Q16(context, query, ct));

    }

}
