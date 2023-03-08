import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { AuthService } from '../sevices/auth.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {


  constructor(private loginauth:AuthService,private router:Router){}
  ngOnInit(): void {
    
  }

  loginForm=new FormGroup({
    email:new FormControl("",[Validators.required, Validators.email]),
    pwd:new FormControl("",[
      Validators.required,
      Validators.minLength(6),
      Validators.maxLength(15),
    ]),
  });
  isUserValid:boolean =false;
loginSubmitted()
{
  try{
  console.log(this.loginForm.value);
  this.loginauth.ginUser(this.loginForm.value).subscribe(res=>{ 
    if(res=='Failure')
    {
      this.isUserValid=false;
      alert("Login Unsuccesfull");
    }
    else{
      this.isUserValid=true;
this.loginauth.setToken(res);
this.router.navigateByUrl("app-employees");
    }
  
 
  });
}
  catch(Exception )
  {
    alert("Something went wrong");
  }
  
}

  get Email():FormControl{
    return this.loginForm.get('email') as FormControl;

  }
  get PWD():FormControl{
    return this.loginForm.get('pwd') as FormControl;
    
  }
}
