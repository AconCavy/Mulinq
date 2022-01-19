using Mulinq.Multidimensional;
using NUnit.Framework;

namespace Mulinq.Test.Multidimensional;

public class MinTests
{
    [Test]
    public void Min2DimTest()
    {
        const int n = 3;
        var sut = new int[n, n];

        const int expected = int.MinValue;
        sut[n / 2, n / 2] = expected;
        var actual = sut.Min();
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void MinWithSelector2DimTest()
    {
        const int n = 3;
        var sut = new Sample[n, n];

        const int expected = int.MinValue;
        sut[n / 2, n / 2] = new Sample(expected);
        var actual = sut.Min(x => x.A);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Min3DimTest()
    {
        const int n = 3;
        var sut = new int[n, n, n];

        const int expected = int.MinValue;
        sut[n / 2, n / 2, n / 2] = expected;
        var actual = sut.Min();
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void MinWithSelector3DimTest()
    {
        const int n = 3;
        var sut = new Sample[n, n, n];

        const int expected = int.MinValue;
        sut[n / 2, n / 2, n / 2] = new Sample(expected);
        var actual = sut.Min(x => x.A);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void NullSource2DimTest()
    {
        int[,]? sut = null;
        Assert.Throws<ArgumentNullException>(() => _ = sut.Min());
        Assert.Throws<ArgumentNullException>(() => _ = sut.Min(x => x));
    }

    [Test]
    public void NullSource3DimTest()
    {
        int[,,]? sut = null;
        Assert.Throws<ArgumentNullException>(() => _ = sut.Min());
        Assert.Throws<ArgumentNullException>(() => _ = sut.Min(x => x));
    }

    [Test]
    public void NullSelector2DimTest()
    {
        const int n = 3;
        var sut = new int[n, n];
        Func<int, int>? selector = null;
        Assert.Throws<ArgumentNullException>(() => _ = sut.Min(selector));
    }

    [Test]
    public void NullSelector3DimTest()
    {
        const int n = 3;
        var sut = new int[n, n, n];
        Func<int, int>? selector = null;
        Assert.Throws<ArgumentNullException>(() => _ = sut.Min(selector));
    }

    [Test]
    public void InvalidOperation2DimTest()
    {
        const int n = 0;
        var sut = new int[n, n];
        Assert.Throws<InvalidOperationException>(() => _ = sut.Min());
        Assert.Throws<InvalidOperationException>(() => _ = sut.Min(x => x));
    }

    [Test]
    public void InvalidOperation3DimTest()
    {
        const int n = 0;
        var sut = new int[n, n, n];
        Assert.Throws<InvalidOperationException>(() => _ = sut.Min());
        Assert.Throws<InvalidOperationException>(() => _ = sut.Min(x => x));
    }

    private readonly struct Sample
    {
        public readonly int A;
        public Sample(int a) => A = a;
    }
}