import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http'
import { Observable, catchError, map, throwError } from 'rxjs';
import { CurrencyEntry } from '../models/currency-entry.model';
import { CurrencyReturn } from '../models/currency-return.model';

@Injectable({
  providedIn: 'root'
})
export class CalcService {
  url: string = "https://localhost:44385/api/Calc"

  constructor(private http: HttpClient) {}

  calculateCurrency(entry: CurrencyEntry): Observable<CurrencyReturn> {
    return this.http.post<CurrencyReturn>(this.url, entry).pipe(
      map(x => x),
      catchError(this.handleError)
    )
  }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 0 || error.status === undefined) {
      console.error('Ocorreu um erro durante a solicitação: ', error.error);
      return throwError(() => new Error("Servidor não respondeu à solicitação! Tente novamente mais tarde!"));
    } else {
      console.error(
        `O Servidor retornou o status ${error.status}. Com a mensagem: `, error.error);
        return throwError(() => new Error(error.error));
    }
  }
}
