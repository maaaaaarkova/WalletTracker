using System;
using System.Collections.Generic;
using System.Text;

namespace WalletTracker
{
    public class DepositAccount : Account
    {
        private const double coldWaterPrice = 30.25;
        private const double hotWaterPrice = 80.58;
        private const double household = 5.37;
        public int HotWaterData { get; set; }
        public int ColdWaterData { get; set; }
        public decimal AllHotWater { get; private set; }
        public decimal AllColdWater { get; private set; }
        public decimal AllHouseHold { get; private set; }
        

        public DepositAccount()
        {
            Balance = 0;
            HotWaterData = 0;
            ColdWaterData = 0;
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
        
        public void HouseholdExpenses(int square)
        {
          
            if ((decimal)(square * household) > Balance)
            {
                throw new ArgumentException("Not enough money");
            }

            Balance = Balance - (decimal)(square * household);
            AllHouseHold += (decimal)(square * household);
        }

        public void HotWaterBills(int data)
        {
            if (data < HotWaterData)
            {
                throw new ArgumentException("Wrong input");
            }

            decimal pay;
            pay = (decimal)(data - HotWaterData) * (decimal)hotWaterPrice;

            if (pay > Balance)
            {
                throw new ArgumentException("Not enough money");
            }

            Balance -= pay;
            HotWaterData = data;
            AllHotWater += pay;

        }

        public void ColdWaterBills(int data)
        {
            if (data < ColdWaterData)
            {
                throw new ArgumentException("Wrong input");
            }

            decimal pay;
            pay = (decimal)(data - ColdWaterData) * (decimal)coldWaterPrice;

            if (pay > Balance)
            {
                throw new ArgumentException("Not enough money");
            }

            Balance -= pay;
            ColdWaterData = data;
            AllColdWater += pay;

        }
    }
}
