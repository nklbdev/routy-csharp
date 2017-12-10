using System;
using System.Threading;
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
            private readonly System.Action<int> _responder;
            
            public Ctrlr(System.Action<int> resp)
            {
                _responder = resp;
            }
            
            public System.Action<int> Method(int a)
            {
                Assert.AreEqual(192, a);
                return _responder;
            }
        }
        
        private class Ctrlr2
        {
            private readonly System.Action<int> _responder;
            
            public Ctrlr2(System.Action<int> resp)
            {
                _responder = resp;
            }
            
            public System.Action<int> Method(string s, bool b)
            {
                Assert.AreEqual("asdfasdfasdf", s);
                Assert.AreEqual(true, b);
                return _responder;
            }
        }
        
        [Test]
        public void TestWithAlternative()
        {
            void ExpectedResponder(int response) { }

            var handler = Resource<int, System.Action<int>>.Root(
                () => new Ctrlr(ExpectedResponder),
                m => m
                    .Method("get", q => q
                        .Query(p => p
                                .Single("s", s => s)
                                .Single("b", bool.Parse),
                            cf => new Ctrlr2(ExpectedResponder).Method)),
                n => n);

//            var uri = new Uri("http://localhost?a=192");
            var uri = new Uri("http://localhost?s=asdfasdfasdf&b=true");
            var responder = handler("get", uri, 543, _cts.Token).Result;
            responder(100);
            Assert.AreEqual((System.Action<int>) ExpectedResponder, responder);
        }
        
        [Test]
        public void TestWithDefault()
        {
            void ExpectedResponder(int response) { }

            var handler = Resource<int, System.Action<int>>.Root(() => new Ctrlr(ExpectedResponder),
                m => m.Method("get", q => q.Query(p => p.Single("a", int.Parse), cf => cf().Method)), n => n);

            var uri = new Uri("http://localhost?a=192");
            var responder = handler("get", uri, 543, _cts.Token).Result;
            responder(100);
            Assert.AreEqual((System.Action<int>) ExpectedResponder, responder);
        }
    }
}