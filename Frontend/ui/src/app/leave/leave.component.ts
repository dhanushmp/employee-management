import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Leave } from '../Models/Leave';
import { LeaveService } from '../service/leave.service';

@Component({
  selector: 'app-leave',
  templateUrl: './leave.component.html',
  styleUrls: ['./leave.component.css']
})
export class LeaveComponent implements OnInit {

  Leaveary: Leave[] = [];
  Leaveformgroup: FormGroup;
 
  constructor(private leavedetailservice: LeaveService ,private fb: FormBuilder) { 
    this.Leaveformgroup = this.fb.group({
      serialno:[""],
    employeeId:[""],
    type:[""],
    when:[""],
    leaveReason:[""]
     
  
    })
  }
  
  ngOnInit(): void {
    this.getproducts();
  }
  
  getproducts(){
   this.leavedetailservice.GetProduct().subscribe(response => {
     console.log(response);
      this.Leaveary = response;
    })
  }
  Onsubmit() {
    console.log(this.Leaveformgroup.value);
    if(this.Leaveformgroup.value.serialno !=null && this.Leaveformgroup.value.serialno !=""){
      this.leavedetailservice.UpdateProduct(this.Leaveformgroup.value).subscribe(response => {
        console.log(response);
        this.getproducts();
        this.Leaveformgroup.setValue({
          serialno:"",
          employeeId:"",
          type:"",
          when:"",
          leaveReason:""
  
        })
      })
    }
    else{
      this.leavedetailservice.CreateProduct(this.Leaveformgroup.value).subscribe(response => {
        console.log(response);
        this.getproducts();
        this.Leaveformgroup.setValue({
          serialno:"",
          employeeId:"",
          type:"",
          when:"",
          leaveReason:""
         
  
        })
      })
    }
   
  }
  
   Fillform(lea:Leave){
    this.Leaveformgroup.setValue({
      serialno:lea.serialno,
      employeeId:lea.employeeId,
      type:lea.type,
      when:lea.type,
      leaveReason:lea.leaveReason
  
    })
  
   }
   DeleteProd(serialno:string){
    this.leavedetailservice.DeleteProduct(serialno).subscribe(res => {
      console.log(res);
      this.getproducts();
    })
   }

}
