using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_1
{
    internal class Road
    {
        private List<Lane> _laneList;

        public Road()
        {
            TrafficLight northSouth = new TrafficLight(0.50f, 0.5f, 0.7f);
            northSouth.SetName("North-South Light");

            TrafficLight southNorth = new TrafficLight(0.50f, 0.5f, 0.7f);
            southNorth.SetName("South-North Light");

            Lane northSouthLane = new Lane(northSouth);
            Lane southNorthLane = new Lane(southNorth);

            _laneList = new List<Lane> { northSouthLane, southNorthLane };
        }
        public Road CreateCopy()
        {
            Road road = (Road)this.MemberwiseClone();
            road._laneList = this._laneList;
            return road;

        }
        public Lane[] GetLanes()
        {
            return _laneList.ToArray();
        }

        public Road(params Lane[] lanes)
        {
            _laneList = new List<Lane>(lanes);
        }
    }
}

