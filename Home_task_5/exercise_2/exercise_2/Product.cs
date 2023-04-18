using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_2
{
    internal class Product
    {
        private string _name;
        private double _length;
        private double _height;
        private double _width;
        private Department _department;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public double Length
        {
            get { return _length; }
            set { _length = value; }
        }

        public double Height
        {
            get { return _height; }
            set { _height = value; }
        }
        public double Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public Department Department
        {
            get { return _department; }
            set { _department = value; }
        }

        public double Size => Width * Length * Height;

        public Product(string name, double width, double length, double height, Department department)
        {
            Name = name;
            Width = width;
            Length = length;
            Height = height;
            Department = department;
        }

        public override string ToString() =>
            $"Product {Name}; size is {Width}x{Length}x{Height} and department is {Department.Name}";
    }
}
