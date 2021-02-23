import { BaseEntity } from "./baseEntity";
import { UserFavoriteEntity } from "./userFavoriteEntity";

export class UserFavoriteNotificationEntity extends BaseEntity {
    userFavorite: UserFavoriteEntity;
}