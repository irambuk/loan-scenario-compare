using LoanScenarioCompare.Calculator.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanScenarioCompare.Calculator.Tests
{
    [TestClass]
    public class LoanCalculatorCalculateRepaymentTests
    {
        [TestMethod]
        public void GivenLoanWithAmountRatePeriod_WhenCalculateRepayment_ReturnCorrectValue()
        {
            var calculator = new LoanCalculator();
            var loan = new Loan
            {
                Amount = 100000,
                RepaymentPeriod = new TimePeriod { Count = 60, TimePeriodType = TimePeriodTypes.Month },
                Rate = new Rate { PeriodType = TimePeriodTypes.Year, InterestPercentage = 10 }
            };

            var repayment = calculator.CalculateRepaymentPerPeriod(loan);

            Assert.IsNotNull(repayment);
            Assert.AreEqual(TimePeriodTypes.Month, repayment.PeriodType);
            Assert.AreNotEqual(0, repayment.RepaymentAmount);
        }

        [TestMethod]
        public void GivenLoanWithAmountRatePeriod_WhenCalculateTotalRepayment_ReturnCorrectValue()
        {
            var calculator = new LoanCalculator();
            var loan = new Loan
            {
                Amount = 100000,
                RepaymentPeriod = new TimePeriod { Count = 60, TimePeriodType = TimePeriodTypes.Month },
                Rate = new Rate { PeriodType = TimePeriodTypes.Year, InterestPercentage = 10 }
            };

            var repayment = calculator.CalculateTotalRepayment(loan);

            Assert.IsNotNull(repayment);           
            Assert.AreNotEqual(0, repayment);
        }

        [TestMethod]
        public void GivenLoanWithAmountRatePeriod_WhenCalculatePendingLoanAmount_ReturnCorrectValue()
        {
            var calculator = new LoanCalculator();
            var loan = new Loan
            {
                Amount = 100000,
                RepaymentPeriod = new TimePeriod { Count = 60, TimePeriodType = TimePeriodTypes.Month },
                Rate = new Rate { PeriodType = TimePeriodTypes.Year, InterestPercentage = 10 }
            };

            var repayment = calculator.CalculateRepaymentPerPeriod(loan);

            Assert.IsNotNull(repayment);
            Assert.AreNotEqual(0, repayment);

            var pendingAmount = calculator.CalculatePendingLoanAmount(loan, 2, (double)repayment.RepaymentAmount);

            Assert.IsNotNull(pendingAmount);
            Assert.AreNotEqual(0, pendingAmount);
            Assert.IsTrue(pendingAmount < loan.Amount);
        }

        [TestMethod]
        public void GivenLoanWithAmountRatePeriod_WhenCalculatePendingLoanInterest_ReturnCorrectValue()
        {
            var calculator = new LoanCalculator();
            var loan = new Loan
            {
                Amount = 100000,
                RepaymentPeriod = new TimePeriod { Count = 60, TimePeriodType = TimePeriodTypes.Month },
                Rate = new Rate { PeriodType = TimePeriodTypes.Year, InterestPercentage = 10 }
            };

            var repayment = calculator.CalculateRepaymentPerPeriod(loan);

            Assert.IsNotNull(repayment);
            Assert.AreNotEqual(0, repayment);

            var pendingAmount = calculator.CalculatePendingLoanAmount(loan, 2, (double)repayment.RepaymentAmount);

            Assert.IsNotNull(pendingAmount);
            Assert.AreNotEqual(0, pendingAmount);
            Assert.IsTrue(pendingAmount < loan.Amount);

            var pendingInterest = calculator.CalculatePendingLoanInterest(loan, 2, (double)repayment.RepaymentAmount, (double)pendingAmount);

            Assert.IsNotNull(pendingInterest);
            Assert.AreNotEqual(0, pendingInterest);           

        }
    }
}
