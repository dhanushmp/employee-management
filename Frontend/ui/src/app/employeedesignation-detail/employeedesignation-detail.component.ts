import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { EmployeeDesignationDetail } from '../Models/EmployeeDesignationDetail';
import { EmployeeDesignationDetailService } from '../service/employee-designation-detail.service';

@Component({
  selector: 'app-employeedesignation-detail',
  templateUrl: './employeedesignation-detail.component.html',
  styleUrls: ['./employeedesignation-detail.component.css']
})
export class EmployeedesignationDetailComponent implements OnInit {

  EmployeeDesignationDetailary: EmployeeDesignationDetail[] = [];
  EmployeeDesignationDetailformgroup: FormGroup;
 
  constructor(private empdetailservice: EmployeeDesignationDetailService ,private fb: FormBuilder) { 
    this.EmployeeDesignationDetailformgroup = this.fb.group({
      serialno:[""],
      employeeId:[" "],
      designationName:[""],
      roleName:[""],
      departmentname:[""]
     
  
    })
  }
  
  ngOnInit(): void {
    this.getemployeeDesignations();
   
  }
  
  getemployeeDesignations(){
   this.empdetailservice.GetEmployeeDesignation().subscribe(response => {
     console.log(response);
      this.EmployeeDesignationDetailary = response;
    })
  }
  Onsubmit() {
    console.log(this.EmployeeDesignationDetailformgroup.value);
    if(this.EmployeeDesignationDetailformgroup.value.serialno !=null && this.EmployeeDesignationDetailformgroup.value.serialno !=""){
      this.empdetailservice.UpdateEmployeeDesignation(this.EmployeeDesignationDetailformgroup.value).subscribe(response => {
        console.log(response);
        this.getemployeeDesignations();
        this.EmployeeDesignationDetailformgroup.setValue({
          serialno:"",
    employeeId:"",
    designationName:"",
    roleName:"",
    departmentname:""
  
        })
      })
    }
    else{
      this.empdetailservice.CreateEmployeeDesignation(this.EmployeeDesignationDetailformgroup.value).subscribe(response => {
        console.log(response);
        this.getemployeeDesignations();
        this.EmployeeDesignationDetailformgroup.setValue({
          serialno:"",
          employeeId:"",
          designationName:"",
          roleName:"",
          departmentname:""
         
  
        })
      })
    }
   
  }
  
   Fillform(emp:EmployeeDesignationDetail){
    this.EmployeeDesignationDetailformgroup.setValue({
      serialno:emp.serialno,
    employeeId:emp.employeeId,
    designationName:emp.designationName,
    roleName:emp.roleName,
    departmentname:emp.departmentname
  
    })
  
   }
   DeleteDesig(serialno:string){
    this.empdetailservice.DeleteEmployeeDesignation(serialno).subscribe(res => {
      console.log(res);
      this.getemployeeDesignations();
    })
   }
}
