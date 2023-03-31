using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercice_1
{
    internal abstract class Pump
    {
        private readonly double _power;
        private bool _isOn = false;
        public bool IsOn 
        { 
            get 
            { 
                return _isOn; 
            } 
            set 
            {
                _isOn = value; 
            } 
        }

        public Pump(double power)
        {
            if (power < 0)
                Console.WriteLine("Power can't be less then 0");
            _power = power;
        }
        

        public abstract void ChangePumpState();

        public override string ToString()
        {
            return $"Power of pump is {_power}, state is {_isOn}";
        }
    }
}
