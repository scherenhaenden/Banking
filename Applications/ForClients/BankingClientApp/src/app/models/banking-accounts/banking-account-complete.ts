import { BankingAccountCompactModel } from "./banking-account-compact-model";
import { BankingTransaction } from "./banking-transaction";
import { InterfaceBankingAccountComplete } from "./interface-banking-account-complete";

export class BankingAccountComplete extends BankingAccountCompactModel implements InterfaceBankingAccountComplete {
    public transactions!: BankingTransaction[];
    public isBlocked!: boolean;
    public isCurrencyType!: string;
    public iban!: string;
    public bic!: string;
    public status!: string;
    public createdAt!: string;
    public updatedAt!: string;
    public isLocked!: boolean;
    public isVerified!: boolean;
    public isVerifiedBy!: string;
    public verifiedAt!: string;
}
