import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-top-nav',
  templateUrl: './top-nav.component.html',
  styleUrls: ['./top-nav.component.css']
})
export class TopNavComponent {
  user: any; 
  Isloggedin: boolean = false; 
  constructor() { }

  
   ngOnInit(): void 
   {
  }
  ngDoCheck(){
    this.checkstorage();
  }

     checkstorage()
    {
      this.user =localStorage.getItem('access_token');
      if(this.user!=null){
         this.Isloggedin =true;
        }
      }
         logout() {
          localStorage.clear();
          this.Isloggedin=false;
           console.log(this.Isloggedin);
           }


  }
