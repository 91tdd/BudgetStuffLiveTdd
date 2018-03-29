using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BudgetStuffLiveTdd
{
    [TestClass]
    public class AccountingTests
    {
        private Accounting _accounting;

        [TestInitializeAttribute]
        public void TestInit()
        {
            _accounting = new Accounting();
        }

        [TestMethod]
        public void no_budgets()
        {
            AmountShouldBe(new DateTime(), new DateTime(), 0);
        }

        private void AmountShouldBe(DateTime startDate, DateTime endDate, int expected)
        {
            Assert.AreEqual(expected, _accounting.TotalAmount(startDate, endDate));
        }
    }
}