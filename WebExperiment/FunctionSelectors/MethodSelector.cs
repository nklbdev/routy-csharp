using System;
using System.Threading;
using System.Threading.Tasks;

namespace WebExperiment.FunctionSelectors
{
    public class MethodSelector<TRequest, TController>
    {
        private readonly Func<TRequest, TController> _factory;
        
        public MethodSelector(Func<TRequest, TController> factory)
        {
            _factory = factory;
        }

        public Func<TRequest, CancellationToken, Task<Responder>> By(Func<TController, Func<Responder>> del) => (r, ct) => Task.FromResult(del(_factory(r))());
        public Func<TRequest, CancellationToken, Task<Responder>> ByAsync(Func<TController, Func<Task<Responder>>> del) => async (r, ct) => await del(_factory(r))();
        public Func<TRequest, CancellationToken, Task<Responder>> ByAsyncCanc(Func<TController, Func<CancellationToken, Task<Responder>>> del) => async (r, ct) => await del(_factory(r))(ct);
        
        public Func<TRequest, TQ1, CancellationToken, Task<Responder>> By<TQ1>(Func<TController, Func<TQ1, Responder>> del) => (r, q1, ct) => Task.FromResult(del(_factory(r))(q1));
        public Func<TRequest, TQ1, CancellationToken, Task<Responder>> ByAsync<TQ1>(Func<TController, Func<TQ1, Task<Responder>>> del) => async (r, q1, ct) => await del(_factory(r))(q1);
        public Func<TRequest, TQ1, CancellationToken, Task<Responder>> ByAsyncCanc<TQ1>(Func<TController, Func<TQ1, CancellationToken, Task<Responder>>> del) => async (r, q1, ct) => await del(_factory(r))(q1, ct);
    }

    public class MethodSelector<TRequest, TController, TP1>
    {
        private readonly Func<TRequest, TController> _factory;
        
        public MethodSelector(Func<TRequest, TController> factory)
        {
            _factory = factory;
        }
        
        public Func<TRequest, TP1, CancellationToken, Task<Responder>> By(Func<TController, Func<TP1, Responder>> del) => (r, p1, ct) => Task.FromResult(del(_factory(r))(p1));
        public Func<TRequest, TP1, CancellationToken, Task<Responder>> ByAsync(Func<TController, Func<TP1, Task<Responder>>> del) => async (r, p1, ct) => await del(_factory(r))(p1);
        public Func<TRequest, TP1, CancellationToken, Task<Responder>> ByAsyncCanc(Func<TController, Func<TP1, CancellationToken, Task<Responder>>> del) => async (r, p1, ct) => await del(_factory(r))(p1, ct);
        
        public Func<TRequest, TP1, TQ1, CancellationToken, Task<Responder>> By<TQ1>(Func<TController, Func<TP1, TQ1, Responder>> del) => (r, p1, q1, ct) => Task.FromResult(del(_factory(r))(p1, q1));
        public Func<TRequest, TP1, TQ1, CancellationToken, Task<Responder>> ByAsync<TQ1>(Func<TController, Func<TP1, TQ1, Task<Responder>>> del) => async (r, p1, q1, ct) => await del(_factory(r))(p1, q1);
        public Func<TRequest, TP1, TQ1, CancellationToken, Task<Responder>> ByAsyncCanc<TQ1>(Func<TController, Func<TP1, TQ1, CancellationToken, Task<Responder>>> del) => async (r, p1, q1, ct) => await del(_factory(r))(p1, q1, ct);
    }
    
    public class MethodSelector<TRequest, TController, TP1, TP2>
    {
        private readonly Func<TRequest, TController> _factory;
        
        public MethodSelector(Func<TRequest, TController> factory)
        {
            _factory = factory;
        }
        
        public Func<TRequest, TP1, TP2, CancellationToken, Task<Responder>> By(Func<TController, Func<TP1, TP2, Responder>> del) => (r, p1, p2, ct) => Task.FromResult(del(_factory(r))(p1, p2));
        public Func<TRequest, TP1, TP2, CancellationToken, Task<Responder>> ByAsync(Func<TController, Func<TP1, TP2, Task<Responder>>> del) => async (r, p1, p2, ct) => await del(_factory(r))(p1, p2);
        public Func<TRequest, TP1, TP2, CancellationToken, Task<Responder>> ByAsyncCanc(Func<TController, Func<TP1, TP2, CancellationToken, Task<Responder>>> del) => async (r, p1, p2, ct) => await del(_factory(r))(p1, p2, ct);
        
        public Func<TRequest, TP1, TP2, TQ1, CancellationToken, Task<Responder>> By<TQ1>(Func<TController, Func<TP1, TP2, TQ1, Responder>> del) => (r, p1, p2, q1, ct) => Task.FromResult(del(_factory(r))(p1, p2, q1));
        public Func<TRequest, TP1, TP2, TQ1, CancellationToken, Task<Responder>> ByAsync<TQ1>(Func<TController, Func<TP1, TP2, TQ1, Task<Responder>>> del) => async (r, p1, p2, q1, ct) => await del(_factory(r))(p1, p2, q1);
        public Func<TRequest, TP1, TP2, TQ1, CancellationToken, Task<Responder>> ByAsyncCanc<TQ1>(Func<TController, Func<TP1, TP2, TQ1, CancellationToken, Task<Responder>>> del) => async (r, p1, p2, q1, ct) => await del(_factory(r))(p1, p2, q1, ct);
    }
    
    public class MethodSelector<TRequest, TController, TP1, TP2, TP3>
    {
        private readonly Func<TRequest, TController> _factory;
        
        public MethodSelector(Func<TRequest, TController> factory)
        {
            _factory = factory;
        }
        
        public Func<TRequest, TP1, TP2, TP3, CancellationToken, Task<Responder>> By(Func<TController, Func<TP1, TP2, TP3, Responder>> del) => (r, p1, p2, p3, ct) => Task.FromResult(del(_factory(r))(p1, p2, p3));
        public Func<TRequest, TP1, TP2, TP3, CancellationToken, Task<Responder>> ByAsync(Func<TController, Func<TP1, TP2, TP3, Task<Responder>>> del) => async (r, p1, p2, p3, ct) => await del(_factory(r))(p1, p2, p3);
        public Func<TRequest, TP1, TP2, TP3, CancellationToken, Task<Responder>> ByAsyncCanc(Func<TController, Func<TP1, TP2, TP3, CancellationToken, Task<Responder>>> del) => async (r, p1, p2, p3, ct) => await del(_factory(r))(p1, p2, p3, ct);
        
        public Func<TRequest, TP1, TP2, TP3, TQ1, CancellationToken, Task<Responder>> By<TQ1>(Func<TController, Func<TP1, TP2, TP3, TQ1, Responder>> del) => (r, p1, p2, p3, q1, ct) => Task.FromResult(del(_factory(r))(p1, p2, p3, q1));
        public Func<TRequest, TP1, TP2, TP3, TQ1, CancellationToken, Task<Responder>> ByAsync<TQ1>(Func<TController, Func<TP1, TP2, TP3, TQ1, Task<Responder>>> del) => async (r, p1, p2, p3, q1, ct) => await del(_factory(r))(p1, p2, p3, q1);
        public Func<TRequest, TP1, TP2, TP3, TQ1, CancellationToken, Task<Responder>> ByAsyncCanc<TQ1>(Func<TController, Func<TP1, TP2, TP3, TQ1, CancellationToken, Task<Responder>>> del) => async (r, p1, p2, p3, q1, ct) => await del(_factory(r))(p1, p2, p3, q1, ct);
    }
}
