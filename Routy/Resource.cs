using System.Linq;
using System.Web;

namespace Routy
{
    public static class Resource<TContext, TResult>
    {
        public static MainHandler<TContext, TResult> Root<TController>(
            Factory<TController> controllerFactory,
            Mutator<HttpMethodCollector<TContext, TResult, TController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TResult, TController>> nestedResourceCollectorFiller = null
            )
        {
            var col = new ResourceCollector<TContext, TResult, TController>(controllerFactory)
                .Named(string.Empty, controllerFactory, httpMethodCollectorFiller, nestedResourceCollectorFiller);
            
            return async (method, uri, context, ct) =>
                await col.Handle(method, uri.Segments.Select(s => s.Trim('/')).ToArray(), HttpUtility.ParseQueryString(uri.Query), context, ct);
        }
    }
}