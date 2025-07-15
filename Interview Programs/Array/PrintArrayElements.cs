using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview_Programs.Array
{
    internal class PrintArrayElements
    {
        public static void Main(string[] args)
        {
            int[] arr = { 1, 2, 1, 3, 1, 4, 5, 3, 4 };
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] palindroms = { 101, 223, 333, 4054, 5005, 64, 777, 128, 45954 };

            int[] nums1 = { 1, 2, 4, 5, 2, 6 };
            int[] nums2 = { 4, 7, 3, 6, 8 };

            //PrintUniqueElementsOfArray(nums1, nums2);

        }

        //Print Unique elements in 2 array
        public static void PrintUniqueElementsOfArray(int[] arr1, int[] arr2)
        {
            HashSet<int> common = new HashSet<int>();
            HashSet<int> uniq = new HashSet<int>();

            foreach (int element in arr1)
            {
                common.Add(element);
                uniq.Add(element);
            }
            foreach (int element in arr2)
            {
                if (!common.Contains(element))
                {
                   uniq.Add(element);
                }
                else
                {
                    uniq.Remove(element);
                }
            }
            foreach (var item in uniq)
            {
                Console.WriteLine(item);
            }
        }

        //Print Common elements in 2 array
        public static void PrintCommonElementsOfArray(int[] arr1, int[] arr2)
        {
            HashSet<int> common = new HashSet<int>();
            foreach (int element in arr1)
            {
                common.Add(element);
            }
            foreach (int element in arr2)
            {
                if (common.Contains(element))
                {
                    Console.WriteLine(element);
                }
            }
        }

        //Print non repeated elements of Array
        public static void PrintNonRepeatedElementsOfArray(int[] arr)
        {
            Dictionary<int, int> frequency = new Dictionary<int, int>();
            foreach (int element in arr)
            {
                if (frequency.ContainsKey(element))
                {
                    frequency[element]++;
                }
                else
                {
                    frequency[element] = 1;
                }
            }
            foreach (KeyValuePair<int, int> kvp in frequency)
            {
                if (kvp.Value == 1)
                {
                    Console.WriteLine($"{kvp.Key} ==> {kvp.Value}");
                }
            }

        }

        //Print duplicate elements in array
        public static void PrintDuplicateElementsOfArray(int[] arr)
        {
            Dictionary<int, int> frequency = new Dictionary<int, int>();
            foreach (int element in arr)
            {
                if (frequency.ContainsKey(element))
                {
                    frequency[element]++;
                }
                else
                {
                    frequency[element] = 1;
                }
            }
            foreach (KeyValuePair<int, int> kvp in frequency)
            {
                if (kvp.Value > 1)
                {
                    Console.WriteLine($"{kvp.Key} ==> {kvp.Value}");
                }
            }

        }

        //Print Frequency of Array using Dictionary
        public static void FrequencyOfArrayUsingDictionary(int[] arr)
        {
            Dictionary<int, int> fq = new Dictionary<int, int>();
            foreach (int element in arr)
            {
                if (fq.ContainsKey(element))
                {
                    fq[element]++;
                }
                else
                {
                    fq[element] = 1;
                }
            }
            foreach (var entry in fq)
            {
                Console.WriteLine($"{entry.Key} ==> {entry.Value}");
            }
        }

        //Print frequency of Array
        public static void FrequencyOfArray(int[] arr)
        {
            bool[] visited = new bool[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                if (!visited[i])
                {
                    int count = 1;
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        if (arr[i] == arr[j])
                        {
                            count++;
                            visited[j] = true;
                        }
                    }
                    Console.WriteLine($"{arr[i]} ==> {count}");
                }
            }
        }

        //Print Palindrome Numbers of Array
        public static void PalindromeNumberOfArray(int[] arr)
        {
            foreach (int element in arr)
            {
                if (IsPalindrome(element))
                {
                    Console.WriteLine(element);
                }
            }
        }
        public static bool IsPalindrome(int num)
        {
            string str = num + "";
            for (int i = 0, j = str.Length - 1; i < j; i++, j--)
            {
                if (str[i] != str[j])
                {
                    return false;
                }
            }
            return true;
        }

        // print prime numbers of Array
        public static void PrimeNumberOfArray(int[] arr)
        {
            foreach (int element in arr)
            {
                if (IsPrime(element))
                {
                    Console.WriteLine(element);
                }
            }
        }
        public static bool IsPrime(int num)
        {
            int count = 0;
            for (int i = 1; i <= num; i++)
            {
                if (num % i == 0)
                {
                    count++;
                }
                if (count > 2)
                {
                    return false;
                }
            }
            return count == 2;
        }

        //Print Even elements in array
        public static void EvenElementsOfArray(int[] arr)
        {
            foreach (var element in arr)
            {
                if (element % 2 == 0)
                {
                    Console.Write(element + ", ");
                }
            }
        }

        // Print Array elements in forward order
        public static void printArrayElementsInForwardOrder(int[] arr)
        {
            foreach (var element in arr)
            {
                Console.Write(element + ", ");
            }

        }

        // Print Array elements in reverse order
        public static void ReverseOrder(int[] arr)
        {
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                Console.Write(arr[i] + ", ");
            }
        }

        // First In Last Order
        public static void FirstAndLastOrder(int[] arr)
        {
            for (int i = 0, j = arr.Length - 1; i <= j; i++, j--)
            {
                if (i < j)
                {
                    Console.Write($"{arr[i]}, {arr[j]}, ");
                }
                else
                {
                    Console.Write(arr[j]);
                }
            }
        }
    }

}
