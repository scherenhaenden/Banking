import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MainUpBarComponent } from './main-up-bar.component';

describe('MainUpBarComponent', () => {
  let component: MainUpBarComponent;
  let fixture: ComponentFixture<MainUpBarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MainUpBarComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MainUpBarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
