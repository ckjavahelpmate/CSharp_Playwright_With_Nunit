using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview_Programs.Strings_Programs
{
    internal class StringProgramsDay02
    {
        //Check text is substring of given String?
        public static bool IsPresent(String text, String subtext)
        {
            if( text.Length != subtext.Length)
            {
                return false;
            }
            for( int i=0; i<text.Length; i++ )
            {
                int j = 0, k = i;
                while( j<subtext.Length && subtext[j] == text[k])
                {
                    j++; k++;
                }
                if( j==subtext.Length)
                {
                    return true;
                }
            }
            return false;
        }

        //Check Given Strings are Anagram or not?
        public static bool IsAnagram(String text1, String text2)
        {
            text1 = text1.Trim().ToLower(); text2 = text2.Trim().ToLower();

            char[] char1 = text1.ToCharArray(); char[] char2 = text2.ToCharArray();

            Array.Sort(char1); Array.Sort(char2);

           return char1.SequenceEqual(char2);
        }

        //Check Given String is Palindrome or not?
        public static bool IsPalindrome(String text)
        {
            for(int i=0, j=text.Length-1; i<j; i++, j-- )
            {
                if(text[i] != text[j] )
                {
                    return false;
                }
            }
            return true;
        }

        //Reverse characters in each word without changing words sequency?
        public static String ReverseCharactersOfWords(String text)
        {
            String[] words = text.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = new string(words[i].Reverse().ToArray());
            }
            return String.Join(" ", words);
        }
        //Reverse words in Given String?
        public static String ReverseWordsOfText(String text)
        {
            String[] words = text.Split(' ');

            for (int i = 0, j = words.Length - 1; i < j; i++, j--)
            {
                (words[i], words[j]) = (words[j], words[i]);
            }

            return String.Join(" ", words);
        }

        // Reverse Given String?
        public static String ReverseString(String text)
        {
            StringBuilder sb = new();
            for (int i = text.Length - 1; i >= 0; i--)
            {
                sb.Append(text[i]);
            }
            return sb.ToString();
        }

        public static void Main(String[] args)
        {

            Console.WriteLine( IsPresent("Dinga Loves Dingi" , "Dinga") );
            Console.WriteLine( IsPresent("Dinga Loves Dingi" , "Dingi") );
            Console.WriteLine( IsPresent("Dinga Loves Dingi" , "ves D") );

            //Console.WriteLine(IsAnagram("Cab", "BCA"));
            //Console.WriteLine(IsAnagram("Dirtyroom", "Dormitory"));
            //Console.WriteLine(IsAnagram("Mava", "java"));

            //Console.WriteLine( IsPalindrome("madam") );
            //Console.WriteLine( IsPalindrome("Java") );
            //Console.WriteLine( IsPalindrome("ab121ba") );

            //Console.WriteLine( ReverseCharactersOfWords("Dinga Loves Dingi So Much") );

            //Console.WriteLine( ReverseWordsOfText("Dinga Loves Dingi So Much") );

            //Console.WriteLine(ReverseString("java"));
        }
    }
}
