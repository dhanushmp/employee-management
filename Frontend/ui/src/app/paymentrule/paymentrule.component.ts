import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PaymentRule } from '../Models/PaymentRule';
import { PaymentRuleService } from '../service/payment-rule.service';

@Component({
  selector: 'app-paymentrule',
  templateUrl: './paymentrule.component.html',
  styleUrls: ['./paymentrule.component.css']
})
export class PaymentruleComponent implements OnInit {

  Paymentruleary: PaymentRule[] = [];
  PaymentRuleformgroup: FormGroup;
 
  constructor(private payservice: PaymentRuleService ,private fb: FormBuilder) { 
    this.PaymentRuleformgroup = this.fb.group({
      serialno:[""],
      rule: [""]
     
     
  
    })
  }
  
  ngOnInit(): void {
    this.getpaymentrules();
  }
  
  getpaymentrules(){
   this.payservice.GetPaymentRule().subscribe(response => {
     console.log(response);
      this.Paymentruleary = response;
    })
  }
  Onsubmit() {
    console.log(this.PaymentRuleformgroup.value);
    if(this.PaymentRuleformgroup.value.serialno !=null && this.PaymentRuleformgroup.value.serialno !=""){
      this.payservice.UpdatePaymentRule(this.PaymentRuleformgroup.value).subscribe(response => {
        console.log(response);
        this.getpaymentrules();
        this.PaymentRuleformgroup.setValue({
          serialno:"",
          rule: ""
          
         
  
        })
      })
    }
    else{
      this.payservice.CreatePaymentRule(this.PaymentRuleformgroup.value).subscribe(response => {
        console.log(response);
        this.getpaymentrules();
        this.PaymentRuleformgroup.setValue({
          serialno:"",
          rule: ""
         
         
  
        })
      })
    }
   
  }
  
   Fillform(pay:PaymentRule){
    this.PaymentRuleformgroup.setValue({
      serialno:pay.serialno,
      rule: pay.rule
        
    })
  
   }
   DeletePay(serialno:string){
    this.payservice.DeletePaymentRule(serialno).subscribe(res => {
      console.log(res);
      this.getpaymentrules();
    })
   }

}
