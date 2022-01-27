using Mulinq.Multidimensional;
using NUnit.Framework;

namespace Mulinq.Test.Multidimensional;

public class RowTests
{
    [TestCase(1, 1)]
    [TestCase(2, 2)]
    [TestCase(3, 4)]
    [TestCase(4, 3)]
    public void RowTest(int r, int c)
    {
        var sut = new int[r, c];
        for (var i = 0; i < r; i++)
            for (var j = 0; j < c; j++)
                sut[i, j] = i * c + j;

        for (var i = 0; i < r; i++)
        {
            var expected = Enumerable.Range(i * c, c).ToArray();
            var actual = sut.Row(i);
            Assert.That(actual, Is.EqualTo(expected));
        }
    }

    [TestCase(1, 1)]
    [TestCase(2, 2)]
    [TestCase(3, 4)]
    [TestCase(4, 3)]
    public void RowsTest(int r, int c)
    {
        var sut = new int[r, c];
        for (var i = 0; i < r; i++)
            for (var j = 0; j < c; j++)
                sut[i, j] = i * c + j;

        var all = new List<int[]>();
        for (var i = 0; i < r; i++) all.Add(Enumerable.Range(i * c, c).ToArray());

        for (var i = 0; i < r; i++)
            for (var j = 1; i + j <= r; j++)
            {
                var expected = all.Skip(i).Take(j);
                var actual = sut.Rows(i, j);
                Assert.That(actual, Is.EqualTo(expected));
            }
    }

    [Test]
    public void ArgumentNullTest()
    {
        int[,]? sut = null;
        Assert.Throws<ArgumentNullException>(() => _ = sut.Row(0));
        Assert.Throws<ArgumentNullException>(() => _ = sut.Rows(0, 1).ToArray());
    }

    [Test]
    public void ArgumentOutOfRangeTest()
    {
        const int n = 3;
        var sut = new int[n, n];
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = sut.Row(-1));
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = sut.Row(n));

        Assert.Throws<ArgumentOutOfRangeException>(() => _ = sut.Rows(-1, 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = sut.Rows(n, 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = sut.Rows(0, -1));
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = sut.Rows(1, n));
    }
}