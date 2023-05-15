using exercise_1;
using System.Diagnostics;

namespace Home_task_8
{
    internal class CrossRoad
    {
        private Road northSouth;
        private Road eastWest;
        private TimeSpan simulationStart;
        private TimeSpan simulationEnd;
        private TimeSpan simulationTime;

        public CrossRoad(float start, float end)
        {
            InitializeTrafficLights();
            InitializeRoads();
            SetInitialtDurations();

            simulationStart = TimeSpan.FromSeconds(start);
            simulationEnd = TimeSpan.FromSeconds(end + 1);
            simulationTime = simulationEnd - simulationStart;
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

                this.simulationStart = TimeSpan.FromSeconds(stimulationStart1);
                this.simulationEnd = TimeSpan.FromSeconds(stimulationEnd1 + 1);
                this.simulationTime = simulationEnd - simulationStart;
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

            simulationStart = TimeSpan.FromSeconds(0);
            simulationEnd = TimeSpan.FromSeconds(6);
            simulationTime = simulationEnd - simulationStart;
        }

        public CrossRoad(Road northSouthroad, Road westEastRoad, float stimulationStart1, float stimulationEnd1)
        {
            try
            {
                northSouth = northSouthroad.CreateCopy();
                eastWest = westEastRoad.CreateCopy();

                simulationStart = TimeSpan.FromSeconds(stimulationStart1);
                simulationEnd = TimeSpan.FromSeconds(stimulationEnd1 + 1);
                simulationTime = simulationEnd - simulationStart;
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

            while (stopwatch.Elapsed <= simulationTime)
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


