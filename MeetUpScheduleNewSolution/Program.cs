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

namespace MeetUpScheduleNewSolution
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
            lastDay.Sort(gg);

            IDictionary<int, int> nOfInvestorsFreeDays = new Dictionary<int, int>();

            for (var i = 0; i < firstDay.Count(); i++)
            {
                int startDay = firstDay[i];

                int endDay = lastDay[i];


                while (startDay <= endDay)
                {

                    if (!nOfInvestorsFreeDays.ContainsKey(startDay))
                    {
                        nOfInvestorsFreeDays.Add(startDay, startDay);
                        break;
                    }
                    startDay++;
                }
            }



            return nOfInvestorsFreeDays.Count();


        }

        class Program
        {
            public static void Main(string[] args)
            {
                //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

                // int firstDayCount = Convert.ToInt32(Console.ReadLine().Trim());

                // List<int> firstDay = new List<int>(){1,2,3,4,5}; 
                List<int> firstDay = new List<int>() { 1, 2, 1, 2, 2 };
                //List<int> firstDay = new List<int>() { 1, 2, 3, 3, 3 };

                //for (int i = 0; i < firstDayCount; i++)
                //{
                //    int firstDayItem = Convert.ToInt32(Console.ReadLine().Trim());
                //    firstDay.Add(firstDayItem);
                //}

                // int lastDayCount = Convert.ToInt32(Console.ReadLine().Trim());

                // List<int> lastDay = new List<int>(){6,7,8,9,10};
                List<int> lastDay = new List<int>() { 3, 2, 1, 3, 3 };
                //List<int> lastDay = new List<int>() { 2, 2, 3, 4, 4 };
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
}
//IDictionary<int, int> dictionaryDays = new Dictionary<int, int>();

//var listCounter = firstDay.Count();

//            for (var i = 0; i<firstDay.Count(); i++)
//            {

//                dictionaryDays.Add(i, firstDay[i]);

//            }



//            dictionaryDays = dictionaryDays.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

//var listCounter2 = 0;

//var sortedlastDay = new List<int>();

//            foreach (KeyValuePair<int, int> kvp in dictionaryDays)
//            {
//                firstDay[listCounter2] = kvp.Value;

//                sortedlastDay.Add(lastDay[kvp.Key]);

//                listCounter2++;
//            }