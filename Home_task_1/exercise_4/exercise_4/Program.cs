using System.Text;

namespace Exercise4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 3;
            Tensor<int> tensor3d = new Tensor<int>(n, n, n);
            Tensor<int> tensor2d = new Tensor<int>(n, n);
            Tensor<int> tensor = new Tensor<int>(n);
            Tensor<int> tensor_number = new Tensor<int>(1);

            Random rand = new Random();
            Console.WriteLine("Display 3х3х3 tensor");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        tensor3d.SetValue(rand.Next(0, 10), i, j, k);
                    }
                }
            }

            tensor3d.Print3DTensor(tensor3d, n);
            
           
            Console.WriteLine("Display 3х3 tensor");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    tensor2d.SetValue(rand.Next(0, 10), i, j);
                }
            }
            tensor2d.Print2DTensor(tensor2d, n);
            

            Console.WriteLine("Display vector");
            
            for (int i = 0; i < n; i++)
            {
                tensor.SetValue(rand.Next(0, 10), i);

            }

            tensor.PrintTensor(tensor, n);
            Console.WriteLine();
            Console.WriteLine("Display number");
            
            tensor_number.SetValue(rand.Next(1,10), 0);
            tensor_number.PrintNumber(tensor_number);
        }
    }
}