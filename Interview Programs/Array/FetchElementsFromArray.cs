using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview_Programs.Array
{
    internal class FetchElementsFromArray
    {

        public static void Main(String[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            SumOfElements(numbers, out int sum);
            Console.WriteLine( sum );
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
