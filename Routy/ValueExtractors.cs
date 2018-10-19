using System.Linq;
using System.Threading;

namespace Routy
{
    public static class ValueExtractors
    {
        public static ValueExtractor<TContext, T> Context<TContext, T>(Transformer<TContext, T> parser) => (context, parameters, ct) =>
            parser(context);
        
        public static ValueExtractor<TContext, T> Single<TContext, T>(string name, Parser<T> parser) => (context, parameters, ct) =>
            parser(parameters[name]);

        public static ValueExtractor<TContext, T> Single<TContext, T>(string name, Parser<T> parser, T def) => (context, parameters, ct) =>
        {
            var str = (parameters.GetValues(name) ?? Enumerable.Empty<string>()).LastOrDefault();
            return str == null ? def : parser(str);
        };

        public static ValueExtractor<TContext, T[]> Multiple<TContext, T>(string name, Parser<T> parser) => (context, parameters, ct) =>
            (parameters.GetValues(name) ?? Enumerable.Empty<string>()).Select(x => parser(x)).ToArray();

        public static ValueExtractor<TContext, T> Object<TContext, T>(NameValueCollectionParser<T> parser) => (context, parameters, ct) =>
            parser(parameters);
        
        public static ValueExtractor<TContext, CancellationToken> CancellationToken<TContext>() => (context, parameters, ct) => ct;
    }
}