using NUnit.Framework;
using System;


namespace CarPricer
{
    class Program
    {
		int solution;

		public Program()
        {
			//Random rnd = new Random();
			//this.solution = rnd.Next(1, 1000000);

		}

		string callVerify(int guess)
        {
			//int guess = 1;
			Random rnd = new Random();
			
			this.solution = rnd.Next(1, 1000000);

			for (var i=0; i < 50; i++)
            {
				if(Verify(guess) == 0)
                {
					return "You won";
                }
            }

			return "You Lose";
		}

		private int Verify(int guess)
        {
			if(this.solution == guess)
            {
				
				return 0;

            }else if(this.solution > guess)
            {
				return 1;
            }
            else 
            {
				return -1;
            }

			//return 1;
        }
        static void Main(string[] args)
        {
			//UnitTests unitTests = new UnitTests();
			//unitTests.CalculateCarValue();
			Program program = new Program();

			

			int guess = 5;

			program.callVerify(guess);

			Console.WriteLine("Hello World!");

			Console.WriteLine(program.callVerify(guess));
		}


    }

	public class Car
	{
		public decimal PurchaseValue { get; set; }
		public int AgeInMonths { get; set; }
		public int NumberOfMiles { get; set; }
		public int NumberOfPreviousOwners { get; set; }
		public int NumberOfCollisions { get; set; }




	}

	public class PriceDeterminator

	{




		public decimal DetermineCarPrice(Car car)
		{

			decimal purchaseValue = car.PurchaseValue;

			int validAgeInMonths = car.AgeInMonths;

			decimal purchaseValueDeductionAge = 0m;

			decimal purchaseValueDeductionNumberOfMiles = 0m;

			decimal purchaseValueDeductionPreviousOwners = 0m;

			decimal purchaseValueDeductionCollisions = 0m;


			if (validAgeInMonths < 10 * 12)
			{

				for (int i = 0; i < (validAgeInMonths); i++)
				{
					purchaseValueDeductionAge = purchaseValueDeductionAge
					+ ((decimal)0.5 * purchaseValue / 100);

				}

				purchaseValue = purchaseValue - purchaseValueDeductionAge;

			}

			if (car.NumberOfMiles <= 150000 && car.NumberOfMiles >= 1000)
			{


				for (int i = 0; i < (car.NumberOfMiles / 1000); i++)
				{
					purchaseValueDeductionNumberOfMiles = purchaseValueDeductionNumberOfMiles
								+ (((decimal)0.2 * purchaseValue) / 100);
				}

				purchaseValue = purchaseValue - purchaseValueDeductionNumberOfMiles;
			}
			else if (car.NumberOfMiles > 150000)
			{

				for (int i = 0; i < (150); i++)
				{
					purchaseValueDeductionNumberOfMiles = purchaseValueDeductionNumberOfMiles
								+ (((decimal)0.2 * purchaseValue) / 100);
				}

				purchaseValue = purchaseValue - purchaseValueDeductionNumberOfMiles;


			}

			if (car.NumberOfPreviousOwners > 2)
			{


				purchaseValueDeductionPreviousOwners = purchaseValueDeductionPreviousOwners
					- (((decimal)25 * purchaseValue) / 100);


				purchaseValue = purchaseValue - purchaseValueDeductionPreviousOwners;
			}



			if (car.NumberOfCollisions < 5)
			{


				for (int i = 0; i < (car.NumberOfCollisions); i++)
				{
					purchaseValueDeductionCollisions = purchaseValueDeductionCollisions
						+ (((decimal)2 * purchaseValue) / 100);
				}

				purchaseValue = purchaseValue - purchaseValueDeductionCollisions;
			}

			if (car.NumberOfPreviousOwners == 0)
			{


				return purchaseValue = purchaseValue + (((decimal)10 * purchaseValue) / 100);


			}
			else
			{
				return purchaseValue;
			};



			//throw new NotImplementedException("Implement here!");
		}
	}




	public class UnitTests
	{


		public void CalculateCarValue()
		{
			AssertCarValue(25313.40m, 35000m, 3 * 12, 50000, 1, 1);
			AssertCarValue(19688.20m, 35000m, 3 * 12, 150000, 1, 1);
			AssertCarValue(19688.20m, 35000m, 3 * 12, 250000, 1, 1);
			AssertCarValue(20090.00m, 35000m, 3 * 12, 250000, 1, 0);
			AssertCarValue(21657.02m, 35000m, 3 * 12, 250000, 0, 1);
		}

		private static void AssertCarValue(decimal expectValue, decimal purchaseValue,
		int ageInMonths, int numberOfMiles, int numberOfPreviousOwners, int
		numberOfCollisions)
		{
			Car car = new Car
			{
				AgeInMonths = ageInMonths,
				NumberOfCollisions = numberOfCollisions,
				NumberOfMiles = numberOfMiles,
				NumberOfPreviousOwners = numberOfPreviousOwners,
				PurchaseValue = purchaseValue
			};
			PriceDeterminator priceDeterminator = new PriceDeterminator();
			var carPrice = priceDeterminator.DetermineCarPrice(car);
			Assert.AreEqual(expectValue, carPrice);
		}


	}
}


/*using System;
using System.Collections.Generic;

class Program
{

	static int stringArray(List<string> stringList, int totalSum)
	{
		Console.Write(totalSum + "space");
		//int totalSum = 0;
		if (stringList.Count == 0)
		{
			return totalSum;
		}
		else
		{
			var valueAtIndex = stringList[0];
			try
			{

				totalSum = totalSum + int.Parse(valueAtIndex);
				// totalSum = int.Parse(valueAtIndex);
				// Console.Write(totalSum + "space");
			}
			catch
			{

			}
			stringList.Remove(valueAtIndex);
		}



		//return totalSum = totalSum + stringArray(stringList, totalSum);

		return stringArray(stringList, totalSum);

	}

	static void Main()
	{
		int x = 10;
		int y = 25;
		int z = x + y;
		List<string> stringList = new List<string>() { "3", "200", "k", "kol", "3" };

		stringArray(stringList, 0);

		Console.Write(stringArray(stringList, 0));
		//Console.Write("Sum of x + y = "+ z);
	}
}*/