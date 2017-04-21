using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoanScenarioCompare.Calculator.Data;
using System.Collections.Generic;

namespace LoanScenarioCompare.Calculator.Tests
{
    [TestClass]
    public class LoanComparerCompareTests
    {
        [TestMethod]
        public void GivenNullLoans_WhenCompareLoans_ThrownsArgumentException()
        {
            var comparer = new LoanComparer();

            Assert.ThrowsException<ArgumentException>(() => {
                var results = comparer.Compare(null);
            });
            

            //Assert.IsNotNull(results);
            //Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void GivenEmptyLoans_WhenCompareLoans_ThrowsArgumentException()
        {
            var comparer = new LoanComparer();

            Assert.ThrowsException<ArgumentException>(() => {
                var results = comparer.Compare(new List<Loan>());
            });

            //Assert.IsNotNull(results);
            //Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void Given5Loans_WhenCompareLoans_Returns5Results()
        {
            var comparer = new LoanComparer();
            var loans = new List<Loan>
            {
                new Loan() { Id = Guid.NewGuid(), Amount = 10, RepaymentPeriod = new TimePeriod { TimePeriodType = TimePeriodTypes.Week, Count = 10 }, Rate = new Rate { InterestPercentage = 1, PeriodType = TimePeriodTypes.Week } },
                new Loan() { Id = Guid.NewGuid(), Amount = 10, RepaymentPeriod = new TimePeriod { TimePeriodType = TimePeriodTypes.Week, Count = 10 }, Rate = new Rate { InterestPercentage = 1, PeriodType = TimePeriodTypes.Week } },
                new Loan() { Id = Guid.NewGuid(), Amount = 10, RepaymentPeriod = new TimePeriod { TimePeriodType = TimePeriodTypes.Week, Count = 10 }, Rate = new Rate { InterestPercentage = 1, PeriodType = TimePeriodTypes.Week } },
                new Loan() { Id = Guid.NewGuid(), Amount = 10, RepaymentPeriod = new TimePeriod { TimePeriodType = TimePeriodTypes.Week, Count = 10 }, Rate = new Rate { InterestPercentage = 1, PeriodType = TimePeriodTypes.Week } },
                new Loan() { Id = Guid.NewGuid(), Amount = 10, RepaymentPeriod = new TimePeriod { TimePeriodType = TimePeriodTypes.Week, Count = 10 }, Rate = new Rate { InterestPercentage = 1, PeriodType = TimePeriodTypes.Week } }
            };
            var results = comparer.Compare(loans);

            Assert.IsNotNull(results);
            Assert.AreEqual(loans.Count, results.Count);
            Assert.IsTrue(results.TrueForAll(x => x.LoanId != Guid.Empty));
        }
    }
}
