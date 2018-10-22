using System;
using System.Collections.Specialized;
using System.Linq;
using System.Threading;

namespace Routy
{
    public static class ValueExtractors
    {
        public static ValueExtractor<TContext, TContext> Context<TContext>() => (context, parameters, ct) =>
            context;

        public static ValueExtractor<TContext, T> Context<TContext, T>(Func<TContext, T> parser) => (context, parameters, ct) =>
            parser(context);

        public static ValueExtractor<TContext, T> Context<TContext, T>(Func<TContext, CancellationToken, T> parser) => (context, parameters, ct) =>
            parser(context, ct);

        public static ValueExtractor<TContext, T> Single<TContext, T>(string name, Func<string, T> parser) => (context, parameters, ct) =>
            parser(parameters[name]);

        public static ValueExtractor<TContext, T> Single<TContext, T>(string name, Func<string, T> parser, T def) => (context, parameters, ct) =>
        {
            var str = (parameters.GetValues(name) ?? Enumerable.Empty<string>()).LastOrDefault();
            return str == null ? def : parser(str);
        };

        public static ValueExtractor<TContext, T[]> Multiple<TContext, T>(string name, Func<string, T> parser) => (context, parameters, ct) =>
            (parameters.GetValues(name) ?? Enumerable.Empty<string>()).Select(parser).ToArray();

        public static ValueExtractor<TContext, T> Custom<TContext, T>(Func<NameValueCollection, T> parser) => (context, parameters, ct) =>
            parser(parameters);
        
        public static ValueExtractor<TContext, CancellationToken> CancellationToken<TContext>() => (context, parameters, ct) => ct;
    }
}