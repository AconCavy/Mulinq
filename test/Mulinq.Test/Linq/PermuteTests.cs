using System;
using System.Collections.Generic;
using System.Linq;
using Mulinq.Linq;
using NUnit.Framework;

namespace Mulinq.Test.Linq;

public class PermuteTests
{
    [Test]
    public void PermuteAllTest()
    {
        const int count = 3;
        var items = Enumerable.Range(1, count);

        var expected = new List<int[]>();
        for (var a = 1; a <= count; a++)
            for (var b = 1; b <= count; b++)
                for (var c = 1; c <= count; c++)
                {
                    if (a == b || b == c || c == a) continue;
                    expected.Add(new[] { a, b, c });
                }

        var actual = items.Permute(count);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void PermuteLessThanCountTest1()
    {
        const int count = 3;
        var items = Enumerable.Range(1, count);

        var expected = new List<int[]>();
        for (var a = 1; a <= count; a++)
            for (var b = 1; b <= count; b++)
            {
                if (a == b) continue;
                expected.Add(new[] { a, b });
            }

        var actual = items.Permute(2);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void PermuteLessThanCountTest2()
    {
        const int count = 10;
        var items = Enumerable.Range(1, count);

        var expected = new List<int[]>();
        for (var a = 1; a <= count; a++)
            for (var b = 1; b <= count; b++)
                for (var c = 1; c <= count; c++)
                {
                    if (a == b || b == c || c == a) continue;
                    expected.Add(new[] { a, b, c });
                }

        var actual = items.Permute(3);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void NullSourceTest()
    {
        IEnumerable<int>? items = null;
        Assert.Throws<ArgumentNullException>(() => items.Permute(1));
    }

    [Test]
    public void CountOverThanCountTest()
    {
        var items = Enumerable.Range(0, 3);
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            using var e = items.Permute(4).GetEnumerator();
            while (e.MoveNext()) _ = e.Current;
        });
    }

    [Test]
    public void CountLessThanOrEquals0Test()
    {
        var items = Enumerable.Range(0, 5);
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            using var e = items.Permute(0).GetEnumerator();
            while (e.MoveNext()) _ = e.Current;
        });
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            using var e = items.Permute(-1).GetEnumerator();
            while (e.MoveNext()) _ = e.Current;
        });
    }
}