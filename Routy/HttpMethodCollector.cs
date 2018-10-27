using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using System.Threading.Tasks;

namespace Routy
{
    public class HttpMethodCollector<TContext, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly Dictionary<string, QueryCollector<TContext, TResult, TController>> _queryCollectors = new Dictionary<string, QueryCollector<TContext, TResult, TController>>();

        public HttpMethodCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }
        
        public HttpMethodCollector<TContext, TResult, TController> Method(
            string method,
            Mutator<QueryCollector<TContext, TResult, TController>> filler)
        {
            _queryCollectors[method] = filler(new QueryCollector<TContext, TResult, TController>(_controllerProvider));
            return this;
        }
        
        public async Task<TResult> Handle(string httpMethod, NameValueCollection query, TContext context, CancellationToken ct)
        {
            if (_queryCollectors.TryGetValue(httpMethod.ToLower(), out var queryCollector))
                return await queryCollector.Handle(query, context, ct);
            throw new NotImplementedException("23");
        }
    }

    public class HttpMethodCollector<TContext, TP1, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly Dictionary<string, QueryCollector<TContext, TP1, TResult, TController>> _queryCollectors = new Dictionary<string, QueryCollector<TContext, TP1, TResult, TController>>();

        public HttpMethodCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }
        
        public HttpMethodCollector<TContext, TP1, TResult, TController> Method(
            string method,
            Mutator<QueryCollector<TContext, TP1, TResult, TController>> filler)
        {
            _queryCollectors[method] = filler(new QueryCollector<TContext, TP1, TResult, TController>(_controllerProvider));
            return this;
        }
        
        public async Task<TResult> Handle(string httpMethod, NameValueCollection query, TContext context, TP1 p1, CancellationToken ct)
        {
            if (_queryCollectors.TryGetValue(httpMethod.ToLower(), out var queryCollector))
                return await queryCollector.Handle(query, context, p1, ct);
            throw new NotImplementedException("23");
        }
    }

    public class HttpMethodCollector<TContext, TP1, TP2, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly Dictionary<string, QueryCollector<TContext, TP1, TP2, TResult, TController>> _queryCollectors = new Dictionary<string, QueryCollector<TContext, TP1, TP2, TResult, TController>>();

        public HttpMethodCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }
        
        public HttpMethodCollector<TContext, TP1, TP2, TResult, TController> Method(
            string method,
            Mutator<QueryCollector<TContext, TP1, TP2, TResult, TController>> filler)
        {
            _queryCollectors[method] = filler(new QueryCollector<TContext, TP1, TP2, TResult, TController>(_controllerProvider));
            return this;
        }
        
        public async Task<TResult> Handle(string httpMethod, NameValueCollection query, TContext context, TP1 p1, TP2 p2, CancellationToken ct)
        {
            if (_queryCollectors.TryGetValue(httpMethod.ToLower(), out var queryCollector))
                return await queryCollector.Handle(query, context, p1, p2, ct);
            throw new NotImplementedException("23");
        }
    }

    public class HttpMethodCollector<TContext, TP1, TP2, TP3, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly Dictionary<string, QueryCollector<TContext, TP1, TP2, TP3, TResult, TController>> _queryCollectors = new Dictionary<string, QueryCollector<TContext, TP1, TP2, TP3, TResult, TController>>();

        public HttpMethodCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }
        
        public HttpMethodCollector<TContext, TP1, TP2, TP3, TResult, TController> Method(
            string method,
            Mutator<QueryCollector<TContext, TP1, TP2, TP3, TResult, TController>> filler)
        {
            _queryCollectors[method] = filler(new QueryCollector<TContext, TP1, TP2, TP3, TResult, TController>(_controllerProvider));
            return this;
        }
        
        public async Task<TResult> Handle(string httpMethod, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, CancellationToken ct)
        {
            if (_queryCollectors.TryGetValue(httpMethod.ToLower(), out var queryCollector))
                return await queryCollector.Handle(query, context, p1, p2, p3, ct);
            throw new NotImplementedException("23");
        }
    }

    public class HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly Dictionary<string, QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController>> _queryCollectors = new Dictionary<string, QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController>>();

        public HttpMethodCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }
        
        public HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController> Method(
            string method,
            Mutator<QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController>> filler)
        {
            _queryCollectors[method] = filler(new QueryCollector<TContext, TP1, TP2, TP3, TP4, TResult, TController>(_controllerProvider));
            return this;
        }
        
        public async Task<TResult> Handle(string httpMethod, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, CancellationToken ct)
        {
            if (_queryCollectors.TryGetValue(httpMethod.ToLower(), out var queryCollector))
                return await queryCollector.Handle(query, context, p1, p2, p3, p4, ct);
            throw new NotImplementedException("23");
        }
    }

    public class HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly Dictionary<string, QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController>> _queryCollectors = new Dictionary<string, QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController>>();

        public HttpMethodCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }
        
        public HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController> Method(
            string method,
            Mutator<QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController>> filler)
        {
            _queryCollectors[method] = filler(new QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TResult, TController>(_controllerProvider));
            return this;
        }
        
        public async Task<TResult> Handle(string httpMethod, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, CancellationToken ct)
        {
            if (_queryCollectors.TryGetValue(httpMethod.ToLower(), out var queryCollector))
                return await queryCollector.Handle(query, context, p1, p2, p3, p4, p5, ct);
            throw new NotImplementedException("23");
        }
    }

    public class HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly Dictionary<string, QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController>> _queryCollectors = new Dictionary<string, QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController>>();

        public HttpMethodCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }
        
        public HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController> Method(
            string method,
            Mutator<QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController>> filler)
        {
            _queryCollectors[method] = filler(new QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TResult, TController>(_controllerProvider));
            return this;
        }
        
        public async Task<TResult> Handle(string httpMethod, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, CancellationToken ct)
        {
            if (_queryCollectors.TryGetValue(httpMethod.ToLower(), out var queryCollector))
                return await queryCollector.Handle(query, context, p1, p2, p3, p4, p5, p6, ct);
            throw new NotImplementedException("23");
        }
    }

    public class HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly Dictionary<string, QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController>> _queryCollectors = new Dictionary<string, QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController>>();

        public HttpMethodCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }
        
        public HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController> Method(
            string method,
            Mutator<QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController>> filler)
        {
            _queryCollectors[method] = filler(new QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TResult, TController>(_controllerProvider));
            return this;
        }
        
        public async Task<TResult> Handle(string httpMethod, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, CancellationToken ct)
        {
            if (_queryCollectors.TryGetValue(httpMethod.ToLower(), out var queryCollector))
                return await queryCollector.Handle(query, context, p1, p2, p3, p4, p5, p6, p7, ct);
            throw new NotImplementedException("23");
        }
    }

    public class HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly Dictionary<string, QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController>> _queryCollectors = new Dictionary<string, QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController>>();

        public HttpMethodCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }
        
        public HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController> Method(
            string method,
            Mutator<QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController>> filler)
        {
            _queryCollectors[method] = filler(new QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TResult, TController>(_controllerProvider));
            return this;
        }
        
        public async Task<TResult> Handle(string httpMethod, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, CancellationToken ct)
        {
            if (_queryCollectors.TryGetValue(httpMethod.ToLower(), out var queryCollector))
                return await queryCollector.Handle(query, context, p1, p2, p3, p4, p5, p6, p7, p8, ct);
            throw new NotImplementedException("23");
        }
    }

    public class HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly Dictionary<string, QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController>> _queryCollectors = new Dictionary<string, QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController>>();

        public HttpMethodCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }
        
        public HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController> Method(
            string method,
            Mutator<QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController>> filler)
        {
            _queryCollectors[method] = filler(new QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TResult, TController>(_controllerProvider));
            return this;
        }
        
        public async Task<TResult> Handle(string httpMethod, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, CancellationToken ct)
        {
            if (_queryCollectors.TryGetValue(httpMethod.ToLower(), out var queryCollector))
                return await queryCollector.Handle(query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, ct);
            throw new NotImplementedException("23");
        }
    }

    public class HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly Dictionary<string, QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController>> _queryCollectors = new Dictionary<string, QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController>>();

        public HttpMethodCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }
        
        public HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController> Method(
            string method,
            Mutator<QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController>> filler)
        {
            _queryCollectors[method] = filler(new QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TResult, TController>(_controllerProvider));
            return this;
        }
        
        public async Task<TResult> Handle(string httpMethod, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, TP10 p10, CancellationToken ct)
        {
            if (_queryCollectors.TryGetValue(httpMethod.ToLower(), out var queryCollector))
                return await queryCollector.Handle(query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, ct);
            throw new NotImplementedException("23");
        }
    }

    public class HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly Dictionary<string, QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController>> _queryCollectors = new Dictionary<string, QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController>>();

        public HttpMethodCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }
        
        public HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController> Method(
            string method,
            Mutator<QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController>> filler)
        {
            _queryCollectors[method] = filler(new QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TResult, TController>(_controllerProvider));
            return this;
        }
        
        public async Task<TResult> Handle(string httpMethod, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, TP10 p10, TP11 p11, CancellationToken ct)
        {
            if (_queryCollectors.TryGetValue(httpMethod.ToLower(), out var queryCollector))
                return await queryCollector.Handle(query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, ct);
            throw new NotImplementedException("23");
        }
    }

    public class HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly Dictionary<string, QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController>> _queryCollectors = new Dictionary<string, QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController>>();

        public HttpMethodCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }
        
        public HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController> Method(
            string method,
            Mutator<QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController>> filler)
        {
            _queryCollectors[method] = filler(new QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TResult, TController>(_controllerProvider));
            return this;
        }
        
        public async Task<TResult> Handle(string httpMethod, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, TP10 p10, TP11 p11, TP12 p12, CancellationToken ct)
        {
            if (_queryCollectors.TryGetValue(httpMethod.ToLower(), out var queryCollector))
                return await queryCollector.Handle(query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, ct);
            throw new NotImplementedException("23");
        }
    }

    public class HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly Dictionary<string, QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController>> _queryCollectors = new Dictionary<string, QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController>>();

        public HttpMethodCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }
        
        public HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController> Method(
            string method,
            Mutator<QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController>> filler)
        {
            _queryCollectors[method] = filler(new QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TResult, TController>(_controllerProvider));
            return this;
        }
        
        public async Task<TResult> Handle(string httpMethod, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, TP10 p10, TP11 p11, TP12 p12, TP13 p13, CancellationToken ct)
        {
            if (_queryCollectors.TryGetValue(httpMethod.ToLower(), out var queryCollector))
                return await queryCollector.Handle(query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, ct);
            throw new NotImplementedException("23");
        }
    }

    public class HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly Dictionary<string, QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TController>> _queryCollectors = new Dictionary<string, QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TController>>();

        public HttpMethodCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }
        
        public HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TController> Method(
            string method,
            Mutator<QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TController>> filler)
        {
            _queryCollectors[method] = filler(new QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TResult, TController>(_controllerProvider));
            return this;
        }
        
        public async Task<TResult> Handle(string httpMethod, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, TP10 p10, TP11 p11, TP12 p12, TP13 p13, TP14 p14, CancellationToken ct)
        {
            if (_queryCollectors.TryGetValue(httpMethod.ToLower(), out var queryCollector))
                return await queryCollector.Handle(query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, ct);
            throw new NotImplementedException("23");
        }
    }

    public class HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly Dictionary<string, QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult, TController>> _queryCollectors = new Dictionary<string, QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult, TController>>();

        public HttpMethodCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }
        
        public HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult, TController> Method(
            string method,
            Mutator<QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult, TController>> filler)
        {
            _queryCollectors[method] = filler(new QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TResult, TController>(_controllerProvider));
            return this;
        }
        
        public async Task<TResult> Handle(string httpMethod, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, TP10 p10, TP11 p11, TP12 p12, TP13 p13, TP14 p14, TP15 p15, CancellationToken ct)
        {
            if (_queryCollectors.TryGetValue(httpMethod.ToLower(), out var queryCollector))
                return await queryCollector.Handle(query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, ct);
            throw new NotImplementedException("23");
        }
    }

    public class HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TResult, TController>
    {
        private readonly Func<TController> _controllerProvider;
        private readonly Dictionary<string, QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TResult, TController>> _queryCollectors = new Dictionary<string, QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TResult, TController>>();

        public HttpMethodCollector(Func<TController> controllerProvider)
        {
            _controllerProvider = controllerProvider;
        }
        
        public HttpMethodCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TResult, TController> Method(
            string method,
            Mutator<QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TResult, TController>> filler)
        {
            _queryCollectors[method] = filler(new QueryCollector<TContext, TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, TResult, TController>(_controllerProvider));
            return this;
        }
        
        public async Task<TResult> Handle(string httpMethod, NameValueCollection query, TContext context, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, TP6 p6, TP7 p7, TP8 p8, TP9 p9, TP10 p10, TP11 p11, TP12 p12, TP13 p13, TP14 p14, TP15 p15, TP16 p16, CancellationToken ct)
        {
            if (_queryCollectors.TryGetValue(httpMethod.ToLower(), out var queryCollector))
                return await queryCollector.Handle(query, context, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, ct);
            throw new NotImplementedException("23");
        }
    }

}