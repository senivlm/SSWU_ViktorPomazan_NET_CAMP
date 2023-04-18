using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_2
{
    internal class Box
    {
        private readonly Market _market;
        private string _name;
        private List<Product> _products;
        private double _width;
        private double _length;
        private double _height;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<Product> Products
        {
            get { return _products; }
            set { _products = value; }
        }

        public double Width
        {
            get { return _width; }
            set { _width = value; }
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

        public Box(string name, List<Product> products, Market market)
        {
            Name = name;
            Products = products;
            CalculateDimensions(); 
            _market = market;
        }

        public void CalculateDimensions() 
        {
            Width = Products.Sum(p => p.Width);
            Length = Products.Max(p => p.Length);
            Height = Products.Max(p => p.Height);
        }

        public static bool IsBoxEmpty(Product product, Box box)
        {
            return product.Length <= box.Length && product.Height <= box.Height &&
                   (box.Products.Count == 0 || box.Products[0].Department == product.Department);
        }

        public override string ToString()
        {
            var productDepartment = Products.FirstOrDefault()?.Department.Name ?? "";
            return $"Box: {_market.Name}--->{productDepartment}\n Size: {Width}x{Length}x{Height}\n In box: {Name}";
        }
    }
}
