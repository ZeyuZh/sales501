using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales501
{
    class Transaction
    {

        private static int _number = 0;
        public Transaction(string fn, string ln, string add, string email, List<string> items, List<double> cost, double total, int month, int day, int year)
        {
            firstName = fn;
            lastName = ln;
            Address = add;
            Email = email;
            Items = items;
            Cost = cost;
            Total = total;
            Month = month;
            Day = day;
            Year = year;
        }

        public static int IDGenerator()
        {
            _number++;
            return _number;
        }

        public static string IDFormat(int id)
        {
            string format;
            if (id < 10) format = "#000" + id;
            else if (id < 100) format = "#00" + id;
            else if (id < 1000) format = "#0" + id;
            else format = "#" + id;
            return format;
        }
        public int Month { get; set; }

        public int Day { get; set; }

        public int Year { get; set; }

        public string firstName { get; private set; }

        public string lastName { get; private set; }

        public string Address { get; private set; }

        public string Email { get; private set; }

        public List<string> Items { get; private set; }

        public List<double> Cost { get; set; }

        public double Total { get; set; }
    
    }
}
