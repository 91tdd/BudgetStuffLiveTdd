using System;

namespace BudgetStuffLiveTdd
{
    public class Period
    {
        public Period(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public double Days()
        {
            var days = (EndDate.AddDays(1) - StartDate).TotalDays;
            return days;
        }
    }
}