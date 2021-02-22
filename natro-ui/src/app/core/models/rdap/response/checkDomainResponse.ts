import { BaseResponse } from "../../baseResponse";

export class CheckDomainResponse extends BaseResponse {
    domain: string;
    isAvailableToBuy: boolean;
    nameserver1: string;
    nameserver2: string;
    lastChange: Date;
    expireDate: Date;
}