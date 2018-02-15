using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales501
{
    class DataBase
    {
        private static Dictionary<int, Transaction> _DB = new Dictionary<int, Transaction>();
        //int _count = 0;


        public DataBase(int id, Transaction tran)
        {
            _DB.Add(id, tran);
            //_count++;
        }
       
        public static bool TransactionExist(int id)
        {
            foreach(int i in _DB.Keys)
            {
                if(i == id)
                {
                    return true;
                }
            }
            return false;
        }

        public static Transaction GetTransaction(int id)
        {
            if (!TransactionExist(id))
            {
                return null;
            }
            else
            {
                return _DB[id];
            }
        }
    }
}
