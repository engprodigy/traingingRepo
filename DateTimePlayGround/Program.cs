using System;
using System.Globalization;

namespace DateTimePlayGround
{
	class GFG
	{

		// Main Method 
		public static void Main()
		{
			try
			{

				// creating object of DateTime 
				DateTime date = new DateTime(2011, 1,
										1, 4, 0, 15);

				// creating object of TimeSpan 
				TimeSpan ts = new TimeSpan(1, 12,
										15, 16);

				// getting ShortTime from 
				// subtracting DateTime and TimeSpan 
				// using Subtract() method; 
				DateTime value = date.Subtract(ts);

				// Display the TimeSpan 
				Console.WriteLine("DateTime between date " +
								"and ts is {0}", value);
			}

			catch (ArgumentOutOfRangeException e)
			{
				Console.Write("Exception Thrown: ");
				Console.Write("{0}", e.GetType(), e.Message);
			}

			try
			{

				// creating object of DateTime 
				DateTime date = new DateTime(2011, 1,
										1, 4, 0, 15);

				// creating object of TimeSpan 
				TimeSpan ts = new TimeSpan(1, 12,
										 15, 16);

				// getting ShortTime from  
				// subtracting DateTime and TimeSpan 
				// using Subtract() method; 
				DateTime value = date.Add(ts);

				// Display the TimeSpan 
				Console.WriteLine("DateTime between date " +
								   "and ts is {0}", value);
			}

			catch (ArgumentOutOfRangeException e)
			{
				Console.Write("Exception Thrown: ");
				Console.Write("{0}", e.GetType(), e.Message);
			}
		}
	}
}
// C# program to demonstrate the 
// DateTime.Subtract(TimeSpan) 
// Method 



