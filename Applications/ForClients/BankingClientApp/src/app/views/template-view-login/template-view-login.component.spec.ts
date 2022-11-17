import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TemplateViewLoginComponent } from './template-view-login.component';

describe('TemplateViewLoginComponent', () => {
  let component: TemplateViewLoginComponent;
  let fixture: ComponentFixture<TemplateViewLoginComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TemplateViewLoginComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TemplateViewLoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
