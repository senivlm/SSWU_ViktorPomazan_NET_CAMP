using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercice_1
{
    internal abstract class User
    {
        private double _consumption;

        private double _using = 0;


        public double Сonsumption
        { 
            get {
                return 
                    _consumption - _using; 
            } 
        }

        public User(double consumption)
        {
            if (consumption < 0)
                Console.WriteLine("Consumption can`t be less than 0");
            _consumption = consumption;
        }

        public abstract void UseWater(WaterTower waterTower);

        public override string? ToString()
        {
            return $"User consumption is {_consumption}, using water is {_using}";
        }
    }
}
