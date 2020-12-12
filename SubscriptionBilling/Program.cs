using System;
using System.Collections.Generic;
using System.Linq;

namespace SubscriptionBilling
{
    public class Subscription
    {
        public Subscription() { }
        public Subscription(int id, int customerId, int monthlyPriceInDollars)
        {
            this.Id = id;
            this.CustomerId = customerId;
            this.MonthlyPriceInDollars = monthlyPriceInDollars;
        }

        public int Id;
        public int CustomerId;
        public int MonthlyPriceInDollars;
    }

    public class User
    {
        public User() { }
        public User(int id, string name, DateTime activatedOn, DateTime deactivatedOn, int customerId)
        {
            this.Id = id;
            this.Name = name;
            this.ActivatedOn = activatedOn;
            this.DeactivatedOn = deactivatedOn;
            this.CustomerId = customerId;
        }

        public int Id;
        public string Name;
        public DateTime ActivatedOn;
        public DateTime DeactivatedOn;
        public int CustomerId;
    }

    public class Challenge
    {
        public static Decimal BillFor(string month, Subscription activeSubscription, User[] users)
        {

            string iString = month;
           
            DateTime oDate = DateTime.ParseExact(iString, "yyyy-MM", null);

            Console.WriteLine(oDate);

            var firstDayOfMonthDate = FirstDayOfMonth(oDate);
            var LastDayOfMonthDate = LastDayOfMonth(oDate);

            var noOfDayInMonth = (LastDayOfMonth(oDate).Day - FirstDayOfMonth(oDate).Day) + 1;
            Console.WriteLine(firstDayOfMonthDate);
            // your code here
            decimal monthlyPrice = (decimal)activeSubscription.MonthlyPriceInDollars;
            var dailySubscriptionRate = monthlyPrice / (decimal)noOfDayInMonth;
            Console.WriteLine(dailySubscriptionRate);

            var newFirstDayOfMonth = firstDayOfMonthDate;

            decimal subTotal = 0;

            for (var i = 0; i < noOfDayInMonth; i++)
            {

                DateTime todaysDate;
                
                if(i == 0)
                {
                    todaysDate = firstDayOfMonthDate;
                }
                else
                {
                    firstDayOfMonthDate = NextDay(firstDayOfMonthDate);
                    todaysDate = firstDayOfMonthDate;
                }

                foreach (var user in users)
                {

                  if(user.ActivatedOn <= todaysDate && todaysDate <= user.DeactivatedOn)
                    {

                        subTotal = subTotal + dailySubscriptionRate;

                    }

                }


            }

            subTotal = Decimal.Round(subTotal, 2);

            return subTotal;
        }


        public static void Main()
        {
            Subscription newPlan = new Subscription(1, 1, 4);

            User[] constantUsers = {
      new User(1, "Employee #1", new DateTime(2018, 11, 4), DateTime.MaxValue, 1),
      new User(2, "Employee #2", new DateTime(2018, 12, 4), DateTime.MaxValue, 1)
                               };

            User[] userSignedUp = {
      new User(1, "Employee #1", new DateTime(2018, 11, 4), DateTime.MaxValue, 1),
      new User(2, "Employee #2", new DateTime(2018, 12, 4), DateTime.MaxValue, 1),
      new User(3, "Employee #3", new DateTime(2019, 1, 10), DateTime.MaxValue, 1),
                          };

            User[] userDeactivated= {
      new User(1, "Employee #1", new DateTime(2018, 11, 4), DateTime.MaxValue, 1),
      new User(2, "Employee #2", new DateTime(2018, 12, 4), new DateTime(2019, 1, 10), 1),
      new User(3, "Employee #3", new DateTime(2019, 1, 10), new DateTime(2019, 1, 11), 1),
  };

            Challenge.BillFor("2019-01", newPlan, constantUsers);

            Challenge.BillFor("2019-01", newPlan, userSignedUp);

            Challenge.BillFor("2019-01", newPlan, userDeactivated);

        }

            /*******************
            * Helper functions *
            *******************/

            /**
            Takes a DateTime object and returns a DateTime which is the first day
            of that month. For example:

            FirstDayOfMonth(new DateTime(2019, 2, 7)) // => new DateTime(2019, 2, 1)
            **/
            private static DateTime FirstDayOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        /**
        Takes a DateTime object and returns a DateTime which is the last day
        of that month. For example:

        LastDayOfMonth(new DateTime(2019, 2, 7)) // => new DateTime(2019, 2, 28)
        **/
        private static DateTime LastDayOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
        }

        /**
        Takes a DateTime object and returns a DateTime which is the next day.
        For example:

        NextDay(new DateTime(2019, 2, 7))  // => new DateTime(2019, 2, 8)
        NextDay(new DateTime(2019, 2, 28)) // => new DateTime(2019, 3, 1)
        **/
        private static DateTime NextDay(DateTime date)
        {
            return date.AddDays(1);
        }
    }
}
