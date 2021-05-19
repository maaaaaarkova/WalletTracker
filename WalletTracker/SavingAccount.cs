using System;
using System.Collections.Generic;
using System.Text;

namespace WalletTracker
{
    public class SavingAccount : Account
    {
        public SavingAccount()
        {
            Balance = 0;
        }

        public override void AddMoney(decimal sum)
        {
            Balance = Balance + sum;
        }

        public override void WithdrawMoney(decimal sum)
        {
            if (sum > Balance)
            {
                throw new ArgumentException("Not enough money");
            }

            Balance = Balance - sum;
        }


        public override void TransferMoney(decimal sum, Account account)
        {
            if (sum > Balance)
            {
                throw new ArgumentException("Not enough money");
            }
            account.AddMoney(sum);
            Balance = Balance - sum;
        }

        public void SaveMoney(decimal sum, DepositAccount money)
        {
            if (sum > money.Balance)
            {
                throw new ArgumentException("Not enough money");
            }
            money.WithdrawMoney(sum);
            Balance = Balance + sum;

        }
    }
}
