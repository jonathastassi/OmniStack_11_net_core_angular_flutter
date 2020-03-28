import { tap } from 'rxjs/operators';
import { Ong } from './../models/ong';
import { Session } from './../models/session';
import { environment } from './../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class SessionsService {

  readonly urlBase = environment.urlBaseApi + 'session';

  constructor(
    private http: HttpClient,
    private router: Router
  ) { }

  Login(model: Session): Observable<any> {
    return this.http.post(this.urlBase, model)
      .pipe(
        tap((ong: Ong) => {
          if (ong) {
            localStorage.setItem('hero:ongId', ong.id);
            localStorage.setItem('hero:ongName', ong.name);
          }
        })
      );
  }

  Logout(): void {
    localStorage.removeItem('hero:ongId');
    localStorage.removeItem('hero:ongName');
    this.router.navigateByUrl('/');
  }

  getName(): string {
    const name = localStorage.getItem('hero:ongName');

    return name;
  }

  isAuthenticated(): boolean {
    return localStorage.getItem('hero:ongId') ? true : false;
  }
}
