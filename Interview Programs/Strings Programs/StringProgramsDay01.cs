using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview_Programs.Strings_Programs
{
    internal class StringProgramsDay01
    {
        //Print Vowels Present in String?
        public static void PrintVowelsOfGivenString(String text)
        {
            String vowels = "aeiouAEIOU";
            foreach (char ch in text)
            {
                if (vowels.Contains(ch))
                {
                    Console.WriteLine(ch);
                }
            }
        }

        // Count Upper case, Lower case, Digits and Special chars in String?
        public static (int uppercase, int lowercase, int digits, int specialChars) CountChars(String text)
        {
            int upperCase = 0, lowerCase = 0, digits = 0, specialChars = 0;

            foreach (char ch in text)
            {
                if (char.IsUpper(ch))
                {
                    upperCase++;
                }
                else if (char.IsLower(ch))
                {
                    lowerCase++;
                }
                else if (char.IsDigit(ch))
                {
                    digits++;
                }
                else
                {
                    specialChars++;
                }
            }
            return (upperCase, lowerCase, digits, specialChars);

        }

        //Check String contains Only numbers?
        public static bool IsAllDigits(String text)
        {
            if (string.IsNullOrEmpty(text))
                return false;
            foreach (char ch in text)
            {
                if (!char.IsDigit(ch))
                {
                    return false;
                }
            }
            return true;
        }


        //Remove Space and Print given String?
        public static String RemoveSpace(String text)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in text)
            {
                if (c != ' ')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        //Check Given char is present in Given String?
        public static bool IsPresent(String text, char key)
        {
            foreach( char ch in text)
            {
                if( ch==key )
                {
                    return true;
                }
            }
            return false;
        }

        // Return index of given character?
        public static int GetIndex(String text , char key)
        {
            int index = 0;
            foreach( char ch in text)
            {
                if( ch==key)
                {
                    return index;
                }
                index++;
            }
            return text.IndexOf(key);
        }

        // Return the occurrence of given character in String?
        public static int GetOccurrence(String text, char key)
        {
            int occurrence = 0 ;
            foreach( char ch in text)
            {
                if( ch == key)
                {
                    occurrence++;
                }
            }
            return occurrence;
        }

        // Convert Uppercase into Lowercase & vice versa?
        public static String CaseConvertion(String text)
        {
            StringBuilder sb = new StringBuilder(); 
            foreach( char ch in text)
            {
                if( char.IsUpper(ch) )
                {
                    sb.Append( (char)(ch+32));
                }
                else if ( char.IsLower(ch) )
                {
                    sb.Append( (char)(ch-32) );
                }
                else
                {
                    sb.Append( ch );
                }
            }
            return sb.ToString();
        }

        // Convert Every word first character into Upper case?
        public static String ToTitleCase(String text)
        {
            char[] chars = text.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (i == 0 && char.IsLower(chars[i]))
                {
                    chars[i] = (char)(chars[i] - 32);
                }
                if (chars[i] == ' ' && i < chars.Length && char.IsLower(chars[i + 1]))
                {
                    chars[i + 1] = (char)(chars[i + 1] - 32);
                }
            }
            return new String(chars);
        }

        public static void Main(String[] args)
        {

            //Console.WriteLine( ToTitleCase( text: "dinga is a programmer" ) );

            //Console.WriteLine( CaseConvertion("Dinga Loves Dingi") );

            //Console.WriteLine( GetOccurrence("Programmer" , 'a') ); //1
            //Console.WriteLine( GetOccurrence("Programmer" , 'r') ); //3
            //Console.WriteLine( GetOccurrence("Programmer" , 'm') ); //2

            //Console.WriteLine(GetIndex("Programmer", 'g'));
            //Console.WriteLine(GetIndex("Programmer", 'x'));

            //Console.WriteLine(IsPresent("Programmer", 'g') );
            //Console.WriteLine(IsPresent("Programmer", 'x') );

            //Console.WriteLine(RemoveSpace("Ding loves Dingi") );

            //Console.WriteLine(IsAllDigits("Demo123"));
            //Console.WriteLine(IsAllDigits("Demo"));
            //Console.WriteLine(IsAllDigits("123"));

            //(int uppercase, int lowercase, int digits, int specialChars)  = CountChars("Programmer");
            //Console.WriteLine( $"Upper case={uppercase}");
            //Console.WriteLine( $"Lower case={lowercase}");
            //Console.WriteLine( $"Digits={digits}");
            //Console.WriteLine( $"Special chars={specialChars}");







        }
    }
}
