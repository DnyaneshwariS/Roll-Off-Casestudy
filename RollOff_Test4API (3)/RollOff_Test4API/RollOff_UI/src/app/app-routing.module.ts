import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeesComponent } from './employees/employees.component';
import { ViewEmployeeComponent } from './employees/view-employee/view-employee.component';
import { FeedbackformComponent } from './feedbackform/feedbackform.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { TempComponent } from './temp/temp.component';

const routes: Routes = [
  {
    path:'',
    component:LoginComponent
  },
  {
    path:'app-employees',
    component:EmployeesComponent
  },
  {
    path:'app-temp',
    component:TempComponent
  },
  {
    path:'app-employees/:id',
    component:ViewEmployeeComponent
  },
  {
    path:'app-feedbackform/:id',
    component:FeedbackformComponent
  },
  {
    path:'app-view-employee',
    component:ViewEmployeeComponent
  },
  {
    path:'app-login',
    component:LoginComponent
  },
  {
    path:'app-register',
    component:RegisterComponent
  },
  {
    path:'app-feedbackform',
    component:FeedbackformComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
