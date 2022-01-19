using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Mulinq.Test.Linq;

using static Mulinq.Linq.EnumerableExtension;

public class MaxByTests
{
    [Test]
    public void MaxByTestByClass()
    {
        const int count = 10;
        var items = Enumerable.Range(1, count).Select(x => new SampleClass(x, count)).ToArray();
        items = items.Concat(items.Reverse()).ToArray();
        SampleClass? expected = null;
        var max = int.MinValue;
        foreach (var x in items)
        {
            if (max >= x.A) continue;
            max = x.A;
            expected = x;
        }

        var actual = items.MaxBy(x => x.A);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void MaxByTestByStruct()
    {
        const int count = 10;
        var items = Enumerable.Range(1, count).Select(x => new SampleStruct(x, count)).ToArray();
        items = items.Concat(items.Reverse()).ToArray();
        SampleStruct expected = default;
        var max = int.MinValue;
        foreach (var x in items)
        {
            if (max >= x.A) continue;
            max = x.A;
            expected = x;
        }

        var actual = items.MaxBy(x => x.A);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void UpdateEqualsFalseTestByClass()
    {
        const int count = 10;
        var items = Enumerable.Range(1, count).Select(x => new SampleClass(x, count)).ToArray();
        var expected = items[0];

        var actual = items.MaxBy(x => x.B);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void UpdateEqualsFalseTestByStruct()
    {
        const int count = 10;
        var items = Enumerable.Range(1, count).Select(x => new SampleStruct(x, count)).ToArray();
        var expected = items[0];

        var actual = items.MaxBy(x => x.B);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void UpdateEqualsTrueTestByClass()
    {
        const int count = 10;
        var items = Enumerable.Range(1, count).Select(x => new SampleClass(x, count)).ToArray();
        var expected = items[^1];

        var actual = items.MaxBy(x => x.B, true);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void UpdateEqualsTrueTestByStruct()
    {
        const int count = 10;
        var items = Enumerable.Range(1, count).Select(x => new SampleStruct(x, count)).ToArray();
        var expected = items[^1];

        var actual = items.MaxBy(x => x.B, true);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void NullSourceTest()
    {
        IEnumerable<SampleClass>? classes = null;
        Assert.Throws<ArgumentNullException>(() => classes.MaxBy(x => x.A));

        IEnumerable<SampleStruct>? structs = null;
        Assert.Throws<ArgumentNullException>(() => structs.MaxBy(x => x.A));
    }

    [Test]
    public void NullFuncTest()
    {
        var classes = Enumerable.Range(1, 5).Select(x => new SampleClass(x, x));
        Assert.Throws<ArgumentNullException>(() => classes.MaxBy<SampleClass, int>(null));

        var structs = Enumerable.Range(1, 5).Select(x => new SampleStruct(x, x));
        Assert.Throws<ArgumentNullException>(() => structs.MaxBy<SampleStruct, int>(null));
    }

    [Test]
    public void NoElementTest()
    {
        IEnumerable<SampleClass> classes = new SampleClass[0];
        Assert.Throws<InvalidOperationException>(() => classes.MaxBy(x => x.A));

        IEnumerable<SampleStruct> structs = new SampleStruct[0];
        Assert.Throws<InvalidOperationException>(() => structs.MaxBy(x => x.A));
    }

    private readonly struct SampleStruct
    {
        public readonly int A;
        public readonly int B;

        public SampleStruct(int a, int b) => (A, B) = (a, b);
    }

    private class SampleClass
    {
        public SampleClass(int a, int b) => (A, B) = (a, b);

        public int A { get; }
        public int B { get; }
    }
}