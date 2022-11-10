import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SecurityService } from '../security.service';
import { userCredentials } from '../security.models';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private securityService:SecurityService,private router:Router) { }

  ngOnInit(): void {
  }
  register(userCredentials:userCredentials){
    this.securityService.register(userCredentials).subscribe(authenticationResponse =>{
      this.securityService.saveToken(authenticationResponse);
      this.router.navigate(['/']);
    });

  }

}