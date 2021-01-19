using System;
using System.Collections.Generic;
using System.Linq;
using Mulinq.Linq;
using NUnit.Framework;

namespace Mulinq.Test.Linq
{
    public class TryGetLastTests
    {
        [Test]
        public void TryGetLastTest()
        {
            const int count = 10;
            var items = Enumerable.Range(1, count).ToArray();
            const int expected = count;

            var exist = items.TryGetLast(out var actual);

            Assert.That(exist, Is.True);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TryGetLastWithPredicateTest()
        {
            const int count = 10;
            var items = Enumerable.Range(0, count).ToArray();
            const int expected = 9;

            var exist = items.TryGetLast(out var actual, x => x % 2 == 1);

            Assert.That(exist, Is.True);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void DoesNotExistTest()
        {
            var items = Array.Empty<int>();
            const int expected = 0;

            var exist = items.TryGetLast(out var actual);

            Assert.That(exist, Is.False);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void DoesNotExistWithPredicateTest()
        {
            var items = Enumerable.Range(1, 5).Select(x => x * 2);
            const int expected = 0;

            var exist = items.TryGetLast(out var actual, x => x % 2 == 1);

            Assert.That(exist, Is.False);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void NullSourceTest()
        {
            IEnumerable<int> items = null;
            Assert.Throws<ArgumentNullException>(() => items.TryGetLast(out _));
            Assert.Throws<ArgumentNullException>(() => items.TryGetLast(out _, x => x % 2 == 0));
        }

        [Test]
        public void NullPredicateTest()
        {
            var items = Enumerable.Range(1, 10);
            Assert.Throws<ArgumentNullException>(() => items.TryGetLast(out _, null));
        }
    }
}