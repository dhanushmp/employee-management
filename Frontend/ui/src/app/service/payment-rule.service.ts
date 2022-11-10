import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PaymentRule } from '../Models/PaymentRule';

@Injectable({
  providedIn: 'root'
})
export class PaymentRuleService {
  constructor(private httpclient: HttpClient) { }
  baseurl = "https://localhost:44304/api/PaymentRule";
  GetPaymentRule(): Observable<PaymentRule[]> {
    return this.httpclient.get<PaymentRule[]>(this.baseurl)
  }
  CreatePaymentRule(pay: PaymentRule): Observable<PaymentRule> {
    pay.serialno="0";
    return this.httpclient.post<PaymentRule>(this.baseurl, pay)
  }
  UpdatePaymentRule(pay: PaymentRule):Observable<PaymentRule> {
   return this.httpclient.put<PaymentRule>(this.baseurl + '/' + pay.serialno, pay);

  }
  DeletePaymentRule(serialno: string):Observable<PaymentRule> {
    return this.httpclient.delete<PaymentRule>(this.baseurl + '/' + serialno);
 
   }
}
