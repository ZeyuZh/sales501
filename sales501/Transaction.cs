using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales501
{
    public class Transaction
    {
        /// <summary>
        /// the ID number
        /// </summary>
        private static int _number = 0;
        /// <summary>
        /// Constructor of Transaction
        /// </summary>
        /// <param name="fn">first name</param>
        /// <param name="ln">last name</param>
        /// <param name="add">address</param>
        /// <param name="email">Email</param>
        /// <param name="items">the list of Items</param>
        /// <param name="cost">the list of Cost of each item</param>
        /// <param name="total">total cost</param>
        /// <param name="month"> transaction generate date of month</param>
        /// <param name="day">transaction generate date of day</param>
        /// <param name="year">transaction generate date of year</param>
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

        /// <summary>
        /// generate the ID of transaction
        /// </summary>
        /// <returns></returns>
        public static int IDGenerator()
        {
            _number++;
            return _number;
        }

        /// <summary>
        /// The format ID displayed
        /// </summary>
        /// <param name="id">the ID user wants to display</param>
        /// <returns></returns>
        public static string IDFormat(int id)
        {
            string format;
            if (id < 10) format = "#000" + id;
            else if (id < 100) format = "#00" + id;
            else if (id < 1000) format = "#0" + id;
            else format = "#" + id;
            return format;
        }
        /// <summary>
        /// transaction generate date of month
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// transaction generate date of day
        /// </summary>
        public int Day { get; set; }

        /// <summary>
        /// transaction generate date of year
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// first name
        /// </summary>
        public string firstName { get; private set; }

        /// <summary>
        /// last name
        /// </summary>
        public string lastName { get; private set; }

        /// <summary>
        /// Address
        /// </summary>
        public string Address { get; private set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// the list of items
        /// </summary>
        public List<string> Items { get; private set; }

        /// <summary>
        /// the list of Cost of each item
        /// </summary>
        public List<double> Cost { get; set; }

        /// <summary>
        /// total cost
        /// </summary>
        public double Total { get; set; }
    
    }
}
