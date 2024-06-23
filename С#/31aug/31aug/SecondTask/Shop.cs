using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31aug.SecondTask
{
    public class Shop
    {
        public string Name { get; set; }
        public string Description { get; set; }

        private Dictionary<Product, int> products;

        public Dictionary<Product, int> GetProducts() => products;

        public event NewProductEventHandler NewProducts;

        public Shop(string name, string description, Dictionary<Product, int> products)
        {
            Name = name;
            Description = description;
            this.products = products;
        }

        public void IncreaseProduct(Product product, int count)
        {
            if (count < 0) return;
            if (products.ContainsKey(product)) products[product]+= count;
            else products.Add(product, count);
            Console.WriteLine($"{Name}: Поступил товар {product} в количестве {count}!");
            NewProducts?.Invoke(this, new(product));
        }
        public void DecreaseProduct(Product product)
        {
            if (products.ContainsKey(product))
            {
                if (products[product] > 0)
                    products[product]--;
            }
        }

        public override string? ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Название магазина: {Name}");
            sb.AppendLine($"Описание магазина: {Description}");
            sb.AppendLine($"\tПродукты");
            foreach( var (product, count) in products)
            {
                sb.AppendLine($"{product} Кол-во: {count}");
            }
            return sb.ToString();
        }
    }
}
