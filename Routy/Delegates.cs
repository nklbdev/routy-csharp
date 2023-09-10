
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Routy;

// RequestHandler
public delegate TResult RequestHandler<in TContext, out TResult>(string httpMethod, Uri uri, TContext context);

// Functional value extractor
public delegate T ValueExtractor<in TContext, out T>(TContext context, NameValueCollection parameters);

// Value parser
public delegate TErr Parser<TRes, out TErr>(string source, out TRes result);

// Functional mutator
public delegate T Mutator<T>(T t);

#region Parameter collector fillers

public delegate ParameterCollector<TContext, TResult, TController> ParameterCollectorFiller<TContext, TResult, TController>(ParameterCollector<TContext, TResult, TController> parameterCollector);
public delegate ParameterCollector<TContext, TQ1, TResult, TController> ParameterCollectorFiller<TContext, TQ1, TResult, TController>(ParameterCollector<TContext, TResult, TController> parameterCollector);
public delegate ParameterCollector<TContext, TQ1, TQ2, TResult, TController> ParameterCollectorFiller<TContext, TQ1, TQ2, TResult, TController>(ParameterCollector<TContext, TResult, TController> parameterCollector);
public delegate ParameterCollector<TContext, TQ1, TQ2, TQ3, TResult, TController> ParameterCollectorFiller<TContext, TQ1, TQ2, TQ3, TResult, TController>(ParameterCollector<TContext, TResult, TController> parameterCollector);

#endregion

#region Middle handlers

public delegate TResult ResourceCollectorHandler<in TContext, out TResult>(string httpMethod, ICollection<string> urlSegments, NameValueCollection queryParameters, TContext context);
public delegate TResult ResourceCollectorHandler<in TContext, in TP1, out TResult>(string httpMethod, ICollection<string> urlSegments, NameValueCollection queryParameters, TContext context, TP1 tp1);
public delegate TResult ResourceCollectorHandler<in TContext, in TP1, in TP2, out TResult>(string httpMethod, ICollection<string> urlSegments, NameValueCollection queryParameters, TContext context, TP1 tp1, TP2 tp2);
public delegate TResult ResourceCollectorHandler<in TContext, in TP1, in TP2, in TP3, out TResult>(string httpMethod, ICollection<string> urlSegments, NameValueCollection queryParameters, TContext context, TP1 tp1, TP2 tp2, TP3 tp3);

public delegate TResult HttpMethodCollectorHandler<in TContext, out TResult>(string httpMethod, NameValueCollection query, TContext context);
public delegate TResult HttpMethodCollectorHandler<in TContext, in TP1, out TResult>(string httpMethod, NameValueCollection query, TContext context, TP1 tp1);
public delegate TResult HttpMethodCollectorHandler<in TContext, in TP1, in TP2, out TResult>(string httpMethod, NameValueCollection query, TContext context, TP1 tp1, TP2 tp2);
public delegate TResult HttpMethodCollectorHandler<in TContext, in TP1, in TP2, in TP3, out TResult>(string httpMethod, NameValueCollection query, TContext context, TP1 tp1, TP2 tp2, TP3 tp3);

public delegate TResult ParameterCollectorHandler<in TContext, out TResult>(NameValueCollection query, TContext context);
public delegate TResult ParameterCollectorHandler<in TContext, in TP1, out TResult>(NameValueCollection query, TContext context, TP1 tp1);
public delegate TResult ParameterCollectorHandler<in TContext, in TP1, in TP2, out TResult>(NameValueCollection query, TContext context, TP1 tp1, TP2 tp2);
public delegate TResult ParameterCollectorHandler<in TContext, in TP1, in TP2, in TP3, out TResult>(NameValueCollection query, TContext context, TP1 tp1, TP2 tp2, TP3 tp3);

#endregion
