import { BaseResponse } from "../../baseResponse";

export class LoginResponse extends BaseResponse {
    email: string;
    jwt: string;
}