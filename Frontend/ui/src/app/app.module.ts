import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HomeComponent } from './home/home.component';
import { ViewComponent } from './authorize/view/view.component';
import { AuthenticationFormComponent } from './security/authentication-form/authentication-form.component';
import { LoginComponent } from './security/login/login.component';
import { RegisterComponent } from './security/register/register.component';
import{HttpClientModule} from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatMenuModule} from '@angular/material/menu';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import { EmployeeDetailComponent } from './employee-detail/employee-detail.component';
import {MatCardModule} from '@angular/material/card';
import { EmployeedesignationDetailComponent } from './employeedesignation-detail/employeedesignation-detail.component';
import { LeaveComponent } from './leave/leave.component';
import { PaymentruleComponent } from './paymentrule/paymentrule.component';
import { WorkingHourComponent } from './working-hour/working-hour.component';
@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    ViewComponent,
    AuthenticationFormComponent,
    LoginComponent,
    RegisterComponent,
    EmployeeDetailComponent,
    EmployeedesignationDetailComponent,
    LeaveComponent,
    PaymentruleComponent,
    WorkingHourComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    MatToolbarModule,
    MatIconModule,
    MatMenuModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    BrowserAnimationsModule,
    MatCardModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
