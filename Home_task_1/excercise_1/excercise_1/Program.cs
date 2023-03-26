int n = int.Parse(Console.ReadLine()); // кількість рядків
int m = int.Parse(Console.ReadLine()); // кількість стовпців

int[,] matrix = new int[n, m]; // ініціалізація матриці

int value = 1; // початкове значення
int row = 0; // поточний рядок
int col = 0; // поточний стовпець
int direction = 3;

// заповнення матриці
for (int i = 0; i < n * m; i++)
{
    matrix[row, col] = value; // присвоєння значення елементу матриці
    value++; // збільшення значення для наступного елементу

    // визначення наступного рядка і стовпця залежно від напряму руху
    switch (direction)
    {
        case 0: // вниз
            if (row == n - 1 || matrix[row + 1, col] != 0)
            {
                direction = 1; // зміна напряму руху на вправо
                col++;
            }
            else
            {
                row++;
            }
            break;
        case 1: // вправо
            if (col == m - 1 || matrix[row, col + 1] != 0)
            {
                direction = 2; // зміна напряму руху на вверх
                row--;
            }
            else
            {
                col++;
            }
            break;
        case 2: // вверх
            if (row == 0 || matrix[row - 1, col] != 0)
            {
                direction = 3; // зміна напряму руху на вліво
                col--;
            }
            else
            {
                row--;
            }
            break;
        case 3: // вліво
            if (col == 0 || matrix[row, col - 1] != 0)
            {
                direction = 0; // зміна напряму руху на вниз
                row++;
            }
            else
            {
                col--;
            }
            break;
    }
}

// виведення матриці
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        Console.Write(matrix[i, j] + " ");
    }
    Console.WriteLine();
}
