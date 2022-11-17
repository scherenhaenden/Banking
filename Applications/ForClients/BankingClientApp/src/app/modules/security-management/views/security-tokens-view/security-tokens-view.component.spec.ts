import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SecurityTokensViewComponent } from './security-tokens-view.component';

describe('SecurityTokensViewComponent', () => {
  let component: SecurityTokensViewComponent;
  let fixture: ComponentFixture<SecurityTokensViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SecurityTokensViewComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SecurityTokensViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
