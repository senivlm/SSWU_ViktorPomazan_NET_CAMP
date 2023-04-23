using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
    internal class Tensor<T>
    {
        private readonly int[] _shape;
        private readonly T[] _data;

        public Tensor(params int[] shape)
        {
            if (shape == null || shape.Length == 0)
            {
                throw new ArgumentException("At least one shape is required.", nameof(shape));
            }

            _shape = shape;
            _data = new T[CalculateTensorSize(shape)];
        }
// Порушення інкапсуляції
        public int[] Dimensions => _shape;

        public T GetValue(params int[] indices)
        {
            if (indices == null || indices.Length != _shape.Length)
            {
                throw new ArgumentException("Indices must have the same length as the tensor's shape.", nameof(indices));
            }

            int offset = CalculateIndex(indices);
            return _data[offset];
        }
        // наявність таких методів вже показує скінченність підходу....
        public void Print3DTensor(Tensor<int> tensor3d, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        Console.Write(tensor3d.GetValue(i, j, k) + " ");
                    }

                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
        public void Print2DTensor(Tensor<int> tensor2d, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(tensor2d.GetValue(i, j) + " ");
                }
                Console.WriteLine();
            }
        }
        public void PrintTensor(Tensor<int> vector, int n)
        {
            for (int i = 0; i < n; i++)
            { 
                Console.Write(vector.GetValue(i) + " ");
            }
        }
        public void PrintNumber(Tensor<int> number)
        {
            Console.WriteLine(number.GetValue(0));
        }
        public void SetValue(T data, params int[] indices)
        {
            if (indices == null || indices.Length != _shape.Length)
            {
                throw new ArgumentException("Indices must have the same length as the tensor's shape.", nameof(indices));
            }

            int offset = CalculateIndex(indices);
            _data[offset] = data;
        }

        private int CalculateTensorSize(int[] shape)
        {
            int size = 1;
            foreach (int sh in shape)
            {
                if (sh <= 0)
                {
                    throw new ArgumentException("Shape must be positive.", nameof(shape));
                }

                size *= sh;
            }

            return size;
        }

        private int CalculateIndex(int[] indices)
        {
            int offset = 0;
            int stride = 1;

            for (int i = _shape.Length - 1; i >= 0; i--)
            {
                int index = indices[i];
                if (index < 0 || index >= _shape[i])
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }

                offset += index * stride;
                stride *= _shape[i];
            }

            return offset;
        }

    }
}
