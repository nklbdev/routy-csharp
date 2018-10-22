using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
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
        private readonly Func<int, ICollection<string>, View> _shmindexViewProvider;
        private readonly ViewProvider _aboutViewProvider;

        public HomeController(
            [KeyFilter("Index")] Func<ICollection<string>, View> indexViewProvider,
            [KeyFilter("ShmIndex")] Func<int, ICollection<string>, View> shmindexViewProvider,
            [KeyFilter("About")] ViewProvider aboutViewProvider)
        {
            _indexViewProvider = indexViewProvider;
            _aboutViewProvider = aboutViewProvider;
            _shmindexViewProvider = shmindexViewProvider;
        }

        public View PostAnswer(SimpleForm form)
        {
            Answers.Add(form.Answer);
            // todo make redirect
            return Index();
        }

        public View Index() => _indexViewProvider(Answers).Invoke;

        public View EreIndex(HttpListenerRequest a) => _indexViewProvider(Answers).Invoke;

        public View About() => _aboutViewProvider().Invoke;
    }
}