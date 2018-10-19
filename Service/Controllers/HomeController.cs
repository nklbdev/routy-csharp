using System;
using System.Collections.Generic;
using Autofac.Features.AttributeFilters;
using Service.Forms;
using Service.Views;

namespace Service.Controllers
{
    public delegate View ViewProvider();

    internal class HomeController
    {
        private static readonly List<string> Answers = new List<string>();
        private readonly Func<ICollection<string>, View> _indexViewProvider;
        private readonly ViewProvider _aboutViewProvider;

        public HomeController(
            [KeyFilter("Index")] Func<ICollection<string>, View> indexViewProvider,
            [KeyFilter("About")] ViewProvider aboutViewProvider)
        {
            _indexViewProvider = indexViewProvider;
            _aboutViewProvider = aboutViewProvider;
        }

        public View PostAnswer(SimpleForm form)
        {
            Answers.Add(form.Answer);
            // todo make redirect
            return Index();
        }

        public View Index() => _indexViewProvider(Answers).Invoke;

        public View About() => _aboutViewProvider().Invoke;
    }
}