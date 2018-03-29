using System;
using System.Collections.Generic;
using System.Linq;
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
            GivenBudgets();
            AmountShouldBe(new DateTime(), new DateTime(), 0);
        }

        [TestMethod]
        public void one_effective_day_period_inside_budget_month()
        {
            GivenBudgets(
                new Budget {YearMonth = "201704", Amount = 30}
            );

            AmountShouldBe(new DateTime(2017, 4, 1), new DateTime(2017, 4, 1), 1);
        }

        [TestMethod]
        public void no_overlapping_days_period_before_budget_month()
        {
            GivenBudgets(
                new Budget {YearMonth = "201704", Amount = 30}
            );

            AmountShouldBe(new DateTime(2017, 3, 31), new DateTime(2017, 3, 31), 0);
        }

        [TestMethod]
        public void no_overlapping_days_period_after_budget_month()
        {
            GivenBudgets(
                new Budget {YearMonth = "201704", Amount = 30}
            );

            AmountShouldBe(new DateTime(2017, 5, 1), new DateTime(2017, 5, 1), 0);
        }

        [TestMethod]
        public void one_overlapping_days_period_across_budget_LastDay()
        {
            GivenBudgets(
                new Budget {YearMonth = "201704", Amount = 30}
            );

            AmountShouldBe(new DateTime(2017, 4, 30), new DateTime(2017, 5, 1), 1);
        }

        [TestMethod]
        public void one_overlapping_days_period_across_budget_FirstDay()
        {
            GivenBudgets(
                new Budget {YearMonth = "201704", Amount = 30}
            );

            AmountShouldBe(new DateTime(2017, 3, 31), new DateTime(2017, 4, 1), 1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidException))]
        public void invalid_period()
        {
            GivenBudgets(
                new Budget {YearMonth = "201704", Amount = 30}
            );

            AmountShouldBe(new DateTime(2017, 5, 31), new DateTime(2017, 4, 1), 1);
        }

        private void GivenBudgets(params Budget[] budgets)
        {
            _repository.GetBudgets().ReturnsForAnyArgs(budgets.ToList());
        }

        private void AmountShouldBe(DateTime startDate, DateTime endDate, int expected)
        {
            Assert.AreEqual(expected, _accounting.TotalAmount(startDate, endDate));
        }
    }
}