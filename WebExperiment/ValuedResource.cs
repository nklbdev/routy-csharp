using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebExperiment
{
    public class ValuedResource<TContext, TResult, TValue>
    {
        private readonly Parser<TValue> _parser;
        private readonly HttpMethodCollectorHandle<TContext, TResult, TValue> _methodCollectorHandler;
        private readonly ResourceCollectorHandle<TContext, TResult, TValue> _nestedResourceCollectorHandler;
        
        public ValuedResource(
            Parser<TValue> parser,
            HttpMethodCollectorHandle<TContext, TResult, TValue> methodCollectorHandler,
            ResourceCollectorHandle<TContext, TResult, TValue> nestedResourceCollectorHandler)
        {
            _parser = parser;
            _methodCollectorHandler = methodCollectorHandler;
            _nestedResourceCollectorHandler = nestedResourceCollectorHandler;
        }
        
        public async Task<TResult> Handle(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, CancellationToken ct)
        {
            if (!uriSegments.Any())
                throw new NotImplementedException();

            var head = uriSegments.First();
            var tail = uriSegments.Skip(1).ToArray();

            var value = _parser(head);

            return tail.Any()
                ? await _nestedResourceCollectorHandler(httpMethod, tail, query, context, value, ct)
                : await _methodCollectorHandler(httpMethod, query, context, value, ct);
        }
    }
}