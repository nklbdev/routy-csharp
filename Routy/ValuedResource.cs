using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Routy
{
    public class ValuedResource<TContext, TValue, TResult>
    {
        private readonly Func<string, TValue> _parser;
        private readonly AsyncHttpMethodCollectorHandler<TContext, TValue, TResult> _methodCollectorHandler;
        private readonly AsyncResourceCollectorHandler<TContext, TValue, TResult> _nestedAsyncResourceCollectorHandler;
        
        public ValuedResource(
            Func<string, TValue> parser,
            AsyncHttpMethodCollectorHandler<TContext, TValue, TResult> methodCollectorHandler,
            AsyncResourceCollectorHandler<TContext, TValue, TResult> nestedAsyncResourceCollectorHandler)
        {
            _parser = parser;
            _methodCollectorHandler = methodCollectorHandler;
            _nestedAsyncResourceCollectorHandler = nestedAsyncResourceCollectorHandler;
        }
        
        public async Task<TResult> Handle(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, CancellationToken ct)
        {
            if (!uriSegments.Any())
                throw new NotImplementedException("1");

            var head = uriSegments.First();
            var tail = uriSegments.Skip(1).ToArray();

            var value = _parser(head);

            return tail.Any()
                ? await _nestedAsyncResourceCollectorHandler(httpMethod, tail, query, context, value, ct)
                : await _methodCollectorHandler(httpMethod, query, context, value, ct);
        }
    }

    public class ValuedResource<TContext, TP1, TValue, TResult>
    {
        private readonly Func<string, TValue> _parser;
        private readonly AsyncHttpMethodCollectorHandler<TContext, TP1, TValue, TResult> _methodCollectorHandler;
        private readonly AsyncResourceCollectorHandler<TContext, TP1, TValue, TResult> _nestedAsyncResourceCollectorHandler;
        
        public ValuedResource(
            Func<string, TValue> parser,
            AsyncHttpMethodCollectorHandler<TContext, TP1, TValue, TResult> methodCollectorHandler,
            AsyncResourceCollectorHandler<TContext, TP1, TValue, TResult> nestedAsyncResourceCollectorHandler)
        {
            _parser = parser;
            _methodCollectorHandler = methodCollectorHandler;
            _nestedAsyncResourceCollectorHandler = nestedAsyncResourceCollectorHandler;
        }
        
        public async Task<TResult> Handle(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, TP1 p1, CancellationToken ct)
        {
            if (!uriSegments.Any())
                throw new NotImplementedException("1");

            var head = uriSegments.First();
            var tail = uriSegments.Skip(1).ToArray();

            var value = _parser(head);

            return tail.Any()
                ? await _nestedAsyncResourceCollectorHandler(httpMethod, tail, query, context, p1, value, ct)
                : await _methodCollectorHandler(httpMethod, query, context, p1, value, ct);
        }
    }

    public class ValuedResource<TContext, TP1, TP2, TValue, TResult>
    {
        private readonly Func<string, TValue> _parser;
        private readonly AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TValue, TResult> _methodCollectorHandler;
        private readonly AsyncResourceCollectorHandler<TContext, TP1, TP2, TValue, TResult> _nestedAsyncResourceCollectorHandler;
        
        public ValuedResource(
            Func<string, TValue> parser,
            AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TValue, TResult> methodCollectorHandler,
            AsyncResourceCollectorHandler<TContext, TP1, TP2, TValue, TResult> nestedAsyncResourceCollectorHandler)
        {
            _parser = parser;
            _methodCollectorHandler = methodCollectorHandler;
            _nestedAsyncResourceCollectorHandler = nestedAsyncResourceCollectorHandler;
        }
        
        public async Task<TResult> Handle(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, TP1 p1, TP2 p2, CancellationToken ct)
        {
            if (!uriSegments.Any())
                throw new NotImplementedException("1");

            var head = uriSegments.First();
            var tail = uriSegments.Skip(1).ToArray();

            var value = _parser(head);

            return tail.Any()
                ? await _nestedAsyncResourceCollectorHandler(httpMethod, tail, query, context, p1, p2, value, ct)
                : await _methodCollectorHandler(httpMethod, query, context, p1, p2, value, ct);
        }
    }

    public class ValuedResource<TContext, TP1, TP2, TP3, TValue, TResult>
    {
        private readonly Func<string, TValue> _parser;
        private readonly AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TValue, TResult> _methodCollectorHandler;
        private readonly AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TValue, TResult> _nestedAsyncResourceCollectorHandler;
        
        public ValuedResource(
            Func<string, TValue> parser,
            AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TValue, TResult> methodCollectorHandler,
            AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TValue, TResult> nestedAsyncResourceCollectorHandler)
        {
            _parser = parser;
            _methodCollectorHandler = methodCollectorHandler;
            _nestedAsyncResourceCollectorHandler = nestedAsyncResourceCollectorHandler;
        }
        
        public async Task<TResult> Handle(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, CancellationToken ct)
        {
            if (!uriSegments.Any())
                throw new NotImplementedException("1");

            var head = uriSegments.First();
            var tail = uriSegments.Skip(1).ToArray();

            var value = _parser(head);

            return tail.Any()
                ? await _nestedAsyncResourceCollectorHandler(httpMethod, tail, query, context, p1, p2, p3, value, ct)
                : await _methodCollectorHandler(httpMethod, query, context, p1, p2, p3, value, ct);
        }
    }

    public class ValuedResource<TContext, TP1, TP2, TP3, TP4, TValue, TResult>
    {
        private readonly Func<string, TValue> _parser;
        private readonly AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TValue, TResult> _methodCollectorHandler;
        private readonly AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TValue, TResult> _nestedAsyncResourceCollectorHandler;
        
        public ValuedResource(
            Func<string, TValue> parser,
            AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TValue, TResult> methodCollectorHandler,
            AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TValue, TResult> nestedAsyncResourceCollectorHandler)
        {
            _parser = parser;
            _methodCollectorHandler = methodCollectorHandler;
            _nestedAsyncResourceCollectorHandler = nestedAsyncResourceCollectorHandler;
        }
        
        public async Task<TResult> Handle(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, CancellationToken ct)
        {
            if (!uriSegments.Any())
                throw new NotImplementedException("1");

            var head = uriSegments.First();
            var tail = uriSegments.Skip(1).ToArray();

            var value = _parser(head);

            return tail.Any()
                ? await _nestedAsyncResourceCollectorHandler(httpMethod, tail, query, context, p1, p2, p3, p4, value, ct)
                : await _methodCollectorHandler(httpMethod, query, context, p1, p2, p3, p4, value, ct);
        }
    }

    public class ValuedResource<TContext, TP1, TP2, TP3, TP4, TP5, TValue, TResult>
    {
        private readonly Func<string, TValue> _parser;
        private readonly AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TValue, TResult> _methodCollectorHandler;
        private readonly AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TValue, TResult> _nestedAsyncResourceCollectorHandler;
        
        public ValuedResource(
            Func<string, TValue> parser,
            AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TValue, TResult> methodCollectorHandler,
            AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TValue, TResult> nestedAsyncResourceCollectorHandler)
        {
            _parser = parser;
            _methodCollectorHandler = methodCollectorHandler;
            _nestedAsyncResourceCollectorHandler = nestedAsyncResourceCollectorHandler;
        }
        
        public async Task<TResult> Handle(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, CancellationToken ct)
        {
            if (!uriSegments.Any())
                throw new NotImplementedException("1");

            var head = uriSegments.First();
            var tail = uriSegments.Skip(1).ToArray();

            var value = _parser(head);

            return tail.Any()
                ? await _nestedAsyncResourceCollectorHandler(httpMethod, tail, query, context, p1, p2, p3, p4, p5, value, ct)
                : await _methodCollectorHandler(httpMethod, query, context, p1, p2, p3, p4, p5, value, ct);
        }
    }

    public class ValuedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TValue, TResult>
    {
        private readonly Func<string, TValue> _parser;
        private readonly AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TValue, TResult> _methodCollectorHandler;
        private readonly AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TValue, TResult> _nestedAsyncResourceCollectorHandler;
        
        public ValuedResource(
            Func<string, TValue> parser,
            AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TValue, TResult> methodCollectorHandler,
            AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TValue, TResult> nestedAsyncResourceCollectorHandler)
        {
            _parser = parser;
            _methodCollectorHandler = methodCollectorHandler;
            _nestedAsyncResourceCollectorHandler = nestedAsyncResourceCollectorHandler;
        }
        
        public async Task<TResult> Handle(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, CancellationToken ct)
        {
            if (!uriSegments.Any())
                throw new NotImplementedException("1");

            var head = uriSegments.First();
            var tail = uriSegments.Skip(1).ToArray();

            var value = _parser(head);

            return tail.Any()
                ? await _nestedAsyncResourceCollectorHandler(httpMethod, tail, query, context, p1, p2, p3, p4, p5, p6, value, ct)
                : await _methodCollectorHandler(httpMethod, query, context, p1, p2, p3, p4, p5, p6, value, ct);
        }
    }

    public class ValuedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TValue, TResult>
    {
        private readonly Func<string, TValue> _parser;
        private readonly AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TValue, TResult> _methodCollectorHandler;
        private readonly AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TValue, TResult> _nestedAsyncResourceCollectorHandler;
        
        public ValuedResource(
            Func<string, TValue> parser,
            AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TValue, TResult> methodCollectorHandler,
            AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TValue, TResult> nestedAsyncResourceCollectorHandler)
        {
            _parser = parser;
            _methodCollectorHandler = methodCollectorHandler;
            _nestedAsyncResourceCollectorHandler = nestedAsyncResourceCollectorHandler;
        }
        
        public async Task<TResult> Handle(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, CancellationToken ct)
        {
            if (!uriSegments.Any())
                throw new NotImplementedException("1");

            var head = uriSegments.First();
            var tail = uriSegments.Skip(1).ToArray();

            var value = _parser(head);

            return tail.Any()
                ? await _nestedAsyncResourceCollectorHandler(httpMethod, tail, query, context, p1, p2, p3, p4, p5, p6, p7, value, ct)
                : await _methodCollectorHandler(httpMethod, query, context, p1, p2, p3, p4, p5, p6, p7, value, ct);
        }
    }

    public class ValuedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TValue, TResult>
    {
        private readonly Func<string, TValue> _parser;
        private readonly AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TValue, TResult> _methodCollectorHandler;
        private readonly AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TValue, TResult> _nestedAsyncResourceCollectorHandler;
        
        public ValuedResource(
            Func<string, TValue> parser,
            AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TValue, TResult> methodCollectorHandler,
            AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TValue, TResult> nestedAsyncResourceCollectorHandler)
        {
            _parser = parser;
            _methodCollectorHandler = methodCollectorHandler;
            _nestedAsyncResourceCollectorHandler = nestedAsyncResourceCollectorHandler;
        }
        
        public async Task<TResult> Handle(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, CancellationToken ct)
        {
            if (!uriSegments.Any())
                throw new NotImplementedException("1");

            var head = uriSegments.First();
            var tail = uriSegments.Skip(1).ToArray();

            var value = _parser(head);

            return tail.Any()
                ? await _nestedAsyncResourceCollectorHandler(httpMethod, tail, query, context, p1, p2, p3, p4, p5, p6, p7, p8, value, ct)
                : await _methodCollectorHandler(httpMethod, query, context, p1, p2, p3, p4, p5, p6, p7, p8, value, ct);
        }
    }

    public class ValuedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TValue, TResult>
    {
        private readonly Func<string, TValue> _parser;
        private readonly AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TValue, TResult> _methodCollectorHandler;
        private readonly AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TValue, TResult> _nestedAsyncResourceCollectorHandler;
        
        public ValuedResource(
            Func<string, TValue> parser,
            AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TValue, TResult> methodCollectorHandler,
            AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TValue, TResult> nestedAsyncResourceCollectorHandler)
        {
            _parser = parser;
            _methodCollectorHandler = methodCollectorHandler;
            _nestedAsyncResourceCollectorHandler = nestedAsyncResourceCollectorHandler;
        }
        
        public async Task<TResult> Handle(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, CancellationToken ct)
        {
            if (!uriSegments.Any())
                throw new NotImplementedException("1");

            var head = uriSegments.First();
            var tail = uriSegments.Skip(1).ToArray();

            var value = _parser(head);

            return tail.Any()
                ? await _nestedAsyncResourceCollectorHandler(httpMethod, tail, query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, value, ct)
                : await _methodCollectorHandler(httpMethod, query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, value, ct);
        }
    }

    public class ValuedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TValue, TResult>
    {
        private readonly Func<string, TValue> _parser;
        private readonly AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TValue, TResult> _methodCollectorHandler;
        private readonly AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TValue, TResult> _nestedAsyncResourceCollectorHandler;
        
        public ValuedResource(
            Func<string, TValue> parser,
            AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TValue, TResult> methodCollectorHandler,
            AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TValue, TResult> nestedAsyncResourceCollectorHandler)
        {
            _parser = parser;
            _methodCollectorHandler = methodCollectorHandler;
            _nestedAsyncResourceCollectorHandler = nestedAsyncResourceCollectorHandler;
        }
        
        public async Task<TResult> Handle(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, TP10 p10, CancellationToken ct)
        {
            if (!uriSegments.Any())
                throw new NotImplementedException("1");

            var head = uriSegments.First();
            var tail = uriSegments.Skip(1).ToArray();

            var value = _parser(head);

            return tail.Any()
                ? await _nestedAsyncResourceCollectorHandler(httpMethod, tail, query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, value, ct)
                : await _methodCollectorHandler(httpMethod, query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, value, ct);
        }
    }

    public class ValuedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TValue, TResult>
    {
        private readonly Func<string, TValue> _parser;
        private readonly AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TValue, TResult> _methodCollectorHandler;
        private readonly AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TValue, TResult> _nestedAsyncResourceCollectorHandler;
        
        public ValuedResource(
            Func<string, TValue> parser,
            AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TValue, TResult> methodCollectorHandler,
            AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TValue, TResult> nestedAsyncResourceCollectorHandler)
        {
            _parser = parser;
            _methodCollectorHandler = methodCollectorHandler;
            _nestedAsyncResourceCollectorHandler = nestedAsyncResourceCollectorHandler;
        }
        
        public async Task<TResult> Handle(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, TP10 p10, TP11 p11, CancellationToken ct)
        {
            if (!uriSegments.Any())
                throw new NotImplementedException("1");

            var head = uriSegments.First();
            var tail = uriSegments.Skip(1).ToArray();

            var value = _parser(head);

            return tail.Any()
                ? await _nestedAsyncResourceCollectorHandler(httpMethod, tail, query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, value, ct)
                : await _methodCollectorHandler(httpMethod, query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, value, ct);
        }
    }

    public class ValuedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TValue, TResult>
    {
        private readonly Func<string, TValue> _parser;
        private readonly AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TValue, TResult> _methodCollectorHandler;
        private readonly AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TValue, TResult> _nestedAsyncResourceCollectorHandler;
        
        public ValuedResource(
            Func<string, TValue> parser,
            AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TValue, TResult> methodCollectorHandler,
            AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TValue, TResult> nestedAsyncResourceCollectorHandler)
        {
            _parser = parser;
            _methodCollectorHandler = methodCollectorHandler;
            _nestedAsyncResourceCollectorHandler = nestedAsyncResourceCollectorHandler;
        }
        
        public async Task<TResult> Handle(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, TP10 p10, TP11 p11, TP12 p12, CancellationToken ct)
        {
            if (!uriSegments.Any())
                throw new NotImplementedException("1");

            var head = uriSegments.First();
            var tail = uriSegments.Skip(1).ToArray();

            var value = _parser(head);

            return tail.Any()
                ? await _nestedAsyncResourceCollectorHandler(httpMethod, tail, query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, value, ct)
                : await _methodCollectorHandler(httpMethod, query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, value, ct);
        }
    }

    public class ValuedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TValue, TResult>
    {
        private readonly Func<string, TValue> _parser;
        private readonly AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TValue, TResult> _methodCollectorHandler;
        private readonly AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TValue, TResult> _nestedAsyncResourceCollectorHandler;
        
        public ValuedResource(
            Func<string, TValue> parser,
            AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TValue, TResult> methodCollectorHandler,
            AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TValue, TResult> nestedAsyncResourceCollectorHandler)
        {
            _parser = parser;
            _methodCollectorHandler = methodCollectorHandler;
            _nestedAsyncResourceCollectorHandler = nestedAsyncResourceCollectorHandler;
        }
        
        public async Task<TResult> Handle(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, TP10 p10, TP11 p11, TP12 p12, TP13 p13, CancellationToken ct)
        {
            if (!uriSegments.Any())
                throw new NotImplementedException("1");

            var head = uriSegments.First();
            var tail = uriSegments.Skip(1).ToArray();

            var value = _parser(head);

            return tail.Any()
                ? await _nestedAsyncResourceCollectorHandler(httpMethod, tail, query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, value, ct)
                : await _methodCollectorHandler(httpMethod, query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, value, ct);
        }
    }

    public class ValuedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TValue, TResult>
    {
        private readonly Func<string, TValue> _parser;
        private readonly AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TValue, TResult> _methodCollectorHandler;
        private readonly AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TValue, TResult> _nestedAsyncResourceCollectorHandler;
        
        public ValuedResource(
            Func<string, TValue> parser,
            AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TValue, TResult> methodCollectorHandler,
            AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TValue, TResult> nestedAsyncResourceCollectorHandler)
        {
            _parser = parser;
            _methodCollectorHandler = methodCollectorHandler;
            _nestedAsyncResourceCollectorHandler = nestedAsyncResourceCollectorHandler;
        }
        
        public async Task<TResult> Handle(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, TP10 p10, TP11 p11, TP12 p12, TP13 p13, TP14 p14, CancellationToken ct)
        {
            if (!uriSegments.Any())
                throw new NotImplementedException("1");

            var head = uriSegments.First();
            var tail = uriSegments.Skip(1).ToArray();

            var value = _parser(head);

            return tail.Any()
                ? await _nestedAsyncResourceCollectorHandler(httpMethod, tail, query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, value, ct)
                : await _methodCollectorHandler(httpMethod, query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, value, ct);
        }
    }

    public class ValuedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TValue, TResult>
    {
        private readonly Func<string, TValue> _parser;
        private readonly AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TValue, TResult> _methodCollectorHandler;
        private readonly AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TValue, TResult> _nestedAsyncResourceCollectorHandler;
        
        public ValuedResource(
            Func<string, TValue> parser,
            AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TValue, TResult> methodCollectorHandler,
            AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TValue, TResult> nestedAsyncResourceCollectorHandler)
        {
            _parser = parser;
            _methodCollectorHandler = methodCollectorHandler;
            _nestedAsyncResourceCollectorHandler = nestedAsyncResourceCollectorHandler;
        }
        
        public async Task<TResult> Handle(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, TP10 p10, TP11 p11, TP12 p12, TP13 p13, TP14 p14, TP15 p15, CancellationToken ct)
        {
            if (!uriSegments.Any())
                throw new NotImplementedException("1");

            var head = uriSegments.First();
            var tail = uriSegments.Skip(1).ToArray();

            var value = _parser(head);

            return tail.Any()
                ? await _nestedAsyncResourceCollectorHandler(httpMethod, tail, query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, value, ct)
                : await _methodCollectorHandler(httpMethod, query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, value, ct);
        }
    }

}
