import { Component, OnInit, } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../sevices/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit
{
  repeatPass:string='none';
  displayMsg: string='';isAccountCreated:boolean =false;
  constructor(private authService:AuthService){}
  ngOnInit(): void {
    
  }
   selectedTeam = '';
	onSelected(value:string): void {
	 	this.selectedTeam = value;
   }
   
 
  registerForm=new FormGroup({
    // empid:new FormControl("",[Validators.required]),
    firstname:new FormControl("",[Validators.required,Validators.minLength(2),
       Validators.pattern("[a-zA-z].*")]),
        lastname:new FormControl("",[Validators.required,Validators.minLength(2),
          Validators.pattern("[a-zA-z].*")]),
          email:new FormControl("",[Validators.required,Validators.email]),
          role:new FormControl(""),
         pwd:new FormControl("",[Validators.required,Validators.minLength(6),Validators.maxLength(12)]),
         cpwd:new FormControl(""),
      
       
  });

registerSubmitted(){
  if(this.PWD.value==this.CPWD.value){
    console.log("this.registerForm.valid");
    this.repeatPass='none'
    console.log(this.registerForm.value);
    this.authService.registerUser(this.registerForm.value).subscribe(res=>

      {
         if (res =='User Created')
         {
           this.displayMsg='Account Created Successfully!';
            this.isAccountCreated=true;
          }
          else if (res == 'Already Exist')
          {
            this.displayMsg='Account Already Exist.Try another Email.';
            this.isAccountCreated==false;
          }
          else{
             //this.displayMsg='Something went Wrong.';
             this.isAccountCreated=false;
             }
             
            




    });
  }else
  {
    this.repeatPass='inline'
  }
  //console.log(this.registerForm.value);
}
// get Empid():FormControl
// {
//   return this.registerForm.get("empid") as FormControl;
// }
get FirstName():FormControl
{
  return this.registerForm.get("firstname") as FormControl;
}
get LastName():FormControl
{
  return this.registerForm.get("lastname") as FormControl;
}
get Email():FormControl
{
  return this.registerForm.get("email") as FormControl;
}
get Role():FormControl{
  return this.registerForm.get("role") as FormControl;
}

get PWD():FormControl
{
  return this.registerForm.get("pwd") as FormControl;
}
get CPWD():FormControl{
  return this.registerForm.get("cpwd") as FormControl;
}

}