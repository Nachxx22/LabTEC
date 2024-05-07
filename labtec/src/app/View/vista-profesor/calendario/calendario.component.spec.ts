import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CalendarioComponent } from './calendario.component';
import {HttpClientTestingModule} from "@angular/common/http/testing";
import {CalendarioService} from "../calendario.service";

describe('CalendarioComponent', () => {
  let component: CalendarioComponent;
  let fixture: ComponentFixture<CalendarioComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CalendarioComponent],
      providers: [CalendarioService], // Agrega los proveedores necesarios
      imports: [HttpClientTestingModule] // Importa HttpClientTestingModule para mockear solicitudes HTTP
    })
      .compileComponents();

    fixture = TestBed.createComponent(CalendarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });


  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
