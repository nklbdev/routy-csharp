using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WebExperimentCodeGenerator
{
    internal static class Program
    {
        public const int MaxParameterCount = 16;
        
        public static string StripMargin(this string s)
        {
            return Regex.Replace(s, @"\n\s+\|", "\n");
        }
        
        public static string Params(int pc = 0, int qc = 0)
        {
            return string.Join(", ",
                Enumerable.Range(1, pc).Select(pn => $"TP{pn}")
                    .Concat(Enumerable.Range(1, qc).Select(qn => $"TQ{qn}")));
        }
        
        public static string Surrounded(string str, string left = "", string right = "", bool force = false)
        {
            return string.IsNullOrEmpty(str) ? "" : $"{left}{str}{right}";
        }

        public static string GenerateMethodSelector()
        {
            var classes = string.Join("\n\n", Enumerable.Range(0, MaxParameterCount + 1).Select(positionalParameterCount =>
            {
                var posParams = Surrounded(Params(positionalParameterCount), ", ");
                var methodGroups = string.Join("\n\n", Enumerable.Range(0, MaxParameterCount + 1 - positionalParameterCount).Select(queryParameterCount =>
                {
                    var qryParams = Surrounded(Params(0, queryParameterCount), "<", ">");
                    var allParams1 = Surrounded(Params(positionalParameterCount, queryParameterCount), "<", ">");
                    var allParams = Surrounded(Params(positionalParameterCount, queryParameterCount), right: ", ");
                    return positionalParameterCount + queryParameterCount < MaxParameterCount
                        ? $@"        public Some{allParams1} By{qryParams}(Func<TController, Func<{allParams}Responder>> del) {{ throw new NotImplementedException(); }}
                            |        public Some{allParams1} ByAsync{qryParams}(Func<TController, Func<{allParams}Task<Responder>>> del) {{ throw new NotImplementedException(); }}
                            |        public Some{allParams1} ByAsyncCanc{qryParams}(Func<TController, Func<{allParams}CancellationToken, Task<Responder>>> del) {{ throw new NotImplementedException(); }}".StripMargin()
                        : $@"        public Some{allParams1} By{qryParams}(Func<TController, Func<{allParams}Responder>> del) {{ throw new NotImplementedException(); }}
                            |        public Some{allParams1} ByAsync{qryParams}(Func<TController, Func<{allParams}Task<Responder>>> del) {{ throw new NotImplementedException(); }}".StripMargin();
                    }));

                return $@"    public class MethodSelector<TController{posParams}>
                         |    {{
                         |{methodGroups}
                         |    }}".StripMargin();
            }));
            
            return $@"using System;
                     |using System.Threading;
                     |using System.Threading.Tasks;
                     |
                     |namespace WebExperiment.FunctionSelectors
                     |{{
                     |{classes}
                     |}}
                     |".StripMargin();
        }
        
        public static string GenerateDelegateSelector()
        {
            var classes = string.Join("\n\n", Enumerable.Range(0, MaxParameterCount + 1).Select(positionalParameterCount =>
            {
                var posParams = Surrounded(Params(positionalParameterCount), "<", ">");
                var methodGroups = string.Join("\n\n", Enumerable.Range(0, MaxParameterCount + 1 - positionalParameterCount).Select(queryParameterCount =>
                {
                    var qryParams = Surrounded(Params(0, queryParameterCount), "<", ">");
                    var allParams = Surrounded(Params(positionalParameterCount, queryParameterCount), right: ", ");
                    return positionalParameterCount + queryParameterCount < MaxParameterCount
                        ? $@"        public Some{posParams} By{qryParams}(Func<{allParams}Responder> del) {{ throw new NotImplementedException(); }}
                            |        public Some{posParams} ByAsync{qryParams}(Func<{allParams}Task<Responder>> del) {{ throw new NotImplementedException(); }}
                            |        public Some{posParams} ByAsyncCanc{qryParams}(Func<{allParams}CancellationToken, Task<Responder>> del) {{ throw new NotImplementedException(); }}".StripMargin()
                        : $@"        public Some{posParams} By{qryParams}(Func<{allParams}Responder> del) {{ throw new NotImplementedException(); }}
                            |        public Some{posParams} ByAsync{qryParams}(Func<{allParams}Task<Responder>> del) {{ throw new NotImplementedException(); }}".StripMargin();
                    }));

                return $@"    public class DelegateSelector{posParams}
                         |    {{
                         |{methodGroups}
                         |    }}".StripMargin();
            }));
            
            return $@"using System;
                     |using System.Threading;
                     |using System.Threading.Tasks;
                     |
                     |namespace WebExperiment.FunctionSelectors
                     |{{
                     |{classes}
                     |}}
                     |".StripMargin();
        }

        public static string GenerateSome()
        {
            var classes = string.Join("\n\n", Enumerable.Range(0, MaxParameterCount + 1).Select(parameterCount =>
            {
                var allarams = Surrounded(Params(parameterCount), "<", ">");
                return $@"    public class Some{allarams}
                         |    {{
                         |    }}".StripMargin();
            }));
            
            return $@"namespace WebExperiment
                     |{{
                     |{classes}
                     |}}
                     |".StripMargin();
        }
        
        public static string GenerateControllerFactorySelector()
        {
            var classes = string.Join("\n\n", Enumerable.Range(0, MaxParameterCount + 1).Select(positionalParameterCount =>
            {
                var posParams1 = Surrounded(Params(positionalParameterCount), "<", ">");
                var posParams = Surrounded(Params(positionalParameterCount), ", ");
                return $@"    public class ControllerFactorySelector<TController{posParams}>
                         |    {{
                         |        public DelegateSelector{posParams1} WithNothing() {{ throw new NotImplementedException(); }}
                         |        public MethodSelector<TController{posParams}> WithDefault() {{ throw new NotImplementedException(); }}
                         |        public MethodSelector<TAlternativeController{posParams}> With<TAlternativeController>(Func<TAlternativeController> controllerFactory) {{ throw new NotImplementedException(); }}
                         |    }}".StripMargin();
            }));
            
            return $@"using System;
                     |using WebExperiment.FunctionSelectors;
                     |
                     |namespace WebExperiment
                     |{{
                     |{classes}
                     |}}
                     |".StripMargin();
        }

        public static string GenerateParameterCollector()
        {
            var classes = string.Join("\n\n", Enumerable.Range(0, MaxParameterCount + 1).Select(parameterCount =>
            {
                var qryParams1 = Surrounded(Params(parameterCount), "<", ">");
                var qryParams = Surrounded(Params(parameterCount), right: ", ");
                
                var methods = parameterCount < MaxParameterCount
                    ? $@"        public ParameterCollector<{qryParams}T> Single<T>(string name, Func<string, T> parser) {{ throw new NotImplementedException(); }}
                        |        public ParameterCollector<{qryParams}T> Single<T>(string name, Func<string, T> parser, T def) {{ throw new NotImplementedException(); }}
                        |        public ParameterCollector<{qryParams}T> Array<T>(string name, Func<string, T> parser) {{ throw new NotImplementedException(); }}".StripMargin()
                    : "";
                
                return $@"    public class ParameterCollector{qryParams1}
                         |    {{
                         |{methods}
                         |    }}".StripMargin();
            }));
            
            return $@"using System;
                     |
                     |namespace WebExperiment
                     |{{
                     |{classes}
                     |}}
                     |".StripMargin();
        }
        
        public static string GenerateQueryDescriber()
        {
            var classes = string.Join("\n\n", Enumerable.Range(0, MaxParameterCount + 1).Select(positionalParameterCount =>
            {
                var posParams = Surrounded(Params(positionalParameterCount), ", ");
                var methods = string.Join("\n", Enumerable.Range(0, MaxParameterCount + 1 - positionalParameterCount).Select(queryParameterCount =>
                {
                    var qryParams = Surrounded(Params(0, queryParameterCount), "<", ">");
                    var allParams = Surrounded(Params(positionalParameterCount, queryParameterCount), ", ");
                    var allParams1 = Surrounded(Params(positionalParameterCount, queryParameterCount), "<", ">");
                    return $@"        public QueryDescriber<TController{posParams}> Handle{qryParams}(Func<ParameterCollector, ParameterCollector{qryParams}> coll, Func<ControllerFactorySelector<TController{allParams}>, Some{allParams1}> c) {{ throw new NotImplementedException(); }}";
                    }));

                return $@"    public class QueryDescriber<TController{posParams}>
                         |    {{
                         |{methods}
                         |    }}".StripMargin();
            }));
            
            return $@"using System;
                     |
                     |namespace WebExperiment
                     |{{
                     |{classes}
                     |}}
                     |".StripMargin();
        }
        
        public static string GenerateResourceCollector()
        {
            throw new NotImplementedException();
        }

//        public static string GenerateResourceCollector()
//        {
//            var methods = new[] { "options", "get", "head", "post", "put", "patch", "delete", "trace", "connect" };
//            
//            
//            var classes = string.Join("\n\n", Enumerable.Range(0, MaxParameterCount + 1).Select(positionalParameterCount =>
//            {
//                var parStr = "            Func<ControllerFactorySelector<TDefaultController>, ControllerFactorySelector<TDefaultController>> %s = null";
//                var nestedStr = "            Func<ResourceCollector<TDefaultController>, ResourceCollector<TDefaultController>> nested = null";
//                methods = string.Join(",\n", methods. ([parStr % method) for method in methods] + [nestedStr]) + ")\n"
//                var a = $@"    public static class ResourceCollector
//                          |    {{
//                          |        public static ResourceBuilder<TDefaultController> Root<TDefaultController>(Func<TDefaultController> defaultControllerFactory,
//                          |{nestedStr})
//                          |        {{
//                          |            throw new NotImplementedException();
//                          |        }}
//                          |    }}".StripMargin();
////                var posParams = Surrounded(Params(positionalParameterCount), ", ");
////                return $@"    public class ControllerFactorySelector<TDefaultController{posParams}>
////                         |    {{
////                         |        public DelegateSelector<TDefaultController{posParams}> WithNothing() {{ throw new NotImplementedException(); }}
////                         |        public SameMethodSelector<TDefaultController{posParams}> WithDefault() {{ throw new NotImplementedException(); }}
////                         |        public AlternativeMethodSelector<TDefaultController, TAlternativeController{posParams}> With<TAlternativeController>(Func<TAlternativeController> controllerFactory) {{ throw new NotImplementedException(); }}
////                         |    }}".StripMargin();
//            }));
//            
//            return $@"using System;
//                     |using WebExperiment.FunctionSelectors;
//                     |
//                     |namespace WebExperiment
//                     |{{
//                     |{classes}
//                     |}}
//                     |".StripMargin();
//            return string.Empty;
//        }
        
        public static void Main(string[] args)
        {
            File.WriteAllText("../../../WebExperiment/Some.cs", GenerateSome());
            File.WriteAllText("../../../WebExperiment/QueryDescriber.cs", GenerateQueryDescriber());
            File.WriteAllText("../../../WebExperiment/ParameterCollector.cs", GenerateParameterCollector());
            File.WriteAllText("../../../WebExperiment/ControllerFactorySelector.cs", GenerateControllerFactorySelector());
            File.WriteAllText("../../../WebExperiment/FunctionSelectors/DelegateSelector.cs", GenerateDelegateSelector());
            File.WriteAllText("../../../WebExperiment/FunctionSelectors/MethodSelector.cs", GenerateMethodSelector());
        }
    }
}