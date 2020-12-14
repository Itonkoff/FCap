using System;
using BMS.AccountSpecifications;
using BMS.Models;

namespace BMS.Accounts {
    public class PlatinumAccount : PlatinumSpecification, Account {
        public Guid AccountNumber { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string IdNumber { get; set; }
        public double PayAmount { get; set; }

        private double Balance { get; set; }
        private DateTime LastWithdrawalDate { get; set; }

        public PlatinumAccount()
        {
            Initialize();
        }


        public void Create(string firstName, string lastName, string idNumber, double payAmount)
        {
            AccountNumber = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            IdNumber = idNumber;
            PayAmount = payAmount;
        }


        public void Deposit(double amount)
        {
            Balance += amount;
        }


        public bool Withdraw(double amount)
        {
            if (CanWithdraw(amount))
            {
                Balance -= amount;
                LastWithdrawalDate = DateTime.Now;
                return true;
            }

            return false;
        }


        public bool AWeekHasPassed()
        {
            return (DateTime.Now - LastWithdrawalDate).TotalDays % 7 >= 1;
        }


        public bool WontExhaustOverdraft(double amount)
        {
            if (amount - Balance < 0)
            {
                var difference = amount - Balance;
                //Possibility of balance being negative
                //make Sure balance is positive
                difference *= -1;

                return CalculateOverdraftPercentage(difference) <= MaximumWithdrawalLimit;
            }

            return true;
        }

        /// <summary>
        /// Calculate overdraft Percentage
        /// </summary>
        /// <param name="balance"></param>
        /// <returns></returns>
        private double CalculateOverdraftPercentage(double balance)
        {
            if (balance < 0)
                return (balance / PayAmount) * 100;
            return 0;
        }

        /// <summary> 
        /// Check if withdrawal wont over exhaust overdraft
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        private bool CanWithdraw(double amount)
        {
            return AWeekHasPassed() && WontExhaustOverdraft(amount);
        }

        /// <summary>
        /// Account summary
        /// </summary>
        /// <returns></returns>
        public string ToString()
        {
            var accountSummary =
                $"Account    : {AccountNumber}\n" +
                $"Holder     : {FirstName} {LastName}" +
                $"Balance    : {Balance}\n" +
                $"Overdraft  : {CalculateOverdraftPercentage(Balance)}\n\n";

            if (LastWithdrawalDate != null)
            {
                accountSummary = $"{accountSummary}\n" +
                                 $"Last withdrawal: {LastWithdrawalDate.ToString("d")}\n\n";
            }

            return accountSummary;
        }
    }
}