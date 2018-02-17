using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales501
{
    public class ReturnItems
    {
        /// <summary>
        /// Constructor of Return items
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        public ReturnItems(int id, string item)
        {
            Console.WriteLine(ItemReturned(id, item));
        }

        /// <summary>
        /// check the qualification of returning items
        /// </summary>
        /// <param name="id">the ID of transaction user wants to return</param>
        /// <param name="month">return date of month</param>
        /// <param name="year"> return date of year</param>
        /// <returns>true or false of the qualification of returning items</returns>
        public static bool ReturnAllowed(int id, int month, int year)
        {
            Transaction tran = DataBase.GetTransaction(id);
            
            if ((tran.Year != year || month > 7) && DataBase.RebateExist(id)) return false;
            else return true;
        }

        /// <summary>
        /// method for return an item
        /// </summary>
        /// <param name="id">the id of transaction user want to return items</param>
        /// <param name="item"> the item user want to return</param>
        /// <returns>the prompt information of return successfully or the prompt information that system cannot find item</returns>
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
