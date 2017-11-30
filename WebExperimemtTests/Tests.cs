using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using WebExperiment;

namespace WebExperimemtTests
{
    [TestFixture]
    public class Tests
    {
        private CancellationTokenSource _cts;
        
        [SetUp]
        public void Init()
        {
            _cts = new CancellationTokenSource();
        }
        
        [Test]
        public void WithoutParameters()
        {
            const string content = "asdfsadf";
            Func<Response> del = () => new Response{Content = content};
            
            var a = new Hndlr(del);

            var result = a.Handle(new object[] { }, new Dictionary<string, string>(), _cts.Token).Result;
            
            Assert.NotNull(result);
            Assert.AreEqual(content, result.Content);
        }
        
        [Test]
        public void Some()
        {
            const string content = "asdfsadf";
            Func<int, int, Response> del = (a, b) => new Response{Content = (a + b).ToString()};
            
            var hndlr = new Hndlr(del);

            var result = hndlr.Handle(new object[] { }, new Dictionary<string, string>{["a"] = "3", ["b"] = "4"}, _cts.Token).Result;
            
            Assert.NotNull(result);
            Assert.AreEqual("7", result.Content);
        }
    }
}