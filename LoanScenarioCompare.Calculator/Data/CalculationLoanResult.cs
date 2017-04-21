using System;
using System.Collections.Generic;
using System.Text;

namespace LoanScenarioCompare.Calculator.Data
{
    public class CalculationLoanResult
    {
        public Guid LoanId { get; set; }

        public CalculationLoanRepayment RepaymentPerTimePeriod { get; set; }

        public decimal TotalPaymentForLifeOfLoan { get; set; }

        public decimal TotalInterestPaymentForLifeOfLoan { get; set; }

        public List<CalculationPeriodResult> Results { get; set; }
    }
}
