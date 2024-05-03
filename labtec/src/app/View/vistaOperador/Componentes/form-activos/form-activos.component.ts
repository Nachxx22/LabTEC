import {Component, Inject} from '@angular/core';
import {MatButton, MatIconButton} from "@angular/material/button";
import {MatIcon} from "@angular/material/icon";
import {MAT_DIALOG_DATA, MatDialogActions, MatDialogClose, MatDialogContent} from "@angular/material/dialog";
import {MatFormField} from "@angular/material/form-field";
import {MatInput} from "@angular/material/input";
import {MatButtonToggle, MatButtonToggleChange, MatButtonToggleGroup} from "@angular/material/button-toggle";
import {NgIf} from "@angular/common";
import {ComunicationService} from "../../../../Servicios/comunication.service";
import {FormsModule} from "@angular/forms";

@Component({
  selector: 'app-form-activos',
  standalone: true,
  imports: [
    MatIconButton,
    MatIcon,
    MatDialogContent,
    MatFormField,
    MatInput,
    MatDialogActions,
    MatButton,
    MatDialogClose,
    MatButtonToggleGroup,
    MatButtonToggle,
    NgIf,
    FormsModule
  ],
  templateUrl: './form-activos.component.html',
  styleUrl: './form-activos.component.css'
})
export class FormActivosComponent {
  profesorSeleccionado: boolean = false; // Propiedad para almacenar el valor seleccionado del toggle
  banderaparaenviar:boolean=false;
  nombreTextbox="";
  apellidoTextbox="";
  correoTextbox="";
  contrasenaTextbox ="";
  //metodo para manejar el tipo
  onToggleChange(event: MatButtonToggleChange) {
    this.profesorSeleccionado = event.value === "true";
    this.banderaparaenviar = true;
  }
   currentDate= new Date(); //para establecer la fecha
  constructor(private servicio:ComunicationService,@Inject(MAT_DIALOG_DATA) public data: any) {}//forma de pasar
  //datos entre el componente de vista activos y el componente form-activos o
  //el formulario de registros.
  //data es el nombre de la data que se pasa , se usa en el html

  //metodo para realizar las reservas a la base de datos:
  realizarReserva(){
    if(!this.profesorSeleccionado){//si se seleccionó al reservador como
      //estudiante:
      const reservaEst ={//datos para el backend de login
        id:this.data.idActivo,//id del activo
        nomActivo:this.data.nomActivo,//nombre activo
        nombre:this.nombreTextbox,
        apellido:this.apellidoTextbox,
        correo:this.correoTextbox,
        fechaSolicitud: this.currentDate.toDateString()//devuelve mart mayo 2 2024
        //posible cambio a futuro.
      }//mada al servicio de envio
      this.servicio.solicitarReserva(reservaEst).subscribe(
        response => {
          console.log('Datos de reserva:', response);

        },
        error => {
          console.error('Error al enviar datos al servidor:', error);

        }
      );
    }
    else{ //si se seleccionó al profesor.
      const reservaProf ={//datos para el backend de login
        id:this.data.idActivo,//id del activo
        nomActivo:this.data.nomActivo,//nombre activo
        nombre:this.nombreTextbox,
        apellido:this.apellidoTextbox,
        correo:this.correoTextbox,
        contrasena:this.contrasenaTextbox,
        fechaSolicitud: this.currentDate.toDateString()//devuelve mart mayo 2 2024
        //posible cambio a futuro.
      }
      this.servicio.solicitarReservaP(reservaProf).subscribe(
        response => {
          console.log('Datos de reserva:', response);
        },
        error => {
          console.error('Error al enviar datos al servidor:', error);

        }
      );
    }
  }

}
