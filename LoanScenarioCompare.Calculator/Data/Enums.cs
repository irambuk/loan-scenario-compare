using System;
using System.Collections.Generic;
using System.Text;

namespace LoanScenarioCompare.Calculator.Data
{
    public enum RepaymentTypes
    {
        None = 0,
        PrincipleAndInterest = 1,
        InterestOnly = 2,
    }

    public enum TimePeriodTypes
    {
        None = 0,
        Week = 1,
        Fortnight = 2,
        Month = 3,
        Year = 4
    }    
}
