using Mulinq.Multidimensional;
using NUnit.Framework;

namespace Mulinq.Test.Multidimensional;

public class SumTests
{
    #region Regular

    [TestCase(1)]
    [TestCase(10)]
    public void Int32Test(int v)
    {
        const int n = 3;
        var sut = new int[n, n];
        for (var i = 0; i < n; i++)
            for (var j = 0; j < n; j++)
                sut[i, j] = v;

        var seq = Enumerable.Repeat(v, n * n).ToArray();
        var expected = seq.Sum();
        var actual = sut.Sum();
        Assert.That(actual, Is.EqualTo(expected));

        int Selector(int x) => x * n;
        expected = seq.Sum(Selector);
        actual = sut.Sum(Selector);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(1)]
    [TestCase(10)]
    public void NullableInt32Test(int? v)
    {
        const int n = 3;
        var sut = new int?[n, n];
        for (var i = 0; i < n; i++)
            for (var j = 0; j < n; j++)
                sut[i, j] = v;

        var seq = Enumerable.Repeat(v, n * n).ToArray();
        seq[0] = null;
        var expected = seq.Sum();
        sut[0, 0] = null;
        var actual = sut.Sum();
        Assert.That(actual, Is.EqualTo(expected));

        int? Selector(int? x) => x * n;
        expected = seq.Sum(Selector);
        actual = sut.Sum(Selector);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(1L)]
    [TestCase(10L)]
    public void Int64Test(long v)
    {
        const int n = 3;
        var sut = new long[n, n];
        for (var i = 0; i < n; i++)
            for (var j = 0; j < n; j++)
                sut[i, j] = v;

        var seq = Enumerable.Repeat(v, n * n).ToArray();
        var expected = seq.Sum();
        var actual = sut.Sum();
        Assert.That(actual, Is.EqualTo(expected));

        long Selector(long x) => x * n;
        expected = seq.Sum(Selector);
        actual = sut.Sum(Selector);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(1L)]
    [TestCase(10L)]
    public void NullableInt64Test(long? v)
    {
        const int n = 3;
        var sut = new long?[n, n];
        for (var i = 0; i < n; i++)
            for (var j = 0; j < n; j++)
                sut[i, j] = v;

        var seq = Enumerable.Repeat(v, n * n).ToArray();
        seq[0] = null;
        var expected = seq.Sum();
        sut[0, 0] = null;
        var actual = sut.Sum();
        Assert.That(actual, Is.EqualTo(expected));

        long? Selector(long? x) => x * n;
        expected = seq.Sum(Selector);
        actual = sut.Sum(Selector);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(0.3f)]
    [TestCase(0.5f)]
    [TestCase(1f)]
    public void SingleTest(float v)
    {
        const int n = 3;
        var sut = new float[n, n];
        for (var i = 0; i < n; i++)
            for (var j = 0; j < n; j++)
                sut[i, j] = v;

        var seq = Enumerable.Repeat(v, n * n).ToArray();
        var expected = seq.Sum();
        var actual = sut.Sum();
        Assert.That(actual, Is.EqualTo(expected));

        float Selector(float x) => x * n;
        expected = seq.Sum(Selector);
        actual = sut.Sum(Selector);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(0.3f)]
    [TestCase(0.5f)]
    [TestCase(1f)]
    public void NullableSingleTest(float? v)
    {
        const int n = 3;
        var sut = new float?[n, n];
        for (var i = 0; i < n; i++)
            for (var j = 0; j < n; j++)
                sut[i, j] = v;

        var seq = Enumerable.Repeat(v, n * n).ToArray();
        seq[0] = null;
        var expected = seq.Sum();
        sut[0, 0] = null;
        var actual = sut.Sum();
        Assert.That(actual, Is.EqualTo(expected));

        float? Selector(float? x) => x * n;
        expected = seq.Sum(Selector);
        actual = sut.Sum(Selector);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(0.3)]
    [TestCase(0.5)]
    [TestCase(1.0)]
    public void DoubleTest(double v)
    {
        const int n = 3;
        var sut = new double[n, n];
        for (var i = 0; i < n; i++)
            for (var j = 0; j < n; j++)
                sut[i, j] = v;

        var seq = Enumerable.Repeat(v, n * n).ToArray();
        var expected = seq.Sum();
        var actual = sut.Sum();
        Assert.That(actual, Is.EqualTo(expected));

        double Selector(double x) => x * n;
        expected = seq.Sum(Selector);
        actual = sut.Sum(Selector);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(0.3)]
    [TestCase(0.5)]
    [TestCase(1.0)]
    public void NullableDoubleTest(double? v)
    {
        const int n = 3;
        var sut = new double?[n, n];
        for (var i = 0; i < n; i++)
            for (var j = 0; j < n; j++)
                sut[i, j] = v;

        var seq = Enumerable.Repeat(v, n * n).ToArray();
        seq[0] = null;
        var expected = seq.Sum();
        sut[0, 0] = null;
        var actual = sut.Sum();
        Assert.That(actual, Is.EqualTo(expected));

        double? Selector(double? x) => x * n;
        expected = seq.Sum(Selector);
        actual = sut.Sum(Selector);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(0.3)]
    [TestCase(1)]
    [TestCase(1e18)]
    public void DecimalTest(Decimal v)
    {
        const int n = 3;
        var sut = new Decimal[n, n];
        for (var i = 0; i < n; i++)
            for (var j = 0; j < n; j++)
                sut[i, j] = v;

        var seq = Enumerable.Repeat(v, n * n).ToArray();
        var expected = seq.Sum();
        var actual = sut.Sum();
        Assert.That(actual, Is.EqualTo(expected));

        Decimal Selector(Decimal x) => x * n;
        expected = seq.Sum(Selector);
        actual = sut.Sum(Selector);
        Assert.That(actual, Is.EqualTo(expected));
    }


