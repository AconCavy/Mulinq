using Mulinq.Linq;
using NUnit.Framework;

namespace Mulinq.Test.Linq;

public class DeduplicateTests
{
    [TestCase(new[] { 1, 2, 2, 3, 4, 2 }, new[] { 1, 2, 3, 4, 2 })]
    [TestCase(new[] { 1, 1, 1 }, new[] { 1 })]
    [TestCase(new int[0], new int[0])]
    public void DeduplicateTest(int[] sut, int[] expected)
    {
        var actual = sut.Deduplicate(x => x);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void DeduplicateBySelectorTest()
    {
        var sut = new Sample[] { new(1, 1), new(1, 2), new(1, 2), new(1, 3), new(1, 1), };
        var expected = new Sample[] { new(1, 1), new(1, 2), new(1, 3), new(1, 1), };
        var actual = sut.Deduplicate(x => x.B);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void NullSourceTest()
    {
        IEnumerable<int>? sut = null;
        Assert.Throws<ArgumentNullException>(() => sut.Deduplicate(x => x));
    }

    [Test]
    public void NullSelectorTest()
    {
        var sut = new[] { 1, 2, 3 };
        Func<int, int>? selector = null;
        Assert.Throws<ArgumentNullException>(() => sut.Deduplicate(selector));
    }

    private readonly struct Sample : IEquatable<Sample>
    {
        internal int A { get; }
        internal int B { get; }
        internal Sample(int a, int b) => (A, B) = (a, b);
        public bool Equals(Sample other) => A == other.A && B == other.B;
        public override bool Equals(object? obj) => obj is Sample other && Equals(other);
        public override int GetHashCode() => HashCode.Combine(A, B);
    }
}