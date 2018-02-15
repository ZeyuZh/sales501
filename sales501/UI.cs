using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales501
{
    class UI
    {
        public UI()
        {
            mainUI();
        }

        private static void mainUI()
        {
            int input;
            do
            {
                Console.WriteLine("Welcome to use sales501 Sysytem. \nMain:");
                Console.WriteLine("1) Create sale transaction.");
                Console.WriteLine("2) Return item(s).");
                Console.WriteLine("3) Enter rebate.");
                Console.WriteLine("4) Generate rebate check.");
                Console.WriteLine("5) Exit System.");
                do
                {
                    Console.Write("Please select a task 1-5: ");
                    string s = Console.ReadLine();
                
                    input = Int32.Parse(s);
                    if (input == 1)
                    {
                        UIofCreateSaleTrasaction();
                    }
                    else if(input == 2)
                    {
                        UIofReturnitems();
                    }
                    else if(input == 3)
                    {
                        UIofAddRebate();
                    }
                    else if(input == 4)
                    {
                        UIofGenerateRebateCheck();
                    }
                    else
                    {
                        Console.WriteLine("Tanks for using our system.\n System Exiting...");
                    }
                } while (input != 1 && input != 2 && input != 3 && input != 4 && input != 5);
               
            } while (input != 5);
            
        }

        private static void UIofCreateSaleTrasaction()
        {
            bool back = false;
            do
            {
                try
                {
                    Console.WriteLine("Create sale transaction: ");
                    Console.WriteLine("Please fill out all information below to complete transaction.");
                    Console.Write("First name:");
                    string firstName = Console.ReadLine();
                    Console.Write("Last name:");
                    string lastName = Console.ReadLine();
                    Console.Write("Address:");
                    string address = Console.ReadLine();
                    Console.Write("Email:");
                    string email = Console.ReadLine();
                    string input;
                    int count = 1;
                    List<string> items = new List<string>();
                    List<double> cost = new List<double>();
                    do
                    {
                        Console.Write("Enter your #" + count + " item: ");
                        input = Console.ReadLine();
                        items.Add(input);
                        Console.Write("Enter the cost of your #" + count + " item: $");
                        input = Console.ReadLine();
                        cost.Add(Convert.ToDouble(input));
                        do
                        {
                            Console.Write("Would you like to add another item?(y/n)");
                            input = Console.ReadLine().ToLower();
                        } while (confirm(input));
                        count++;
                    } while (input == "y");

                    Console.WriteLine("\nTransaction: ");
                    Console.WriteLine("First name: " + firstName);
                    Console.WriteLine("Last name: " + lastName);
                    Console.WriteLine("Address: " + address);
                    Console.WriteLine("Email: " + email);

                    double total = 0.0;
                    Console.WriteLine("Item(s) purchased: ");
                    for (int i = 0; i < items.Count; i++)
                    {
                        Console.WriteLine("#" + (i + 1) + " item " + items[i] + " and Cost: $" + cost[i]);
                        total += cost[i];
                    }
                    Console.WriteLine("Total is: $" + total);

                    do
                    {
                        Console.Write("\nTransaction Confirm(y/n): ");
                        input = Console.ReadLine().ToLower();
                    } while (confirm(input));

                    if (input == "y")
                    {
                        Transaction tran = new Transaction(firstName, lastName, address, email, items, cost);
                        int id = tran.IDGenerator();
                        DataBase db = new DataBase(id, tran);
                        Console.WriteLine("Transaction completed!");
                    }
                    else
                    {
                        Console.WriteLine("Transaction cancelled!");
                    }

                    do
                    {
                        Console.Write("Would you like to add another transaction?(y/n) ");
                        input = Console.ReadLine();
                    } while (confirm(input));
                    if(input == "n")
                    {
                        back = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    Console.WriteLine("Error! Back to top.");
                }
            } while (back == false);
        }

        private static void UIofReturnitems()
        {

        }

        private static void UIofAddRebate()
        {

        }

        private static void UIofGenerateRebateCheck()
        {

        }
        private static bool confirm(string input)
        {
            if (input == "y" || input == "n") return false;
            else return true;
        }
    }
}
