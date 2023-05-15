using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_1
{
    public class TrafficLight
    {
        private string _name;
        protected Duration _durations;
        private LightColor _currentColor;

        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        public Duration Durations
        {
            get { return _durations; }
            private set { _durations = value; }
        }

        public LightColor CurrentColor
        {
            get { return _currentColor; }
            private set { _currentColor = value; }
        }

        public void SetColor(LightColor color) { CurrentColor = color; }
        public event Action<LightColor> ColorChanged;

        public TrafficLight()
        {
            CurrentColor = LightColor.Red;
            SetDuration(0.5f, 0.5f, 0.10f);
            ColorChanged += ColorChangedEvent;
        }

        public TrafficLight(float red, float yellow, float green)
        {
            CurrentColor = LightColor.Red;
            SetDuration(red, yellow, green);
            ColorChanged += ColorChangedEvent;
        }

        public TrafficLight CreateCopy()
        {
            TrafficLight light = (TrafficLight)MemberwiseClone();
            light.CurrentColor = CurrentColor;
            light.Durations = Durations;
            light.Name = Name;
            return light;
        }

        public void SetName(string s) { Name = s; }

        public virtual void RunFor(float time)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.Elapsed < TimeSpan.FromSeconds(time))
            {
                SwitchColor();
            }
        }

        public void SetDurationTimespan(TimeSpan red, TimeSpan yellow, TimeSpan green)
        {
            Durations = new Duration { RedDuration = red, YellowDuration = yellow, GreenDuration = green };
        }

        public void SetDuration(float red, float yellow, float green)
        {
            Durations = new Duration
            {
                RedDuration = TimeSpan.FromSeconds(red),
                YellowDuration = TimeSpan.FromSeconds(yellow),
                GreenDuration = TimeSpan.FromSeconds(green)
            };
        }

        public virtual void SwitchColor()
        {
            CurrentColor = GetNextColor(CurrentColor);
            OnColorChanged(CurrentColor);
            Thread.Sleep((int)GetDuration(CurrentColor).TotalSeconds);
        }

        private LightColor GetNextColor(LightColor currentColor)
        {
            switch (currentColor)
            {
                case LightColor.Red:
                    return LightColor.Yellow;
                case LightColor.Yellow:
                    return LightColor.Green;
                case LightColor.Green:
                    return LightColor.Red;
                default:
                    throw new ArgumentOutOfRangeException(nameof(currentColor));
            }
        }

        private TimeSpan GetDuration(LightColor color)
        {
            switch (color)
            {
                case LightColor.Red:
                    return Durations.GreenDuration;
                case LightColor.Yellow:
                    return Durations.RedDuration;
                case LightColor.Green:
                    return Durations.YellowDuration;
                default:
                    throw new ArgumentOutOfRangeException(nameof(color));
            }
        }

        public void ColorChangedEvent(LightColor color)
        {
            Console.WriteLine("Color changed to: " + color);
        }

        protected virtual void OnColorChanged(LightColor color)
        {
            ColorChanged?.Invoke(color);
        }
    }
}
