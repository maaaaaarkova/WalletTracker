using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WalletTracker
{
    public class User
    {
        public string Login { get; set; }

        public DepositAccount DepositAccount { get; set; }
        public CreditAccount CreditAccount { get; set; }
        public SavingAccount SavingAccount { get; set; }


        public User(string login)
        {
            if (string.IsNullOrWhiteSpace(login))
                throw new ArgumentNullException(nameof(login), "Unsuitable login");

            Login = login;
        }

    }
}
