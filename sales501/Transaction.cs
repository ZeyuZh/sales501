using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales501
{
    class Transaction
    {
        private string _firstName;
        private string _lastName;
        private string _address;
        private string _email;
        private List<string> _items;
        private List<double> _cost;
        private bool _rebate;
        private int _number = 0;

        public Transaction(string fn, string ln, string add, string email, List<string> items, List<double> cost)
        {
            _firstName = fn;
            _lastName = ln;
            _address = add;
            _email = email;
            _items = items;
            _cost = cost;
            _rebate = false;
        }

        public int IDGenerator()
        {
            return _number++;
        }

        
    }
}
