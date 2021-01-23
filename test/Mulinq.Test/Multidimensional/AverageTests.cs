using System;
using System.Linq;
using Mulinq.Multidimensional;
using NUnit.Framework;

namespace Mulinq.Test.Multidimensional
{
    public class AverageTests
    {
        #region Regular

        [TestCase(1)]
        [TestCase(10)]
        public void Int32Test(int v)
        {
            const int n = 3;
            var sut = new int[n, n];
            for (var i = 0; i < n; i++)
                for (var j = 0; j < n; j++)
                    sut[i, j] = v;

            var seq = Enumerable.Repeat(v, n * n).ToArray();
            var expected = seq.Average();
            var actual = sut.Average();
            Assert.That(actual, Is.EqualTo(expected));

            int Selector(int x) => x * n;
            expected = seq.Average(Selector);
            actual = sut.Average(Selector);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(1)]
        [TestCase(10)]
        public void NullableInt32Test(int? v)
        {
            const int n = 3;
            var sut = new int?[n, n];
            for (var i = 0; i < n; i++)
                for (var j = 0; j < n; j++)
                    sut[i, j] = v;

            var seq = Enumerable.Repeat(v, n * n).ToArray();
            seq[0] = null;
            var expected = seq.Average();
            sut[0, 0] = null;
            var actual = sut.Average();
            Assert.That(actual, Is.EqualTo(expected));

            int? Selector(int? x) => x * n;
            expected = seq.Average(Selector);
            actual = sut.Average(Selector);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(1L)]
        [TestCase(10L)]
        public void Int64Test(long v)
        {
            const int n = 3;
            var sut = new long[n, n];
            for (var i = 0; i < n; i++)
                for (var j = 0; j < n; j++)
                    sut[i, j] = v;

            var seq = Enumerable.Repeat(v, n * n).ToArray();
            var expected = seq.Average();
            var actual = sut.Average();
            Assert.That(actual, Is.EqualTo(expected));

            long Selector(long x) => x * n;
            expected = seq.Average(Selector);
            actual = sut.Average(Selector);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(1L)]
        [TestCase(10L)]
        public void NullableInt64Test(long? v)
        {
            const int n = 3;
            var sut = new long?[n, n];
            for (var i = 0; i < n; i++)
                for (var j = 0; j < n; j++)
                    sut[i, j] = v;

            var seq = Enumerable.Repeat(v, n * n).ToArray();
            seq[0] = null;
            var expected = seq.Average();
            sut[0, 0] = null;
            var actual = sut.Average();
            Assert.That(actual, Is.EqualTo(expected));

            long? Selector(long? x) => x * n;
            expected = seq.Average(Selector);
            actual = sut.Average(Selector);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(0.3f)]
        [TestCase(0.5f)]
        [TestCase(1f)]
        public void SingleTest(float v)
        {
            const int n = 3;
            var sut = new float[n, n];
            for (var i = 0; i < n; i++)
                for (var j = 0; j < n; j++)
                    sut[i, j] = v;

            var seq = Enumerable.Repeat(v, n * n).ToArray();
            var expected = seq.Average();
            var actual = sut.Average();
            Assert.That(actual, Is.EqualTo(expected));

            float Selector(float x) => x * n;
            expected = seq.Average(Selector);
            actual = sut.Average(Selector);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(0.3f)]
        [TestCase(0.5f)]
        [TestCase(1f)]
        public void NullableSingleTest(float? v)
        {
            const int n = 3;
            var sut = new float?[n, n];
            for (var i = 0; i < n; i++)
                for (var j = 0; j < n; j++)
                    sut[i, j] = v;

            var seq = Enumerable.Repeat(v, n * n).ToArray();
            seq[0] = null;
            var expected = seq.Average();
            sut[0, 0] = null;
            var actual = sut.Average();
            Assert.That(actual, Is.EqualTo(expected));

            float? Selector(float? x) => x * n;
            expected = seq.Average(Selector);
            actual = sut.Average(Selector);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(0.3)]
        [TestCase(0.5)]
        [TestCase(1.0)]
        public void DoubleTest(double v)
        {
            const int n = 3;
            var sut = new double[n, n];
            for (var i = 0; i < n; i++)
                for (var j = 0; j < n; j++)
                    sut[i, j] = v;

            var seq = Enumerable.Repeat(v, n * n).ToArray();
            var expected = seq.Average();
            var actual = sut.Average();
            Assert.That(actual, Is.EqualTo(expected));

            double Selector(double x) => x * n;
            expected = seq.Average(Selector);
            actual = sut.Average(Selector);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(0.3)]
        [TestCase(0.5)]
        [TestCase(1.0)]
        public void NullableDoubleTest(double? v)
        {
            const int n = 3;
            var sut = new double?[n, n];
            for (var i = 0; i < n; i++)
                for (var j = 0; j < n; j++)
                    sut[i, j] = v;

            var seq = Enumerable.Repeat(v, n * n).ToArray();
            seq[0] = null;
            var expected = seq.Average();
            sut[0, 0] = null;
            var actual = sut.Average();
            Assert.That(actual, Is.EqualTo(expected));

            double? Selector(double? x) => x * n;
            expected = seq.Average(Selector);
            actual = sut.Average(Selector);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(0.3)]
        [TestCase(1)]
        [TestCase(1e18)]
        public void DecimalTest(Decimal v)
        {
            const int n = 3;
            var sut = new Decimal[n, n];
            for (var i = 0; i < n; i++)
                for (var j = 0; j < n; j++)
                    sut[i, j] = v;

            var seq = Enumerable.Repeat(v, n * n).ToArray();
            var expected = seq.Average();
            var actual = sut.Average();
            Assert.That(actual, Is.EqualTo(expected));

            Decimal Selector(Decimal x) => x * n;
            expected = seq.Average(Selector);
            actual = sut.Average(Selector);
            Assert.That(actual, Is.EqualTo(expected));
        }


