export interface InterfaceTransaction {
  id: string
  date: string
  description: string
  amount: number
  currency: string
  type: string
  isBlocked: boolean
  relatedTransactionAccountNumber: string
}

