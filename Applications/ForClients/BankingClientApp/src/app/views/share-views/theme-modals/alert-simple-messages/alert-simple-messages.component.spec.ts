import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlertSimpleMessagesComponent } from './alert-simple-messages.component';

describe('AlertSimpleMessagesComponent', () => {
  let component: AlertSimpleMessagesComponent;
  let fixture: ComponentFixture<AlertSimpleMessagesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AlertSimpleMessagesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AlertSimpleMessagesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
