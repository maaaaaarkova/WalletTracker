using System;
using System.Collections.Generic;
using System.Text;

namespace WalletTracker
{
    public class CreditAccount : Account
    {
        private const double percent = 0.15;
        private const double transferPercent = 0.05;
        public decimal Debt { get; set; }

        public CreditAccount()
        {
            Balance = 0;
        }

        public override void AddMoney(decimal sum)
        {
            Balance += sum;
        }

        public override void WithdrawMoney(decimal sum)
        {
            decimal percentSum = sum + sum * (decimal)transferPercent;

            if (percentSum > Balance)
            {
                throw new ArgumentException("Not enough money");
            }

            Balance -= percentSum;
        }

        public override void TransferMoney(decimal sum, Account account)
        {
            decimal percentSum = sum + sum * (decimal)transferPercent;

            if (percentSum > Balance)
            {
                throw new ArgumentException("Not enough money");
            }

            account.AddMoney(sum);
            Balance -= percentSum;
        }

        public void BorrowMoney(decimal sum)
        {
            Balance += sum;
            Debt = Debt + sum + sum * (decimal)percent;
        }

        public void ReturnMoney(decimal sum)
        {
            if (sum > Balance)
            {
                throw new ArgumentException("Not enough money");
            }

            if (sum > Debt)
            {
                throw new ArgumentException("Wrong input");
            }

            Balance -= sum;
            Debt -= sum;

        }

    }
}
