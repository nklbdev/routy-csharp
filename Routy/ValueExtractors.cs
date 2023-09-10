using System;
using System.Collections.Specialized;
using System.Linq;

namespace Routy;

public static class ValueExtractors
{
    public static ValueExtractor<TContext, TContext> Context<TContext>() => (context, parameters) =>
        context;

    public static ValueExtractor<TContext, T> Context<TContext, T>(Func<TContext, T> parser) => (context, parameters) =>
        parser(context);

    public static ValueExtractor<TContext, T> Single<TContext, T>(string name, Func<string, T> parser) => (context, parameters) =>
        parser(parameters[name]);

    public static ValueExtractor<TContext, T> Single<TContext, T>(string name, Func<string, T> parser, T def) => (context, parameters) =>
    {
        var values = parameters.GetValues(name);
        return values == null || values.Length == 0 ? def : parser(values[^1]);
    };

    public static ValueExtractor<TContext, T[]> Multiple<TContext, T>(string name, Func<string, T> parser) => (context, parameters) =>
        (parameters.GetValues(name) ?? Enumerable.Empty<string>()).Select(parser).ToArray();

    public static ValueExtractor<TContext, T> Custom<TContext, T>(Func<NameValueCollection, T> parser) => (context, parameters) =>
        parser(parameters);
}
