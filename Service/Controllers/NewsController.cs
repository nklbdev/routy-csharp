using System;
using System.Collections.Generic;
using System.Text;
using Service.Views;

namespace Service.Controllers
{
    internal class NewsController
    {
        public View Index(int page, IEnumerable<bool> order, int parsed) => r =>
        {
            var bytes = Encoding.UTF8.GetBytes($"News int page: {page}, bool order: [{string.Join(", ", order)}], parsed: {parsed}");
            using(var s = r.OutputStream)
                s.Write(bytes, 0, bytes.Length);
        };
        
        public View Add(string title, string content)
        {
            throw new NotImplementedException("11");
        }

        public View Get(int arg) => r =>
        {
            var bytes = Encoding.UTF8.GetBytes($"Concrete news page: {arg}");
            using (var s = r.OutputStream)
                s.Write(bytes, 0, bytes.Length);
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
}