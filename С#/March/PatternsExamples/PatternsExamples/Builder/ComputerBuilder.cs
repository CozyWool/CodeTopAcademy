namespace PatternsExamples.Builder
{
    // StringBuilder
    public class ComputerBuilder
    {
        private string _configuration = ""; //string.Empty

        public ComputerBuilder()
        {
            // \n <-> Environment.NewLine
            _configuration = "процессор\n" +
                             "материнская плата (с дискретной видеокартой)\n" +
                             "ОП\n" +
                             "жесткий диск\n" +
                             "кулер\n" +
                             "БП\n";
        }

        // добавить видеокарту
        public ComputerBuilder AddVideoCard(string model)
        {
            _configuration += $"Видеокарта, модель {model}\n";
            return this;
        }

        // мышка
        public ComputerBuilder AddMouse(string model)
        {
            _configuration += $"Мышь, модель {model}\n";
            return this;
        }

        // клавиатура
        public ComputerBuilder AddKeyboard(string model)
        {
            _configuration += $"Клавиатура, модель {model}\n";
            return this;
        }

        // монитор
        public ComputerBuilder AddMonitor(string model)
        {
            _configuration += $"Монитор, модель {model}\n";
            return this;
        }

        // микрофон
        public ComputerBuilder AddMicrophone(string model)
        {
            _configuration += $"Микрофон, модель {model}\n";
            return this;
        }

        // строительство итогового объекта
        public string Build()
        {
            return _configuration;
        }
    }
}