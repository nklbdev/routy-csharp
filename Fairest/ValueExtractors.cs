using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Fairest
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

        public static ValueExtractor<TContext, IEnumerable<T>> Array<TContext, T>(string name, Parser<T> parser) => (context, parameters, ct) =>
            (parameters.GetValues(name) ?? Enumerable.Empty<string>()).Select(x => parser(x));
        
        public static ValueExtractor<TContext, CancellationToken> CancellationToken<TContext>() => (context, parameters, ct) => ct;
    }
}