import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  type:string="password";
  isText:boolean=false;
  eyeIcon:string="fa-eye-slash"
  loginForm!:FormGroup;
  constructor(private fb:FormBuilder) { }

  ngOnInit() {
    this.loginForm= this.fb.group({
      userName:['',Validators.required],
      password:['',Validators.required]
    })
  }
  hideShowPass(){
    this.isText=!this.isText;
    this.isText?this.eyeIcon="fa-eye":this.eyeIcon="fa-eye-slash";
    this.isText?this.type="text":this.type="password";
  }
  onSubmit(){
    if(this.loginForm.valid){
      console.log(this.loginForm.value);
    }
    else{
      this.validateAllFormFields(this.loginForm)
      alert("Your Form Is Invalid")
    }
  }

  private validateAllFormFields(formGroup:FormGroup){
    Object.keys(formGroup).forEach(f=>{
      const control = formGroup.get(f)
      if(control instanceof FormControl){
        control?.markAsDirty({onlySelf:true})
      }
      else if(control instanceof FormGroup){
        this.validateAllFormFields(control)
      }
    })

  }

}
