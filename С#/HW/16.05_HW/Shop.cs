using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16._05_HW
{
    public class Shop
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }
        public int Square { get; set; }

        public Shop(string Name, string Email, string Description, string Address, string PhoneNumber, int square)
        {
            this.Name = Name;
            this.Email = Email;
            this.Description = Description;
            this.Address = Address;
            this.PhoneNumber = PhoneNumber;
            Square = square;
        }
        public Shop(Shop s) : this(s.Name, s.Email, s.Description, s.Address, s.PhoneNumber, s.Square) { }
        public Shop() : this("none", "none", "none", "none", "none", 0) { }

        public static Shop operator +(Shop s, int square)
        {
            var shop = new Shop(s);
            shop.Square += square;
            return shop;
        }
        public static Shop operator -(Shop s, int square)
        {
            var shop = new Shop(s);
            shop.Square -= square;
            return shop;
        }

        public static bool operator<(Shop s1,Shop s2) => s1.Square < s2.Square;
        public static bool operator>(Shop s1,Shop s2) => s1.Square > s2.Square;
        public static bool operator==(Shop s1,Shop s2) => s1.Square == s2.Square;
        public static bool operator!=(Shop s1,Shop s2) => !(s1 == s2);
        public override bool Equals(object? obj)
        {
            if(obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj is not Shop s) return false;
            return s.Square == Square;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Название магазина: {Name}\n");
            sb.Append($"Описание магазина: {Description}\n");
            sb.Append($"E-mail магазина: {Email}\n");
            sb.Append($"Контактный телефон магазина: {PhoneNumber}\n");
            sb.Append($"Адрес магазина: {Address}\n");
            return sb.ToString();
        }
    }
}
