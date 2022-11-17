import { Injectable } from '@angular/core';
import { BankingAccountCompactModel } from 'src/app/models/banking-accounts/banking-account-compact-model';
import { ApiBaseService } from '../generic/api-base.service';

@Injectable({
  providedIn: 'root'
})
export class AccountsService {

  constructor(private apiBaseService: ApiBaseService) { }

  public async getAccounts(): Promise<BankingAccountCompactModel[]> {
    return await this.apiBaseService.get(`/Accounts/getAccounts`);
  }
}
