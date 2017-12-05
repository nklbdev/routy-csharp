using System;
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
            private readonly Responder<int> _responder;
            private readonly int _request;
            public Ctrlr(int request, Responder<int> resp)
            {
                _responder = resp;
                _request = request;
            }
            
            public Responder<int> Method(int a)
            {
                Assert.AreEqual(543, _request);
                Assert.AreEqual(192, a);
                return _responder;
            }
        }
        
        private class Ctrlr2
        {
            private readonly Responder<int> _responder;
            private readonly int _request;
            public Ctrlr2(int request, Responder<int> resp)
            {
                _responder = resp;
                _request = request;
            }
            
            public Responder<int> Method(string b, bool c)
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
            Task ExpectedResponder(int response) => Task.FromResult(false);

            var handler = ResourceCollector<int, int>
                .Root(r => new Ctrlr(r, ExpectedResponder),
                    get: h => h.Handle(q => q
                            .Single("a", int.Parse, 192),
                        c => c.With(r => new Ctrlr(r, ExpectedResponder)).By(a => a.Method)));

//            var uri = new Uri("http://localhost?a=192");
            var uri = new Uri("http://localhost");
            var responder = handler(543, uri, _cts.Token).Result;
            responder(100).Wait();
            Assert.AreEqual((Responder<int>) ExpectedResponder, responder);
        }
        
        [Test]
        public void TestWithDefault()
        {
            Task ExpectedResponder(int response) => Task.FromResult(false);

            var handler = ResourceCollector<int, int>
                .Root(r => new Ctrlr(r, ExpectedResponder),
                    get: h => h
                        .Handle(q => q
                                .Single("b", s => s)
                                .Single("c", bool.Parse),
                            c => c.With(r => new Ctrlr2(r, ExpectedResponder)).By(a => a.Method))
                        .Handle(q => q.Single("a", int.Parse, 0), c => c.WithDefault().By(a => a.Method))
                    );

            var uri = new Uri("http://localhost?b=asdfasdfasdf&c=true");
            var responder = handler(543, uri, _cts.Token).Result;
            responder(100).Wait();
            Assert.AreEqual((Responder<int>) ExpectedResponder, responder);
        }
    }
}