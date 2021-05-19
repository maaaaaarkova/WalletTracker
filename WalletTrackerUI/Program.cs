using System;
using WalletTracker;

namespace WalletTrackerUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the WalletTracker! Which account do you want to continue with?");
            DepositAccount depAccount = new DepositAccount();
            CreditAccount crAccount = new CreditAccount();
            SavingAccount savAccount = new SavingAccount();


            while (true)
            {
                Beginning(depAccount, crAccount, savAccount);
            }

         

        }

        static void Beginning(DepositAccount depAccount, CreditAccount crAccount, SavingAccount savAccount)
        {
            Console.WriteLine("Press 1 to continue with a deposit account");
            Console.WriteLine("Press 2 to continue with a credit account");
            Console.WriteLine("Press 3 to continue with your saving account");
            Console.WriteLine("Press 0 to exit");

            int key;

            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out key))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong input!");
                    Console.ResetColor();
                }

                else
                {
                    break;
                }
            }

            switch (key)
            {
                case 1:
                    Console.WriteLine("Welcome to the deposit account!");
                    WorkingWithDA(depAccount, crAccount, savAccount);
                    break;
                case 2:
                    Console.WriteLine("Welcome to the credit account!");
                    WorkingWithCA(depAccount, crAccount, savAccount);
                    break;

                case 3:
                    Console.WriteLine("Welcome to your saving account!");
                    WorkingWithSA(depAccount, crAccount, savAccount);
                    break;

                case 0:
                    Environment.Exit(0);
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong input!");
                    Console.ResetColor();
                    break;
            }

        }
        static void WorkingWithDA(DepositAccount account, CreditAccount crAccount, SavingAccount savAccount)
        {
            Console.WriteLine("Choose your next step: ");
            Console.WriteLine("Press 1 to add money to your account");
            Console.WriteLine("Press 2 to withdraw money");
            Console.WriteLine("Press 3 to transfer money to another account");
            Console.WriteLine("Press 4 to pay bills");
            Console.WriteLine("Press 0 to return");

            int key;

            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out key))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong input!");
                    Console.ResetColor();
                }

                else
                {
                    break;
                }
            }

            switch (key)
            {
                case 1:
                    Console.WriteLine("How much money do you want to add? Enter your sum: ");
                    decimal addSum;

                    while (true)
                    {
                        if (!decimal.TryParse(Console.ReadLine(), out addSum))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Wrong input!");
                            Console.ResetColor();
                        }

                        else
                        {
                            break;
                        }
                    }

                    if (addSum >= 0)
                    {
                        account.AddMoney(addSum);
                        Console.WriteLine("Your Balance: " + account.Balance);
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong input!");
                        Console.ResetColor();
                    }
                    WorkingWithDA(account, crAccount, savAccount);
                    break;

                case 2:
                    if (account.Balance != 0)
                    {
                        Console.WriteLine("How much money do you want to withdraw? Enter your sum: ");

                        while (true)
                        {
                            decimal withdrawSum;

                            if (!decimal.TryParse(Console.ReadLine(), out withdrawSum))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Wrong input!");
                                Console.ResetColor();
                            }

                            else
                            {
                                if (withdrawSum >= 0)
                                {
                                    try
                                    {
                                        account.WithdrawMoney(withdrawSum);
                                        break;
                                    }
                                    catch (ArgumentException)
                                    {
                                        Console.WriteLine("You entered the wrong value! Choose another one");
                                    }
                                }

                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Wrong input!");
                                    Console.ResetColor();
                                    WorkingWithDA(account, crAccount, savAccount);
                                }
                            }
                        }

                        Console.WriteLine("Your Balance: " + account.Balance);
                    }

                    else
                    {
                        Console.WriteLine("You cant withdraw any money! Your account is empty! Try another operation");
                    }

                    WorkingWithDA(account, crAccount, savAccount);
                    break;

                case 3:
                    if (account.Balance != 0)
                    {
                        Console.WriteLine("Choose the account you want to transfer money to: ");
                        Console.WriteLine("Press 1 to transfer to credit account");
                        Console.WriteLine("Press 2 to transfer to saving account");
                        Console.WriteLine("Press 0 to go back to the previous page");

                        int acc;

                        while (true)
                        {
                            if (!int.TryParse(Console.ReadLine(), out acc))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Wrong input!");
                                Console.ResetColor();
                            }

                            else
                            {
                                break;
                            }
                        }

                        switch (acc)
                        {
                            case 1:
                                Console.WriteLine("How much money do you want to transfer? Enter your sum: ");
                                while (true)
                                {
                                    decimal crTransferSum;

                                    if (!decimal.TryParse(Console.ReadLine(), out crTransferSum))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Wrong input!");
                                        Console.ResetColor();
                                    }

                                    else
                                    {
                                        if (crTransferSum >= 0)
                                        {
                                            try
                                            {
                                                account.TransferMoney(crTransferSum, crAccount);
                                                Console.WriteLine("Your Balance: " + account.Balance);
                                                break;
                                            }
                                            catch (ArgumentException)
                                            {
                                                Console.WriteLine("You entered the wrong value! Choose another one");
                                            }
                                        }

                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Wrong input!");
                                            Console.ResetColor();
                                        }
                                    }
                                }

                                WorkingWithDA(account, crAccount, savAccount);
                                break;

                            case 2:
                                Console.WriteLine("How much money do you want to transfer? Enter your sum: ");
                                while (true)
                                {
                                    decimal savTransferSum;

                                    if (!decimal.TryParse(Console.ReadLine(), out savTransferSum))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Wrong input!");
                                        Console.ResetColor();
                                    }

                                    else
                                    {
                                        if (savTransferSum >= 0)
                                        {
                                            try
                                            {
                                                account.TransferMoney(savTransferSum, savAccount);
                                                Console.WriteLine("Your Balance: " + account.Balance);
                                                break;
                                            }
                                            catch (ArgumentException)
                                            {
                                                Console.WriteLine("You entered the wrong value! Choose another one");
                                            }
                                        }

                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Wrong input!");
                                            Console.ResetColor();
                                        }
                                    }
                                }

                                WorkingWithDA(account, crAccount, savAccount);
                                break;

                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Wrong input!");
                                Console.ResetColor();
                                break;
                        }
                    }

                    else
                    {
                        Console.WriteLine("Your account is empty! Choose another operation!");
                        WorkingWithDA(account, crAccount, savAccount);
                    }
                    break;

                case 4:
                    if (account.Balance != 0)
                    {
                        Console.WriteLine("Choose the bill you want to pay:");
                        Console.WriteLine("Press 1 to pay your charges for hot water");
                        Console.WriteLine("Press 2 to pay your charges for cold water");
                        Console.WriteLine("Press 3 to pay your household expenses");
                        Console.WriteLine("Press 4 to check all money you have paid for bills");
                        Console.WriteLine("Press 0 to return");

                        int billsKey;

                        while (true)
                        {
                            if (!int.TryParse(Console.ReadLine(), out billsKey))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Wrong input!");
                                Console.ResetColor();
                            }

                            else
                            {
                                break;
                            }
                        }

                        switch (billsKey)
                        {
                            case 1:
                                Console.WriteLine("Enter your hot water counter data:");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Hot water price = 80.58 per m3");
                                Console.ResetColor();

                                while (true)
                                {
                                    int hotData;

                                    if (!int.TryParse(Console.ReadLine(), out hotData))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Wrong input!");
                                        Console.ResetColor();
                                    }

                                    else
                                    {
                                        if (hotData >= 1)
                                        {
                                            try
                                            {
                                                account.HotWaterBills(hotData);
                                                break;
                                            }
                                            catch (ArgumentException)
                                            {
                                                Console.WriteLine("Not enough money!");
                                                WorkingWithDA(account, crAccount, savAccount);
                                            }
                                        }

                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Wrong input!");
                                            Console.ResetColor();
                                        }
                                    }
                                }
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Your bills were successfully paid");
                                Console.ResetColor();
                                Console.WriteLine("Your Balance: " + account.Balance);
                                WorkingWithDA(account, crAccount, savAccount);
                                break;

                            case 2:
                                Console.WriteLine("Enter your cold water counter data:");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Cold water price = 30.25 per m3");
                                Console.ResetColor();

                                while (true)
                                {
                                    int coldData;

                                    if (!int.TryParse(Console.ReadLine(), out coldData))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Wrong input!");
                                        Console.ResetColor();
                                    }

                                    else
                                    {
                                        if (coldData >= 1)
                                        {
                                            try
                                            {
                                                account.ColdWaterBills(coldData);
                                                break;
                                            }
                                            catch (ArgumentException)
                                            {
                                                Console.WriteLine("Not enough money!");
                                                WorkingWithDA(account, crAccount, savAccount);
                                            }
                                        }

                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Wrong input!");
                                            Console.ResetColor();
                                        }
                                    }
                                }
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Your bills were successfully paid");
                                Console.ResetColor();
                                Console.WriteLine("Your Balance: " + account.Balance);
                                WorkingWithDA(account, crAccount, savAccount);
                                break;

                            case 3:
                                Console.WriteLine("Enter the square of your apartment");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Household expenses = 5.37 per m2");
                                Console.ResetColor();
                                int square;

                                while (true)
                                {
                                    if (!int.TryParse(Console.ReadLine(), out square))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Wrong input!");
                                        Console.ResetColor();
                                    }

                                    else
                                    {
                                        if (square >= 1)
                                        {
                                            try
                                            {
                                                account.HouseholdExpenses(square);
                                                break;
                                            }
                                            catch (ArgumentException)
                                            {
                                                Console.WriteLine("Not enough money!");
                                                WorkingWithDA(account, crAccount, savAccount);
                                            }
                                        }

                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Wrong input!");
                                            Console.ResetColor();
                                        }
                                    }
                                }
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Your bills were successfully paid");
                                Console.ResetColor();
                                Console.WriteLine("Your Balance: " + account.Balance);
                                WorkingWithDA(account, crAccount, savAccount);
                                break;

                            case 4:
                                Console.WriteLine("You have paid:");
                                Console.WriteLine("For hot water: " + account.AllHotWater);
                                Console.WriteLine("For cold water: " + account.AllColdWater);
                                Console.WriteLine("For household expenses: " + account.AllHouseHold);
                                WorkingWithDA(account, crAccount, savAccount);
                                break;

                            case 0:
                                break;

                            default:
                                break;
                        }
                    }

                    else
                    {
                        Console.WriteLine("Your account is empty! Choose another operation!");
                        WorkingWithDA(account, crAccount, savAccount);
                    }

                    break;

                case 0:
                    Beginning(account, crAccount, savAccount);
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong input!");
                    Console.ResetColor();
                    WorkingWithDA(account, crAccount, savAccount);
                    break;
            }
        }

        static void WorkingWithCA(DepositAccount depAccount, CreditAccount crAccount, SavingAccount savAccount)
        {

            Console.WriteLine("Choose your next step: ");
            Console.WriteLine("Press 1 to add money to your account");
            Console.WriteLine("Press 2 to withdraw money");
            Console.WriteLine("Press 3 to transfer money to another account");
            Console.WriteLine("Press 4 to borrow money from the bank");
            Console.WriteLine("Press 5 to return borrowed money to the bank");
            Console.WriteLine("Press 6 to check your debt");
            Console.WriteLine("Press 7 to check your Balance");
            Console.WriteLine("Press 0 to return");

            int key;

            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out key))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong input!");
                    Console.ResetColor();
                }

                else
                {
                    break;
                }
            }

            switch (key)
            {
                case 1:
                    Console.WriteLine("How much money do you want to add? Enter your sum: ");
                    decimal addSum;

                    while (true)
                    {
                        if (!decimal.TryParse(Console.ReadLine(), out addSum))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Wrong input!");
                            Console.ResetColor();
                        }

                        else
                        {
                            break;
                        }
                    }

                    if (addSum >= 0)
                    {
                        crAccount.AddMoney(addSum);
                        Console.WriteLine("Your Balance: " + crAccount.Balance);
                    }

                    else
                    {
                        Console.WriteLine("Wrong input");
                    }
                    WorkingWithCA(depAccount, crAccount, savAccount);
                    break;

                case 2:

                    if (crAccount.Balance != 0)
                    {
                        Console.WriteLine("How much money do you want to withdraw? Enter your sum: ");
                        Console.WriteLine("Withdraw fee = 5%");

                        while (true)
                        {
                            decimal withdrawSum;

                            if (!decimal.TryParse(Console.ReadLine(), out withdrawSum))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Wrong input!");
                                Console.ResetColor();
                            }

                            else
                            {
                                if (withdrawSum >= 0)
                                {
                                    try
                                    {
                                        crAccount.WithdrawMoney(withdrawSum);
                                        Console.WriteLine("Your Balance: " + crAccount.Balance);
                                        break;
                                    }
                                    catch (ArgumentException)
                                    {
                                        Console.WriteLine("You entered the wrong value! Choose another one");
                                    }
                                }

                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Wrong input!");
                                    Console.ResetColor();
                                }
                            }
                        }
 
                    }

                    else
                    {
                        Console.WriteLine("You cant withdraw any money! Your account is empty! Try another operation");
                    }

                    WorkingWithCA(depAccount, crAccount, savAccount);
                    break;

                case 3:
                    if (crAccount.Balance != 0)
                    {
                        Console.WriteLine("Choose the account you want to transfer money to: ");
                        Console.WriteLine("Press 1 to transfer to deposit account");
                        Console.WriteLine("Press 2 to transfer to saving account");
                        Console.WriteLine("Press 0 to go back to the previous page");

                        int acc;

                        while (true)
                        {
                            if (!int.TryParse(Console.ReadLine(), out acc))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Wrong input!");
                                Console.ResetColor();
                            }

                            else
                            {
                                break;
                            }
                        }

                        switch (acc)
                        {
                            case 1:
                                Console.WriteLine("How much money do you want to transfer? Enter your sum: ");
                                Console.WriteLine("Transfer fee = 5%");
                                while (true)
                                {
                                    decimal crTransferSum;

                                    if (!decimal.TryParse(Console.ReadLine(), out crTransferSum))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Wrong input!");
                                        Console.ResetColor();
                                    }

                                    else
                                    {
                                        if (crTransferSum >= 0)
                                        {
                                            try
                                            {
                                                crAccount.TransferMoney(crTransferSum, depAccount);
                                                Console.WriteLine("Your Balance: " + crAccount.Balance);
                                                break;
                                            }

                                            catch (ArgumentException)
                                            {
                                                Console.WriteLine("You entered the wrong value! Choose another one");
                                            }
                                        }

                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Wrong input!");
                                            Console.ResetColor();
                                        }
                                    }
                                }

                                WorkingWithCA(depAccount, crAccount, savAccount);
                                break;

                            case 2:
                                Console.WriteLine("How much money do you want to transfer? Enter your sum: ");
                                Console.WriteLine("Transfer fee = 5%");
                                while (true)
                                {
                                    decimal savTransferSum;

                                    if (!decimal.TryParse(Console.ReadLine(), out savTransferSum))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Wrong input!");
                                        Console.ResetColor();
                                    }

                                    else
                                    {
                                        if (savTransferSum >= 0)
                                        {
                                            try
                                            {
                                                crAccount.TransferMoney(savTransferSum, savAccount);
                                                Console.WriteLine("Your Balance: " + crAccount.Balance);
                                                break;
                                            }

                                            catch (ArgumentException)
                                            {
                                                Console.WriteLine("You entered the wrong value! Choose another one");
                                            }
                                        }

                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Wrong input!");
                                            Console.ResetColor();
                                        }
                                    }
                                }

                                WorkingWithCA(depAccount, crAccount, savAccount);
                                break;

                            case 0:
                                WorkingWithCA(depAccount, crAccount, savAccount);
                                break;

                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Wrong input!");
                                Console.ResetColor();
                                break;
                        }
                    }

                    else
                    {
                        Console.WriteLine("Your account is empty! Choose another operation");
                    }
                    WorkingWithCA(depAccount, crAccount, savAccount);
                    break;

                case 4:
                    Console.WriteLine("How much money do you want to borrow? Enter your sum: ");
                    Console.WriteLine("Credit percent = 15%");
                    decimal borrowSum;

                    while (true)
                    {
                        if (!decimal.TryParse(Console.ReadLine(), out borrowSum))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Wrong input!");
                            Console.ResetColor();
                        }

                        else
                        {
                            break;
                        }
                    }

                    if (borrowSum >= 0)
                    {
                        crAccount.BorrowMoney(borrowSum);
                        Console.WriteLine("Your Balance: " + crAccount.Balance);
                        Console.WriteLine("Your debt: " + crAccount.Debt);
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong input!");
                        Console.ResetColor();
                    }
                    WorkingWithCA(depAccount, crAccount, savAccount);
                    break;

                case 5:
                    if (crAccount.Debt != 0)
                    {
                        Console.WriteLine("How much money do you want to return? Enter your sum:");
                        decimal returnSum;

                        while (true)
                        {
                            if (!decimal.TryParse(Console.ReadLine(), out returnSum))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Wrong input!");
                                Console.ResetColor();
                            }

                            else
                            {
                                if (returnSum >= 0)
                                {
                                    try
                                    {
                                        crAccount.ReturnMoney(returnSum);
                                        Console.WriteLine("Your Balance: " + crAccount.Balance);
                                        Console.WriteLine("Your debt: " + crAccount.Debt);
                                        break;
                                    }
                                    catch (ArgumentException)
                                    {
                                        Console.WriteLine("You entered the wrong value! Choose another one!");
                                    }
                                }

                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Wrong input!");
                                    Console.ResetColor();
                                }
                            }
                        }

                        WorkingWithCA(depAccount, crAccount, savAccount);
                    }

                    else
                    {
                        Console.WriteLine("You dont have any debt! Choose another operation!");
                        WorkingWithCA(depAccount, crAccount, savAccount);
                    }

                    break;

                case 6:
                    Console.WriteLine("Your debt: " + crAccount.Debt);
                    WorkingWithCA(depAccount, crAccount, savAccount);
                    break;

                case 7:
                    Console.WriteLine("Your Balance: " + crAccount.Balance);
                    WorkingWithCA(depAccount, crAccount, savAccount);
                    break;

                case 0:
                    Beginning(depAccount, crAccount, savAccount);
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong input!");
                    Console.ResetColor();
                    WorkingWithCA(depAccount, crAccount, savAccount);
                    break;
            }

        }

        static void WorkingWithSA(DepositAccount depAccount, CreditAccount crAccount, SavingAccount savAccount)
        {

            Console.WriteLine("Choose your next step: ");
            Console.WriteLine("Press 1 to add money to your account");
            Console.WriteLine("Press 2 to withdraw money");
            Console.WriteLine("Press 3 to transfer money to another account");
            Console.WriteLine("Press 4 to save money from the deposit account");
            Console.WriteLine("Press 5 to check your Balance");
            Console.WriteLine("Press 0 to return");

            int key;

            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out key))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong input!");
                    Console.ResetColor();
                }

                else
                {
                    break;
                }
            }

            switch (key)
            {
                case 1:
                    Console.WriteLine("How much money do you want to add? Enter your sum: ");
                    decimal addSum;

                    while (true)
                    {
                        if (!decimal.TryParse(Console.ReadLine(), out addSum))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Wrong input!");
                            Console.ResetColor();
                        }

                        else
                        {
                            break;
                        }
                    }

                    if (addSum >= 0)
                    {
                        savAccount.AddMoney(addSum);

                        Console.WriteLine("Your Balance: " + savAccount.Balance);
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong input!");
                        Console.ResetColor();
                    }

                    WorkingWithSA(depAccount, crAccount, savAccount);
                    break;

                case 2:
                    if (savAccount.Balance != 0)
                    {
                        Console.WriteLine("How much money do you want to withdraw? Enter your sum: ");

                        while (true)
                        {
                            decimal withdrawSum;

                            if (!decimal.TryParse(Console.ReadLine(), out withdrawSum))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Wrong input!");
                                Console.ResetColor();
                            }

                            else
                            {
                                if (withdrawSum >= 0)
                                {
                                    try
                                    {
                                        savAccount.WithdrawMoney(withdrawSum);
                                        break;
                                    }
                                    catch (ArgumentException)
                                    {
                                        Console.WriteLine("You entered the wrong value! Choose another one");
                                    }
                                }

                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Wrong input!");
                                    Console.ResetColor();
                                    WorkingWithSA(depAccount, crAccount, savAccount);
                                }
                            }
                        }

                        Console.WriteLine("Your Balance: " + savAccount.Balance);
                    }

                    else
                    {
                        Console.WriteLine("You cant withdraw any money! Your account is empty! Try another operation");
                    }

                    WorkingWithSA(depAccount, crAccount, savAccount);
                    break;

                case 3:
                    if (savAccount.Balance > 0)
                    {
                        Console.WriteLine("Choose the account you want to transfer money to: ");
                        Console.WriteLine("Press 1 to transfer to deposit account");
                        Console.WriteLine("Press 2 to transfer to credit account");
                        Console.WriteLine("Press 0 to go back to the previous page");

                        int acc;

                        while (true)
                        {
                            if (!int.TryParse(Console.ReadLine(), out acc))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Wrong input!");
                                Console.ResetColor();
                            }

                            else
                            {
                                break;
                            }
                        }

                        switch (acc)
                        {
                            case 1:
                                Console.WriteLine("How much money do you want to transfer? Enter your sum: ");
                                while (true)
                                {
                                    decimal depTransferSum;

                                    if (!decimal.TryParse(Console.ReadLine(), out depTransferSum))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Wrong input!");
                                        Console.ResetColor();
                                    }

                                    else
                                    {
                                        if (depTransferSum >= 0)
                                        {
                                            try
                                            {
                                                savAccount.TransferMoney(depTransferSum, depAccount);
                                                Console.WriteLine("Your Balance: " + savAccount.Balance);
                                                break;
                                            }
                                            catch (ArgumentException)
                                            {
                                                Console.WriteLine("You entered the wrong value! Choose another one");
                                            }
                                        }

                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Wrong input!");
                                            Console.ResetColor();
                                        }
                                    }
                                }

                                WorkingWithSA(depAccount, crAccount, savAccount);
                                break;

                            case 2:
                                Console.WriteLine("How much money do you want to transfer? Enter your sum: ");

                                while (true)
                                {
                                    decimal crTransferSum;

                                    if (!decimal.TryParse(Console.ReadLine(), out crTransferSum))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Wrong input!");
                                        Console.ResetColor();
                                    }

                                    else
                                    {
                                        if (crTransferSum >= 0)
                                        {
                                            try
                                            {
                                                crAccount.TransferMoney(crTransferSum, crAccount);
                                                Console.WriteLine("Your Balance: " + savAccount.Balance);
                                                break;
                                            }

                                            catch (ArgumentException)
                                            {
                                                Console.WriteLine("You entered the wrong value! Choose another one");
                                            }
                                        }

                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Wrong input!");
                                            Console.ResetColor();
                                        }
                                    }
                                }


                                WorkingWithSA(depAccount, crAccount, savAccount);
                                break;

                            case 0:
                                WorkingWithSA(depAccount, crAccount, savAccount);
                                break;

                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Wrong input!");
                                Console.ResetColor();
                                break;
                        }
                    }

                    else
                    {
                        Console.WriteLine("Your account is empty! Choose another operation!");
                    }

                    WorkingWithSA(depAccount, crAccount, savAccount);
                    break;

                case 4:
                    Console.WriteLine("How much money do you want to save? Enter your sum: ");
                    decimal saveSum;

                    while (true)
                    {
                        if (!decimal.TryParse(Console.ReadLine(), out saveSum))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Wrong input!");
                            Console.ResetColor();
                        }

                        else
                        {

                            if (saveSum >= 0)
                            {
                                try
                                {
                                    savAccount.SaveMoney(saveSum, depAccount);
                                    Console.WriteLine("Your Balance: " + savAccount.Balance);
                                    break;
                                }

                                catch (ArgumentException)
                                {
                                    Console.WriteLine("You entered the wrong value! There is not enough money on your deposit account. Choose another sum");
                                }
                            }

                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Wrong input!");
                                Console.ResetColor();
                            }
                        }
                    }
                    WorkingWithSA(depAccount, crAccount, savAccount);
                    break;

                case 5:
                    Console.WriteLine("Your Balance: " + savAccount.Balance);
                    WorkingWithSA(depAccount, crAccount, savAccount);
                    break;

                case 0:
                    Beginning(depAccount, crAccount, savAccount);
                    break;

                default:
                    WorkingWithSA(depAccount, crAccount, savAccount);
                    break;
            }

        }
    }
}
