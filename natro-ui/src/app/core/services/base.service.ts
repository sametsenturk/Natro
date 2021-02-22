import { HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BaseService {

  constructor() { }

  private token = localStorage.getItem("token");

  getHeaders(): HttpHeaders {
    let headers = new HttpHeaders();
    headers = headers.append("Content-Type", "application/json");
    if (this.token !== null && this.token !== undefined && this.token.length > 0) {
      headers = headers.append("Authorization", "Bearer " + this.token);
    }
    return headers;
  }

}
