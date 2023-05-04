using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.MoneyTransactions
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(',');
            List<BankAccount> list = new List<BankAccount>();
            for (int i = 0; i < input.Length; i++)
            {
                string[] arr = input[i].Split('-');
                BankAccount bankAccount = new BankAccount(int.Parse(arr[0]), double.Parse(arr[1]));
                list.Add(bankAccount);
            }
            string command = Console.ReadLine();
            while (command != "End")
            {
                try
                {
                    string[] tokens = command.Split(" ");
                    if (tokens[0] == "Deposit")
                    {
                        int accNumber = int.Parse(tokens[1]);
                        double amount = double.Parse(tokens[2]);
                        if (list.Any(x => x.AccountNumber == accNumber))
                        {
                          BankAccount bankAcc =   list.FirstOrDefault((x => x.AccountNumber == accNumber));
                            bankAcc.Deposit(amount);
                            Console.WriteLine($"Account {bankAcc.AccountNumber} has new balance: {bankAcc.Balance:f2}");
                        }
                        else
                        {
                            throw new ArgumentException("Invalid account!");
                        }
                    }
                    else if (tokens[0] == "Withdraw")
                    {
                        int accNumber = int.Parse(tokens[1]);
                        double amount = double.Parse(tokens[2]);
                        if (list.Any(x => x.AccountNumber == accNumber))
                        {
                            BankAccount bankAcc = list.FirstOrDefault((x => x.AccountNumber == accNumber));
                            bankAcc.Withdraw(amount);
                            Console.WriteLine($"Account {bankAcc.AccountNumber} has new balance: {bankAcc.Balance:f2}");
                        }
                        else
                        {
                            throw new ArgumentException("Invalid account!");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Invalid command!");
                    }

                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                    command = Console.ReadLine();
                }
            }
        }
    }
    public class BankAccount
    {
        public BankAccount(int accountNumber, double balance)
        {
            AccountNumber = accountNumber;
            Balance = balance;
        }

        public int AccountNumber { get; private set; }
        public double Balance { get; private set; }

        public void Deposit(double amount)
        {
            Balance = Balance + amount;
        }
        public void Withdraw(double amount)
        {
            if (amount > Balance)
            {
                throw new ArgumentException("Insufficient balance!");
            }
            Balance = Balance - amount;
        }
    }
}
