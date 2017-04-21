using LoanScenarioCompare.Calculator.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanScenarioCompare.Calculator
{
    /// <summary>
    /// Helps to work with time periods easily
    /// </summary>
    public interface IPeriodConverter
    {
        decimal CalculatePeriodInDays(PeriodTypes periodType, decimal count);

        double CovertPeriod(PeriodTypes sourcePeriodType, decimal sourceValue, PeriodTypes targetPeriodType);
    }

    public class PeriodConverter : IPeriodConverter
    {
        public decimal CalculatePeriodInDays(PeriodTypes periodType, decimal count)
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

        public double CovertPeriod(PeriodTypes sourcePeriodType, decimal sourceValue, PeriodTypes targetPeriodType)
        {
            if (sourcePeriodType != PeriodTypes.Week && sourcePeriodType != PeriodTypes.Fortnight && sourcePeriodType != PeriodTypes.Month && sourcePeriodType != PeriodTypes.Year)
                throw new NotSupportedException($"Given source period type: {sourcePeriodType} is not valid to CovertPeriod");

            if (targetPeriodType != PeriodTypes.Week && targetPeriodType != PeriodTypes.Fortnight && targetPeriodType != PeriodTypes.Month && targetPeriodType != PeriodTypes.Year)
                throw new NotSupportedException($"Given targe period type: {sourcePeriodType} is not valid to CovertPeriod");


            double conversionRatio = 1;

            switch (sourcePeriodType)
            {
                case PeriodTypes.Week:
                    switch (targetPeriodType)
                    {
                        case PeriodTypes.Week:
                            conversionRatio = 1;
                            break;
                        case PeriodTypes.Fortnight:
                            conversionRatio = 2;
                            break;
                        case PeriodTypes.Month:
                            conversionRatio = 31 / 7;
                            break;
                        case PeriodTypes.Year:
                            conversionRatio = 52;
                            break;
                    }
                    break;
                case PeriodTypes.Fortnight:
                    switch (targetPeriodType)
                    {
                        case PeriodTypes.Week:
                            conversionRatio = 0.5;
                            break;
                        case PeriodTypes.Fortnight:
                            conversionRatio = 1;
                            break;
                        case PeriodTypes.Month:
                            conversionRatio = 31 / 14;
                            break;
                        case PeriodTypes.Year:
                            conversionRatio = 26;
                            break;
                    }
                    break;
                case PeriodTypes.Month:
                    switch (targetPeriodType)
                    {
                        case PeriodTypes.Week:
                            conversionRatio = 7/31;
                            break;
                        case PeriodTypes.Fortnight:
                            conversionRatio = 14/31;
                            break;
                        case PeriodTypes.Month:
                            conversionRatio = 1;
                            break;
                        case PeriodTypes.Year:
                            conversionRatio = 12;
                            break;
                    }
                    break;
                case PeriodTypes.Year:
                    switch (targetPeriodType)
                    {
                        case PeriodTypes.Week:
                            conversionRatio = 1/52;
                            break;
                        case PeriodTypes.Fortnight:
                            conversionRatio = 1/26;
                            break;
                        case PeriodTypes.Month:
                            conversionRatio = (double)1/12;
                            break;
                        case PeriodTypes.Year:
                            conversionRatio = 1;
                            break;
                    }
                    break;
            }


            return conversionRatio * Convert.ToDouble(sourceValue);
        }
    }
}
