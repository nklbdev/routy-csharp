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

    #region Fillers
    
    // HttpMethodCollectorFiller
    public delegate HttpMethodCollector<TContext, TResult, TController> HttpMethodCollectorFiller<TContext, TResult, TController>(HttpMethodCollector<TContext, TResult, TController> httpMethodCollector);
    public delegate HttpMethodCollector<TContext, TResult, TController, TP1> HttpMethodCollectorFiller<TContext, TResult, TController, TP1>(HttpMethodCollector<TContext, TResult, TController, TP1> httpMethodCollector);
    public delegate HttpMethodCollector<TContext, TResult, TController, TP1, TP2> HttpMethodCollectorFiller<TContext, TResult, TController, TP1, TP2>(HttpMethodCollector<TContext, TResult, TController, TP1, TP2> httpMethodCollector);
    
    // ResourceCollectorFiller
    public delegate ResourceCollector<TContext, TResult, TController> ResourceCollectorFiller<TContext, TResult, TController>(ResourceCollector<TContext, TResult, TController> resourceCollector);
    public delegate ResourceCollector<TContext, TResult, TController, TP1> ResourceCollectorFiller<TContext, TResult, TController, TP1>(ResourceCollector<TContext, TResult, TController, TP1> resourceCollector);
    public delegate ResourceCollector<TContext, TResult, TController, TP1, TP2> ResourceCollectorFiller<TContext, TResult, TController, TP1, TP2>(ResourceCollector<TContext, TResult, TController, TP1, TP2> resourceCollector);
    
    // ParameterCollectorFiller
    public delegate ParameterCollector<TContext, TResult, TController> ParameterCollectorFiller<TContext, TResult, TController>(ParameterCollector<TContext, TResult, TController> parameterCollector);
    public delegate ParameterCollector<TContext, TQ1, TResult, TController> ParameterCollectorFiller<TContext, TQ1, TResult, TController>(ParameterCollector<TContext, TResult, TController> parameterCollector);
    public delegate ParameterCollector<TContext, TQ1, TQ2, TResult, TController> ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController>(ParameterCollector<TContext, TResult, TController> parameterCollector);
    
    // QueryCollectorFiller
    public delegate QueryCollector<TContext, TResult, TController> QueryCollectorFiller<TContext, TResult, TController>(QueryCollector<TContext, TResult, TController> queryCollector);
    public delegate QueryCollector<TContext, TResult, TController, TP1> QueryCollectorFiller<TContext, TResult, TController, TP1>(QueryCollector<TContext, TResult, TController, TP1> queryCollector);
    public delegate QueryCollector<TContext, TResult, TController, TP1, TP2> QueryCollectorFiller<TContext, TResult, TController, TP1, TP2>(QueryCollector<TContext, TResult, TController, TP1, TP2> queryCollector);
    
    #endregion

    #region Handlers
    
    // ResourceHandle
    public delegate Task<TResult> ResourceHandle<in TContext, TResult>(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, CancellationToken ct);
    public delegate Task<TResult> ResourceHandle<in TContext, TResult, in TP1>(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, TP1 p1, CancellationToken ct);
    public delegate Task<TResult> ResourceHandle<in TContext, TResult, in TP1, in TP2>(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, TP1 p1, TP2 p2, CancellationToken ct);
    
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
    
    #endregion

    #region Actions

    public delegate TResult Action<out TResult>();
    public delegate TResult Action<in T1, out TResult>(T1 v1);
    public delegate TResult Action<in T1, in T2, out TResult>(T1 v1, T2 v2);
    public delegate TResult Action<in T1, in T2, in T3, out TResult>(T1 v1, T2 v2, T3 v3);
    public delegate TResult Action<in T1, in T2, in T3, in T4, out TResult>(T1 v1, T2 v2, T3 v3, T4 v4);
    
    public delegate Task<TResult> AsyncAction<TResult>();
    public delegate Task<TResult> AsyncAction<in T1, TResult>(T1 v1);
    public delegate Task<TResult> AsyncAction<in T1, in T2, TResult>(T1 v1, T2 v2);
    public delegate Task<TResult> AsyncAction<in T1, in T2, in T3, TResult>(T1 v1, T2 v2, T3 v3);
    public delegate Task<TResult> AsyncAction<in T1, in T2, in T3, in T4, TResult>(T1 v1, T2 v2, T3 v3, T4 v4);

    #endregion
    
    #region Action factories
    
    public delegate Action<TResult> ActionFactory<in TController, out TResult>(Factory<TController> controllerFactory);
    public delegate Action<T1, TResult> ActionFactory<in TController, in T1, out TResult>(Factory<TController> controllerFactory);
    public delegate Action<T1, T2, TResult> ActionFactory<in TController, in T1, in T2, out TResult>(Factory<TController> controllerFactory);
    public delegate Action<T1, T2, T3, TResult> ActionFactory<in TController, in T1, in T2, in T3, out TResult>(Factory<TController> controllerFactory);
    public delegate Action<T1, T2, T3, T4, TResult> ActionFactory<in TController, in T1, in T2, in T3, in T4, out TResult>(Factory<TController> controllerFactory);
    
    public delegate AsyncAction<TResult> AsyncActionFactory<in TController, TResult>(Factory<TController> controllerFactory);
    public delegate AsyncAction<T1, TResult> AsyncActionFactory<in TController, in T1, TResult>(Factory<TController> controllerFactory);
    public delegate AsyncAction<T1, T2, TResult> AsyncActionFactory<in TController, in T1, in T2, TResult>(Factory<TController> controllerFactory);
    public delegate AsyncAction<T1, T2, T3, TResult> AsyncActionFactory<in TController, in T1, in T2, in T3, TResult>(Factory<TController> controllerFactory);
    public delegate AsyncAction<T1, T2, T3, T4, TResult> AsyncActionFactory<in TController, in T1, in T2, in T3, in T4, TResult>(Factory<TController> controllerFactory);
    
    #endregion
}