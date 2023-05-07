using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using exercise_7b.Interfaces;

namespace exercise_7b
{
    public class Printer: IPrinter
    {
        private readonly TrafficLight _trafficLight;

        public Printer(TrafficLight trafficLight)
        {
            _trafficLight = trafficLight;
        }
        public void Print()
        {
            Console.Clear();
            Console.WriteLine($"Current time: {_trafficLight.CurrentTime}s.");

            const string green = "    Green      ";
            const string red = " Red       ";
            const string plusLine = "+{0}+";
            const string emptyCell = "|{0}|";

            for (int i = 0; i < _trafficLight.Directions.Count; i++)
            {
                var direction = _trafficLight.Directions[i];
                var spaces = direction.Length + 2;
                var isGreen = (_trafficLight.CurrentTime / _trafficLight.Timer + i) % 2 == 0;

                Console.Write(plusLine, new string('-', spaces));
            }
            Console.WriteLine();

            for (int i = 0; i < _trafficLight.Directions.Count; i++)
            {
                var direction = _trafficLight.Directions[i];

                Console.Write(emptyCell, $" {direction} ");
            }
            Console.WriteLine("|");

            for (int i = 0; i < _trafficLight.Directions.Count; i++)
            {
                var direction = _trafficLight.Directions[i];
                var spaces = direction.Length + 2;
                var isGreen = (_trafficLight.CurrentTime / _trafficLight.Timer + i) % 2 == 0;
                var color = isGreen ? ConsoleColor.Green : ConsoleColor.Red;
                var text = isGreen ? green : red;

                Console.ForegroundColor = color;
                Console.Write(emptyCell, text);
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("|");

            for (int i = 0; i < _trafficLight.Directions.Count; i++)
            {
                var direction = _trafficLight.Directions[i];
                var spaces = direction.Length + 2;

                Console.Write(plusLine, new string('-', spaces));
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
