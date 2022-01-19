using Mulinq.Multidimensional;
using NUnit.Framework;

namespace Mulinq.Test.Multidimensional;

public class CountTests
{
    [Test]
    public void Count2DimTest()
    {
        const int n = 3;
        var sut = new int[n, n];
        for (var i = 0; i < n; i++)
            for (var j = 0; j < n; j++)
                sut[i, j] = i * n + j;

        static bool Predicate(int x) => x % 2 == 0;

        var expected = Enumerable.Range(0, n * n).Count(Predicate);
        var actual = sut.Count(Predicate);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Count3DimTest()
    {
        const int n = 3;
        var sut = new int[n, n, n];
        for (var i = 0; i < n; i++)
            for (var j = 0; j < n; j++)
                for (var k = 0; k < n; k++)
                    sut[i, j, k] = i * n * n + j * n + k;

        static bool Predicate(int x) => x % 2 == 0;

        var expected = Enumerable.Range(0, n * n * n).Count(Predicate);
        var actual = sut.Count(Predicate);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void NullSource2DimTest()
    {
        int[,]? sut = null;
        Assert.Throws<ArgumentNullException>(() => _ = sut.Count(x => x == 0));
    }

    [Test]
    public void NullSource3DimTest()
    {
        int[,,]? sut = null;
        Assert.Throws<ArgumentNullException>(() => _ = sut.Count(x => x == 0));
    }

    [Test]
    public void NullPredicate2DimTest()
    {
        const int n = 3;
        var sut = new int[n, n];
        Func<int, bool>? predicate = null;
        Assert.Throws<ArgumentNullException>(() => _ = sut.Count(predicate));
    }

    [Test]
    public void NullPredicate3DimTest()
    {
        const int n = 3;
        var sut = new int[n, n, n];
        Func<int, bool>? predicate = null;
        Assert.Throws<ArgumentNullException>(() => _ = sut.Count(predicate));
    }
}