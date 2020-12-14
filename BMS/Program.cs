using System;
using System.Collections.Generic;
using System.Linq;
using BMS.Accounts;

namespace BMS {
    class Program {
        public static List<SavingsAccount> SavingsAccounts = new List<SavingsAccount>();
        public static List<CurrentAccount> CurrentAccounts = new List<CurrentAccount>();
        public static List<PlatinumAccount> PlatinumAccounts = new List<PlatinumAccount>();

        static void Main(string[] args)
        {
            Console.WriteLine($"Choose Action\n" +
                              $"====================\n" +
                              $"1 => Create account\n" +
                              $"2 => Deposit\n" +
                              $"3 => WithDraw\n");

            var actionSelection = Console.ReadLine();
            if (string.IsNullOrEmpty(actionSelection))
                Main(args);

            switch (int.Parse(actionSelection))
            {
                case 1:
                    CreateAccount(args);
                    break;
                case 2:
                    Deposit(args);
                    break;
                case 3:
                    Withdraw(args);
                    break;
                default:
                    Main(args);
                    break;
            }
        }

        private static void Withdraw(string[] args)
        {
            switch (GetAccountType())
            {
                case 1:
                    var savingsAccount = SavingsAccounts
                        .SingleOrDefault(a =>
                            a.AccountNumber.ToString().Equals(GetAccountNumber()));
                    if (savingsAccount != null && savingsAccount.Withdraw(GetAmount()))
                    {
                        Console.WriteLine(savingsAccount.ToString());
                    }
                    else
                        Console.WriteLine("Failed to withdraw");

                    break;
                case 2:
                    var currentAccount = CurrentAccounts
                        .SingleOrDefault(a =>
                            a.AccountNumber.ToString().Equals(GetAccountNumber()));
                    if (currentAccount != null && currentAccount.Withdraw(GetAmount()))
                        Console.WriteLine(currentAccount.ToString());
                    else
                        Console.WriteLine("Failed to withdraw");

                    break;
                case 3:
                    var platinumAccount = PlatinumAccounts
                        .SingleOrDefault(a =>
                            a.AccountNumber.ToString().Equals(GetAccountNumber()));
                    if (platinumAccount != null && platinumAccount.Withdraw(GetAmount()))
                        Console.WriteLine(platinumAccount.ToString());
                    else
                        Console.WriteLine("Failed to withdraw");

                    break;
            }

            Main(args);
        }

        private static double GetAmount()
        {
            Console.Write("Amount?: ");
            return double.Parse(Console.ReadLine());
        }

        private static string GetAccountNumber()
        {
            Console.Write("Account number?: ");
            return Console.ReadLine();
        }

        private static int GetAccountType()
        {
            Console.WriteLine($"Choose Account Type\n" +
                              $"===================\n" +
                              $"1 => Savings\n" +
                              $"2 => Current\n" +
                              $"3 => Platinum\n");
            return int.Parse(Console.ReadLine());
        }

        private static void Deposit(string[] args)
        {
            switch (GetAccountType())
            {
                case 1:
                    var savingsAccount = SavingsAccounts
                        .SingleOrDefault(a =>
                            a.AccountNumber.ToString().Equals(GetAccountNumber()));
                    if (savingsAccount != null)
                    {
                        savingsAccount.Deposit(GetAmount());
                        Console.WriteLine(savingsAccount.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Account not found");
                    }

                    break;
                case 2:
                    var currentAccount = CurrentAccounts
                        .SingleOrDefault(a =>
                            a.AccountNumber.ToString().Equals(GetAccountNumber()));
                    if (currentAccount != null)
                    {
                        currentAccount.Deposit(GetAmount());
                        Console.WriteLine(currentAccount.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Account not found");
                    }

                    break;
                case 3:
                    var platinumAccount = PlatinumAccounts
                        .SingleOrDefault(a =>
                            a.AccountNumber.ToString().Equals(GetAccountNumber()));
                    if (platinumAccount != null)
                    {
                        platinumAccount.Deposit(GetAmount());
                        Console.WriteLine(platinumAccount.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Account not found");
                    }

                    break;
            }

            Main(args);
        }

        private static void CreateAccount(string[] args)
        {
            switch (GetAccountType())
            {
                case 1:
                    var savingsAccount = new SavingsAccount();
                    savingsAccount
                        .Create(GetFirstName(), GetLastName(), GetIdNumber(), GetPay(savingsAccount.MinimumPay, args));
                    var initialDeposit = InitialDeposit();
                    if (initialDeposit >= savingsAccount.BookBalance)
                    {
                        savingsAccount.Deposit(initialDeposit);
                        SavingsAccounts.Add(savingsAccount);
                        Console.WriteLine(savingsAccount.ToString());
                    }
                    else
                    {
                        Console.WriteLine($"Initial deposit must be a minimum of {savingsAccount.BookBalance}");
                    }

                    Main(args);
                    break;
                case 2:
                    var currentAccount = new CurrentAccount();
                    currentAccount.Create(GetFirstName(), GetLastName(), GetIdNumber(),
                        GetPay(currentAccount.MinimumPay, args));
                    currentAccount.Deposit(InitialDeposit());
                    CurrentAccounts.Add(currentAccount);
                    Console.WriteLine(currentAccount.ToString());
                    Main(args);
                    break;
                case 3:
                    var platinumAccount = new PlatinumAccount();
                    platinumAccount
                        .Create(GetFirstName(), GetLastName(), GetIdNumber(), GetPay(platinumAccount.MinimumPay, args));
                    platinumAccount.Deposit(InitialDeposit());
                    PlatinumAccounts.Add(platinumAccount);
                    Console.WriteLine(platinumAccount.ToString());
                    Main(args);
                    break;
            }
        }

        private static double InitialDeposit()
        {
            Console.WriteLine("Initial deposit?: ");
            return Convert.ToDouble(Console.ReadLine());
        }

        private static double GetPay(int minimumPay, string[] args)

        {
            Console.Write("Your pay? : ");
            var d = Convert.ToDouble(Console.ReadLine());
            if (d < minimumPay)
            {
                Console.WriteLine("\n\nYour pay is too little.\n\n");
                Main(args);
            }

            return d;
        }

        private static string GetIdNumber()
        {
            Console.Write("Id Number? : ");
            return Console.ReadLine();
        }

        private static string GetLastName()
        {
            Console.Write("Surname? : ");
            return Console.ReadLine();
        }

        private static string GetFirstName()
        {
            Console.Write("Name(s)? : ");
            return Console.ReadLine();
        }
    }
}