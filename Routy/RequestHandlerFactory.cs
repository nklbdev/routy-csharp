using System.Linq;
using System.Web;

namespace Routy
{
    public static class RequestHandlerFactory<TContext, TResult>
    {
        public static RequestHandler<TContext, TResult> Create<TController>(
            Provider<TController> controllerProvider,
            Mutator<HttpMethodCollector<TContext, TResult, TController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TResult, TController>> nestedResourceCollectorFiller = null
            )
        {
            var col = new ResourceCollector<TContext, TResult, TController>(controllerProvider)
                .Named(string.Empty, controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);
            
            return async (method, uri, context, ct) =>
                await col.Handle(method, uri.Segments.Select(s => s.Trim('/')).ToArray(), HttpUtility.ParseQueryString(uri.Query), context, ct);
        }

        public static RequestHandler<TContext, TResult> Create(
            Mutator<HttpMethodCollector<TContext, TResult, object>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TResult, object>> nestedResourceCollectorFiller = null
            )
        {
            var col = new ResourceCollector<TContext, TResult, object>(null)
                .Named(string.Empty, null, httpMethodCollectorFiller, nestedResourceCollectorFiller);
            
            return async (method, uri, context, ct) =>
                await col.Handle(method, uri.Segments.Select(s => s.Trim('/')).ToArray(), HttpUtility.ParseQueryString(uri.Query), context, ct);
        }
    }
}
