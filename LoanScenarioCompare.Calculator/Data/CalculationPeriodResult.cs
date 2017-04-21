using System;
using System.Collections.Generic;
using System.Text;

namespace LoanScenarioCompare.Calculator.Data
{
    public class CalculationPeriodResult
    {
        public TimePeriodTypes PeriodType { get; set; }

        public int PeriodOffset { get; set; }

        public decimal PendingLoanAmount { get; set; }

        public decimal PendingInterestAmount { get; set; }

        public decimal PendingTotalAmount
        {
            get
            {
                return PendingLoanAmount + PendingInterestAmount;
            }
        }
    }
}
