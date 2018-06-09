using System.Linq;
using System.Web;

namespace Routy
{
    public static class RequestHandlerFactory<TContext, TResult>
    {
        public static RequestHandler<TContext, TResult> Create<TController>(
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
