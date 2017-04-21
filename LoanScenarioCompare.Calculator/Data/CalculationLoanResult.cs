using System;
using System.Collections.Generic;
using System.Text;

namespace LoanScenarioCompare.Calculator.Data
{
    public class CalculationLoanResult
    {
        public Guid LoanId { get; set; }

        public List<CalculationPeriodResult> Results { get; set; }
    }
}
