import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SafeAuto } from '../models/safeAuto.model';
import { InformationSafeAuto } from '../models/informationSafeAuto.model';

@Injectable({
  providedIn: 'root'
})
export class SafeAutoService {

  path: string = "https://localhost:44365/api/SafeAuto";

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      Authorization: 'my-auth-token'
    })
  };

  constructor(
    private _http: HttpClient,
  ) {
   
   }

  public newDriver(SafeAuto: SafeAuto): Observable<any>{
console.log("newDriver");
return this._http.post<any>(this.path + '/newDriver', JSON.stringify(SafeAuto), this.httpOptions);
  }
  
  public generateReporting(SafeAutoInformation: InformationSafeAuto): Observable<any>{
    console.log("generateReporting");
    return this._http.post<any>(this.path + "/addInformation", JSON.stringify(SafeAutoInformation), this.httpOptions);
  }

  public getAllInformation(): Observable<any>{
    console.log("getAllInformationSafeAutos");
    return this._http.get(this.path + "/getAllInformationSafeAutos");
  }

}
