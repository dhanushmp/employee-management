import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { WorkingHour } from '../Models/WorkingHour';
import { WorkingHourService } from '../service/working-hour.service';

@Component({
  selector: 'app-working-hour',
  templateUrl: './working-hour.component.html',
  styleUrls: ['./working-hour.component.css']
})
export class WorkingHourComponent implements OnInit {

  WorkingHourary: WorkingHour[] = [];
  WorkingHourformgroup: FormGroup;
 
  constructor(private workservice: WorkingHourService ,private fb: FormBuilder) { 
    this.WorkingHourformgroup = this.fb.group({
      serialno:[""],
      employeeId: [""],
      comworkingHour: [""],
      empworkingHour: [""]
     
  
    })
  }
  
  ngOnInit(): void {
    this.gethours();
  }
 
  gethours(){
   this.workservice.GetWorkinghour().subscribe(response => {
     console.log(response);
      this.WorkingHourary = response;
    })
  }
  Onsubmit() {
    console.log(this.WorkingHourformgroup.value);
    if(this.WorkingHourformgroup.value.serialno !=null && this.WorkingHourformgroup.value.serialno !=""){
      this.workservice.UpdateWorkinghour(this.WorkingHourformgroup.value).subscribe(response => {
        console.log(response);
        this.gethours();
        this.WorkingHourformgroup.setValue({
          serialno:"",
          employeeId: "",
          comworkingHour: "",
          empworkingHour: ""
         
  
        })
      })
    }
    else{
      this.workservice.CreateWorkinghour(this.WorkingHourformgroup.value).subscribe(response => {
        console.log(response);
        this.gethours();
        this.WorkingHourformgroup.setValue({
          serialno:"",
          employeeId: "",
          comworkingHour: "",
          empworkingHour: ""
         
  
        })
      })
    }
   
  }
  
   Fillform(emp:WorkingHour){
    this.WorkingHourformgroup.setValue({
      serialno:emp.serialno,
          employeeId: emp.employeeId,
          comworkingHour: emp.comworkingHour,
          empworkingHour: emp.empworkingHour
  
    })
  
   }
   DeleteProd(serialno:string){
    this.workservice.DeleteWorkinghour(serialno).subscribe(res => {
      console.log(res);
      this.gethours();
    })
   }


}
