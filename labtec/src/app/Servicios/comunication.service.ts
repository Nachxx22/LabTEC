
import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ComunicacionService {
  private servidorURL = 'http://localhost:5020/platillo';

  constructor(private http: HttpClient) {}

  getPlatillo(): Observable<any> {
    return this.http.get<any>(`${this.servidorURL}/getPlatillos`);
  }
  postPlatillo(platilloData: any): Observable<any> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    return this.http.post<any>(`${this.servidorURL}/agregarPlatillos`, platilloData,httpOptions);
  }
}
