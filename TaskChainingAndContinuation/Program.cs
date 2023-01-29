using System;
using System.Threading.Tasks;
using TaskChainingAndContinuation.Core;

namespace TaskChainingAndContinuation
{
    public static class Program
    {
        static async Task Main(string[] args)
        {
            Random random = new Random();

            ArrayManager arrayManager = new ArrayManager();

            Task<int[]> createArrayTask = Task.Run(() =>
            {
                var res = arrayManager.CreateRandomArray(0, 100);
                Console.WriteLine("Generated Array: ");
                PrintArray(res);
                return res;
            });

            await createArrayTask
                .ContinueWith(task =>
                {
                    var number = random.Next(0, 100);
                    Console.WriteLine($"Random Number {number}");
                    var res = arrayManager.MultiplyArrayByNumber(task.Result,number);
                    Console.WriteLine("Multiped Array: ");
                    PrintArray(res);
                    return res;
                })
                .ContinueWith(task =>
                {
                    var res = arrayManager.SortArrayByAscending(task.Result);
                    Console.WriteLine("Sorted Array: ");
                    PrintArray(res);
                    return res;
                }, TaskContinuationOptions.OnlyOnRanToCompletion)
                .ContinueWith(task =>
                {
                    var average = arrayManager.AverageValue(task.Result);
                    Console.WriteLine($"Average:{average} ");
                });
        }

        private static void PrintArray(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }
    }
}
