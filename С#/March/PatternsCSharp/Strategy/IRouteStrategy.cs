using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsCSharp.Strategy
{
    internal interface IRouteStrategy
    {
        void BuildRoute(string source, string destination);
    }
    public class StepStrategy : IRouteStrategy
    {
        public void BuildRoute(string source, string destination)
        {
            Console.WriteLine($"Вышли из {source}");
            Console.WriteLine("Выбрали маршрут передвижения");
            Console.WriteLine($"Идём по маршруту из пункта {source} в пункт {destination}");

        }
    }
    public class BusStrategy : IRouteStrategy
    {
        public void BuildRoute(string source, string destination)
        {
            Console.WriteLine("Нашли подоходящий автобус и ближайшую остановку");
            Console.WriteLine($"Вышли из {source}");
            Console.WriteLine($"Идём из пункта {source} до остановки");
            Console.WriteLine("Ждём нужный автобус...");
            Console.WriteLine($"Едем до ближайшей остановки к {destination}");
            Console.WriteLine($"Идём от остановки до {destination}");
        }
    }
    public class AutoSt11rategy : IRouteStrategy
    {
        public void BuildRoute(string source, string destination)
        {
            throw new NotImplementedException();
        }
    }
}
