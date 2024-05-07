import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { CalendarioService } from '../calendario.service';
import { Horario, Laboratorio, LaboratorioData } from '../models';

@Component({
  selector: 'app-calendario',
  templateUrl: './calendario.component.html',
  standalone: true,
  imports: [
    CommonModule,  // Importa CommonModule para usar *ngFor, *ngIf, etc.
    FormsModule,   // Importa FormsModule para usar [(ngModel)]
    ReactiveFormsModule  // Importa ReactiveFormsModule para los formularios reactivos
  ],
  styleUrls: ['./calendario.component.css']
})
export class CalendarioComponent implements OnInit {
  laboratorios: Laboratorio[] = [];
  horariosReservados: Horario[] = [];
  laboratorioSeleccionado: string = '';
  selectedHour: string | null = null;
  selectedDate: string = new Date().toISOString().split('T')[0]; // Establece la fecha actual como predeterminada
  reservaForm: FormGroup;
  dayHours = ['08:00', '09:00', '10:00', '11:00', '12:00', '13:00', '14:00', '15:00', '16:00', '17:00', '18:00', '19:00', '20:00', '21:00', '22:00', '23:00'];


  constructor(
    private fb: FormBuilder,
    private calendarioService: CalendarioService
  ) {
    this.reservaForm = this.fb.group({
      LaboratorioNombre: ['', Validators.required],
      HoraInicio: ['', Validators.required],
      HoraFin: ['', Validators.required],
      Fecha: ['', Validators.required],
      CédulaProfesor: ['', Validators.required]
    });
  }




  ngOnInit(): void {
    this.calendarioService.getLaboratorios().subscribe((data: any[]) => {
      console.log(data);  // Esto mostrará los datos recibidos.
      this.laboratorios = data.map(lab => ({ name: lab.nombre }));
      console.log(this.laboratorios);  // Esto te mostrará lo que se guarda en 'laboratorios'
    }, error => {
      console.error('Error al cargar laboratorios:', error);
    });
  }



  onLaboratorioSelected() {
    if (this.laboratorioSeleccionado && this.selectedDate) {
      this.calendarioService.getHorarios(this.laboratorioSeleccionado, this.selectedDate).subscribe((data: any[]) => {
        this.horariosReservados = data.map(horario => ({
          ...horario,
          horaInicio: new Date(horario.fecha + 'T' + horario.horaInicio),
          horaFin: new Date(horario.fecha + 'T' + horario.horaFin)
        }));
      }, error => {
        console.error('Error al cargar horarios:', error);
      });
    }
  }


  prepararReserva(hour: string) {
    this.selectedHour = hour; // Almacena la hora seleccionada
    // Configura los valores iniciales del formulario aquí, si es necesario
    this.reservaForm.patchValue({
      horaInicio: hour, // Establece horaInicio como la hora seleccionada
      horaFin: hour // Esto es solo un ejemplo, probablemente necesites ajustarlo
    });
  }




  isReserved(hour: string): boolean {
    const hourDate = new Date(`${this.selectedDate}T${hour}:00`);

    return this.horariosReservados.some(h =>
      hourDate >= h.horaInicio && hourDate < h.horaFin
    );
  }





  enviarReserva() {
    if (this.reservaForm.valid) {
      // Asegúrate de que la fecha se formatee correctamente
      const formattedDate = this.reservaForm.value.Fecha ?
        new Date(this.reservaForm.value.Fecha).toISOString().split('T')[0] :
        null;
      console.log('Formatted Date:', formattedDate); // Esto imprimirá la fecha formateada en la consola

      const reserva = {
        LaboratorioNombre: String(this.laboratorioSeleccionado),
        Fecha: String(this.reservaForm.value.Fecha),
        HoraInicio: String(this.reservaForm.value.HoraInicio),
        HoraFin: String(this.reservaForm.value.HoraFin),
        CédulaProfesor: String(this.reservaForm.value.CédulaProfesor)
      };
      console.log('NombreLaboratorio:', reserva.LaboratorioNombre); // Esto imprimirá la fecha formateada en la consola
      console.log('Fecha enviada:', reserva.Fecha); // Esto imprimirá la fecha formateada en la consola
      console.log('HoraInicio:', reserva.HoraInicio); // Esto imprimirá la fecha formateada en la consola
      console.log('HoraFin:', reserva.HoraFin);
      console.log('cedulaprofesor:', reserva.CédulaProfesor);

      this.calendarioService.reservarHorario(reserva).subscribe({
        next: () => {
          alert('Reserva realizada con éxito');
          this.reservaForm.reset();
          this.onLaboratorioSelected();  // Recargar horarios reservados
        },
        error: (err) => {
          alert('Error al realizar la reserva: ' + err.message);
        }
      });
    } else {
      alert('Por favor, complete todos los campos requeridos.');
    }
  }


}








