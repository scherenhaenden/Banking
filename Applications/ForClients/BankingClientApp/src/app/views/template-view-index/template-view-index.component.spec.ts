import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TemplateViewIndexComponent } from './template-view-index.component';

describe('TemplateViewIndexComponent', () => {
  let component: TemplateViewIndexComponent;
  let fixture: ComponentFixture<TemplateViewIndexComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TemplateViewIndexComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TemplateViewIndexComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
