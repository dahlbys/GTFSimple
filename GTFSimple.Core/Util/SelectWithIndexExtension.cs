using System;
using System.Collections.Generic;
using System.Linq;

namespace GTFSimple.Core.Util
{
    internal static class SelectWithIndexExtension
    {
        internal static SelectIndexProvider GetIndex<T>(this T element)
        {
            return default(SelectIndexProvider);
        }

        internal struct SelectIndexProvider { }

        internal static IEnumerable<TResult> SelectMany<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, SelectIndexProvider> collectionSelector,
            Func<TSource, int, TResult> resultSelector)
        {
            return source.Select(resultSelector);
        }
    }
}