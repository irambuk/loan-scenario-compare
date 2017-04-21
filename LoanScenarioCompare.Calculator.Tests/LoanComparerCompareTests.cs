using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoanScenarioCompare.Calculator.Data;
using System.Collections.Generic;

namespace LoanScenarioCompare.Calculator.Tests
{
    [TestClass]
    public class LoanComparerCompareTests
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
        public void GivenNullLoans_WhenCompareLoans_ThrownsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => {
                var results = _comparer.Compare(null);
            });
        }

        [TestMethod]
        public void GivenEmptyLoans_WhenCompareLoans_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => {
                var results = _comparer.Compare(new List<Loan>());
            });
        }

        [TestMethod]
        public void Given5Loans_WhenCompareLoans_Returns5Results()
        {
            var loans = new List<Loan>
            {
                new Loan() { Id = Guid.NewGuid(), Amount = 10, RepaymentPeriod = new TimePeriod { TimePeriodType = TimePeriodTypes.Week, Count = 10 }, Rate = new Rate { InterestPercentage = 1, PeriodType = TimePeriodTypes.Week } },
                new Loan() { Id = Guid.NewGuid(), Amount = 10, RepaymentPeriod = new TimePeriod { TimePeriodType = TimePeriodTypes.Week, Count = 10 }, Rate = new Rate { InterestPercentage = 1, PeriodType = TimePeriodTypes.Week } },
                new Loan() { Id = Guid.NewGuid(), Amount = 10, RepaymentPeriod = new TimePeriod { TimePeriodType = TimePeriodTypes.Week, Count = 10 }, Rate = new Rate { InterestPercentage = 1, PeriodType = TimePeriodTypes.Week } },
                new Loan() { Id = Guid.NewGuid(), Amount = 10, RepaymentPeriod = new TimePeriod { TimePeriodType = TimePeriodTypes.Week, Count = 10 }, Rate = new Rate { InterestPercentage = 1, PeriodType = TimePeriodTypes.Week } },
                new Loan() { Id = Guid.NewGuid(), Amount = 10, RepaymentPeriod = new TimePeriod { TimePeriodType = TimePeriodTypes.Week, Count = 10 }, Rate = new Rate { InterestPercentage = 1, PeriodType = TimePeriodTypes.Week } }
            };
            var results = _comparer.Compare(loans);

            Assert.IsNotNull(results);
            Assert.AreEqual(loans.Count, results.Count);
            Assert.IsTrue(results.TrueForAll(x => x.LoanId != Guid.Empty));
        }
    }
}
