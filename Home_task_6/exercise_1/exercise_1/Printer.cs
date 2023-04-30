using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_1
{
    public static class Printer
    {
        public static void Print()
        {
            int[,] matrix = new int[,]
            {
                { 1, 2, 3, 4, 5, 6 },
                { 7, 8, 9, 10, 11, 12 },
                { 13, 14, 15, 16, 17, 18 },
                { 19, 20, 21, 22, 23, 24 },
                { 25, 26, 27, 28, 29, 30 },
                { 31, 32, 33, 34, 35, 36 }
            };

            SpiralMatrix spiralMatrix = new SpiralMatrix(matrix);
            Console.WriteLine(spiralMatrix.ToString());
        }
    }
}
