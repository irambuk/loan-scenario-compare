using System;
using System.Collections.Generic;
using System.Text;

namespace LoanScenarioCompare.Calculator.Data
{
    public class Fee
    {
        public string Name { get; set; }

        public decimal Amount { get; set; }

        public PeriodTypes Period { get; set; }
    }
}
