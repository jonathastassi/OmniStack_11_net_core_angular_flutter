import { environment } from './../../environments/environment';
import { Ong } from './../models/ong';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class OngsService {

  readonly urlBase = environment.urlBaseApi + 'ongs';

  constructor(
    private http: HttpClient
  ) { }

  Post(model: Ong): Observable<any> {
    return this.http.post(this.urlBase, model);
  }
}
