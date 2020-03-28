import { Incident } from './../models/incident';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class IncidentsService {

  readonly urlBase = environment.urlBaseApi + 'incidents';

  constructor(
    private http: HttpClient
  ) { }

  Post(model: Incident): Observable<any> {
    return this.http.post(this.urlBase, model);
  }

  Delete(id: number): Observable<any> {
    return this.http.delete(`${this.urlBase}/${id}`);
  }
}
