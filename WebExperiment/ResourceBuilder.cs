using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace WebExperiment
{
    public delegate Task<Responder> Handler(HttpListenerRequest request);
    
    public class ResourceBuilder<TH>
    {
        public ResourceBuilder(Func<TH> def) { }

        private readonly Dictionary<HttpQueryType, List<object>> _handlerProviders = new Dictionary<HttpQueryType, List<object>>();
        private readonly IList<Resource> _resources = new List<Resource>();
        private readonly IList<IHndlr> _hndlrs = new List<IHndlr>();
        
        public Handler Build() { throw new NotImplementedException(); }

        public async Task<Responder> Handle(IDictionary<string, string> q, CancellationToken ct)
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