using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WalletTracker
{
    public class UserController
    {
        private readonly List<User> _registeredUsers = new List<User>();

        public User CurrentUser { get; set; }
        public bool IsNewUser { get; private set; }

        public UserController() { }

        public void SignIn(string login)
        {
            CurrentUser = _registeredUsers.SingleOrDefault(u => u.Login == login);

            if (CurrentUser == null)
            {
                CurrentUser = new User(login);
                _registeredUsers.Add(CurrentUser);
                IsNewUser = true;
            }
            else
            {
                IsNewUser = false;
            }
        }

        public void SetAccounts(DepositAccount depositAccount, CreditAccount creditAccount, SavingAccount savingAccount)
        {
            CurrentUser.DepositAccount = depositAccount;
            CurrentUser.CreditAccount = creditAccount;
            CurrentUser.SavingAccount = savingAccount;
        }
    }
}
