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
            var budgets = _repository.GetBudgets();
            if (HasNoBudgets(budgets)) return 0;
 
            var days = new Period(startDate, endDate).OverlappingDays(budgets[0]);
            return (decimal) days;
        }

        private bool HasNoBudgets(List<Budget> budgets)
        {
            return !budgets.Any();
        }
    }
}