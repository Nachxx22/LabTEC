import {Component, Inject} from '@angular/core';
import {MatButton, MatIconButton} from "@angular/material/button";
import {MatIcon} from "@angular/material/icon";
import {MAT_DIALOG_DATA, MatDialogActions, MatDialogClose, MatDialogContent} from "@angular/material/dialog";
import {MatFormField} from "@angular/material/form-field";
import {MatInput} from "@angular/material/input";
import {MatButtonToggle, MatButtonToggleChange, MatButtonToggleGroup} from "@angular/material/button-toggle";
import {NgIf} from "@angular/common";
import {ComunicationService} from "../../../../Servicios/comunication.service";
@Component({
  selector: 'app-form-devolucion',
  standalone: true,
  imports: [MatIconButton,
    MatIcon,
    MatDialogContent,
    MatFormField,
    MatInput,
    MatDialogActions,
    MatButton,
    MatDialogClose,
    MatButtonToggleGroup,
    MatButtonToggle,
    NgIf],
  templateUrl: './form-devolucion.component.html',
  styleUrl: './form-devolucion.component.css'
})
export class FormDevolucionComponent {
  Averia: boolean = false; // Propiedad para almacenar el valor seleccionado del toggle
  banderaparaenviar:boolean=false;
  password ="";//para los input
  descripcionAberia=""; //para los input
  //metodo para manejar el tipo
  onToggleChange(event: MatButtonToggleChange) {
    this.Averia = event.value === "true";
    this.banderaparaenviar = true;
  }
  constructor(private servicio:ComunicationService,@Inject(MAT_DIALOG_DATA) public data: any) {}//forma de pasar

  devolverActivo(){
    const devolActivo ={//datos para el backend de login
      id:this.data.idActivo,//id del activo
      nomActivo:this.data.nombreActivo,//nombre activo
      contrasena:this.password,
      desAveria:this.descripcionAberia,
      averia:this.Averia,
      //devuelve mart mayo 2 2024
      //posible cambio a futuro.
    }
    this.servicio.Averias(devolActivo).subscribe(
      response => {
        console.log('Datos de reserva:', response);
      },
      error => {
        console.error('Error al enviar datos al servidor:', error);

      }
    );
  }
}
