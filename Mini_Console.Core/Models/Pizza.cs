using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Console.Core.Models
{
    public class Pizza
    {
        public List<string> Ingredients = new List<string>();
        public string Name { get; set; }
        public double Price { get; set; }
        public int Id { get; set; }
        private static int _id=0;
        public Size PizzaSize { get; set; }
        public Pizza(string name, double price, Size size, List<string> ingredients)
        {
            Name = name;
            Price = price;
            Id = _id++;
            PizzaSize = size;
            Ingredients = ingredients;
        }
    }
    public enum Size
    {
        Small,
        Medium,
        Large,
    }
}
