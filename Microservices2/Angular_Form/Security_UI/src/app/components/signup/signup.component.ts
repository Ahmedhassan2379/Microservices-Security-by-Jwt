import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  
  type:string="password";
  isText:boolean=false;
  eyeIcon:string="fa-eye-slash"
  signupForm!:FormGroup
  constructor(private fb:FormBuilder) { }

  ngOnInit() {
    this.signupForm = this.fb.group({
      firstName:['',Validators.required],
      lastName:['',Validators.required],
      email:['',Validators.required],
      password:['',Validators.required],
    })
  }

  hideShowPass(){
    this.isText=!this.isText;
    this.isText?this.eyeIcon="fa-eye":this.eyeIcon="fa-eye-slash";
    this.isText?this.type="text":this.type="password";
  }

  onSubmit(){
    if(this.signupForm.valid){
      console.log(this.signupForm.value);
    }
    else{
      this.validateAllFormFields(this.signupForm)
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
