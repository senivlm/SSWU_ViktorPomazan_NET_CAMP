using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_2
{
    internal class Market
    {
        private string _name; 
        private List<Department> _departments; 

        public string Name 
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<Department> Departments 
        {
            get { return _departments; }
            set { _departments = value; }
        }

        public Market()
        {
            _name = "";
            _departments = new List<Department>();
        }

        public Market(string name, List<Department> departments)
        {
            _name = name;
            _departments = departments;
        }

        public void AddDepartment(Department department)
        {
            _departments.Add(department);
        }

        public List<Box> CreateProductSet(List<Product> products, Market shop)
        {
            List<Box> boxes = new List<Box>();

            foreach (var product in products)
            {
                Box usingBox = boxes.FirstOrDefault(box => Box.IsBoxEmpty(product, box));

                if (usingBox != null)
                {
                    usingBox.Products.Add(product);
                    usingBox.CalculateDimensions();
                    
                    usingBox.Name += $", {product.Name}";
                }
                else
                {
                    Box newBox = new Box(product.Name, new List<Product> { product }, shop);
                    boxes.Add(newBox);
                }
            }

            return boxes;
        }

    }
}
