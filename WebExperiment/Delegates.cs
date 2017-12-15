using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using System.Threading.Tasks;

namespace WebExperiment
{
    // Factory
    public delegate T Factory<out T>();
    
    // Transformer
    public delegate TOut Transformer<in TIn, out TOut>(TIn input);
    
    // MainHandler
    public delegate Task<TResult> MainHandler<in TContext, TResult>(string httpMethod, Uri uri, TContext context, CancellationToken ct);
    
    // Parser
    public delegate TValue Parser<out TValue>(string str);
    
    // ValueExtractor
    public delegate T ValueExtractor<in TContext, out T>(TContext context, NameValueCollection parameters, CancellationToken ct);

    public delegate T Mutator<T>(T t);

    #region Handlers
    
    // ParameterCollectorFiller
    public delegate ParameterCollector<TContext, TResult, TController> ParameterCollectorFiller<TContext, TResult, TController>(ParameterCollector<TContext, TResult, TController> parameterCollector);
    public delegate ParameterCollector<TContext, TQ1, TResult, TController> ParameterCollectorFiller<TContext, TQ1, TResult, TController>(ParameterCollector<TContext, TResult, TController> parameterCollector);
    public delegate ParameterCollector<TContext, TQ1, TQ2, TResult, TController> ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController>(ParameterCollector<TContext, TResult, TController> parameterCollector);
    public delegate ParameterCollector<TContext, TQ1, TQ2, TQ3, TResult, TController> ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController>(ParameterCollector<TContext, TResult, TController> parameterCollector);
    
    #endregion

    #region Handlers
    
    // ResourceCollectorHandle
    public delegate Task<TResult> ResourceCollectorHandle<in TContext, TResult>(string httpMethod, ICollection<string> urlSegments, NameValueCollection queryParameters, TContext context, CancellationToken ct);
    public delegate Task<TResult> ResourceCollectorHandle<in TContext, TResult, in TP1>(string httpMethod, ICollection<string> urlSegments, NameValueCollection queryParameters, TContext context, TP1 p1, CancellationToken ct);
    public delegate Task<TResult> ResourceCollectorHandle<in TContext, TResult, in TP1, in TP2>(string httpMethod, ICollection<string> urlSegments, NameValueCollection queryParameters, TContext context, TP1 p1, TP2 tp2, CancellationToken ct);
    
    // HttpMethodCollectorHandle
    public delegate Task<TResult> HttpMethodCollectorHandle<in TContext, TResult>(string httpMethod, NameValueCollection query, TContext context, CancellationToken ct);
    public delegate Task<TResult> HttpMethodCollectorHandle<in TContext, TResult, in TP1>(string httpMethod, NameValueCollection query, TContext context, TP1 p1, CancellationToken ct);
    public delegate Task<TResult> HttpMethodCollectorHandle<in TContext, TResult, in TP1, in TP2>(string httpMethod, NameValueCollection query, TContext context, TP1 p1, TP2 p2, CancellationToken ct);
    
    // ParameterCollectorHandle
    public delegate Task<TResult> ParameterCollectorHandle<in TContext, TResult>(NameValueCollection query, TContext context, CancellationToken ct);
    public delegate Task<TResult> ParameterCollectorHandle<in TContext, TResult, in TP1>(NameValueCollection query, TContext context, TP1 p1, CancellationToken ct);
    public delegate Task<TResult> ParameterCollectorHandle<in TContext, TResult, in TP1, in TP2>(NameValueCollection query, TContext context, TP1 p1, TP2 p2, CancellationToken ct);
    public delegate Task<TResult> ParameterCollectorHandle<in TContext, TResult, in TP1, in TP2, in TP3>(NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, CancellationToken ct);

    #endregion

    #region Actions

