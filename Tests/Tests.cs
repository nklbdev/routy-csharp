// using System;
// using System.Collections.Generic;
// using System.IO;
// using System.Reflection;
// using System.Threading;
// using System.Web;
// using Newtonsoft.Json;
// using NUnit.Framework;
// using Routy;
//
// namespace Tests;
//
// [TestFixture]
// public class Tests
// {
//     private CancellationTokenSource _cts;
//
//     [SetUp]
//     public void Init()
//     {
//         _cts = new CancellationTokenSource();
//     }
//
//     private class Controller
//     {
//         private readonly Action<int> _responder;
//
//         public Controller(Action<int> resp)
//         {
//             _responder = resp;
//         }
//
//         public Action<int> Method(int a)
//         {
//             Assert.AreEqual(192, a);
//             return _responder;
//         }
//     }
//
//     private class Ctrlr2
//     {
//         private readonly Action<int> _responder;
//
//         public Ctrlr2(Action<int> resp)
//         {
//             _responder = resp;
//         }
//
//         public Action<int> Method(string s, bool b)
//         {
//             Assert.AreEqual("asdfasdfasdf", s);
//             Assert.AreEqual(true, b);
//             return _responder;
//         }
//     }
//
//     [Test]
//     public void TestWithAlternative()
//     {
//         void ExpectedResponder(int response) { }
//
//         var handler = RequestHandlerFactory<int, Action<int>>.CreateHandler(
//             () => new Controller(ExpectedResponder),
//             m => m
//                 .Method("get", q => q
//                     .Sync(p => p
//                             .Single("s", s => s)
//                             .Single("b", bool.Parse),
//                         cf => new Ctrlr2(ExpectedResponder).Method)),
//             n => n);
//
//         var uri = new Uri("http://localhost?s=asdfasdfasdf&b=true");
//         var responder = handler("get", uri, 543, _cts.Token).Result;
//         responder(100);
//         Assert.AreEqual((Action<int>) ExpectedResponder, responder);
//     }
//
//     [Test]
//     public void TestWithDefault()
//     {
//         void ExpectedResponder(int response) { }
//
//         var handler = RequestHandlerFactory<int, Action<int>>.CreateHandler(() => new Controller(ExpectedResponder),
//             m => m.Method("get", q => q.Sync(p => p.Single("a", int.Parse), cf => cf().Method)), n => n);
//
//         var uri = new Uri("http://localhost?a=192");
//         var responder = handler("get", uri, 543, _cts.Token).Result;
//         responder(100);
//         Assert.AreEqual((Action<int>) ExpectedResponder, responder);
//     }
//
//     public static Stream GenerateStreamFromString(string s)
//     {
//         var stream = new MemoryStream();
//         var writer = new StreamWriter(stream);
//         writer.Write(s);
//         writer.Flush();
//         stream.Position = 0;
//         return stream;
//     }
//
//     public class SomeEntity
//     {
//         public int IntField { get; set; }
//         public bool BoolField { get; set; }
//         public string StringField { get; set; }
//     }
//
//     public static bool HandleSomeEntity(SomeEntity entity)
//     {
//         return entity.IntField == 12 && entity.BoolField && entity.StringField == "asdf";
//     }
//
//     public static T JsonDeserialize<T>(Stream stream)
//     {
//         var serializer = new JsonSerializer();
//         using (var sr = new StreamReader(stream))
//         using (var jsonTextReader = new JsonTextReader(sr))
//             return serializer.Deserialize<T>(jsonTextReader);
//     }
//
//     private static readonly Dictionary<Type, Func<string, object>> _parsers = new Dictionary<Type, Func<string, object>>
//     {
//         [typeof(string)] = s => s,
//         [typeof(bool)] = s => bool.Parse(s),
//         [typeof(int)] = s => int.Parse(s)
//     };
//
//     public static T FormUrlencodedDeserialize<T>(Stream stream) where T : new()
//     {
//         using (var reader = new StreamReader(stream))
//         {
//             var content = reader.ReadToEnd();
//             var decodedContent = HttpUtility.UrlDecode(content);
//             var nvc = HttpUtility.ParseQueryString(decodedContent);
//             var t = new T();
//             foreach (var kvp in nvc.AllKeys)
//             {
//                 var pi = typeof(T).GetProperty(kvp, BindingFlags.Public | BindingFlags.Instance);
//                 if (pi == null)
//                     continue;
//
//                 if (_parsers.TryGetValue(pi.PropertyType, out var parser))
//                     pi.SetValue(t, parser(nvc[kvp]), null);
//                 else
//                     throw new NotImplementedException("21");
//             }
//             return t;
//         }
//     }
//
//     [Test]
//     public void TestHandleJson()
//     {
//         void ExpectedResponder(int response) { }
//
//         var handler = RequestHandlerFactory<Stream, bool>.CreateHandler(() => new Controller(ExpectedResponder),
//             m => m.Method("get", q => q
//                 .Sync(p => p
//                         .Context(JsonDeserialize<SomeEntity>),
//                     cf => HandleSomeEntity)), n => n);
//
//         var uri = new Uri("http://localhost");
//         var json = @"{
//     ""intField"": 12,
//     ""boolField"": true,
//     ""stringField"": ""asdf"",
// }";
//         var stream = GenerateStreamFromString(json);
//         var result = handler("get", uri, stream, _cts.Token).Result;
//         Assert.IsTrue(result);
//     }
//
//     [Test]
//     public void TestHandleNonMultipart()
//     {
//         void ExpectedResponder(int response) { }
//
//         var handler = RequestHandlerFactory<Stream, bool>.CreateHandler(() => new Controller(ExpectedResponder),
//             m => m.Method("get", q => q
//                 .Sync(p => p
//                         .Context(FormUrlencodedDeserialize<SomeEntity>),
//                     cf => HandleSomeEntity)), n => n);
//
//         var uri = new Uri("http://localhost");
//         var body = "IntField=12&BoolField=true&StringField=asdf";
//         var stream = GenerateStreamFromString(body);
//         var result = handler("get", uri, stream, _cts.Token).Result;
//         Assert.IsTrue(result);
//     }
// }
