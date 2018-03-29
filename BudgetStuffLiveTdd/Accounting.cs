using System;
using System.Linq;

namespace BudgetStuffLiveTdd
{
    public class Accounting
    {
        private IRepository<Budget> _repository;

        public Accounting(IRepository<Budget> repository)
        {
            _repository = repository;
        }

        public decimal TotalAmount(DateTime startDate, DateTime endDate)
        {
            var period = new Period(startDate, endDate);

            return _repository.GetBudgets()
                .Sum(b => b.EffectiveAmount(period));
        }
    }
}