        [TestCase(0.3)]
        [TestCase(1)]
        [TestCase(1e18)]
        public void NullableDecimalTest(Decimal? v)
        {
            const int n = 3;
            var sut = new Decimal?[n, n];
            for (var i = 0; i < n; i++)
                for (var j = 0; j < n; j++)
                    sut[i, j] = v;

            var seq = Enumerable.Repeat(v, n * n).ToArray();
            seq[0] = null;
            var expected = seq.Average();
            sut[0, 0] = null;
            var actual = sut.Average();
            Assert.That(actual, Is.EqualTo(expected));

            Decimal? Selector(Decimal? x) => x * n;
            expected = seq.Average(Selector);
            actual = sut.Average(Selector);
            Assert.That(actual, Is.EqualTo(expected));
        }

        #endregion

        #region NullSelector

        [Test]
        public void Int32NullSelectorTest()
        {
            const int n = 3;
            var sut = new int[n, n];
            Func<int, int>? selector = null;
            Assert.Throws<ArgumentNullException>(() => _ = sut.Average(selector));
        }

        [Test]
        public void NullableInt32NullSelectorTest()
        {
            const int n = 3;
            var sut = new int?[n, n];
            Func<int?, int?>? selector = null;
            Assert.Throws<ArgumentNullException>(() => _ = sut.Average(selector));
        }

        [Test]
        public void Int64NullSelectorTest()
        {
            const int n = 3;
            var sut = new long[n, n];
            Func<long, long>? selector = null;
            Assert.Throws<ArgumentNullException>(() => _ = sut.Average(selector));
        }

        [Test]
        public void NullableInt64NullSelectorTest()
        {
            const int n = 3;
            var sut = new long?[n, n];
            Func<long?, long?>? selector = null;
            Assert.Throws<ArgumentNullException>(() => _ = sut.Average(selector));
        }

        [Test]
        public void SingleNullSelectorTest()
        {
            const int n = 3;
            var sut = new float[n, n];
            Func<float, float>? selector = null;
            Assert.Throws<ArgumentNullException>(() => _ = sut.Average(selector));
        }

        [Test]
        public void NullableSingleNullSelectorTest()
        {
            const int n = 3;
            var sut = new float?[n, n];
            Func<float?, float?>? selector = null;
            Assert.Throws<ArgumentNullException>(() => _ = sut.Average(selector));
        }

        [Test]
        public void DoubleNullSelectorTest()
        {
            const int n = 3;
            var sut = new double[n, n];
            Func<double, double>? selector = null;
            Assert.Throws<ArgumentNullException>(() => _ = sut.Average(selector));
        }

        [Test]
        public void NullableDoubleNullSelectorTest()
        {
            const int n = 3;
            var sut = new double?[n, n];
            Func<double?, double?>? selector = null;
            Assert.Throws<ArgumentNullException>(() => _ = sut.Average(selector));
        }

        [Test]
        public void DecimalNullSelectorTest()
        {
            const int n = 3;
            var sut = new Decimal[n, n];
            Func<Decimal, Decimal>? selector = null;
            Assert.Throws<ArgumentNullException>(() => _ = sut.Average(selector));
        }

        [Test]
        public void NullableDecimalNullSelectorTest()
        {
            const int n = 3;
            var sut = new Decimal?[n, n];
            Func<Decimal?, Decimal?>? selector = null;
            Assert.Throws<ArgumentNullException>(() => _ = sut.Average(selector));
        }

        #endregion

        #region NullSource

        [Test]
        public void Int32NullSourceTest()
        {
            int[,]? sut = null;
            Assert.Throws<ArgumentNullException>(() => _ = sut.Average());
            Assert.Throws<ArgumentNullException>(() => _ = sut.Average(x => x));
        }

