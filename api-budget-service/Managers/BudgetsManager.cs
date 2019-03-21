using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api_budget_service.Models;

namespace api_budget_service.Managers
{
    public class BudgetsManager : IBudgetsManager
    {
        public async Task<decimal> CalculateBudget(BudgetsRequest request)
        {
            int numberOfDays = request.NumberOfDays;
            DateTime currentDay = request.StartDate;
            DateTime dayCounter = currentDay;
            decimal budget = 0;

            // The cost of banana is tiered, every 7 days, the cost go up by
            // $0.05. 
            for(var i = 0; i < numberOfDays; i++)
            {
                // To find the tier, dividie current day of the month by 7
                // then offset by 1 so the end of each tier doesn't overlap with
                // next one. Explicit cast to int truncates decimals.
                int priceTier = (int)(dayCounter.Day - 1) / 7;

                // Grab enum -> 0 = Sunday, 1 = Monday...
                int dayOfWeek = (int)dayCounter.DayOfWeek;

                // Only buy during week days
                if(dayOfWeek > 0 && dayOfWeek < 6)
                {
                    // First tier is going to be 0, we offset by adding $0.05
                    // to every purchase.
                    budget += (priceTier * 0.05m) + 0.05m;
                }
                dayCounter = dayCounter.AddDays(1);
            }

            return budget;
        }
    }
}
