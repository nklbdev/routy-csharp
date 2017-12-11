using System;
using System.Collections.Generic;
using System.Net;
using Autofac.Features.AttributeFilters;
using Service.Forms;

namespace Service.Controllers
{
    public delegate void View(HttpListenerResponse response);
    public delegate View ViewFactory();

    internal class HomeController
    {
        private static readonly List<string> Answers = new List<string>();
        
        private readonly Func<ICollection<string>, View> _indexViewFactory;
        private readonly ViewFactory _aboutViewFactory;

        public HomeController(
            [KeyFilter("Index")] Func<ICollection<string>, View> indexViewFactory,
            [KeyFilter("About")] ViewFactory aboutViewFactory)
        {
            _indexViewFactory = indexViewFactory;
            _aboutViewFactory = aboutViewFactory;
        }

        public Action<HttpListenerResponse> PostAnswer(SimpleForm form)
        {
            Answers.Add(form.Answer);
            // todo make redirect
            return Index();
        }

        public Action<HttpListenerResponse> Index() => _indexViewFactory(Answers).Invoke;

        public Action<HttpListenerResponse> About() => _aboutViewFactory().Invoke;
    }
}