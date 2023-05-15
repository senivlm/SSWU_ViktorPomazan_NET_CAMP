using exercise_1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Home_task_8
{
    internal class CrossRoad
    {
        private Road northSouth;
        private Road eastWest;
        private TimeSpan stimulationStart;
        private TimeSpan stimulationEnd;
        private TimeSpan stimulationtime;

        public CrossRoad(float start, float end)
        {
            InitializeTrafficLights();
            InitializeRoads();
            SetInitialtDurations();

            stimulationStart = TimeSpan.FromSeconds(start);
            stimulationEnd = TimeSpan.FromSeconds(end + 1);
            stimulationtime = stimulationEnd - stimulationStart;
        }

        private void InitializeTrafficLights()
        {
            TrafficLight _northSouth = new TrafficLight();
            TrafficLight _southNorth = new TrafficLight();
            TrafficLight _westEast = new TrafficLight();
            TrafficLight _eastWest = new TrafficLight();

            _westEast.SetColor(LightColor.Green);
            _eastWest.SetColor(LightColor.Green);
        }

        private void InitializeRoads()
        {
            northSouth = new Road(new Lane(new TrafficLight()), new Lane(new TrafficLight()));
            eastWest = new Road(new Lane(new TrafficLight()), new Lane(new TrafficLight()));
        }

        private void SetInitialtDurations()
        {
            Duration duration = new Duration(0.50f, 0.5f, 0.7f);

            foreach (var lane in northSouth.GetLanes().Concat(eastWest.GetLanes()))
            {
                lane.TrafficLight.SetDuration(
                    duration.RedDuration.Seconds,
                    duration.YellowDuration.Seconds,
                    duration.GreenDuration.Seconds);
            }
        }

        public CrossRoad(
            TrafficLight northSouthtl, TrafficLight southNorth,
            TrafficLight westEast, TrafficLight eastWesttl,
            float stimulationStart1, float stimulationEnd1)
        {
            try
            {
                InitializeTrafficLights();

                Lane northsouthrl = new Lane(northSouthtl.CreateCopy());
                Lane southnorthrl = new Lane(southNorth.CreateCopy());
                northSouth = new Road(northsouthrl, southnorthrl);

                Lane eastWestrl = new Lane(eastWesttl.CreateCopy());
                Lane westEastrl = new Lane(westEast.CreateCopy());
                eastWest = new Road(westEastrl, eastWestrl);

                this.stimulationStart = TimeSpan.FromSeconds(stimulationStart1);
                this.stimulationEnd = TimeSpan.FromSeconds(stimulationEnd1 + 1);
                this.stimulationtime = stimulationEnd - stimulationStart;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public CrossRoad(Road northSouthroad, Road westEastRoad)
        {
            northSouth = northSouthroad.CreateCopy();
            eastWest = westEastRoad.CreateCopy();

            stimulationStart = TimeSpan.FromSeconds(0);
            stimulationEnd = TimeSpan.FromSeconds(6);
            stimulationtime = stimulationEnd - stimulationStart;
        }

        public CrossRoad(Road northSouthroad, Road westEastRoad, float stimulationStart1, float stimulationEnd1)
        {
            try
            {
                northSouth = northSouthroad.CreateCopy();
                eastWest = westEastRoad.CreateCopy();

                stimulationStart = TimeSpan.FromSeconds(stimulationStart1);
                stimulationEnd = TimeSpan.FromSeconds(stimulationEnd1 + 1);
                stimulationtime = stimulationEnd - stimulationStart;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        public void SetNorthLightTime(float red, float yellow, float green)
        {
            Duration duration = new Duration(red, yellow, green);
            Lane[] rls = northSouth.GetLanes();

            foreach (var item in rls)
            {
                item.TrafficLight.SetDuration(
                    duration.RedDuration.Seconds,
                    duration.YellowDuration.Seconds,
                    duration.GreenDuration.Seconds);
            }
        }

        public void SetEastLightTime(float red, float yellow, float green)
        {
            Duration duration = new Duration(red, yellow, green);
            Lane[] rls = eastWest.GetLanes();

            foreach (var item in rls)
            {
                item.TrafficLight.SetDuration(
                    duration.RedDuration.Seconds,
                    duration.YellowDuration.Seconds,
                    duration.GreenDuration.Seconds);
            }
        }

        public void SimulateCrossRoadWork(Stopwatch stopwatch)
        {
            Lane[] rls = northSouth.GetLanes();
            Lane[] rls2 = eastWest.GetLanes();

            Console.WriteLine($"t={stopwatch.Elapsed.TotalSeconds:N0} с");
            Console.WriteLine($"Свiтлофор:    Пн-Пд            Пд-Пн            Сх-Зх           Зх-Сх\nКолiр: \t\t{rls[0].TrafficLight.CurrentColor}\t\t{rls[1].TrafficLight.CurrentColor}\t\t{rls2[0].TrafficLight.CurrentColor}\t\t{rls2[1].TrafficLight.CurrentColor}");
        }

        public void StartSimulation()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Lane[] firstLane = northSouth.GetLanes();
            Lane[] secondLane = eastWest.GetLanes();

            while (stopwatch.Elapsed <= stimulationtime)
            {
                SimulateCrossRoadWork(stopwatch);
                SwitchLights(firstLane);
                SwitchLights(secondLane);

                Console.WriteLine();
                Thread.Sleep(1000);
            }
        }

        private void SwitchLights(Lane[] lanes)
        {
            foreach (var item in lanes)
            {
                item.TrafficLight.SwitchColor();
            }
        }
    }
}


