using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static program;

namespace Exercises___Fundamentals
{
    public class SuperMarket
    {
        private Dictionary<string, Product> _catalog;

        private Dictionary<string, int?> _stock;

        public SuperMarket()
        {
            _catalog = new Dictionary<string, Product>();
            _stock = new Dictionary<string, int?>();

            var banana = new Product("Banana", 4.99);
            var arroz = new Product("Arroz", 4.99);
            var leite = new Product("Leite", 6.90);

            _catalog["Banana"] = banana;
            _catalog["Arroz"] = arroz;
            _catalog["Leite UHT"] = leite;

            _stock["Banana"] = 10;
            _stock["Arroz"] = 20;
            _stock["Leite"] = 15;
        }

        public double GetPriceByProductName(string productName)
        {
            if (_catalog.ContainsKey(productName))
            {
                return _catalog[productName].GetPrice();
            }
            else
            {
                return -1;
            }
        }

        public int GetStockByProductName(string productName)
        {
            if (_stock.Count > 0 && _stock.ContainsKey(productName))
            {
                return _stock[productName] ?? -1;
            }
            else
            {
                return -1;
            }
        }

        public List<string> ListCatalog()
        {
            var list = new List<string>();

            foreach (var item in _catalog)
            {
                string name = item.Key;
                double price = item.Value.Price ?? 0.0;
                list.Add($"{name} — R${price:0.00}");
            }
            return list;
        }
    }
}
