import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Leave } from '../Models/Leave';

@Injectable({
  providedIn: 'root'
})
export class LeaveService {
  constructor(private httpclient: HttpClient) { }
  baseurl = "https://localhost:44304/api/Leave";
  GetProduct(): Observable<Leave[]> {
    return this.httpclient.get<Leave[]>(this.baseurl)
  }
  CreateProduct(lea: Leave): Observable<Leave> {
    lea.serialno="0";
    return this.httpclient.post<Leave>(this.baseurl, lea)
  }
  UpdateProduct(lea: Leave):Observable<Leave> {
   return this.httpclient.put<Leave>(this.baseurl + '/' + lea.serialno, lea);

  }
  DeleteProduct(serialno: string):Observable<Leave> {
    return this.httpclient.delete<Leave>(this.baseurl + '/' + serialno);
 
   }
}
