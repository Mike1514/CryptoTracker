import { Component, Input } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-stats',
  standalone: false,
  template: `
    <mat-card>
      <h3>Max Price</h3>
      <p>{{ maxPrice | number:'1.2-2' }}</p>
    </mat-card>
    <mat-card>
      <h3>Average Price</h3>
      <p>{{ averagePrice | number:'1.2-2' }}</p>
    </mat-card>
  `,
  styleUrls: ['./stats.component.scss']
})
export class StatsComponent {
  @Input() maxPrice: number = 0;
  @Input() averagePrice: number = 0;
}

