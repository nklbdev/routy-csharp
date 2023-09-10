using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HandlebarsDotNet;

namespace Service.Views;

internal class AboutView
{
    private const string TemplatePath = "Templates/About.hbs";
    private readonly Func<object, string> _renderer = Handlebars.Compile(File.ReadAllText(TemplatePath));
        
    public async Task ShowAsync(HttpListenerResponse response, CancellationToken ct)
    {
        var data = new {
            title = "The about page",
            body = "Hello on my first about page!"
        };
        var bytes = Encoding.UTF8.GetBytes(_renderer(data));
        response.ContentType = "text/html; charset=utf-8";
        await using var s = response.OutputStream;
        await s.WriteAsync(bytes, ct);
    }
}
