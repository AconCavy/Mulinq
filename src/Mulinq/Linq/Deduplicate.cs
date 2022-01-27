namespace Mulinq.Linq;

public static partial class EnumerableExtension
{
    /// <summary>
    ///     Returns the sequence that the selector will exclude repeated values.
    /// </summary>
    /// <param name="source">A sequence of values.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the selector which needs to implement IEquatable&lt;TKey&gt;.</typeparam>
    /// <returns>The sequence that is the selector will exclude repeated values.</returns>
    /// <exception cref="ArgumentNullException">source or func is null.</exception>
    /// <code>
    /// var debup = new[] { 1, 2, 2, 3, 4, 2 }.Deduplicate(x => x);
    /// debup: { 1, 2, 3, 4, 2 }
    /// </code>
    public static IEnumerable<TSource> Deduplicate<TSource, TKey>(this IEnumerable<TSource>? source,
        Func<TSource, TKey>? selector) where TKey : IEquatable<TKey>
    {
        if (source is null) throw new ArgumentNullException(nameof(source));
        if (selector is null) throw new ArgumentNullException(nameof(selector));

        IEnumerable<TSource> Inner()
        {
            using var e = source.GetEnumerator();
            if (!e.MoveNext()) yield break;
            yield return e.Current;
            var prev = selector(e.Current);
            while (e.MoveNext())
            {
                var current = selector(e.Current);
                if (!current.Equals(prev)) yield return e.Current;
                prev = current;
            }
        }

        return Inner();
    }
}