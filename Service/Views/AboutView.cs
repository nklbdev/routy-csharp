using System;
using System.IO;
using System.Net;
using System.Text;
using HandlebarsDotNet;

namespace Service.Views
{
    internal class AboutView
    {
        private const string TemplatePath = "Templates/About.hbs";
        private readonly Func<object, string> _renderer = Handlebars.Compile(File.ReadAllText(TemplatePath));
        
        public void Show(HttpListenerResponse response)
        {
            var data = new {
                title = "The about page",
                body = "Hello on my first about page!"
            };
            var bytes = Encoding.UTF8.GetBytes(_renderer(data));
            response.ContentType = "text/html; charset=utf-8";
            using(var s = response.OutputStream)
                s.Write(bytes, 0, bytes.Length);
        }
    }
}