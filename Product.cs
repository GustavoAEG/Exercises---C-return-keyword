using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises___Fundamentals
{
    public class Product
    {
        public string Name { get; init; }

        public double? Price { get; init; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public double GetPrice()
        {
            if (Price.HasValue)
            {
                return Price.Value;
            }
            else
            {
                throw new InvalidOperationException("Price is not set.");
            }
        }

    }
}
