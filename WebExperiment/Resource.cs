using System.Linq;
using System.Web;

namespace WebExperiment
{
    public static class Resource<TContext, TResult>
    {
        public static MainHandler<TContext, TResult> Root<TController>(
            Factory<TController> controllerFactory,
            HttpMethodCollectorFiller<TContext, TResult, TController> httpMethodCollectorFiller,
            ResourceCollectorFiller<TContext, TResult, TController> nestedResourceCollectorFiller)
        {
            var col = new ResourceCollector<TContext, TResult, TController>(controllerFactory)
                .Named(string.Empty, controllerFactory, httpMethodCollectorFiller, nestedResourceCollectorFiller);
            
            return async (method, uri, context, ct) =>
                await col.Handle(method, uri.Segments.Select(s => s.TrimStart('/')).ToArray(), HttpUtility.ParseQueryString(uri.Query), context, ct);
        }
    }
}