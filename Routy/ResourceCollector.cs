using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Routy
{
    public class ResourceCollector<TContext, TResult, TController>
    {
        private readonly Factory<TController> _controllerFactory;
        private readonly Dictionary<string, ResourceCollectorHandler<TContext, TResult>> _namedResourceHandlers = new Dictionary<string, ResourceCollectorHandler<TContext, TResult>>();
        private readonly List<ResourceCollectorHandler<TContext, TResult>> _valuedResourceHandlers = new List<ResourceCollectorHandler<TContext, TResult>>();

        public ResourceCollector(Factory<TController> controllerFactory)
        {
            _controllerFactory = controllerFactory;
        }

        public ResourceCollector<TContext, TResult, TController> Named(string name,
            Mutator<HttpMethodCollector<TContext, TResult, TController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TResult, TController>> nestedResourceCollectorFiller = null
            ) => Named(name, _controllerFactory, httpMethodCollectorFiller, nestedResourceCollectorFiller);
        
        public ResourceCollector<TContext, TResult, TController> Named<TNewController>(string name,
            Factory<TNewController> controllerFactory,
            Mutator<HttpMethodCollector<TContext, TResult, TNewController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TResult, TNewController>> nestedResourceCollectorFiller = null
            )
        {
            if (httpMethodCollectorFiller == null) httpMethodCollectorFiller = x => x;
            if (nestedResourceCollectorFiller == null) nestedResourceCollectorFiller = x => x;
            _namedResourceHandlers[name] = new NamedResource<TContext, TResult>(
                httpMethodCollectorFiller(new HttpMethodCollector<TContext, TResult, TNewController>(controllerFactory)).Handle,
                nestedResourceCollectorFiller(new ResourceCollector<TContext, TResult, TNewController>(controllerFactory)).Handle).Handle;
            return this;
        }
        
        public ResourceCollector<TContext, TResult, TController> Valued<TValue>(Parser<TValue> parser,
            Mutator<HttpMethodCollector<TContext, TResult, TController, TValue>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TResult, TController, TValue>> nestedResourceCollectorFiller = null
            ) => Valued(parser, _controllerFactory, httpMethodCollectorFiller, nestedResourceCollectorFiller);

        public ResourceCollector<TContext, TResult, TController> Valued<TValue, TNewController>(Parser<TValue> parser,
            Factory<TNewController> controllerFactory,
            Mutator<HttpMethodCollector<TContext, TResult, TNewController, TValue>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TResult, TNewController, TValue>> nestedResourceCollectorFiller = null
            )
        {
            if (httpMethodCollectorFiller == null) httpMethodCollectorFiller = x => x;
            if (nestedResourceCollectorFiller == null) nestedResourceCollectorFiller = x => x;
            _valuedResourceHandlers.Add(new ValuedResource<TContext, TResult, TValue>(
                parser,
                httpMethodCollectorFiller(new HttpMethodCollector<TContext, TResult, TNewController, TValue>(controllerFactory)).Handle,
                nestedResourceCollectorFiller(new ResourceCollector<TContext, TResult, TNewController, TValue>(controllerFactory)).Handle).Handle);
            return this;
        }
        
        public async Task<TResult> Handle(string httpMethod, ICollection<string> urlSegments, NameValueCollection queryParameters, TContext context, CancellationToken ct)
        {
            if (!urlSegments.Any())
                throw new NotImplementedException("15");
            
            var urlHead = urlSegments.First();

            ResourceCollectorHandler<TContext, TResult> namedResourceHandler;
            if (_namedResourceHandlers.TryGetValue(urlHead, out namedResourceHandler))
                return await namedResourceHandler(httpMethod, urlSegments, queryParameters, context, ct);

            foreach (var valuedResourceHandler in _valuedResourceHandlers)
                try
                {
                    return await valuedResourceHandler(httpMethod, urlSegments, queryParameters, context, ct);
                }
                catch
                {
                    
                }
            
            throw new NotImplementedException("16");
        }
    }

    public class ResourceCollector<TContext, TResult, TController, TP1>
    {
        private readonly Factory<TController> _controllerFactory;
        private readonly Dictionary<string, ResourceCollectorHandler<TContext, TResult, TP1>> _namedResourceHandlers = new Dictionary<string, ResourceCollectorHandler<TContext, TResult, TP1>>();
        private readonly List<ResourceCollectorHandler<TContext, TResult, TP1>> _valuedResourceHandlers = new List<ResourceCollectorHandler<TContext, TResult, TP1>>();

        public ResourceCollector(Factory<TController> controllerFactory)
        {
            _controllerFactory = controllerFactory;
        }
        
        public async Task<TResult> Handle(string httpMethod, ICollection<string> urlSegments, NameValueCollection queryParameters, TContext context, TP1 p1, CancellationToken ct)
        {
            if (!urlSegments.Any())
                throw new NotImplementedException("17");
            
            var urlHead = urlSegments.First();

            ResourceCollectorHandler<TContext, TResult, TP1> namedResourceHandler;
            if (_namedResourceHandlers.TryGetValue(urlHead, out namedResourceHandler))
                return await namedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, ct);

            foreach (var valuedResourceHandler in _valuedResourceHandlers)
                try
                {
                    return await valuedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, ct);
                }
                catch
                {
                    
                }
            
            throw new NotImplementedException("18");
        }
    }
    
    public class ResourceCollector<TContext, TResult, TController, TP1, TP2>
    {
        private readonly Factory<TController> _controllerFactory;
        private readonly Dictionary<string, ResourceCollectorHandler<TContext, TResult, TP1, TP2>> _namedResourceHandlers = new Dictionary<string, ResourceCollectorHandler<TContext, TResult, TP1, TP2>>();
        private readonly List<ResourceCollectorHandler<TContext, TResult, TP1, TP2>> _valuedResourceHandlers = new List<ResourceCollectorHandler<TContext, TResult, TP1, TP2>>();

        public ResourceCollector(Factory<TController> controllerFactory)
        {
            _controllerFactory = controllerFactory;
        }
        
        public async Task<TResult> Handle(string httpMethod, ICollection<string> urlSegments, NameValueCollection queryParameters, TContext context, TP1 p1, TP2 p2, CancellationToken ct)
        {
            if (!urlSegments.Any())
                throw new NotImplementedException("19");
            
            var urlHead = urlSegments.First();

            ResourceCollectorHandler<TContext, TResult, TP1, TP2> namedResourceHandler;
            if (_namedResourceHandlers.TryGetValue(urlHead, out namedResourceHandler))
                return await namedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, p2, ct);

            foreach (var valuedResourceHandler in _valuedResourceHandlers)
                try
                {
                    return await valuedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, p2, ct);
                }
                catch
                {
                    
                }
            
            throw new NotImplementedException("20");
        }
    }
}
