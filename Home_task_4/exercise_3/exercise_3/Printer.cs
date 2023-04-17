using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_3
{
    internal static class Printer
    {
        private static readonly QuarterReport _report = new QuarterReport();

        public static void PrintEverything()
        {
            _report.ReadApartmentsDataFromFile("data.txt");
            Console.WriteLine("Enter the cost of electricity:");
            double price = Convert.ToDouble(Console.ReadLine());
            while (true)
            {
                Console.WriteLine(
                    "1 - Apartments table;\n2 - Apartment;\n3 - Find max bill;\n4 - Show apartment that don`t use electricity;\n5 - Exit;");
                Console.WriteLine("Write number to choose: ");
                int temp = Convert.ToInt32(Console.ReadLine());
                switch (temp)
                {
                    case 1:
                        PrintApartmentsInfoTable(price);
                        Console.ReadLine();
                        break;
                    case 2:
                        PrintApartmentInfo();
                        Console.ReadLine();
                        break;
                    case 3:
                        PrintMaxBill(price);
                        Console.ReadLine();
                        break;
                    case 4:
                        PrintNoElextricityApartment();
                        Console.ReadLine();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Error");
                        break;
                }
            }
        }

        private static void PrintApartmentsInfoTable(double cost)
        {
            Console.WriteLine("Report for quarter {0}", _report.Quarter);
            Console.WriteLine("{0,-5}|{1,-20}|{2,-15}|{3,-24}|{4,-21}|{5,-28}|{6,-35:F2}|", "Number", "Address",
                "Owner", "Electricity consumption", "Date of last reading", "Electricity debt", "Days since electricity check");
            Console.WriteLine(
                "|---------------------------------------------------------------------------------------------------------------------------|");
            foreach (var flat in _report.Apartments)
            {
                Console.WriteLine("|{0,-5}|{1,-25}|{2,-15}|{3,-30}|{4,-20}|{5,-30}|{6,-35:F2}|", flat.FlatNumber,
                    flat.Address,
                    flat.OwnerName, flat.EndReaderIndex - flat.StartReaderIndex,
                    flat.Date.ToString("dd.MM.yy"), flat.GetBillForFlat(cost).bill,
                    (DateTime.Now - flat.Date).ToString("dd"));
            }
            Console.WriteLine(
                "|---------------------------------------------------------------------------------------------------------------------------|");
        }

        private static void PrintApartmentInfo()
        {
            Console.WriteLine("Find apartment:\n1 - By flat number;\n2 - By owner surname;");
            int find = Convert.ToInt32(Console.ReadLine());
            string report = "";
            switch (find)
            {
                case 1:
                    Console.WriteLine("Enter number of flat:");
                    int flatNumber = Convert.ToInt32(Console.ReadLine());
                    report = _report.ShowApartment(flatNumber.ToString());
                    break;
                case 2:
                    Console.WriteLine("Enter owner name");
                    string ownerName = Console.ReadLine();
                    report = _report.ShowApartment(ownerName);
                    break;
            }
            if (!string.IsNullOrEmpty(report))
            {
                Console.WriteLine(report);
            }
            else
            {
                Console.WriteLine("Apartment not exist");
            }
        }
        private static void PrintNoElextricityApartment()
        {
            Console.WriteLine(_report.ShowApartmentWithoutElectricity());
        }
        private static void PrintMaxBill(double cost)
        {
            var bill = _report.FindMaxBill(cost);
            Console.WriteLine($"Owner {bill.owner} need to pay {bill.bill}.");
        }
    }
}
