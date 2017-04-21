using System;
using System.Collections.Generic;
using System.Text;

namespace LoanScenarioCompare.Calculator.Data
{
    public class Loan
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Amount { get; set; }

        public RepaymentTypes RepaymentType { get; set; }

        public Period RepaymentPeriod { get; set; }

        public Rate Rate { get; set; }

        public decimal InitialPaymentAmount { get; set; }

        public decimal FinalPaymentAmount { get; set; }

        public IList<Fee> InitialFees { get; set; }

        public IList<Fee> MaintenanceFees { get; set; }

        public IList<Fee> FinalFees { get; set; }
    }
}
