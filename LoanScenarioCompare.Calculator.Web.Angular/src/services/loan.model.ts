
export class LoanScenario {
    public id: string;
    public name: string;
    public loans: Array<Loan>;
}

export class Loan {
    public id: string;
    public name: string;
    public amount: number;
    public repaymentType: RepaymentTypes;
    public repaymentPeriod: TimePeriod;
    public rate: Rate;
    public initialPaymentAmount: number;
    public finalPaymentAmount: number;
    public initialFees: Array<Fee>;
    public maintenanceFees: Array<Fee>;
    public finalFees: Array<Fee>;
}

export class Rate {
    public PeriodType: TimePeriodTypes;
    public InterestPercentage: number;
}

export class TimePeriod {
    public TimePeriodType: TimePeriodTypes;
    public Count: number;
}

export class Fee {
    public Name: string;
    public Amount: number;
    public Period: TimePeriodTypes;
}

export enum RepaymentTypes {
    None = 0,

    PrincipleAndInterest = 1,

    InterestOnly = 2
}
export enum TimePeriodTypes {
    None = 0,

    Week = 1,

    Fortnight = 2,

    Month = 3,

    Year = 4
}