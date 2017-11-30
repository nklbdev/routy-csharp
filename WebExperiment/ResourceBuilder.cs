using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace WebExperiment
{
    public enum HttpQueryType
    {
        Options,
        Get,
        Head,
        Post,
        Put,
        Patch,
        Delete,
        Trace,
        Connect
    }
    
    public static class Deserializer
    {
        public static object Deserialize(Type type, string val) { throw new NotImplementedException(); }
    }

    
    
    
    public interface IHndlr
    {
        Task<Response> Handle(ICollection<object> p, IDictionary<string, string> q, CancellationToken ct);
    }
    
    public abstract class HndlrBase : IHndlr
    {
        protected readonly Delegate Del;
        protected readonly (string Name, Type Type)[] NamesAndTypes;

        protected HndlrBase(Delegate del)
        {
            Del = del;
            NamesAndTypes = Del
                .Method
                .GetParameters()
                .Select(p => (Name: p.Name, Type: p.ParameterType))
                .ToArray();
        }

        public abstract Task<Response> Handle(ICollection<object> p, IDictionary<string, string> q, CancellationToken ct);
    }

    public class Hndlr : HndlrBase
    {
        public Hndlr(Delegate del) : base(del) { }
        
        public override Task<Response> Handle(ICollection<object> p, IDictionary<string, string> q, CancellationToken ct)
        {
            var result = (Response) Del.DynamicInvoke(p
                .Concat(NamesAndTypes
                    .Take(NamesAndTypes.Length - 1)
                    .Skip(p.Count)
                    .Select(nt => Deserializer.Deserialize(nt.Type, q[nt.Name])))
                .ToArray());
            return Task.FromResult(result);
        }
    }
    
    public class AsyncHndlr : HndlrBase
    {
        public AsyncHndlr(Delegate del) : base(del) { }
        
        public override async Task<Response> Handle(ICollection<object> p, IDictionary<string, string> q, CancellationToken ct)
        {
            return await (Task<Response>) Del.DynamicInvoke(p
                .Concat(NamesAndTypes
                    .Take(NamesAndTypes.Length - 1)
                    .Skip(p.Count)
                    .Select(nt => Deserializer.Deserialize(nt.Type, q[nt.Name])))
                .ToArray());
        }
    }

    public class AsyncCancHndlr : HndlrBase
    {
        public AsyncCancHndlr(Delegate del) : base(del) { }

        public override async Task<Response> Handle(ICollection<object> p, IDictionary<string, string> q, CancellationToken ct)
        {
            return await (Task<Response>) Del.DynamicInvoke(p
                .Concat(NamesAndTypes
                    .Take(NamesAndTypes.Length - 1)
                    .Skip(p.Count)
                    .Select(nt => Deserializer.Deserialize(nt.Type, q[nt.Name]))
                    .Concat(Enumerable.Repeat((object) ct, 1)))
                .ToArray());
        }
    }
    
    public abstract class FctHndlrBase<T> : HndlrBase
    {
        protected readonly Func<T> Factory;

        protected FctHndlrBase(Func<T> factory, Delegate del) : base(del)
        {
            Factory = factory;
        }
    }
    
    public class FctrHndlr<T> : FctHndlrBase<T>
    {
        public FctrHndlr(Func<T> factory, Delegate del) : base(factory, del) { }
        
        public override Task<Response> Handle(ICollection<object> p, IDictionary<string, string> q, CancellationToken ct)
        {
            var inst = Factory();
            var m = Del.DynamicInvoke(inst) as MethodBase;
            return Task.FromResult((Response) m.Invoke(inst, p
                .Concat(NamesAndTypes
                    .Take(NamesAndTypes.Length - 1)
                    .Skip(p.Count)
                    .Select(nt => Deserializer.Deserialize(nt.Type, q[nt.Name])))
                .ToArray()));
        }
    }
    
    public class FctrAsyncHndlr<T> : FctHndlrBase<T>
    {
        public FctrAsyncHndlr(Func<T> factory, Delegate del) : base(factory, del) { }
        
        public override async Task<Response> Handle(ICollection<object> p, IDictionary<string, string> q, CancellationToken ct)
        {
            var inst = Factory();
            var m = Del.DynamicInvoke(inst) as MethodBase;
            return await (Task<Response>) m.Invoke(inst, p
                .Concat(NamesAndTypes
                    .Take(NamesAndTypes.Length - 1)
                    .Skip(p.Count)
                    .Select(nt => Deserializer.Deserialize(nt.Type, q[nt.Name])))
                .ToArray());
        }
    }

    public class FctrAsyncCancHndlr<T> : FctHndlrBase<T>
    {
        public FctrAsyncCancHndlr(Func<T> factory, Delegate del) : base(factory, del) { }
        
        public override async Task<Response> Handle(ICollection<object> p, IDictionary<string, string> q, CancellationToken ct)
        {
            var inst = Factory();
            var m = Del.DynamicInvoke(inst) as MethodBase;
            return await (Task<Response>) m.Invoke(inst, p
                .Concat(NamesAndTypes
                    .Take(NamesAndTypes.Length - 1)
                    .Skip(p.Count)
                    .Select(nt => Deserializer.Deserialize(nt.Type, q[nt.Name]))
                    .Concat(Enumerable.Repeat((object) ct, 1)))
                .ToArray());
        }
    }

    
    
    
    public class ControllerFactorySelector<TDefaultController>
    {
        public DelegateSelector<TDefaultController> WithNothing() { throw new NotImplementedException(); }
        public SameMethodSelector<TDefaultController> WithDefault() {throw new NotImplementedException(); }
        public AlternateMethodSelector<TDefaultController, TAlternativeController> With<TAlternativeController>(Func<TAlternativeController> controllerFactory) { throw new NotImplementedException(); }
    }
    
    public class ControllerFactorySelector<TDefaultController, TP1>
    {
        public DelegateSelector<TDefaultController, TP1> WithNothing() { throw new NotImplementedException(); }
        public SameMethodSelector<TDefaultController, TP1> WithDefault() {throw new NotImplementedException(); }
        public AlternateMethodSelector<TDefaultController, TAlternativeController, TP1> With<TAlternativeController>(Func<TAlternativeController> controllerFactory) { throw new NotImplementedException(); }
    }
    
    public class ControllerFactorySelector<TDefaultController, TP1, TP2>
    {
        public DelegateSelector<TDefaultController, TP1, TP2> WithNothing() { throw new NotImplementedException(); }
        public SameMethodSelector<TDefaultController, TP1, TP2> WithDefault() {throw new NotImplementedException(); }
        public AlternateMethodSelector<TDefaultController, TAlternativeController, TP1, TP2> With<TAlternativeController>(Func<TAlternativeController> controllerFactory) { throw new NotImplementedException(); }
    }
    
    public class DelegateSelector<TDefaultController>
    {
        public ControllerFactorySelector<TDefaultController> By(Func<Response> del) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController> ByAsync(Func<Task<Response>> del) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController> ByAsyncCanc(Func<CancellationToken, Task<Response>> del) { throw new NotImplementedException(); }
    }
    
    public class DelegateSelector<TDefaultController, TP1>
    {
        public ControllerFactorySelector<TDefaultController, TP1> By(Func<TP1, Response> del) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController, TP1> ByAsync(Func<TP1, Task<Response>> del) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController, TP1> ByAsyncCanc(Func<TP1, CancellationToken, Task<Response>> del) { throw new NotImplementedException(); }
    }
    
    public class DelegateSelector<TDefaultController, TP1, TP2>
    {
        public ControllerFactorySelector<TDefaultController, TP1, TP2> By(Func<TP1, TP2, Response> del) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController, TP1, TP2> ByAsync(Func<TP1, TP2, Task<Response>> del) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController, TP1, TP2> ByAsyncCanc(Func<TP1, TP2, CancellationToken, Task<Response>> del) { throw new NotImplementedException(); }
    }
    
    public class SameMethodSelector<TDefaultController>
    {
        public ControllerFactorySelector<TDefaultController> By(Func<TDefaultController, Func<Response>> a) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController> ByAsync(Func<TDefaultController, Func<Task<Response>>> a) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController> ByAsyncCanc(Func<TDefaultController, Func<Task<Response>>> a) { throw new NotImplementedException(); }
        
        public ControllerFactorySelector<TDefaultController> By<T>(Func<TDefaultController, Func<T, Response>> a) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController> ByAsync<T>(Func<TDefaultController, Func<T, Task<Response>>> a) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController> ByAsyncCanc<T>(Func<TDefaultController, Func<T, CancellationToken, Task<Response>>> a) { throw new NotImplementedException(); }
        
        public ControllerFactorySelector<TDefaultController> By<T1, T2>(Func<TDefaultController, Func<T1, T2, Response>> a) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController> ByAsync<T1, T2>(Func<TDefaultController, Func<T1, T2, Task<Response>>> a) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController> ByAsyncCanc<T1, T2>(Func<TDefaultController, Func<T1, T2, CancellationToken, Task<Response>>> a) { throw new NotImplementedException(); }
    }
    
    public class SameMethodSelector<TDefaultController, TP1>
    {
        public ControllerFactorySelector<TDefaultController, TP1> By(Func<TDefaultController, Func<TP1, Response>> a) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController, TP1> ByAsync() { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController, TP1> ByAsyncCanc() { throw new NotImplementedException(); }
        
        public ControllerFactorySelector<TDefaultController, TP1> By<T>(Func<TDefaultController, Func<TP1, T, Response>> a) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController, TP1> ByAsync<T>(Func<TDefaultController, Func<TP1, T, Task<Response>>> a) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController, TP1> ByAsyncCanc<T>(Func<TDefaultController, Func<TP1, T, CancellationToken, Task<Response>>> a) { throw new NotImplementedException(); }
        
        public ControllerFactorySelector<TDefaultController, TP1> By<T1, T2>(Func<TDefaultController, Func<TP1, T1, T2, Response>> a) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController, TP1> ByAsync<T1, T2>(Func<TDefaultController, Func<TP1, T1, T2, Task<Response>>> a) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController, TP1> ByAsyncCanc<T1, T2>(Func<TDefaultController, Func<TP1, T1, T2, CancellationToken, Task<Response>>> a) { throw new NotImplementedException(); }
    }
    
    public class SameMethodSelector<TDefaultController, TP1, TP2>
    {
        public ControllerFactorySelector<TDefaultController, TP1, TP2> By(Func<TDefaultController, Func<TP1, TP2, Response>> a) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController, TP1, TP2> ByAsync(Func<TDefaultController, Func<TP1, TP2, Task<Response>>> a) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController, TP1, TP2> ByAsyncCanc(Func<TDefaultController, Func<TP1, TP2, CancellationToken, Task<Response>>> a) { throw new NotImplementedException(); }
        
        public ControllerFactorySelector<TDefaultController, TP1, TP2> By<T>(Func<TDefaultController, Func<TP1, TP2, T, Response>> a) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController, TP1, TP2> ByAsync<T>(Func<TDefaultController, Func<TP1, TP2, T, Task<Response>>> a) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController, TP1, TP2> ByAsyncCanc<T>(Func<TDefaultController, Func<TP1, TP2, T, CancellationToken, Task<Response>>> a) { throw new NotImplementedException(); }
        
        public ControllerFactorySelector<TDefaultController, TP1, TP2> By<T1, T2>(Func<TDefaultController, Func<TP1, TP2, T1, T2, Response>> a) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController, TP1, TP2> ByAsync<T1, T2>(Func<TDefaultController, Func<TP1, TP2, T1, T2, Task<Response>>> a) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController, TP1, TP2> ByAsyncCanc<T1, T2>(Func<TDefaultController, Func<TP1, TP2, T1, T2, CancellationToken, Task<Response>>> a) { throw new NotImplementedException(); }
    }
    
    public class AlternateMethodSelector<TDefaultController, TAlternativeController>
    {
        public ControllerFactorySelector<TDefaultController> By(Func<TAlternativeController, Func<Response>> a) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController> ByAsync(Func<TAlternativeController, Func<Task<Response>>> a) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController> ByAsyncCanc(Func<TAlternativeController, Func<CancellationToken, Task<Response>>> a) { throw new NotImplementedException(); }
        
        public ControllerFactorySelector<TDefaultController> By<TQ1>(Func<TAlternativeController, Func<TQ1, Response>> a) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController> ByAsync<TQ1>(Func<TAlternativeController, Func<TQ1, Task<Response>>> a) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController> ByAsyncCanc<TQ1>(Func<TAlternativeController, Func<TQ1, CancellationToken, Task<Response>>> a) { throw new NotImplementedException(); }
        
        public ControllerFactorySelector<TDefaultController> By<TQ1, TQ2>(Func<TAlternativeController, Func<TQ1, TQ2, Response>> a) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController> ByAsync<TQ1, TQ2>(Func<TAlternativeController, Func<TQ1, TQ2, Task<Response>>> a) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController> ByAsyncCanc<TQ1, TQ2>(Func<TAlternativeController, Func<TQ1, TQ2, CancellationToken, Task<Response>>> a) { throw new NotImplementedException(); }
    }
    
    public class AlternateMethodSelector<TDefaultController, TAlternativeController, TP1>
    {
        public ControllerFactorySelector<TDefaultController, TP1> By(Func<TAlternativeController, Func<TP1, Response>> a) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController, TP1> ByAsync(Func<TAlternativeController, Func<TP1, Task<Response>>> a) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController, TP1> ByAsyncCanc(Func<TAlternativeController, Func<TP1, CancellationToken, Task<Response>>> a) { throw new NotImplementedException(); }
        
        public ControllerFactorySelector<TDefaultController, TP1> By<TQ1>(Func<TAlternativeController, Func<TP1, TQ1, Response>> a) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController, TP1> ByAsync<TQ1>(Func<TAlternativeController, Func<TP1, TQ1, Task<Response>>> a) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController, TP1> ByAsyncCanc<TQ1>(Func<TAlternativeController, Func<TP1, TQ1, CancellationToken, Task<Response>>> a) { throw new NotImplementedException(); }
        
        public ControllerFactorySelector<TDefaultController, TP1> By<TQ1, TQ2>(Func<TAlternativeController, Func<TP1, TQ1, TQ2, Response>> a) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController, TP1> ByAsync<TQ1, TQ2>(Func<TAlternativeController, Func<TP1, TQ1, TQ2, Task<Response>>> a) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController, TP1> ByAsyncCanc<TQ1, TQ2>(Func<TAlternativeController, Func<TP1, TQ1, TQ2, CancellationToken, Task<Response>>> a) { throw new NotImplementedException(); }
    }
    
    public class AlternateMethodSelector<TDefaultController, TAlternativeController, TP1, TP2>
    {
        public ControllerFactorySelector<TDefaultController, TP1, TP2> By(Func<TAlternativeController, Func<TP1, TP2, Response>> a) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController, TP1, TP2> ByAsync(Func<TAlternativeController, Func<TP1, TP2, Task<Response>>> a) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController, TP1, TP2> ByAsyncCanc(Func<TAlternativeController, Func<TP1, TP2, CancellationToken, Task<Response>>> a) { throw new NotImplementedException(); }
        
        public ControllerFactorySelector<TDefaultController, TP1, TP2> By<TQ1>(Func<TAlternativeController, Func<TP1, TP2, TQ1, Response>> a) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController, TP1, TP2> ByAsync<TQ1>(Func<TAlternativeController, Func<TP1, TP2, TQ1, Task<Response>>> a) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController, TP1, TP2> ByAsyncCanc<TQ1>(Func<TAlternativeController, Func<TP1, TP2, TQ1, CancellationToken, Task<Response>>> a) { throw new NotImplementedException(); }
        
        public ControllerFactorySelector<TDefaultController, TP1, TP2> By<TQ1, TQ2>(Func<TAlternativeController, Func<TP1, TP2, TQ1, TQ2, Response>> a) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController, TP1, TP2> ByAsync<TQ1, TQ2>(Func<TAlternativeController, Func<TP1, TP2, TQ1, TQ2, Task<Response>>> a) { throw new NotImplementedException(); }
        public ControllerFactorySelector<TDefaultController, TP1, TP2> ByAsyncCanc<TQ1, TQ2>(Func<TAlternativeController, Func<TP1, TP2, TQ1, TQ2, CancellationToken, Task<Response>>> a) { throw new NotImplementedException(); }
    }

    public class ResourceCollector
    {
        public static ResourceBuilder<TDefaultController> Root<TDefaultController>(
            Func<TDefaultController> defaultControllerFactory,
            Func<ControllerFactorySelector<TDefaultController>, ControllerFactorySelector<TDefaultController>> options = null,
            Func<ControllerFactorySelector<TDefaultController>, ControllerFactorySelector<TDefaultController>> get = null,
            Func<ControllerFactorySelector<TDefaultController>, ControllerFactorySelector<TDefaultController>> head = null,
            Func<ControllerFactorySelector<TDefaultController>, ControllerFactorySelector<TDefaultController>> post = null,
            Func<ControllerFactorySelector<TDefaultController>, ControllerFactorySelector<TDefaultController>> put = null,
            Func<ControllerFactorySelector<TDefaultController>, ControllerFactorySelector<TDefaultController>> patch = null,
            Func<ControllerFactorySelector<TDefaultController>, ControllerFactorySelector<TDefaultController>> delete = null,
            Func<ControllerFactorySelector<TDefaultController>, ControllerFactorySelector<TDefaultController>> trace = null,
            Func<ControllerFactorySelector<TDefaultController>, ControllerFactorySelector<TDefaultController>> connect = null,
            Func<ResourceCollector<TDefaultController>, ResourceCollector<TDefaultController>> nested = null
            )
        {
            throw new NotImplementedException();
        }
    }
    
    public class ResourceCollector<TDefaultController>
    {
        
        public ResourceCollector<TDefaultController> Named(string name,
            Func<ControllerFactorySelector<TDefaultController>, ControllerFactorySelector<TDefaultController>> options = null,
            Func<ControllerFactorySelector<TDefaultController>, ControllerFactorySelector<TDefaultController>> get = null,
            Func<ControllerFactorySelector<TDefaultController>, ControllerFactorySelector<TDefaultController>> head = null,
            Func<ControllerFactorySelector<TDefaultController>, ControllerFactorySelector<TDefaultController>> post = null,
            Func<ControllerFactorySelector<TDefaultController>, ControllerFactorySelector<TDefaultController>> put = null,
            Func<ControllerFactorySelector<TDefaultController>, ControllerFactorySelector<TDefaultController>> patch = null,
            Func<ControllerFactorySelector<TDefaultController>, ControllerFactorySelector<TDefaultController>> delete = null,
            Func<ControllerFactorySelector<TDefaultController>, ControllerFactorySelector<TDefaultController>> trace = null,
            Func<ControllerFactorySelector<TDefaultController>, ControllerFactorySelector<TDefaultController>> connect = null,
            Func<ResourceCollector<TDefaultController>, ResourceCollector<TDefaultController>> nested = null
            )
        {
            throw new NotImplementedException();
        }
        
        public ResourceCollector<TDefaultController> Named<TNewDefaultController>(string name,
            Func<TNewDefaultController> newDefaultControllerFactory,
            Func<ControllerFactorySelector<TNewDefaultController>, ControllerFactorySelector<TNewDefaultController>> options = null,
            Func<ControllerFactorySelector<TNewDefaultController>, ControllerFactorySelector<TNewDefaultController>> get = null,
            Func<ControllerFactorySelector<TNewDefaultController>, ControllerFactorySelector<TNewDefaultController>> head = null,
            Func<ControllerFactorySelector<TNewDefaultController>, ControllerFactorySelector<TNewDefaultController>> post = null,
            Func<ControllerFactorySelector<TNewDefaultController>, ControllerFactorySelector<TNewDefaultController>> put = null,
            Func<ControllerFactorySelector<TNewDefaultController>, ControllerFactorySelector<TNewDefaultController>> patch = null,
            Func<ControllerFactorySelector<TNewDefaultController>, ControllerFactorySelector<TNewDefaultController>> delete = null,
            Func<ControllerFactorySelector<TNewDefaultController>, ControllerFactorySelector<TNewDefaultController>> trace = null,
            Func<ControllerFactorySelector<TNewDefaultController>, ControllerFactorySelector<TNewDefaultController>> connect = null,
            Func<ResourceCollector<TNewDefaultController>, ResourceCollector<TNewDefaultController>> nested = null
            )
        {
            throw new NotImplementedException();
        }
        
        public ResourceCollector<TDefaultController> Valued<TValue>(
            Func<ControllerFactorySelector<TDefaultController, TValue>, ControllerFactorySelector<TDefaultController, TValue>> options = null,
            Func<ControllerFactorySelector<TDefaultController, TValue>, ControllerFactorySelector<TDefaultController, TValue>> get = null,
            Func<ControllerFactorySelector<TDefaultController, TValue>, ControllerFactorySelector<TDefaultController, TValue>> head = null,
            Func<ControllerFactorySelector<TDefaultController, TValue>, ControllerFactorySelector<TDefaultController, TValue>> post = null,
            Func<ControllerFactorySelector<TDefaultController, TValue>, ControllerFactorySelector<TDefaultController, TValue>> put = null,
            Func<ControllerFactorySelector<TDefaultController, TValue>, ControllerFactorySelector<TDefaultController, TValue>> patch = null,
            Func<ControllerFactorySelector<TDefaultController, TValue>, ControllerFactorySelector<TDefaultController, TValue>> delete = null,
            Func<ControllerFactorySelector<TDefaultController, TValue>, ControllerFactorySelector<TDefaultController, TValue>> trace = null,
            Func<ControllerFactorySelector<TDefaultController, TValue>, ControllerFactorySelector<TDefaultController, TValue>> connect = null,
            Func<ResourceCollector<TDefaultController>, ResourceCollector<TDefaultController>> nested = null
            )
        {
            throw new NotImplementedException();
        }
        
        public ResourceCollector<TDefaultController> Valued<TValue, TNewDefaultController>(
            Func<TNewDefaultController> newDefaultControllerFactory,
            Func<ControllerFactorySelector<TNewDefaultController>, ControllerFactorySelector<TNewDefaultController, TValue>> options = null,
            Func<ControllerFactorySelector<TNewDefaultController>, ControllerFactorySelector<TNewDefaultController, TValue>> get = null,
            Func<ControllerFactorySelector<TNewDefaultController>, ControllerFactorySelector<TNewDefaultController, TValue>> head = null,
            Func<ControllerFactorySelector<TNewDefaultController>, ControllerFactorySelector<TNewDefaultController, TValue>> post = null,
            Func<ControllerFactorySelector<TNewDefaultController>, ControllerFactorySelector<TNewDefaultController, TValue>> put = null,
            Func<ControllerFactorySelector<TNewDefaultController>, ControllerFactorySelector<TNewDefaultController, TValue>> patch = null,
            Func<ControllerFactorySelector<TNewDefaultController>, ControllerFactorySelector<TNewDefaultController, TValue>> delete = null,
            Func<ControllerFactorySelector<TNewDefaultController>, ControllerFactorySelector<TNewDefaultController, TValue>> trace = null,
            Func<ControllerFactorySelector<TNewDefaultController>, ControllerFactorySelector<TNewDefaultController, TValue>> connect = null,
            Func<ResourceCollector<TNewDefaultController>, ResourceCollector<TDefaultController>> nested = null
            )
        {
            throw new NotImplementedException();
        }
    }
    
    public static class ResourceBuilder
    {
        public static ResourceBuilder<TH> Root<TH>(Func<TH> def)
        {
            return new ResourceBuilder<TH>(def);
        }

    }
    
    public class ResourceBuilder<TH>
    {
        public ResourceBuilder(Func<TH> def) { }

        private readonly Dictionary<HttpQueryType, List<object>> _handlerProviders = new Dictionary<HttpQueryType, List<object>>();
        private readonly IList<Resource> _resources = new List<Resource>();
        private readonly IList<IHndlr> _hndlrs = new List<IHndlr>();
        
        public Resource Build() { throw new NotImplementedException(); }

        public async Task<Response> Handle(IDictionary<string, string> q, CancellationToken ct)
        {
            foreach (var hndlr in _hndlrs.Reverse())
            {
                try
                {
                    return await hndlr.Handle(new object[] {}, q, ct);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            return null;
        }
    }
}