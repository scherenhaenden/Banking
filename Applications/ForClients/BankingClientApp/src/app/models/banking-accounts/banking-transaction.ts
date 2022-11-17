import { InterfaceTransaction } from "./interface-transaction";

export class BankingTransaction implements InterfaceTransaction{
  public id!: string;
  public date!: string;
  public description!: string;
  public amount!: number;
  public currency!: string;
  public type!: string;
  public isBlocked!: boolean;
  public relatedTransactionAccountNumber!: string;
}
