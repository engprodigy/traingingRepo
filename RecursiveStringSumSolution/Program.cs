using System;
using System.Collections.Generic;

namespace RecursiveStringSumSolution
{
    class Program
    {
        static int stringArray(List<string> stringList, int totalSum)
        {
            //Console.Write(totalSum + "space");
            int Sum = 0;
            if (stringList.Count == 0)
            {
                return totalSum;
            }
            else
            {
                var valueAtIndex = stringList[0];
                try
                {

                    Sum = int.Parse(valueAtIndex);
                    // totalSum = int.Parse(valueAtIndex);
                    // Console.Write(totalSum + "space");
                }
                catch
                {

                }
                stringList.Remove(valueAtIndex);
            }



            //return totalSum = totalSum + stringArray(stringList, totalSum);

            return stringArray(stringList, totalSum + Sum);

        }

        static void Main()
        {
            int x = 10;
            int y = 25;
            int z = x + y;
            List<string> stringList = new List<string>() { "3", "200", "k", "kol", "3" };

            //stringArray(stringList, 0);

            Console.Write(stringArray(stringList, 0));
            //Console.Write("Sum of x + y = "+ z);
        }
    }
}
