import {Component, Inject} from '@angular/core';
import {MatButton, MatIconButton} from "@angular/material/button";
import {MatIcon} from "@angular/material/icon";
import {MAT_DIALOG_DATA, MatDialogActions, MatDialogClose, MatDialogContent} from "@angular/material/dialog";
import {MatFormField} from "@angular/material/form-field";
import {MatInput} from "@angular/material/input";
import {MatButtonToggle, MatButtonToggleChange, MatButtonToggleGroup} from "@angular/material/button-toggle";
import {NgIf} from "@angular/common";
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
  //metodo para manejar el tipo
  onToggleChange(event: MatButtonToggleChange) {
    this.Averia = event.value === "true";
    this.banderaparaenviar = true;
  }
  constructor(@Inject(MAT_DIALOG_DATA) public data: any) {}//forma de pasar
  //datos entre el componente de vista activos y el componente form-activos o
  //el formulario de registros.
  //data es el nombre de la data que se pasa , se usa en el html


}
