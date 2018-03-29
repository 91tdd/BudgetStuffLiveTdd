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

        public double OverlappingDays(Budget budget)
        {
            if (HasNoOverlappingDays(budget))
            {
                return 0;
            }

            var effectiveEndDate = EndDate > budget.LastDay
                ? budget.LastDay
                : EndDate;

            var effectiveStartDate = StartDate < budget.FirstDay
                ? budget.FirstDay
                : StartDate;

            var days = (effectiveEndDate.AddDays(1) - effectiveStartDate).TotalDays;
            return days;
        }

        private bool HasNoOverlappingDays(Budget budget)
        {
            return StartDate > budget.LastDay || EndDate < budget.FirstDay;
        }
    }
}