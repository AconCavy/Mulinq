using System;
using System.Linq;
using Mulinq.Multidimensional;
using NUnit.Framework;

namespace Mulinq.Test.Multidimensional
{
    public class SelectTests
    {
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 4)]
        [TestCase(4, 3)]
        public void SelectTest(int r, int c)
        {
            const int multiplier = 3;
            long Selector(int x) => x * multiplier;
            var sut = new int[r, c];
            for (var i = 0; i < r; i++)
                for (var j = 0; j < c; j++)
                    sut[i, j] = i * c + j;

            var expected = Enumerable.Range(0, r * c).Select((Func<int, long>)Selector);
            var actual = sut.Select((Func<int, long>)Selector);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ArgumentNullTest()
        {
            int[,]? sut = null;
            Func<int, int>? selector = null;
            Assert.Throws<ArgumentNullException>(() => _ = sut.Select(x => x));

            const int n = 3;
            sut = new int[n, n];
            Assert.Throws<ArgumentNullException>(() => _ = sut.Select(selector));
        }
    }
}