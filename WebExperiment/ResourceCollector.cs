using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebExperiment
{
    public static class ResourceCollector
    {
        public static Func<TRequest, Uri, CancellationToken, Task<Responder>> Root<TRequest, TDefaultController>(Func<TRequest, TDefaultController> defaultControllerFactory,
            Func<QueryDescriber<TRequest, TDefaultController>, QueryDescriber<TRequest, TDefaultController>> options = null,
            Func<QueryDescriber<TRequest, TDefaultController>, QueryDescriber<TRequest, TDefaultController>> get = null,
            Func<QueryDescriber<TRequest, TDefaultController>, QueryDescriber<TRequest, TDefaultController>> head = null,
            Func<QueryDescriber<TRequest, TDefaultController>, QueryDescriber<TRequest, TDefaultController>> post = null,
            Func<QueryDescriber<TRequest, TDefaultController>, QueryDescriber<TRequest, TDefaultController>> put = null,
            Func<QueryDescriber<TRequest, TDefaultController>, QueryDescriber<TRequest, TDefaultController>> patch = null,
            Func<QueryDescriber<TRequest, TDefaultController>, QueryDescriber<TRequest, TDefaultController>> delete = null,
            Func<QueryDescriber<TRequest, TDefaultController>, QueryDescriber<TRequest, TDefaultController>> trace = null,
            Func<QueryDescriber<TRequest, TDefaultController>, QueryDescriber<TRequest, TDefaultController>> connect = null,
            Func<ResourceCollector<TRequest, TDefaultController>, ResourceCollector<TRequest, TDefaultController>> nested = null)
        {
            var _asdf = new[]
            {
//                (HttpQueryType.Options, options),
                (HttpQueryType.Get, get)//,
//                (HttpQueryType.Head, head),
//                (HttpQueryType.Post, post),
//                (HttpQueryType.Put, put),
//                (HttpQueryType.Patch, patch),
//                (HttpQueryType.Delete, post),
//                (HttpQueryType.Trace, post),
//                (HttpQueryType.Connect, post)
            }.Select(x => (x.Item1, x.Item2(new QueryDescriber<TRequest, TDefaultController>(defaultControllerFactory)).A())).ToDictionary(x => x.Item1, x => x.Item2);

            return (request, uri, ct) => _asdf[HttpQueryType.Get](request, uri, ct);
        }
    }
    
    public class ResourceCollector<TRequest, TDefaultController>
    {
        public ResourceCollector<TRequest, TDefaultController> Named(string name,
            Func<QueryDescriber<TRequest, TDefaultController>, QueryDescriber<TRequest, TDefaultController>> options = null,
            Func<QueryDescriber<TRequest, TDefaultController>, QueryDescriber<TRequest, TDefaultController>> get = null,
            Func<QueryDescriber<TRequest, TDefaultController>, QueryDescriber<TRequest, TDefaultController>> head = null,
            Func<QueryDescriber<TRequest, TDefaultController>, QueryDescriber<TRequest, TDefaultController>> post = null,
            Func<QueryDescriber<TRequest, TDefaultController>, QueryDescriber<TRequest, TDefaultController>> put = null,
            Func<QueryDescriber<TRequest, TDefaultController>, QueryDescriber<TRequest, TDefaultController>> patch = null,
            Func<QueryDescriber<TRequest, TDefaultController>, QueryDescriber<TRequest, TDefaultController>> delete = null,
            Func<QueryDescriber<TRequest, TDefaultController>, QueryDescriber<TRequest, TDefaultController>> trace = null,
            Func<QueryDescriber<TRequest, TDefaultController>, QueryDescriber<TRequest, TDefaultController>> connect = null,
            Func<ResourceCollector<TRequest, TDefaultController>, ResourceCollector<TRequest, TDefaultController>> nested = null)
        {
            throw new NotImplementedException();
        }
        public ResourceCollector<TRequest, TDefaultController> Named<TNewDefaultController>(string name, Func<TRequest, TNewDefaultController> newDefaultControllerFactory,
            Func<QueryDescriber<TRequest, TNewDefaultController>, QueryDescriber<TRequest, TNewDefaultController>> options = null,
            Func<QueryDescriber<TRequest, TNewDefaultController>, QueryDescriber<TRequest, TNewDefaultController>> get = null,
            Func<QueryDescriber<TRequest, TNewDefaultController>, QueryDescriber<TRequest, TNewDefaultController>> head = null,
            Func<QueryDescriber<TRequest, TNewDefaultController>, QueryDescriber<TRequest, TNewDefaultController>> post = null,
            Func<QueryDescriber<TRequest, TNewDefaultController>, QueryDescriber<TRequest, TNewDefaultController>> put = null,
            Func<QueryDescriber<TRequest, TNewDefaultController>, QueryDescriber<TRequest, TNewDefaultController>> patch = null,
            Func<QueryDescriber<TRequest, TNewDefaultController>, QueryDescriber<TRequest, TNewDefaultController>> delete = null,
            Func<QueryDescriber<TRequest, TNewDefaultController>, QueryDescriber<TRequest, TNewDefaultController>> trace = null,
            Func<QueryDescriber<TRequest, TNewDefaultController>, QueryDescriber<TRequest, TNewDefaultController>> connect = null,
            Func<ResourceCollector<TRequest, TNewDefaultController>, ResourceCollector<TRequest, TNewDefaultController>> nested = null)
        {
            throw new NotImplementedException();
        }
        public ResourceCollector<TRequest, TDefaultController> Valued<TValue>(Func<string, TValue> parser,
            Func<QueryDescriber<TRequest, TDefaultController, TValue>, QueryDescriber<TRequest, TDefaultController, TValue>> options = null,
            Func<QueryDescriber<TRequest, TDefaultController, TValue>, QueryDescriber<TRequest, TDefaultController, TValue>> get = null,
            Func<QueryDescriber<TRequest, TDefaultController, TValue>, QueryDescriber<TRequest, TDefaultController, TValue>> head = null,
            Func<QueryDescriber<TRequest, TDefaultController, TValue>, QueryDescriber<TRequest, TDefaultController, TValue>> post = null,
            Func<QueryDescriber<TRequest, TDefaultController, TValue>, QueryDescriber<TRequest, TDefaultController, TValue>> put = null,
            Func<QueryDescriber<TRequest, TDefaultController, TValue>, QueryDescriber<TRequest, TDefaultController, TValue>> patch = null,
            Func<QueryDescriber<TRequest, TDefaultController, TValue>, QueryDescriber<TRequest, TDefaultController, TValue>> delete = null,
            Func<QueryDescriber<TRequest, TDefaultController, TValue>, QueryDescriber<TRequest, TDefaultController, TValue>> trace = null,
            Func<QueryDescriber<TRequest, TDefaultController, TValue>, QueryDescriber<TRequest, TDefaultController, TValue>> connect = null,
            Func<ResourceCollector<TRequest, TDefaultController, TValue>, ResourceCollector<TRequest, TDefaultController, TValue>> nested = null)
        {
            throw new NotImplementedException();
        }
        public ResourceCollector<TRequest, TDefaultController> Valued<TValue, TNewDefaultController>(Func<string, TValue> parser, Func<TRequest, TNewDefaultController> newDefaultControllerFactory,
            Func<QueryDescriber<TRequest, TNewDefaultController, TValue>, QueryDescriber<TRequest, TNewDefaultController, TValue>> options = null,
            Func<QueryDescriber<TRequest, TNewDefaultController, TValue>, QueryDescriber<TRequest, TNewDefaultController, TValue>> get = null,
            Func<QueryDescriber<TRequest, TNewDefaultController, TValue>, QueryDescriber<TRequest, TNewDefaultController, TValue>> head = null,
            Func<QueryDescriber<TRequest, TNewDefaultController, TValue>, QueryDescriber<TRequest, TNewDefaultController, TValue>> post = null,
            Func<QueryDescriber<TRequest, TNewDefaultController, TValue>, QueryDescriber<TRequest, TNewDefaultController, TValue>> put = null,
            Func<QueryDescriber<TRequest, TNewDefaultController, TValue>, QueryDescriber<TRequest, TNewDefaultController, TValue>> patch = null,
            Func<QueryDescriber<TRequest, TNewDefaultController, TValue>, QueryDescriber<TRequest, TNewDefaultController, TValue>> delete = null,
            Func<QueryDescriber<TRequest, TNewDefaultController, TValue>, QueryDescriber<TRequest, TNewDefaultController, TValue>> trace = null,
            Func<QueryDescriber<TRequest, TNewDefaultController, TValue>, QueryDescriber<TRequest, TNewDefaultController, TValue>> connect = null,
            Func<ResourceCollector<TRequest, TNewDefaultController, TValue>, ResourceCollector<TRequest, TNewDefaultController, TValue>> nested = null)
        {
            throw new NotImplementedException();
        }
    }

    public class ResourceCollector<TRequest, TDefaultController, TP1>
    {
        public ResourceCollector<TRequest, TDefaultController, TP1> Named(string name,
            Func<QueryDescriber<TRequest, TDefaultController, TP1>, QueryDescriber<TRequest, TDefaultController, TP1>> options = null,
            Func<QueryDescriber<TRequest, TDefaultController, TP1>, QueryDescriber<TRequest, TDefaultController, TP1>> get = null,
            Func<QueryDescriber<TRequest, TDefaultController, TP1>, QueryDescriber<TRequest, TDefaultController, TP1>> head = null,
            Func<QueryDescriber<TRequest, TDefaultController, TP1>, QueryDescriber<TRequest, TDefaultController, TP1>> post = null,
            Func<QueryDescriber<TRequest, TDefaultController, TP1>, QueryDescriber<TRequest, TDefaultController, TP1>> put = null,
            Func<QueryDescriber<TRequest, TDefaultController, TP1>, QueryDescriber<TRequest, TDefaultController, TP1>> patch = null,
            Func<QueryDescriber<TRequest, TDefaultController, TP1>, QueryDescriber<TRequest, TDefaultController, TP1>> delete = null,
            Func<QueryDescriber<TRequest, TDefaultController, TP1>, QueryDescriber<TRequest, TDefaultController, TP1>> trace = null,
            Func<QueryDescriber<TRequest, TDefaultController, TP1>, QueryDescriber<TRequest, TDefaultController, TP1>> connect = null,
            Func<ResourceCollector<TRequest, TDefaultController, TP1>, ResourceCollector<TRequest, TDefaultController, TP1>> nested = null)
        {
            throw new NotImplementedException();
        }
        public ResourceCollector<TRequest, TDefaultController, TP1> Named<TNewDefaultController>(string name, Func<TRequest, TNewDefaultController> newDefaultControllerFactory,
            Func<QueryDescriber<TRequest, TNewDefaultController, TP1>, QueryDescriber<TRequest, TNewDefaultController, TP1>> options = null,
            Func<QueryDescriber<TRequest, TNewDefaultController, TP1>, QueryDescriber<TRequest, TNewDefaultController, TP1>> get = null,
            Func<QueryDescriber<TRequest, TNewDefaultController, TP1>, QueryDescriber<TRequest, TNewDefaultController, TP1>> head = null,
            Func<QueryDescriber<TRequest, TNewDefaultController, TP1>, QueryDescriber<TRequest, TNewDefaultController, TP1>> post = null,
            Func<QueryDescriber<TRequest, TNewDefaultController, TP1>, QueryDescriber<TRequest, TNewDefaultController, TP1>> put = null,
            Func<QueryDescriber<TRequest, TNewDefaultController, TP1>, QueryDescriber<TRequest, TNewDefaultController, TP1>> patch = null,
            Func<QueryDescriber<TRequest, TNewDefaultController, TP1>, QueryDescriber<TRequest, TNewDefaultController, TP1>> delete = null,
            Func<QueryDescriber<TRequest, TNewDefaultController, TP1>, QueryDescriber<TRequest, TNewDefaultController, TP1>> trace = null,
            Func<QueryDescriber<TRequest, TNewDefaultController, TP1>, QueryDescriber<TRequest, TNewDefaultController, TP1>> connect = null,
            Func<ResourceCollector<TRequest, TNewDefaultController, TP1>, ResourceCollector<TRequest, TNewDefaultController, TP1>> nested = null)
        {
            throw new NotImplementedException();
        }
        public ResourceCollector<TRequest, TDefaultController, TP1> Valued<TValue>(Func<string, TValue> parser,
            Func<QueryDescriber<TRequest, TDefaultController, TP1, TValue>, QueryDescriber<TRequest, TDefaultController, TP1, TValue>> options = null,
            Func<QueryDescriber<TRequest, TDefaultController, TP1, TValue>, QueryDescriber<TRequest, TDefaultController, TP1, TValue>> get = null,
            Func<QueryDescriber<TRequest, TDefaultController, TP1, TValue>, QueryDescriber<TRequest, TDefaultController, TP1, TValue>> head = null,
            Func<QueryDescriber<TRequest, TDefaultController, TP1, TValue>, QueryDescriber<TRequest, TDefaultController, TP1, TValue>> post = null,
            Func<QueryDescriber<TRequest, TDefaultController, TP1, TValue>, QueryDescriber<TRequest, TDefaultController, TP1, TValue>> put = null,
            Func<QueryDescriber<TRequest, TDefaultController, TP1, TValue>, QueryDescriber<TRequest, TDefaultController, TP1, TValue>> patch = null,
            Func<QueryDescriber<TRequest, TDefaultController, TP1, TValue>, QueryDescriber<TRequest, TDefaultController, TP1, TValue>> delete = null,
            Func<QueryDescriber<TRequest, TDefaultController, TP1, TValue>, QueryDescriber<TRequest, TDefaultController, TP1, TValue>> trace = null,
            Func<QueryDescriber<TRequest, TDefaultController, TP1, TValue>, QueryDescriber<TRequest, TDefaultController, TP1, TValue>> connect = null,
            Func<ResourceCollector<TRequest, TDefaultController, TP1, TValue>, ResourceCollector<TRequest, TDefaultController, TP1, TValue>> nested = null)
        {
            throw new NotImplementedException();
        }
        public ResourceCollector<TRequest, TDefaultController, TP1> Valued<TValue, TNewDefaultController>(Func<TRequest, TNewDefaultController> newDefaultControllerFactory,
            Func<QueryDescriber<TRequest, TNewDefaultController, TP1, TValue>, QueryDescriber<TRequest, TNewDefaultController, TP1, TValue>> options = null,
            Func<QueryDescriber<TRequest, TNewDefaultController, TP1, TValue>, QueryDescriber<TRequest, TNewDefaultController, TP1, TValue>> get = null,
            Func<QueryDescriber<TRequest, TNewDefaultController, TP1, TValue>, QueryDescriber<TRequest, TNewDefaultController, TP1, TValue>> head = null,
            Func<QueryDescriber<TRequest, TNewDefaultController, TP1, TValue>, QueryDescriber<TRequest, TNewDefaultController, TP1, TValue>> post = null,
            Func<QueryDescriber<TRequest, TNewDefaultController, TP1, TValue>, QueryDescriber<TRequest, TNewDefaultController, TP1, TValue>> put = null,
            Func<QueryDescriber<TRequest, TNewDefaultController, TP1, TValue>, QueryDescriber<TRequest, TNewDefaultController, TP1, TValue>> patch = null,
            Func<QueryDescriber<TRequest, TNewDefaultController, TP1, TValue>, QueryDescriber<TRequest, TNewDefaultController, TP1, TValue>> delete = null,
            Func<QueryDescriber<TRequest, TNewDefaultController, TP1, TValue>, QueryDescriber<TRequest, TNewDefaultController, TP1, TValue>> trace = null,
            Func<QueryDescriber<TRequest, TNewDefaultController, TP1, TValue>, QueryDescriber<TRequest, TNewDefaultController, TP1, TValue>> connect = null,
            Func<ResourceCollector<TRequest, TNewDefaultController, TP1, TValue>, ResourceCollector<TRequest, TNewDefaultController, TP1, TValue>> nested = null)
        {
            throw new NotImplementedException();
        }
    }
    
    public class ResourceCollector<TRequest, TDefaultController, TP1, TP2>
    {
        public ResourceCollector<TRequest, TDefaultController, TP1, TP2> Named(string name,
            Func<QueryDescriber<TRequest, TDefaultController, TP1, TP2>, QueryDescriber<TRequest, TDefaultController, TP1, TP2>> options = null,
            Func<QueryDescriber<TRequest, TDefaultController, TP1, TP2>, QueryDescriber<TRequest, TDefaultController, TP1, TP2>> get = null,
            Func<QueryDescriber<TRequest, TDefaultController, TP1, TP2>, QueryDescriber<TRequest, TDefaultController, TP1, TP2>> head = null,
            Func<QueryDescriber<TRequest, TDefaultController, TP1, TP2>, QueryDescriber<TRequest, TDefaultController, TP1, TP2>> post = null,
            Func<QueryDescriber<TRequest, TDefaultController, TP1, TP2>, QueryDescriber<TRequest, TDefaultController, TP1, TP2>> put = null,
            Func<QueryDescriber<TRequest, TDefaultController, TP1, TP2>, QueryDescriber<TRequest, TDefaultController, TP1, TP2>> patch = null,
            Func<QueryDescriber<TRequest, TDefaultController, TP1, TP2>, QueryDescriber<TRequest, TDefaultController, TP1, TP2>> delete = null,
            Func<QueryDescriber<TRequest, TDefaultController, TP1, TP2>, QueryDescriber<TRequest, TDefaultController, TP1, TP2>> trace = null,
            Func<QueryDescriber<TRequest, TDefaultController, TP1, TP2>, QueryDescriber<TRequest, TDefaultController, TP1, TP2>> connect = null,
            Func<ResourceCollector<TRequest, TDefaultController, TP1, TP2>, ResourceCollector<TRequest, TDefaultController, TP1, TP2>> nested = null)
        {
            throw new NotImplementedException();
        }
        public ResourceCollector<TRequest, TDefaultController, TP1, TP2> Named<TNewDefaultController>(string name, Func<TRequest, TNewDefaultController> newDefaultControllerFactory,
            Func<QueryDescriber<TRequest, TNewDefaultController, TP1, TP2>, QueryDescriber<TRequest, TNewDefaultController, TP1, TP2>> options = null,
            Func<QueryDescriber<TRequest, TNewDefaultController, TP1, TP2>, QueryDescriber<TRequest, TNewDefaultController, TP1, TP2>> get = null,
            Func<QueryDescriber<TRequest, TNewDefaultController, TP1, TP2>, QueryDescriber<TRequest, TNewDefaultController, TP1, TP2>> head = null,
            Func<QueryDescriber<TRequest, TNewDefaultController, TP1, TP2>, QueryDescriber<TRequest, TNewDefaultController, TP1, TP2>> post = null,
            Func<QueryDescriber<TRequest, TNewDefaultController, TP1, TP2>, QueryDescriber<TRequest, TNewDefaultController, TP1, TP2>> put = null,
            Func<QueryDescriber<TRequest, TNewDefaultController, TP1, TP2>, QueryDescriber<TRequest, TNewDefaultController, TP1, TP2>> patch = null,
            Func<QueryDescriber<TRequest, TNewDefaultController, TP1, TP2>, QueryDescriber<TRequest, TNewDefaultController, TP1, TP2>> delete = null,
            Func<QueryDescriber<TRequest, TNewDefaultController, TP1, TP2>, QueryDescriber<TRequest, TNewDefaultController, TP1, TP2>> trace = null,
            Func<QueryDescriber<TRequest, TNewDefaultController, TP1, TP2>, QueryDescriber<TRequest, TNewDefaultController, TP1, TP2>> connect = null,
            Func<ResourceCollector<TRequest, TNewDefaultController, TP1, TP2>, ResourceCollector<TRequest, TNewDefaultController, TP1, TP2>> nested = null)
        {
            throw new NotImplementedException();
        }
//        public ResourceCollector<TRequest, TDefaultController, TP1> Valued<TValue>(Func<string, TValue> parser,
//            Func<QueryDescriber<TRequest, TDefaultController, TP1, TValue>, QueryDescriber<TRequest, TDefaultController, TP1, TValue>> options = null,
//            Func<QueryDescriber<TRequest, TDefaultController, TP1, TValue>, QueryDescriber<TRequest, TDefaultController, TP1, TValue>> get = null,
//            Func<QueryDescriber<TRequest, TDefaultController, TP1, TValue>, QueryDescriber<TRequest, TDefaultController, TP1, TValue>> head = null,
//            Func<QueryDescriber<TRequest, TDefaultController, TP1, TValue>, QueryDescriber<TRequest, TDefaultController, TP1, TValue>> post = null,
//            Func<QueryDescriber<TRequest, TDefaultController, TP1, TValue>, QueryDescriber<TRequest, TDefaultController, TP1, TValue>> put = null,
//            Func<QueryDescriber<TRequest, TDefaultController, TP1, TValue>, QueryDescriber<TRequest, TDefaultController, TP1, TValue>> patch = null,
//            Func<QueryDescriber<TRequest, TDefaultController, TP1, TValue>, QueryDescriber<TRequest, TDefaultController, TP1, TValue>> delete = null,
//            Func<QueryDescriber<TRequest, TDefaultController, TP1, TValue>, QueryDescriber<TRequest, TDefaultController, TP1, TValue>> trace = null,
//            Func<QueryDescriber<TRequest, TDefaultController, TP1, TValue>, QueryDescriber<TRequest, TDefaultController, TP1, TValue>> connect = null,
//            Func<ResourceCollector<TRequest, TDefaultController, TP1, TValue>, ResourceCollector<TRequest, TDefaultController, TP1, TValue>> nested = null)
//        {
//            throw new NotImplementedException();
//        }
//        public ResourceCollector<TRequest, TDefaultController, TP1> Valued<TValue, TNewDefaultController>(Func<TRequest, TNewDefaultController> newDefaultControllerFactory,
//            Func<QueryDescriber<TRequest, TNewDefaultController, TP1, TValue>, QueryDescriber<TRequest, TNewDefaultController, TP1, TValue>> options = null,
//            Func<QueryDescriber<TRequest, TNewDefaultController, TP1, TValue>, QueryDescriber<TRequest, TNewDefaultController, TP1, TValue>> get = null,
//            Func<QueryDescriber<TRequest, TNewDefaultController, TP1, TValue>, QueryDescriber<TRequest, TNewDefaultController, TP1, TValue>> head = null,
//            Func<QueryDescriber<TRequest, TNewDefaultController, TP1, TValue>, QueryDescriber<TRequest, TNewDefaultController, TP1, TValue>> post = null,
//            Func<QueryDescriber<TRequest, TNewDefaultController, TP1, TValue>, QueryDescriber<TRequest, TNewDefaultController, TP1, TValue>> put = null,
//            Func<QueryDescriber<TRequest, TNewDefaultController, TP1, TValue>, QueryDescriber<TRequest, TNewDefaultController, TP1, TValue>> patch = null,
//            Func<QueryDescriber<TRequest, TNewDefaultController, TP1, TValue>, QueryDescriber<TRequest, TNewDefaultController, TP1, TValue>> delete = null,
//            Func<QueryDescriber<TRequest, TNewDefaultController, TP1, TValue>, QueryDescriber<TRequest, TNewDefaultController, TP1, TValue>> trace = null,
//            Func<QueryDescriber<TRequest, TNewDefaultController, TP1, TValue>, QueryDescriber<TRequest, TNewDefaultController, TP1, TValue>> connect = null,
//            Func<ResourceCollector<TRequest, TNewDefaultController, TP1, TValue>, ResourceCollector<TRequest, TNewDefaultController, TP1, TValue>> nested = null)
//        {
//            throw new NotImplementedException();
//        }
    }
}




