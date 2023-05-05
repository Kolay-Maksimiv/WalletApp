import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { TransactionsListModel } from '../views/transactions/transactions.component';
import { BlocsModel } from '../views/users/users.component';

@Injectable({
  providedIn: 'root'
})
export class TransactionService {

  constructor(
    private http: HttpClient
  ) { }

  getTrancasctionForUserId(userId: string): Observable<TransactionsListModel> {
    return this.http.get<TransactionsListModel>(`${environment.apiUrl}Transactions/${userId}`)
      .pipe(
        catchError((error: HttpErrorResponse) => {
          return throwError(error);
        })
      );
  }

  getBlocs(): Observable<BlocsModel> {
    return this.http.get<BlocsModel>(`${environment.apiUrl}Transactions/blocs`)
      .pipe(
        catchError((error: HttpErrorResponse) => {
          return throwError(error);
        })
      );
  };

  deleteTranscation(id: number) {
    return this.http.delete(`${environment.apiUrl}Transactions/${id}`).pipe(
      catchError((error: HttpErrorResponse) => {
        return throwError(error);
      })
    );
  }
}

