import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { UserBaseModels } from '../views/users/users.component';

export interface CreateUserModel {
  firstName: string;
  lastName: string;
}

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(
    private http: HttpClient
  ) { }

  getListOfUsers(): Observable<UserBaseModels[]> {
    return this.http.get<UserBaseModels[]>(`${environment.apiUrl}Users`)
      .pipe(
        catchError((error: HttpErrorResponse) => {
          return throwError(error);
        })
      );
  }

  create(body: CreateUserModel) {
    return this.http.post(`${environment.apiUrl}Users`, body)
      .pipe(
        catchError((error: HttpErrorResponse) => {
          return throwError(error);
        })
      )
  }
}
