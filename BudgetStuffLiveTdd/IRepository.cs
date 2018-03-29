using System.Collections.Generic;

namespace BudgetStuffLiveTdd
{
    public interface IRepository<T>
    {
        List<Budget> GetBudgets();
    }
}