    [TestCase(0.3)]
    [TestCase(1)]
    [TestCase(1e18)]
    public void NullableDecimalTest(Decimal? v)
    {
        const int n = 3;
        var sut = new Decimal?[n, n];
        for (var i = 0; i < n; i++)
            for (var j = 0; j < n; j++)
                sut[i, j] = v;

        var seq = Enumerable.Repeat(v, n * n).ToArray();
        seq[0] = null;
        var expected = seq.Sum();
        sut[0, 0] = null;
        var actual = sut.Sum();
        Assert.That(actual, Is.EqualTo(expected));

        Decimal? Selector(Decimal? x) => x * n;
        expected = seq.Sum(Selector);
        actual = sut.Sum(Selector);
        Assert.That(actual, Is.EqualTo(expected));
    }

    #endregion

    #region NullSelector

    [Test]
    public void Int32NullSelectorTest()
    {
        const int n = 3;
        var sut = new int[n, n];
        Func<int, int>? selector = null;
        Assert.Throws<ArgumentNullException>(() => _ = sut.Sum(selector));
    }

    [Test]
    public void NullableInt32NullSelectorTest()
    {
        const int n = 3;
        var sut = new int?[n, n];
        Func<int?, int?>? selector = null;
        Assert.Throws<ArgumentNullException>(() => _ = sut.Sum(selector));
    }

    [Test]
    public void Int64NullSelectorTest()
    {
        const int n = 3;
        var sut = new long[n, n];
        Func<long, long>? selector = null;
        Assert.Throws<ArgumentNullException>(() => _ = sut.Sum(selector));
    }

    [Test]
    public void NullableInt64NullSelectorTest()
    {
        const int n = 3;
        var sut = new long?[n, n];
        Func<long?, long?>? selector = null;
        Assert.Throws<ArgumentNullException>(() => _ = sut.Sum(selector));
    }

    [Test]
    public void SingleNullSelectorTest()
    {
        const int n = 3;
        var sut = new float[n, n];
        Func<float, float>? selector = null;
        Assert.Throws<ArgumentNullException>(() => _ = sut.Sum(selector));
    }

    [Test]
    public void NullableSingleNullSelectorTest()
    {
        const int n = 3;
        var sut = new float?[n, n];
        Func<float?, float?>? selector = null;
        Assert.Throws<ArgumentNullException>(() => _ = sut.Sum(selector));
    }

    [Test]
    public void DoubleNullSelectorTest()
    {
        const int n = 3;
        var sut = new double[n, n];
        Func<double, double>? selector = null;
        Assert.Throws<ArgumentNullException>(() => _ = sut.Sum(selector));
    }

    [Test]
    public void NullableDoubleNullSelectorTest()
    {
        const int n = 3;
        var sut = new double?[n, n];
        Func<double?, double?>? selector = null;
        Assert.Throws<ArgumentNullException>(() => _ = sut.Sum(selector));
    }

    [Test]
    public void DecimalNullSelectorTest()
    {
        const int n = 3;
        var sut = new Decimal[n, n];
        Func<Decimal, Decimal>? selector = null;
        Assert.Throws<ArgumentNullException>(() => _ = sut.Sum(selector));
    }

    [Test]
    public void NullableDecimalNullSelectorTest()
    {
        const int n = 3;
        var sut = new Decimal?[n, n];
        Func<Decimal?, Decimal?>? selector = null;
        Assert.Throws<ArgumentNullException>(() => _ = sut.Sum(selector));
    }

    #endregion

    #region NullSource

    [Test]
    public void Int32NullSourceTest()
    {
        int[,]? sut = null;
        Assert.Throws<ArgumentNullException>(() => _ = sut.Sum());
        Assert.Throws<ArgumentNullException>(() => _ = sut.Sum(x => x));
    }

    [Test]
    public void NullableInt32NullSourceTest()
    {
        int?[,]? sut = null;
        Assert.Throws<ArgumentNullException>(() => _ = sut.Sum());
        Assert.Throws<ArgumentNullException>(() => _ = sut.Sum(x => x));
    }

