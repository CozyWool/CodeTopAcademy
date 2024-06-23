using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16._05_HW
{
    public class Journal
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        public string PhoneNumber { get; set; }
        public int WorkersCount { get; set; }

        public Journal(string Name, string Email, string Description, string PhoneNumber, int WorkersCount)
        {
            this.Name = Name;
            this.Email = Email;
            this.Description = Description;
            this.PhoneNumber = PhoneNumber;
            this.WorkersCount = WorkersCount;
        }
        public Journal(Journal j) : this(j.Name, j.Email, j.Description, j.PhoneNumber, j.WorkersCount) { }
        public Journal() : this("none", "none", "none", "none", 0) { }

        public static Journal operator +(Journal j, int workers)
        {
            var journal = new Journal(j);
            journal.WorkersCount += workers;
            return journal;
        }
        public static Journal operator -(Journal j, int workers)
        {
            var journal = new Journal(j);
            journal.WorkersCount -= workers;
            return journal;
        }

        public static bool operator <(Journal j1, Journal j2) => j1.WorkersCount < j2.WorkersCount;
        public static bool operator >(Journal j1, Journal j2) => j1.WorkersCount > j2.WorkersCount;
        public static bool operator ==(Journal j1, Journal j2) => j1.WorkersCount == j2.WorkersCount;
        public static bool operator !=(Journal j1, Journal j2) => !(j1 == j2);
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj is not Journal j) return false;
            return j.WorkersCount == WorkersCount;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Название журнала: {Name}\n");
            sb.Append($"Описание журнала: {Description}\n");
            sb.Append($"E-mail журнала: {Email}\n");
            sb.Append($"Контактный телефон журнала: {PhoneNumber}\n");
            sb.Append($"Кол-во работников журнала: {WorkersCount}\n");
            return sb.ToString();
        }
    }
}
