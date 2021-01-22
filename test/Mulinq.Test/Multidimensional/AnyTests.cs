using System;
using Mulinq.Multidimensional;
using NUnit.Framework;

namespace Mulinq.Test.Multidimensional
{
    public class AnyTests
    {
        [Test]
        public void AnyTrue2DimTest()
        {
            const int n = 3;
            var sut = new int[n, n];
            var actual = sut.Any();
            Assert.That(actual, Is.True);
        }

        [Test]
        public void AnyFalse2DimTest()
        {
            const int n = 0;
            var sut = new int[n, n];
            var actual = sut.Any();
            Assert.That(actual, Is.False);
        }

        [Test]
        public void AnyTrueWithPredicate2DimTest()
        {
            const int n = 3;
            var sut = new int[n, n];
            sut[0, 0] = 1;
            var actual = sut.Any(x => x == 1);
            Assert.That(actual, Is.True);
        }

        [Test]
        public void AnyFalseWithPredicate2DimTest()
        {
            const int n = 3;
            var sut = new int[n, n];
            var actual = sut.Any(x => x == 1);
            Assert.That(actual, Is.False);
        }

        [Test]
        public void NullSource2DimTest()
        {
            int[,]? sut = null;
            Assert.Throws<ArgumentNullException>(() => _ = sut.Any());
            Assert.Throws<ArgumentNullException>(() => _ = sut.Any(x => x == 0));
        }

        [Test]
        public void NullPredicate2DimTest()
        {
            const int n = 3;
            Func<int, bool>? predicate = null;
            var sut = new int[n, n];
            Assert.Throws<ArgumentNullException>(() => _ = sut.Any(predicate));
        }

        [Test]
        public void AnyTrue3DimTest()
        {
            const int n = 3;
            var sut = new int[n, n, n];
            var actual = sut.Any();
            Assert.That(actual, Is.True);
        }

        [Test]
        public void AnyFalse3DimTest()
        {
            const int n = 0;
            var sut = new int[n, n, n];
            var actual = sut.Any();
            Assert.That(actual, Is.False);
        }

        [Test]
        public void AnyTrueWithPredicate3DimTest()
        {
            const int n = 3;
            var sut = new int[n, n, n];
            sut[0, 0, 0] = 1;
            var actual = sut.Any(x => x == 1);
            Assert.That(actual, Is.True);
        }

        [Test]
        public void AnyFalseWithPredicate3DimTest()
        {
            const int n = 3;
            var sut = new int[n, n, n];
            var actual = sut.Any(x => x == 1);
            Assert.That(actual, Is.False);
        }

        [Test]
        public void NullSource3DimTest()
        {
            int[,,]? sut = null;
            Assert.Throws<ArgumentNullException>(() => _ = sut.Any());
            Assert.Throws<ArgumentNullException>(() => _ = sut.Any(x => x == 0));
        }

        [Test]
        public void NullPredicate3DimTest()
        {
            const int n = 3;
            Func<int, bool>? predicate = null;
            var sut = new int[n, n, n];
            Assert.Throws<ArgumentNullException>(() => _ = sut.Any(predicate));
        }
    }
}