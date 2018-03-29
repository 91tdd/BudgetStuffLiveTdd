using System;
using System.Collections.Generic;
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

            var totalAmount = 0m;
            foreach (var budget in _repository.GetBudgets())
            {
                totalAmount += budget.EffectiveAmount(period);
            }
            return totalAmount;
        }

        private bool HasNoBudgets(List<Budget> budgets)
        {
            return !budgets.Any();
        }
    }
}