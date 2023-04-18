using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_1
{
    internal static class Printer
    {
        public static void Print()
        {
            Tree[] firstlySeededTrees = 
                { 
                new Tree(0, 0), 
                new Tree(0, 1),
                new Tree(1, 2), 
                new Tree(1, 3), 
                new Tree(2, 1) 
            };

            Tree[] secondlySeededTrees = 
                {
                new Tree(0, 0),
                new Tree(1, 1),
                new Tree(2, 3),
                new Tree(3, 1),
                new Tree(2, 4) 
            };

            Garden firstSeededGarden = new Garden(firstlySeededTrees);
            Garden secondSeededGarden = new Garden(firstlySeededTrees);
            Garden thirdSeededGarden = new Garden(secondlySeededTrees);

            Console.WriteLine(firstSeededGarden);
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(secondSeededGarden);
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(thirdSeededGarden);
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("Perimeter of first garden is "+firstSeededGarden.CalculatePerimeter(firstlySeededTrees));
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Equality checkign");
            Console.WriteLine(firstSeededGarden == secondSeededGarden);
            Console.WriteLine(secondSeededGarden != firstSeededGarden);
            Console.WriteLine();
            Console.WriteLine(firstSeededGarden.Equals(secondSeededGarden));
            Console.WriteLine(secondSeededGarden.Equals(firstSeededGarden));
            Console.WriteLine();

            Console.WriteLine(firstSeededGarden == thirdSeededGarden);
            Console.WriteLine(thirdSeededGarden != firstSeededGarden);
            Console.WriteLine();
            Console.WriteLine(thirdSeededGarden.Equals(firstSeededGarden));
            Console.WriteLine(thirdSeededGarden.Equals(secondSeededGarden));
            Console.WriteLine();

            Console.WriteLine(secondSeededGarden == thirdSeededGarden);
            Console.WriteLine(thirdSeededGarden != secondSeededGarden);
            Console.WriteLine();
            Console.WriteLine(thirdSeededGarden.Equals(secondSeededGarden));
            Console.WriteLine(thirdSeededGarden.Equals(firstSeededGarden));
        }
    }
}
