import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';

//import { LoanService } from '../services/loan.service';

import { AppComponent } from './app.component';
import { LoanCompareComponent } from './loan-compare.component';
import { LoanGraphComponent } from './loan-graph.component';
import { LoanInfoComponent } from './loan-info.component';

@NgModule({
  declarations: [
      AppComponent, LoanCompareComponent, LoanGraphComponent, LoanInfoComponent      
  ],
  imports: [
      BrowserModule, HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
