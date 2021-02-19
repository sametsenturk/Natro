import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { LoginRequest } from '../../models/user/request/loginRequest';
import { LoginResponse } from '../../models/user/response/loginResponse';
import { BaseService } from '../base.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(
    private httpClient: HttpClient,
    private router: Router,
    private baseService: BaseService
  ) { }

  private API_URL = environment.API_URL;
  private Controller = "user";

 

  login(request: LoginRequest) : Observable<LoginResponse> {
     return this.httpClient.post<LoginResponse>(
       `${this.API_URL}/${this.Controller}/login`, request, { headers: this.baseService.getHeaders(), }
     );
  }

  validateToken(): boolean {
    let token = localStorage.getItem("token");
    return token != null && token != undefined && token.length > 0;
  }

}