        [Test]
        public void NullableInt32NullSourceTest()
        {
            int?[,]? sut = null;
            Assert.Throws<ArgumentNullException>(() => _ = sut.Average());
            Assert.Throws<ArgumentNullException>(() => _ = sut.Average(x => x));
        }

        [Test]
        public void Int64NullSourceTest()
        {
            long[,]? sut = null;
            Assert.Throws<ArgumentNullException>(() => _ = sut.Average());
            Assert.Throws<ArgumentNullException>(() => _ = sut.Average(x => x));
        }

        [Test]
        public void NullableInt64NullSourceTest()
        {
            long?[,]? sut = null;
            Assert.Throws<ArgumentNullException>(() => _ = sut.Average());
            Assert.Throws<ArgumentNullException>(() => _ = sut.Average(x => x));
        }

        [Test]
        public void SingleNullSourceTest()
        {
            float[,]? sut = null;
            Assert.Throws<ArgumentNullException>(() => _ = sut.Average());
            Assert.Throws<ArgumentNullException>(() => _ = sut.Average(x => x));
        }

        [Test]
        public void NullableSingleNullSourceTest()
        {
            float?[,]? sut = null;
            Assert.Throws<ArgumentNullException>(() => _ = sut.Average());
            Assert.Throws<ArgumentNullException>(() => _ = sut.Average(x => x));
        }

        [Test]
        public void DoubleNullSourceTest()
        {
            double[,]? sut = null;
            Assert.Throws<ArgumentNullException>(() => _ = sut.Average());
            Assert.Throws<ArgumentNullException>(() => _ = sut.Average(x => x));
        }

        [Test]
        public void NullableDoubleNullSourceTest()
        {
            double?[,]? sut = null;
            Assert.Throws<ArgumentNullException>(() => _ = sut.Average());
            Assert.Throws<ArgumentNullException>(() => _ = sut.Average(x => x));
        }

        [Test]
        public void DecimalNullSourceTest()
        {
            Decimal[,]? sut = null;
            Assert.Throws<ArgumentNullException>(() => _ = sut.Average());
            Assert.Throws<ArgumentNullException>(() => _ = sut.Average(x => x));
        }

        [Test]
        public void NullableDecimalNullSourceTest()
        {
            Decimal?[,]? sut = null;
            Assert.Throws<ArgumentNullException>(() => _ = sut.Average());
            Assert.Throws<ArgumentNullException>(() => _ = sut.Average(x => x));
        }

        #endregion

        #region NoElements

        [Test]
        public void Int32NoElementsTest()
        {
            const int n = 0;
            var sut = new int[n, n];
            Assert.Throws<InvalidOperationException>(() => _ = sut.Average());
            Assert.Throws<InvalidOperationException>(() => _ = sut.Average(x => x));
        }

        [Test]
        public void NullableInt32NoElementsTest()
        {
            const int n = 0;
            var sut = new int?[n, n];
            var actual = sut.Average();
            Assert.That(actual, Is.Null);
        }

        [Test]
        public void Int64NoElementsTest()
        {
            const int n = 0;
            var sut = new long[n, n];
            Assert.Throws<InvalidOperationException>(() => _ = sut.Average());
            Assert.Throws<InvalidOperationException>(() => _ = sut.Average(x => x));
        }

        [Test]
        public void NullableInt64NoElementsTest()
        {
            const int n = 0;
            var sut = new long?[n, n];
            var actual = sut.Average();
            Assert.That(actual, Is.Null);
        }

        [Test]
        public void SingleNoElementsTest()
        {
            const int n = 0;
            var sut = new float[n, n];
            Assert.Throws<InvalidOperationException>(() => _ = sut.Average());
            Assert.Throws<InvalidOperationException>(() => _ = sut.Average(x => x));
        }

        [Test]
        public void NullableSingleNoElementsTest()
        {
            const int n = 0;
            var sut = new float?[n, n];
            var actual = sut.Average();
            Assert.That(actual, Is.Null);
        }

        [Test]
        public void DoubleNoElementsTest()
        {
            const int n = 0;
            var sut = new double[n, n];
            Assert.Throws<InvalidOperationException>(() => _ = sut.Average());
            Assert.Throws<InvalidOperationException>(() => _ = sut.Average(x => x));
        }

        [Test]
        public void NullableDoubleNoElementsTest()
        {
            const int n = 0;
            var sut = new double?[n, n];
            var actual = sut.Average();
            Assert.That(actual, Is.Null);
        }

        [Test]
        public void DecimalNoElementsTest()
        {
            const int n = 0;
            var sut = new Decimal[n, n];
            Assert.Throws<InvalidOperationException>(() => _ = sut.Average());
            Assert.Throws<InvalidOperationException>(() => _ = sut.Average(x => x));
        }

        [Test]
        public void NullableDecimalNoElementsTest()
        {
            const int n = 0;
            var sut = new Decimal?[n, n];
            var actual = sut.Average();
            Assert.That(actual, Is.Null);
        }

        #endregion
    }
}