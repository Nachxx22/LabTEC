import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DevolucionActivosComponent } from './devolucion-activos.component';

describe('DevolucionActivosComponent', () => {
  let component: DevolucionActivosComponent;
  let fixture: ComponentFixture<DevolucionActivosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DevolucionActivosComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DevolucionActivosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
