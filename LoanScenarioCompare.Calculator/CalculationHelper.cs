using LoanScenarioCompare.Calculator.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanScenarioCompare.Calculator
{
    public interface ICalculationHelper
    {
        int CalculatePeriodInDays(PeriodTypes periodType, int count);
    }

    public class CalculationHelper : ICalculationHelper
    {
        public int CalculatePeriodInDays(PeriodTypes periodType, int count)
        {
            switch (periodType)
            {
                case PeriodTypes.None:
                    throw new NotSupportedException($"Given period type: {periodType} is not valid to CalculatePeriodInDays");
                case PeriodTypes.Week:
                    return count * 7;
                case PeriodTypes.Fortnight:
                    return count * 7 * 2;
                case PeriodTypes.Month:
                    return count * 30;
                 case PeriodTypes.Year:
                    return count * 365;
                default:
                    throw new NotSupportedException($"Given period type: {periodType} is not valid to CalculatePeriodInDays");
            }
        }
    }
}
