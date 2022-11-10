import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { EmployeeDetail } from '../Models/EmployeeDetail';
import { EmployeeDetailService } from '../service/employee-detail.service';

@Component({
  selector: 'app-employee-detail',
  templateUrl: './employee-detail.component.html',
  styleUrls: ['./employee-detail.component.css']
})
export class EmployeeDetailComponent implements OnInit {

  EmployeeDetailary: EmployeeDetail[] = [];
  Employeeformgroup: FormGroup;
 
  constructor(private empdetailservice: EmployeeDetailService ,private fb: FormBuilder) { 
    this.Employeeformgroup = this.fb.group({
      serialno:[""],
      employeeId: [""],
      employeeName: [""],
      phoneno: [""],
      mailId:[""],
      address:[""]
     
  
    })
  }
  
  ngOnInit(): void {
    this.getemployees();
  }
  
  getemployees(){
   this.empdetailservice.GetEmployee().subscribe(response => {
     console.log(response);
      this.EmployeeDetailary = response;
    })
  }
  Onsubmit() {
    console.log(this.Employeeformgroup.value);
    if(this.Employeeformgroup.value.serialno !=null && this.Employeeformgroup.value.serialno !=""){
      this.empdetailservice.UpdateEmployee(this.Employeeformgroup.value).subscribe(response => {
        console.log(response);
        this.getemployees();
        this.Employeeformgroup.setValue({
          serialno:"",
          employeeId: "",
          employeeName: "",
          phoneno: "",
          mailId:"",
          address:""
         
  
        })
      })
    }
    else{
      this.empdetailservice.CreateEmployee(this.Employeeformgroup.value).subscribe(response => {
        console.log(response);
        this.getemployees();
        this.Employeeformgroup.setValue({
          serialno:"",
          employeeId: "",
          employeeName: "",
          phoneno: "",
          mailId:"",
          address:""
         
  
        })
      })
    }
   
  }
  
   Fillform(emp:EmployeeDetail){
    this.Employeeformgroup.setValue({
          serialno:emp.serialno,
          employeeId: emp.employeeId,
          employeeName: emp.employeeName,
          phoneno: emp.phoneno,
          mailId:emp.mailId,
          address:emp.address
  
    })
  
   }
   DeleteEmp(serialno:string){
    this.empdetailservice.DeleteEmployee(serialno).subscribe(res => {
      console.log(res);
      this.getemployees();
    })
   }

}
