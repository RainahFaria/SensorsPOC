import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
// tslint:disable-next-line: import-blacklist
import { Observable } from 'rxjs';
import { Sensor } from '../models/sensor.model';

@Injectable({
  providedIn: 'root'
})
export class SensorsService {

  constructor(private httpClient: HttpClient) { }

  private getOptions(myParams?: HttpParams) {
    const httpClientDefaultHeader: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });
    const myOptions = { headers: httpClientDefaultHeader, params: myParams };
    return myOptions;
  }

  getAllSensors(): Observable<object> {
    return this.httpClient.get(`https://localhost:44354/api/Sensors`, this.getOptions());
  }

  addSensor(sensor: Sensor): Observable<object> {
    return this.httpClient.post(`https://localhost:44354/api/Sensors`, JSON.stringify(sensor), this.getOptions());
  }

}



