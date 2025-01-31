using MainCode.Models;
using MainCode.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MainCode.Utilities.MainCodeStaticObjects;

namespace MainCode.Repository
{
    public class CustomerLoginHandller : LoginHandler
    {
        public bool LoginCheck(string username)
        {
            var customer = new Customer();
            try
            {
                loggerMainCode.Info("Customer logging in method - checking if username is correct");
                CustomerRepository customersRepository = new CustomerRepository();
                customer = customersRepository.ReadGetAllRows().FirstOrDefault(c => c.Username == username);
            }
            catch (Exception ex)
            {
                loggerMainCode.Error(ex.Message);
            }

            bool valid = customer != null ? true : false;
            return valid;
        }

        public override void Login(ref string userName)
        {
            char exitMenu = 'b';
            char menuOption = ' ';
            int count = 0;
            while (menuOption != exitMenu)
            {
                if (userName == "") 
                {
                    Console.Clear();
                    Console.WriteLine("\nThe Bug Stoppers Invoicing System Main Menu\n==================================================================");
                    Console.WriteLine("Enter your username (b to go to Main Menu): ");
                    userName = Console.ReadLine();
                }

                if (userName == "X" || userName == "x")
                {
                    menuOption = 'x';
                }
                bool checkLogin = LoginCheck(userName);

                if (checkLogin)
                {
                    menuOption = '1';
                }
                else if (userName == "b" || userName == "B")
                {
                    menuOption = 'b';
                }
                else if (successor != null)
                {
                    successor.Login(ref userName);
                    if (userName == "z")
                    {
                        count = 0;
                        menuOption = 'b';
                        userName = "";
                    }

                }

                switch (menuOption)
                {
                    case '1':
                        count++;
                        menuOption = 'b';
                        break;
                    case 'b':
                        break;
                    default:
                        Console.WriteLine("User does not exist, please try again");
                        Console.WriteLine("\nPress any key to continue ...");
                        Console.ReadKey();
                        break;
                }
            }
            if (count == 1)
            {
                try
                {
                    loggerMainCode.Info("Customer Login Handler - Customer is logging in");
                    CustomerRepository customersRepository = new CustomerRepository();
                    string username = userName;
                    var customer = customersRepository.ReadGetAllRows().FirstOrDefault(c => c.Username == username);
                    
                    person = new Person(customer.CustomerID, customer.FirstName, customer.Surname, customer.Username, customer.PasswordHash, customer.Salt, customer.EncrytionType);
                    MenuOptions.CustomerMenu();
                }
                catch (Exception ex) 
                { 
                    Console.WriteLine(ex.Message);
                    loggerMainCode.Error(ex.Message);
                }
            }
        }
    }
}
