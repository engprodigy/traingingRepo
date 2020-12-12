using NUnit.Framework;

namespace NUnitTestProject
{

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
					+ (((decimal)0.5 * purchaseValue) / 100);

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
	public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
           // Assert.Pass();
			AssertCarValue(25313.40m, 35000m, 3 * 12, 50000, 1, 1);
		}

		

		[Test]
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