using System;
using System.Collections.Generic;
using System.Text;

namespace WalletTracker
{
    public abstract class Account
    {
        public decimal Balance { get; protected set; }
        public abstract void AddMoney(decimal sum);
        public abstract void WithdrawMoney(decimal sum);
        public abstract void TransferMoney(decimal sum, Account account);

       
    }
}
