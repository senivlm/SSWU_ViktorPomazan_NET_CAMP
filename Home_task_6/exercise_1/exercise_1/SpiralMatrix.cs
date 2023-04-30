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
        private int[,] _matrix;

        public SpiralMatrix(int x)
        {
            _matrix = new int[x, x];
            int number = 0;
            for(int i = 0; i < x; i++)
            {
                for(int j = 0; j < x; j++)
                {
                    _matrix[i, j] = number++;
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            Point min = new Point(0, 0);
            Point max = new Point(_matrix.GetLength(0) - 1, _matrix.GetLength(1) - 1);
            while(min != max)
            {
                int freeParam;
                if(min.X > min.Y)
                {
                    freeParam = min.Y;
                    for(int i = min.X; i >= min.Y; i--)
                    {
                        yield return _matrix[i, freeParam++];
                    }
                    if(min.X < _matrix.GetLength(0) - 1)
                        min = new Point(0, min.X + 1);
                    else
                        min = new Point(min.Y + 1, min.X);
                }
                else
                {
                    freeParam = min.X;
                    for(int i = min.Y; i >= min.X; i--)
                    {
                        yield return _matrix[freeParam++, i];
                    }
                    if (min.Y < _matrix.GetLength(1) - 1)
                        min = new Point(min.Y + 1, 0);
                    else
                    {
                        min = new Point(min.Y, min.X + 1);
                    }
                }
            }
            yield return _matrix[max.X, max.Y];
        }
    }
}
