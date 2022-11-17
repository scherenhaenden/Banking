import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TemplateViewProfileComponent } from './template-view-profile.component';

describe('TemplateViewProfileComponent', () => {
  let component: TemplateViewProfileComponent;
  let fixture: ComponentFixture<TemplateViewProfileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TemplateViewProfileComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TemplateViewProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
