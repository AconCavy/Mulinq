using Mulinq.Multidimensional;
using NUnit.Framework;

namespace Mulinq.Test.Multidimensional;

public class SelectTests
{
    [TestCase(1, 1)]
    [TestCase(2, 2)]
    [TestCase(3, 4)]
    [TestCase(4, 3)]
    public void Select2DimTest(int r, int c)
    {
        const int multiplier = 3;
        long Selector(int x) => x * multiplier;
        var sut = new int[r, c];
        for (var i = 0; i < r; i++)
            for (var j = 0; j < c; j++)
                sut[i, j] = i * c + j;

        var expected = Enumerable.Range(0, r * c).Select(Selector);
        var actual = sut.Select(Selector);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(1)]
    [TestCase(3)]
    public void Select2DimTest(int n)
    {
        const int multiplier = 3;
        long Selector(int x) => x * multiplier;
        var sut = new int[n, n, n];
        for (var i = 0; i < n; i++)
            for (var j = 0; j < n; j++)
                for (var k = 0; k < n; k++)
                    sut[i, j, k] = i * n * n + j * n + k;

        var expected = Enumerable.Range(0, n * n * n).Select(Selector);
        var actual = sut.Select(Selector);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void ArgumentNull2DimTest()
    {
        int[,]? sut = null;
        Func<int, int>? selector = null;
        Assert.Throws<ArgumentNullException>(() => _ = sut.Select(x => x));

        const int n = 3;
        sut = new int[n, n];
        Assert.Throws<ArgumentNullException>(() => _ = sut.Select(selector));
    }

    [Test]
    public void ArgumentNull3DimTest()
    {
        int[,,]? sut = null;
        Func<int, int>? selector = null;
        Assert.Throws<ArgumentNullException>(() => _ = sut.Select(x => x));

        const int n = 3;
        sut = new int[n, n, n];
        Assert.Throws<ArgumentNullException>(() => _ = sut.Select(selector));
    }
}