using System;
using System.Collections.Generic;
using System.Linq;
using Mulinq.Linq;
using NUnit.Framework;

namespace Mulinq.Test.Linq
{
    public class CumulateTests
    {
        [Test]
        public void CumulateTest()
        {
            const int count = 10;
            var items = Enumerable.Range(11, count);
            var expected = new long[count + 1];
            expected[0] = 1;
            for (var i = 1; i <= count; i++) expected[i] = expected[i - 1] * (count + i);

            var actual = items.Cumulate(MultipleLongInt, 1L);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void CumulateNoSeedTest()
        {
            const int count = 10;
            var items = Enumerable.Range(1, count);
            var expected = new long[count + 1];
            for (var i = 1; i <= count; i++) expected[i] = expected[i - 1] + i;

            var actual = items.Cumulate<int, long>(AddLongInt);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void CumulateSameTypeTest()
        {
            const int count = 10;
            var items = Enumerable.Range(1, count);
            var expected = new int[count + 1];
            for (var i = 1; i <= count; i++) expected[i] = expected[i - 1] + i;

            var actual = items.Cumulate(AddInt);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void NullSourceTest()
        {
            IEnumerable<int>? items = null;
            Assert.Throws<ArgumentNullException>(() => items.Cumulate(AddInt));
            Assert.Throws<ArgumentNullException>(() => items.Cumulate(MultipleLongInt, 0L));
            Assert.Throws<ArgumentNullException>(() => items.Cumulate<int, long>(MultipleLongInt));
        }

        [Test]
        public void NullFuncTest()
        {
            var items = Enumerable.Range(0, 5);
            Assert.Throws<ArgumentNullException>(() => items.Cumulate(null));
            Assert.Throws<ArgumentNullException>(() => items.Cumulate(null, 0L));
            Assert.Throws<ArgumentNullException>(() => items.Cumulate<int, long>(null));
        }

        private static int AddInt(int x, int y) => x + y;

        private static long AddLongInt(long x, int y) => x + y;

        private static long MultipleLongInt(long x, int y) => x * y;
    }
}