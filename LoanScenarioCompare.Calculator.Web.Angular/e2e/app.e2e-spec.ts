import { LoanScenarioCompare.Calculator.Web.AngularPage } from './app.po';

describe('loan-scenario-compare.calculator.web.angular App', () => {
  let page: LoanScenarioCompare.Calculator.Web.AngularPage;

  beforeEach(() => {
    page = new LoanScenarioCompare.Calculator.Web.AngularPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!!');
  });
});
