using System;
using System.Linq;

namespace TaskChainingAndContinuation.Core
{
    public class ArrayManager : IArrayManager
    {
        private readonly int arrayLength = 10;

        /// <summary>
        /// Creates an array of 10 random integers.
        /// </summary>
        /// <param name="min">Min range value.</param>
        /// <param name="max">Max range value.</param>
        /// <returns>An array of 10 random integers.</returns>
        /// <exception cref="ArgumentException">If value of max is greater than min.</exception>
        /// <exception cref="ArgumentNullException">If array is null.</exception>
        /// <exception cref="ArgumentException">If array has no elements.</exception>
        public int[] CreateRandomArray(int min, int max)
        {
            if (max < min)
            {
                throw new ArgumentException(nameof(max));
            }

            Random random = new Random();
            return Enumerable.Range(0, arrayLength).Select(i => random.Next(min, max)).ToArray();
        }

        /// <summary>
        /// Multiples the array by number
        /// </summary>
        /// <param name="array">Array to multiply.</param>
        /// <param name="number">Multiplication value. </param>
        /// <returns> A new multiplied array.</returns>
        /// <exception cref="ArgumentNullException">If array is null.</exception>
        /// <exception cref="ArgumentException">If array has no elements.</exception>
        public int[] MultiplyArrayByNumber(int[] array, int number)
        {
            ValidateArray(array);
            
            return array.Select(i => number * i).ToArray();
        }

        /// <summary>
        /// Sorts array ascending.
        /// </summary>
        /// <param name="array">Array with values.</param>
        /// <returns>Sorted array.</returns>
        /// <exception cref="ArgumentNullException">If array is null.</exception>
        /// <exception cref="ArgumentException">If array has no elements.</exception>
        public int[] SortArrayByAscending(int[] array)
        {
            ValidateArray(array);

            return array.OrderBy(x => x).ToArray();
        }

        /// <summary>
        /// Calculates an average value.
        /// </summary>
        /// <param name="array">Array with values to calcluate avg value.</param>
        /// <returns>Average value.</returns>
        /// <exception cref="ArgumentNullException">If array is null.</exception>
        /// <exception cref="ArgumentException">If array has no elements.</exception>
        public int AverageValue(int[] array)
        {
            ValidateArray(array);

            return (int)array.Average(); 
        }

        /// <summary>
        /// Validate an array.
        /// </summary>
        /// <param name="array">Array to check.</param>
        private void ValidateArray(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 0)
            {
                throw new ArgumentException(nameof(array));
            }
        }
    }
}