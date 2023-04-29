import { Component, OnInit } from '@angular/core';
import { LoginDetailService } from '../shared/login-detail.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {

  public Logins:any;
  constructor(public service : LoginDetailService) { }

  ngOnInit(): void {
    this.getAllLogins();
  }

  getAllLogins(){
    this.service.getLogins().subscribe(values =>{
      this.Logins = values;
    });
  }

  onSubmit(form: NgForm){
    this.service.postLogin().subscribe(
      (res) => {
        console.log("Submitted successfully to database");
        this.getAllLogins();
      },
      err=>{
        console.log(err);
      }
    );    
  }

  deleteLogin(id: number){
    this.service.deleteLogin(id).subscribe(
      (res) => {
        console.log("Deleted Successfully!");
        this.getAllLogins();
      },
      (err) => {
        console.log(err);
      }
    )
  }

}
