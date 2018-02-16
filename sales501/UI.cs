using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales501
{
    class UI
    {
        public static void startUI()
        {
            mainUI();
        }

        private static void mainUI()
        {
            int input;
            Console.WriteLine("Welcome to use sales501 Sysytem.");
            
            do
            {
                Console.WriteLine("\nMain:");
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
                    else if (input == 5)
                    {
                        Console.WriteLine("Tanks for using our system.\nSystem Exiting...");
                    }
                } while (input != 1 && input != 2 && input != 3 && input != 4 && input != 5);
               
            } while (input < 5);
            
        }

        private static void UIofCreateSaleTrasaction()
        {
            bool back = false;
            do
            {
                try
                {
                    Console.WriteLine("\nCreate sale transaction: ");
                    Console.WriteLine("Please fill out all information below to complete transaction.");
                    Console.Write("First name:");
                    string firstName = Console.ReadLine();
                    Console.Write("Last name:");
                    string lastName = Console.ReadLine();
                    Console.Write("Address:");
                    string address = Console.ReadLine();
                    Console.Write("Email:");
                    string email = Console.ReadLine();
                    bool redo = false;
                    string input;
                    string[] date;
                    do {
                        Console.Write("Date of today(MM/DD/YYYY): ");
                        input = Console.ReadLine();
                        date = input.Split('/');
                        if (!checkDateformat(Int32.Parse(date[0]), Int32.Parse(date[1]), Int32.Parse(date[2])))
                        {
                            Console.WriteLine("Date invalid!");
                            redo = true;
                        }
                        else redo = false;
                    } while (redo);


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
                    Console.WriteLine("Date: " + date[0] + "/" + date[1] + "/" + date[2]);
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
                        Transaction tran = new Transaction(firstName, lastName, address, email, items, cost,total,Int32.Parse(date[0]), Int32.Parse(date[1]), Int32.Parse(date[2]));
                        int id = Transaction.IDGenerator();
                        Console.WriteLine("Your ID number is : " + Transaction.IDFormat(id));
                        DataBase.AddTransaction(id, tran);
                        
                        Console.WriteLine("Transaction completed!\n");
                    }
                    else
                    {
                        Console.WriteLine("Transaction cancelled!\n");
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
            bool back = false;
            do
            {
                try
                {
                    string input;
                    
                    Console.WriteLine("\nReturn item(s):");
                    do
                    {
                        bool redo = false;
                        string[] date;
                        do
                        {   
                            Console.Write("Date of today(MM/DD/YYYY): ");
                            input = Console.ReadLine();
                            date = input.Split('/');
                            if (!checkDateformat(Int32.Parse(date[0]), Int32.Parse(date[1]), Int32.Parse(date[2])))
                            {
                                Console.WriteLine("Date invalid!");
                                redo = true;
                            }
                            else redo = false;
                        } while (redo);
                        Console.Write("Enter the transaction ID you want to return: ");
                        input = Console.ReadLine();
                        int id = Int32.Parse(input);
                        if (!DataBase.TransactionExist(id)) Console.WriteLine("This transaction does not exist.");
                        else
                        {
                            Transaction tran = DataBase.GetTransaction(id);
                            if (!ReturnItems.ReturnAllowed(id, Int32.Parse(date[0]), Int32.Parse(date[2]))) Console.WriteLine("This transaction has been rebated, so it cannot return.");
                            else
                            {
                                Console.WriteLine("Here is the list of your items: ");
                                Console.WriteLine(DataBase.PrintItemsAndCost(id));
                                do
                                {
                                    Console.Write("Which item you would like to return? (Please type the name of the item)");
                                    input = Console.ReadLine();
                                    ReturnItems re = new ReturnItems(id, input);
                                    do
                                    {
                                        Console.Write("Would you like to return another one?(y/n) ");
                                        input = Console.ReadLine().ToLower();
                                    } while (confirm(input));

                                } while (input == "y");
                            }
                        }
                        do
                        {
                            Console.Write("Would you like return another transaction? (y/n) ");
                            input = Console.ReadLine().ToLower();
                        } while (confirm(input));
                    } while (input == "y");

                    back = true;
                }catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                    Console.WriteLine("Error! Back to top.");
                }
            } while (back == false);
        }

        private static void UIofAddRebate()
        {
            bool back = false;
            do
            {
                try
                {
                    string input;
                    Console.WriteLine("\nEnter Rebate: ");
                    do
                    {
                        Console.Write("Enter transaction ID you want to add rebate: ");
                        input = Console.ReadLine();
                        int id = Int32.Parse(input);
                        if (!DataBase.TransactionExist(id)) Console.WriteLine("This transaction does not exist.");
                        else
                        {
                            if (DataBase.GetTransaction(id).Month != 6) Console.WriteLine("This transaction is not established on June.");
                            else
                            {
                                bool redo = false;
                                string[] date;
                                do
                                {
                                    Console.Write("Date of today(MM/DD/YYYY): ");
                                    input = Console.ReadLine();
                                    date = input.Split('/');
                                    if (!checkDateformat(Int32.Parse(date[0]), Int32.Parse(date[1]), Int32.Parse(date[2])))
                                    {
                                        Console.WriteLine("Date invalid!");
                                        redo = true;
                                    }
                                    else redo = false;
                                } while (redo);


                                if (Int32.Parse(date[0]) > 7) Console.WriteLine("Exceed the rebate date.");
                                else if (Int32.Parse(date[0]) == 7 && Int32.Parse(date[1]) > 15) Console.WriteLine("Exceed the rebate date.");
                                else if (!Rebate.RebateAllowed(id, Int32.Parse(date[2]))) Console.WriteLine("This transaction is not allowed to rebate!");
                                else
                                {
                                    Console.Write("Enter the amount you would like to rebate(ex: if rebate 11%, enter 11): ");
                                    input = Console.ReadLine();
                                    double rebate = Convert.ToDouble(input);
                                    Rebate reb = new Rebate(rebate, Int32.Parse(date[0]), Int32.Parse(date[1]), Int32.Parse(date[2]));
                                    DataBase.AddRebate(id, reb);
                                    Console.WriteLine("Rebate complete.");
                                }
                            }

                            do
                            {
                                Console.Write("Would you like rebate another transaction? (y/n) ");
                                input = Console.ReadLine().ToLower();
                            } while (confirm(input));
                        }
                    } while (input == "y");
                    back = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    Console.WriteLine("Error! Back to top.");
                }
            } while (back == false);
        }

        private static void UIofGenerateRebateCheck()
        {
            Console.WriteLine("\nRebate Check(s): ");
            Console.WriteLine(DataBase.GenerateRebateCheck());
            Console.WriteLine("Press anything to continue.");
            Console.ReadLine();
        }
        private static bool confirm(string input)
        {
            if (input == "y" || input == "n") return false;
            else return true;
        }

        private static bool checkDateformat(int month, int day, int year)
        {
            if (month > 12) return false;
            else if (day > 31) return false;
            else if ((month == 4 || month == 6 || month == 9 || month == 11) && day > 30) return false;
            else if (month == 2 && day > 28) return false;
            else return true;
        }
    }
}
