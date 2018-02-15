using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales501
{
    class DataBase
    {
        Dictionary<int, Transaction> _DB = new Dictionary<int, Transaction>();
        int _count = 0;


        public DataBase(int id, Transaction tran)
        {
            _DB.Add(id, tran);
            _count++;
        }
       
    }
}
