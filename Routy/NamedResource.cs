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
        private readonly AsyncHttpMethodCollectorHandler<TContext, TResult> _methodCollectorHandler;
        private readonly AsyncResourceCollectorHandler<TContext, TResult> _nestedAsyncResourceCollectorHandler;
        
        public NamedResource(
            AsyncHttpMethodCollectorHandler<TContext, TResult> methodCollectorHandler,
            AsyncResourceCollectorHandler<TContext, TResult> nestedAsyncResourceCollectorHandler)
        {
            _methodCollectorHandler = methodCollectorHandler;
            _nestedAsyncResourceCollectorHandler = nestedAsyncResourceCollectorHandler;
        }
        
        public async Task<TResult> HandleAsync(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, CancellationToken ct)
        {
            if (!uriSegments.Any())
                throw new NotImplementedException("6");

            var tail = uriSegments.Skip(1).ToArray();

            return tail.Any()
                ? await _nestedAsyncResourceCollectorHandler(httpMethod, tail, query, context, ct)
                : await _methodCollectorHandler(httpMethod, query, context, ct);
        }
    }

    public class NamedResource<TContext, TP1, TResult>
    {
        private readonly AsyncHttpMethodCollectorHandler<TContext, TP1, TResult> _methodCollectorHandler;
        private readonly AsyncResourceCollectorHandler<TContext, TP1, TResult> _nestedAsyncResourceCollectorHandler;
        
        public NamedResource(
            AsyncHttpMethodCollectorHandler<TContext, TP1, TResult> methodCollectorHandler,
            AsyncResourceCollectorHandler<TContext, TP1, TResult> nestedAsyncResourceCollectorHandler)
        {
            _methodCollectorHandler = methodCollectorHandler;
            _nestedAsyncResourceCollectorHandler = nestedAsyncResourceCollectorHandler;
        }
        
        public async Task<TResult> HandleAsync(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, TP1 p1, CancellationToken ct)
        {
            if (!uriSegments.Any())
                throw new NotImplementedException("6");

            var tail = uriSegments.Skip(1).ToArray();

            return tail.Any()
                ? await _nestedAsyncResourceCollectorHandler(httpMethod, tail, query, context, p1, ct)
                : await _methodCollectorHandler(httpMethod, query, context, p1, ct);
        }
    }

    public class NamedResource<TContext, TP1, TP2, TResult>
    {
        private readonly AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TResult> _methodCollectorHandler;
        private readonly AsyncResourceCollectorHandler<TContext, TP1, TP2, TResult> _nestedAsyncResourceCollectorHandler;
        
        public NamedResource(
            AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TResult> methodCollectorHandler,
            AsyncResourceCollectorHandler<TContext, TP1, TP2, TResult> nestedAsyncResourceCollectorHandler)
        {
            _methodCollectorHandler = methodCollectorHandler;
            _nestedAsyncResourceCollectorHandler = nestedAsyncResourceCollectorHandler;
        }
        
        public async Task<TResult> HandleAsync(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, TP1 p1, TP2 p2, CancellationToken ct)
        {
            if (!uriSegments.Any())
                throw new NotImplementedException("6");

            var tail = uriSegments.Skip(1).ToArray();

            return tail.Any()
                ? await _nestedAsyncResourceCollectorHandler(httpMethod, tail, query, context, p1, p2, ct)
                : await _methodCollectorHandler(httpMethod, query, context, p1, p2, ct);
        }
    }

    public class NamedResource<TContext, TP1, TP2, TP3, TResult>
    {
        private readonly AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TResult> _methodCollectorHandler;
        private readonly AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TResult> _nestedAsyncResourceCollectorHandler;
        
        public NamedResource(
            AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TResult> methodCollectorHandler,
            AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TResult> nestedAsyncResourceCollectorHandler)
        {
            _methodCollectorHandler = methodCollectorHandler;
            _nestedAsyncResourceCollectorHandler = nestedAsyncResourceCollectorHandler;
        }
        
        public async Task<TResult> HandleAsync(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, CancellationToken ct)
        {
            if (!uriSegments.Any())
                throw new NotImplementedException("6");

            var tail = uriSegments.Skip(1).ToArray();

            return tail.Any()
                ? await _nestedAsyncResourceCollectorHandler(httpMethod, tail, query, context, p1, p2, p3, ct)
                : await _methodCollectorHandler(httpMethod, query, context, p1, p2, p3, ct);
        }
    }

    public class NamedResource<TContext, TP1, TP2, TP3, TP4, TResult>
    {
        private readonly AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> _methodCollectorHandler;
        private readonly AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> _nestedAsyncResourceCollectorHandler;
        
        public NamedResource(
            AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> methodCollectorHandler,
            AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TResult> nestedAsyncResourceCollectorHandler)
        {
            _methodCollectorHandler = methodCollectorHandler;
            _nestedAsyncResourceCollectorHandler = nestedAsyncResourceCollectorHandler;
        }
        
        public async Task<TResult> HandleAsync(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, CancellationToken ct)
        {
            if (!uriSegments.Any())
                throw new NotImplementedException("6");

            var tail = uriSegments.Skip(1).ToArray();

            return tail.Any()
                ? await _nestedAsyncResourceCollectorHandler(httpMethod, tail, query, context, p1, p2, p3, p4, ct)
                : await _methodCollectorHandler(httpMethod, query, context, p1, p2, p3, p4, ct);
        }
    }

    public class NamedResource<TContext, TP1, TP2, TP3, TP4, TP5, TResult>
    {
        private readonly AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> _methodCollectorHandler;
        private readonly AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> _nestedAsyncResourceCollectorHandler;
        
        public NamedResource(
            AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> methodCollectorHandler,
            AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TResult> nestedAsyncResourceCollectorHandler)
        {
            _methodCollectorHandler = methodCollectorHandler;
            _nestedAsyncResourceCollectorHandler = nestedAsyncResourceCollectorHandler;
        }
        
        public async Task<TResult> HandleAsync(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, CancellationToken ct)
        {
            if (!uriSegments.Any())
                throw new NotImplementedException("6");

            var tail = uriSegments.Skip(1).ToArray();

            return tail.Any()
                ? await _nestedAsyncResourceCollectorHandler(httpMethod, tail, query, context, p1, p2, p3, p4, p5, ct)
                : await _methodCollectorHandler(httpMethod, query, context, p1, p2, p3, p4, p5, ct);
        }
    }

    public class NamedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult>
    {
        private readonly AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> _methodCollectorHandler;
        private readonly AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> _nestedAsyncResourceCollectorHandler;
        
        public NamedResource(
            AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> methodCollectorHandler,
            AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult> nestedAsyncResourceCollectorHandler)
        {
            _methodCollectorHandler = methodCollectorHandler;
            _nestedAsyncResourceCollectorHandler = nestedAsyncResourceCollectorHandler;
        }
        
        public async Task<TResult> HandleAsync(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, CancellationToken ct)
        {
            if (!uriSegments.Any())
                throw new NotImplementedException("6");

            var tail = uriSegments.Skip(1).ToArray();

            return tail.Any()
                ? await _nestedAsyncResourceCollectorHandler(httpMethod, tail, query, context, p1, p2, p3, p4, p5, p6, ct)
                : await _methodCollectorHandler(httpMethod, query, context, p1, p2, p3, p4, p5, p6, ct);
        }
    }

    public class NamedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult>
    {
        private readonly AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> _methodCollectorHandler;
        private readonly AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> _nestedAsyncResourceCollectorHandler;
        
        public NamedResource(
            AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> methodCollectorHandler,
            AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult> nestedAsyncResourceCollectorHandler)
        {
            _methodCollectorHandler = methodCollectorHandler;
            _nestedAsyncResourceCollectorHandler = nestedAsyncResourceCollectorHandler;
        }
        
        public async Task<TResult> HandleAsync(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, CancellationToken ct)
        {
            if (!uriSegments.Any())
                throw new NotImplementedException("6");

            var tail = uriSegments.Skip(1).ToArray();

            return tail.Any()
                ? await _nestedAsyncResourceCollectorHandler(httpMethod, tail, query, context, p1, p2, p3, p4, p5, p6, p7, ct)
                : await _methodCollectorHandler(httpMethod, query, context, p1, p2, p3, p4, p5, p6, p7, ct);
        }
    }

    public class NamedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult>
    {
        private readonly AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> _methodCollectorHandler;
        private readonly AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> _nestedAsyncResourceCollectorHandler;
        
        public NamedResource(
            AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> methodCollectorHandler,
            AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult> nestedAsyncResourceCollectorHandler)
        {
            _methodCollectorHandler = methodCollectorHandler;
            _nestedAsyncResourceCollectorHandler = nestedAsyncResourceCollectorHandler;
        }
        
        public async Task<TResult> HandleAsync(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, CancellationToken ct)
        {
            if (!uriSegments.Any())
                throw new NotImplementedException("6");

            var tail = uriSegments.Skip(1).ToArray();

            return tail.Any()
                ? await _nestedAsyncResourceCollectorHandler(httpMethod, tail, query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct)
                : await _methodCollectorHandler(httpMethod, query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct);
        }
    }

    public class NamedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult>
    {
        private readonly AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> _methodCollectorHandler;
        private readonly AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> _nestedAsyncResourceCollectorHandler;
        
        public NamedResource(
            AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> methodCollectorHandler,
            AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult> nestedAsyncResourceCollectorHandler)
        {
            _methodCollectorHandler = methodCollectorHandler;
            _nestedAsyncResourceCollectorHandler = nestedAsyncResourceCollectorHandler;
        }
        
        public async Task<TResult> HandleAsync(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, CancellationToken ct)
        {
            if (!uriSegments.Any())
                throw new NotImplementedException("6");

            var tail = uriSegments.Skip(1).ToArray();

            return tail.Any()
                ? await _nestedAsyncResourceCollectorHandler(httpMethod, tail, query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, ct)
                : await _methodCollectorHandler(httpMethod, query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, ct);
        }
    }

    public class NamedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult>
    {
        private readonly AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult> _methodCollectorHandler;
        private readonly AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult> _nestedAsyncResourceCollectorHandler;
        
        public NamedResource(
            AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult> methodCollectorHandler,
            AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult> nestedAsyncResourceCollectorHandler)
        {
            _methodCollectorHandler = methodCollectorHandler;
            _nestedAsyncResourceCollectorHandler = nestedAsyncResourceCollectorHandler;
        }
        
        public async Task<TResult> HandleAsync(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, TP10 p10, CancellationToken ct)
        {
            if (!uriSegments.Any())
                throw new NotImplementedException("6");

            var tail = uriSegments.Skip(1).ToArray();

            return tail.Any()
                ? await _nestedAsyncResourceCollectorHandler(httpMethod, tail, query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, ct)
                : await _methodCollectorHandler(httpMethod, query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, ct);
        }
    }

    public class NamedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult>
    {
        private readonly AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult> _methodCollectorHandler;
        private readonly AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult> _nestedAsyncResourceCollectorHandler;
        
        public NamedResource(
            AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult> methodCollectorHandler,
            AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult> nestedAsyncResourceCollectorHandler)
        {
            _methodCollectorHandler = methodCollectorHandler;
            _nestedAsyncResourceCollectorHandler = nestedAsyncResourceCollectorHandler;
        }
        
        public async Task<TResult> HandleAsync(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, TP10 p10, TP11 p11, CancellationToken ct)
        {
            if (!uriSegments.Any())
                throw new NotImplementedException("6");

            var tail = uriSegments.Skip(1).ToArray();

            return tail.Any()
                ? await _nestedAsyncResourceCollectorHandler(httpMethod, tail, query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, ct)
                : await _methodCollectorHandler(httpMethod, query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, ct);
        }
    }

    public class NamedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult>
    {
        private readonly AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult> _methodCollectorHandler;
        private readonly AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult> _nestedAsyncResourceCollectorHandler;
        
        public NamedResource(
            AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult> methodCollectorHandler,
            AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult> nestedAsyncResourceCollectorHandler)
        {
            _methodCollectorHandler = methodCollectorHandler;
            _nestedAsyncResourceCollectorHandler = nestedAsyncResourceCollectorHandler;
        }
        
        public async Task<TResult> HandleAsync(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, TP10 p10, TP11 p11, TP12 p12, CancellationToken ct)
        {
            if (!uriSegments.Any())
                throw new NotImplementedException("6");

            var tail = uriSegments.Skip(1).ToArray();

            return tail.Any()
                ? await _nestedAsyncResourceCollectorHandler(httpMethod, tail, query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, ct)
                : await _methodCollectorHandler(httpMethod, query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, ct);
        }
    }

    public class NamedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult>
    {
        private readonly AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult> _methodCollectorHandler;
        private readonly AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult> _nestedAsyncResourceCollectorHandler;
        
        public NamedResource(
            AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult> methodCollectorHandler,
            AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult> nestedAsyncResourceCollectorHandler)
        {
            _methodCollectorHandler = methodCollectorHandler;
            _nestedAsyncResourceCollectorHandler = nestedAsyncResourceCollectorHandler;
        }
        
        public async Task<TResult> HandleAsync(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, TP10 p10, TP11 p11, TP12 p12, TP13 p13, CancellationToken ct)
        {
            if (!uriSegments.Any())
                throw new NotImplementedException("6");

            var tail = uriSegments.Skip(1).ToArray();

            return tail.Any()
                ? await _nestedAsyncResourceCollectorHandler(httpMethod, tail, query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, ct)
                : await _methodCollectorHandler(httpMethod, query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, ct);
        }
    }

    public class NamedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult>
    {
        private readonly AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult> _methodCollectorHandler;
        private readonly AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult> _nestedAsyncResourceCollectorHandler;
        
        public NamedResource(
            AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult> methodCollectorHandler,
            AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult> nestedAsyncResourceCollectorHandler)
        {
            _methodCollectorHandler = methodCollectorHandler;
            _nestedAsyncResourceCollectorHandler = nestedAsyncResourceCollectorHandler;
        }
        
        public async Task<TResult> HandleAsync(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, TP10 p10, TP11 p11, TP12 p12, TP13 p13, TP14 p14, CancellationToken ct)
        {
            if (!uriSegments.Any())
                throw new NotImplementedException("6");

            var tail = uriSegments.Skip(1).ToArray();

            return tail.Any()
                ? await _nestedAsyncResourceCollectorHandler(httpMethod, tail, query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, ct)
                : await _methodCollectorHandler(httpMethod, query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, ct);
        }
    }

    public class NamedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult>
    {
        private readonly AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult> _methodCollectorHandler;
        private readonly AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult> _nestedAsyncResourceCollectorHandler;
        
        public NamedResource(
            AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult> methodCollectorHandler,
            AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult> nestedAsyncResourceCollectorHandler)
        {
            _methodCollectorHandler = methodCollectorHandler;
            _nestedAsyncResourceCollectorHandler = nestedAsyncResourceCollectorHandler;
        }
        
        public async Task<TResult> HandleAsync(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, TP10 p10, TP11 p11, TP12 p12, TP13 p13, TP14 p14, TP15 p15, CancellationToken ct)
        {
            if (!uriSegments.Any())
                throw new NotImplementedException("6");

            var tail = uriSegments.Skip(1).ToArray();

            return tail.Any()
                ? await _nestedAsyncResourceCollectorHandler(httpMethod, tail, query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, ct)
                : await _methodCollectorHandler(httpMethod, query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, ct);
        }
    }

    public class NamedResource<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TResult>
    {
        private readonly AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TResult> _methodCollectorHandler;
        private readonly AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TResult> _nestedAsyncResourceCollectorHandler;
        
        public NamedResource(
            AsyncHttpMethodCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TResult> methodCollectorHandler,
            AsyncResourceCollectorHandler<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TResult> nestedAsyncResourceCollectorHandler)
        {
            _methodCollectorHandler = methodCollectorHandler;
            _nestedAsyncResourceCollectorHandler = nestedAsyncResourceCollectorHandler;
        }
        
        public async Task<TResult> HandleAsync(string httpMethod, IEnumerable<string> uriSegments, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, TP10 p10, TP11 p11, TP12 p12, TP13 p13, TP14 p14, TP15 p15, TP16 p16, CancellationToken ct)
        {
            if (!uriSegments.Any())
                throw new NotImplementedException("6");

            var tail = uriSegments.Skip(1).ToArray();

            return tail.Any()
                ? await _nestedAsyncResourceCollectorHandler(httpMethod, tail, query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, ct)
                : await _methodCollectorHandler(httpMethod, query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, ct);
        }
    }

}
