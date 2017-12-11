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
        private static List<string> Answers = new List<string>();
        
        private readonly Func<ICollection<string>, View> _indexViewFactory;
        private readonly ViewFactory _aboutViewFactory;
//        private readonly Func<string, View> _postAnswerViewFactory;

        public HomeController(
            [KeyFilter("Index")] Func<ICollection<string>, View> indexViewFactory,
            [KeyFilter("About")] ViewFactory aboutViewFactory//,
//            [KeyFilter("PostAnswer")] Func<string, View> postAnswerViewFactory
            )
        {
            _indexViewFactory = indexViewFactory;
            _aboutViewFactory = aboutViewFactory;
//            _postAnswerViewFactory = postAnswerViewFactory;
        }

//        public Action<HttpListenerResponse> PostAnswer(SimpleForm form) => _postAnswerViewFactory(form.Answer).Invoke;
        public Action<HttpListenerResponse> PostAnswer(SimpleForm form)
        {
            Answers.Add(form.Answer);
            return Index();
        }

        public Action<HttpListenerResponse> Index() => _indexViewFactory(Answers).Invoke;

        public Action<HttpListenerResponse> About() => _aboutViewFactory().Invoke;
    }
}