using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales501
{
    public class Rebate
    {
        /// <summary>
        /// the rebate user entered
        /// </summary>
        public double rebate { get; set; }
        /// <summary>
        /// the month establish the rebate
        /// </summary>
        public int Month { get; set; }
        /// <summary>
        /// the day establish the rebate
        /// </summary>
        public int Day { get; set; }
        /// <summary>
        /// the year establish the rebate
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// the total cost after rebate
        /// </summary>
        public double CostWithRebate { get; set; }

        /// <summary>
        /// constructor of the rebate class
        /// </summary>
        /// <param name="r">the rebate</param>
        /// <param name="month">date of month</param>
        /// <param name="day">date of day</param>
        /// <param name="year">date of year</param>
        public Rebate(double r, int month, int day, int year)
        {
            rebate = r;
            Month = month;
            Day = day;
            Year = year;
        }

        /// <summary>
        /// check whether user can add a rebate or not
        /// </summary>
        /// <param name="id">the id of transaction which need to add rebate</param>
        /// <param name="year">the date of year adding rebate</param>
        /// <returns>true or false user can add rebate</returns>
        public static  bool RebateAllowed(int id, int year)
        {
            Transaction tran = DataBase.GetTransaction(id);
            if(tran.Year != year || tran.Month != 6) return false;
            else return true;
        }

        /// <summary>
        /// calculate the total cost after rebate
        /// </summary>
        /// <param name="id">the id user rebated</param>
        public void minusRebate(int id)
        {
            double total = 0;
            double temp = 0;
            Transaction tran = DataBase.GetTransaction(id);
            for(int i = 0; i < tran.Cost.Count; i++)
            {
                temp = tran.Cost[i] - tran.Cost[i] * rebate / 100;
                total += temp;
            }
            CostWithRebate = total;
        }
    }
}