    [Test]
    public void Int64NullSourceTest()
    {
        long[,]? sut = null;
        Assert.Throws<ArgumentNullException>(() => _ = sut.Sum());
        Assert.Throws<ArgumentNullException>(() => _ = sut.Sum(x => x));
    }

    [Test]
    public void NullableInt64NullSourceTest()
    {
        long?[,]? sut = null;
        Assert.Throws<ArgumentNullException>(() => _ = sut.Sum());
        Assert.Throws<ArgumentNullException>(() => _ = sut.Sum(x => x));
    }

    [Test]
    public void SingleNullSourceTest()
    {
        float[,]? sut = null;
        Assert.Throws<ArgumentNullException>(() => _ = sut.Sum());
        Assert.Throws<ArgumentNullException>(() => _ = sut.Sum(x => x));
    }

    [Test]
    public void NullableSingleNullSourceTest()
    {
        float?[,]? sut = null;
        Assert.Throws<ArgumentNullException>(() => _ = sut.Sum());
        Assert.Throws<ArgumentNullException>(() => _ = sut.Sum(x => x));
    }

    [Test]
    public void DoubleNullSourceTest()
    {
        double[,]? sut = null;
        Assert.Throws<ArgumentNullException>(() => _ = sut.Sum());
        Assert.Throws<ArgumentNullException>(() => _ = sut.Sum(x => x));
    }

    [Test]
    public void NullableDoubleNullSourceTest()
    {
        double?[,]? sut = null;
        Assert.Throws<ArgumentNullException>(() => _ = sut.Sum());
        Assert.Throws<ArgumentNullException>(() => _ = sut.Sum(x => x));
    }

    [Test]
    public void DecimalNullSourceTest()
    {
        Decimal[,]? sut = null;
        Assert.Throws<ArgumentNullException>(() => _ = sut.Sum());
        Assert.Throws<ArgumentNullException>(() => _ = sut.Sum(x => x));
    }

    [Test]
    public void NullableDecimalNullSourceTest()
    {
        Decimal?[,]? sut = null;
        Assert.Throws<ArgumentNullException>(() => _ = sut.Sum());
        Assert.Throws<ArgumentNullException>(() => _ = sut.Sum(x => x));
    }

    #endregion

    #region Overflow

    [TestCase(int.MinValue)]
    [TestCase(int.MaxValue)]
    public void Int32OverflowTest(int v)
    {
        const int n = 3;
        var sut = new int[n, n];
        for (var i = 0; i < n; i++)
            for (var j = 0; j < n; j++)
                sut[i, j] = v;

        Assert.Throws<OverflowException>(() => _ = sut.Sum());
    }

    [TestCase(int.MinValue)]
    [TestCase(int.MaxValue)]
    public void NullableInt32OverflowTest(int v)
    {
        const int n = 3;
        var sut = new int?[n, n];
        for (var i = 0; i < n; i++)
            for (var j = 0; j < n; j++)
                sut[i, j] = v;

        Assert.Throws<OverflowException>(() => _ = sut.Sum());
    }

    [TestCase(long.MinValue)]
    [TestCase(long.MaxValue)]
    public void Int64OverflowTest(long v)
    {
        const int n = 3;
        var sut = new long[n, n];
        for (var i = 0; i < n; i++)
            for (var j = 0; j < n; j++)
                sut[i, j] = v;

        Assert.Throws<OverflowException>(() => _ = sut.Sum());
    }

    [TestCase(long.MinValue)]
    [TestCase(long.MaxValue)]
    public void NullableInt64OverflowTest(long? v)
    {
        const int n = 3;
        var sut = new long?[n, n];
        for (var i = 0; i < n; i++)
            for (var j = 0; j < n; j++)
                sut[i, j] = v;

        Assert.Throws<OverflowException>(() => _ = sut.Sum());
    }

    #endregion

    #region NoElements

    [Test]
    public void NullableInt32NoElementsTest()
    {
        const int n = 0;
        var sut = new int?[n, n];
        var actual = sut.Sum();
        Assert.That(actual, Is.Null);
    }

    [Test]
    public void NullableInt64NoElementsTest()
    {
        const int n = 1;
        var sut = new long?[n, n];
        var actual = sut.Sum();
        Assert.That(actual, Is.Null);
    }

    [Test]
    public void NullableSingleNoElementsTest()
    {
        const int n = 1;
        var sut = new float?[n, n];
        var actual = sut.Sum();
        Assert.That(actual, Is.Null);
    }

    [Test]
    public void NullableDoubleNoElementsTest()
    {
        const int n = 1;
        var sut = new double?[n, n];
        var actual = sut.Sum();
        Assert.That(actual, Is.Null);
    }

    [Test]
    public void NullableDecimalNoElementsTest()
    {
        const int n = 1;
        var sut = new Decimal?[n, n];
        var actual = sut.Sum();
        Assert.That(actual, Is.Null);
    }

    #endregion
}