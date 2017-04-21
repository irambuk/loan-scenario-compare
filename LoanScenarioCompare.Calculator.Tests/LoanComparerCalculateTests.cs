using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoanScenarioCompare.Calculator.Data;
using System.Collections.Generic;

namespace LoanScenarioCompare.Calculator.Tests
{
    [TestClass]
    public class LoanComparerCalculateTests
    {
        private ILoanComparer _comparer;

        [TestInitialize]
        public void Initialize()
        {
            var periodConverter = new PeriodConverter();
            var loanCalculator = new LoanCalculator(periodConverter);
            _comparer = new LoanComparer(loanCalculator);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _comparer = null;
        }

        [TestMethod]
        public void GivenNullLoans_WhenCalculateLoan_ThrownsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => {
                var results = _comparer.Calculate(null);
            });
            

            //Assert.IsNotNull(results);
            //Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void GivenEmptyLoans_WhenCalculateLoan_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => {
                var results = _comparer.Calculate(new Loan());
            });

            //Assert.IsNotNull(results);
            //Assert.AreEqual(0, results.Count);
        }
    }
}
