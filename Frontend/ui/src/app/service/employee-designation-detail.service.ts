import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EmployeeDesignationDetail } from '../Models/EmployeeDesignationDetail';

@Injectable({
  providedIn: 'root'
})
export class EmployeeDesignationDetailService {
  constructor(private httpclient: HttpClient) { }
  baseurl = "https://localhost:44304/api/EmployeeDesignationDetail";
  GetEmployeeDesignation(): Observable<EmployeeDesignationDetail[]> {
    return this.httpclient.get<EmployeeDesignationDetail[]>(this.baseurl)
  }
  CreateEmployeeDesignation(emp: EmployeeDesignationDetail): Observable<EmployeeDesignationDetail> {
    emp.serialno="0";
    return this.httpclient.post<EmployeeDesignationDetail>(this.baseurl, emp)
  }
  UpdateEmployeeDesignation(emp: EmployeeDesignationDetail):Observable<EmployeeDesignationDetail> {
   return this.httpclient.put<EmployeeDesignationDetail>(this.baseurl + '/' + emp.serialno, emp);

  }
  DeleteEmployeeDesignation(serialno: string):Observable<EmployeeDesignationDetail> {
    return this.httpclient.delete<EmployeeDesignationDetail>(this.baseurl + '/' + serialno);
 
   }
}
