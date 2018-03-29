using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace BudgetStuffLiveTdd
{
    [TestClass]
    public class AccountingTests
    {
        private Accounting _accounting;
        private IRepository<Budget> _repository;

        [TestInitializeAttribute]
        public void TestInit()
        {
            _repository = Substitute.For<IRepository<Budget>>();
            _accounting = new Accounting(_repository);
        }

        [TestMethod]
        public void no_budgets()
        {
            _repository.GetBudgets().ReturnsForAnyArgs(new List<Budget>
            {
            });
            AmountShouldBe(new DateTime(), new DateTime(), 0);
        }

        [TestMethod]
        public void one_effective_day_period_inside_budget_month()
        {
            _repository.GetBudgets().ReturnsForAnyArgs(new List<Budget>
            {
                new Budget {YearMonth = "201704", Amount = 30}
            });

            AmountShouldBe(new DateTime(2017, 4, 1), new DateTime(2017, 4, 1), 1);
        }

        private void AmountShouldBe(DateTime startDate, DateTime endDate, int expected)
        {
            Assert.AreEqual(expected, _accounting.TotalAmount(startDate, endDate));
        }
    }
}