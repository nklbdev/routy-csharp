using System;
using System.Linq;
using System.Web;

namespace Routy
{
    public static class RequestHandlerFactory<TContext, TResult>
    {
        public static AsyncRequestHandler<TContext, TResult> CreateHandler<TController>(
            Func<TController> controllerProvider,
            Mutator<HttpMethodCollector<TContext, TResult, TController>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TResult, TController>> nestedResourceCollectorFiller = null
            )
        {
            var col = new ResourceCollector<TContext, TResult, TController>(controllerProvider)
                .Named(string.Empty, controllerProvider, httpMethodCollectorFiller, nestedResourceCollectorFiller);
            
            return (method, uri, context, ct) =>
                col.HandleAsync(method, uri.Segments.Select(s => s.Trim('/')).ToArray(), HttpUtility.ParseQueryString(uri.Query), context, ct);
        }

        public static AsyncRequestHandler<TContext, TResult> CreateHandler(
            Mutator<HttpMethodCollector<TContext, TResult, object>> httpMethodCollectorFiller = null,
            Mutator<ResourceCollector<TContext, TResult, object>> nestedResourceCollectorFiller = null
            ) => CreateHandler(() => null, httpMethodCollectorFiller, nestedResourceCollectorFiller);
    }
}
