import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BehaviorSubject } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class AuthService {

  currentuser:BehaviorSubject<any>= new BehaviorSubject("Null");
  
  baseServerUrl="https://localhost:44385/api/";
  jwtHelperService=new JwtHelperService();

  constructor(private http: HttpClient) {  }

  registerUser(reg : any)
  {
    return this.http.post(this.baseServerUrl+"Register/CreateUser",reg,
    {responseType: 'text'});
    
}
ginUser(reg : any)
{
  return this.http.post(this.baseServerUrl+"Register/LoginUser",reg,
  {responseType: 'text'});
  
}
setToken(token:string)
{
  localStorage.setItem("access_token",token);
  this.loadCurrentUser();
}
loadCurrentUser(){
  const Token=localStorage.getItem("access_token");
  const userInfo=Token!=null?this.jwtHelperService.decodeToken(Token):null;
  console.log(userInfo);
}
}
