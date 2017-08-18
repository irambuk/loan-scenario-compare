import { Component, Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import { LoanService } from '../services/loan.service';
import { LoanScenario } from '../services/loan.model';

@Component({
  selector: 'loan-compare',
  templateUrl: './loan-compare.component.html',
  //styleUrls: ['./loan-compare.component.css']
  providers: [LoanService]
})

@Injectable()
export class LoanCompareComponent {
    title = 'app';
    loanScenario: LoanScenario;
    name: string;

    constructor(private loanService: LoanService) {
        loanService.getloanscenario().subscribe(
            result => {
                this.loanScenario = result[0];
                this.name = this.loanScenario.name;
            });

    }
}
