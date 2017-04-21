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

        decimal CalculateTotalRepayment(Loan loan);

        decimal CalculatePendingLoanAmount(Loan loan, int inNoOfPeriods, double repaymentPerPeriod);

        decimal CalculatePendingLoanInterest(Loan loan, int inNoOfPeriods, double repaymentPerPeriod, double pendingLoanAmount);
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

            var repayment = (rate + rate / (Math.Pow(1 + rate, periods) - 1)) * amount;

            return new CalculationLoanRepayment { PeriodType = loan.RepaymentPeriod.TimePeriodType, RepaymentAmount = Convert.ToDecimal(repayment) };
        }

        public decimal CalculateTotalRepayment(Loan loan)
        {
            var amount = Convert.ToDouble(loan.Amount);
            var rate = PeriodConverter.CovertPeriod(loan.Rate.PeriodType, loan.Rate.InterestPercentage / 100, loan.RepaymentPeriod.TimePeriodType);
            var periods = loan.RepaymentPeriod.Count;

            var repayment = Math.Pow(1 + rate, periods)  * amount;

            return Convert.ToDecimal(repayment);
        }

        public decimal CalculatePendingLoanAmount(Loan loan, int inNoOfPeriods, double repaymentPerPeriod)
        {
            var amount = Convert.ToDouble(loan.Amount);
            var rate = PeriodConverter.CovertPeriod(loan.Rate.PeriodType, loan.Rate.InterestPercentage / 100, loan.RepaymentPeriod.TimePeriodType);
            var periods = loan.RepaymentPeriod.Count;
            
            var repayment = Math.Pow(1 + rate, inNoOfPeriods) * amount - repaymentPerPeriod * (Math.Pow(1+rate, inNoOfPeriods) -1) / (rate);

            return Convert.ToDecimal(repayment);
        }

        public decimal CalculatePendingLoanInterest(Loan loan, int inNoOfPeriods, double repaymentPerPeriod, double pendingLoanAmount)
        {
            var totalLoanPayment = loan.RepaymentPeriod.Count * repaymentPerPeriod;
            var totalPaidSoFar = inNoOfPeriods * repaymentPerPeriod;

            return Convert.ToDecimal(totalLoanPayment - totalPaidSoFar - pendingLoanAmount); 
        }

        
    }
}
