using _18._07_HW.Enums;
using _18._07_HW.Interfaces;
using _18._07_HW.Parts;

namespace _18._07_HW
{
    public class House
    {
        public Basement Basement { get; set; }
        public List<Wall> Walls { get; set; }
        public Door Door { get; set; }
        public List<Window> Windows { get; set; }
        public Roof Roof { get; set; }

        private bool _isBuilded;

        public House()
        {
            Basement = new Basement();
            Walls = new List<Wall>(4)
            {
                new Wall(),
                new Wall(),
                new Wall(),
                new Wall()
            };
            Door = new Door();
            Windows = new List<Window>(4)
            {
                new Window(),
                new Window(),
                new Window(),
                new Window()
            };
            Roof = new Roof();
            _isBuilded = false;
        }

        public bool IsBasementReady() => Basement.IsBuilded;

        public bool IsWallsReady()
        {
            bool result = true;
            foreach (Wall wall in Walls)
            {
                if (!wall.IsBuilded)
                {
                    result = false;
                }
            }
            return IsBasementReady() && result;
        }
        public bool IsDoorReady() => IsWallsReady() && Door.IsBuilded;
        public bool IsWindowsReady()
        {
            bool result = true;
            foreach (Window window in Windows)
            {
                if (!window.IsBuilded)
                {
                    result = false;
                }
            }
            return IsDoorReady() && result;
        }
        public bool IsRoofReady() => IsWindowsReady() && Roof.IsBuilded;
        public bool IsHouseReady() => _isBuilded;


        public PartTypes WhatToDo()
        {
            if (_isBuilded) return PartTypes.None;
            if (IsWindowsReady()) return PartTypes.Roof;
            if (IsDoorReady()) return PartTypes.Window;
            if (IsWallsReady()) return PartTypes.Door;
            if (IsBasementReady()) return PartTypes.Wall;
            return PartTypes.Basement;
        }

        public void Build(IPart part)
        {
            part.IsBuilded = true;
            if (IsRoofReady())
            {
                _isBuilded = true;
            }
        }
    }
}
