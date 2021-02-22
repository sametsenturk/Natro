import { BaseRequest } from "../../baseRequest";

export class AddFavoriteRequest extends BaseRequest {
    domain: string;
    isAvailableToBuy: boolean;
    nameserver1: string;
    nameserver2: string;
    lastChange: Date;
    expireDate: Date;
}