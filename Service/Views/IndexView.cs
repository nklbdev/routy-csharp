using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HandlebarsDotNet;

namespace Service.Views;

internal class IndexView
{
    private const string TemplatePath = "Templates/Index.hbs";
    private readonly Func<object, string> _renderer = Handlebars.Compile(File.ReadAllText(TemplatePath));
        
    public ICollection<string> Answers { get; set; }
        
    public async Task ShowAsync(HttpListenerResponse response, CancellationToken ct)
    {
        var data = new {
            title = "The index page",
            body = "Hello on my first index page!",
            answers = Answers
        };
        var bytes = Encoding.UTF8.GetBytes(_renderer(data));
        response.ContentType = "text/html; charset=utf-8";
        await using var s = response.OutputStream;
        await s.WriteAsync(bytes, ct);
    }
}

internal class ShmIndexView
{
    private const string TemplatePath = "Templates/Index.hbs";
    private readonly Func<object, string> _renderer = Handlebars.Compile(File.ReadAllText(TemplatePath));
        
    public ICollection<string> Answers { get; set; }
    public int Shm { get; set; }

    public async Task ShowAsync(HttpListenerResponse response, CancellationToken ct)
    {
        var data = new {
            title = "The SHMindex page",
            body = $"Hello on my first index page! shmindex pinxex {Shm}",
            answers = Answers
        };
        var bytes = Encoding.UTF8.GetBytes(_renderer(data));
        response.ContentType = "text/html; charset=utf-8";
        await using var s = response.OutputStream;
        await s.WriteAsync(bytes, ct);
    }
}
