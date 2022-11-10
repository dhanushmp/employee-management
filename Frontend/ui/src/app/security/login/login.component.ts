import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SecurityService } from '../security.service';
import { userCredentials } from '../security.models';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private securityService:SecurityService,private router:Router) { }

  ngOnInit(): void {
  }
  login(userCredentials:userCredentials)
  {
    this.securityService.login(userCredentials).subscribe(authenticationResponse =>{
      this.securityService.saveToken(authenticationResponse);
      this.router.navigate(['/']);
    });
  }

}
