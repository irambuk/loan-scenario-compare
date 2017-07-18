import { browser, by, element } from 'protractor';

export class LoanScenarioCompare.Calculator.Web.AngularPage {
  navigateTo() {
    return browser.get('/');
  }

  getParagraphText() {
    return element(by.css('app-root h1')).getText();
  }
}
