import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { WorkingHour } from '../Models/WorkingHour';

@Injectable({
  providedIn: 'root'
})
export class WorkingHourService {
  constructor(private httpclient: HttpClient) { }
  baseurl = "https://localhost:44304/api/WorkingHour";
  GetWorkinghour(): Observable<WorkingHour[]> {
    return this.httpclient.get<WorkingHour[]>(this.baseurl)
  }
  CreateWorkinghour(wor: WorkingHour): Observable<WorkingHour> {
    wor.serialno="0";
    return this.httpclient.post<WorkingHour>(this.baseurl, wor)
  }
  UpdateWorkinghour(wor: WorkingHour):Observable<WorkingHour> {
   return this.httpclient.put<WorkingHour>(this.baseurl + '/' + wor.serialno, wor);

  }
  DeleteWorkinghour(serialno: string):Observable<WorkingHour> {
    return this.httpclient.delete<WorkingHour>(this.baseurl + '/' + serialno);
 
   }
}
