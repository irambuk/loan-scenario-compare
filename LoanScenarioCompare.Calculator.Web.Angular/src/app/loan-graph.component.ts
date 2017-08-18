﻿import { Component, ViewChild, ElementRef, AfterViewInit } from '@angular/core';
import { Chart} from 'chart.js';

@Component({
  selector: 'loan-graph',
  templateUrl: './loan-graph.component.html'//,
  //styleUrls: ['./loan-graph.component.css']
})
export class LoanGraphComponent implements AfterViewInit  {
    @ViewChild('loanChart') loanChart: ElementRef;

    title = 'app';

    constructor() {
        //this.initChart();
    }

    ngAfterViewInit() {
        this.initChart();
    }

    initChart(): void{
        // Any of the following formats may be used
        //var ctx = this.document.getElementById("loanChart");
        var ctx = this.loanChart.nativeElement.getContext('2d');

        var myChart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: ["Red", "Blue", "Yellow", "Green", "Purple", "Orange"],
                datasets: [{
                    label: '# of Votes',
                    data: [12, 19, 3, 5, 2, 3],
                    backgroundColor: [
                        'rgba(255, 99, 132, 0.2)',
                        'rgba(54, 162, 235, 0.2)',
                        'rgba(255, 206, 86, 0.2)',
                        'rgba(75, 192, 192, 0.2)',
                        'rgba(153, 102, 255, 0.2)',
                        'rgba(255, 159, 64, 0.2)'
                    ],
                    borderColor: [
                        'rgba(255,99,132,1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(255, 206, 86, 1)',
                        'rgba(75, 192, 192, 1)',
                        'rgba(153, 102, 255, 1)',
                        'rgba(255, 159, 64, 1)'
                    ],
                    borderWidth: 1
                }]
            },
            options: {
                scales: {
                    yAxes: [{
                        ticks: {
                            beginAtZero: true
                        }
                    }]
                }
            }
        });
        
    }
}
