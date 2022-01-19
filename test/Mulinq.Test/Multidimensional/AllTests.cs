using System;
using Mulinq.Multidimensional;
using NUnit.Framework;

namespace Mulinq.Test.Multidimensional;

public class AllTests
{
    [Test]
    public void AllTrue2DimTest()
    {
        const int n = 3;
        var sut = new int[n, n];
        var actual = sut.All(x => x == 0);
        Assert.That(actual, Is.True);
    }

    [Test]
    public void AllFalse2DimTest()
    {
        const int n = 3;
        var sut = new int[n, n];
        sut[0, 0] = 1;
        var actual = sut.All(x => x == 0);
        Assert.That(actual, Is.False);
    }

    [Test]
    public void NullSource2DimTest()
    {
        int[,]? sut = null;
        Assert.Throws<ArgumentNullException>(() => _ = sut.All(x => x == 0));
    }

    [Test]
    public void NullPredicate2DimTest()
    {
        const int n = 3;
        Func<int, bool>? predicate = null;
        var sut = new int[n, n];
        Assert.Throws<ArgumentNullException>(() => _ = sut.All(predicate));
    }

    [Test]
    public void AllTrue3DimTest()
    {
        const int n = 3;
        var sut = new int[n, n, n];
        var actual = sut.All(x => x == 0);
        Assert.That(actual, Is.True);
    }

    [Test]
    public void AllFalse3DimTest()
    {
        const int n = 3;
        var sut = new int[n, n, n];
        sut[0, 0, 0] = 1;
        var actual = sut.All(x => x == 0);
        Assert.That(actual, Is.False);
    }

    [Test]
    public void NullSource3DimTest()
    {
        int[,,]? sut = null;
        Assert.Throws<ArgumentNullException>(() => _ = sut.All(x => x == 0));
    }

    [Test]
    public void NullPredicate3DimTest()
    {
        const int n = 3;
        Func<int, bool>? predicate = null;
        var sut = new int[n, n, n];
        Assert.Throws<ArgumentNullException>(() => _ = sut.All(predicate));
    }
}