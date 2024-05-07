import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormActivosComponent } from './form-activos.component';

describe('FormActivosComponent', () => {
  let component: FormActivosComponent;
  let fixture: ComponentFixture<FormActivosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FormActivosComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FormActivosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
