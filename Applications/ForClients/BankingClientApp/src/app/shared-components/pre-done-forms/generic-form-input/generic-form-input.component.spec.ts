import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GenericFormInputComponent } from './generic-form-input.component';

describe('GenericFormInputComponent', () => {
  let component: GenericFormInputComponent;
  let fixture: ComponentFixture<GenericFormInputComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GenericFormInputComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GenericFormInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
