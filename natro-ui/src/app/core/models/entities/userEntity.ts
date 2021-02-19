import { BaseEntity } from "./baseEntity";
import { UserFavoriteEntity } from "./userFavoriteEntity";

export class UserEntity extends BaseEntity {
   username: string;
   password: string;
   email: string;
   favorites: UserFavoriteEntity[];
}