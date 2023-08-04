import { Component, OnInit } from '@angular/core';
import {FormControl ,FormGroup,ValidationErrors,Validator, Validators } from '@angular/forms';
import { newUser } from 'src/app/Models/newuser';
import { CommunicationFromServer } from 'src/app/Services/ClientService';
@Component({
  selector: 'app-new-user',
  templateUrl: './new-user.component.html',
  styleUrls: ['./new-user.component.css']
})
export class NewUserComponent implements OnInit { 

constructor(private com:CommunicationFromServer){}
  NewUserRegistration:any;

  ngOnInit() {

    this.NewUserRegistration = new FormGroup ({
      name : new FormControl('',[Validators.required]),
      email: new FormControl('',[Validators.required]),
      password: new FormControl('',[Validators.required])
    });

  
  }
  submitForm(){
    const newUser : newUser ={
      Name: this.name.value,
      Email: this.email.value,
      Password: this.password.value
    }

    this.com.NewUser(newUser).subscribe(data=>{
      console.log(data);
      
    })

  }
  get name(){
    return this.NewUserRegistration.get('name');
  }

  get email(){
    return this.NewUserRegistration.get('email') ;
  }

  get password() {
    return this.NewUserRegistration.get('password')
  }
}
