using System.Text;

namespace exercise_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Cube cube = new Cube(3);
            cube.FillCube();
            cube.ToString();
            cube.FindEmptySpaceInAxisX();
            cube.FindEmptySpaceInAxisY();
            cube.FindEmptySpaceInAxisZ();
        }
    }
}