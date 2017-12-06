using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebExperiment
{
    public static class ResourceCollector<TRequest, TResponse>
    {
        public static Func<string, Uri, TRequest, CancellationToken, Task<Responder<TResponse>>> Root<TDefaultController>(Func<TRequest, TDefaultController> defaultControllerFactory,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController>, QueryDescriber<TRequest, TResponse, TDefaultController>> options = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController>, QueryDescriber<TRequest, TResponse, TDefaultController>> get = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController>, QueryDescriber<TRequest, TResponse, TDefaultController>> head = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController>, QueryDescriber<TRequest, TResponse, TDefaultController>> post = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController>, QueryDescriber<TRequest, TResponse, TDefaultController>> put = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController>, QueryDescriber<TRequest, TResponse, TDefaultController>> patch = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController>, QueryDescriber<TRequest, TResponse, TDefaultController>> delete = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController>, QueryDescriber<TRequest, TResponse, TDefaultController>> trace = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController>, QueryDescriber<TRequest, TResponse, TDefaultController>> connect = null,
            Func<ResourceCollector<TRequest, TResponse, TDefaultController>, ResourceCollector<TRequest, TResponse, TDefaultController>> nested = null)
        {
            var _asdf = new[]
            {
                ("options", options),
                ("get", get),
                ("head", head),
                ("post", post),
                ("put", put),
                ("patch", patch),
                ("delete", post),
                ("trace", post),
                ("connect", post)
            }.Where(x => x.Item2 != null).Select(x => (x.Item1, x.Item2(new QueryDescriber<TRequest, TResponse, TDefaultController>(defaultControllerFactory)).A())).ToDictionary(x => x.Item1, x => x.Item2);

            return (method, uri, request, ct) => _asdf[method.ToLower()](request, uri, ct);
        }
    }
    
    public class ResourceCollector<TRequest, TResponse, TDefaultController>
    {
        public ResourceCollector<TRequest, TResponse, TDefaultController> Named(string name,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController>, QueryDescriber<TRequest, TResponse, TDefaultController>> options = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController>, QueryDescriber<TRequest, TResponse, TDefaultController>> get = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController>, QueryDescriber<TRequest, TResponse, TDefaultController>> head = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController>, QueryDescriber<TRequest, TResponse, TDefaultController>> post = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController>, QueryDescriber<TRequest, TResponse, TDefaultController>> put = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController>, QueryDescriber<TRequest, TResponse, TDefaultController>> patch = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController>, QueryDescriber<TRequest, TResponse, TDefaultController>> delete = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController>, QueryDescriber<TRequest, TResponse, TDefaultController>> trace = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController>, QueryDescriber<TRequest, TResponse, TDefaultController>> connect = null,
            Func<ResourceCollector<TRequest, TResponse, TDefaultController>, ResourceCollector<TRequest, TResponse, TDefaultController>> nested = null)
        {
            throw new NotImplementedException();
        }
        public ResourceCollector<TRequest, TResponse, TDefaultController> Named<TNewDefaultController>(string name, Func<TRequest, TNewDefaultController> newDefaultControllerFactory,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController>, QueryDescriber<TRequest, TResponse, TNewDefaultController>> options = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController>, QueryDescriber<TRequest, TResponse, TNewDefaultController>> get = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController>, QueryDescriber<TRequest, TResponse, TNewDefaultController>> head = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController>, QueryDescriber<TRequest, TResponse, TNewDefaultController>> post = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController>, QueryDescriber<TRequest, TResponse, TNewDefaultController>> put = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController>, QueryDescriber<TRequest, TResponse, TNewDefaultController>> patch = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController>, QueryDescriber<TRequest, TResponse, TNewDefaultController>> delete = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController>, QueryDescriber<TRequest, TResponse, TNewDefaultController>> trace = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController>, QueryDescriber<TRequest, TResponse, TNewDefaultController>> connect = null,
            Func<ResourceCollector<TRequest, TResponse, TNewDefaultController>, ResourceCollector<TRequest, TResponse, TNewDefaultController>> nested = null)
        {
            throw new NotImplementedException();
        }
        public ResourceCollector<TRequest, TResponse, TDefaultController> Valued<TValue>(Func<string, TValue> parser,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController, TValue>, QueryDescriber<TRequest, TResponse, TDefaultController, TValue>> options = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController, TValue>, QueryDescriber<TRequest, TResponse, TDefaultController, TValue>> get = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController, TValue>, QueryDescriber<TRequest, TResponse, TDefaultController, TValue>> head = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController, TValue>, QueryDescriber<TRequest, TResponse, TDefaultController, TValue>> post = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController, TValue>, QueryDescriber<TRequest, TResponse, TDefaultController, TValue>> put = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController, TValue>, QueryDescriber<TRequest, TResponse, TDefaultController, TValue>> patch = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController, TValue>, QueryDescriber<TRequest, TResponse, TDefaultController, TValue>> delete = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController, TValue>, QueryDescriber<TRequest, TResponse, TDefaultController, TValue>> trace = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController, TValue>, QueryDescriber<TRequest, TResponse, TDefaultController, TValue>> connect = null,
            Func<ResourceCollector<TRequest, TResponse, TDefaultController, TValue>, ResourceCollector<TRequest, TResponse, TDefaultController, TValue>> nested = null)
        {
            throw new NotImplementedException();
        }
        public ResourceCollector<TRequest, TResponse, TDefaultController> Valued<TValue, TNewDefaultController>(Func<string, TValue> parser, Func<TRequest, TNewDefaultController> newDefaultControllerFactory,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController, TValue>, QueryDescriber<TRequest, TResponse, TNewDefaultController, TValue>> options = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController, TValue>, QueryDescriber<TRequest, TResponse, TNewDefaultController, TValue>> get = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController, TValue>, QueryDescriber<TRequest, TResponse, TNewDefaultController, TValue>> head = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController, TValue>, QueryDescriber<TRequest, TResponse, TNewDefaultController, TValue>> post = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController, TValue>, QueryDescriber<TRequest, TResponse, TNewDefaultController, TValue>> put = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController, TValue>, QueryDescriber<TRequest, TResponse, TNewDefaultController, TValue>> patch = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController, TValue>, QueryDescriber<TRequest, TResponse, TNewDefaultController, TValue>> delete = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController, TValue>, QueryDescriber<TRequest, TResponse, TNewDefaultController, TValue>> trace = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController, TValue>, QueryDescriber<TRequest, TResponse, TNewDefaultController, TValue>> connect = null,
            Func<ResourceCollector<TRequest, TResponse, TNewDefaultController, TValue>, ResourceCollector<TRequest, TResponse, TNewDefaultController, TValue>> nested = null)
        {
            throw new NotImplementedException();
        }
    }

    public class ResourceCollector<TRequest, TResponse, TDefaultController, TP1>
    {
        public ResourceCollector<TRequest, TResponse, TDefaultController, TP1> Named(string name,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController, TP1>, QueryDescriber<TRequest, TResponse, TDefaultController, TP1>> options = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController, TP1>, QueryDescriber<TRequest, TResponse, TDefaultController, TP1>> get = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController, TP1>, QueryDescriber<TRequest, TResponse, TDefaultController, TP1>> head = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController, TP1>, QueryDescriber<TRequest, TResponse, TDefaultController, TP1>> post = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController, TP1>, QueryDescriber<TRequest, TResponse, TDefaultController, TP1>> put = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController, TP1>, QueryDescriber<TRequest, TResponse, TDefaultController, TP1>> patch = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController, TP1>, QueryDescriber<TRequest, TResponse, TDefaultController, TP1>> delete = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController, TP1>, QueryDescriber<TRequest, TResponse, TDefaultController, TP1>> trace = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController, TP1>, QueryDescriber<TRequest, TResponse, TDefaultController, TP1>> connect = null,
            Func<ResourceCollector<TRequest, TResponse, TDefaultController, TP1>, ResourceCollector<TRequest, TResponse, TDefaultController, TP1>> nested = null)
        {
            throw new NotImplementedException();
        }
        public ResourceCollector<TRequest, TResponse, TDefaultController, TP1> Named<TNewDefaultController>(string name, Func<TRequest, TNewDefaultController> newDefaultControllerFactory,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1>, QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1>> options = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1>, QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1>> get = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1>, QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1>> head = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1>, QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1>> post = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1>, QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1>> put = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1>, QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1>> patch = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1>, QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1>> delete = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1>, QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1>> trace = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1>, QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1>> connect = null,
            Func<ResourceCollector<TRequest, TResponse, TNewDefaultController, TP1>, ResourceCollector<TRequest, TResponse, TNewDefaultController, TP1>> nested = null)
        {
            throw new NotImplementedException();
        }
        public ResourceCollector<TRequest, TResponse, TDefaultController, TP1> Valued<TValue>(Func<string, TValue> parser,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController, TP1, TValue>, QueryDescriber<TRequest, TResponse, TDefaultController, TP1, TValue>> options = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController, TP1, TValue>, QueryDescriber<TRequest, TResponse, TDefaultController, TP1, TValue>> get = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController, TP1, TValue>, QueryDescriber<TRequest, TResponse, TDefaultController, TP1, TValue>> head = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController, TP1, TValue>, QueryDescriber<TRequest, TResponse, TDefaultController, TP1, TValue>> post = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController, TP1, TValue>, QueryDescriber<TRequest, TResponse, TDefaultController, TP1, TValue>> put = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController, TP1, TValue>, QueryDescriber<TRequest, TResponse, TDefaultController, TP1, TValue>> patch = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController, TP1, TValue>, QueryDescriber<TRequest, TResponse, TDefaultController, TP1, TValue>> delete = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController, TP1, TValue>, QueryDescriber<TRequest, TResponse, TDefaultController, TP1, TValue>> trace = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController, TP1, TValue>, QueryDescriber<TRequest, TResponse, TDefaultController, TP1, TValue>> connect = null,
            Func<ResourceCollector<TRequest, TResponse, TDefaultController, TP1, TValue>, ResourceCollector<TRequest, TResponse, TDefaultController, TP1, TValue>> nested = null)
        {
            throw new NotImplementedException();
        }
        public ResourceCollector<TRequest, TResponse, TDefaultController, TP1> Valued<TValue, TNewDefaultController>(Func<TRequest, TNewDefaultController> newDefaultControllerFactory,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1, TValue>, QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1, TValue>> options = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1, TValue>, QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1, TValue>> get = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1, TValue>, QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1, TValue>> head = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1, TValue>, QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1, TValue>> post = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1, TValue>, QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1, TValue>> put = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1, TValue>, QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1, TValue>> patch = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1, TValue>, QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1, TValue>> delete = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1, TValue>, QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1, TValue>> trace = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1, TValue>, QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1, TValue>> connect = null,
            Func<ResourceCollector<TRequest, TResponse, TNewDefaultController, TP1, TValue>, ResourceCollector<TRequest, TResponse, TNewDefaultController, TP1, TValue>> nested = null)
        {
            throw new NotImplementedException();
        }
    }
    
    public class ResourceCollector<TRequest, TResponse, TDefaultController, TP1, TP2>
    {
        public ResourceCollector<TRequest, TResponse, TDefaultController, TP1, TP2> Named(string name,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController, TP1, TP2>, QueryDescriber<TRequest, TResponse, TDefaultController, TP1, TP2>> options = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController, TP1, TP2>, QueryDescriber<TRequest, TResponse, TDefaultController, TP1, TP2>> get = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController, TP1, TP2>, QueryDescriber<TRequest, TResponse, TDefaultController, TP1, TP2>> head = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController, TP1, TP2>, QueryDescriber<TRequest, TResponse, TDefaultController, TP1, TP2>> post = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController, TP1, TP2>, QueryDescriber<TRequest, TResponse, TDefaultController, TP1, TP2>> put = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController, TP1, TP2>, QueryDescriber<TRequest, TResponse, TDefaultController, TP1, TP2>> patch = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController, TP1, TP2>, QueryDescriber<TRequest, TResponse, TDefaultController, TP1, TP2>> delete = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController, TP1, TP2>, QueryDescriber<TRequest, TResponse, TDefaultController, TP1, TP2>> trace = null,
            Func<QueryDescriber<TRequest, TResponse, TDefaultController, TP1, TP2>, QueryDescriber<TRequest, TResponse, TDefaultController, TP1, TP2>> connect = null,
            Func<ResourceCollector<TRequest, TResponse, TDefaultController, TP1, TP2>, ResourceCollector<TRequest, TResponse, TDefaultController, TP1, TP2>> nested = null)
        {
            throw new NotImplementedException();
        }
        public ResourceCollector<TRequest, TResponse, TDefaultController, TP1, TP2> Named<TNewDefaultController>(string name, Func<TRequest, TNewDefaultController> newDefaultControllerFactory,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1, TP2>, QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1, TP2>> options = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1, TP2>, QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1, TP2>> get = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1, TP2>, QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1, TP2>> head = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1, TP2>, QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1, TP2>> post = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1, TP2>, QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1, TP2>> put = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1, TP2>, QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1, TP2>> patch = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1, TP2>, QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1, TP2>> delete = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1, TP2>, QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1, TP2>> trace = null,
            Func<QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1, TP2>, QueryDescriber<TRequest, TResponse, TNewDefaultController, TP1, TP2>> connect = null,
            Func<ResourceCollector<TRequest, TResponse, TNewDefaultController, TP1, TP2>, ResourceCollector<TRequest, TResponse, TNewDefaultController, TP1, TP2>> nested = null)
        {
            throw new NotImplementedException();
        }
    }
}




