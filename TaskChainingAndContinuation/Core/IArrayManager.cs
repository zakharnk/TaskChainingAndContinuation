using System;
using System.Collections.Generic;
using System.Text;

namespace TaskChainingAndContinuation.Core
{
    public interface IArrayManager
    {
        public int[] CreateRandomArray(int min, int max);
        public int[] MultiplyArrayByNumber(int[] array, int number);
        public int[] SortArrayByAscending(int[] array);
        public int AverageValue(int[] array);
    }
}
