using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31aug.SecondTask
{
    public class Client
    {
        public string Name { get; set; }
        public int Money { get; set; }
        public Dictionary<Product, int> Products { get; private set; }
        public List<Product> WantedProducts { get; private set; } = new();

        public Client(string name, int money, Dictionary<Product, int> products)
        {
            Name = name;
            Money = money;
            Products = products;
        }
        public Client(string name, int money) : this(name, money, new()) { }

        public void BuyProduct(Shop shop, Product product)
        {
            if (!shop.GetProducts().ContainsKey(product))
            {
                Console.WriteLine($"{Name}: Товара {product.Name} нет в магазине!");
                return;
            }
            if (Money < product.Price)
            {
                Console.WriteLine($"{Name}: Не хватило денег на покупку товара {product.Name}; Баланс на счёте:{Money}");
                return;
            }

            if (shop.GetProducts()[product] <= 0)
            {
                Console.WriteLine($"В магазине {shop.Name} не было {product.Name}. " +
                    $"Клиент {Name} оставил свои контакты в магазине");
                shop.NewProducts += OnNewProducts;
                WantedProducts.Add(product);
                return;
            }

            shop.GetProducts()[product]--;
            // Почему-то тернарным оператором не получилось
            if (Products.ContainsKey(product)) Products[product]++;
            else Products.Add(product, 1);
            Money -= product.Price;
            Console.WriteLine($"{Name} покупает {product} в {shop.Name}");
        }

        private void OnNewProducts(object sender, NewProductEventArgs e)
        {
            if (sender is Shop s)
            {
                var foundProducts = s.GetProducts().Where(product => WantedProducts.Contains(product.Key)).ToList();
                foreach (var (product, count) in foundProducts)
                {
                    Console.WriteLine($"{Name}: Получено уведомление о поступлении {product} в {s.Name}!");
                    BuyProduct(s, product);
                    WantedProducts.Remove(product);
                }
            }
        }

        public override string? ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Имя: {Name}");
            sb.AppendLine($"Деньги: {Money} р.");
            sb.AppendLine($"\tКупленные продукты");
            if (Products.Count == 0)
                sb.AppendLine("Купленных продуктов пока нет...");
            else
            {
                foreach (var (product, count) in Products)
                    sb.AppendLine($"{product} Кол-во: {count}");
            }

            sb.AppendLine($"\tЖелаемые продукты");
            if (WantedProducts.Count == 0)
                sb.AppendLine("Желаемых продуктов пока нет...");
            else
            {
                foreach (var product in WantedProducts)
                    sb.AppendLine($"{product}");
            }
            return sb.ToString();
        }
    }
}
