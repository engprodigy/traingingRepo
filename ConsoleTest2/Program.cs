using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;



namespace ConsoleTest2
{
    class GFG : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x == 0 || y == 0)
            {
                return 0;
            }

            // CompareTo() method 
            return x.CompareTo(y);

        }
    }
    class Result
    {
        static bool ContainsLoop(List<int> list, int value)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == value)
                {
                    return true;
                }
            }
            return false;
        }
        /*
         * Complete the 'countMeetings' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER_ARRAY firstDay
         *  2. INTEGER_ARRAY lastDay
         */

        public static int countMeetings(List<int> firstDay, List<int> lastDay)
        {
            

            GFG gg = new GFG();
            firstDay.Sort(gg);


           // List<int> nOfInvestorsFreeDays = new List<int>();

            IDictionary<int, int> nOfInvestorsFreeDays = new Dictionary<int, int>();
            List<int> nOfInvestorsFreeLastDays = new List<int>();
            //int maxLastDay = nOfInvestorsFreeDays.Max(r => r);
            //int minLastDay = lastDay.Min(r => r);

            //List<int> mergedList = new List<int>();
            int maxDay = firstDay[0];

            for (var i = 0; i < firstDay.Count(); i++)
            {

                if (i == 0 && maxDay <= firstDay[i])
                {
                    nOfInvestorsFreeDays.Add(firstDay[i], firstDay[i]);
                    maxDay = firstDay[i];
                }
               
                else if (maxDay < firstDay[i])
                {
                    nOfInvestorsFreeDays.Add(firstDay[i], firstDay[i]);
                    maxDay = firstDay[i];
                }
                else
                {

                    nOfInvestorsFreeLastDays.Add(lastDay[i]);

                }


            }



            if (nOfInvestorsFreeLastDays.Count() == 0)
            {
                return nOfInvestorsFreeDays.Count();
            }
            var minDay = nOfInvestorsFreeLastDays.Min();
            
            nOfInvestorsFreeLastDays.Sort(gg);

            for (var i = 0; i < nOfInvestorsFreeLastDays.Count(); i++)
            {

                if (minDay <= nOfInvestorsFreeLastDays[i] && !nOfInvestorsFreeDays.ContainsKey(minDay))
                {
                    nOfInvestorsFreeDays.Add(minDay, minDay);
                    minDay++;
                }
                else
                {
                    if (i + 1 < nOfInvestorsFreeLastDays.Count())
                    {
                        minDay = nOfInvestorsFreeLastDays[i + 1];
                    }

                }


            }

           



            Console.WriteLine(nOfInvestorsFreeDays.Count());
            return 1;
        }

    }

    class Program
    {
            public static void Main(string[] args)
            {
                //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

               // int firstDayCount = Convert.ToInt32(Console.ReadLine().Trim());

                //List<int> firstDay = new List<int>(){1,2,3,4,5};
             List<int> firstDay = new List<int>(){1,2,1,2,2}; 
            //List<int> firstDay = new List<int>() { 1, 2, 3, 3, 3 };

            //for (int i = 0; i < firstDayCount; i++)
            //{
            //    int firstDayItem = Convert.ToInt32(Console.ReadLine().Trim());
            //    firstDay.Add(firstDayItem);
            //}

            // int lastDayCount = Convert.ToInt32(Console.ReadLine().Trim());

            //List<int> lastDay = new List<int>(){6,7,8,9,10};
             List<int> lastDay = new List<int>(){3,2,1,3,3};
           // List<int> lastDay = new List<int>() { 2, 2, 3, 4, 4 };
            //for (int i = 0; i < lastDayCount; i++)
            //{
            //    int lastDayItem = Convert.ToInt32(Console.ReadLine().Trim());
            //    lastDay.Add(lastDayItem);
            //}

            int result = Result.countMeetings(firstDay, lastDay);

                //textWriter.WriteLine(result);

                //textWriter.Flush();
                //textWriter.Close();
            }
        
    }
}
