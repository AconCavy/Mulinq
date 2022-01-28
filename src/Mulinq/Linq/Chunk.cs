namespace Mulinq.Linq;

public static partial class EnumerableExtension
{
    /// <summary>
    ///     Returns sequences that split by specified size.
    /// </summary>
    /// <param name="source">A sequence of values.</param>
    /// <param name="size">Size of each sequence after splitting.</param>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <returns>The sequences that split by specified size.</returns>
    /// <exception cref="ArgumentNullException">source is null.</exception>
    /// <exception cref="ArgumentException">size &lt;= 0</exception>
    public static IEnumerable<TSource[]> Chunk<TSource>(this IEnumerable<TSource>? source, int size)
    {
        if (source is null) throw new ArgumentNullException(nameof(source));
        if (size <= 0) throw new ArgumentException(nameof(size));

        IEnumerable<TSource[]> Inner()
        {
            var idx = 0;
            var result = new TSource[size];
            foreach (var x in source)
            {
                result[idx++] = x;
                if (idx != size) continue;
                yield return result;
                result = new TSource[size];
                idx %= size;
            }

            if (idx > 0) yield return result[..idx];
        }

        return Inner();
    }
}