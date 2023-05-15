using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_1
{
    public class Lane
    {
        public TrafficLight TrafficLight { get; private set; }

        public Lane()
        {
            TrafficLight = new TrafficLight();
        }

        public Lane(TrafficLight tl)
        {
            TrafficLight = tl.CreateCopy();
        }

        public Lane CreateCopy()
        {
            Lane lane = (Lane)MemberwiseClone();
            lane.TrafficLight = TrafficLight.CreateCopy();
            return lane;
        }
    }
}
