import { SessionService } from 'src/app/services/session/session.service';
import { Component, OnInit } from '@angular/core';
import { BankingTransaction } from 'src/app/models/banking-accounts/banking-transaction';
import { BankingAccountComplete } from 'src/app/models/banking-accounts/banking-account-complete';
import { BankingAccountCompactModel } from 'src/app/models/banking-accounts/banking-account-compact-model';
import { AccountsService } from 'src/app/services/api/accounts/accounts.service';

@Component({
  selector: 'app-accounts-view',
  templateUrl: './accounts-view.component.html',
  styleUrls: ['./accounts-view.component.scss']
})
export class AccountsViewComponent implements OnInit {

  constructor(private sessionService: SessionService,
              private accountsService: AccountsService) { }

  ngOnInit(): void {
    this.loadSomeData();
    this.loadAccounts();
  }

  // Write loadAccounts method
  public async loadAccounts(): Promise<void> {

    const result = await this.accountsService.getAccounts();
    this.accounts = result;
  }

  public accounts: BankingAccountCompactModel [] = [];

  // Create method that logs user out
  public logout(): void {
    this.sessionService.clearUserSession();
  }

  public loadSomeData(): void {


/*

    // Mock banking accounts simple
    const bankingAccountSimple1 = new BankingAccountSimple();
    bankingAccountSimple1.id = '1';
    bankingAccountSimple1.name = 'Savings Account';
    bankingAccountSimple1.balance = 1000;
    bankingAccountSimple1.currency = 'USD';
    bankingAccountSimple1.isDefault = true;
    bankingAccountSimple1.isBlocked = false;
    bankingAccountSimple1.isArchived = false;
    bankingAccountSimple1.isCurrencyType = 'USD';
    bankingAccountSimple1.isCurrencyTypeCode = 'USD';
    bankingAccountSimple1.isDeleted = false;

   /* console.log('bankingAccountSimple1', bankingAccountSimple1);
    console.log('bankingAccountSimple1', JSON.stringify(bankingAccountSimple1));* /

    const bankingTransaction = new BankingTransaction();
    bankingTransaction.id = '1';
    bankingTransaction.date = new Date();
    bankingTransaction.description = 'Salary';
    bankingTransaction.amount = 1000;
    bankingTransaction.currency = 'USD';
    bankingTransaction.type = 'Credit';
    bankingTransaction.isBlocked = false;
    bankingTransaction.relatedTransactionAccountNumber = '123456789';


   /* console.log('bankingTransaction', bankingTransaction);
    console.log('bankingTransaction', JSON.stringify(bankingTransaction));* /

    const bankingAccountComplete : BankingAccountComplete = bankingAccountSimple1 as BankingAccountComplete;
    bankingAccountComplete.accountNumber = '123456789';
    bankingAccountComplete.transactions = [bankingTransaction];
/*
    console.log('bankingAccountComplete', bankingAccountComplete);
    console.log('bankingAccountComplete', JSON.stringify(bankingAccountComplete));* /




    const bankingAccountSimple2 = new BankingAccountSimple();
    bankingAccountSimple2.id = '2';
    bankingAccountSimple2.name = 'Current Account';
    bankingAccountSimple2.balance = 2000;

    const bankingAccountSimple3 = new BankingAccountSimple();
    bankingAccountSimple3.id = '3';
    bankingAccountSimple3.name = 'Credit Card';
    bankingAccountSimple3.balance = 3000;

    this.accounts.push(bankingAccountSimple1);
    this.accounts.push(bankingAccountSimple2);
    this.accounts.push(bankingAccountSimple3);*/

  }


}
