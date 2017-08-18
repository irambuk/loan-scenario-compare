import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

import { LoanScenario} from './loan.model'

@Injectable()
export class LoanService {

    constructor(private http: HttpClient) {
    }

    getloanscenario(): Observable<LoanScenario> {
        var httpHeaders = new HttpHeaders();
        //httpHeaders = httpHeaders.append('Access-Control-Allow-Origin', ['http://localhost:50668']);
        //httpHeaders = httpHeaders.append('Origin', ['http://localhost:50668']);
        //httpHeaders = httpHeaders.append('Access-Control-Allow-Origin', ['*', 'http://localhost:50668/api/loanscenarios']);
        //httpHeaders = httpHeaders.append('Access-Control-Allow-Origin', ['*', 'http://localhost:50668/api/loanscenarios']);
        
        var result = this.http.get<LoanScenario>('http://localhost:50668/api/loanscenarios', { 'headers': httpHeaders})
          //.subscribe(
          //    data => { },
          //    err => console.log(err)
          //);
        return result;
    }
} 
