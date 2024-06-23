namespace PatternsCSharp.Decorator
{
    public class TomatoPizza : PizzaBase
    {
        private readonly PizzaBase pizza;

        public TomatoPizza(PizzaBase pizza = null)
        {
            this.pizza = pizza;
        }

        public override void MakePizza()
        {
            pizza?.MakePizza();
            Console.WriteLine("Добавляем ингредиенты для томатной пиццы!");
        }
    }

}
