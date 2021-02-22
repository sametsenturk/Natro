import { BaseEntity } from "./baseEntity";
import { UserEntity } from "./userEntity";

export class UserFavoriteEntity extends BaseEntity {
    domain: string;
    isAvailableToBuy: boolean;
    expireDate: Date;
    lastChange: Date;
    nameserver1: string;
    nameserver2: string;
    userID: number;
    user: UserEntity;
}