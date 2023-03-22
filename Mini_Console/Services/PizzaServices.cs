using Mini_Console.Core.Models;
using Mini_Console.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Console.Services
{
    internal class PizzaServices : IService, IPizzaService
    {
        List<Pizza> pizzalist=new List<Pizza>();
        List<string> ingredients=new List<string>();

        public void Check(string name, string pricestr, string pizzasizestr)
        {
            Pizza pizza;
            while (string.IsNullOrWhiteSpace(name) || name.Length < 3 || name.Length > 10)
            {
                Helper.Print("Duzgun name daxil edin: ", ConsoleColor.Red);
                name = Console.ReadLine();
            }
            bool isDouble = double.TryParse(pricestr, out double price);
            while (!isDouble || price<=0)
            {
                Helper.Print("Duzgun price daxil edin: ", ConsoleColor.Red);
                pricestr = Console.ReadLine();
                isDouble = double.TryParse(pricestr, out price);
            }
        PIZZASIZE:
            Size pizzasize;
            if (pizzasizestr.ToUpper() == "SMALL")
            {
                pizzasize = Size.Small;

            }
            else if (pizzasizestr.ToUpper() == "MEDIUM")
            {
                pizzasize = Size.Medium;
            }
            else if (pizzasizestr.ToUpper() == "LARGE")
            {
                pizzasize = Size.Large;
            }
            else
            {
                Helper.Print("Duzgun size daxil edin: ", ConsoleColor.Red);
                pizzasizestr = Console.ReadLine();
                goto PIZZASIZE;
            }
            
            bool bingredient = true;
            Helper.Print("Pizzanin ingredientlerini daxil edin: ", ConsoleColor.DarkBlue);
            while (bingredient==true)
            {
                string ingredient = Console.ReadLine();
                ingredients.Add(ingredient);
                INGREDIENT:
                Helper.Print("Elave ingredient daxil etmek isteyirsinizmi? Yes/No   ", ConsoleColor.Magenta);
                string select = Console.ReadLine();
                Console.Clear();
                while (string.IsNullOrWhiteSpace(select))
                {
                    Helper.Print("Duzgun daxili edin: ", ConsoleColor.Red);
                    select = Console.ReadLine();
                }
                switch (select.ToUpper())
                {
                    case "YES":
                        bingredient = true;
                        Helper.Print("Ingredient: ", ConsoleColor.DarkBlue);
                        break;
                    case "NO":
                        bingredient= false;
                        break;
                    default: Helper.PrintLine("Duzgun daxil edin: ", ConsoleColor.Red);
                        goto INGREDIENT;
                }

            }
            pizza = new Pizza(name, price, pizzasize, ingredients);
            Create(pizza);

        }
        public void Create(Pizza pizza)
        {
            pizzalist.Add(pizza);
        }

        public void Show()
        {
            
            if(pizzalist.Capacity>=1)
            {
                foreach (Pizza item in pizzalist)
                {
                    Helper.PrintLine($"Name: {item.Name},    ID:  {item.Id},   Size:  {item.PizzaSize},   Price:  {item.Price}", ConsoleColor.DarkYellow);
                }
            }
            else
            {
                Helper.PrintLine("Pizza yoxdur", ConsoleColor.Red);
            }
            
        }

        public void ShowIngredients()
        {
            Show();
            Helper.Print("Enter iD for Ingredient:  ", ConsoleColor.DarkMagenta);
            int id = int.Parse(Console.ReadLine());
            Console.Clear();
            foreach (Pizza pizza in pizzalist)
            {
                if (pizza.Id == id)
                {
                    foreach (var item in pizza.Ingredients)
                    {
                        Helper.PrintLine(item, ConsoleColor.DarkCyan);
                    }
                }
            }
        }
    }
}
