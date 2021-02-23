import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { GetUserFavoriteNotificationsResponse } from '../../models/notification/response/getUserFavoriteNotificationsResponse';
import { BaseService } from '../base.service';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor(
    private httpService: HttpClient,
    private baseService: BaseService
  ) { }

  private API_URL = environment.API_URL;
  private Controller = "notification";

  getNotifications() : Observable<GetUserFavoriteNotificationsResponse> {
    return this.httpService.get<GetUserFavoriteNotificationsResponse>(
      `${this.API_URL}/${this.Controller}/getUserFavoriteNotifications`, { headers: this.baseService.getHeaders() }
    );
  }

}
