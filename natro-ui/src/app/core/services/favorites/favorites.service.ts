import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AddFavoriteRequest } from '../../models/favorite/request/addFavoriteRequest';
import { AddFavoriteResponse } from '../../models/favorite/response/addFavoriteResponse';
import { DeleteFavoriteResponse } from '../../models/favorite/response/deleteFavoriteResponse';
import { GetFavoritesResponse } from '../../models/favorite/response/getFavoritesResponse';
import { BaseService } from '../base.service';

@Injectable({
  providedIn: 'root'
})
export class FavoritesService {

  constructor(
    private httpClient: HttpClient,
    private baseService: BaseService
  ) { }

  
  private API_URL = environment.API_URL;
  private Controller = "favorite";

  addFavorite(request: AddFavoriteRequest): Observable<AddFavoriteResponse> {
    return this.httpClient.put<AddFavoriteResponse>(
      `${this.API_URL}/${this.Controller}/put`, request, { headers: this.baseService.getHeaders() }
    );
  }

  getList() : Observable<GetFavoritesResponse> {
    return this.httpClient.get<GetFavoritesResponse>(
      `${this.API_URL}/${this.Controller}/getlist`, { headers: this.baseService.getHeaders() }
    );
  }

  deleteFavorite(id: number): Observable<DeleteFavoriteResponse> {
    return this.httpClient.delete<DeleteFavoriteResponse>(
      `${this.API_URL}/${this.Controller}/delete/${id}`, { headers: this.baseService.getHeaders() }
    );
  }

}
