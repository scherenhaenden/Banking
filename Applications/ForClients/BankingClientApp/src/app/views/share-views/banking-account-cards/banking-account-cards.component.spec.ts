import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BankingAccountCardsComponent } from './banking-account-cards.component';

describe('BankingAccountCardsComponent', () => {
  let component: BankingAccountCardsComponent;
  let fixture: ComponentFixture<BankingAccountCardsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BankingAccountCardsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BankingAccountCardsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
