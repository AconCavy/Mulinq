using Mulinq.Multidimensional;
using NUnit.Framework;

namespace Mulinq.Test.Multidimensional;

public class ContainsTests
{
    [Test]
    public void ContainsTrue2DimTest()
    {
        const int n = 3;
        var sut = new int[n, n];
        sut[0, 0] = 1;
        var actual = sut.Contains(1);
        Assert.That(actual, Is.True);

        actual = sut.Contains(1, EqualityComparer<int>.Default);
        Assert.That(actual, Is.True);
    }

    [Test]
    public void ContainsFalse2DimTest()
    {
        const int n = 3;
        var sut = new int[n, n];
        var actual = sut.Contains(1);
        Assert.That(actual, Is.False);

        actual = sut.Contains(1, EqualityComparer<int>.Default);
        Assert.That(actual, Is.False);
    }

    [Test]
    public void NullSource2DimTest()
    {
        int[,]? sut = null;
        Assert.Throws<ArgumentNullException>(() => _ = sut.Contains(1));
        Assert.Throws<ArgumentNullException>(() => _ = sut.Contains(1, EqualityComparer<int>.Default));
    }

    [Test]
    public void ContainsTrue3DimTest()
    {
        const int n = 3;
        var sut = new int[n, n, n];
        sut[0, 0, 0] = 1;
        var actual = sut.Contains(1);
        Assert.That(actual, Is.True);

        actual = sut.Contains(1, EqualityComparer<int>.Default);
        Assert.That(actual, Is.True);
    }

    [Test]
    public void ContainsFalse3DimTest()
    {
        const int n = 3;
        var sut = new int[n, n, n];
        var actual = sut.Contains(1);
        Assert.That(actual, Is.False);

        actual = sut.Contains(1, EqualityComparer<int>.Default);
        Assert.That(actual, Is.False);
    }

    [Test]
    public void NullSource3DimTest()
    {
        int[,,]? sut = null;
        Assert.Throws<ArgumentNullException>(() => _ = sut.Contains(1));
        Assert.Throws<ArgumentNullException>(() => _ = sut.Contains(1, EqualityComparer<int>.Default));
    }
}