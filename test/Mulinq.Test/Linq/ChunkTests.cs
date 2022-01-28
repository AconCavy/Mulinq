using NUnit.Framework;

namespace Mulinq.Test.Linq;

using static Mulinq.Linq.EnumerableExtension;

public class ChunkTests
{
    [Test]
    public void DivideByTest()
    {
        var items = Enumerable.Range(0, 9);

        var expected = new[] { new[] { 0, 1, 2 }, new[] { 3, 4, 5 }, new[] { 6, 7, 8 } };
        var actual = items.Chunk(3);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void FragmentTest()
    {
        var items = Enumerable.Range(0, 10);

        var expected = new[] { new[] { 0, 1, 2 }, new[] { 3, 4, 5 }, new[] { 6, 7, 8 }, new[] { 9 } };
        var actual = items.Chunk(3);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void FragmentToArrayTest()
    {
        var items = Enumerable.Range(0, 10);

        var expected = new[] { new[] { 0, 1, 2 }, new[] { 3, 4, 5 }, new[] { 6, 7, 8 }, new[] { 9 } };
        var actual = items.Chunk(3).ToArray();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void LessThanSizeTest()
    {
        var items = Enumerable.Range(0, 2);

        var expected = new[] { new[] { 0, 1 } };
        var actual = items.Chunk(3);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void NullSourceTest()
    {
        IEnumerable<int>? items = null;
        Assert.Throws<ArgumentNullException>(() => items.Chunk(1));
    }

    [Test]
    public void SizeLessThanOrEquals0Test()
    {
        var items = Enumerable.Range(0, 5);
        Assert.Throws<ArgumentException>(() => items.Chunk(0));
        Assert.Throws<ArgumentException>(() => items.Chunk(-1));
    }
}