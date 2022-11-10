import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeDetailComponent } from './employee-detail/employee-detail.component';
import { EmployeedesignationDetailComponent } from './employeedesignation-detail/employeedesignation-detail.component';
import { HomeComponent } from './home/home.component';
import { IsAdminGuard } from './is-admin.guard';
import { LeaveComponent } from './leave/leave.component';
import { NavbarComponent } from './navbar/navbar.component';
import { PaymentruleComponent } from './paymentrule/paymentrule.component';
import { LoginComponent } from './security/login/login.component';
import { RegisterComponent } from './security/register/register.component';
import { WorkingHourComponent } from './working-hour/working-hour.component';

const routes: Routes = [
  {path:'navbar',component:NavbarComponent},
  {path:'',component:HomeComponent},
  {path:'login',component:LoginComponent},
  {path:'register',component:RegisterComponent},
  {path:'employeeDetail',component:EmployeeDetailComponent,canActivate:[IsAdminGuard]},
  {path:'employeeDesignationDetail',component:EmployeedesignationDetailComponent,canActivate:[IsAdminGuard]},
  {path:'leave',component:LeaveComponent,canActivate:[IsAdminGuard]},
  {path:'paymentRule',component:PaymentruleComponent,canActivate:[IsAdminGuard]},
  {path:'workingHour',component:WorkingHourComponent,canActivate:[IsAdminGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
