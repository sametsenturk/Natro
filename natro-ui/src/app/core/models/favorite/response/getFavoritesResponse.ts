import { BaseResponse } from "../../baseResponse";
import { UserFavoriteEntity } from "../../entities/userFavoriteEntity";

export class GetFavoritesResponse extends BaseResponse {
    favorites: UserFavoriteEntity[];
}