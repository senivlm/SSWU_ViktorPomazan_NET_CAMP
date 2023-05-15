using System;

namespace exercise_4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ChildClass child = new ChildClass();
            child.EventOccurred += Child_EventOccurred;

            child.DoSomething();
        }
        private static void Child_EventOccurred(object sender, EventArgs e)
        {
            Console.WriteLine("Подія сталася в дочірньому класі.");
        }
    }
}