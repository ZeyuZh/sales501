using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales501
{
    class UI
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to use sales501 Sysytem. \nMain:");
            Console.WriteLine("1) Create sale transaction.");
            Console.WriteLine("2) Return item(s).");
            Console.WriteLine("3) Enter rebate.");
            Console.WriteLine("4) Generate rebate check.");
            Console.WriteLine("5) Exit System.");
            Console.Write("Please select a task 1-5: ");
            string s = Console.ReadLine();
            int choose;
            choose = Int32.Parse(s);
            if(choose == 1)
            {
                UIofCreateSaleTrasaction();
            }
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
                    List <string> items = new List<string>();
                    List<int> cost = new List<int>();
                    do
                    {
                        Console.Write("Enter your #" + count + " item: ");
                        input = Console.ReadLine();
                        items.Add(input);
                        Console.Write("Enter the cost of your #" + count + " item: $");
                        input = Console.ReadLine();
                        cost.Add(Int32.Parse(input));
                        do
                        {
                            Console.Write("Would you like to add another item?(y/n)");
                            input = Console.ReadLine().ToLower();
                        } while (input != "n" && input != "y");
                        count++;
                    } while (input == "y");

                    Console.WriteLine("\nTransaction: ");
                    Console.WriteLine("First name: " + firstName);
                    Console.WriteLine("Last name: " + lastName);
                    Console.WriteLine("Address: " + address);
                    Console.WriteLine("Email: " + email);

                    Console.WriteLine("Item(s) purchased: ");
                    for(int i = 0; i < items.Count; i++)
                    {
                        Console.WriteLine("#" + (i + 1) + " item " + items[i] + " and Cost: $" + cost[i]);
                    }

                    do
                    {
                        Console.Write("\nTransaction Confirm(y/n): ");
                        input = Console.ReadLine().ToLower();
                    } while (input != "y" && input != "n");

                    if(input == "y")
                    {

                    }
                    else
                    {
                        Console.WriteLine("Transaction cancelled!");
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                    Console.WriteLine("Error! Back to top.");
                }
            } while (back == true);
            
            

        }
    }
}
