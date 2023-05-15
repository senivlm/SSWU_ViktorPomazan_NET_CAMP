using Home_task_8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_1
{
    public class Simulator
    {
        public void Simulate()
        {
            TrafficLightExtended trafficLightExtended = new TrafficLightExtended();
            trafficLightExtended.SetColor(LightColor.Green);
            trafficLightExtended.SetName("West-East Light");

            TrafficLight trafficLight = new TrafficLight(100, 200, 300);
            trafficLight.SetColor(LightColor.Green);
            trafficLight.SetName("East-West Light");

            Lane firstLane = new Lane(trafficLightExtended);
            Lane secondLane = new Lane(trafficLight);

            Road firstRoad = new Road(firstLane, secondLane);
            Road secondRoad = new Road();
            CrossRoad crossRoad = new CrossRoad(firstRoad, secondRoad, 0, 10);
            crossRoad.StartSimulation();
        }
    }
}
