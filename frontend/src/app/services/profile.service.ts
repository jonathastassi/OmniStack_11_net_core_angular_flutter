import { Incident } from './../models/incident';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  readonly urlBase = environment.urlBaseApi + 'profile';

  constructor(
    private http: HttpClient
  ) { }

  Get(): Observable<Incident[]> {
    return this.http.get<Incident[]>(this.urlBase);
  }
}
