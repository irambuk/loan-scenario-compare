using LoanScenarioCompare.Calculator.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanScenarioCompare.Calculator
{
    /// <summary>
    /// Calculates the loan repayment, remaining balance etc
    /// </summary>
    public interface ILoanCalculator
    {
        CalculationLoanRepayment CalculateRepaymentPerPeriod(Loan loan);
    }

    public class LoanCalculator : ILoanCalculator
    {
        public IPeriodConverter PeriodConverter { get; set; }

        public LoanCalculator()
        {
            PeriodConverter = new PeriodConverter();
        }

        public CalculationLoanRepayment CalculateRepaymentPerPeriod(Loan loan)
        {
            var amount = Convert.ToDouble(loan.Amount);
            var rate = PeriodConverter.CovertPeriod(loan.Rate.PeriodType, loan.Rate.InterestPercentage / 100, loan.RepaymentPeriod.TimePeriodType);
            var periods = loan.RepaymentPeriod.Count;

            //var repayment= Convert.ToDouble(rate * amount) /(1 - Math.Pow(Convert.ToDouble(1 + rate), -periods ));
            var repayment = (rate + rate / (Math.Pow(1 + rate, periods) - 1)) * amount;

            return new CalculationLoanRepayment { PeriodType = loan.RepaymentPeriod.TimePeriodType, RepaymentAmount = Convert.ToDecimal(repayment) };
        }
    }
}
