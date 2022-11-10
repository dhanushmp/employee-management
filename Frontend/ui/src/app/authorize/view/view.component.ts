import { Component, Input, OnInit } from '@angular/core';
import { SecurityService } from 'src/app/security/security.service';

@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent implements OnInit {

  constructor(private securityService:SecurityService) { }

  ngOnInit(): void {
  }


  @Input()
  role: string;

  public isAuthorized(){
    if(this.role){
      return this.securityService.getRole() === this.role;

    }else{
    return this.securityService.isAuthenticated();
  }
}

}