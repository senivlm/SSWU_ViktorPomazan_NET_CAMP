using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_3
{
    internal class QuarterReport
    {
        public Apartment[] Apartments;
        private int _quarter;
        public int Quarter
        {
            get { return _quarter; }
            set { _quarter = value; }
        }

        public void ReadApartmentsDataFromFile(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string[] parts = reader.ReadLine().Split(' ');
                int apartmentCount = int.Parse(parts[0]);
                _quarter = int.Parse(parts[1]);

                Apartment[] apartments = new Apartment[apartmentCount];

                for (int i = 0; i < apartmentCount; i++)
                {
                    parts = reader.ReadLine().Split("; ");
                    int flatNumber = int.Parse(parts[0]);
                    string address = parts[1];
                    string ownerLastName = parts[2];
                    int previousReading = int.Parse(parts[3]);
                    int currentReading = int.Parse(parts[4]);
                    DateTime date = DateTime.ParseExact(parts[5], "dd.MM.yy", CultureInfo.InvariantCulture);

                    apartments[i] = new Apartment(flatNumber, address, ownerLastName, previousReading, currentReading, date);
                }

                Apartments = apartments;
                reader.Close();
            }
        }

        public string? ShowApartment(int flatNumber)
        {
            return Apartments.FirstOrDefault(a => a.FlatNumber == flatNumber)?.ToString();
        }

        public string? ShowApartment(string ownerName)
        {
            return Apartments.FirstOrDefault(a => a.OwnerName == ownerName)?.ToString();
        }

        public (string owner, double bill) FindMaxBill (double ElectricityCost)
        {
            Apartment maxBillApartment = Apartments[0];
            foreach (var apartment in Apartments)
            {
                if (apartment.EndReaderIndex - apartment.StartReaderIndex > maxBillApartment.EndReaderIndex - maxBillApartment.StartReaderIndex)
                {
                    maxBillApartment = apartment;
                }
            }

            return (maxBillApartment.OwnerName, (maxBillApartment.EndReaderIndex - maxBillApartment.StartReaderIndex) * ElectricityCost);
        }

        public string? ShowApartmentWithoutElectricity()
        {
            return Apartments.FirstOrDefault(a => a.StartReaderIndex == a.EndReaderIndex)?.ToString();
        }
    }
}