    public delegate TResult Action<out TResult>();
    public delegate TResult Action<in T1, out TResult>(T1 v1);
    public delegate TResult Action<in T1, in T2, out TResult>(T1 v1, T2 v2);
    public delegate TResult Action<in T1, in T2, in T3, out TResult>(T1 v1, T2 v2, T3 v3);
    public delegate TResult Action<in T1, in T2, in T3, in T4, out TResult>(T1 v1, T2 v2, T3 v3, T4 v4);
    public delegate TResult Action<in T1, in T2, in T3, in T4, in T5, out TResult>(T1 v1, T2 v2, T3 v3, T4 v4, T5 v5);
    public delegate TResult Action<in T1, in T2, in T3, in T4, in T5, in T6, out TResult>(T1 v1, T2 v2, T3 v3, T4 v4, T5 v5, T6 v6);
    
    public delegate Task<TResult> AsyncAction<TResult>();
    public delegate Task<TResult> AsyncAction<in T1, TResult>(T1 v1);
    public delegate Task<TResult> AsyncAction<in T1, in T2, TResult>(T1 v1, T2 v2);
    public delegate Task<TResult> AsyncAction<in T1, in T2, in T3, TResult>(T1 v1, T2 v2, T3 v3);
    public delegate Task<TResult> AsyncAction<in T1, in T2, in T3, in T4, TResult>(T1 v1, T2 v2, T3 v3, T4 v4);
    public delegate Task<TResult> AsyncAction<in T1, in T2, in T3, in T4, in T5, TResult>(T1 v1, T2 v2, T3 v3, T4 v4, T5 v5);
    public delegate Task<TResult> AsyncAction<in T1, in T2, in T3, in T4, in T5, in T6, TResult>(T1 v1, T2 v2, T3 v3, T4 v4, T5 v5, T6 v6);

    #endregion
    
    #region Action factories
    
    public delegate Action<TResult> ActionFactory<in TController, out TResult>(Factory<TController> controllerFactory);
    public delegate Action<T1, TResult> ActionFactory<in TController, in T1, out TResult>(Factory<TController> controllerFactory);
    public delegate Action<T1, T2, TResult> ActionFactory<in TController, in T1, in T2, out TResult>(Factory<TController> controllerFactory);
    public delegate Action<T1, T2, T3, TResult> ActionFactory<in TController, in T1, in T2, in T3, out TResult>(Factory<TController> controllerFactory);
    public delegate Action<T1, T2, T3, T4, TResult> ActionFactory<in TController, in T1, in T2, in T3, in T4, out TResult>(Factory<TController> controllerFactory);
    public delegate Action<T1, T2, T3, T4, T5, TResult> ActionFactory<in TController, in T1, in T2, in T3, in T4, in T5, out TResult>(Factory<TController> controllerFactory);
    public delegate Action<T1, T2, T3, T4, T5, T6, TResult> ActionFactory<in TController, in T1, in T2, in T3, in T4, in T5, in T6, out TResult>(Factory<TController> controllerFactory);
    
    public delegate AsyncAction<TResult> AsyncActionFactory<in TController, TResult>(Factory<TController> controllerFactory);
    public delegate AsyncAction<T1, TResult> AsyncActionFactory<in TController, in T1, TResult>(Factory<TController> controllerFactory);
    public delegate AsyncAction<T1, T2, TResult> AsyncActionFactory<in TController, in T1, in T2, TResult>(Factory<TController> controllerFactory);
    public delegate AsyncAction<T1, T2, T3, TResult> AsyncActionFactory<in TController, in T1, in T2, in T3, TResult>(Factory<TController> controllerFactory);
    public delegate AsyncAction<T1, T2, T3, T4, TResult> AsyncActionFactory<in TController, in T1, in T2, in T3, in T4, TResult>(Factory<TController> controllerFactory);
    public delegate AsyncAction<T1, T2, T3, T4, T5, TResult> AsyncActionFactory<in TController, in T1, in T2, in T3, in T4, in T5, TResult>(Factory<TController> controllerFactory);
    public delegate AsyncAction<T1, T2, T3, T4, T5, T6, TResult> AsyncActionFactory<in TController, in T1, in T2, in T3, in T4, in T5, in T6, TResult>(Factory<TController> controllerFactory);
    
    #endregion
}