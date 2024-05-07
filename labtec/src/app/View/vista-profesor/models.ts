  export interface Horario {
    fecha: Date;
    horaInicio: Date;
    horaFin: Date;
    cedulaProfesor: string;
    laboratorio?: string;  // Agrega esta línea si es necesaria
  }


  export interface Laboratorio {
    name: string;
  }

  export interface Reserva {
    LaboratorioNombre: string;
    Fecha: Date;
    HoraInicio: Date;
    HoraFin: Date;
    CédulaProfesor: string;
  }
  export interface LaboratorioData {
    nombre: string;
    // Otros posibles campos que los objetos podrían tener
  }
