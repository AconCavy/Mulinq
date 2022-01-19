using System;
using System.Collections.Generic;
using System.Linq;
using Mulinq.Linq;
using NUnit.Framework;

namespace Mulinq.Test.Linq;

public class SkipEachTests
{
    [Test]
    public void SkipEachTest([Range(1, 10)] int skip)
    {
        const int count = 100;
        var items = Enumerable.Range(0, count).ToArray();
        var expected = new int[(count + skip) / (skip + 1)];
        for (var i = 0; i < count; i += skip + 1) expected[i / (skip + 1)] = items[i];
        var actual = items.SkipEach(skip);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Skip0Test()
    {
        const int count = 100;
        var items = Enumerable.Range(0, count).ToArray();
        var expected = items.ToArray();
        var actual = items.SkipEach(0);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void NullSourceTest()
    {
        IEnumerable<int>? items = null;
        Assert.Throws<ArgumentNullException>(() => items.SkipEach(0));
    }

    [Test]
    public void SizeLessThanOrEquals0Test()
    {
        var items = Enumerable.Range(0, 5);
        Assert.Throws<ArgumentException>(() => items.SkipEach(-1));
    }
}