using System;
using System.Threading;
using System.Threading.Tasks;
using WebExperiment;

namespace Service.Controllers
{
    internal class NewsController
    {
        public Responder Index(int? arg1, bool? arg2)
        {
            throw new NotImplementedException();
        }
        
        public Task<Responder> IndexAsync(int arg1, bool arg2)
        {
            throw new NotImplementedException();
        }
        
        public Task<Responder> IndexAsync(int arg1, bool arg2, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
        
        public Responder Add(string arg1, string arg2)
        {
            throw new NotImplementedException();
        }

        public Responder Get(int arg)
        {
            throw new NotImplementedException();
        }

        public Responder Change(int arg1, string arg2, string arg3)
        {
            throw new NotImplementedException();
        }

        public Responder Delete(int arg)
        {
            throw new NotImplementedException();
        }
    }
}