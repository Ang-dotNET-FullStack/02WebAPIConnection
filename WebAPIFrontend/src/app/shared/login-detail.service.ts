import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginDetail } from './login-detail.model';

@Injectable({
  providedIn: 'root'
})
export class LoginDetailService {

  constructor(private httpClient : HttpClient) { }

  formData: LoginDetail= new LoginDetail();
  readonly baseUrl = '';
}
