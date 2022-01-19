namespace Mulinq.Linq;

public static partial class EnumerableExtension
{
    /// <summary>
    ///     Returns the combination sequences from the original sequence. (nCr patterns).
    /// </summary>
    /// <param name="source">A sequence of values.</param>
    /// <param name="count">A number of objects selected.</param>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <returns>The combination sequences from the original sequence.</returns>
    /// <exception cref="ArgumentNullException">source is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">count &lt;= 0 or source.Count() &gt; count</exception>
    /// <code>
    /// var combination = new []{ 1, 2, 3 }.Combine(2);
    /// combination: { { 1, 2 }, { 1, 3 }, { 2, 3 } }
    /// </code>
    public static IEnumerable<IEnumerable<TSource>> Combine<TSource>(this IEnumerable<TSource>? source, int count)
    {
        if (source is null) throw new ArgumentNullException(nameof(source));

        IEnumerable<IEnumerable<TSource>> Inner()
        {
            var items = source.ToArray();
            if (count <= 0 || items.Length < count) throw new ArgumentOutOfRangeException(nameof(count));
            var n = items.Length;
            var indices = new int[n];
            for (var i = 0; i < indices.Length; i++)
            {
                indices[i] = i;
            }

            var result = new TSource[count];

            void Fill()
            {
                for (var i = 0; i < count; i++)
                {
                    result[i] = items[indices[i]];
                }
            }

            Fill();
            yield return result;
            while (true)
            {
                var done = true;
                var idx = 0;
                for (var i = count - 1; i >= 0; i--)
                {
                    if (indices[i] == i + n - count) continue;
                    idx = i;
                    done = false;
                    break;
                }

                if (done) yield break;

                indices[idx]++;
                for (var i = idx; i + 1 < count; i++)
                {
                    indices[i + 1] = indices[i] + 1;
                }

                Fill();
                yield return result;
            }
        }

        return Inner();
    }
}