import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegistroTrabajoComponent } from './registro-trabajo.component';

describe('RegistroTrabajoComponent', () => {
  let component: RegistroTrabajoComponent;
  let fixture: ComponentFixture<RegistroTrabajoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RegistroTrabajoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RegistroTrabajoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
