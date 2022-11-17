import { InterfaceTransaction } from "./interface-transaction"

export interface InterfaceBankingAccountComplete {
  userId: string
  accountId: string
  name: string
  balance: number
  currency: string
  isDefault: boolean
  isArchived: boolean
  isCurrencyTypeCode: string
  isDeleted: boolean
  type: string
  transactions: InterfaceTransaction[]
  iban: string
  bic: string
  status: string
  createdAt: string
  updatedAt: string
  isLocked: boolean
  isVerified: boolean
  isVerifiedBy: string
  verifiedAt: string
}
