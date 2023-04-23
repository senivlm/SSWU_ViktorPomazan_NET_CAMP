using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// У такому підході немає узагальнення. Ви пишете подібний код кілька разів - отже, існує узагальнення! 
namespace exercise_3
{
    internal class Cube
    {// тут тип int дуже надлишковий
        int[,,] _cube;
        int _size;
        public Cube()
        {
            this._size = 5;
            this._cube = new int[_size, _size, _size];
        }
        public Cube(int[,,] cube)
        {
            this._cube = cube;
            this._size = cube.GetLength(0);
        }
        public Cube(int size)
        {
            this._size = size;
            this._cube = new int[_size, _size, _size];
        }
        public Cube(int size, int[,,] cube)
        {
            this._cube = cube;
            this._size = size;
        }

        public void FillCube()
        {
            int cubeLength = _cube.GetLength(0);
            Random random = new Random();

            for (int i = 0; i < cubeLength; ++i)
            {
                for (int j = 0; j < cubeLength; ++j)
                {
                    for (int k = 0; k < cubeLength; ++k)
                    {
                        _cube[k, j, i] = random.Next(0, 2);
                    }
                }
            }
        }
        // насправді Ви змінюєте 3 координату. Тому назва є некоректною.
        public void FindEmptySpaceInAxisX()
        {
            for (int i = 0; i < _cube.GetLength(0); i++)
            {

                for (int j = 0; j < _cube.GetLength(1); j++)
                {
                    bool holeAlongX = true;
                    for (int k = 0; k < _cube.GetLength(2); k++)
                    {
                        if (_cube[i, j, k] != 0)
                        {
                            holeAlongX = false;
                            break;
                        }
                    }//тут не потрібний роздрук. Це ж модельний клас.
                    if (holeAlongX)
                    {
                        Console.WriteLine("Empty space in X was found");
                        Console.WriteLine($"Start of hole: ({i}, {j}, 0 )");
                        Console.WriteLine($"End of hole: ({i}, {j}, {_cube.GetLength(2) - 1})");
                    }
                }
            }
        }
        public void FindEmptySpaceInAxisY()
        {
            for (int i = 0; i < _cube.GetLength(0); i++)
            {

                for (int j = 0; j < _cube.GetLength(1); j++)
                {
                    bool holeAlongY = true;
                    for (int k = 0; k < _cube.GetLength(2); k++)
                    {
                        if (_cube[i, k, j] != 0)
                        {
                            holeAlongY = false;
                            break;
                        }
                    }
                    if (holeAlongY)
                    {
                        Console.WriteLine("Empty space in Y was found");
                        Console.WriteLine($"Start of hole: ({i}, 0, {j})");
                        Console.WriteLine($"End of hole: ({i}, {_cube.GetLength(1) - 1}, {j})");
                    }
                }
            }

        }
        public void FindEmptySpaceInAxisZ()
        {
            for (int i = 0; i < _cube.GetLength(0); i++)
            {

                for (int j = 0; j < _cube.GetLength(1); j++)
                { 
                    bool holeAlongZ = true;
                    for (int k = 0; k < _cube.GetLength(0); k++)
                    {
                        if (_cube[k, i, j] != 0)
                        {
                            holeAlongZ = false;
                            break;
                        }
                    }
                    if (holeAlongZ)
                    {
                        Console.WriteLine("Empty space in Z was found");
                        Console.WriteLine($"Start of hole: (0, {i}, {j})");
                        Console.WriteLine($"End of hole: ({_cube.GetLength(0) - 1}, {i}, {j})");
                    }
                }

            }
        }
        public override string ToString()
        {
            int cubeLength = _cube.GetLength(0);
            StringBuilder output = new StringBuilder();
            for (int z = 0; z < cubeLength; ++z)
            {
                output.Append("{");
                for (int y = 0; y < cubeLength; ++y)
                {
                    output.Append("\n  {");
                    for (int x = 0; x < cubeLength; ++x)
                    {
                        output.Append($" {_cube[z, y, x]} ");
                    }
                    output.Append("}\n");
                }
                output.Append("}\n\n");
            }

            return output.ToString();
        }
    }
    
}
