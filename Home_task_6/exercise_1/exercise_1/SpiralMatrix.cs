using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_1
{
    internal class SpiralMatrix: IEnumerable
    {
        private readonly int[,] matrix;
        public SpiralMatrix(int[,] matrix)
        {
            this.matrix = matrix;
        }

        public IEnumerator GetEnumerator()
        {
            int currentRow = 0;
            int currentCol = 0;
            int maxRow = matrix.GetLength(0) - 1;
            int maxCol = matrix.GetLength(1) - 1;
            bool isGoingDown = true;

            int step = 0;
            while (step < matrix.Length)
            {
                yield return matrix[currentRow, currentCol];

                switch (isGoingDown)
                {
                    case true 
                    when currentRow == maxRow:
                        currentCol++;
                        isGoingDown = false;
                        break;
                    case true when currentCol == 0:
                        currentRow++;
                        isGoingDown = false;
                        break;
                    case true:
                        currentRow++;
                        currentCol--;
                        break;
                    case false when currentCol == maxCol:
                        currentRow++;
                        isGoingDown = true;
                        break;
                    case false when currentRow == 0:
                        currentCol++;
                        isGoingDown = true;
                        break;
                    case false:
                        currentRow--;
                        currentCol++;
                        break;
                }

                step++;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Original matrix:").AppendLine();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sb.Append(matrix[i, j]).Append(" ");
                }
                sb.AppendLine();
            }
            sb.Append("Spiral order:").AppendLine();
            foreach (int element in this)
            {
                sb.Append(element).Append(", ");
            }
            if (sb.Length >= 2)
            {
                sb.Remove(sb.Length - 2, 2);
            }
            return sb.ToString();
        }
    }
}
