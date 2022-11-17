import { InterfaceBankingAccountCompactModel } from "./interface-banking-account-compact-model";

export class BankingAccountCompactModel implements InterfaceBankingAccountCompactModel {
    public userId!: string;
    public accountId!: string;
    public name!: string;
    public balance!: number;
    public currency!: string;
    public isDefault!: boolean;
    public isArchived!: boolean;
    public isCurrencyTypeCode!: string;
    public isDeleted!: boolean;
    public type!: string;
}
