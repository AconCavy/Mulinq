using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Mulinq.Linq
{
    public static partial class EnumerableExtension
    {
        /// <summary>
        ///     Returns the sequence of accumulated values at each step.
        /// </summary>
        /// <param name="source">An IEnumerable&lt;T&gt; to accumulate over.</param>
        /// <param name="func">An accumulator function to be invoked on each element.</param>
        /// <param name="seed">An initial value.</param>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TAccumulate">The type of the accumulator value.</typeparam>
        /// <returns>The sequence of accumulated values at each step.</returns>
        /// <exception cref="ArgumentNullException">source or func is null.</exception>
        /// <code>
        /// var items = new [] { 1, 2, 3, 4, 5 };
        /// var aggregated = items.Aggregate((x, y) => x + y);
        /// var cumulated = items.Cumulate((x, y) => x + y);
        /// // var cumulated = items.Cumulate((x, y) => x + y, 0L);
        /// aggregated: 15
        /// cumulated: { 0, 1, 3, 6, 10, 15 }
        /// </code>
        public static IEnumerable<TAccumulate> Cumulate<TSource, TAccumulate>(this IEnumerable<TSource>? source,
            Func<TAccumulate, TSource, TAccumulate>? func, [MaybeNull] TAccumulate seed = default)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            if (func is null) throw new ArgumentNullException(nameof(func));

            IEnumerable<TAccumulate> Inner()
            {
                yield return seed;
                foreach (var item in source) yield return seed = func(seed, item);
            }

            return Inner();
        }

        /// <summary>
        ///     Returns the sequence of accumulated values at each step.
        /// </summary>
        /// <param name="source">An IEnumerable&lt;T&gt; to accumulate over.</param>
        /// <param name="func">An accumulator function to be invoked on each element.</param>
        /// <param name="seed">An initial value.</param>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <returns>The sequence of accumulated values at each step.</returns>
        /// <exception cref="ArgumentNullException">source or func is null.</exception>
        /// <code>
        /// var items = new [] { 1, 2, 3, 4, 5 };
        /// var aggregated = items.Aggregate((x, y) => x + y);
        /// var cumulated = items.Cumulate((x, y) => x + y);
        /// // var cumulated = items.Cumulate((x, y) => x + y, 0);
        /// aggregated: 15
        /// cumulated: { 0, 1, 3, 6, 10, 15 }
        /// </code>
        public static IEnumerable<TSource> Cumulate<TSource>(this IEnumerable<TSource>? source,
            Func<TSource, TSource, TSource>? func, [MaybeNull] TSource seed = default)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            if (func is null) throw new ArgumentNullException(nameof(func));

            IEnumerable<TSource> Inner()
            {
                yield return seed;
                foreach (var item in source) yield return seed = func(seed, item);
            }

            return Inner();
        }
    }
}