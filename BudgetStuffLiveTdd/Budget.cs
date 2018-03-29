using System;

namespace BudgetStuffLiveTdd
{
    public class Budget
    {
        public int Amount { get; set; }
        public string YearMonth { get; set; }

        public DateTime FirstDay
        {
            get { return DateTime.ParseExact(YearMonth + "01", "yyyyMMdd", null); }
        }

        public DateTime LastDay
        {
            get
            {
                var days = Days();
                return DateTime.ParseExact(YearMonth + days, "yyyyMMdd", null);
            }
        }

        private int Days()
        {
            var days = DateTime.DaysInMonth(FirstDay.Year, FirstDay.Month);
            return days;
        }
    }
}