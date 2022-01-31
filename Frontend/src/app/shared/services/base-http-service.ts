import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

export class BaseHttpService {
    private baseUrl = environment.apiEndpoint;

    constructor(protected http: HttpClient){}

    protected buildUrl(path: string) {
        return `${this.baseUrl}/path`;
    }

}