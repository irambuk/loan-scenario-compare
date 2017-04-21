using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoanScenarioCompare.Calculator.Data;
using System.Collections.Generic;

namespace LoanScenarioCompare.Calculator.Tests
{
    [TestClass]
    public class LoanComparerCalculateTests
    {
        [TestMethod]
        public void GivenNullLoans_WhenCalculateLoan_ThrownsArgumentException()
        {
            var comparer = new LoanComparer();

            Assert.ThrowsException<ArgumentException>(() => {
                var results = comparer.Calculate(null);
            });
            

            //Assert.IsNotNull(results);
            //Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void GivenEmptyLoans_WhenCalculateLoan_ThrowsArgumentException()
        {
            var comparer = new LoanComparer();

            Assert.ThrowsException<ArgumentException>(() => {
                var results = comparer.Calculate(new Loan());
            });

            //Assert.IsNotNull(results);
            //Assert.AreEqual(0, results.Count);
        }
    }
}
