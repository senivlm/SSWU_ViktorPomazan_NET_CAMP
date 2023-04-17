using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_3
{
    internal class Apartment
    {
        private int _flatNnumber;
        private string _ownerName;
        private string _address;
        private int _startReaderIndex;
        private int _endReaderIndex;
        private DateTime _date;

        public int FlatNumber
        {
            get { return _flatNnumber; }
            set { _flatNnumber = value; }
        }

        public string OwnerName
        {
            get { return _ownerName; }
            set { _ownerName = value; }
        }

        public int StartReaderIndex
        {
            get { return _startReaderIndex; }
            set { _startReaderIndex = value; }
        }

        public int EndReaderIndex
        {
            get { return _endReaderIndex; }
            set { _endReaderIndex = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public Apartment(int flatNnumber, string address, string ownerName, int startReaderIndex, int endReaderIndex, DateTime readingDate)
        {
            _flatNnumber = flatNnumber;
            _address = address;
            _ownerName = ownerName;
            _startReaderIndex = startReaderIndex;
            _endReaderIndex = endReaderIndex;
            _date = readingDate;
        }

        public override string ToString()
        {
            return ($"Flat number is {_flatNnumber}, owner is {_ownerName}, address {_address}; Last: {_startReaderIndex}; Now: {_endReaderIndex}; {_date.ToString("MMMM")}: {_date.ToString("dd.MM.yy")}");
        }

        public (double bill, int flat) GetBillForFlat(double ElextricityCost)
        {
            double consumption = EndReaderIndex - StartReaderIndex;
            double bill = consumption * ElextricityCost;
            return (bill, FlatNumber);
        }
    }
}
