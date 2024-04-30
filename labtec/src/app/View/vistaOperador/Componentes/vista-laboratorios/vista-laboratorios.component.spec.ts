import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VistaLaboratoriosComponent } from './vista-laboratorios.component';

describe('VistaLaboratoriosComponent', () => {
  let component: VistaLaboratoriosComponent;
  let fixture: ComponentFixture<VistaLaboratoriosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [VistaLaboratoriosComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(VistaLaboratoriosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
