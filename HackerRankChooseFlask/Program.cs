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

namespace HackerRankChooseFlask
{
    class Result
    {

        /*
         * Complete the 'chooseFlask' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER_ARRAY requirements
         *  2. INTEGER flaskTypes
         *  3. 2D_INTEGER_ARRAY markings
         */

        public static int chooseFlask(List<int> requirements, int flaskTypes, List<List<int>> markings)
        {

               

                var minIndex = -1;

                var minCountFlag = 0;

                var newBlockStart = 0;

                var maxRequirementValue = requirements[requirements.Count() - 1];

                var exitFlag = false;

                var inlineExcess = 0;
                var inlineExcessMin = 0; 
                var requirementsCountValue = requirements.Count();

                var requirementsCount = 0;
                var requirementsCountForBreak  = 0;

            IDictionary<int, int> blockStart = new Dictionary<int, int>();

            var i = 0;
            for (var j = 0; j < markings.Count(); j++)
            {
                if(j+1 < markings.Count())
                {

                
                if (markings[j][0] != markings[j + 1][0])
                {

                        blockStart.Add(i, j + 1);
                        i++;

                }


                }
            }

                for (var j = 0; j < markings.Count(); j++)
            {
                
                while (markings[j][1] >= requirements[requirementsCount])
                {
                    exitFlag = false;
                    if (requirementsCountForBreak < requirementsCountValue)
                    {

                        inlineExcess = inlineExcess + (markings[j][1] - requirements[requirementsCount]);

                    }
                    if (requirementsCount + 1 <= requirementsCountValue - 1)
                    {

                        requirementsCount++;



                    }

                    requirementsCountForBreak++;
                    //if (j + 1 < markings.Count())
                    // {
                    //    if (markings[j][0] != markings[j + 1][0] && requirementsCountForBreak >= requirementsCountValue)
                    if ( requirementsCountForBreak >= requirementsCountValue)
                       {
                            Console.WriteLine(inlineExcess);

                            if (minCountFlag == 0) {
                                if (inlineExcess >= 0 && inlineExcess > inlineExcessMin)
                                {
                                    inlineExcessMin = inlineExcess;
                                    minIndex = markings[j][0];

                                }

                            }
                            else
                            {
                                if (inlineExcess >= 0 && inlineExcess < inlineExcessMin)
                                {
                                    inlineExcessMin = inlineExcess;
                                    // minIndex = Math.Min(minIndex, j);
                                    minIndex = markings[j][0]; 

                                }


                            }
                            minCountFlag++;
                            requirementsCount = 0;
                            inlineExcess = 0;
                            requirementsCountForBreak = 0;
                            if (blockStart.ContainsKey(newBlockStart)) { 

                                j = blockStart[newBlockStart]-1;

                                newBlockStart++;
                            }
                        exitFlag = true;
                            break;
                        }else if(requirementsCount == requirementsCountValue)
                          {

                        if (blockStart.ContainsKey(newBlockStart))
                        {

                            j = blockStart[newBlockStart] - 1;

                            newBlockStart++;
                        }

                    }
                  //  }

                }

                if (j + 1 < markings.Count()) 
                { 


                if (markings[j][0] != markings[j + 1][0] && exitFlag == false)
                {
                    requirementsCount = 0;
                    inlineExcess = 0;
                    requirementsCountForBreak = 0;
                    if (blockStart.ContainsKey(newBlockStart))
                    {

                        j = blockStart[newBlockStart] - 1;

                        newBlockStart++;
                    }
                }


                }


            }

            Console.WriteLine(minIndex);
            return minIndex;

        }


    }
    class Program
    {
        public static void Main(string[] args)
        {
            // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            //int requirementsCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> requirements = new List<int>() { 4, 6, 6, 7 };
            //List<int> requirements = new List<int>() { 10, 15 };
            //List<int> requirements = new List<int>() { 4, 6 };

            //for (int i = 0; i < requirementsCount; i++)
            //{
            //    int requirementsItem = Convert.ToInt32(Console.ReadLine().Trim());
            //    requirements.Add(requirementsItem);
            //}

            // int flaskTypes = Convert.ToInt32(Console.ReadLine().Trim());

            //int flaskTypes = 2;
            int flaskTypes = 3;

            //int markingsRows = Convert.ToInt32(Console.ReadLine().Trim());
            // int markingsColumns = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<int>> markings = new List<List<int>>();

            //markings.Add(new List<int>());
            //markings[0].Add(0);
            //markings[0].Add(11);
            //markings.Add(new List<int>());
            //markings[1].Add(0);
            //markings[1].Add(20);
            //markings.Add(new List<int>());
            //markings[2].Add(1);
            //markings[2].Add(11);
            //markings.Add(new List<int>());
            //markings[3].Add(1);
            //markings[3].Add(17);
            //markings.Add(new List<int>());
            //markings[4].Add(2);
            //markings[4].Add(12);
            //markings.Add(new List<int>());
            //markings[5].Add(2);
            //markings[5].Add(16);

            markings.Add(new List<int>());
            markings[0].Add(0);
            markings[0].Add(3);
            markings.Add(new List<int>());
            markings[1].Add(0);
            markings[1].Add(3);
            markings.Add(new List<int>());
            markings[2].Add(0);
            markings[2].Add(3);
            markings.Add(new List<int>());
            markings[3].Add(1);
            markings[3].Add(6);
            markings.Add(new List<int>());
            markings[4].Add(1);
            markings[4].Add(8);
            markings.Add(new List<int>());
            markings[5].Add(1);
            markings[5].Add(9);
            markings.Add(new List<int>());
            markings[6].Add(2);
            markings[6].Add(3);
            markings.Add(new List<int>());
            markings[7].Add(2);
            markings[7].Add(5);
            markings.Add(new List<int>());
            markings[8].Add(2);
            markings[8].Add(6);

            //markings.Add(new List<int>());
            //markings[0].Add(0);
            //markings[0].Add(5);
            //markings.Add(new List<int>());
            //markings[1].Add(0);
            //markings[1].Add(7);
            //markings.Add(new List<int>());
            //markings[2].Add(0);
            //markings[2].Add(10);
            //markings.Add(new List<int>());
            //markings[3].Add(1);
            //markings[3].Add(4);
            //markings.Add(new List<int>());
            //markings[4].Add(1);
            //markings[4].Add(10);


            //for (int i = 0; i < markingsRows; i++)
            //{
            //    markings.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(markingsTemp => Convert.ToInt32(markingsTemp)).ToList());
            //}

            int result = Result.chooseFlask(requirements, flaskTypes, markings);

            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
    }




//if(markings[j][0] != markings[j + 1][0])
//{
//    newBlockStart++;
//}

//            while (markings[j][1] >= requirements[requirementsCount])
//            {

//                var testEvaluate = markings[j][1];
//Console.WriteLine(testEvaluate);

//                if (requirementsCountForBreak<requirementsCountValue) 
//                { 

//                   inlineExcess = inlineExcess + (markings[j][1] - requirements[requirementsCount]);

//                }

//                    if(requirementsCount + 1 <= requirementsCountValue - 1)
//                    {

//                          requirementsCount++;



//                    }

//                    requirementsCountForBreak++;

//                 if(j + 1 < markings.Count())
//                {


//                if (markings[j][0] != markings[j + 1][0] && requirementsCountForBreak >= requirementsCountValue)
//                    {

//                      if(inlineExcess > 0) { 
//                          if(minCountFlag == 0)
//                            {
//                              minIndex = Math.Max(markings[j][0], minIndex);
//                            }
//                            else
//                            {
//                                minIndex = Math.Min(markings[j][0], minIndex);
//                            }

//                            minCountFlag++;

//                       }
//                      requirementsCount = 0;
//                      inlineExcess = 0;

//                      break;
//                     }

//                }







//            }




//                    if (j == markings.Count() - 1)
//                    {
//                        if (inlineExcess > 0)
//                        {
//                            if (minCountFlag == 0)
//                            {
//                                minIndex = Math.Max(markings[j][0], minIndex);
//                            }
//                            else
//                            {
//                                minIndex = Math.Min(markings[j][0], minIndex);
//                            }

//                            minCountFlag++;

//                        }
//                    }



//            }





//var i = 0;
//                while (markings[j][i] >= requirements[requirementsCount] || i<markings[j].Count)
//                {
//                    if (markings[j][i] < requirements[requirementsCount])
//                    {
                        
//                        i++;
//                        if (i >= markings[j].Count)
//                        {
                            
//                            break;
//                        }
//                    }
//                    else
//                    { 

//                     if (requirementsCountForBreak<requirementsCountValue)
//                    {

//                        inlineExcess = inlineExcess + (markings[j][i] - requirements[requirementsCount]);

//                    }
//                    if (requirementsCount + 1 <= requirementsCountValue - 1)
//                    {

//                        requirementsCount++;
//                        if (i + 1 < markings[j].Count() && markings[j][i] < requirements[requirementsCount])
//                        {

//                            i++;

//                        }

//                    }


//                    requirementsCountForBreak++;
//                    if (requirementsCountForBreak >= requirementsCountValue)
//                    {
                          
//                        // Console.WriteLine(inlineExcess);
//                            if(minCountFlag == 0) { 
//                            if (inlineExcess >= 0 && inlineExcess > inlineExcessMin)
//                            {
//                                inlineExcessMin = inlineExcess;
//                                minIndex = j;

//                            }
                            
//                            }
//                            else
//                            {
//                                if (inlineExcess >= 0 && inlineExcess<inlineExcessMin)
//                                {
//                                    inlineExcessMin = inlineExcess;
//                                   // minIndex = Math.Min(minIndex, j);
//                                    minIndex = j;

//                                }
                                

//                            }
//                            minCountFlag++;
//                            requirementsCount = 0;
//                        inlineExcess = 0;
//                        requirementsCountForBreak = 0;
//                        break;
//                    } else if (requirementsCount == requirementsCountValue)
                        
//                    {
//                            requirementsCount = 0;
//                            inlineExcess = 0;
//                            requirementsCountForBreak = 0;
//                            break;
//                    }

//                    }
//                }