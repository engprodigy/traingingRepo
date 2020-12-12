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

namespace HackerRankLeadALife
{
    class Result
    {

        /*
         * Complete the 'calculateProfit' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER n
         *  2. INTEGER_ARRAY earning
         *  3. INTEGER_ARRAY cost
         *  4. INTEGER e
         */

        public static int calculateProfit(int n, List<int> earning, List<int> cost, int e)
        {
            var totalEarning = 0;
           
            var startList = new List<int>(e+1);
            var maxEnergy = e;


                //earnings after working start
                for (var i = 0; i <= e ; i++)
                {

                startList.Insert(i, (earning[0] * (maxEnergy - i)));


                }

                for(var i = 0; i < earning.Count(); i++)
                {
                        if (i == 0)
                        {
                            //earnings after eating
                            for (var j = startList.Count() - 1; j > -1; j--)
                            {

                                var sortList = new List<int>();

                                for (var k = 0; k <= j; k++)
                                {

                                    sortList.Add(startList[j - k] - (k * cost[i]));

                                }

                                Console.WriteLine(sortList.Max());

                                startList[j] = sortList.Max();

                            }

                            Console.WriteLine(startList);


                        }
                        if (i > 0 && i != n - 1)
                        {

                            //earnings after work
                            var energyCountNew = 0;

                            for (var j = startList.Count() - 1; j > -1; j--)
                            {

                                var sortList = new List<int>();

                                for (var k = 0; k <= energyCountNew; k++)
                                {

                                sortList.Add(startList[startList.Count() - 1 - k] + ((energyCountNew - k) * earning[i]));


                                }

                                Console.WriteLine(sortList.Max());

                                startList[j] = sortList.Max();
                                energyCountNew++;

                            }


                            //earnings after eating
                            for (var j = startList.Count() - 1; j > -1; j--)
                            {

                                var sortList = new List<int>();

                                for (var k = 0; k <= j; k++)
                                {

                                    sortList.Add(startList[j - k] - (k * cost[i]));

                                }

                                Console.WriteLine(sortList.Max());

                                startList[j] = sortList.Max();

                            }

                            Console.WriteLine(startList);


                        }

                        if (i == n - 1)
                        {
                            //earnings after work
                            var energyCountNew = 0;

                            for (var j = startList.Count() - 1; j > -1; j--)
                            {

                                var sortList = new List<int>();

                                for (var k = 0; k <= energyCountNew; k++)
                                {

                                    sortList.Add(startList[startList.Count() - 1 - k] + ((energyCountNew - k) * earning[i]));


                                }

                                Console.WriteLine(sortList.Max());

                                startList[j] = sortList.Max();
                                energyCountNew++;

                            }

                        }

                }




                totalEarning = startList.Max();

            return totalEarning;

            //earnings after eating
            //for (var i = startList.Count()-1; i > -1;  i--)
            //    {

            //        var sortList = new List<int>();

            //            for (var j = 0; j <= i; j++)
            //            {

            //               sortList.Add(startList[i-j] - (j * 7));

            //            }

            //            Console.WriteLine(sortList.Max());

            //            startList[i] = sortList.Max();

            //    }

            //       Console.WriteLine(startList);



            //    //earnings after work
            //    var energyCount = 0;

            //    for (var i = startList.Count()-1; i > -1; i--)
            //    {

            //        var sortList = new List<int>();

            //        for (var j = 0; j <= energyCount; j++)
            //        {

            //        sortList.Add(startList[startList.Count() - 1 -j] + ((energyCount-j) * 2) );


            //        }

            //        Console.WriteLine(sortList.Max());

            //        startList[i] = sortList.Max();
            //        energyCount++;

            //    }






            //    //earnings after eating
            //    for (var i = startList.Count() - 1; i > -1; i--)
            //    {

            //    var sortList = new List<int>();

            //    for (var j = 0; j <= i; j++)
            //    {

            //        sortList.Add(startList[i - j] - (j * 3));

            //    }

            //    Console.WriteLine(sortList.Max());

            //    startList[i] = sortList.Max();

            //    }


            ////earnings after work
            // energyCount = 0;

            //for (var i = startList.Count() - 1; i > -1; i--)
            //{

            //    var sortList = new List<int>();

            //    for (var j = 0; j <= energyCount; j++)
            //    {

            //        sortList.Add(startList[startList.Count() - 1 - j] + ((energyCount - j) * 4));


            //    }

            //    Console.WriteLine(sortList.Max());

            //    startList[i] = sortList.Max();
            //    energyCount++;

            //}



        }

    }
    class Program
    {
        public static void Main(string[] args)
        {
            // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            //int n = Convert.ToInt32(Console.ReadLine().Trim());


            // int earningCount = Convert.ToInt32(Console.ReadLine().Trim());

            // int earningCount = 3;



            //for (int i = 0; i < earningCount; i++)
            //{
            //    int earningItem = Convert.ToInt32(Console.ReadLine().Trim());
            //    earning.Add(earningItem);
            //}

            //int costCount = Convert.ToInt32(Console.ReadLine().Trim());
            //int n = 2;
           // List<int> earning = new List<int>() { 7, 2, 4 };
           // List<int> cost = new List<int>() { 7, 3, 6 };
            //int e = 5;

            int n = 4;
            List<int> earning = new List<int>() { 1, 8, 6, 7 };
            List<int> cost = new List<int>() { 1, 3, 4, 1 };
            int e = 5;

            //for (int i = 0; i < costCount; i++)
            //{
            //    int costItem = Convert.ToInt32(Console.ReadLine().Trim());
            //    cost.Add(costItem);
            //}

            //int e = Convert.ToInt32(Console.ReadLine().Trim());



            int result = Result.calculateProfit(n, earning, cost, e);

            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}


//for (var j = 0; j<n; j++)
//            { 
             
//                if(earning[j] > cost[j] && j != n-1)
//                {
//                    totalEarning = totalEarning + (earning[j] * e);
//                    totalCost = totalCost + (cost[j] * e);
//                }
//                if (j == n - 1)
//                {
//                    totalEarning = totalEarning + (earning[j] * e);
//                }
//            }

//            var validTotalEarning = totalEarning - totalCost;

//Console.WriteLine(validTotalEarning);

//            return validTotalEarning;