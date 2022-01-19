using System;
using System.Collections.Generic;
using System.Linq;
using Mulinq.Linq;
using NUnit.Framework;

namespace Mulinq.Test.Linq;

public class DeltaTests
{
    [Test]
    public void DeltaTest()
    {
        const int count = 10;
        var items = Enumerable.Range(0, count).ToArray();
        var expected = new int[count - 1];
        for (var i = 0; i < count - 1; i++) expected[i] = items[i + 1] - items[i];

        var actual = items.Delta((x, y) => y - x);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void DeltaOneItemTest()
    {
        var items = new[] { 0 };
        var expected = new int[0];

        var actual = items.Delta((x, y) => y - x);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void DeltaZeroItemTest()
    {
        var items = new int[0];
        var expected = new int[0];

        var actual = items.Delta((x, y) => y - x);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void NullSourceTest()
    {
        IEnumerable<int>? items = null;

        Assert.Throws<ArgumentNullException>(() => items.Delta((x, y) => y - x));
    }

    [Test]
    public void NullFuncTest()
    {
        var items = Enumerable.Range(0, 5);

        Assert.Throws<ArgumentNullException>(() => items.Delta(null));
    }
}