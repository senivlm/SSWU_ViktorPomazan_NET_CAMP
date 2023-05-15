using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_1
{
    public struct Duration
    {
        public TimeSpan RedDuration;
        public TimeSpan YellowDuration;
        public TimeSpan GreenDuration;
        public Duration(TimeSpan redDuration, TimeSpan yellowDuration, TimeSpan greenDuration)
        {
            RedDuration = redDuration;
            YellowDuration = yellowDuration;
            GreenDuration = greenDuration;
        }
        public Duration(int hours, int minutes, int seconds)
        {
            RedDuration = new TimeSpan(hours, minutes, seconds);
            YellowDuration = new TimeSpan(hours, minutes, seconds);
            GreenDuration = new TimeSpan(hours, minutes, seconds);
        }
        public Duration(float hours, float minutes, float seconds)
        {
            RedDuration = new TimeSpan((int)hours, (int)minutes, (int)seconds);
            YellowDuration = new TimeSpan((int)hours, (int)minutes, (int)seconds);
            GreenDuration = new TimeSpan((int)hours, (int)minutes, (int)seconds);
        }
    }
}
