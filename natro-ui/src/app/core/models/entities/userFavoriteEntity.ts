import { BaseEntity } from "./baseEntity";
import { UserEntity } from "./userEntity";

export class UserFavoriteEntity extends BaseEntity {
    domain: string;
    isAvailableToBuy: boolean;
    userID: number;
    user: UserEntity;
}