using Mini_Console.Core.Models;
using Mini_Console.Services;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Mini_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            PizzaServices services = new PizzaServices();
            Helper.PrintLine("PizzaMizzaya Xosh gelmisiniz...", ConsoleColor.Green);
             CHOOSE:
            Helper.PrintLine("1. Menu", ConsoleColor.Magenta);
            Helper.PrintLine("2. Create Pizza", ConsoleColor.Magenta);
            string choose = Console.ReadLine();
            Console.Clear();
            switch (choose)
            {
                case "1":
                    services.Show();
                    Helper.PrintLine("0. Back to Menu", ConsoleColor.Magenta);
                    Helper.PrintLine("1. Show Ingredients", ConsoleColor.Magenta);
                    string choose1 = Console.ReadLine();
                    Console.Clear();
                    switch (choose1)
                    {
                        case "0":
                            goto CHOOSE;

                        case "1":
                            services.ShowIngredients();
                            goto CHOOSE;
                    }

                    break;
                case "2":
                    Helper.Print("Pizza adini daxil edin: ", ConsoleColor.DarkBlue);
                    string name = Console.ReadLine();
                    Helper.Print("Pizza qiymetini daxil edin: ", ConsoleColor.DarkBlue);
                    string pricestr = Console.ReadLine();
                    Helper.Print("Pizza type daxil edin: Small/Medium/Large: ", ConsoleColor.DarkBlue);
                    string pizzasize = Console.ReadLine();
                    services.Check(name, pricestr, pizzasize);
                    goto CHOOSE;
                default: Helper.Print("Duzgun daxil edin:  ", ConsoleColor.Red);
                    goto CHOOSE;
            }
        }
    }
}
