﻿using LoanScenarioCompare.Calculator.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanScenarioCompare.Calculator
{
    /// <summary>
    /// Provides functionality to compare <see cref="Loan"/> properties against given parameters such as period, interest paid etc.
    /// </summary>
    public interface ILoanComparer
    {
        /// <summary>
        /// Compare multiple loans
        /// </summary>
        /// <param name="loans"></param>
        /// <returns>Collection of calculations, one <see cref="CalculationLoanResult"/> per loan</returns>
        List<CalculationLoanResult> Compare(IList<Loan> loans);

        /// <summary>
        /// Calculates the replayment details for a loan and returns the <see cref="CalculationLoanResult"/>
        /// </summary>
        /// <param name="loan"></param>
        /// <returns></returns>
        CalculationLoanResult Calculate(Loan loan);
    }

    public class LoanComparer : ILoanComparer
    {
        public ILoanCalculator LoanCalculator { get; set; }

        public LoanComparer()
        {
            LoanCalculator = new LoanCalculator();
        }

        public List<CalculationLoanResult> Compare(IList<Loan> loans)
        {
            if (loans == null || loans.Count == 0)
                throw new ArgumentException("No loans to compare");

            var results = new List<CalculationLoanResult>();

            foreach (var loan in loans)
            {
                var result = Calculate(loan);
                results.Add(result);
            }

            return results;
        }

        public CalculationLoanResult Calculate(Loan loan)
        {
            if (loan == null || loan.Id == Guid.Empty || loan.Amount == 0 || loan.RepaymentPeriod == null || loan.RepaymentPeriod.Count == 0 || loan.Rate == null || loan.Rate.InterestPercentage <0)
                throw new ArgumentException("is null or empty");

            var loanResult = new CalculationLoanResult { LoanId = loan.Id};
            
            loanResult.RepaymentPerTimePeriod = LoanCalculator.CalculateRepaymentPerPeriod(loan);
            loanResult.TotalPaymentForLifeOfLoan = LoanCalculator.CalculateTotalRepayment(loan);
            loanResult.TotalInterestPaymentForLifeOfLoan = loanResult.TotalPaymentForLifeOfLoan - loan.Amount;

            loanResult.Results = new List<CalculationPeriodResult>();
            for (int i = 0; i < loan.RepaymentPeriod.Count; i++)
            {
                var result = new CalculationPeriodResult()
                {
                    PeriodOffset = i + 1,
                    PendingLoanAmount = LoanCalculator.CalculatePendingLoanAmount(loan, i + 1, (double)loanResult.RepaymentPerTimePeriod.RepaymentAmount),                    
                };
                result.PendingInterestAmount = LoanCalculator.CalculatePendingLoanInterest(loan, i + 1, (double)loanResult.RepaymentPerTimePeriod.RepaymentAmount, (double)result.PendingLoanAmount);
                loanResult.Results.Add(result);
            }

            return loanResult;
        }
    }
}
