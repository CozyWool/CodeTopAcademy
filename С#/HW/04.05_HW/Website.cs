using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04._05_HW
{
    public class Website
    {
        private string title;
        private string url;
        private string description;
        private string ipAddress;
        public Website(string Title, string Url, string Description, string IpAddress)
        {
            title = Title;
            url = Url;
            description = Description;
            ipAddress = IpAddress;
        }
        public Website() : this("none", "none", "none", "192.168.0.0") { }

        public string GetTitle()
        {
            return title;
        }
        public string GetUrl()
        {
            return url;
        }
        public string GetDescription()
        {
            return description;
        }
        public string GetIpAddress()
        {
            return ipAddress;
        }
        public void SetTitle(string value)
        {
            title = value;
        }
        public void SetUrl(string value)
        {
            url = value;
        }
        public void SetDescription(string value)
        {
            description = value;
        }
        public void SetIpAddress(string value)
        {
            ipAddress = value;
        }

        public void Input()
        {
            Console.Write("Введите название сайта:");
            SetTitle(Console.ReadLine());
            Console.Write("Введите описание сайта:");
            SetDescription(Console.ReadLine());
            Console.Write("Введите ссылку на сайт:");
            SetUrl(Console.ReadLine());
            Console.Write("Введите IP-адрес сайта:");
            SetIpAddress(Console.ReadLine());
        }
        public void Output()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Название сайта: {GetTitle()}\n");
            sb.Append($"Описание сайта: {GetDescription()}\n");
            sb.Append($"Ссылка на сайт: {GetUrl()}\n");
            sb.Append($"IP-адрес сайта: {GetIpAddress()}\n");
            Console.WriteLine(sb.ToString());
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Название сайта: {GetTitle()}\n");
            sb.Append($"Описание сайта: {GetDescription()}\n");
            sb.Append($"Ссылка на сайт: {GetUrl()}\n");
            sb.Append($"IP-адрес сайта: {GetIpAddress()}\n");
            return sb.ToString();
        }
    }
    
}
