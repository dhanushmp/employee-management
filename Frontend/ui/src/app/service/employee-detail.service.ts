import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EmployeeDetail } from '../Models/EmployeeDetail';

@Injectable({
  providedIn: 'root'
})
export class EmployeeDetailService {
  constructor(private httpclient: HttpClient) { }
  baseurl = "https://localhost:44304/api/EmployeeDetail";
  GetEmployee(): Observable<EmployeeDetail[]> {
    return this.httpclient.get<EmployeeDetail[]>(this.baseurl)
  }
  CreateEmployee(emp: EmployeeDetail): Observable<EmployeeDetail> {
    emp.serialno="0";
    return this.httpclient.post<EmployeeDetail>(this.baseurl, emp)
  }
  UpdateEmployee(emp: EmployeeDetail):Observable<EmployeeDetail> {
   return this.httpclient.put<EmployeeDetail>(this.baseurl + '/' + emp.serialno, emp);

  }
  DeleteEmployee(serialno: string):Observable<EmployeeDetail> {
    return this.httpclient.delete<EmployeeDetail>(this.baseurl + '/' + serialno);
 
   }
}
