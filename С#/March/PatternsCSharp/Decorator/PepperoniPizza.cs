namespace PatternsCSharp.Decorator
{
    public class PepperoniPizza : PizzaBase
    {
        private readonly PizzaBase pizza;

        public PepperoniPizza(PizzaBase pizza = null)
        {
            this.pizza = pizza;
        }
        public override void MakePizza()
        {
            pizza?.MakePizza();
            Console.WriteLine("Добавляем ингредиенты для пепперони!");
        }
    }

}
