using NUnit.Framework;
using System;
using TaskChainingAndContinuation.Core;

namespace TaskChainingAndContinuation.Test
{
    public class ArrayMannagerTest
    {
        private readonly IArrayManager _arrayManger;

        public ArrayMannagerTest()
        {
            _arrayManger = new ArrayManager();
        }

        [TestCase(1, 100)]
        [TestCase(-100, 100)]
        public void CreateRandomArraySuccess(int min, int max)
        {
            var res = _arrayManger.CreateRandomArray(min, max);
            Assert.IsNotNull(res);
            Assert.AreEqual(10, res.Length);
        }

        [TestCase(1000, 100)]
        [TestCase(-100, -1000)]
        public void CreateRandomArrayFailure(int min, int max)
        {
            Assert.Throws<ArgumentException>(() => _arrayManger.CreateRandomArray(min, max));
        }

        [TestCase(new[] { 5, 15, 25, 35, 45 }, 10, ExpectedResult = new[] { 50, 150, 250, 350, 450 })]
        [TestCase(new[] { -10, -9, -5, 0, 0, 5, 1, 2 }, 10, ExpectedResult = new[] { -100, -90, -50, 0, 0, 50, 10, 20 })]
        public int[] MultiplyArrayByNumberSuccess(int[] array, int mult)
        {
            return _arrayManger.MultiplyArrayByNumber(array, mult);
        }

        [Test]
        public void MultiplyArrayByNumberFailure()
        {
            Assert.Throws<ArgumentNullException>(() => _arrayManger.MultiplyArrayByNumber(null, 10));
        }

        [Test]
        public void MultiplyArrayByNumberFailure2()
        {
            Assert.Throws<ArgumentException>(() => _arrayManger.MultiplyArrayByNumber(Array.Empty<int>(), 10));
        }

        [TestCase(new[] { 5, 15, 25, 35, 45 }, ExpectedResult = new[] { 5, 15, 25, 35, 45 })]
        [TestCase(new[] { -10, -9, -5, 0, 0, 5, 1, 2 }, ExpectedResult = new[] { -10, -9, -5, 0, 0, 1, 2, 5 })]
        public int[] SortArrayByAscendingSuccess(int[] array)
        {
            return _arrayManger.SortArrayByAscending(array);
        }

        [Test]
        public void SortArrayByAscendingFailure()
        {
            Assert.Throws<ArgumentNullException>(() => _arrayManger.SortArrayByAscending(null));
        }

        [Test]
        public void SortArrayByAscendingFailure2()
        {
            Assert.Throws<ArgumentException>(() => _arrayManger.SortArrayByAscending(Array.Empty<int>()));
        }

        [TestCase(new[] { 10, 10, 10, 10, 10 }, ExpectedResult = 10)]
        [TestCase(new[] { 5, 15, 25, 35, 45 }, ExpectedResult = 25)]
        public int AverageValueSuccess(int[] array)
        {
            return _arrayManger.AverageValue(array);
        }

        [Test]
        public void AverageValueFailure()
        {
            Assert.Throws<ArgumentNullException>(() => _arrayManger.AverageValue(null));
        }

        [Test]
        public void AverageValueFailure2()
        {
            Assert.Throws<ArgumentException>(() => _arrayManger.AverageValue(Array.Empty<int>()));
        }
    }
}