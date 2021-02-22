import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CheckDomainResponse } from '../../models/rdap/response/checkDomainResponse';
import { BaseService } from '../base.service';

@Injectable({
  providedIn: 'root'
})
export class RdapService {

  constructor(
    private httpClient: HttpClient,
    private baseService: BaseService
  ) { }

  private API_URL = environment.API_URL;
  private Controller = "rdap";


  checkDomain(domain: string) : Observable<CheckDomainResponse> {
    return this.httpClient.get<CheckDomainResponse>(
      `${this.API_URL}/${this.Controller}/checkdomain/${domain}`, { headers: this.baseService.getHeaders() }
    );
  }

}
