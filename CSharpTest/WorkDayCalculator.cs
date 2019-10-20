using System;
using System.Linq;

namespace CSharpTest
{ 
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            DateTime endDate = startDate.AddDays(dayCount - 1);

            if (weekEnds != null)
            {
                foreach (WeekEnd vacationRange in weekEnds)
                {
                    if (vacationRange.StartDate >= startDate && vacationRange.StartDate <= endDate)
                    {
                        endDate =  endDate.AddDays((vacationRange.EndDate - vacationRange.StartDate).Days + 1);
                    }
                }
            }

            return endDate;
        }
    }
}
