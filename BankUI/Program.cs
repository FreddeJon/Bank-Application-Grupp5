﻿using BankLogic;
using System;
using System.Collections.Generic;
using System.Threading;

namespace BankUI
{
    public static class Program
    {
        static void Main(string[] args)
        {
            //Menyn
            bool quit = false;
            do
            {
                Bank.ReadFromDB();
                MainHeader();
                Console.WriteLine("1. Add new customer\n2. Select Customer\n3. Show all customers\n4. Exit");
                _ = Int32.TryParse(Console.ReadLine(), out int menu);
                switch (menu)
                {
                    case 1: // Adds a new user, logic inside Class Add
                        if (Add.Customer())
                        {
                            Console.WriteLine("Customer added");
                            Clear();
                        }
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        Select.Customer();
                        break;
                    case 3:
                        foreach (var customer in Bank.GetCustomers())
                        {
                            Console.WriteLine(customer.ToString());
                        }
                        Console.WriteLine("Enter to continue");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 4:
                        quit = true;
                        break;
                    default:
                        Console.Clear();
                        break;
                }
                Bank.SaveToDB();



            } while (!quit);
        }


        public static string FirstToUpper(this string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                string temp = name.ToLower();
                string save = string.Empty;
                save += char.ToUpper(temp[0]);
                save += temp[(0 + 1)..];
                name = save;
                return save;
            }
            return name;
        }

        public static void Clear()
        {
            Thread.Sleep(700);
            Console.Clear();
        }



        public static void MainHeader()
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("-----------------------");
        }
    }
}
