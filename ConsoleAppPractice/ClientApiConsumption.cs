using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
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
using System.Runtime.Serialization.Json;
using System.Text.RegularExpressions;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;



namespace ConsoleAppPractice
{
    // You must apply a DataContractAttribute or SerializableAttribute
    // to a class to have it serialized by the DataContractSerializer.

    [DataContract]
    public class Transactions
    {
        [DataMember]
        public int page { get; set; }
        [DataMember]
        public int per_page { get; set; }
        [DataMember]
        public int total { get; set; }
        [DataMember]
        public int total_pages { get; set; }

    }


    [DataContract]
    public class TransactionsItr
    {
        [DataMember]
        public string page { get; set; }
        [DataMember]
        public int per_page { get; set; }
        [DataMember]
        public int total { get; set; }
        [DataMember]
        public int total_pages { get; set; }
        [DataMember]
        public List<TransactionsData> data { get; set; }

    }

    public class TransactionsData
    {

        public int id { get; set; }

        
        public int userId { get; set; }

        public string userName { get; set; }

        public long timestamp { get; set; }
        public string txnType { get; set; }

        public string amount { get; set; }
        public Location location { get; set; }

        public string ip { get; set; }

    }


    public class Location
    {

        public int id { get; set; }

        public string address { get; set; }
        public string city { get; set; }

        public int zipCode { get; set; }
       


    }

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
         * Complete the 'totalTransactions' function below.
         *
         * The function is expected to return a 2D_INTEGER_ARRAY.
         * The function accepts following parameters:
         *  1. INTEGER locationId
         *  2. STRING transactionType
         */

       //public static List<List<int>> totalTransactions(int locationId, string transactionType)
         public static void totalTransactions(int locationId, string transactionType)
        {
            Transactions transactions = new Transactions();
            HttpClient client = new HttpClient();

            var url = "https://jsonmock.hackerrank.com/api/transactions/";

            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var iterateUrlStart = "search?txnType=" + transactionType;
            var responseTask = client.GetAsync(iterateUrlStart);

            responseTask.Wait();

            var responseResult = responseTask.Result;

            if (responseResult.IsSuccessStatusCode)
            {
               // var readJson = responseResult.Content.ReadAsStringAsync().Result;
                var readJson = responseResult.Content.ReadAsStreamAsync().Result;

                var ser = new DataContractJsonSerializer(typeof(Transactions));
                //transactions =  JsonSerializer.Deserialize<Transactions>(readJson);
                readJson.Position = 0;
                transactions = (Transactions)ser.ReadObject(readJson);
            }
            List<List<int>> totalTransactions = new List<List<int>>();

            var amount = 0;

            var uniqueIdList = new List<int>();
            var dataTemporaryStorageList  = new List<TransactionsData>();

            for (var i = 1; i <= transactions.total_pages; i++)

                {
                TransactionsItr transactionsItr = new TransactionsItr();

               
                var iterateUrl = "search?txnType=" + transactionType + "&page=" + i.ToString();

                    var responseTaskIterate = client.GetAsync(iterateUrl);

                    responseTaskIterate.Wait();

                    var responseResultIterate = responseTaskIterate.Result;

                    if (responseResultIterate.IsSuccessStatusCode)
                    {

                    //var readJsonIterate = responseResultIterate.Content.ReadAsStringAsync().Result;
                    var readJsonIterate = responseResultIterate.Content.ReadAsStreamAsync().Result;
                    //transactionsItr = JsonSerializer.Deserialize<TransactionsItr>(readJsonIterate);
                    var ser2 = new DataContractJsonSerializer(typeof(TransactionsItr));
                    readJsonIterate.Position = 0;
                    transactionsItr = (TransactionsItr)ser2.ReadObject(readJsonIterate);
                    //Console.WriteLine(transactionsItr.page);
                    }

                    

                    foreach (var transactionsItrValue in transactionsItr.data)
                    {

                      

                      if (transactionsItrValue.location.id == locationId && transactionsItrValue.txnType == transactionType)
                        {
                            dataTemporaryStorageList.Add(transactionsItrValue);
                            
                            var array = transactionsItrValue.amount.
                             Trim(new Char[] { '$' }).Replace(",", "").Split(new[] { '.' }, 2);
                             
                             amount = amount + int.Parse(array[0]);

                            if (!uniqueIdList.Contains(transactionsItrValue.userId)) 
                            {
                               uniqueIdList.Add(transactionsItrValue.userId);
                              
                              

                            }

                        } 

                    }


                }



           

            var countId = 0;
            GFG gg = new GFG();
            uniqueIdList.Sort(gg);

            if (dataTemporaryStorageList.Count == 0)
            {
                totalTransactions.Add(new List<int>());
                totalTransactions[0].Add(-1);
                totalTransactions[0].Add(-1);

            }

            foreach (var uniqueIdListValue in uniqueIdList)
            {
                Console.WriteLine(uniqueIdListValue);
                totalTransactions.Add(new List<int>());
                float amountTotal = 0;
                foreach (var dataTemporaryStorageListValue in dataTemporaryStorageList)
                {
                   
                    if(dataTemporaryStorageListValue.userId == uniqueIdListValue)
                    {
                      
                        amountTotal = amountTotal + float.Parse(dataTemporaryStorageListValue.amount.
                            Trim(new Char[] { '$' }).Replace(",", ""));
                    }

                }
                
                Console.WriteLine((int)amountTotal);
                

                totalTransactions[countId].Add(uniqueIdListValue);
                totalTransactions[countId].Add((int)amountTotal);
                countId++;
            }

            
           

           
         }

    }

    class ClientApiConsumption
    {
        public static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int locationId = Convert.ToInt32(Console.ReadLine().Trim());

            string transactionType = Console.ReadLine();

            //int locationId = 1;

            //string transactionType = "debit";

            // List<List<int>> result = Result.totalTransactions(locationId, transactionType);

            Result.totalTransactions(locationId, transactionType);

            // textWriter.WriteLine(String.Join("\n", result.Select(x => String.Join(" ", x))));

            // textWriter.Flush();
            // textWriter.Close();
        }
    }
}
