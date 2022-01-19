namespace Mulinq.Linq;

public static partial class EnumerableExtension
{
    /// <summary>
    ///     Returns the permutation sequences from the original sequence. (nPr patterns).
    /// </summary>
    /// <param name="source">A sequence of values.</param>
    /// <param name="count">A number of objects selected.</param>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <returns>The permutation sequences from the original sequence.</returns>
    /// <exception cref="ArgumentNullException">source is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">count &lt;= 0 or source.Count() &gt; count</exception>
    /// <code>
    /// var permutation = new []{ 1, 2, 3 }.Permute(3);
    /// permutation: { { 1, 2, 3 }, { 1, 3, 2 }, { 2, 1, 3 }, { 2, 3, 1 }, { 3, 1, 2 }, { 3, 2, 1 } }
    /// </code>
    public static IEnumerable<IEnumerable<TSource>> Permute<TSource>(this IEnumerable<TSource>? source, int count)
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

            var cycles = new int[count];
            for (var i = 0; i < cycles.Length; i++)
            {
                cycles[i] = n - i;
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
                for (var i = count - 1; i >= 0; i--)
                {
                    cycles[i]--;
                    if (cycles[i] == 0)
                    {
                        for (var j = i; j + 1 < indices.Length; j++)
                        {
                            (indices[j], indices[j + 1]) = (indices[j + 1], indices[j]);
                        }

                        cycles[i] = n - i;
                    }
                    else
                    {
                        (indices[i], indices[^cycles[i]]) = (indices[^cycles[i]], indices[i]);
                        Fill();
                        yield return result;
                        done = false;
                        break;
                    }
                }

                if (done) yield break;
            }
        }

        return Inner();
    }
}