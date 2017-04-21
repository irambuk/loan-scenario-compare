using LoanScenarioCompare.Calculator.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanScenarioCompare.Calculator
{
    public interface ISampleLoanProvider
    {
        Loan GetLoan1();

        Loan GetLoan2();

        LoanScenario GetLoanScenario();
    }

    public class SampleLoanProvider : ISampleLoanProvider
    {
        public Loan GetLoan1()
        {
            var loan = new Loan()
            {
                Id = Guid.NewGuid(),
                Name = "Sample Loan 1",

                Amount = 100000,
                RepaymentType = RepaymentTypes.PrincipleAndInterest,
                RepaymentPeriod = new TimePeriod { TimePeriodType = TimePeriodTypes.Month, Count = 60 },
                Rate = new Rate { PeriodType = TimePeriodTypes.Year, InterestPercentage = 8 },

                InitialPaymentAmount = 1000,
                FinalPaymentAmount = 5000,

                InitialFees = new List<Fee>(),
                MaintenanceFees = new List<Fee>(),
                FinalFees = new List<Fee>()
            };
            loan.InitialFees.Add(new Fee { Name = "Setup Fee", Amount = 250 });

            loan.InitialFees.Add(new Fee { Name = "Monthly Fee", Amount = 10, Period = TimePeriodTypes.Month });
            loan.InitialFees.Add(new Fee { Name = "Annual Package Fee", Amount = 300, Period = TimePeriodTypes.Year });
            
            loan.InitialFees.Add(new Fee { Name = "Discharge Fee", Amount = 250 });

            return loan;
        }

        public Loan GetLoan2()
        {
            var loan = new Loan()
            {
                Id = Guid.NewGuid(),
                Name = "Sample Loan 2",

                Amount = 200000,
                RepaymentType = RepaymentTypes.PrincipleAndInterest,
                RepaymentPeriod = new TimePeriod { TimePeriodType = TimePeriodTypes.Month, Count = 120 },
                Rate = new Rate { PeriodType = TimePeriodTypes.Year, InterestPercentage = 6 },

                InitialPaymentAmount = 1000,
                FinalPaymentAmount = 5000,

                InitialFees = new List<Fee>(),
                MaintenanceFees = new List<Fee>(),
                FinalFees = new List<Fee>()
            };
            loan.InitialFees.Add(new Fee { Name = "Setup Fee", Amount = 250 });

            loan.InitialFees.Add(new Fee { Name = "Monthly Fee", Amount = 10, Period = TimePeriodTypes.Month });
            loan.InitialFees.Add(new Fee { Name = "Annual Package Fee", Amount = 300, Period = TimePeriodTypes.Year });

            loan.InitialFees.Add(new Fee { Name = "Discharge Fee", Amount = 250 });

            return loan;
        }

        public LoanScenario GetLoanScenario()
        {
            var scenario = new LoanScenario()
            {
                Id = Guid.NewGuid(),
                Name = "Sample Loan Scenario",
                Loans = new List<Loan>()
            };
            scenario.Loans.Add(GetLoan1());
            scenario.Loans.Add(GetLoan2());

            return scenario;
        }
    }
}
