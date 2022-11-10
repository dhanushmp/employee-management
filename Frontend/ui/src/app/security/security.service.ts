import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { authenticationResponse ,userCredentials} from './security.models';

@Injectable({
  providedIn: 'root'
})
export class SecurityService {

  constructor(private http:HttpClient) { }

  baseurl = "https://localhost:44304/api/accounts/create";
  loginurl="https://localhost:44304/api/accounts/login";
  private tokenkey:string ='token';
  private expirationTokenKey:string ='token-expiration'

  isAuthenticated():boolean{
    const token = localStorage.getItem(this.tokenkey);
    if(!token){
      return false;
    }
    const expiration:any =localStorage.getItem(this.expirationTokenKey);
    const expirationDate = new Date(expiration);

    if(expirationDate <= new Date()){
      this.logout();
      return false;
    }
    return true;
  }
  getFieldFromJWT(field:string):string{
    const token =localStorage.getItem(this.tokenkey);
    if(!token){return ''; }
    const dataToken =JSON.parse(token.split('.')[1]);
    return dataToken[field];
  }
  logout(){
    localStorage.removeItem(this.tokenkey);
    localStorage.removeItem(this.expirationTokenKey);
  }
  getRole():string{
    return 'admin';
  }
  register(userCredentials:userCredentials):Observable<authenticationResponse>{
    return this.http.post<authenticationResponse>(this.baseurl,userCredentials)

  }
  login(userCredentials:userCredentials):Observable<authenticationResponse>{
    return this.http.post<authenticationResponse>(this.loginurl,userCredentials)

  }
  saveToken(authenticationResponse:authenticationResponse){
    localStorage.setItem(this.tokenkey,authenticationResponse.token);
    localStorage.setItem(this.expirationTokenKey,authenticationResponse.expiration.toString());

  }
}