using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using HandlebarsDotNet;

namespace Service.Views
{
    internal class IndexView
    {
        private const string TemplatePath = "Templates/Index.hbs";
        private readonly Func<object, string> _renderer = Handlebars.Compile(File.ReadAllText(TemplatePath));
        
        public ICollection<string> Answers { get; set; }
        
        public void Show(HttpListenerResponse response)
        {
            var data = new {
                title = "The index page",
                body = "Hello on my first index page!",
                answers = Answers
            };
            var bytes = Encoding.UTF8.GetBytes(_renderer(data));
            response.ContentType = "text/html; charset=utf-8";
            using(var s = response.OutputStream)
                s.Write(bytes, 0, bytes.Length);
        }
    }

    internal class ShmIndexView
    {
        private const string TemplatePath = "Templates/Index.hbs";
        private readonly Func<object, string> _renderer = Handlebars.Compile(File.ReadAllText(TemplatePath));
        
        public ICollection<string> Answers { get; set; }
        public int Shm { get; set; }

        public void Show(HttpListenerResponse response)
        {
            var data = new {
                title = "The SHMindex page",
                body = $"Hello on my first index page! shmindex pinxex {Shm}",
                answers = Answers
            };
            var bytes = Encoding.UTF8.GetBytes(_renderer(data));
            response.ContentType = "text/html; charset=utf-8";
            using(var s = response.OutputStream)
                s.Write(bytes, 0, bytes.Length);
        }
    }
}