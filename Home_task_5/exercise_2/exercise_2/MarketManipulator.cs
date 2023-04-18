using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_2
{
    internal static class MarketManipulator
    {
        public static Market CreateMarketStruture()
        {
            Console.WriteLine("Enter market name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter count of departments: ");
            int countOfDepartments;
            while (!int.TryParse(Console.ReadLine(), out countOfDepartments))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer for count of departments: ");
            }

            List<Department> departments = new List<Department>();

            for (int i = 0; i < countOfDepartments; i++)
            {
                Console.WriteLine($"Enter name of {i} department : ");
                departments.Add(new Department(Console.ReadLine()));

                Console.WriteLine($"Enter count of products in this department: ");
                int countOfItems;
                while (!int.TryParse(Console.ReadLine(), out countOfItems))
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer for count of products: ");
                }

                for (int j = 0; j < countOfItems; j++)
                {
                    Console.WriteLine($"Enter name of {j} product : ");
                    string nameProduct = Console.ReadLine();

                    Console.WriteLine($"Enter width of {nameProduct}: ");
                    int width;
                    while (!int.TryParse(Console.ReadLine(), out width))
                    {
                        Console.WriteLine($"Invalid input. Please enter a valid integer for width of {nameProduct}: ");
                    }

                    Console.WriteLine($"Enter length of {nameProduct}: ");
                    int length;
                    while (!int.TryParse(Console.ReadLine(), out length))
                    {
                        Console.WriteLine($"Invalid input. Please enter a valid integer for length of {nameProduct}: ");
                    }

                    Console.WriteLine($"Enter height of {nameProduct}: ");
                    int height;
                    while (!int.TryParse(Console.ReadLine(), out height))
                    {
                        Console.WriteLine($"Invalid input. Please enter a valid integer for height of {nameProduct}: ");
                    }

                    departments[i].AddProduct(new Product(nameProduct, width, length, height, departments[i]));
                }
            }

            Market market = new Market(name, departments);
            Console.WriteLine("Market is created!");
            return market;
        }

        public static Market UseDefaultShop()
        {
            Department techology = new Department("techology");
            Department food = new Department("food");
            Department drink = new Department("drink");

            List<Product> electronicItems = new List<Product>
            {
                new Product("Smart TV", 70, 50, 20, techology),
                new Product("Gaming Laptop", 35, 25, 12, techology),
                new Product("Wireless Headphones", 10, 8, 5, techology),
                new Product("Smartphone", 18, 10, 6, techology),
                new Product("Mirrorless Camera", 15, 10, 8, techology),
                new Product("Fitness Tracker", 5, 5, 3, techology)
            };

            List<Product> foodItems = new List<Product>
            {
                new Product("Whole Wheat Bread", 22, 18, 15, food),
                new Product("Organic Eggs", 6, 6, 6, food),
                new Product("Cheddar Cheese", 14, 10, 6, food),
                new Product("Almond Milk", 12, 12, 12, food),
                new Product("Organic Apples", 10, 10, 10, food),
                new Product("Grass-Fed Beef", 18, 12, 8, food)
            };

            List<Product> drinksItems = new List<Product>
            {
                new Product("Mineral Water", 35, 20, 20, drink),
                new Product("Craft Soda", 12, 10, 10, drink),
                new Product("Cold Pressed Juice", 18, 12, 12, drink),
                new Product("Organic Green Tea", 8, 8, 8, drink),
                new Product("Arabica Coffee", 10, 10, 10, drink),
                new Product("Craft Beer", 12, 12, 18, drink)
            };

            techology.AddProducts(electronicItems);
            drink.AddProducts(drinksItems);
            food.AddProducts(foodItems);
            
            List<Department> departments = new List<Department> { techology, food, drink };
            Market market = new Market("Sil'po", departments);
            Console.WriteLine("Market is created");
            return market;
        }

        public static void ShowAllItems(Market market)
        {
            Console.WriteLine($"Products in {market.Name}:");
            foreach (var department in market.Departments)
            {
                foreach (var product in department.Products)
                {
                    Console.WriteLine(product.ToString());
                }
            }
        }

        public static void CreateProductsSet(Market market)
        {
            foreach (var department in market.Departments)
            {
                var boxes = market.CreateProductSet(department.Products, market);
                foreach (var box in boxes)
                {
                    Console.WriteLine(box.ToString());
                    Console.WriteLine();
                }
            }
        }
    }
}
