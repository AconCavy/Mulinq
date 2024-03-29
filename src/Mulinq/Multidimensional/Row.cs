namespace Mulinq.Multidimensional;

public static partial class ArrayExtension
{
    /// <summary>
    ///     Returns the sequence of the specified row of the 2-dimensional array.
    /// </summary>
    /// <param name="source">A 2-dimensional array.</param>
    /// <param name="index">A row index.</param>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <returns>The sequence of the specified row of the 2-dimensional array.</returns>
    /// <exception cref="ArgumentNullException">source is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">index &lt; 0 or row &lt;= index.</exception>
    public static TSource[] Row<TSource>(this TSource[,]? source, int index)
    {
        if (source is null) throw new ArgumentNullException(nameof(source));
        var (row, column) = (source.GetLength(0), source.GetLength(1));
        if (index < 0 || row <= index) throw new ArgumentOutOfRangeException(nameof(index));

        TSource[] Inner()
        {
            var result = new TSource[column];
            for (var i = 0; i < column; i++) result[i] = source[index, i];
            return result;
        }

        return Inner();
    }

    /// <summary>
    ///     Returns the sequences of each row of the 2-dimensional array.
    /// </summary>
    /// <param name="source">A 2-dimensional array.</param>
    /// <param name="start">A first-row index.</param>
    /// <param name="count">A rows count.</param>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <returns>The sequences of each row of the 2-dimensional array.</returns>
    /// <exception cref="ArgumentNullException">source is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     start &lt; 0 or row &lt;= start or count &lt;= 0 or row &lt; start + count
    /// </exception>
    public static IEnumerable<TSource[]> Rows<TSource>(this TSource[,]? source, int start, int count)
    {
        if (source is null) throw new ArgumentNullException(nameof(source));
        var (row, column) = (source.GetLength(0), source.GetLength(1));
        if (start < 0 || row <= start) throw new ArgumentOutOfRangeException(nameof(start));
        if (count <= 0 || row < start + count) throw new ArgumentOutOfRangeException(nameof(count));

        IEnumerable<TSource[]> Inner()
        {
            for (var r = start; r < start + count; r++)
            {
                var result = new TSource[column];
                for (var i = 0; i < column; i++) result[i] = source[r, i];
                yield return result;
            }
        }

        return Inner();
    }
}