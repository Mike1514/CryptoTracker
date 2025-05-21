import { Component, Input, OnChanges } from '@angular/core';
import { ChartConfiguration, ChartType } from 'chart.js';
import { BaseChartDirective } from 'ng2-charts';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-chart',
  standalone: false,
  templateUrl: './chart.component.html',
})
export class ChartComponent implements OnChanges {
  @Input() labels: string[] = [];
  @Input() data: number[] = [];

  public lineChartData: ChartConfiguration<'line'>['data'] = {
    labels: [],
    datasets: [
      {
        data: [],
        label: 'BTC Price',
        fill: true,
        tension: 0.4,
        borderColor: 'blue',
        backgroundColor: 'rgba(0,0,255,0.2)',
        pointBackgroundColor: 'blue',
        pointBorderColor: '#fff',
        pointHoverBackgroundColor: '#fff',
        pointHoverBorderColor: 'blue',
      }
    ],
  };

  public lineChartOptions: ChartConfiguration<'line'>['options'] = {
    responsive: true,
    plugins: {
      legend: { display: true },
    },
  };

  public lineChartType: ChartType = 'line';

  ngOnChanges(): void {
    if (this.lineChartData && this.lineChartData.datasets && this.lineChartData.datasets.length > 0) {
      this.lineChartData.labels = this.labels;
      this.lineChartData.datasets[0].data = this.data;
    }
  }
}
