using System;
using System.Linq;
using Mulinq.Multidimensional;
using NUnit.Framework;

namespace Mulinq.Test.Multidimensional
{
    public class WhereTests
    {
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 4)]
        [TestCase(4, 3)]
        public void WhereTest(int r, int c)
        {
            static bool Predicate(int x) => x % 2 == 0;
            const int multiplier = 3;
            var sut = new int[r, c];
            for (var i = 0; i < r; i++)
                for (var j = 0; j < c; j++)
                    sut[i, j] = i * c + j;

            var expected = Enumerable.Range(0, r * c).Where(Predicate);

            var actual = sut.Where(Predicate);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ArgumentNullTest()
        {
            int[,]? sut = null;
            Func<int, bool>? predicate = null;
            Assert.Throws<ArgumentNullException>(() => _ = sut.Where(x => x % 2 == 0));

            const int n = 3;
            sut = new int[n, n];
            Assert.Throws<ArgumentNullException>(() => _ = sut.Where(predicate));
        }
    }
}