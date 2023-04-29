import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginDetail } from './login-detail.model';

@Injectable({
  providedIn: 'root'
})
export class LoginDetailService {

  constructor(private http : HttpClient) { }

  formData: LoginDetail= new LoginDetail();
  readonly baseUrl = 'https://localhost:44333/api/Logins';

  postLogin(){
    return this.http.post(this.baseUrl, this.formData);
  }

  getLogins(){
    return this.http.get(this.baseUrl);
  }

  updateLogin(id:number){
    return this.http.put(this.baseUrl+'/'+id, this.formData);
  }

  deleteLogin(id:number){
    return this.http.delete(this.baseUrl+'/'+id);
  }

}
