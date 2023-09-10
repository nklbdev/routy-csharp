using System;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Service.Views;

namespace Service.Controllers;

internal class NewsIndexViewer
{
    public async Task View(HttpListenerResponse response, CancellationToken ct)
    {
        var bytes = Encoding.UTF8.GetBytes(
            $"News int page: {_page}, bool order: [{string.Join(", ", _order)}], parsed: {_parsed}, businessData: {_businessData}");
        await using var s = response.OutputStream;
        await s.WriteAsync(bytes, ct);
    }

    private readonly int _page;
    private readonly bool[] _order;
    private readonly int _parsed;
    private readonly int _businessData;

    public NewsIndexViewer(int page, bool[] order, int parsed, int businessData)
    {
        _page = page;
        _order = order;
        _parsed = parsed;
        _businessData = businessData;
    }
}

internal static class BusinessLogic
{
    private static int _state;

    public static int CriticalCall(int query)
    {
        _state += query;
        return _state;
    }
}

internal class NewsController
{
    public View Index(int page, bool[] order, int parsed)
    {
        // call business logic (it can change business state)
        // get contextual business data
        var businessData = BusinessLogic.CriticalCall(parsed);
        // return view for its data
        return new NewsIndexViewer(page, order, parsed, businessData).View;
    }

    public View Add(string title, string content)
    {
        throw new NotImplementedException("11");
    }

    public View Get(int arg) => async (r, ct) =>
    {
        var bytes = Encoding.UTF8.GetBytes($"Concrete news page: {arg}");
        await using var s = r.OutputStream;
        await s.WriteAsync(bytes, ct);
    };

    public View Change(int arg1, string arg2, string arg3)
    {
        throw new NotImplementedException("13");
    }

    public View Delete(int arg)
    {
        throw new NotImplementedException("14");
    }
}
