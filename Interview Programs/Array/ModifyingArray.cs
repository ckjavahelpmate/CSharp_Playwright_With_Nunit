using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview_Programs.Array
{
    internal class ModifyingArray
    {
        public static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7 };
            int[] duplicates = { 1, 2, 1, 3, 1, 4, 5, 3, 4 };
            int[] unsorted = { 5, 1, 4, 2, 6, 3, 5 };
            int[] withzeros = { 0, 1, 02, 0, 0, 3, 4, 0, 5 };

            MoveALlZerosToLeft( ref withzeros);

            Console.WriteLine(String.Join(", ", withzeros));
        }

        // Move All Zero's to right
        public static void MoveALlZerosToRight( ref int[] arr)
        {
            int[] temp = new int[arr.Length];
            for (int i = 0, j = 0; i < arr.Length; i++ )
            {
                if (arr[i] != 0 )
                {
                    temp[j++] = arr[i];
                }
            }
            arr = temp;
        }

        // Move All Zero's to left
        public static void MoveALlZerosToLeft(ref int[] arr)
        {
            int[] temp = new int[arr.Length];
            for (int i = arr.Length-1, j = temp.Length-1; i>= 0; i--)
            {
                if (arr[i] != 0)
                {
                    temp[j--] = arr[i];
                }
            }
            arr = temp;
        }

        // Sortv Array using Insertion Sort 
        public static void InsertionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int temp = arr[i];
                int j = i;
                while (j > 0 && temp < arr[j - 1])
                {
                    arr[j] = arr[j - 1];
                    j--;
                }
                arr[j] = temp;
            }
        }


        // Sort Array Using Selection sort
        public static void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    (arr[i], arr[minIndex]) = (arr[minIndex], arr[i]);
                }
            }
        }

        // Sort Array Using bubble sort
        public static void BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[i] < arr[j])
                    {
                        (arr[j], arr[i]) = (arr[i], arr[j]);
                    }
                }
            }
        }

        // Remove Duplicate From array
        public static void RemoveDuplicatesOfArray(int[] arr)
        {
            HashSet<int> set = new HashSet<int>();
            foreach (int element in arr)
            {
                set.Add(element);
            }
            int[] temp = new int[set.Count];
            int index = 0;
            foreach (int element in set)
            {
                temp[index++] = element;
            }
            Console.WriteLine(String.Join(", ", temp));
        }


        // Right Rotate array given steps
        public static void RightReateArray(int[] arr, int steps)
        {
            while (steps > 0)
            {
                int temp = arr[arr.Length - 1];
                for (int i = arr.Length - 1; i > 0; i--)
                {
                    arr[i] = arr[i - 1];
                }
                arr[0] = temp;
                steps--;
            }
            Console.WriteLine(string.Join(", ", arr));
        }

        // Left Rotate array given steps
        public static void LeftReateArray(int[] arr, int steps)
        {
            while (steps > 0)
            {
                int temp = arr[0];
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }
                arr[arr.Length - 1] = temp;
                steps--;
            }
            Console.WriteLine(string.Join(", ", arr));
        }

        // Reverse Array
        public static void ReverseArray(int[] arr)
        {
            for (int i = 0, j = arr.Length - 1; i < j; i++, j--)
            {
                (arr[j], arr[i]) = (arr[i], arr[j]);
            }
            Console.WriteLine(string.Join(", ", arr));
        }

    }

}
