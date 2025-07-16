using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Interview_Programs.Array_Programs
{
    internal class FetchElementsFromArray
    {

        public static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] duplicates = { 1, 2, 1, 3, 1, 4, 5, 3, 4 };
            int[] maxmin = { 40, 10, 50, 20, 60, 30, 60 };

            LogestSubArrayOfKSum(duplicates, 4, out int maxLength);
            Console.WriteLine($"Max Length = {maxLength}");
        }

        // Return Longest subArray with K sum
        public static void LogestSubArrayOfKSum(int[] arr, int k, out int maxLength)
        {
            Dictionary<int, int> prefixSum = new Dictionary<int, int>();
            int currentSum = 0;
            maxLength = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                currentSum += arr[i];

                if (currentSum == k)
                {
                    maxLength = i + 1;
                }

                if (prefixSum.ContainsKey(currentSum - k))
                {
                    int previousIndex = prefixSum[currentSum - k];
                    maxLength = Math.Max(maxLength, i - previousIndex);
                }

                if (!prefixSum.ContainsKey(currentSum))
                {
                    prefixSum[currentSum] = i;
                }
            }
        }

        // Find SecondMax element in Array
        public static void SecondMax(int[] arr, out int max, out int secondMax)
        {
            max = int.MinValue; secondMax = int.MinValue;
            foreach (int num in arr)
            {
                if (num > max)
                {
                    secondMax = max;
                    max = num;
                }
                else if (num > secondMax && num != max)
                {
                    secondMax = num;
                }
            }
        }

        // Find Max element in Array
        public static void Max(int[] arr, out int max)
        {
            max = int.MinValue;
            foreach (int num in arr)
            {
                if (num > max)
                {
                    max = num;
                }
            }
        }

        // Find the occurrence of given element
        public static void OccurrenceOfElementInArray(int[] arr, int key, out int occurrence)
        {
            occurrence = 0;
            foreach (int num in arr)
            {
                if (num == key)
                {
                    occurrence++;
                }
            }
        }

        // Find Given element is present or not
        public static void IsPresent(int[] arr, out bool isPresent, int key)
        {
            isPresent = false;
            foreach (int num in arr)
            {
                if (num == key)
                {
                    isPresent = true;
                }
            }
        }

        // Find Sum of Even elements
        public static void SumOfEvenElements(int[] arr, out int sum)
        {
            sum = 0;
            foreach (int num in arr)
            {
                if (num % 2 == 0)
                {
                    sum += num;
                }
            }
        }

        //Find sum array elements
        public static void SumOfElements(int[] numbers, out int sum)
        {
            sum = 0;
            foreach (int element in numbers)
            {
                sum += element;
            }
        }

    }
}
