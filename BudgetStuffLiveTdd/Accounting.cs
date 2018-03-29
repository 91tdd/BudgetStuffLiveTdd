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
            if (_repository.GetBudgets().Any())
            {
                var days = new Period(startDate, endDate).Days();
                return (decimal) days;
            }
            return 0;
        }
    }
}