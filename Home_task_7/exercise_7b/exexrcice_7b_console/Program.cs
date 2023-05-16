
using exercise_7b;
using exercise_7b.Interfaces;
using exexrcice_7b_console;
using System.Net.Http.Headers;

namespace exercise_7b_console
{
    public class Program
    {// Не бачу відображення вікна проєктування. Не зрозуміле проєктування. Прохання залишитись  пояснити аспекти.
        static void Main(string[] args)
        {
            IReader reader = new Reader();
            
            int delay = reader.ReadValue("Set delay:");
            int time = reader.ReadValue("Set timer:");

            var directions = new List<string>() { "North-South", "East-West", "South-North", "West-East" };
            var lights = new TrafficLight(directions, delay);

            IPrinter printer = new Printer(lights);

            for (int i = 0; i < time; i++)
            {
                lights.TrafficLightOn(() => printer.Print());
            }
        }
    }
}
