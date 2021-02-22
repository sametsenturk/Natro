import { BaseResponse } from "../../baseResponse";

export class CheckDomainResponse extends BaseResponse {
    domain: string;
    isAvailableToBuy: boolean;
    ownerName: string;
    ownerAdress: string;
    ownerPhoneNumber: string;
}