using System.Collections.ObjectModel;
using exercise_7b.Interfaces;

namespace exercise_7b
{
    public class TrafficLight
    {
        private List<string> _directions;
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

        public List<string> Directions
        {
            get { return _directions; }
        }

        public TrafficLight(List<string> directions, int t = 1)
        {
            _timer = t;
            _directions = directions;
        }

        public void UpdateTime(int t)
        {
            _timer = t;
        }

        public void TrafficLightOn(Action printMethod)
        {
            printMethod();
            Thread.Sleep(_timer * 1000);
            _currentTime += _timer;
        }
    }
}