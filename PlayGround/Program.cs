using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PlayGround
{
    class Program
    {
        static void Main(string[] args)
        {
            // Convert string to char array  
            //https://docs.microsoft.com/en-us/dotnet/api/system.string.chars?view=netcore-3.1
            //https://docs.microsoft.com/en-us/dotnet/api/system.string.substring?view=netcore-3.1
            //string sentence = "Mahesh Chand";
            //char[] charArr = sentence.ToCharArray();
            //foreach (char ch in charArr)
            //{

            //    Console.WriteLine(ch);
            //}

            // Convert char array to string  
            /*char[] chars = new char[10];
            chars[0] = 'M';
            chars[1] = 'a';
            chars[2] = 'h';
            chars[3] = 'e';
            chars[4] = 's';
            chars[5] = 'h';
            string charsStr = new string(chars);
            string charsStr2 = new string(new char[]
            {'T','h','i','s',' ','i','s',' ','a',' ','s','t','r','i','n','g'});
            Console.WriteLine("Chars to string: {0}", charsStr);
            Console.WriteLine("Chars to string: {0}", charsStr2);

            string abc = "abc";
            char getresult = abc.Where((item, index) => index == 2).Single();

            string value = "Dot Net Perls";
            char first = value[0];
            char second = value[1];
            char last = value[value.Length - 1];

            string str1 = "Test";
            for (int ctr = 0; ctr <= str1.Length - 1; ctr++)
                Console.Write("{0} ", str1[ctr]);

            string s1 = "The quick brown fox jumps over the lazy dog";
            string s2 = "fox";
            bool b = s1.Contains(s2);
            Console.WriteLine("'{0}' is in the string '{1}': {2}",
                            s2, s1, b);
            if (b)
            {
                int index = s1.IndexOf(s2);
                if (index >= 0)
                    Console.WriteLine("'{0} begins at character position {1}",
                                  s2, index + 1);
            }*/
            // This example displays the following output:
            //    'fox' is in the string 'The quick brown fox jumps over the lazy dog': True
            //    'fox begins at character position 17
            /*for (var i = 1; i <= 99; i++)
            {

                if (i % 3 == 0 && i % 7 == 0)
                {
                    Console.WriteLine("OpenSource" + i);

                }
                else if (i % 7 == 0)
                {

                    Console.WriteLine("Source");

                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Open");
                }


            }*/
            //float f = 53.005f;
            //double f1 = -17976931.348623158E+301;
            //double f2 = 222507385850.72014E-308;
            //double f3 = -123.0000e-20;
            //double d = 2345.7652;
            // Console.WriteLine(f1);
            //Console.WriteLine(f2);
            //Console.WriteLine(f2 - f3);
            //Console.WriteLine(f2 - 222507385140.72014E-308); 

            NumberFormatInfo setPrecision = new NumberFormatInfo();

            setPrecision.NumberDecimalDigits = 2;

            //decimal test = 1.22223m;

            //Console.Write(test.ToString("N", setPrecision)); //Should write 1.23

            //decimal[] values = { 1.45m, 1.55m, 123.456789m, 123.456789m,
            //               123.456789m, -123.456m,
            //               new Decimal(1230000000, 0, 0, true, 7 ),
            //               new Decimal(1230000000, 0, 0, true, 7 ),
            //               -9999999999.9999999999m,
            //               -9999999999.9999999999m };
            //// Define a set of integers to for decimals argument.
            //int[] decimals = { 1, 1, 4, 6, 8, 0, 3, 11, 9, 10 };

            //Console.WriteLine("{0,26}{1,8}{2,26}",
            //                  "Argument", "Digits", "Result");
            //Console.WriteLine("{0,26}{1,8}{2,26}",
            //                  "--------", "------", "------");
            //for (int ctr = 0; ctr < values.Length; ctr++)
            //    Console.WriteLine("{0,26}{1,8}{2,26}",
            //                      values[ctr], decimals[ctr],
            //                      Decimal.Round(values[ctr], decimals[ctr]));

            decimal testDec = 2.374m; // 2.37
            decimal testDec1 = 2.365m; // 2.36
            decimal testDec2 = 2.375m; // 2.38
            decimal testDec3 = 2.376m; // 2.38

            Console.WriteLine(Decimal.Round(testDec, 2));
            Console.WriteLine(Decimal.Round(testDec1, 2));
            Console.WriteLine(Decimal.Round(testDec2, 2));
            Console.WriteLine(Decimal.Round(testDec3, 2));

            double[][] m = new double[4][];  // 4 rows
            for (int i = 0; i < 4; ++i)
                m[i] = new double[3];  // 3 columns per row

            double[,] m2 = new double[4, 3];  // 4x3
            m2[0, 1] = -1.2345;  // row 0, col 1


            List<string> stringList = new List<string>() { "3", "200", "k", "kol", "3" };

            int totalSum = 0;

            foreach(var listValue in stringList) 
            {
                //if(listValue.Length == 1)
                 //  {
                    try {

                    totalSum = totalSum + int.Parse(listValue);
                    //Console.WriteLine(totalSum);

                    }
                    catch
                    {

                    }

               // }
            }

        }
    }
}
