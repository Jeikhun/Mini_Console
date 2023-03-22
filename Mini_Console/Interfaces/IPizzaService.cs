using Mini_Console.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Console.Interfaces
{
    internal interface IPizzaService
    {
        void Create(Pizza piza);
        void Show();
        void Check(string name, string price, string size);
        void ShowIngredients();
    }
}
