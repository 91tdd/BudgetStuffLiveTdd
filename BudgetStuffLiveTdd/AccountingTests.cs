using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BudgetStuffLiveTdd
{
    [TestClass]
    public class AccountingTests
    {
        [TestMethod]
        public void no_budgets()
        {
            var accounting = new Accounting();
            var totalAmount = accounting.TotalAmount(new DateTime(), new DateTime());
            Assert.AreEqual(0, totalAmount);
        }
    }
}