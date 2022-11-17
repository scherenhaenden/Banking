export interface InterfaceBankingAccountCompactModel {
  userId:             string;
  accountId:          string;
  name:               string;
  balance:            number;
  currency:           string;
  isDefault:          boolean;
  isArchived:         boolean;
  isCurrencyTypeCode: string;
  isDeleted:          boolean;
  type:                string;
}
