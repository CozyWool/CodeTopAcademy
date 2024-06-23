namespace PatternsCSharp.Decorator
{
    public class MeatPizza : PizzaBase
    {
        private readonly PizzaBase pizza;

        public MeatPizza(PizzaBase pizza = null)
        {
            this.pizza = pizza;
        }
        public override void MakePizza()
        {
            pizza?.MakePizza();
            Console.WriteLine("Добавляем ингредиенты для мясной пиццы!");
        }
    }

}
