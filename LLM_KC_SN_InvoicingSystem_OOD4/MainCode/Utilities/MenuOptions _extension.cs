using MainCode.Models;
using MainCode.Repository;
using static MainCode.Utilities.MainCodeStaticObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using MainCode.Repository.CustomerOptions;

namespace MainCode.Utilities
{
    internal partial class MenuOptions
    {
        /// <summary>
        /// A summary about MenuOptions extended Class
        /// </summary>
        /// <remarks>
        /// These remarks explain more about the MenuOptions extended class and methods 
        ///  
        /// public static void CustomerMenu()  
        /// This is the customers main menu which shows all the available options for the customers.
        /// 
        /// </remarks>
        public static void CustomerMenu()
        {
            string exitMenu = "99";
            string menuOption = "";

            do
            {
                Console.WriteLine("\nThe Bug Stoppers Invoicing System Customer Main Menu\n==================================================================");
                Person.GetDetails();
                Console.WriteLine("==================================================================");
                Console.WriteLine("1. View My Invoices");
                Console.WriteLine("2. View Invoice Details");
                Console.WriteLine("3. Make Payment");
                Console.WriteLine("4. View Payment History");
                Console.WriteLine("5. Edit Contact Information");
                Console.WriteLine("6. View Contact Information");
                Console.WriteLine("99. Back to Main Menu");
                Console.WriteLine("x. Exit\nEnter your selected menu option: ");
                menuOption = Console.ReadLine();



                switch (menuOption)
                {
                    case "1":
                        CustomerOptions.ViewMyInvoices(Person.Id);
                        break;
                    case "2":
                        CustomerOptions.ViewInvoiceDetails(Person.Id);
                        break;
                    case "3":
                        CustomerOptions.MakePayment(Person.Id);
                        break;
                    case "4":
                        CustomerOptions.ViewPaymentHistory(Person.Id);
                        break;
                    case "5":
                        Console.WriteLine("Update Contact Information");
                        StringBuilder stringBuilder1 = new StringBuilder();
                        CustomerRepository customerRepository = new CustomerRepository();
                        int customerID = 0;
                        bool valid = int.TryParse(Person.Id.ToString(), out customerID);
                        if (valid)
                        {
                            Customer customer1 = new Customer();
                            List<Customer> customers1 = customerRepository.ReadGetAllRows();
                            customer1 = customers1.FirstOrDefault(c => c.CustomerID == customerID);
                            if (customer1 != null)
                            {


                                string firstName1 = "";
                                Console.WriteLine("Please enter first name (Leave blank if you do not want to update): ");
                                firstName1 = Console.ReadLine();
                                if (firstName1.Trim() == "")
                                {
                                    firstName1 = customer1.FirstName;
                                }
                                string surname1 = "";

                                Console.WriteLine("Please enter surname (Leave blank if you do not want to update): ");
                                surname1 = Console.ReadLine();
                                if (surname1.Trim() == "")
                                {
                                    surname1 = customer1.Surname;
                                }

                                string address1 = "";

                                Console.WriteLine("Please enter address (format to follow: {street number}, {street name}, {postal code}) (Leave blank if you do not want to update): ");
                                address1 = Console.ReadLine();
                                if (address1.Trim() == "")
                                {
                                    address1 = customer1.Address;
                                }

                                string phoneNumber1 = "";
                                Console.WriteLine("Please enter phone number (Leave blank if you do not want to update): ");
                                phoneNumber1 = Console.ReadLine();
                                if (phoneNumber1.Trim() == "")
                                {
                                    phoneNumber1 = customer1.PhoneNumber;
                                }

                                customer1.FirstName = firstName1;
                                customer1.Surname = surname1;
                                customer1.Address = address1;
                                customer1.PhoneNumber = phoneNumber1;
                                int count1 = 0;
                                do
                                {
                                    Console.WriteLine("Are you sure you want to update this customer (Y/N): ");
                                    string response = Console.ReadLine();
                                    if (response == "y" || response == "Y")
                                    {
                                        response = response.ToLower();
                                    }
                                    else if (response == "n" || response == "N")
                                    {
                                        response = response.ToLower();
                                    }

                                    switch (response)
                                    {
                                        case "y":
                                            stringBuilder1.AppendLine(CustomerOptions.UpdateContactInformation(customer1));
                                            Person.FirstName = firstName1;
                                            Person.Surname = surname1;
                                            CustomerRepository repository = new CustomerRepository();
                                            Customer customer = repository.ReadGetAllRows().FirstOrDefault(c => c.CustomerID == Person.Id);
                                            Console.WriteLine($"Your Updated Contact Information");

                                            Console.WriteLine($"ID: {customer.CustomerID}");
                                            Console.WriteLine($"First Name: {customer.FirstName}");
                                            Console.WriteLine($"Surname: {customer.Surname}");
                                            Console.WriteLine($"Email: {customer.Email}");
                                            Console.WriteLine($"Username: {customer.Username}");
                                            Console.WriteLine($"Address: {customer.Address}");
                                            Console.WriteLine($"Phone Number: {customer.PhoneNumber}");
                                            count1++;
                                            break;
                                        case "n":
                                            stringBuilder1.AppendLine("Update has been cancelled");
                                            count1++;
                                            break;
                                        default:
                                            Console.WriteLine("Wrong option, please try again");
                                            break;
                                    }
                                }
                                while (count1 == 0);
                            }
                            else
                            {
                                stringBuilder1.AppendLine("Customer does not exist");
                            }
                        }
                        else
                        {
                            stringBuilder1.AppendLine("Incorrect format of customer id, please try again");
                        }
                        Console.WriteLine(stringBuilder1.ToString());
                        break;
                    case "6":
                        CustomerOptions.ViewContactInformation(Person.Id);
                        break;
                    case "99":
                        return;
                    case "x":
                        Console.WriteLine("Goodbye");
                        Console.WriteLine("\nPress any key to continue ...");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please review the menu and Enter your selected menu option");
                        break;
                }
                Console.WriteLine("\nPress any key to continue ...");
                Console.ReadKey();
            }
            while (menuOption != exitMenu);
        } 
    }
}