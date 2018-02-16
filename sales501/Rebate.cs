using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales501
{
    public class Rebate
    {
        public double rebate { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Year { get; set; }
        public double CostWithRebate { get; set; }

        public Rebate(double r, int month, int day, int year)
        {
            rebate = r;
            Month = month;
            Day = day;
            Year = year;
        }

        public static  bool RebateAllowed(int id, int year)
        {
            Transaction tran = DataBase.GetTransaction(id);
            if(tran.Year != year || tran.Month != 6) return false;
            else return true;
        }

        public void minusRebate(int id)
        {
            double total = 0;
            Transaction tran = DataBase.GetTransaction(id);
            for(int i = 0; i < tran.Cost.Count; i++)
            {
                tran.Cost[i] = tran.Cost[i] - tran.Cost[i] * rebate / 100;
                total += tran.Cost[i];
            }
            CostWithRebate = total;
        }
    }
}
