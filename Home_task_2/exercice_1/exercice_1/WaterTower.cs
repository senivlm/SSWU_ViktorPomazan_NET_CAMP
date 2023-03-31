using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercice_1
{
    internal abstract class WaterTower
    {
        private Pump _pump;
        private readonly int _сapacity;
        private double _currentLevel;

        public WaterTower(Pump pump, int сapacity)
        {
            if (сapacity < 0)
            {
                Console.WriteLine("Capacity should be positive");
            }
            _сapacity = сapacity;
            _pump = pump;
        }

        public abstract void GiveWater(int consumption);

        public override string? ToString()
        {
            return $"Current level of water is {_currentLevel}, pump in tower is {_pump}";
        }
    }
}
