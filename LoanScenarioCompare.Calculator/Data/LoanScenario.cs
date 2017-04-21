using System;
using System.Collections.Generic;
using System.Text;

namespace LoanScenarioCompare.Calculator.Data
{
    public class LoanScenario
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IList<Loan> Loans { get; set; }
    }
}
