import { Component } from '@angular/core';
import {MatToolbar} from "@angular/material/toolbar";
import {MatFormField, MatHint, MatLabel} from "@angular/material/form-field";
import {MatDatepicker, MatDatepickerInput, MatDatepickerToggle} from "@angular/material/datepicker";
import { MatNativeDateModule } from '@angular/material/core';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import {MatGridList, MatGridTile} from "@angular/material/grid-list";
import {NgClass, NgFor} from "@angular/common";
import {MatCard} from "@angular/material/card";
import {FormsModule} from "@angular/forms";
import {
  MatCell,
  MatCellDef,
  MatColumnDef,
  MatHeaderCell,
  MatHeaderRow,
  MatHeaderRowDef,
  MatRow, MatRowDef, MatTable, MatTableDataSource
} from "@angular/material/table";
export interface Reservacion {
  reservador: string;
  dia: string;
  horaInicio: string;
  horaFin: string;
}

@Component({
  selector: 'app-vista-laboratorios',
  standalone: true,
  imports: [
    NgFor,
    MatToolbar,
    MatFormField,
    MatDatepickerInput,
    MatDatepickerToggle,
    MatDatepicker,
    MatHint,
    MatLabel,
    MatNativeDateModule,
    MatInputModule,
    MatDatepickerModule,
    MatGridList,
    MatGridTile,
    MatCard,
    FormsModule,
    NgClass,
    MatCell,
    MatCellDef,
    MatColumnDef,
    MatHeaderCell,
    MatHeaderRow,
    MatHeaderRowDef,
    MatRow,
    MatRowDef,
    MatTable
  ],
  templateUrl: './vista-laboratorios.component.html',
  styleUrl: './vista-laboratorios.component.css'
})
export class VistaLaboratoriosComponent {
  // Función para filtrar las fechas
  myFilter = (d: Date | null): boolean => {//filtro para el selector del dia.
    if (!d) return false; // Si d es nulo, retorna falso

    const today = new Date();
    const startDate = new Date(today);
    startDate.setDate(today.getDate() - 1);

    const endDate = new Date(today);
    endDate.setDate(today.getDate() + 21); // 3 semanas después
    // Si la fecha es anterior al día de hoy o después de 3 semanas, no está disponible
    return d >= startDate || d === today && d <= endDate;
  };
  daysOfWeek = ['Hora','Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado', 'Domingo'];
  hours = ['7 AM', '8 AM', '9 AM', '10 AM', '11 AM', '12 PM'];
  reservations = [{}]; // Aquí almacenarás las reservaciones existentes

  openReservationForm(day: string, hour: string) {
    // Lógica para abrir el formulario de reservación
  }


}
