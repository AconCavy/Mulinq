using System;
using System.Collections.Generic;

namespace Mulinq.Multidimensional
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        ///     Returns the sequence as a single dimension.
        /// </summary>
        /// <param name="source">A 2-dimensional array.</param>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <returns>The sequence as a single dimension.</returns>
        /// <exception cref="ArgumentNullException">source is null.</exception>
        public static IEnumerable<TSource> AsEnumerable<TSource>(this TSource[,]? source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            foreach (var item in source) yield return item;
        }

        /// <summary>
        ///     Returns the sequence as a single dimension.
        /// </summary>
        /// <param name="source">A 3-dimensional array.</param>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <returns>The sequence as a single dimension.</returns>
        /// <exception cref="ArgumentNullException">source is null.</exception>
        public static IEnumerable<TSource> AsEnumerable<TSource>(this TSource[,,]? source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            foreach (var item in source) yield return item;
        }
    }
}