import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {catchError, Observable, throwError} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CalendarioService {
  private apiUrl = 'http://localhost:5276/api';

  constructor(private http: HttpClient) { }

  getLaboratorios(): Observable<any> {
    return this.http.get(`${this.apiUrl}/Laboratorio`);
  }

  getHorarios(laboratorioNombre: string, fecha?: string): Observable<any> {
    let url = `${this.apiUrl}/HorariosLaboratorios/${laboratorioNombre}`;
    if (fecha) {
      url += `/${fecha}`;
    }
    return this.http.get(url);
  }

  reservarHorario(reserva: any): Observable<any> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    return this.http.post(`${this.apiUrl}/HorariosLaboratorios`, JSON.stringify(reserva), { headers })
      .pipe(
        catchError(err => {
          console.error('Error al enviar la reserva:', err);
          return throwError(() => new Error('Error al realizar la reserva'));
        })
      );
  }
}



