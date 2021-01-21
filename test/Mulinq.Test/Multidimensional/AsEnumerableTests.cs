using System;
using System.Linq;
using Mulinq.Multidimensional;
using NUnit.Framework;

namespace Mulinq.Test.Multidimensional
{
    public class AsEnumerableTests
    {
        [Test]
        public void AsEnumerable2DimTest()
        {
            const int n = 5;
            var sut = new int[n, n];
            for (var i = 0; i < n; i++)
                for (var j = 0; j < n; j++)
                    sut[i, j] = i * n + j;

            var expected = Enumerable.Range(0, n * n);
            var actual = sut.AsEnumerable();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ArgumentNull2DimTest()
        {
            int[,] sut = null;
            Assert.Throws<ArgumentNullException>(() => _ = sut.AsEnumerable().ToArray());
        }

        [Test]
        public void AsEnumerable3DimTest()
        {
            const int n = 5;
            var sut = new int[n, n, n];
            for (var i = 0; i < n; i++)
                for (var j = 0; j < n; j++)
                    for (var k = 0; k < n; k++)
                        sut[i, j, k] = i * n * n + j * n + k;

            var expected = Enumerable.Range(0, n * n * n);
            var actual = sut.AsEnumerable();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ArgumentNull3DimTest()
        {
            int[,,] sut = null;
            Assert.Throws<ArgumentNullException>(() => _ = sut.AsEnumerable().ToArray());
        }
    }
}