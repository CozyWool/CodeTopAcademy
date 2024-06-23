namespace PatternsCSharp.Decorator
{
    public class ChessePizza : PizzaBase
    {
        private readonly PizzaBase pizza;

        public ChessePizza(PizzaBase pizza = null)
        {
            this.pizza = pizza;
        }
        public override void MakePizza()
        {
            pizza?.MakePizza();
            Console.WriteLine("Добавляем ингредиенты для сырной пиццы!");
        }
    }

}
