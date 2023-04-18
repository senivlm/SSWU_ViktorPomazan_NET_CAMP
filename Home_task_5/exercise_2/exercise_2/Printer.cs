using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_2
{
    internal static class Printer
    {
        private static Market _market;
        private static bool isChosen = false;

        public static void Print()
        {
            while (true)
            {
                Console.WriteLine("1 - Enter market structure");
                Console.WriteLine("2 - Use default market");
                Console.WriteLine("3 - Show all products");
                Console.WriteLine("4 - Show all boxes");

                Console.WriteLine("Write number to make action : ");
                int num = Convert.ToInt32(Console.ReadLine());
                switch (num)
                {
                    case 1:
                        if (!isChosen)
                        {
                            _market = MarketManipulator.CreateMarketStruture();
                            isChosen = true;
                        }
                        else
                        {
                            Console.WriteLine("Market is already created!");
                        }
                        Console.ReadLine();
                        break;
                    case 2:
                        if (!isChosen)
                        {
                            _market = MarketManipulator.UseDefaultShop();
                            isChosen = true;
                        }
                        else
                        {
                            Console.WriteLine("Market is already created!");
                        }
                        Console.ReadLine();
                        break;
                    case 3:
                        if (isChosen)
                        {
                            MarketManipulator.ShowAllItems(_market);
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Market is not created!");
                        }

                        break;
                    case 4:
                        if (isChosen)
                        {
                            MarketManipulator.CreateProductsSet(_market);
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Market is not created!");
                        }

                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Choose something else :3 ");
                        break;
                }
            }
        }
    }
}
