//Вітаю. Перше завдання по створенню репозиторію Ви виконали.
int n = int.Parse(Console.ReadLine()); 
int m = int.Parse(Console.ReadLine()); 

int[,] matrix = new int[n, m]; 

int value = 1; 
int row = 0; 
int col = 0;
int direction = 0;

for (int i = 0; i < n * m; i++)
{
    matrix[row, col] = value; 
    value++; 

    switch (direction)
    {
        case 0:
            if (row == n - 1 || matrix[row + 1, col] != 0)
            {
                direction = 1;
                col++;
            }
            else
            {
                row++;
            }
            break;
        case 1:
            if (col == m - 1 || matrix[row, col + 1] != 0)
            {
                direction = 2;
                row--;
            }
            else
            {
                col++;
            }
            break;
        case 2:
            if (row == 0 || matrix[row - 1, col] != 0)
            {
                direction = 3; 
                col--;
            }
            else
            {
                row--;
            }
            break;
        case 3: 
            if (col == 0 || matrix[row, col - 1] != 0)
            {
                direction = 0;
                row++;
            }
            else
            {
                col--;
            }
            break;
    }
}


for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        Console.Write(matrix[i, j] + " ");
    }
    Console.WriteLine();
}
