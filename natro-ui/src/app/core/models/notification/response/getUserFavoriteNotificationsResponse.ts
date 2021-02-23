import { BaseResponse } from "../../baseResponse";
import { UserFavoriteNotificationEntity } from "../../entities/userFavoriteNotificationEntity";

export class GetUserFavoriteNotificationsResponse extends BaseResponse {
    userFavoriteNotifications: UserFavoriteNotificationEntity[];
}