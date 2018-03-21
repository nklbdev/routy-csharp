using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Routy
{
    public class NamedResource<TContext, TResult>
    {
        private readonly HttpMethodCollectorHandler<TContext, TResult> _methodCollectorHandler;
        private readonly ResourceCollectorHandler<TContext, TResult> _nestedResourceCollectorHandler;
        
        public NamedResource(
            HttpMethodCollectorHandler<TContext, TResult> methodCollectorHandler,
            ResourceCollectorHandler<TContext, TResult> nestedResourceCollectorHandler)
        {
            _methodCollectorHandler = methodCollectorHandler;
            _nestedResourceCollectorHandler = nestedResourceCollectorHandler;
        }
        
        public async Task<TResult> Handle(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, CancellationToken ct)
        {
            if (!uriSegments.Any())
                throw new NotImplementedException("6");

            var tail = uriSegments.Skip(1).ToArray();

            return tail.Any()
                ? await _nestedResourceCollectorHandler(httpMethod, tail, query, context, ct)
                : await _methodCollectorHandler(httpMethod, query, context, ct);
        }
    }
}