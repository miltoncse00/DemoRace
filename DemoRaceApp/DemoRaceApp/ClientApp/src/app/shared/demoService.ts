import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { RaceSummary } from './raceSummary.model';

@Injectable()
export class DemoService {
  myAppUrl: string = "";

  constructor(private _http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
  }

  RaceSummary(): Observable<RaceSummary[]> {

    return this._http.get <RaceSummary[]>(this.myAppUrl + "api/DemoRace/RaceSummary");

  }
}
