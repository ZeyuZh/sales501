using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales501
{
    public class ReturnItems
    {
        public ReturnItems(int id, string item)
        {
            Console.WriteLine(ItemReturned(id, item));
        }

        public static bool ReturnAllowed(int id, int month, int year)
        {
            Transaction tran = DataBase.GetTransaction(id);
            
            if ((tran.Year != year || month > 7) && DataBase.RebateExist(id)) return false;
            else return true;
        }

        private string ItemReturned(int id, string item)
        {
            Transaction tran = DataBase.GetTransaction(id);
            int count = 0;

            foreach (string s in tran.Items)
            {
                if (s == item)
                {
                    tran.Total -= tran.Cost[count];
                    tran.Cost[count] = 0;
                    return "Item returned.";
                }
                count++;
            }
            return "Item does not exist.";

        }
    }
}
