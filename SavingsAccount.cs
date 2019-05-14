using System;

namespace Acumen.Bank.Account
{
    public class SavingsAccount
    {
        public string OwnerName { get; private set; }
        public double Balance { get; private set; }
        public double Rate { get; private set; }

        public SavingsAccount(string ownerName, double balance, double rate)
        {
            this.OwnerName = ownerName;
            this.Balance = balance;
            this.Rate = rate;
        }

        public void Deposit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Cannot deposit a negative amount");
            }
            this.Balance += amount;
        }

        public void TransferSave2Save(SavingsAccount destinationAccount, double amount, SavingsAccount sourceAccount)
        {
            if (amount > sourceAccount.Balance)
            {
                throw new ArgumentException("Source account too low");
            }
            else
            {
                destinationAccount.Deposit(amount);
                sourceAccount.Balance -= amount;
            }
        }

        public void Interest(double years)
        {
            // P1 = P(1+(r/n)^nt where P1 = the new principal sum
            // P = the original payment, r = the nominal annual interest rate
            // n = the compounding frequency, t = the overall length of time(usually in years)
            double P = this.Balance; // user investment + current bal.
            double r = this.Rate; // personalized rate for account
            double n = 1; // this will only compound once per year
            double t = years; // this is determined by the number of years the account is open
            double P1 = P * Math.Pow((1 + (r / n)), (n * t));
            double gain = Math.Round(P1 - P, 2);
            this.Balance += gain;
            Console.WriteLine("Interest Gained for " + this.OwnerName + " over " +
                years + " years " + gain.ToString());
            Console.WriteLine();
        }
    }
}
