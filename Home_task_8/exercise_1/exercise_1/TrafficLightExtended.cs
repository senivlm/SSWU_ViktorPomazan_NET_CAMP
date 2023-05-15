using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace exercise_1
{
    public class TrafficLightExtended : TrafficLight
    {
        private bool _turnRegulation = false;
        private TimeSpan _turnRegulationInterval;
        public event Action<bool> TurnWorks;
        private Stopwatch _stopwatch = new Stopwatch();

        public TrafficLightExtended() : base()
        {
            _turnRegulationInterval = TimeSpan.FromSeconds(5);
            TurnWorks += OnTurnWorks;
        }

        public TrafficLightExtended(float time) : base()
        {
            _turnRegulationInterval = TimeSpan.FromSeconds(time);
            TurnWorks += OnTurnWorks;
        }

        public TrafficLightExtended DeepCopy(Duration d)
        {
            TrafficLightExtended tltr = (TrafficLightExtended)MemberwiseClone();
            tltr._turnRegulationInterval = _turnRegulationInterval;
            tltr.SetDuration(d.RedDuration.Seconds, d.YellowDuration.Seconds, d.GreenDuration.Seconds);
            tltr.SetColor(CurrentColor);
            return tltr;
        }

        public override void SwitchColor()
        {
            _stopwatch.Start();

            if (_stopwatch.Elapsed < _turnRegulationInterval)
            {
                Task.Run(() => StartTurnRegulation());
            }
            else
            {
                Task.Run(() => StopTurnRegulation());
                PerformColorSwitch();
            }
        }

        private void PerformColorSwitch()
        {
            switch (CurrentColor)
            {
                case LightColor.Red:
                    SwitchToYellow();
                    break;

                case LightColor.Yellow:
                    SwitchToGreen();
                    break;

                case LightColor.Green:
                    SwitchToRed();
                    break;
            }
        }

        private void SwitchToYellow()
        {
            SetColor(LightColor.Yellow);
            OnColorChanged(CurrentColor);
            Thread.Sleep(Durations.GreenDuration);
        }

        private void SwitchToGreen()
        {
            SetColor(LightColor.Green);
            OnColorChanged(CurrentColor);
            Thread.Sleep(Durations.RedDuration);
        }

        private void SwitchToRed()
        {
            SetColor(LightColor.Red);
            OnColorChanged(CurrentColor);
            Thread.Sleep(Durations.YellowDuration);
        }
        public override void RunFor(float time)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.Elapsed < TimeSpan.FromSeconds(time))
            {
                SwitchColor();
                if (stopwatch.Elapsed < _turnRegulationInterval)
                {
                    StartTurnRegulation();
                }
                else
                {
                    StopTurnRegulation();
                }
            }
        }

        public void StartTurnRegulation()
        {
            _turnRegulation = true;
            OnTurnWorks(_turnRegulation);
        }

        public void StopTurnRegulation()
        {
            _turnRegulation = false;
            OnTurnWorks(_turnRegulation);
        }

        protected virtual void OnTurnWorks(bool isWorking)
        {
            if (isWorking)
            {
                if (Name != null)
                    Console.Write(Name + "'s " + "Turn works.\t");
                else
                    Console.Write("Turn works");
            }
            else
            {
                if (Name != null)
                    Console.Write(Name + "'s " + "Turn doesn't work");
            }
        }
    }
}