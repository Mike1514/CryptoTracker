import { Component, OnInit } from '@angular/core';
import { PriceService } from './services/price.service';
import { ChartData } from 'chart.js';
import { PriceRecord } from './models/price.model';
import { StatsComponent } from "./components/stats/stats.component";
import { ChartComponent } from "./components/chart/chart.component";
import { CommonModule } from '@angular/common';
import { BaseChartDirective } from 'ng2-charts';
@Component({
  selector: 'app-root',
  standalone: false,
  template: `
    <div class="dashboard">
      <app-stats [maxPrice]="maxPrice" [averagePrice]="averagePrice"></app-stats>
      <app-chart [labels]="chartData.labels" [data]="chartData.data" ></app-chart>
    </div>
  `,
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  chartData :{ labels: string[], data: number[] } = { labels: [], data: [] };
  maxPrice = 0;
  averagePrice = 0;

  constructor(private priceService: PriceService) {}

  ngOnInit(): void {
    const from = new Date(Date.now() - 3600000).toISOString();
    const to = new Date().toISOString();

    this.priceService.pollPrices(60000, from, to).subscribe(prices => {
      this.chartData = {
        labels: prices.map(p => new Date(p.time).toLocaleTimeString()),
        data: prices.map(p => p.value)
      };
      const values = prices.map(p => p.value);
      this.maxPrice = Math.max(...values);
      this.averagePrice = values.reduce((sum, v) => sum + v, 0) / values.length;
    });
  }
}
