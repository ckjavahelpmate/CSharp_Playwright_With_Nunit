using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDrivenTesting.Tests
{
    internal class StringProgram
    {


        [Test]
        public async Task demo()
        {

            string str = "InFoViSiOn";

            char[] chars = str.ToCharArray();

            for( int i=0; i < chars.Length; i++)
            {
                char ch = chars[i];

                if( ch>='A' && ch<='Z')
                {
                    chars[i] = (char)(ch + 32);
                }
                else if (ch >= 'a' && ch <= 'z')
                {
                    chars[i] = (char)(ch - 32);
                }
            }

            string str2 = new string(chars);

            Console.WriteLine(str2);    
                
        }


    }
}
