using System;

namespace BudgetStuffLiveTdd
{
    public class Budget
    {
        public int Amount { get; set; }
        public string YearMonth { get; set; }

        private DateTime FirstDay
        {
            get { return DateTime.ParseExact(YearMonth + "01", "yyyyMMdd", null); }
        }

        private DateTime LastDay
        {
            get { return DateTime.ParseExact(YearMonth + Days(), "yyyyMMdd", null); }
        }

        public decimal EffectiveAmount(Period period)
        {
            return (decimal) period.OverlappingDays(new Period(FirstDay, LastDay)) * DailyAmount();
        }

        private int DailyAmount()
        {
            var dailyAmount = Amount / Days();
            return dailyAmount;
        }

        private int Days()
        {
            var days = DateTime.DaysInMonth(FirstDay.Year, FirstDay.Month);
            return days;
        }
    }
}