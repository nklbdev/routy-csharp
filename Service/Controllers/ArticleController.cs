using System;
using System.Threading;
using System.Threading.Tasks;
using Service.Views;

namespace Service.Controllers;

internal class ArticleController
{
    public View Index(int arg)
    {
        throw new NotImplementedException("37");
    }
        
    public async Task<View> IndexAsync(int arg)
    {
        throw new NotImplementedException("38");
    }
        
    public async Task<View> IndexAsync(int arg, CancellationToken ct)
    {
        throw new NotImplementedException("39");
    }

    public View Add(string arg1, string arg2)
    {
        throw new NotImplementedException("40");
    }

    public View Get(int arg)
    {
        throw new NotImplementedException("41");
    }

    public View Change(int arg1, string arg2, string arg3)
    {
        throw new NotImplementedException("42");
    }

    public View Delete(int arg)
    {
        throw new NotImplementedException("43");
    }
}
