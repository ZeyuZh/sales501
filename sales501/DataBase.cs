using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales501
{
    public class DataBase
    {
        /// <summary>
        /// the dictionary of transactions
        /// </summary>
        private static Dictionary<int, Transaction> _DBofTransaction = new Dictionary<int, Transaction>();
        
        /// <summary>
        /// the dictionary of rebated transactions
        /// </summary>
        private static Dictionary<int, Rebate> _DBofRebate = new Dictionary<int, Rebate>();

        /// <summary>
        /// add new transaction to database
        /// </summary>
        /// <param name="id"> the id of transaction</param>
        /// <param name="tran"> the transaction we would like to add</param>
        public static void AddTransaction(int id, Transaction tran)
        {
            _DBofTransaction.Add(id, tran);
        }

        /// <summary>
        /// add new rebate to database
        /// </summary>
        /// <param name="id"> the id of rebated transaction</param>
        /// <param name="reb"> the rebate we would like to add for this transaction</param>
        public static void AddRebate(int id, Rebate reb)
        {
            _DBofRebate.Add(id, reb);
        }

        /// <summary>
        /// Check the ID if it exists or not in DataBase.
        /// </summary>
        /// <param name="id">the id we want to check</param>
        /// <returns> true or false for the existence of transaction</returns>
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

        /// <summary>
        /// get transaction from DataBase
        /// </summary>
        /// <param name="id"> the id of transaction user would like to get</param>
        /// <returns>the transaction user looks for</returns>
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

        /// <summary>
        /// . Check the existence of the ID of rebate in DataBase
        /// </summary>
        /// <param name="id">the id user wants to check</param>
        /// <returns>true or false of the existence of rebate</returns>
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

        /// <summary>
        /// get the rebate from given ID
        /// </summary>
        /// <param name="id">the ID of the rebate users look for</param>
        /// <returns> the rebate user looks for</returns>
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

        /// <summary>
        /// print the items and cost from the given ID
        /// </summary>
        /// <param name="id">the ID of transaction user wants to print</param>
        /// <returns>the content user wants to print</returns>
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
        /// <summary>
        /// generate the rebate check
        /// </summary>
        /// <returns>the content for rebate transaction</returns>
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
