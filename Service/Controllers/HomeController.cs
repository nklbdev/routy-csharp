using System;
using System.Collections.Generic;
using Autofac.Features.AttributeFilters;
using Service.Forms;
using Service.Views;

namespace Service.Controllers
{
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

        public View PostAnswer(SimpleForm form)
        {
            Answers.Add(form.Answer);
            // todo make redirect
            return Index();
        }

        public View Index() => _indexViewFactory(Answers).Invoke;

        public View About() => _aboutViewFactory().Invoke;
    }
}