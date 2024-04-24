import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VistaActivosComponent } from './vista-activos.component';

describe('VistaActivosComponent', () => {
  let component: VistaActivosComponent;
  let fixture: ComponentFixture<VistaActivosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [VistaActivosComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(VistaActivosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
