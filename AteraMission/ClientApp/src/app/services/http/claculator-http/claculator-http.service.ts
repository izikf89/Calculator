import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable()
export class ClaculatorHttpService {
  
  constructor(
    @Inject('BASE_URL') private baseUrl: string,
    private http: HttpClient,
  ) { }

  calc(exp: string): Observable<string> {
    return this.http.get(this.baseUrl + 'api/Calculator', { params: { exp: encodeURIComponent(exp) },responseType:'text'})   
  }
}
