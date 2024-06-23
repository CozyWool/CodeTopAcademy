using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsCSharp.Facade
{
    public class KeychanFacade
    {
        private readonly Spotlight spotlight;
        private readonly Engine engine;
        private readonly SeatHeating seatHeating;
        private readonly MirrorHeating mirrorHeating;

        public KeychanFacade(Spotlight spotlight,
            Engine engine, 
            SeatHeating seatHeating, 
            MirrorHeating mirrorHeating)
        {
            this.spotlight = spotlight;
            this.engine = engine;
            this.seatHeating = seatHeating;
            this.mirrorHeating = mirrorHeating;
        }
        public void StartAuto()
        {
            // Включать фары
            spotlight.Blink();
            // Запускать двигатель
            engine.Start();
            // Подогрев сидений
            seatHeating.Heat();
            // Подогрев зеркал
            mirrorHeating.Heat();
        }
    }
}
