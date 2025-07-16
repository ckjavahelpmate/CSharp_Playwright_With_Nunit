using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview_Programs.Strings_Programs
{
    internal class StringProgramsday03
    {
        //Remove duplicates from String?
        public static String RemoveDuplicate(String text)
        {
            HashSet<char> set = [];

            foreach (char ch in text)
            {
                set.Add(ch);
            }
            StringBuilder sb = new();
            foreach (char ch in set)
            {
                sb.Append(ch);
            }
            return sb.ToString();
        }

        //Return frequency of characters in String?
        public static Dictionary<char, int> FrequencyOfCharsIntext(String text)
        {
            Dictionary<char, int> frequency = [];
            foreach (char ch in text)
            {
                if (frequency.ContainsKey(ch))
                {
                    frequency[ch]++;
                }
                else
                {
                    frequency[ch] = 1;
                }
            }
            return frequency;
        }

        // Print duplicate characters in string?
        public static void DuplicateCharacters(String text)
        {
            Dictionary<char, int> frequency = [];
            foreach (char ch in text)
            {
                if (frequency.ContainsKey(ch))
                {
                    frequency[ch]++;
                }
                else
                {
                    frequency[ch] = 1;
                }
            }
            foreach( KeyValuePair<char, int> kvp in frequency)
            {
                if( kvp.Value>1)
                {
                    Console.WriteLine(kvp);
                }
            }
        }
        // Print Non repeated characters in string?
        public static void NonRepeatedCharacters(String text)
        {
            Dictionary<char, int> frequency = [];
            foreach (char ch in text)
            {
                if (frequency.ContainsKey(ch))
                {
                    frequency[ch]++;
                }
                else
                {
                    frequency[ch] = 1;
                }
            }
            foreach( KeyValuePair<char, int> kvp in frequency)
            {
                if( kvp.Value==1)
                {
                    Console.WriteLine(kvp);
                }
            }
        }

        //Return sum digits in String?
        public static int sumOfDigit(String text)
        {
            int sum = 0;
            foreach(char ch in text)
            {
                if( char.IsDigit(ch) )
                {
                    sum += ch-48;
                }
            }
            return sum;
        }
        public static void Main(String[] args)
        {



            //Console.WriteLine( sumOfDigit("Ding143Dingi420") );

            //NonRepeatedCharacters("Programmer");

            //DuplicateCharacters("Programmer");

            //foreach(KeyValuePair<char,int> kvp in FrequencyOfCharsIntext("Programmer"))
            //{
            //    Console.WriteLine( kvp );
            //}

            //Console.WriteLine(RemoveDuplicate("Programmer"));
        }
    }
}
