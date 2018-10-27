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
        private readonly Func<TController> _controllerProvider;
        private readonly Dictionary<string, AsyncResourceCollectorHandler<TContext, TResult>> _namedResourceHandlers = new Dictionary<string, AsyncResourceCollectorHandler<TContext, TResult>>();
        private readonly List<AsyncResourceCollectorHandler<TContext, TResult>> _valuedResourceHandlers = new List<AsyncResourceCollectorHandler<TContext, TResult>>();

        public ResourceCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        public ResourceCollector<TContext, TResult, TController> Named(string name,
            Mutator<HttpMethodCollector<TContext, TResult, TController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TResult, TController>> nestedResourceCollectorFiller = null
            ) => Named(name, _controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);
        
        public ResourceCollector<TContext, TResult, TController> Named<TNewController>(string name,
            Func<TNewController> controllerProvider,
            Mutator<HttpMethodCollector<TContext, TResult, TNewController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TResult, TNewController>> nestedResourceCollectorFiller = null
            )
        {
            if (httpMethodCollectorFiller == null) httpMethodCollectorFiller = x => x;
            if (nestedResourceCollectorFiller == null) nestedResourceCollectorFiller = x => x;
            _namedResourceHandlers[name] = new NamedResource<TContext, TResult>(
                httpMethodCollectorFiller(new HttpMethodCollector<TContext, TResult, TNewController>(controllerProvider)).Handle,
                nestedResourceCollectorFiller(new ResourceCollector<TContext, TResult, TNewController>(controllerProvider)).HandleAsync).HandleAsync;
            return this;
        }
        
        public ResourceCollector<TContext, TResult, TController> Valued<TValue>(Func<string, TValue> parser,
            Mutator<HttpMethodCollector<TContext, TValue, TResult, TController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TValue, TResult, TController>> nestedResourceCollectorFiller = null
            ) => Valued(parser, _controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);

        public ResourceCollector<TContext, TResult, TController> Valued<TValue, TNewController>(Func<string, TValue> parser,
            Func<TNewController> controllerProvider,
            Mutator<HttpMethodCollector<TContext, TValue, TResult, TNewController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TValue, TResult, TNewController>> nestedResourceCollectorFiller = null
            )
        {
            if (httpMethodCollectorFiller == null) httpMethodCollectorFiller = x => x;
            if (nestedResourceCollectorFiller == null) nestedResourceCollectorFiller = x => x;
            _valuedResourceHandlers.Add(new ValuedResource<TContext, TValue, TResult>(
                parser,
                httpMethodCollectorFiller(new HttpMethodCollector<TContext, TValue, TResult, TNewController>(controllerProvider)).Handle,
                nestedResourceCollectorFiller(new ResourceCollector<TContext, TValue, TResult, TNewController>(controllerProvider)).HandleAsync).Handle);
            return this;
        }

        public async Task<TResult> HandleAsync(string httpMethod, ICollection<string> urlSegments, NameValueCollection queryParameters, TContext context, CancellationToken ct)
        {
            if (!urlSegments.Any())
                throw new NotImplementedException("15");
            
            var urlHead = urlSegments.First();

            if (_namedResourceHandlers.TryGetValue(urlHead, out var namedResourceHandler))
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

    public class ResourceCollector<TContext, TP1, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly Dictionary<string, AsyncResourceCollectorHandler<TContext, TP1, TResult>> _namedResourceHandlers = new Dictionary<string, AsyncResourceCollectorHandler<TContext, TP1, TResult>>();
        private readonly List<AsyncResourceCollectorHandler<TContext, TP1, TResult>> _valuedResourceHandlers = new List<AsyncResourceCollectorHandler<TContext, TP1, TResult>>();

        public ResourceCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        public ResourceCollector<TContext, TP1, TResult, TController> Named(string name,
            Mutator<HttpMethodCollector<TContext, TP1, TResult, TController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TResult, TController>> nestedResourceCollectorFiller = null
            ) => Named(name, _controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);
        
        public ResourceCollector<TContext, TP1, TResult, TController> Named<TNewController>(string name,
            Func<TNewController> controllerProvider,
            Mutator<HttpMethodCollector<TContext, TP1, TResult, TNewController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TResult, TNewController>> nestedResourceCollectorFiller = null
            )
        {
            if (httpMethodCollectorFiller == null) httpMethodCollectorFiller = x => x;
            if (nestedResourceCollectorFiller == null) nestedResourceCollectorFiller = x => x;
            _namedResourceHandlers[name] = new NamedResource<TContext, TP1, TResult>(
                httpMethodCollectorFiller(new HttpMethodCollector<TContext, TP1, TResult, TNewController>(controllerProvider)).Handle,
                nestedResourceCollectorFiller(new ResourceCollector<TContext, TP1, TResult, TNewController>(controllerProvider)).HandleAsync).HandleAsync;
            return this;
        }
        
        public ResourceCollector<TContext, TP1, TResult, TController> Valued<TValue>(Func<string, TValue> parser,
            Mutator<HttpMethodCollector<TContext, TP1, TValue, TResult, TController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TValue, TResult, TController>> nestedResourceCollectorFiller = null
            ) => Valued(parser, _controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);

        public ResourceCollector<TContext, TP1, TResult, TController> Valued<TValue, TNewController>(Func<string, TValue> parser,
            Func<TNewController> controllerProvider,
            Mutator<HttpMethodCollector<TContext, TP1, TValue, TResult, TNewController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TValue, TResult, TNewController>> nestedResourceCollectorFiller = null
            )
        {
            if (httpMethodCollectorFiller == null) httpMethodCollectorFiller = x => x;
            if (nestedResourceCollectorFiller == null) nestedResourceCollectorFiller = x => x;
            _valuedResourceHandlers.Add(new ValuedResource<TContext, TP1, TValue, TResult>(
                parser,
                httpMethodCollectorFiller(new HttpMethodCollector<TContext, TP1, TValue, TResult, TNewController>(controllerProvider)).Handle,
                nestedResourceCollectorFiller(new ResourceCollector<TContext, TP1, TValue, TResult, TNewController>(controllerProvider)).HandleAsync).Handle);
            return this;
        }

        public async Task<TResult> HandleAsync(string httpMethod, ICollection<string> urlSegments, NameValueCollection queryParameters, TContext context, TP1 p1, CancellationToken ct)
        {
            if (!urlSegments.Any())
                throw new NotImplementedException("15");
            
            var urlHead = urlSegments.First();

            if (_namedResourceHandlers.TryGetValue(urlHead, out var namedResourceHandler))
                return await namedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, ct);

            foreach (var valuedResourceHandler in _valuedResourceHandlers)
                try
                {
                    return await valuedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, ct);
                }
                catch
                {
                    
                }
            
            throw new NotImplementedException("16");
        }
    }

    public class ResourceCollector<TContext, TP1, TP2, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly Dictionary<string, AsyncResourceCollectorHandler<TContext, TP1, TP2, TResult>> _namedResourceHandlers = new Dictionary<string, AsyncResourceCollectorHandler<TContext, TP1, TP2, TResult>>();
        private readonly List<AsyncResourceCollectorHandler<TContext, TP1, TP2, TResult>> _valuedResourceHandlers = new List<AsyncResourceCollectorHandler<TContext, TP1, TP2, TResult>>();

        public ResourceCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        public ResourceCollector<TContext, TP1, TP2, TResult, TController> Named(string name,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TResult, TController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TResult, TController>> nestedResourceCollectorFiller = null
            ) => Named(name, _controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);
        
        public ResourceCollector<TContext, TP1, TP2, TResult, TController> Named<TNewController>(string name,
            Func<TNewController> controllerProvider,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TResult, TNewController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TResult, TNewController>> nestedResourceCollectorFiller = null
            )
        {
            if (httpMethodCollectorFiller == null) httpMethodCollectorFiller = x => x;
            if (nestedResourceCollectorFiller == null) nestedResourceCollectorFiller = x => x;
            _namedResourceHandlers[name] = new NamedResource<TContext, TP1, TP2, TResult>(
                httpMethodCollectorFiller(new HttpMethodCollector<TContext, TP1, TP2, TResult, TNewController>(controllerProvider)).Handle,
                nestedResourceCollectorFiller(new ResourceCollector<TContext, TP1, TP2, TResult, TNewController>(controllerProvider)).HandleAsync).HandleAsync;
            return this;
        }
        
        public ResourceCollector<TContext, TP1, TP2, TResult, TController> Valued<TValue>(Func<string, TValue> parser,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TValue, TResult, TController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TValue, TResult, TController>> nestedResourceCollectorFiller = null
            ) => Valued(parser, _controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);

        public ResourceCollector<TContext, TP1, TP2, TResult, TController> Valued<TValue, TNewController>(Func<string, TValue> parser,
            Func<TNewController> controllerProvider,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TValue, TResult, TNewController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TValue, TResult, TNewController>> nestedResourceCollectorFiller = null
            )
        {
            if (httpMethodCollectorFiller == null) httpMethodCollectorFiller = x => x;
            if (nestedResourceCollectorFiller == null) nestedResourceCollectorFiller = x => x;
            _valuedResourceHandlers.Add(new ValuedResource<TContext, TP1, TP2, TValue, TResult>(
                parser,
                httpMethodCollectorFiller(new HttpMethodCollector<TContext, TP1, TP2, TValue, TResult, TNewController>(controllerProvider)).Handle,
                nestedResourceCollectorFiller(new ResourceCollector<TContext, TP1, TP2, TValue, TResult, TNewController>(controllerProvider)).HandleAsync).Handle);
            return this;
        }

        public async Task<TResult> HandleAsync(string httpMethod, ICollection<string> urlSegments, NameValueCollection queryParameters, TContext context, TP1 p1, TP2 p2, CancellationToken ct)
        {
            if (!urlSegments.Any())
                throw new NotImplementedException("15");
            
            var urlHead = urlSegments.First();

            if (_namedResourceHandlers.TryGetValue(urlHead, out var namedResourceHandler))
                return await namedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, p2, ct);

            foreach (var valuedResourceHandler in _valuedResourceHandlers)
                try
                {
                    return await valuedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, p2, ct);
                }
                catch
                {
                    
                }
            
            throw new NotImplementedException("16");
        }
    }

    public class ResourceCollector<TContext, TP1, TP2, TP3, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly Dictionary<string, AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TResult>> _namedResourceHandlers = new Dictionary<string, AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TResult>>();
        private readonly List<AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TResult>> _valuedResourceHandlers = new List<AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TResult>>();

        public ResourceCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        public ResourceCollector<TContext, TP1, TP2, TP3, TResult, TController> Named(string name,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TResult, TController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TResult, TController>> nestedResourceCollectorFiller = null
            ) => Named(name, _controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);
        
        public ResourceCollector<TContext, TP1, TP2, TP3, TResult, TController> Named<TNewController>(string name,
            Func<TNewController> controllerProvider,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TResult, TNewController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TResult, TNewController>> nestedResourceCollectorFiller = null
            )
        {
            if (httpMethodCollectorFiller == null) httpMethodCollectorFiller = x => x;
            if (nestedResourceCollectorFiller == null) nestedResourceCollectorFiller = x => x;
            _namedResourceHandlers[name] = new NamedResource<TContext, TP1, TP2, TP3, TResult>(
                httpMethodCollectorFiller(new HttpMethodCollector<TContext, TP1, TP2, TP3, TResult, TNewController>(controllerProvider)).Handle,
                nestedResourceCollectorFiller(new ResourceCollector<TContext, TP1, TP2, TP3, TResult, TNewController>(controllerProvider)).HandleAsync).HandleAsync;
            return this;
        }
        
        public ResourceCollector<TContext, TP1, TP2, TP3, TResult, TController> Valued<TValue>(Func<string, TValue> parser,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TValue, TResult, TController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TValue, TResult, TController>> nestedResourceCollectorFiller = null
            ) => Valued(parser, _controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);

        public ResourceCollector<TContext, TP1, TP2, TP3, TResult, TController> Valued<TValue, TNewController>(Func<string, TValue> parser,
            Func<TNewController> controllerProvider,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TValue, TResult, TNewController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TValue, TResult, TNewController>> nestedResourceCollectorFiller = null
            )
        {
            if (httpMethodCollectorFiller == null) httpMethodCollectorFiller = x => x;
            if (nestedResourceCollectorFiller == null) nestedResourceCollectorFiller = x => x;
            _valuedResourceHandlers.Add(new ValuedResource<TContext, TP1, TP2, TP3, TValue, TResult>(
                parser,
                httpMethodCollectorFiller(new HttpMethodCollector<TContext, TP1, TP2, TP3, TValue, TResult, TNewController>(controllerProvider)).Handle,
                nestedResourceCollectorFiller(new ResourceCollector<TContext, TP1, TP2, TP3, TValue, TResult, TNewController>(controllerProvider)).HandleAsync).Handle);
            return this;
        }

        public async Task<TResult> HandleAsync(string httpMethod, ICollection<string> urlSegments, NameValueCollection queryParameters, TContext context, TP1 p1, TP2 p2, TP3 p3, CancellationToken ct)
        {
            if (!urlSegments.Any())
                throw new NotImplementedException("15");
            
            var urlHead = urlSegments.First();

            if (_namedResourceHandlers.TryGetValue(urlHead, out var namedResourceHandler))
                return await namedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, p2, p3, ct);

            foreach (var valuedResourceHandler in _valuedResourceHandlers)
                try
                {
                    return await valuedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, p2, p3, ct);
                }
                catch
                {
                    
                }
            
            throw new NotImplementedException("16");
        }
    }

    public class ResourceCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly Dictionary<string, AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult>> _namedResourceHandlers = new Dictionary<string, AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult>>();
        private readonly List<AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult>> _valuedResourceHandlers = new List<AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult>>();

        public ResourceCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Named(string name,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController>> nestedResourceCollectorFiller = null
            ) => Named(name, _controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);
        
        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Named<TNewController>(string name,
            Func<TNewController> controllerProvider,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TResult, TNewController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TResult, TNewController>> nestedResourceCollectorFiller = null
            )
        {
            if (httpMethodCollectorFiller == null) httpMethodCollectorFiller = x => x;
            if (nestedResourceCollectorFiller == null) nestedResourceCollectorFiller = x => x;
            _namedResourceHandlers[name] = new NamedResource<TContext, TP1, TP2, TP3, TP4, TResult>(
                httpMethodCollectorFiller(new HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TResult, TNewController>(controllerProvider)).Handle,
                nestedResourceCollectorFiller(new ResourceCollector<TContext, TP1, TP2, TP3, TP4, TResult, TNewController>(controllerProvider)).HandleAsync).HandleAsync;
            return this;
        }
        
        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Valued<TValue>(Func<string, TValue> parser,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TValue, TResult, TController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TValue, TResult, TController>> nestedResourceCollectorFiller = null
            ) => Valued(parser, _controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);

        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Valued<TValue, TNewController>(Func<string, TValue> parser,
            Func<TNewController> controllerProvider,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TValue, TResult, TNewController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TValue, TResult, TNewController>> nestedResourceCollectorFiller = null
            )
        {
            if (httpMethodCollectorFiller == null) httpMethodCollectorFiller = x => x;
            if (nestedResourceCollectorFiller == null) nestedResourceCollectorFiller = x => x;
            _valuedResourceHandlers.Add(new ValuedResource<TContext, TP1, TP2, TP3, TP4, TValue, TResult>(
                parser,
                httpMethodCollectorFiller(new HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TValue, TResult, TNewController>(controllerProvider)).Handle,
                nestedResourceCollectorFiller(new ResourceCollector<TContext, TP1, TP2, TP3, TP4, TValue, TResult, TNewController>(controllerProvider)).HandleAsync).Handle);
            return this;
        }

        public async Task<TResult> HandleAsync(string httpMethod, ICollection<string> urlSegments, NameValueCollection queryParameters, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, CancellationToken ct)
        {
            if (!urlSegments.Any())
                throw new NotImplementedException("15");
            
            var urlHead = urlSegments.First();

            if (_namedResourceHandlers.TryGetValue(urlHead, out var namedResourceHandler))
                return await namedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, p2, p3, p4, ct);

            foreach (var valuedResourceHandler in _valuedResourceHandlers)
                try
                {
                    return await valuedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, p2, p3, p4, ct);
                }
                catch
                {
                    
                }
            
            throw new NotImplementedException("16");
        }
    }

    public class ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly Dictionary<string, AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult>> _namedResourceHandlers = new Dictionary<string, AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult>>();
        private readonly List<AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult>> _valuedResourceHandlers = new List<AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult>>();

        public ResourceCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Named(string name,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController>> nestedResourceCollectorFiller = null
            ) => Named(name, _controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);
        
        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Named<TNewController>(string name,
            Func<TNewController> controllerProvider,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TNewController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TNewController>> nestedResourceCollectorFiller = null
            )
        {
            if (httpMethodCollectorFiller == null) httpMethodCollectorFiller = x => x;
            if (nestedResourceCollectorFiller == null) nestedResourceCollectorFiller = x => x;
            _namedResourceHandlers[name] = new NamedResource<TContext, TP1, TP2, TP3, TP4, TP5, TResult>(
                httpMethodCollectorFiller(new HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TNewController>(controllerProvider)).Handle,
                nestedResourceCollectorFiller(new ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TNewController>(controllerProvider)).HandleAsync).HandleAsync;
            return this;
        }
        
        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Valued<TValue>(Func<string, TValue> parser,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TValue, TResult, TController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TValue, TResult, TController>> nestedResourceCollectorFiller = null
            ) => Valued(parser, _controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);

        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Valued<TValue, TNewController>(Func<string, TValue> parser,
            Func<TNewController> controllerProvider,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TValue, TResult, TNewController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TValue, TResult, TNewController>> nestedResourceCollectorFiller = null
            )
        {
            if (httpMethodCollectorFiller == null) httpMethodCollectorFiller = x => x;
            if (nestedResourceCollectorFiller == null) nestedResourceCollectorFiller = x => x;
            _valuedResourceHandlers.Add(new ValuedResource<TContext, TP1, TP2, TP3, TP4, TP5, TValue, TResult>(
                parser,
                httpMethodCollectorFiller(new HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TValue, TResult, TNewController>(controllerProvider)).Handle,
                nestedResourceCollectorFiller(new ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TValue, TResult, TNewController>(controllerProvider)).HandleAsync).Handle);
            return this;
        }

        public async Task<TResult> HandleAsync(string httpMethod, ICollection<string> urlSegments, NameValueCollection queryParameters, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, CancellationToken ct)
        {
            if (!urlSegments.Any())
                throw new NotImplementedException("15");
            
            var urlHead = urlSegments.First();

            if (_namedResourceHandlers.TryGetValue(urlHead, out var namedResourceHandler))
                return await namedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, p2, p3, p4, p5, ct);

            foreach (var valuedResourceHandler in _valuedResourceHandlers)
                try
                {
                    return await valuedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, p2, p3, p4, p5, ct);
                }
                catch
                {
                    
                }
            
            throw new NotImplementedException("16");
        }
    }

    public class ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly Dictionary<string, AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult>> _namedResourceHandlers = new Dictionary<string, AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult>>();
        private readonly List<AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult>> _valuedResourceHandlers = new List<AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult>>();

        public ResourceCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Named(string name,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController>> nestedResourceCollectorFiller = null
            ) => Named(name, _controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);
        
        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Named<TNewController>(string name,
            Func<TNewController> controllerProvider,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TNewController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TNewController>> nestedResourceCollectorFiller = null
            )
        {
            if (httpMethodCollectorFiller == null) httpMethodCollectorFiller = x => x;
            if (nestedResourceCollectorFiller == null) nestedResourceCollectorFiller = x => x;
            _namedResourceHandlers[name] = new NamedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult>(
                httpMethodCollectorFiller(new HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TNewController>(controllerProvider)).Handle,
                nestedResourceCollectorFiller(new ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TNewController>(controllerProvider)).HandleAsync).HandleAsync;
            return this;
        }
        
        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Valued<TValue>(Func<string, TValue> parser,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TValue, TResult, TController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TValue, TResult, TController>> nestedResourceCollectorFiller = null
            ) => Valued(parser, _controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);

        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Valued<TValue, TNewController>(Func<string, TValue> parser,
            Func<TNewController> controllerProvider,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TValue, TResult, TNewController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TValue, TResult, TNewController>> nestedResourceCollectorFiller = null
            )
        {
            if (httpMethodCollectorFiller == null) httpMethodCollectorFiller = x => x;
            if (nestedResourceCollectorFiller == null) nestedResourceCollectorFiller = x => x;
            _valuedResourceHandlers.Add(new ValuedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TValue, TResult>(
                parser,
                httpMethodCollectorFiller(new HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TValue, TResult, TNewController>(controllerProvider)).Handle,
                nestedResourceCollectorFiller(new ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TValue, TResult, TNewController>(controllerProvider)).HandleAsync).Handle);
            return this;
        }

        public async Task<TResult> HandleAsync(string httpMethod, ICollection<string> urlSegments, NameValueCollection queryParameters, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, CancellationToken ct)
        {
            if (!urlSegments.Any())
                throw new NotImplementedException("15");
            
            var urlHead = urlSegments.First();

            if (_namedResourceHandlers.TryGetValue(urlHead, out var namedResourceHandler))
                return await namedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, p2, p3, p4, p5, p6, ct);

            foreach (var valuedResourceHandler in _valuedResourceHandlers)
                try
                {
                    return await valuedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, p2, p3, p4, p5, p6, ct);
                }
                catch
                {
                    
                }
            
            throw new NotImplementedException("16");
        }
    }

    public class ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly Dictionary<string, AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult>> _namedResourceHandlers = new Dictionary<string, AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult>>();
        private readonly List<AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult>> _valuedResourceHandlers = new List<AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult>>();

        public ResourceCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Named(string name,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController>> nestedResourceCollectorFiller = null
            ) => Named(name, _controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);
        
        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Named<TNewController>(string name,
            Func<TNewController> controllerProvider,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TNewController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TNewController>> nestedResourceCollectorFiller = null
            )
        {
            if (httpMethodCollectorFiller == null) httpMethodCollectorFiller = x => x;
            if (nestedResourceCollectorFiller == null) nestedResourceCollectorFiller = x => x;
            _namedResourceHandlers[name] = new NamedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult>(
                httpMethodCollectorFiller(new HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TNewController>(controllerProvider)).Handle,
                nestedResourceCollectorFiller(new ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TNewController>(controllerProvider)).HandleAsync).HandleAsync;
            return this;
        }
        
        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Valued<TValue>(Func<string, TValue> parser,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TValue, TResult, TController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TValue, TResult, TController>> nestedResourceCollectorFiller = null
            ) => Valued(parser, _controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);

        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Valued<TValue, TNewController>(Func<string, TValue> parser,
            Func<TNewController> controllerProvider,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TValue, TResult, TNewController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TValue, TResult, TNewController>> nestedResourceCollectorFiller = null
            )
        {
            if (httpMethodCollectorFiller == null) httpMethodCollectorFiller = x => x;
            if (nestedResourceCollectorFiller == null) nestedResourceCollectorFiller = x => x;
            _valuedResourceHandlers.Add(new ValuedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TValue, TResult>(
                parser,
                httpMethodCollectorFiller(new HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TValue, TResult, TNewController>(controllerProvider)).Handle,
                nestedResourceCollectorFiller(new ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TValue, TResult, TNewController>(controllerProvider)).HandleAsync).Handle);
            return this;
        }

        public async Task<TResult> HandleAsync(string httpMethod, ICollection<string> urlSegments, NameValueCollection queryParameters, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, CancellationToken ct)
        {
            if (!urlSegments.Any())
                throw new NotImplementedException("15");
            
            var urlHead = urlSegments.First();

            if (_namedResourceHandlers.TryGetValue(urlHead, out var namedResourceHandler))
                return await namedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, p2, p3, p4, p5, p6, p7, ct);

            foreach (var valuedResourceHandler in _valuedResourceHandlers)
                try
                {
                    return await valuedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, p2, p3, p4, p5, p6, p7, ct);
                }
                catch
                {
                    
                }
            
            throw new NotImplementedException("16");
        }
    }

    public class ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly Dictionary<string, AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult>> _namedResourceHandlers = new Dictionary<string, AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult>>();
        private readonly List<AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult>> _valuedResourceHandlers = new List<AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult>>();

        public ResourceCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Named(string name,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController>> nestedResourceCollectorFiller = null
            ) => Named(name, _controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);
        
        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Named<TNewController>(string name,
            Func<TNewController> controllerProvider,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TNewController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TNewController>> nestedResourceCollectorFiller = null
            )
        {
            if (httpMethodCollectorFiller == null) httpMethodCollectorFiller = x => x;
            if (nestedResourceCollectorFiller == null) nestedResourceCollectorFiller = x => x;
            _namedResourceHandlers[name] = new NamedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult>(
                httpMethodCollectorFiller(new HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TNewController>(controllerProvider)).Handle,
                nestedResourceCollectorFiller(new ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TNewController>(controllerProvider)).HandleAsync).HandleAsync;
            return this;
        }
        
        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Valued<TValue>(Func<string, TValue> parser,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TValue, TResult, TController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TValue, TResult, TController>> nestedResourceCollectorFiller = null
            ) => Valued(parser, _controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);

        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Valued<TValue, TNewController>(Func<string, TValue> parser,
            Func<TNewController> controllerProvider,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TValue, TResult, TNewController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TValue, TResult, TNewController>> nestedResourceCollectorFiller = null
            )
        {
            if (httpMethodCollectorFiller == null) httpMethodCollectorFiller = x => x;
            if (nestedResourceCollectorFiller == null) nestedResourceCollectorFiller = x => x;
            _valuedResourceHandlers.Add(new ValuedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TValue, TResult>(
                parser,
                httpMethodCollectorFiller(new HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TValue, TResult, TNewController>(controllerProvider)).Handle,
                nestedResourceCollectorFiller(new ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TValue, TResult, TNewController>(controllerProvider)).HandleAsync).Handle);
            return this;
        }

        public async Task<TResult> HandleAsync(string httpMethod, ICollection<string> urlSegments, NameValueCollection queryParameters, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, CancellationToken ct)
        {
            if (!urlSegments.Any())
                throw new NotImplementedException("15");
            
            var urlHead = urlSegments.First();

            if (_namedResourceHandlers.TryGetValue(urlHead, out var namedResourceHandler))
                return await namedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, p2, p3, p4, p5, p6, p7, p8, ct);

            foreach (var valuedResourceHandler in _valuedResourceHandlers)
                try
                {
                    return await valuedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, p2, p3, p4, p5, p6, p7, p8, ct);
                }
                catch
                {
                    
                }
            
            throw new NotImplementedException("16");
        }
    }

    public class ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly Dictionary<string, AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult>> _namedResourceHandlers = new Dictionary<string, AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult>>();
        private readonly List<AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult>> _valuedResourceHandlers = new List<AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult>>();

        public ResourceCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Named(string name,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController>> nestedResourceCollectorFiller = null
            ) => Named(name, _controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);
        
        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Named<TNewController>(string name,
            Func<TNewController> controllerProvider,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TNewController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TNewController>> nestedResourceCollectorFiller = null
            )
        {
            if (httpMethodCollectorFiller == null) httpMethodCollectorFiller = x => x;
            if (nestedResourceCollectorFiller == null) nestedResourceCollectorFiller = x => x;
            _namedResourceHandlers[name] = new NamedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult>(
                httpMethodCollectorFiller(new HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TNewController>(controllerProvider)).Handle,
                nestedResourceCollectorFiller(new ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TNewController>(controllerProvider)).HandleAsync).HandleAsync;
            return this;
        }
        
        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Valued<TValue>(Func<string, TValue> parser,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TValue, TResult, TController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TValue, TResult, TController>> nestedResourceCollectorFiller = null
            ) => Valued(parser, _controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);

        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Valued<TValue, TNewController>(Func<string, TValue> parser,
            Func<TNewController> controllerProvider,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TValue, TResult, TNewController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TValue, TResult, TNewController>> nestedResourceCollectorFiller = null
            )
        {
            if (httpMethodCollectorFiller == null) httpMethodCollectorFiller = x => x;
            if (nestedResourceCollectorFiller == null) nestedResourceCollectorFiller = x => x;
            _valuedResourceHandlers.Add(new ValuedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TValue, TResult>(
                parser,
                httpMethodCollectorFiller(new HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TValue, TResult, TNewController>(controllerProvider)).Handle,
                nestedResourceCollectorFiller(new ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TValue, TResult, TNewController>(controllerProvider)).HandleAsync).Handle);
            return this;
        }

        public async Task<TResult> HandleAsync(string httpMethod, ICollection<string> urlSegments, NameValueCollection queryParameters, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, CancellationToken ct)
        {
            if (!urlSegments.Any())
                throw new NotImplementedException("15");
            
            var urlHead = urlSegments.First();

            if (_namedResourceHandlers.TryGetValue(urlHead, out var namedResourceHandler))
                return await namedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, ct);

            foreach (var valuedResourceHandler in _valuedResourceHandlers)
                try
                {
                    return await valuedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, ct);
                }
                catch
                {
                    
                }
            
            throw new NotImplementedException("16");
        }
    }

    public class ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly Dictionary<string, AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult>> _namedResourceHandlers = new Dictionary<string, AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult>>();
        private readonly List<AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult>> _valuedResourceHandlers = new List<AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult>>();

        public ResourceCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Named(string name,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController>> nestedResourceCollectorFiller = null
            ) => Named(name, _controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);
        
        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Named<TNewController>(string name,
            Func<TNewController> controllerProvider,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TNewController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TNewController>> nestedResourceCollectorFiller = null
            )
        {
            if (httpMethodCollectorFiller == null) httpMethodCollectorFiller = x => x;
            if (nestedResourceCollectorFiller == null) nestedResourceCollectorFiller = x => x;
            _namedResourceHandlers[name] = new NamedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult>(
                httpMethodCollectorFiller(new HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TNewController>(controllerProvider)).Handle,
                nestedResourceCollectorFiller(new ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TNewController>(controllerProvider)).HandleAsync).HandleAsync;
            return this;
        }
        
        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Valued<TValue>(Func<string, TValue> parser,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TValue, TResult, TController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TValue, TResult, TController>> nestedResourceCollectorFiller = null
            ) => Valued(parser, _controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);

        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Valued<TValue, TNewController>(Func<string, TValue> parser,
            Func<TNewController> controllerProvider,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TValue, TResult, TNewController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TValue, TResult, TNewController>> nestedResourceCollectorFiller = null
            )
        {
            if (httpMethodCollectorFiller == null) httpMethodCollectorFiller = x => x;
            if (nestedResourceCollectorFiller == null) nestedResourceCollectorFiller = x => x;
            _valuedResourceHandlers.Add(new ValuedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TValue, TResult>(
                parser,
                httpMethodCollectorFiller(new HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TValue, TResult, TNewController>(controllerProvider)).Handle,
                nestedResourceCollectorFiller(new ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TValue, TResult, TNewController>(controllerProvider)).HandleAsync).Handle);
            return this;
        }

        public async Task<TResult> HandleAsync(string httpMethod, ICollection<string> urlSegments, NameValueCollection queryParameters, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, TP10 p10, CancellationToken ct)
        {
            if (!urlSegments.Any())
                throw new NotImplementedException("15");
            
            var urlHead = urlSegments.First();

            if (_namedResourceHandlers.TryGetValue(urlHead, out var namedResourceHandler))
                return await namedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, ct);

            foreach (var valuedResourceHandler in _valuedResourceHandlers)
                try
                {
                    return await valuedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, ct);
                }
                catch
                {
                    
                }
            
            throw new NotImplementedException("16");
        }
    }

    public class ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly Dictionary<string, AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult>> _namedResourceHandlers = new Dictionary<string, AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult>>();
        private readonly List<AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult>> _valuedResourceHandlers = new List<AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult>>();

        public ResourceCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Named(string name,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController>> nestedResourceCollectorFiller = null
            ) => Named(name, _controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);
        
        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Named<TNewController>(string name,
            Func<TNewController> controllerProvider,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TNewController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TNewController>> nestedResourceCollectorFiller = null
            )
        {
            if (httpMethodCollectorFiller == null) httpMethodCollectorFiller = x => x;
            if (nestedResourceCollectorFiller == null) nestedResourceCollectorFiller = x => x;
            _namedResourceHandlers[name] = new NamedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult>(
                httpMethodCollectorFiller(new HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TNewController>(controllerProvider)).Handle,
                nestedResourceCollectorFiller(new ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TNewController>(controllerProvider)).HandleAsync).HandleAsync;
            return this;
        }
        
        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Valued<TValue>(Func<string, TValue> parser,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TValue, TResult, TController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TValue, TResult, TController>> nestedResourceCollectorFiller = null
            ) => Valued(parser, _controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);

        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Valued<TValue, TNewController>(Func<string, TValue> parser,
            Func<TNewController> controllerProvider,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TValue, TResult, TNewController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TValue, TResult, TNewController>> nestedResourceCollectorFiller = null
            )
        {
            if (httpMethodCollectorFiller == null) httpMethodCollectorFiller = x => x;
            if (nestedResourceCollectorFiller == null) nestedResourceCollectorFiller = x => x;
            _valuedResourceHandlers.Add(new ValuedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TValue, TResult>(
                parser,
                httpMethodCollectorFiller(new HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TValue, TResult, TNewController>(controllerProvider)).Handle,
                nestedResourceCollectorFiller(new ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TValue, TResult, TNewController>(controllerProvider)).HandleAsync).Handle);
            return this;
        }

        public async Task<TResult> HandleAsync(string httpMethod, ICollection<string> urlSegments, NameValueCollection queryParameters, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, TP10 p10, TP11 p11, CancellationToken ct)
        {
            if (!urlSegments.Any())
                throw new NotImplementedException("15");
            
            var urlHead = urlSegments.First();

            if (_namedResourceHandlers.TryGetValue(urlHead, out var namedResourceHandler))
                return await namedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, ct);

            foreach (var valuedResourceHandler in _valuedResourceHandlers)
                try
                {
                    return await valuedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, ct);
                }
                catch
                {
                    
                }
            
            throw new NotImplementedException("16");
        }
    }

    public class ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly Dictionary<string, AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult>> _namedResourceHandlers = new Dictionary<string, AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult>>();
        private readonly List<AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult>> _valuedResourceHandlers = new List<AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult>>();

        public ResourceCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Named(string name,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController>> nestedResourceCollectorFiller = null
            ) => Named(name, _controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);
        
        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Named<TNewController>(string name,
            Func<TNewController> controllerProvider,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TNewController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TNewController>> nestedResourceCollectorFiller = null
            )
        {
            if (httpMethodCollectorFiller == null) httpMethodCollectorFiller = x => x;
            if (nestedResourceCollectorFiller == null) nestedResourceCollectorFiller = x => x;
            _namedResourceHandlers[name] = new NamedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult>(
                httpMethodCollectorFiller(new HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TNewController>(controllerProvider)).Handle,
                nestedResourceCollectorFiller(new ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TNewController>(controllerProvider)).HandleAsync).HandleAsync;
            return this;
        }
        
        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Valued<TValue>(Func<string, TValue> parser,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TValue, TResult, TController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TValue, TResult, TController>> nestedResourceCollectorFiller = null
            ) => Valued(parser, _controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);

        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Valued<TValue, TNewController>(Func<string, TValue> parser,
            Func<TNewController> controllerProvider,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TValue, TResult, TNewController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TValue, TResult, TNewController>> nestedResourceCollectorFiller = null
            )
        {
            if (httpMethodCollectorFiller == null) httpMethodCollectorFiller = x => x;
            if (nestedResourceCollectorFiller == null) nestedResourceCollectorFiller = x => x;
            _valuedResourceHandlers.Add(new ValuedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TValue, TResult>(
                parser,
                httpMethodCollectorFiller(new HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TValue, TResult, TNewController>(controllerProvider)).Handle,
                nestedResourceCollectorFiller(new ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TValue, TResult, TNewController>(controllerProvider)).HandleAsync).Handle);
            return this;
        }

        public async Task<TResult> HandleAsync(string httpMethod, ICollection<string> urlSegments, NameValueCollection queryParameters, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, TP10 p10, TP11 p11, TP12 p12, CancellationToken ct)
        {
            if (!urlSegments.Any())
                throw new NotImplementedException("15");
            
            var urlHead = urlSegments.First();

            if (_namedResourceHandlers.TryGetValue(urlHead, out var namedResourceHandler))
                return await namedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, ct);

            foreach (var valuedResourceHandler in _valuedResourceHandlers)
                try
                {
                    return await valuedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, ct);
                }
                catch
                {
                    
                }
            
            throw new NotImplementedException("16");
        }
    }

    public class ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly Dictionary<string, AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult>> _namedResourceHandlers = new Dictionary<string, AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult>>();
        private readonly List<AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult>> _valuedResourceHandlers = new List<AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult>>();

        public ResourceCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController> Named(string name,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController>> nestedResourceCollectorFiller = null
            ) => Named(name, _controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);
        
        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController> Named<TNewController>(string name,
            Func<TNewController> controllerProvider,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TNewController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TNewController>> nestedResourceCollectorFiller = null
            )
        {
            if (httpMethodCollectorFiller == null) httpMethodCollectorFiller = x => x;
            if (nestedResourceCollectorFiller == null) nestedResourceCollectorFiller = x => x;
            _namedResourceHandlers[name] = new NamedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult>(
                httpMethodCollectorFiller(new HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TNewController>(controllerProvider)).Handle,
                nestedResourceCollectorFiller(new ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TNewController>(controllerProvider)).HandleAsync).HandleAsync;
            return this;
        }
        
        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController> Valued<TValue>(Func<string, TValue> parser,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TValue, TResult, TController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TValue, TResult, TController>> nestedResourceCollectorFiller = null
            ) => Valued(parser, _controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);

        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController> Valued<TValue, TNewController>(Func<string, TValue> parser,
            Func<TNewController> controllerProvider,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TValue, TResult, TNewController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TValue, TResult, TNewController>> nestedResourceCollectorFiller = null
            )
        {
            if (httpMethodCollectorFiller == null) httpMethodCollectorFiller = x => x;
            if (nestedResourceCollectorFiller == null) nestedResourceCollectorFiller = x => x;
            _valuedResourceHandlers.Add(new ValuedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TValue, TResult>(
                parser,
                httpMethodCollectorFiller(new HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TValue, TResult, TNewController>(controllerProvider)).Handle,
                nestedResourceCollectorFiller(new ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TValue, TResult, TNewController>(controllerProvider)).HandleAsync).Handle);
            return this;
        }

        public async Task<TResult> HandleAsync(string httpMethod, ICollection<string> urlSegments, NameValueCollection queryParameters, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, TP10 p10, TP11 p11, TP12 p12, TP13 p13, CancellationToken ct)
        {
            if (!urlSegments.Any())
                throw new NotImplementedException("15");
            
            var urlHead = urlSegments.First();

            if (_namedResourceHandlers.TryGetValue(urlHead, out var namedResourceHandler))
                return await namedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, ct);

            foreach (var valuedResourceHandler in _valuedResourceHandlers)
                try
                {
                    return await valuedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, ct);
                }
                catch
                {
                    
                }
            
            throw new NotImplementedException("16");
        }
    }

    public class ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly Dictionary<string, AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult>> _namedResourceHandlers = new Dictionary<string, AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult>>();
        private readonly List<AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult>> _valuedResourceHandlers = new List<AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult>>();

        public ResourceCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TController> Named(string name,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TController>> nestedResourceCollectorFiller = null
            ) => Named(name, _controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);
        
        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TController> Named<TNewController>(string name,
            Func<TNewController> controllerProvider,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TNewController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TNewController>> nestedResourceCollectorFiller = null
            )
        {
            if (httpMethodCollectorFiller == null) httpMethodCollectorFiller = x => x;
            if (nestedResourceCollectorFiller == null) nestedResourceCollectorFiller = x => x;
            _namedResourceHandlers[name] = new NamedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult>(
                httpMethodCollectorFiller(new HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TNewController>(controllerProvider)).Handle,
                nestedResourceCollectorFiller(new ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TNewController>(controllerProvider)).HandleAsync).HandleAsync;
            return this;
        }
        
        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TController> Valued<TValue>(Func<string, TValue> parser,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TValue, TResult, TController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TValue, TResult, TController>> nestedResourceCollectorFiller = null
            ) => Valued(parser, _controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);

        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TController> Valued<TValue, TNewController>(Func<string, TValue> parser,
            Func<TNewController> controllerProvider,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TValue, TResult, TNewController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TValue, TResult, TNewController>> nestedResourceCollectorFiller = null
            )
        {
            if (httpMethodCollectorFiller == null) httpMethodCollectorFiller = x => x;
            if (nestedResourceCollectorFiller == null) nestedResourceCollectorFiller = x => x;
            _valuedResourceHandlers.Add(new ValuedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TValue, TResult>(
                parser,
                httpMethodCollectorFiller(new HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TValue, TResult, TNewController>(controllerProvider)).Handle,
                nestedResourceCollectorFiller(new ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TValue, TResult, TNewController>(controllerProvider)).HandleAsync).Handle);
            return this;
        }

        public async Task<TResult> HandleAsync(string httpMethod, ICollection<string> urlSegments, NameValueCollection queryParameters, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, TP10 p10, TP11 p11, TP12 p12, TP13 p13, TP14 p14, CancellationToken ct)
        {
            if (!urlSegments.Any())
                throw new NotImplementedException("15");
            
            var urlHead = urlSegments.First();

            if (_namedResourceHandlers.TryGetValue(urlHead, out var namedResourceHandler))
                return await namedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, ct);

            foreach (var valuedResourceHandler in _valuedResourceHandlers)
                try
                {
                    return await valuedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, ct);
                }
                catch
                {
                    
                }
            
            throw new NotImplementedException("16");
        }
    }

    public class ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly Dictionary<string, AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult>> _namedResourceHandlers = new Dictionary<string, AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult>>();
        private readonly List<AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult>> _valuedResourceHandlers = new List<AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult>>();

        public ResourceCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult, TController> Named(string name,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult, TController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult, TController>> nestedResourceCollectorFiller = null
            ) => Named(name, _controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);
        
        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult, TController> Named<TNewController>(string name,
            Func<TNewController> controllerProvider,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult, TNewController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult, TNewController>> nestedResourceCollectorFiller = null
            )
        {
            if (httpMethodCollectorFiller == null) httpMethodCollectorFiller = x => x;
            if (nestedResourceCollectorFiller == null) nestedResourceCollectorFiller = x => x;
            _namedResourceHandlers[name] = new NamedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult>(
                httpMethodCollectorFiller(new HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult, TNewController>(controllerProvider)).Handle,
                nestedResourceCollectorFiller(new ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult, TNewController>(controllerProvider)).HandleAsync).HandleAsync;
            return this;
        }
        
        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult, TController> Valued<TValue>(Func<string, TValue> parser,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TValue, TResult, TController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TValue, TResult, TController>> nestedResourceCollectorFiller = null
            ) => Valued(parser, _controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);

        public ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult, TController> Valued<TValue, TNewController>(Func<string, TValue> parser,
            Func<TNewController> controllerProvider,
            Mutator<HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TValue, TResult, TNewController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TValue, TResult, TNewController>> nestedResourceCollectorFiller = null
            )
        {
            if (httpMethodCollectorFiller == null) httpMethodCollectorFiller = x => x;
            if (nestedResourceCollectorFiller == null) nestedResourceCollectorFiller = x => x;
            _valuedResourceHandlers.Add(new ValuedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TValue, TResult>(
                parser,
                httpMethodCollectorFiller(new HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TValue, TResult, TNewController>(controllerProvider)).Handle,
                nestedResourceCollectorFiller(new ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TValue, TResult, TNewController>(controllerProvider)).HandleAsync).Handle);
            return this;
        }

        public async Task<TResult> HandleAsync(string httpMethod, ICollection<string> urlSegments, NameValueCollection queryParameters, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, TP10 p10, TP11 p11, TP12 p12, TP13 p13, TP14 p14, TP15 p15, CancellationToken ct)
        {
            if (!urlSegments.Any())
                throw new NotImplementedException("15");
            
            var urlHead = urlSegments.First();

            if (_namedResourceHandlers.TryGetValue(urlHead, out var namedResourceHandler))
                return await namedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, ct);

            foreach (var valuedResourceHandler in _valuedResourceHandlers)
                try
                {
                    return await valuedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, ct);
                }
                catch
                {
                    
                }
            
            throw new NotImplementedException("16");
        }
    }

    public class ResourceCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly Dictionary<string, AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TResult>> _namedResourceHandlers = new Dictionary<string, AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TResult>>();
        private readonly List<AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TResult>> _valuedResourceHandlers = new List<AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TResult>>();

        public ResourceCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }

        public async Task<TResult> HandleAsync(string httpMethod, ICollection<string> urlSegments, NameValueCollection queryParameters, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, TP10 p10, TP11 p11, TP12 p12, TP13 p13, TP14 p14, TP15 p15, TP16 p16, CancellationToken ct)
        {
            if (!urlSegments.Any())
                throw new NotImplementedException("15");
            
            var urlHead = urlSegments.First();

            if (_namedResourceHandlers.TryGetValue(urlHead, out var namedResourceHandler))
                return await namedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, ct);

            foreach (var valuedResourceHandler in _valuedResourceHandlers)
                try
                {
                    return await valuedResourceHandler(httpMethod, urlSegments, queryParameters, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, ct);
                }
                catch
                {
                    
                }
            
            throw new NotImplementedException("16");
        }
    }

}
