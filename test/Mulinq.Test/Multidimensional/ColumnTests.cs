using System;
using System.Collections.Generic;
using System.Linq;
using Mulinq.Multidimensional;
using NUnit.Framework;

namespace Mulinq.Test.Multidimensional;

public class ColumnTests
{
    [TestCase(1, 1)]
    [TestCase(2, 2)]
    [TestCase(3, 4)]
    [TestCase(4, 3)]
    public void ColumnTest(int r, int c)
    {
        var sut = new int[r, c];
        for (var i = 0; i < r; i++)
            for (var j = 0; j < c; j++)
                sut[i, j] = i * c + j;

        for (var i = 0; i < c; i++)
        {
            var expected = Enumerable.Range(0, r).Select(x => x * c + i).ToArray();
            var actual = sut.Column(i);
            Assert.That(actual, Is.EqualTo(expected));
        }
    }

    [TestCase(1, 1)]
    [TestCase(2, 2)]
    [TestCase(3, 4)]
    [TestCase(4, 3)]
    public void ColumnsTest(int r, int c)
    {
        var sut = new int[r, c];
        for (var i = 0; i < r; i++)
            for (var j = 0; j < c; j++)
                sut[i, j] = i * c + j;

        var all = new List<int[]>();
        for (var i = 0; i < c; i++) all.Add(Enumerable.Range(0, r).Select(x => x * c + i).ToArray());

        for (var i = 0; i < c; i++)
            for (var j = 1; i + j <= c; j++)
            {
                var expected = all.Skip(i).Take(j);
                var actual = sut.Columns(i, j);
                Assert.That(actual, Is.EqualTo(expected));
            }
    }

    [Test]
    public void ArgumentNullTest()
    {
        int[,]? sut = null;
        Assert.Throws<ArgumentNullException>(() => _ = sut.Column(0).ToArray());
        Assert.Throws<ArgumentNullException>(() => _ = sut.Columns(0, 1).ToArray());
    }

    [Test]
    public void ArgumentOutOfRangeTest()
    {
        const int n = 3;
        var sut = new int[n, n];
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = sut.Column(-1));
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = sut.Column(n));

        Assert.Throws<ArgumentOutOfRangeException>(() => _ = sut.Columns(-1, 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = sut.Columns(n, 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = sut.Columns(0, -1));
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = sut.Columns(1, n));
    }
}