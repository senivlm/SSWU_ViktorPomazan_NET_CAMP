using System;

class Program
{// думаємо об'єктно-зорієнтовано. Розкладаємо на методи! Заповнення матриці не мало б мати роздрук!
    public static void FillMatrix(int[,] matrix)
    {
        Random random = new Random();
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = random.Next(0, 17);
            }
        }

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public static void CalculateColorData(int[,] matrix)
    {
        int maxLength = 0;
        int startRow = 0, startCol = 0, endRow = 0, endCol = 0;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int currentLength = 1;
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                if (matrix[i, j] == matrix[i, j + 1])
                {
                    currentLength++;
                }
                else
                {
                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                        startRow = i;
                        startCol = j - currentLength + 1;
                        endRow = i;
                        endCol = j;
                    }
                    currentLength = 1;
                }
            }
            if (currentLength > maxLength)
            {
                maxLength = currentLength;
                startRow = i;
                startCol = matrix.GetLength(1) - currentLength;
                endRow = i;
                endCol = matrix.GetLength(1) - 1;
            }
        }
// Результат мав би бути переданий як параметри методу!
        Console.WriteLine($"The longest line has length {maxLength} and color is {matrix[startRow, startCol]} colors");
        Console.WriteLine($"Start of line: [{startRow}, {startCol}]");
        Console.WriteLine($"End of line: [{endRow}, {endCol}]");
    }
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, m];

        FillMatrix(matrix);
        CalculateColorData(matrix);
    }
}
