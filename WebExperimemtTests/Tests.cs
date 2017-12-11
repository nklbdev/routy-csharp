using System;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
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
        
        public static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static bool HandleSomeEntity(SomeEntity entity)
        {
            return entity.IntField == 12 && entity.BoolField && entity.StringField == "asdf";
        }

        public static T Deserialize<T>(Stream stream)
        {
            var serializer = new JsonSerializer();
            using (var sr = new StreamReader(stream))
            using (var jsonTextReader = new JsonTextReader(sr))
                return serializer.Deserialize<T>(jsonTextReader);
        }
        
        [Test]
        public void TestHandleJson()
        {
            void ExpectedResponder(int response) { }

            var handler = Resource<Stream, bool>.Root(() => new Ctrlr(ExpectedResponder),
                m => m.Method("get", q => q
                    .Query(p => p
                            .Context(Deserialize<SomeEntity>),
                        cf => HandleSomeEntity)), n => n);

            var uri = new Uri("http://localhost");
            var json = @"{
    ""intField"": 12,
    ""boolField"": true,
    ""stringField"": ""asdf"",
}";
            var stream = GenerateStreamFromString(json);
            var result = handler("get", uri, stream, _cts.Token).Result;
            Assert.IsTrue(result);
        }
    }

    public class SomeEntity
    {
        public int IntField { get; set; }
        public bool BoolField { get; set; }
        public string StringField { get; set; }
    }
}
