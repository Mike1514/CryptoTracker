import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PriceRecord } from '../models/price.model';
import { Observable, timer, switchMap, catchError, retry } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class PriceService {
  private apiUrl = 'https://localhost:7214/api/price';
  private maxRetries = 3;

  constructor(private http: HttpClient) {}

  getPrices(from: string, to: string): Observable<PriceRecord[]> {
    return this.http.get<PriceRecord[]>(`${this.apiUrl}?fromDate=${from}&toDate=${to}`).pipe(
      retry(this.maxRetries),
      catchError((error) => {
        console.error('Error fetching prices:', error);
        return [];
      })
    );
  }

  pollPrices(intervalMs = 5000, from: string, to: string): Observable<PriceRecord[]> {
    return timer(0, intervalMs).pipe(
      switchMap(() => this.getPrices(from, to))
    );
  }
}
