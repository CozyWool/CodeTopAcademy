using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsCSharp.Template
{
    public abstract class PizzaBase
    {
        // Раскатать тесто
        protected abstract void RollDough();

        // Добавляем ингредиенты
        protected abstract void AddIngredients();
        // Поставить пиццу в печь и приготовить
        protected abstract void PutInOven();

        public void MakePizza()
        {
            RollDough();
            AddIngredients();
            PutInOven();
            Console.WriteLine("Пицца готова!");
        }
    }
    public class TomatoPizza : PizzaBase
    {
        protected override void AddIngredients()
        {
            Console.WriteLine("Добавляем ингредиенты в томатную пиццу");
        }

        protected override void PutInOven()
        {
            Console.WriteLine("Ставим пиццу в печь");
        }

        protected override void RollDough()
        {
            Console.WriteLine("Раскатываем тесто для круглой томатной пиццы");
        }
    }
    public class MeatPizza : PizzaBase
    {
        protected override void AddIngredients()
        {
            Console.WriteLine("Добавляем ингредиенты в мясную пиццу");
        }

        protected override void PutInOven()
        {
            Console.WriteLine("Ставим пиццу в печь");
        }

        protected override void RollDough()
        {
            Console.WriteLine("Раскатываем тесто для квадратной мясную пиццы");
        }
    }
}
