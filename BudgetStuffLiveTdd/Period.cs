using System;

namespace BudgetStuffLiveTdd
{
    public class Period
    {
        public Period(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                throw new InvalidException();
            }

            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public double OverlappingDays(Period period)
        {
            if (HasNoOverlappingDays(period))
            {
                return 0;
            }

            var effectiveEndDate = EndDate > period.EndDate
                ? period.EndDate
                : EndDate;

            var effectiveStartDate = StartDate < period.StartDate
                ? period.StartDate
                : StartDate;

            var days = (effectiveEndDate.AddDays(1) - effectiveStartDate).TotalDays;
            return days;
        }

        private bool HasNoOverlappingDays(Period period)
        {
            return StartDate > period.EndDate || EndDate < period.StartDate;
        }
    }
}