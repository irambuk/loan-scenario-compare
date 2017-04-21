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
        decimal CalculatePeriodInDays(TimePeriodTypes periodType, decimal count);

        double CovertPeriod(TimePeriodTypes sourcePeriodType, decimal sourceValue, TimePeriodTypes targetPeriodType);
    }

    public class PeriodConverter : IPeriodConverter
    {
        public decimal CalculatePeriodInDays(TimePeriodTypes periodType, decimal count)
        {
            switch (periodType)
            {
                case TimePeriodTypes.None:
                    throw new NotSupportedException($"Given period type: {periodType} is not valid to CalculatePeriodInDays");
                case TimePeriodTypes.Week:
                    return count * 7;
                case TimePeriodTypes.Fortnight:
                    return count * 7 * 2;
                case TimePeriodTypes.Month:
                    return count * 30;
                case TimePeriodTypes.Year:
                    return count * 365;
                default:
                    throw new NotSupportedException($"Given period type: {periodType} is not valid to CalculatePeriodInDays");
            }
        }

        public double CovertPeriod(TimePeriodTypes sourcePeriodType, decimal sourceValue, TimePeriodTypes targetPeriodType)
        {
            if (sourcePeriodType != TimePeriodTypes.Week && sourcePeriodType != TimePeriodTypes.Fortnight && sourcePeriodType != TimePeriodTypes.Month && sourcePeriodType != TimePeriodTypes.Year)
                throw new NotSupportedException($"Given source period type: {sourcePeriodType} is not valid to CovertPeriod");

            if (targetPeriodType != TimePeriodTypes.Week && targetPeriodType != TimePeriodTypes.Fortnight && targetPeriodType != TimePeriodTypes.Month && targetPeriodType != TimePeriodTypes.Year)
                throw new NotSupportedException($"Given targe period type: {sourcePeriodType} is not valid to CovertPeriod");


            double conversionRatio = 1;

            switch (sourcePeriodType)
            {
                case TimePeriodTypes.Week:
                    switch (targetPeriodType)
                    {
                        case TimePeriodTypes.Week:
                            conversionRatio = 1;
                            break;
                        case TimePeriodTypes.Fortnight:
                            conversionRatio = 2;
                            break;
                        case TimePeriodTypes.Month:
                            conversionRatio = 31 / 7;
                            break;
                        case TimePeriodTypes.Year:
                            conversionRatio = 52;
                            break;
                    }
                    break;
                case TimePeriodTypes.Fortnight:
                    switch (targetPeriodType)
                    {
                        case TimePeriodTypes.Week:
                            conversionRatio = 0.5;
                            break;
                        case TimePeriodTypes.Fortnight:
                            conversionRatio = 1;
                            break;
                        case TimePeriodTypes.Month:
                            conversionRatio = 31 / 14;
                            break;
                        case TimePeriodTypes.Year:
                            conversionRatio = 26;
                            break;
                    }
                    break;
                case TimePeriodTypes.Month:
                    switch (targetPeriodType)
                    {
                        case TimePeriodTypes.Week:
                            conversionRatio = 7/31;
                            break;
                        case TimePeriodTypes.Fortnight:
                            conversionRatio = 14/31;
                            break;
                        case TimePeriodTypes.Month:
                            conversionRatio = 1;
                            break;
                        case TimePeriodTypes.Year:
                            conversionRatio = 12;
                            break;
                    }
                    break;
                case TimePeriodTypes.Year:
                    switch (targetPeriodType)
                    {
                        case TimePeriodTypes.Week:
                            conversionRatio = 1/52;
                            break;
                        case TimePeriodTypes.Fortnight:
                            conversionRatio = 1/26;
                            break;
                        case TimePeriodTypes.Month:
                            conversionRatio = (double)1/12;
                            break;
                        case TimePeriodTypes.Year:
                            conversionRatio = 1;
                            break;
                    }
                    break;
            }


            return conversionRatio * Convert.ToDouble(sourceValue);
        }
    }
}
