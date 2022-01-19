using System;
using System.Collections.Generic;
using System.Linq;
using Mulinq.Linq;
using NUnit.Framework;

namespace Mulinq.Test.Linq;

public class CombineTests
{
    [Test]
    public void CombineAllTest()
    {
        const int count = 3;
        var items = Enumerable.Range(1, count);

        var expected = new List<int[]>();
        for (var a = 1; a <= count - 2; a++)
            for (var b = a + 1; b <= count - 1; b++)
                for (var c = b + 1; c <= count; c++)
                    expected.Add(new[] { a, b, c });

        var actual = items.Combine(count);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void CombineLessThanCountTest1()
    {
        const int count = 3;
        var items = Enumerable.Range(1, count);

        var expected = new List<int[]>();
        for (var a = 1; a <= count - 1; a++)
            for (var b = a + 1; b <= count; b++)
                expected.Add(new[] { a, b });

        var actual = items.Combine(2);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void CombineLessThanCountTest2()
    {
        const int count = 10;
        var items = Enumerable.Range(1, count);

        var expected = new List<int[]>();
        for (var a = 1; a <= count - 4; a++)
            for (var b = a + 1; b <= count - 3; b++)
                for (var c = b + 1; c <= count - 2; c++)
                    for (var d = c + 1; d <= count - 1; d++)
                        for (var e = d + 1; e <= count; e++)
                            expected.Add(new[] { a, b, c, d, e });

        var actual = items.Combine(5);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void NullSourceTest()
    {
        IEnumerable<int>? items = null;
        Assert.Throws<ArgumentNullException>(() => items.Combine(1));
    }

    [Test]
    public void CountOverThanCountTest()
    {
        var items = Enumerable.Range(0, 3);
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            using var e = items.Combine(4).GetEnumerator();
            while (e.MoveNext()) _ = e.Current;
        });
    }

    [Test]
    public void CountLessThanOrEquals0Test()
    {
        var items = Enumerable.Range(0, 5);
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            using var e = items.Combine(0).GetEnumerator();
            while (e.MoveNext()) _ = e.Current;
        });
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            using var e = items.Combine(-1).GetEnumerator();
            while (e.MoveNext()) _ = e.Current;
        });
    }
}