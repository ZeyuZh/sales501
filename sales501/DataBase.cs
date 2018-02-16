using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales501
{
    class DataBase
    {
        private static Dictionary<int, Transaction> _DBofTransaction = new Dictionary<int, Transaction>();
        
        private static Dictionary<int, Rebate> _DBofRebate = new Dictionary<int, Rebate>();
        public static void AddTransaction(int id, Transaction tran)
        {
            _DBofTransaction.Add(id, tran);
        }

        public static void AddRebate(int id, Rebate reb)
        {
            _DBofRebate.Add(id, reb);
        }

        public static bool TransactionExist(int id)
        {
            foreach(int i in _DBofTransaction.Keys)
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
                return _DBofTransaction[id];
            }
        }

        public static bool RebateExist(int id)
        {
            foreach(int i in _DBofRebate.Keys)
            {
                if(i == id)
                {
                    return true;
                }
            }
            return false;
        }

        public static Rebate GetRebate(int id)
        {
            if (!RebateExist(id))
            {
                return null;
            }
            else
            {
                return _DBofRebate[id];
            }
        }
        public static string PrintItemsAndCost(int id)
        {
            Transaction tran = GetTransaction(id);
            string str = "";
            for (int i = 0; i < tran.Cost.Count; i++)
            {
                if (tran.Cost[i] == 0)
                {
                    str += "#" + (i + 1) + " item " + tran.Items[i] + ": Returned.\n";
                }
                else
                {
                    str += "#" + (i + 1) + " item " + tran.Items[i] + " and Cost: $" + tran.Cost[i] + "\n";
                }
            }
            return str;
        }

        public static string GenerateRebateCheck()
        {
            string check = "";
            foreach(int id in _DBofRebate.Keys)
            {
                Rebate reb = _DBofRebate[id];
                reb.minusRebate(id);
                Transaction tran = GetTransaction(id);
                double rebateAmount = tran.Total - reb.CostWithRebate;
                check += "First Name: " + tran.firstName + "\nLast Name: " + tran.lastName + "\nAddress: " + tran.Address + "Email: " + tran.Email + "\nItems List: \n"+ PrintItemsAndCost(id) + "\nCost Total: " + tran.Total + "\nCost after rebate: " + reb.CostWithRebate + "\nRebate Amount: " + rebateAmount + ".\n";
                check += "Check is mailing to " + tran.Address + " and the email is sending to " + tran.Email + ".\n"; 
            }
            return check;
        }
    }
}
