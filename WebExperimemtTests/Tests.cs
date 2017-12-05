using System;
using System.Net;
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
        
        private class Ctrlr
        {
            private readonly Responder _responder;
            private readonly int _request;
            public Ctrlr(int request, Responder resp)
            {
                _responder = resp;
                _request = request;
            }
            
            public Responder Method(int a)
            {
                Assert.AreEqual(543, _request);
                Assert.AreEqual(192, a);
                return _responder;
            }
        }
        
        private class Ctrlr2
        {
            private readonly Responder _responder;
            private readonly int _request;
            public Ctrlr2(int request, Responder resp)
            {
                _responder = resp;
                _request = request;
            }
            
            public Responder Method(string b, bool c)
            {
                Assert.AreEqual(543, _request);
                Assert.AreEqual("asdfasdfasdf", b);
                Assert.AreEqual(true, c);
                return _responder;
            }
        }
        
        [Test]
        public void TestWithAlternative()
        {
            Task ExpectedResponder(HttpListenerResponse response) => Task.FromResult(false);

            var handler = ResourceCollector
                .Root((int r) => new Ctrlr(r, ExpectedResponder),
                    get: h => h.Handle(
                        q => q.Single("a", int.Parse, 192),
                        c => c.With(r => new Ctrlr(r, ExpectedResponder)).By(a => a.Method)));

//            var uri = new Uri("http://localhost?a=192");
            var uri = new Uri("http://localhost");
            var responder = handler(543, uri, _cts.Token).Result;
            responder(null).Wait();
            Assert.AreEqual((Responder) ExpectedResponder, responder);
        }
        
        [Test]
        public void TestWithDefault()
        {
            Task ExpectedResponder(HttpListenerResponse response) => Task.FromResult(false);

            var handler = ResourceCollector
                .Root((int r) => new Ctrlr(r, ExpectedResponder),
                    get: h => h
                        .Handle(q => q.Single("a", int.Parse, 0), c => c.WithDefault().By(a => a.Method))
                        .Handle(q => q
                            .Single("b", s => s)
                            .Single("c", bool.Parse),
                            c => c.With(r => new Ctrlr2(r, ExpectedResponder)).By(a => a.Method))
                    );

            var uri = new Uri("http://localhost?b=asdfasdfasdf&c=true");
            var responder = handler(543, uri, _cts.Token).Result;
            responder(null).Wait();
            Assert.AreEqual((Responder) ExpectedResponder, responder);
        }
    }
}