using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebExperiment
{
    public class NamedResource<TContext, TResult>
    {
        private readonly HttpMethodCollectorHandle<TContext, TResult> _methodCollectorHandler;
        private readonly ResourceCollectorHandle<TContext, TResult> _nestedResourceCollectorHandler;
        
        public NamedResource(
            HttpMethodCollectorHandle<TContext, TResult> methodCollectorHandler,
            ResourceCollectorHandle<TContext, TResult> nestedResourceCollectorHandler)
        {
            _methodCollectorHandler = methodCollectorHandler;
            _nestedResourceCollectorHandler = nestedResourceCollectorHandler;
        }
        
        public async Task<TResult> Handle(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, CancellationToken ct)
        {
            if (!uriSegments.Any())
                throw new NotImplementedException();

            var tail = uriSegments.Skip(1).ToArray();

            return tail.Any()
                ? await _nestedResourceCollectorHandler(httpMethod, tail, query, context, ct)
                : await _methodCollectorHandler(httpMethod, query, context, ct);
        }
    }
}