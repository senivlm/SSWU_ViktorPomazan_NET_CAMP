using System.Collections.ObjectModel;
using exercise_7b.Interfaces;

namespace exercise_7b
{
    public class TrafficLight
    {
        private List<string> _directions;
        private List<Road> _roads = new List<Road>();
        private int _timer;
        private int _currentTime = 0;

        public int Timer
        {
            get { return _timer; }
        }

        public int CurrentTime
        {
            get { return _currentTime; }
        }

        public List<Road> Roads
        {
            get { return _roads; }
        }
        public List<string> Directions
        {
            get { return _directions; }
        }

        public TrafficLight(List<string> directions, int t = 1)
        {
            _timer = t;
            _directions = directions;
        }

        public void AddRoad(Road road)
        {
            _roads.Add(road);
        }

        public void UpdateTime(int timer)
        {
            _timer = timer;
        }

        public void TrafficLightOn(Action printMethod)
        {
            printMethod();
            Thread.Sleep(_timer * 1000);
            _currentTime += _timer;
        }
    }

    public class Road
    {
        public string Name { get; set; }
        public List<Lane> Lanes { get; set; }

        public Road(string name)
        {
            Name = name;
            Lanes = new List<Lane>();
        }

        public void AddLane(Lane lane)
        {
            Lanes.Add(lane);
        }
    }

    public class Lane
    {
        public string Name { get; set; }
        public TrafficLight TrafficLight { get; set; }

        public Lane(string name, TrafficLight trafficLight)
        {
            Name = name;
            TrafficLight = trafficLight;
        }
    }
}