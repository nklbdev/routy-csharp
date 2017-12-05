using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WebExperiment
{
    public class QueryDescriber<TRequest, TResponse, TController>
    {
        private readonly Func<TRequest, TController> _controllerFactory;
        private readonly List<Func<TRequest, NameValueCollection, CancellationToken, Task<Responder<TResponse>>>> _handlers = new List<Func<TRequest, NameValueCollection, CancellationToken, Task<Responder<TResponse>>>>();

        public QueryDescriber(Func<TRequest, TController> controllerFactory)
        {
            _controllerFactory = controllerFactory;
        }
        
        public QueryDescriber<TRequest, TResponse, TController> Handle(Func<ParameterCollector, ParameterCollector> coll, Func<ControllerFactorySelector<TRequest, TResponse, TController>, Func<TRequest, CancellationToken, Task<Responder<TResponse>>>> c)
        {
            _handlers.Add((r, qs, ct) => c(new ControllerFactorySelector<TRequest, TResponse, TController>(_controllerFactory))(r, ct));
            return this;
        }

        public QueryDescriber<TRequest, TResponse, TController> Handle<TQ1>(Func<ParameterCollector, ParameterCollector<TQ1>> coll, Func<ControllerFactorySelector<TRequest, TResponse, TController, TQ1>, Func<TRequest, TQ1, CancellationToken, Task<Responder<TResponse>>>> c)
        {
            var cl = coll(new ParameterCollector());
            _handlers.Add((r, u, ct) => c(new ControllerFactorySelector<TRequest, TResponse, TController, TQ1>(_controllerFactory))(r, cl.P1(u), ct));
            return this;
        }
        
        public QueryDescriber<TRequest, TResponse, TController> Handle<TQ1, TQ2>(Func<ParameterCollector, ParameterCollector<TQ1, TQ2>> coll, Func<ControllerFactorySelector<TRequest, TResponse, TController, TQ1, TQ2>, Func<TRequest, TQ1, TQ2, CancellationToken, Task<Responder<TResponse>>>> c)
        {
            var cl = coll(new ParameterCollector());
            _handlers.Add((r, u, ct) => c(new ControllerFactorySelector<TRequest, TResponse, TController, TQ1, TQ2>(_controllerFactory))(r, cl.P1(u), cl.P2(u), ct));
            return this;
        }
        
        public Func<TRequest, Uri, CancellationToken, Task<Responder<TResponse>>> A() => (r, qs, ct) =>
        {
            foreach (var some in _handlers)
            {
                try
                {
                    return some(r, HttpUtility.ParseQueryString(qs.Query), ct);
                }
                catch
                {
                }
            }
            throw new NotImplementedException();
        };
    }

    public class QueryDescriber<TRequest, TResponse, TController, TP1>
    {
        private readonly Func<TRequest, TController> _controllerFactory;
        private readonly List<Func<TRequest, NameValueCollection, TP1, CancellationToken, Task<Responder<TResponse>>>> _handlers = new List<Func<TRequest, NameValueCollection, TP1, CancellationToken, Task<Responder<TResponse>>>>();

        public QueryDescriber(Func<TRequest, TController> controllerFactory)
        {
            _controllerFactory = controllerFactory;
        }
        
        public QueryDescriber<TRequest, TResponse, TController, TP1> Handle(Func<ParameterCollector, ParameterCollector> coll, Func<ControllerFactorySelector<TRequest, TResponse, TController, TP1>, Func<TRequest, TP1, CancellationToken, Task<Responder<TResponse>>>> c)
        {
            _handlers.Add((r, qs, p1, ct) => c(new ControllerFactorySelector<TRequest, TResponse, TController, TP1>(_controllerFactory))(r, p1, ct));
            return this;
        }

        public QueryDescriber<TRequest, TResponse, TController, TP1> Handle<TQ1>(Func<ParameterCollector, ParameterCollector<TQ1>> coll, Func<ControllerFactorySelector<TRequest, TResponse, TController, TP1, TQ1>, Func<TRequest, TP1, TQ1, CancellationToken, Task<Responder<TResponse>>>> c)
        {
            var cl = coll(new ParameterCollector());
            _handlers.Add((r, qs, p1, ct) => c(new ControllerFactorySelector<TRequest, TResponse, TController, TP1, TQ1>(_controllerFactory))(r, p1, cl.P1(qs), ct));
            return this;
        }
        
        public QueryDescriber<TRequest, TResponse, TController, TP1> Handle<TQ1, TQ2>(Func<ParameterCollector, ParameterCollector<TQ1, TQ2>> coll, Func<ControllerFactorySelector<TRequest, TResponse, TController, TP1, TQ1, TQ2>, Func<TRequest, TP1, TQ1, TQ2, CancellationToken, Task<Responder<TResponse>>>> c)
        {
            var cl = coll(new ParameterCollector());
            _handlers.Add((r, qs, p1, ct) => c(new ControllerFactorySelector<TRequest, TResponse, TController, TP1, TQ1, TQ2>(_controllerFactory))(r, p1, cl.P1(qs), cl.P2(qs), ct));
            return this;
        }
        
        public Func<TRequest, Uri, TP1, CancellationToken, Task<Responder<TResponse>>> A() => (r, qs, p1, ct) =>
        {
            foreach (var some in _handlers)
            {
                try
                {
                    return some(r, HttpUtility.ParseQueryString(qs.Query), p1, ct);
                }
                catch
                {
                }
            }
            throw new NotImplementedException();
        };
    }
    
    public class QueryDescriber<TRequest, TResponse, TController, TP1, TP2>
    {
        private readonly Func<TRequest, TController> _controllerFactory;
        private readonly List<Func<TRequest, NameValueCollection, TP1, TP2, CancellationToken, Task<Responder<TResponse>>>> _handlers = new List<Func<TRequest, NameValueCollection, TP1, TP2, CancellationToken, Task<Responder<TResponse>>>>();

        public QueryDescriber(Func<TRequest, TController> controllerFactory)
        {
            _controllerFactory = controllerFactory;
        }
        
        public QueryDescriber<TRequest, TResponse, TController, TP1, TP2> Handle(Func<ParameterCollector, ParameterCollector> coll, Func<ControllerFactorySelector<TRequest, TResponse, TController, TP1, TP2>, Func<TRequest, TP1, TP2, CancellationToken, Task<Responder<TResponse>>>> c)
        {
            _handlers.Add((r, qs, p1, p2, ct) => c(new ControllerFactorySelector<TRequest, TResponse, TController, TP1, TP2>(_controllerFactory))(r, p1, p2, ct));
            return this;
        }

        public QueryDescriber<TRequest, TResponse, TController, TP1, TP2> Handle<TQ1>(Func<ParameterCollector, ParameterCollector<TQ1>> coll, Func<ControllerFactorySelector<TRequest, TResponse, TController, TP1, TP2, TQ1>, Func<TRequest, TP1, TP2, TQ1, CancellationToken, Task<Responder<TResponse>>>> c)
        {
            var cl = coll(new ParameterCollector());
            _handlers.Add((r, qs, p1, p2, ct) => c(new ControllerFactorySelector<TRequest, TResponse, TController, TP1, TP2, TQ1>(_controllerFactory))(r, p1, p2, cl.P1(qs), ct));
            return this;
        }
        
        public Func<TRequest, Uri, TP1, TP2, CancellationToken, Task<Responder<TResponse>>> A() => (r, qs, p1, p2, ct) =>
        {
            foreach (var some in _handlers)
            {
                try
                {
                    return some(r, HttpUtility.ParseQueryString(qs.Query), p1, p2, ct);
                }
                catch
                {
                }
            }
            throw new NotImplementedException();
        };
    }
}
