
import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ComunicationService {
  private servidorURL = 'http://localhost:5276/api';
  private usuarioId = ""; //se almacena el id del operador
  //metodos para setear y almacenar el id.
  public getUsuarioId(): string {
    return this.usuarioId;
  }

  public setUsuarioId(id: string): void {
    this.usuarioId = id;
  }

  constructor(private http: HttpClient) {}
  //obtiene los reportes de este usuario
  getReportes(username:string): Observable<any> {//idOperador es como lo tengo en la bd
    //DEBE DE SER EXACTAMENTE IGUAL EN LA API
    return this.http.get<any>(`${this.servidorURL}/ReportesOperadores/getReportes?idOperador=${username}`);
  }
  //obtiene los activos de este usuario.
  getActivos(): Observable<any> {
    return this.http.get<any>(`${this.servidorURL}/getActivos`);
  }
  //metodo que obtiene los activos por aprobar por el operador.
  getaprobarSolicitud(username:string): Observable<any> {
    return this.http.get<any>(`${this.servidorURL}/getsolAprob?username=${username}`);
  }
  verifyLogin(Correo: string , Contrasena: string): Observable<any> {
    return this.http.get<any>(`${this.servidorURL}/Loginad/ADverificarLogin?correo=${Correo}&contrasena=${Contrasena}`);
  }

  //metodo del servicio que le envia la información del usuario y la contraseña
  //y verifica si es correcta

  //POST****************************************************************

  //solicitud reserva activos estudiantes.
  solicitarReserva(reservaEdata: any): Observable<any> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    return this.http.post<any>(`${this.servidorURL}/reservactivoEst`, reservaEdata,httpOptions);
  }
  //solicitud reserva para profesores
  solicitarReservaP(reservaPdata: any): Observable<any> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    return this.http.post<any>(`${this.servidorURL}/reservactivoProf`, reservaPdata,httpOptions);
  }
  registrarse(registrarsedata: any): Observable<any> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    return this.http.post<any>(`${this.servidorURL}/Loginop/registrarse`, registrarsedata,httpOptions);
  }
  Averias(averiadata: any): Observable<any> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    return this.http.post<any>(`${this.servidorURL}/averias`, averiadata,httpOptions);
  }
}
