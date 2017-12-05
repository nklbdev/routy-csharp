using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace WebExperiment
{
    public delegate T ValueExtractor<out T>(NameValueCollection parameters);

    public static class ParValExtBldr
    {
        public static ValueExtractor<T> CreateSingle<T>(string name, Func<string, T> parser) => parameters =>
            parser(parameters[name]);

        public static ValueExtractor<T> CreateSingle<T>(string name, Func<string, T> parser, T def) => parameters =>
        {
            var str = (parameters.GetValues(name) ?? Enumerable.Empty<string>()).LastOrDefault();
            return str == null ? def : parser(str);
        };

        public static ValueExtractor<IEnumerable<T>> CreateArray<T>(string name, Func<string, T> parser) => parameters =>
            (parameters.GetValues(name) ?? Enumerable.Empty<string>()).Select(parser);
    }
    
    public class ParameterCollector
    {
        public ParameterCollector<T> Single<T>(string name, Func<string, T> parser) =>
            new ParameterCollector<T>{ P1 = ParValExtBldr.CreateSingle(name, parser)};

        public ParameterCollector<T> Single<T>(string name, Func<string, T> parser, T def) =>
            new ParameterCollector<T>{ P1 = ParValExtBldr.CreateSingle(name, parser, def)};

        public ParameterCollector<IEnumerable<T>> Array<T>(string name, Func<string, T> parser) =>
            new ParameterCollector<IEnumerable<T>>{ P1 = ParValExtBldr.CreateArray(name, parser)};
    }

    public class ParameterCollector<TP1>
    {
        public ValueExtractor<TP1> P1 { get; set; }

        public ParameterCollector<TP1, T> Single<T>(string name, Func<string, T> parser) =>
            new ParameterCollector<TP1, T>
            {
                P1 = P1,
                P2 = ParValExtBldr.CreateSingle(name, parser)
            };
        public ParameterCollector<TP1, T> Single<T>(string name, Func<string, T> parser, T def) =>
            new ParameterCollector<TP1, T>
            {
                P1 = P1,
                P2 = ParValExtBldr.CreateSingle(name, parser, def)
            };
        public ParameterCollector<TP1, IEnumerable<T>> Array<T>(string name, Func<string, T> parser) =>
            new ParameterCollector<TP1, IEnumerable<T>>
            {
                P1 = P1,
                P2 = ParValExtBldr.CreateArray(name, parser)
            };
    }

    public class ParameterCollector<TP1, TP2>
    {
        public ValueExtractor<TP1> P1 { get; set; }
        public ValueExtractor<TP2> P2 { get; set; }
    }
}
