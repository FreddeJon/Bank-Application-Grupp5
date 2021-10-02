﻿using BankLogic;
using System;
using System.Collections.Generic;

namespace BankUI
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Bank.ReadFromDB();
            bool quit = false;
             
            var path = AppDomain.CurrentDomain.BaseDirectory + "csv.txt";

            Console.WriteLine(path);
            do
            {
                Bank.ReadFromDB();
                var bankCustomers = Bank.GetCustomers();
                Console.WriteLine("1. Add new customer\n2. Select Account\n3. Show all customers\n4. Exit");
                _ = Int32.TryParse(Console.ReadLine(), out int menu);
                switch (menu)
                {
                    case 1:
                        Console.WriteLine("Name");
                        string name = Console.ReadLine();
                        Console.WriteLine("Lastname");
                        string lastName = Console.ReadLine();
                        Console.WriteLine("Social Number");
                        long socialNumber;
                        while (!long.TryParse(Console.ReadLine(), out socialNumber))
                        {
                            Console.WriteLine("Invalid enter social number 12 numbers.");
                        }
                        if (Bank.AddCustomer(name, lastName, socialNumber))
                        {
                            Console.WriteLine("Customer added");
                            Customer.SaveToDB();
                        }
                        else
                        {
                            Console.WriteLine("invalid inp");
                        }
                        break;
                    case 2:
                        for (int i = 0; i < bankCustomers.Count; i++)
                        {
                            Console.WriteLine($"[{i}]{bankCustomers[i]} ");
                        }

                        Int32.TryParse(Console.ReadLine(), out int select);
                        bankCustomers[select].CreateAccount();
                        bankCustomers[select].CreateAccount();
                        bankCustomers[select].CreateAccount();
                        bankCustomers[select].CreateAccount();

                        foreach (var account in bankCustomers[select].CustomerAccounts)
                        {
                            Console.WriteLine(account.ToString());
                        }
                        foreach (var account in bankCustomers[select].CustomerAccounts)
                        {
                            account.Deposit(10000);

                        }
                        foreach (var account in bankCustomers[select].CustomerAccounts)
                        {
                            Console.WriteLine(account.ToString());
                        }
                        Bank.SaveToDB();
                        break;
                    case 3:
                        foreach (var customer in bankCustomers)
                        {
                            Console.WriteLine(customer.ToString());
                        }
                        Console.ReadLine();
                        break;
                    case 4:
                        quit = true;
                        break;
                    case 5:
                        foreach (var customer in bankCustomers)
                        {
                            Console.WriteLine(customer.ToString());
                            foreach (var account in customer.CustomerAccounts)
                            {
                                Console.WriteLine(account.ToString());
                            }
                        }
                        break;
                    default:
                        break;
                }



                
            } while (!quit);


            //if (bank.AddCustomer("Fredrik", "Jonson", 199305079619))
            //{
            //    list = Bank.GetCustomers();
            //    Console.WriteLine($"Added {list[0].FullName}");
            //    bank.SaveToDB();
            //}

            //while (true)
            //{
            //    var currentCustomer = list[0];
            //    Console.WriteLine(currentCustomer.ToString());
            //    foreach (var account in currentCustomer.CustomerAccounts)
            //    {
            //        Console.WriteLine(account.ToString());
            //    }
            //    Console.WriteLine("choose account");
            //    int currentAccount = 0;
            //    while (true)
            //    {
            //        currentAccount = int.Parse(Console.ReadLine());
            //        if (currentAccount > 0 && currentAccount <= currentCustomer.NumberOfAccounts)
            //        {
            //            break;
            //        }
            //        Console.WriteLine($"Invalid input 1-{currentCustomer.NumberOfAccounts}");
            //    }
            //    currentAccount--;
            //    while (true)
            //    {
            //        Console.WriteLine(currentCustomer.CustomerAccounts[currentAccount].ToString());
            //        Console.WriteLine("Enter amount to withdraw");
            //        decimal amount = decimal.Parse(Console.ReadLine());


            //        if (currentCustomer.CustomerAccounts[currentAccount].Withdraw(amount))
            //        {
            //            break;
            //        }
            //    }
            //}
        }
    }
}
