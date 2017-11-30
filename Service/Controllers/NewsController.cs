using System;
using System.Threading;
using System.Threading.Tasks;
using WebExperiment;

namespace Service.Controllers
{
    internal class NewsController
    {
        public Response Index(int? arg1, bool? arg2)
        {
            throw new NotImplementedException();
        }
        
        public Task<Response> IndexAsync(int? arg1, bool? arg2)
        {
            throw new NotImplementedException();
        }
        
        public Task<Response> IndexAsync(int? arg1, bool? arg2, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
        
        public Response Add(string arg1, string arg2)
        {
            throw new NotImplementedException();
        }

        public Response Get(int arg)
        {
            throw new NotImplementedException();
        }

        public Response Change(int arg1, string arg2, string arg3)
        {
            throw new NotImplementedException();
        }

        public Response Delete(int arg)
        {
            throw new NotImplementedException();
        }
    }
}