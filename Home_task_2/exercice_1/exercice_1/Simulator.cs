using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercice_1
{//краще щоб симулятор сам створював башти, а користувачів мав змогу додавати та вилучати. Або ж робити генератор цих об'єктів за певною стратегією.
    internal abstract class Simulator
    {
        private readonly WaterTower _waterTower;
        private readonly List<User> _users;
        private readonly Pump _pump;

        public Simulator(WaterTower waterTower, List<User> users, Pump pump)
        {
            _waterTower = waterTower;
            _users = users;
            _pump = pump;
        }
        public abstract void CheckWaterState();
        public override string ToString()
        {
            return $"The simulator work with users - {_users}, water tower - {_waterTower}, pump: {_pump}";

        }
    }
}
