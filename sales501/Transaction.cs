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
        private double _total;
        private double _costWithRebate = 0;
        public Transaction(string fn, string ln, string add, string email, List<string> items, List<double> cost, double total)
        {
            firstName = fn;
            lastName = ln;
            Address = add;
            Email = email;
            Items = items;
            Cost = cost;
            Rebate = false;
            _total = total;
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
        public string firstName { get; private set; }

        public string lastName { get; private set; }

        public string Address { get; private set; }

        public string Email { get; private set; }

        public List<string> Items { get; private set; }

        public List<double> Cost { get; set; }

        public bool Rebate { get;  set; }

        public double CostWithRebate { get; set; }

        public void minusRebate(double rebate, DateTime date)
        {
            if (Rebate)
            {
                Console.WriteLine("It was already rebated before, it will be replaced by new rebate.");
            }
            Rebate = true;
            CostWithRebate = _total * rebate / 100;
        }
       
        public string PrintItemsAndCost()
        {
            string str = "";
            for(int i = 0; i < Cost.Count; i++)
            {
                if(Cost[i] == 0)
                {
                    str += "#" + (i + 1) + " item " + Items[i] + ": Returned.\n";
                }
                else
                {
                    str += "#" + (i + 1) + " item " + Items[i] + " and Cost: $" + Cost[i] + "\n";
                }
            }
            return str;
        }

        public string ItemReturn(string item)
        {
            int count = 0;
            foreach(string s in Items)
            {
                if(s == item)
                {
                    Cost[count] = 0;
                    return "Item returned.";
                }
                count++;
            }
            return "Item does not exist.";
        }
    }
}
