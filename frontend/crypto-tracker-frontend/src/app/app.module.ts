import { NgModule, provideZoneChangeDetection } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';


import { AppComponent } from './app.component';
import { ChartComponent } from './components/chart/chart.component';
import { StatsComponent } from './components/stats/stats.component';
import { MatCardModule } from '@angular/material/card';
import { BaseChartDirective, provideCharts, withDefaultRegisterables } from 'ng2-charts';
import { CommonModule } from '@angular/common';
import { provideHttpClient } from '@angular/common/http';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';

@NgModule({
  declarations: [
    AppComponent,
    ChartComponent,
    StatsComponent
  ],
  imports: [
    BrowserModule,
    MatCardModule,
    BaseChartDirective,
    CommonModule
  ],
  providers: [provideZoneChangeDetection({ eventCoalescing: true }), provideRouter(routes),
    provideHttpClient(),
    provideCharts(withDefaultRegisterables())],
  bootstrap: [AppComponent]
})
export class AppModule {}
