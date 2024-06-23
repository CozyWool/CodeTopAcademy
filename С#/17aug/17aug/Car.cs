using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17aug
{
    /// <summary>
    /// Класс Автомобиль для передачи характеристик об автомобиле
    /// </summary>
    public class Car
    {
        /// <param name="Name">
        /// Передается название модели автомобилия
        /// Тип данных <see cref="string"/> для модели
        /// </param>
        public string Name { get; set; }
        /// <param name="Year">
        /// Передается год модели автомобилия
        /// Тип данных <see cref="DateTime"/> для модели
        /// </param>
        public DateTime Year { get; set; }
        /// <param name="Color">
        /// Передается цвет модели автомобилия
        /// Тип данных <see cref="string"/> для модели
        /// </param>
        public string Color { get; set; }
    }
}
