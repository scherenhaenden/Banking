import { Component, Input, OnInit } from '@angular/core';
import { BankingAccountCompactModel } from 'src/app/models/banking-accounts/banking-account-compact-model';

@Component({
  selector: 'app-banking-account-cards',
  templateUrl: './banking-account-cards.component.html',
  styleUrls: ['./banking-account-cards.component.scss']
})
export class BankingAccountCardsComponent implements OnInit {

  // Create property input that receives banking accounts simple

  @Input() public bankingAccountCompactModel!: BankingAccountCompactModel;


  constructor() { }

  ngOnInit(): void {
  }

}
