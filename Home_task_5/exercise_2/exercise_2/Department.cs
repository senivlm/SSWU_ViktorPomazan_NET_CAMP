using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_2
{
    internal class Department
    {
        private string _name; 
        private List<Product> _products; 

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

        public Department(string name)
        {
            _name = name;
            _products = new List<Product>();
        }

        public void AddProduct(Product item)
        {
            _products.Add(item);
        }

        public void AddProducts(List<Product> products)
        {
            _products.AddRange(products);
        }
    }
}
