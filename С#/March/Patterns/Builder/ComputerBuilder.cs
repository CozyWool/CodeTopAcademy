using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Builder
{
    public class ComputerBuilder
    {
        private string configuration = "";

        public ComputerBuilder()
        {
            configuration = "Процессор\n" +
                "Материнская плата(с дискретной видеокартой\n" + 
                "ОЗУ\n" +
                "Жесткий диск\n" +
                "Кулер\n" +
                "БП\n";
        }
        // Добавить видеокарту
        public ComputerBuilder AddGPU(string model) 
        {
            configuration += $"Видеокарта, модель {model}\n";
            return this;
        }
        // Мышь
        public ComputerBuilder AddMouse(string model)
        {
            configuration += $"Мышь, модель {model}\n";
            return this;
        }
        // Клавиатура
        public ComputerBuilder AddKeyboard(string model)
        {
            configuration += $"Клавиатура, модель {model}\n";
            return this;
        }
        // Монитор
        public ComputerBuilder AddMonitor(string model)
        {
            configuration += $"Монитор, модель {model}\n";
            return this;
        }
        // Микрофон
        public ComputerBuilder AddMircophone(string model)
        {
            configuration += $"Микрофон, модель {model}\n";
            return this;
        }
        // строительство итогового объекта
        public string Build() 
        {
            return configuration;
        }
    }
}
