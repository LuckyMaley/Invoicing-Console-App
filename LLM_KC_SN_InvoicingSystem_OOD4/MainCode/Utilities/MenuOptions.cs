using MainCode.Models;
using MainCode.Repository;
using static MainCode.Utilities.MainCodeStaticObjects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainCode.Repository.EmployeeOptions;
using System.Xml.Linq;

namespace MainCode.Utilities
{
    /// <summary>
    /// A summary about MenuOptions Class
    /// </summary>
    /// <remarks>
    /// These remarks explain more about the MenuOptions class and methods 
    ///  
    /// public static void EmployeeMenu()  
    /// This method is the employee main menu which shows 6 available options for the employee.
    /// 
    /// public static void EmployeeMoreMenu(ref int count)
    /// This method is the employee more main menu which shows remainder of the available options for the employee.
    /// <param name="count">
    /// This is an integer that is taken in by the method for keeping track of where the menu is and to let the program hit the exit option.
    /// </param>
    /// 
    /// public static void EmployeeOptionOneSubMenu()
    /// This method is the employee sub menu which shows available options for the employee.
    /// 
    /// public static void EmployeeOptionTwoSubMenu()
    /// This method is the customer sub menu which shows available options for the employee.
    /// 
    /// public static void EmployeeOptionThreeSubMenu()
    /// This method is the product sub menu which shows available options for the employee.
    /// 
    /// public static void EmployeeOptionFourSubMenu()
    /// This method is the discount sub menu which shows available options for the employee.
    /// 
    /// public static void EmployeeOptionFiveSubMenu()
    /// This method is the invoice sub menu which shows available options for the employee.
    /// 
    /// public static void EmployeeOptionSevenSubMenu()
    /// This method is the invoice item sub menu which shows available options for the employee.
    /// 
    /// public static void EmployeeOptionEightSubMenu()
    /// This method is the payment sub menu which shows available options for the employee.
    /// 
    /// public static void EmployeeOptionNineSubMenu()
    /// This method is the invoice notes sub menu which shows available options for the employee.
    /// 
    /// </remarks>
    internal partial class MenuOptions
    {
        public static void EmployeeMenu()
        {
            string exitMenu = "99";
            string menuOption = "";
            int count = 0;
            if (count == 0)
            {
                while (menuOption != exitMenu)
                {
                    count = 0;
                    Console.Clear();
                    Console.WriteLine("\nThe Bug Stoppers Invoicing System Employee Main Menu\n==================================================================");
                    Person.GetDetails();
                    Console.WriteLine("==================================================================");
                    Console.WriteLine("1. Employees");
                    Console.WriteLine("2. Customers");
                    Console.WriteLine("3. Products");
                    Console.WriteLine("4. Discount");
                    Console.WriteLine("5. Invoice");
                    Console.WriteLine("6. More\nEnter your selected menu option: ");
                    menuOption = Console.ReadLine();



                    switch (menuOption)
                    {
                        case "1":
                            EmployeeOptionOneSubMenu();
                            break;
                        case "2":
                            EmployeeOptionTwoSubMenu();
                            break;
                        case "3":
                            EmployeeOptionThreeSubMenu();
                            break;
                        case "4":
                            EmployeeOptionFourSubMenu();
                            break;
                        case "5":
                            EmployeeOptionFiveSubMenu();
                            break;
                        case "6":
                            EmployeeMoreMenu(ref count);
                            if(count == 1)
                            {
                                menuOption = "99";
                            }
                            break;
                        default:
                            Console.WriteLine("Please review the menu and Enter your selected menu option");
                            break;
                    }
                }
            }
        }

        public static void EmployeeMoreMenu(ref int count)
        {
            string exitMenuMore = "x";
            string menuOption = "";

            while (menuOption != exitMenuMore)
            {
                Console.Clear();
                Console.WriteLine("\nThe Bug Stoppers Invoicing System Employee Main Menu\n==================================================================");
                Person.GetDetails();
                Console.WriteLine("==================================================================");
                Console.WriteLine("7. Invoice Items");
                Console.WriteLine("8. Payments");
                Console.WriteLine("9. Notes");
                Console.WriteLine("99. Back");
                Console.WriteLine("#. Main Menu");
                Console.WriteLine("x. Exit\nEnter your selected menu option: ");
                menuOption = Console.ReadLine();

                if (menuOption == "X")
                {
                    menuOption = menuOption.ToLower();
                }


                switch (menuOption)
                {
                    case "7":
                        EmployeeOptionSevenSubMenu();
                        break;
                    case "8":
                        EmployeeOptionEightSubMenu();
                        break;
                    case "9":
                        EmployeeOptionNineSubMenu();
                        break;
                    case "99":
                        menuOption = "x";
                        break;
                    case "#":
                        ++count;
                        menuOption = "x";
                        break;
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
            }
        }

        public static void EmployeeOptionOneSubMenu()
        {
            EmployeeRepository employeesRepository = new EmployeeRepository();
            RepositoryBase<Employee> employeesRepositoryBase = new EmployeeRepository();
            EmployeeOptions employeeOptions = new EmployeeOptions(employeesRepository, employeesRepositoryBase);
            string exitMenu = "99";
            string menuOption = "";

            while (menuOption != exitMenu)
            {
                Console.Clear();
                Console.WriteLine("\nThe Bug Stoppers Invoicing System Sub Menu\n==================================================================");
                Person.GetDetails();
                Console.WriteLine("==================================================================");
                Console.WriteLine("1. Display All Employees");
                Console.WriteLine("2. Search Employee by ID");
                Console.WriteLine("3. Search Employee by First Name");
                Console.WriteLine("4. Search Employee by First Name and Surname");
                Console.WriteLine("5. Add New Employee");
                Console.WriteLine("6. Edit Employee Details");
                Console.WriteLine("7. Remove Employee");
                Console.WriteLine("99. Back\nEnter your selected menu option: ");
                menuOption = Console.ReadLine();


                switch (menuOption)
                {
                    case "1":
                        ShowAllEmployees();
                        break;
                    case "2":
                        Console.WriteLine("Please enter the employee ID");
                        int employeeID = 0;
                        bool result = int.TryParse(Console.ReadLine(), out employeeID);

                        if (result)
                        {
                            Console.WriteLine(employeeOptions.FindEmployeeByID(employeeID));
                        }
                        else
                        {
                            Console.WriteLine("Please make sure that you insert a number for the id");
                        }

                        break;
                    case "3":
                        Console.WriteLine("Please enter employee first name: ");
                        string adName = Console.ReadLine();
                        Console.WriteLine(employeeOptions.FindEmployeeByFirstName(adName));
                        break;
                    case "4":
                        Console.WriteLine("Please enter employee first name: ");
                        string fName = Console.ReadLine();
                        Console.WriteLine("Please enter employee surname: ");
                        string lName = Console.ReadLine();
                        Console.WriteLine(employeeOptions.FindEmployeeByFullName(fName, lName));
                        break;
                    case "5":
                        Employee employee = new Employee();
                        List<Employee> employees = employeesRepository.ReadGetAllRows();
                        int newID = employees.Max(c => c.EmployeeID) + 1;

                        string firstName = "";
                        while (firstName.Trim() == "")
                        {
                            Console.WriteLine("Please enter first name: ");
                            firstName = Console.ReadLine();
                        }
                        string surname = "";
                        while (surname.Trim() == "")
                        {
                            Console.WriteLine("Please enter surname: ");
                            surname = Console.ReadLine();
                        }

                        string email = "";
                        while (email.Trim() == "")
                        {
                            Console.WriteLine("Please enter email (include @ in email): ");
                            email = Console.ReadLine();
                            while (!email.Contains("@"))
                            {
                                Console.WriteLine("Please enter email (include @ in email): ");
                                email = Console.ReadLine();
                            }
                        }

                        string username = "";
                        username = email.Substring(0, email.IndexOf("@"));


                        string address = "";
                        while (address.Trim() == "")
                        {
                            Console.WriteLine("Please enter address (format to follow: {street number}, {street name}, {postal code}): ");
                            address = Console.ReadLine();
                        }

                        string phoneNumber = "";
                        while (phoneNumber.Trim() == "")
                        {
                            Console.WriteLine("Please enter phone number");
                            phoneNumber = Console.ReadLine();
                        }

                        employee.EmployeeID = newID;
                        employee.FirstName = firstName;
                        employee.Surname = surname;
                        employee.Email = email;
                        employee.Username = username;
                        employee.Address = address;
                        employee.PhoneNumber = phoneNumber;
                        employee.Role = "Employee";
                        int count = 0;
                        do
                        {
                            Console.WriteLine("Are you sure you want to add this new employee (Y/N): ");
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
                                    Console.WriteLine(employeeOptions.AddNewEmployee(employee));
                                    count++;
                                    break;
                                case "n":
                                    Console.WriteLine("Insertion has been cancelled");
                                    count++;
                                    break;
                                default:
                                    Console.WriteLine("Wrong option, please try again");
                                    break;
                            }
                        }
                        while (count == 0);
                        break;
                    case "6":
                        StringBuilder stringBuilder = new StringBuilder();
                        Console.WriteLine("Please enter a employee id:");
                        int employeeID1 = 0;
                        bool valid = int.TryParse(Console.ReadLine(), out employeeID1);
                        if (valid)
                        {
                            Employee employee1 = new Employee();
                            List<Employee> employees1 = employeesRepository.ReadGetAllRows();
                            employee1 = employees1.FirstOrDefault(c => c.EmployeeID == employeeID1);
                            if (employee1 != null)
                            {


                                string firstName1 = "";
                                Console.WriteLine("Please enter first name (Leave blank if you do not want to update): ");
                                firstName1 = Console.ReadLine();
                                if (firstName1.Trim() == "")
                                {
                                    firstName1 = employee1.FirstName;
                                }
                                string surname1 = "";

                                Console.WriteLine("Please enter surname (Leave blank if you do not want to update): ");
                                surname1 = Console.ReadLine();
                                if (surname1.Trim() == "")
                                {
                                    surname1 = employee1.Surname;
                                }

                                string address1 = "";

                                Console.WriteLine("Please enter address (format to follow: {street number}, {street name}, {postal code}) (Leave blank if you do not want to update): ");
                                address1 = Console.ReadLine();
                                if (address1.Trim() == "")
                                {
                                    address1 = employee1.Address;
                                }

                                string phoneNumber1 = "";
                                Console.WriteLine("Please enter phone number");
                                phoneNumber1 = Console.ReadLine();
                                if (phoneNumber1.Trim() == "")
                                {
                                    phoneNumber1 = employee1.PhoneNumber;
                                }

                                employee1.FirstName = firstName1;
                                employee1.Surname = surname1;
                                employee1.Address = address1;
                                employee1.PhoneNumber = phoneNumber1;

                                int count1 = 0;
                                do
                                {
                                    Console.WriteLine("Are you sure you want to update this employee (Y/N): ");
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
                                            Console.WriteLine(employeeOptions.UpdateEmployee(employee1));
                                            count1++;
                                            break;
                                        case "n":
                                            stringBuilder.AppendLine("Update has been cancelled");
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
                                stringBuilder.AppendLine("Employee does not exist");
                            }

                        }
                        else
                        {
                            stringBuilder.AppendLine("Incorrect format of employee id, please try again");
                        }
                        Console.WriteLine(stringBuilder.ToString());
                        break;
                    case "7":
                        List<Employee> allOfTheEmployees = employeesRepository.ReadGetAllRows();
                        StringBuilder stringBuilder2 = new StringBuilder();
                        Console.WriteLine("Please enter the employee ID: ");
                        int employeeId = 0;
                        bool validNum = int.TryParse(Console.ReadLine(), out employeeId);
                        if (validNum)
                        {
                            bool exists = employeesRepository.CheckIfIdExists(employeeId);
                            if (exists)
                            {
                                int count2 = 0;
                                do
                                {
                                    Console.WriteLine("Are you sure you want to remove this employee (Y/N): ");
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
                                            stringBuilder2.AppendLine(employeeOptions.RemoveEmployee(employeeId));
                                            count2++;
                                            break;
                                        case "n":
                                            stringBuilder2.AppendLine("Deletion has been cancelled");
                                            count2++;
                                            break;
                                        default:
                                            Console.WriteLine("Wrong option, please try again");
                                            break;
                                    }
                                }
                                while (count2 == 0);

                            }
                            else
                            {
                                stringBuilder2.AppendLine("Employee ID does not exist");
                            }
                        }
                        else
                        {
                            stringBuilder2.AppendLine("Employee ID not in the correct format, please try again");
                        }
                        Console.WriteLine();
                        break;
                    case "99":
                        break;
                    default:
                        Console.WriteLine("Please review the menu and Enter your selected menu option");
                        break;
                }
                Console.WriteLine("\nPress any key to continue ...");
                Console.ReadKey();
            }
        }

        public static void EmployeeOptionTwoSubMenu()
        {
            CustomerRepository customersRepository = new CustomerRepository();
            RepositoryBase<Customer> customersRepositoryBase = new CustomerRepository();
            IRepository<Customer> customersIRepository = new CustomerRepository();
            CustomerOptions customerOptions = new CustomerOptions(customersRepository, customersRepositoryBase, customersIRepository);

            string exitMenu = "99";
            string menuOption = "";

            while (menuOption != exitMenu)
            {
                Console.Clear();
                Console.WriteLine("\nThe Bug Stoppers Invoicing System Sub Menu\n==================================================================");
                Person.GetDetails();
                Console.WriteLine("==================================================================");
                Console.WriteLine("1. Display All Customers");
                Console.WriteLine("2. Search Customer by ID");
                Console.WriteLine("3. Search Customer by First Name");
                Console.WriteLine("4. Search Customer by First Name and Surname");
                Console.WriteLine("5. Add New Customer");
                Console.WriteLine("6. Edit Customer");
                Console.WriteLine("7. Remove Customer");
                Console.WriteLine("8. Generate Customer Invoice");
                Console.WriteLine("99. Back\nEnter your selected menu option: ");
                menuOption = Console.ReadLine();


                switch (menuOption)
                {
                    case "1":
                        ShowAllCustomers();
                        break;
                    case "2":
                        Console.WriteLine("Please enter the customer ID");
                        int cusID = 0;
                        bool result = int.TryParse(Console.ReadLine(), out cusID);
                        if (result)
                        {
                            Console.WriteLine(customerOptions.FindCustomerByID(cusID));
                        }
                        else
                        {
                            Console.WriteLine("Please make sure that you insert a number for the id");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Please enter customer first name: ");
                        string cusName = Console.ReadLine();
                        Console.WriteLine(customerOptions.FindCustomerByFirstName(cusName));
                        break;
                    case "4":
                        Console.WriteLine("Please enter customer first name: ");
                        string cusName1 = Console.ReadLine();
                        Console.WriteLine("Please enter customer surname: ");
                        string lName = Console.ReadLine();
                        Console.WriteLine(customerOptions.FindCustomerByFullName(cusName1, lName));
                        break;
                    case "5":
                        StringBuilder stringBuilder = new StringBuilder();
                        Customer customer = new Customer();
                        List<Customer> customers = customersRepository.ReadGetAllRows();
                        int newID = customers.Max(c => c.CustomerID) + 1;


                        string firstName = "";
                        while (firstName.Trim() == "")
                        {
                            Console.WriteLine("Please enter first name: ");
                            firstName = Console.ReadLine();
                        }
                        string surname = "";
                        while (surname.Trim() == "")
                        {
                            Console.WriteLine("Please enter surname: ");
                            surname = Console.ReadLine();
                        }

                        string email = "";
                        while (email.Trim() == "")
                        {
                            Console.WriteLine("Please enter email (include @ in email): ");
                            email = Console.ReadLine();
                            while (!email.Contains("@"))
                            {
                                Console.WriteLine("Please enter email (include @ in email): ");
                                email = Console.ReadLine();
                            }
                        }

                        string username = "";
                        username = email.Substring(0, email.IndexOf("@"));


                        string address = "";
                        while (address.Trim() == "")
                        {
                            Console.WriteLine("Please enter address (format to follow: {street number}, {street name}, {postal code}): ");
                            address = Console.ReadLine();
                        }

                        string phoneNumber = "";
                        while (phoneNumber.Trim() == "")
                        {
                            Console.WriteLine("Please enter phone number");
                            phoneNumber = Console.ReadLine();
                        }

                        customer.CustomerID = newID;
                        customer.FirstName = firstName;
                        customer.Surname = surname;
                        customer.Email = email;
                        customer.Username = username;
                        customer.Address = address;
                        customer.PhoneNumber = phoneNumber;
                        int count = 0;
                        do
                        {
                            Console.WriteLine("Are you sure you want to add this new customer (Y/N): ");
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
                                    stringBuilder.AppendLine(customerOptions.AddNewCustomer(customer));
                                    count++;
                                    break;
                                case "n":
                                    stringBuilder.AppendLine("Insertion has been cancelled");
                                    count++;
                                    break;
                                default:
                                    Console.WriteLine("Wrong option, please try again");
                                    break;
                            }
                        }
                        while (count == 0);
                        Console.WriteLine(stringBuilder.ToString());
                        break;
                    case "6":
                        StringBuilder stringBuilder1 = new StringBuilder();
                        Console.WriteLine("Please enter a customer id:");
                        int customerID = 0;
                        bool valid = int.TryParse(Console.ReadLine(), out customerID);
                        if (valid)
                        {
                            Customer customer1 = new Customer();
                            List<Customer> customers1 = customersRepository.ReadGetAllRows();
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
                                Console.WriteLine("Please enter phone number");
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
                                            stringBuilder1.AppendLine(customerOptions.UpdateCustomer(customer1));
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
                    case "7":
                        StringBuilder sb = new StringBuilder();
                        List<Customer> allOfTheCustomers = customersRepository.ReadGetAllRows();
                        Console.WriteLine("Please enter the customer ID: ");
                        int cusId = 0;
                        bool validNum = int.TryParse(Console.ReadLine(), out cusId);
                        if (validNum)
                        {
                            bool exists = customersRepository.CheckIfIdExists(cusId);
                            if (exists)
                            {
                                int count2 = 0;
                                do
                                {
                                    Console.WriteLine("Are you sure you want to remove this customer (Y/N): ");
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
                                            sb.AppendLine(customerOptions.RemoveCustomer(cusId));
                                            count2++;
                                            break;
                                        case "n":
                                            sb.AppendLine("Deletion has been cancelled");
                                            count2++;
                                            break;
                                        default:
                                            Console.WriteLine("Wrong option, please try again");
                                            break;
                                    }
                                }
                                while (count2 == 0);

                            }
                            else
                            {
                                sb.AppendLine("Customer ID does not exist");
                            }
                        }
                        else
                        {
                            sb.AppendLine("Customer ID not in the correct format, please try again");
                        }
                        Console.WriteLine(sb.ToString());
                        break;
                    case "8":
                        InvoicesRepository invoicesRepository = new InvoicesRepository();
                        DiscountRepository discountsRepository = new DiscountRepository();
                        InvoiceOptions invoiceOptions = new InvoiceOptions(invoicesRepository, discountsRepository);
                        List<Customer> allOfTheCustomers2 = customersRepository.ReadGetAllRows();
                        CultureInfo ci = new CultureInfo("en-za");
                        Console.WriteLine("Please enter the customer ID: ");
                        int cusId2 = 0;
                        bool validNum3 = int.TryParse(Console.ReadLine(), out cusId2);
                        if (validNum3)
                        {
                            bool exists1 = customersRepository.CheckIfIdExists(cusId2);
                            if (exists1)
                            {

                                List<int> productIds = new List<int>();
                                List<int> quantities = new List<int>();
                                int addcount = 0;
                                ProductRepository productRepository = new ProductRepository();
                                List<Product> allOfTheProducts = productRepository.ReadGetAllRows();
                                while (addcount == 0)
                                {
                                    Console.WriteLine("====================================Products========================================");
                                    allOfTheProducts.ForEach(b => Console.WriteLine($"ID: {b.ProductID}, Name: {b.ProductName}, Description: {b.Description}, Price: {b.Price.ToString("C", ci)}, Quantity: {b.StockQuantity}"));
                                    Console.WriteLine();
                                    Console.WriteLine("Please enter the product ID:");
                                    int productId = 0;
                                    bool prodresult = int.TryParse(Console.ReadLine(), out productId);
                                    if (prodresult)
                                    {
                                        int valid3 = allOfTheProducts.Where(c => c.ProductID == productId).Count();
                                        if (valid3 > 0)
                                        {
                                            Console.Write("Enter Quantity: ");
                                            int quantity = 0;
                                            bool qtyresult = int.TryParse(Console.ReadLine(), out quantity);
                                            while (!qtyresult || quantity == 0)
                                            {
                                                Console.WriteLine("Please enter the quantity (must be a number and greater than zero):");
                                                qtyresult = int.TryParse(Console.ReadLine(), out quantity);
                                            }

                                            productIds.Add(productId);
                                            allOfTheProducts.RemoveAll(c => c.ProductID == productId);
                                            quantities.Add(quantity);
                                            Console.WriteLine("Do you want to add another product? (Y/N):");
                                            string userInput = Console.ReadLine();
                                            if (userInput == "y" || userInput == "Y")
                                            {
                                                userInput = "y";
                                            }
                                            else if (userInput == "n" || userInput == "N")
                                            {
                                                addcount++;
                                            }
                                            if (allOfTheProducts.Count == 0)
                                            {
                                                addcount++;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Product does not exist, Please try again");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Please enter a number");
                                    }
                                    
                                }
                                Console.WriteLine("Please type in the invoice note: ");
                                string note = Console.ReadLine();
                                invoiceOptions.GenerateInvoice(cusId2,1, Person.Id, note, productIds, quantities);
                            }
                            else
                            {
                                Console.WriteLine("Customer ID does not exist");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Customer ID not in the correct format, please try again");
                        }
                        break;
                    case "99":
                        break;
                    default:
                        Console.WriteLine("Please review the menu and Enter your selected menu option");
                        break;
                }
                Console.WriteLine("\nPress any key to continue ...");
                Console.ReadKey();
            }
        }

        public static void EmployeeOptionThreeSubMenu()
        {
            
            ProductRepository productsRepository = new ProductRepository();
            RepositoryBase<Product> repositoryBase = new ProductRepository();
            ProductOptions productOptions = new ProductOptions(productsRepository, repositoryBase);
            string exitMenu = "99";
            string menuOption = "";

            while (menuOption != exitMenu)
            {
                Console.Clear();
                Console.WriteLine("\nThe Bug Stoppers Invoicing System Sub Menu\n==================================================================");
                Person.GetDetails();
                Console.WriteLine("==================================================================");
                Console.WriteLine("1. Display All Products");
                Console.WriteLine("2. Search Product by ID");
                Console.WriteLine("3. Search Product by Name");
                Console.WriteLine("4. Add New Product");
                Console.WriteLine("5. Edit Product");
                Console.WriteLine("6. Remove Product");
                Console.WriteLine("99. Back\nEnter your selected menu option: ");
                menuOption = Console.ReadLine();


                switch (menuOption)
                {
                    case "1":
                        ShowAllProducts();
                        break;
                    case "2":
                        Console.WriteLine("Please enter the product ID");
                        int prodID = 0;
                        bool result = int.TryParse(Console.ReadLine(), out prodID);
                        if (result)
                        {
                            Console.WriteLine(productOptions.FindProductByID(prodID));
                        }
                        else
                        {
                            Console.WriteLine("Please make sure that you insert a number for the id");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Please enter product name: ");
                        string prodName = Console.ReadLine();
                        Console.WriteLine(productOptions.FindProductByName(prodName));
                        break;
                    case "4":
                        Product product = new Product();
                        List<Product> products = productsRepository.ReadGetAllRows();
                        int newID = products.Max(c => c.ProductID) + 1;
                        StringBuilder sb = new StringBuilder();

                        string name = "";
                        while (name.Trim() == "")
                        {
                            Console.WriteLine("Please enter product name: ");
                            name = Console.ReadLine();
                        }

                        string description = "";
                        while (description.Trim() == "")
                        {
                            Console.WriteLine("Please enter product description: ");
                            description = Console.ReadLine();
                        }



                        decimal price = 0m;
                        int priceCount = 0;
                        bool validPrice = false;
                        CultureInfo ci = new CultureInfo("en-za");
                        while (priceCount == 0)
                        {
                            Console.WriteLine("Please enter product price (The , sign represents the decimal point if you want to include it): ");
                            validPrice = decimal.TryParse(Console.ReadLine(), NumberStyles.AllowDecimalPoint, ci, out price);
                            if (validPrice)
                            {
                                priceCount++;
                            }
                        }



                        int stockQuantity = 0;
                        int stockCount = 0;
                        bool validStock = false;
                        while (stockCount == 0)
                        {
                            Console.WriteLine("Please enter product Stock Quantity: ");
                            validStock = int.TryParse(Console.ReadLine(), out stockQuantity);
                            if (validStock)
                            {
                                stockCount++;
                            }
                        }

                        product.ProductID = newID;
                        product.ProductName = name;
                        product.Description = description;
                        product.Price = price;
                        product.StockQuantity = stockQuantity;

                        int count = 0;
                        do
                        {
                            Console.WriteLine("Are you sure you want to add this new product (Y/N): ");
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
                                    Console.WriteLine(productOptions.AddNewProduct(product));
                                    count++;
                                    break;
                                case "n":
                                    sb.AppendLine("Insertion has been cancelled");
                                    count++;
                                    break;
                                default:
                                    Console.WriteLine("Wrong option, please try again");
                                    break;
                            }
                        }
                        while (count == 0);
                        Console.WriteLine(sb.ToString());
                        break;
                    case "5":
                        Console.WriteLine("Please enter a Product id:");
                        int productID = 0;
                        bool valid = int.TryParse(Console.ReadLine(), out productID);
                        StringBuilder sb1 = new StringBuilder();
                        if (valid)
                        {
                            Product product1 = new Product();
                            List<Product> products1 = productsRepository.ReadGetAllRows();
                            product1 = products1.FirstOrDefault(c => c.ProductID == productID);
                            if (product1 != null)
                            {


                                string name1 = "";
                                Console.WriteLine("Please enter product name (Leave blank if you do not want to update): ");
                                name1 = Console.ReadLine();
                                if (name1.Trim() == "")
                                {
                                    name1 = product1.ProductName;
                                }




                                string description1 = "";
                                Console.WriteLine("Please enter product description (Leave blank if you do not want to update): ");
                                description1 = Console.ReadLine();
                                if (description1.Trim() == "")
                                {
                                    description1 = product1.Description;
                                }



                                decimal price1 = 0m;
                                int priceCount1 = 0;
                                bool validPrice1 = false;
                                CultureInfo ci1 = new CultureInfo("en-za");
                                while (priceCount1 == 0)
                                {
                                    Console.WriteLine("Please enter product price (The , sign represents the decimal point if you want to include it): ");
                                    validPrice1 = decimal.TryParse(Console.ReadLine(), NumberStyles.AllowDecimalPoint, ci1, out price1);
                                    if (validPrice1)
                                    {
                                        priceCount1++;
                                    }
                                }



                                int stockQuantity1 = 0;
                                int stockCount1 = 0;
                                bool validStock1 = false;
                                while (stockCount1 == 0)
                                {
                                    Console.WriteLine("Please enter product Stock Quantity: ");
                                    validStock1 = int.TryParse(Console.ReadLine(), out stockQuantity1);
                                    if (validStock1)
                                    {
                                        stockCount1++;
                                    }
                                }

                                product1.ProductName = name1;
                                product1.Description = description1;
                                product1.Price = price1;
                                product1.StockQuantity = stockQuantity1;
                                int count1 = 0;
                                do
                                {
                                    Console.WriteLine("Are you sure you want to update this product (Y/N): ");
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
                                            Console.WriteLine(productOptions.UpdateProduct(product1));
                                            count1++;
                                            break;
                                        case "n":
                                            sb1.AppendLine("Update has been cancelled");
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
                                sb1.AppendLine("Product does not exist");
                            }
                        }
                        else
                        {
                            sb1.AppendLine("Incorrect format of product id, please try again");
                        }
                        Console.WriteLine(sb1.ToString());
                        break;
                    case "6":
                        StringBuilder stringBuilder = new StringBuilder();
                        List<Product> allOfTheProducts = productsRepository.ReadGetAllRows();
                        Console.WriteLine("Please enter the product ID: ");
                        int prodId = 0;
                        bool validNum = int.TryParse(Console.ReadLine(), out prodId);
                        if (validNum)
                        {
                            bool exists = productsRepository.CheckIfIdExists(prodId);
                            if (exists)
                            {
                                int count1 = 0;
                                do
                                {
                                    Console.WriteLine("Are you sure you want to remove this product (Y/N): ");
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
                                            Console.WriteLine(productOptions.RemoveProduct(prodId));
                                            count1++;
                                            break;
                                        case "n":
                                            stringBuilder.AppendLine("Deletion has been cancelled");
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
                                stringBuilder.AppendLine("Product ID does not exist");
                            }
                        }
                        else
                        {
                            stringBuilder.AppendLine("Product ID not in the correct format, please try again");
                        }
                        Console.WriteLine(stringBuilder.ToString());
                        break;
                    case "99":
                        break;
                    default:
                        Console.WriteLine("Please review the menu and Enter your selected menu option");
                        break;
                }
                Console.WriteLine("\nPress any key to continue ...");
                Console.ReadKey();
            }
        }

        public static void EmployeeOptionFourSubMenu()
        {
            DiscountRepository discountRepository = new DiscountRepository();
            RepositoryBase<Discount> discountRepositoryBase = new DiscountRepository();
            DiscountOptions discountOptions = new DiscountOptions(discountRepository, discountRepositoryBase);


            string exitMenu = "99";
            string menuOption = "";

            while (menuOption != exitMenu)
            {
                Console.Clear();
                Console.WriteLine("\nThe Bug Stoppers Invoicing System Sub Menu\n==================================================================");
                Person.GetDetails();
                Console.WriteLine("==================================================================");
                Console.WriteLine("1. Display All Discounts");
                Console.WriteLine("2. Search Discounts by ID");
                Console.WriteLine("3. Search Discounts by Name");
                Console.WriteLine("4. Add New Discounts");
                Console.WriteLine("5. Edit Discounts");
                Console.WriteLine("6. Remove Discounts");
                Console.WriteLine("99. Back\nEnter your selected menu option: ");
                menuOption = Console.ReadLine();


                switch (menuOption)
                {
                    case "1":
                        ShowAllDiscounts();
                        break;
                    case "2":
                        Console.WriteLine("Please enter the discount ID");
                        int discountID = 0;
                        bool result = int.TryParse(Console.ReadLine(), out discountID);

                        if (result)
                        {
                            Console.WriteLine(discountOptions.FindDiscountByID(discountID));
                        }
                        else
                        {
                            Console.WriteLine("Please make sure that you insert a number for the id");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Please enter product name: ");
                        string disName = Console.ReadLine();
                        Console.WriteLine(discountOptions.FindDiscountByName(disName));   
                        break;
                    case "4":
                        StringBuilder sb = new StringBuilder();
                        Discount discount = new Discount();
                        List<Discount> discounts = discountRepository.ReadGetAllRows();
                        int newID = discounts.Max(c => c.DiscountID) + 1;


                        string DiscountName = "";
                        while (DiscountName.Trim() == "")
                        {
                            Console.WriteLine("Please enter Discount  name: ");
                            DiscountName = Console.ReadLine();
                        }
                      

                        decimal rate = 0m;
                        int rateCount = 0;
                        bool validrate = false;
                        CultureInfo ci = new CultureInfo("en-za");
                        while (rateCount == 0)
                        {
                            Console.WriteLine("Please enter Discount price (The , sign represents the decimal point if you want to include it): ");
                            validrate = decimal.TryParse(Console.ReadLine(), NumberStyles.AllowDecimalPoint, ci, out rate);
                            if (validrate)
                            {
                                rateCount++;
                            }
                        }

                        double price = 0;
                        int priceCount = 0;
                        while (priceCount == 0)
                        {
                            Console.WriteLine("Please enter Discount amount (The , sign represents the decimal point if you want to include it): ");
                            price = double.Parse(Console.ReadLine());
                            
                        }
                        discount.DiscountID= newID;
                        discount.DiscountName=DiscountName;
                        discount.Rate= rate;
                        discount.Amount= price;


                        int count = 0;
                        do
                        {
                            Console.WriteLine("Are you sure you want to add this new discount (Y/N): ");
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
                                    Console.WriteLine(discountOptions.AddNewDiscount(discount));
                                    count++;
                                    break;
                                case "n":
                                    sb.AppendLine("Insertion has been cancelled");
                                    count++;
                                    break;
                                default:
                                    Console.WriteLine("Wrong option, please try again");
                                    break;
                            }
                        }
                        while (count == 0);
                        Console.WriteLine(sb.ToString());
                        break;
                    case "5":
                        Console.WriteLine("Please enter a Discount id:");
                        int DiscountID = 0;
                        bool valid = int.TryParse(Console.ReadLine(), out DiscountID);
                        StringBuilder sb1 = new StringBuilder();
                        if (valid)
                        {
                            Discount discount1 = new Discount();
                            List<Discount> discounts1 = discountRepository.ReadGetAllRows();
                            discount1 = discounts1.FirstOrDefault(c => c.DiscountID == DiscountID);
                            if (discount1 != null)
                            {


                                string name1 = "";
                                Console.WriteLine("Please enter Discount name (Leave blank if you do not want to update): ");
                                name1 = Console.ReadLine();
                                if (name1.Trim() == "")
                                {
                                    name1 = discount1.DiscountName;
                                }

                                double amount = 0;
                                int amountCount = 0;
                                while (amountCount == 0)
                                {
                                    Console.WriteLine("Please enter Discount price (The , sign represents the decimal point if you want to include it): ");
                                    amount = double.Parse(Console.ReadLine());

                                }


                                decimal rate1 = 0m;
                                int rateCount1 = 0;
                                bool validrate1 = false;
                                CultureInfo ci1 = new CultureInfo("en-za");
                                while (rateCount1 == 0)
                                {
                                    Console.WriteLine("Please enter Discount price (The , sign represents the decimal point if you want to include it): ");
                                    validrate1 = decimal.TryParse(Console.ReadLine(), NumberStyles.AllowDecimalPoint, ci1, out rate);
                                    if (validrate1)
                                    {
                                        rateCount1++;
                                    }
                                }

                                discount1.DiscountName = name1;
                                discount1.Rate = rate1;
                                discount1.Amount = amount;
                          
                                int count1 = 0;
                                do
                                {
                                    Console.WriteLine("Are you sure you want to update this product (Y/N): ");
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
                                            Console.WriteLine(discountOptions.UpdateDiscount(discount1));
                                            count1++;
                                            break;
                                        case "n":
                                            sb1.AppendLine("Update has been cancelled");
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
                                sb1.AppendLine("Discount does not exist");
                            }
                        }
                        else
                        {
                            sb1.AppendLine("Incorrect format of discount id, please try again");
                        }
                        Console.WriteLine(sb1.ToString());

                        break;
                    case "6":
                        StringBuilder stringBuilder = new StringBuilder();
                        List<Discount> allOfTheDiscounts = discountRepository.ReadGetAllRows();
                        Console.WriteLine("Please enter the Discount ID: ");
                        int DisId = 0;
                        bool validNum = int.TryParse(Console.ReadLine(), out DisId);
                        if (validNum)
                        {
                            bool exists = discountRepository.CheckIfidExists(DisId);
                            if (exists)
                            {
                                int count1 = 0;
                                do
                                {
                                    Console.WriteLine("Are you sure you want to remove this discount (Y/N): ");
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
                                            Console.WriteLine(discountOptions.RemoveDiscount(DisId));
                                            count1++;
                                            break;
                                        case "n":
                                            stringBuilder.AppendLine("Deletion has been cancelled");
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
                                stringBuilder.AppendLine("Discount ID does not exist");
                            }
                        }
                        else
                        {
                            stringBuilder.AppendLine("Discount ID not in the correct format, please try again");
                        }
                        Console.WriteLine(stringBuilder.ToString());
                        break;
                    case "99":
                        break;
                    default:
                        Console.WriteLine("Please review the menu and Enter your selected menu option");
                        break;
                }
                Console.WriteLine("\nPress any key to continue ...");
                Console.ReadKey();
            }
        }

        public static void EmployeeOptionFiveSubMenu()
        {
            InvoicesRepository invoicesRepository = new InvoicesRepository();
            DiscountRepository discountsRepository = new DiscountRepository();
            InvoiceOptions invoiceOptions = new InvoiceOptions(invoicesRepository, discountsRepository);
            string exitMenu = "99";
            string menuOption = "";

            while (menuOption != exitMenu)
            {
                Console.Clear();
                Console.WriteLine("\nThe Bug Stoppers Invoicing System Sub Menu\n==================================================================");
                Person.GetDetails();
                Console.WriteLine("==================================================================");
                Console.WriteLine("1. Display All Invoices");
                Console.WriteLine("2. Search Invoices by ID");
                Console.WriteLine("3. Search Invoices by Date");
                Console.WriteLine("4. Search Invoices between Dates");
                Console.WriteLine("99. Back\nEnter your selected menu option: ");
                menuOption = Console.ReadLine();


                switch (menuOption)
                {
                    case "1":
                        ShowAllInvoices();
                        break;
                    case "2":
                        Console.WriteLine("Please enter the invoice ID: ");
                        int invoiceID = 0;
                        bool result = int.TryParse(Console.ReadLine(), out invoiceID);
                        CultureInfo ci = new CultureInfo("en-za");
                        if (result)
                        {
                            Console.WriteLine(invoiceOptions.FindInvoiceByID(invoiceID));
                        }
                        else
                        {
                            Console.WriteLine("Please make sure that you insert a number for the id");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Please enter invoice date (dd/MM/yyyy): ");
                        string inputDate = Console.ReadLine();
                        if (inputDate != "")
                        {
                            Console.WriteLine(invoiceOptions.FindInvoicesbyDate(inputDate));
                        }
                        else
                        {
                            Console.WriteLine("No Date entered");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Please enter beginning invoice date (dd/MM/yyyy): ");
                        string inputDate1 = Console.ReadLine();
                        Console.WriteLine("Please enter ending invoice date (dd/MM/yyyy): ");
                        string inputDateTwo = Console.ReadLine();
                        if (inputDate1 != "" && inputDateTwo != "")
                        {
                            Console.WriteLine(invoiceOptions.FindInvoicesbyBetweenDates(inputDate1, inputDateTwo));
                        }
                        else
                        {
                            Console.WriteLine("Please enter both beginning and end dates");
                        }
                        break;
                    case "99":
                        break;
                    default:
                        Console.WriteLine("Please review the menu and Enter your selected menu option");
                        break;
                }
                Console.WriteLine("\nPress any key to continue ...");
                Console.ReadKey();
            }
        }

        public static void EmployeeOptionSevenSubMenu()
        {
            InvoiceItemsRepository _invoiceItemsRepository = new InvoiceItemsRepository();
            InvoicesRepository _invoicesRepository = new InvoicesRepository();
            InvoiceItemsOptions invoiceItemsOptions = new InvoiceItemsOptions(_invoiceItemsRepository, _invoicesRepository);

            string exitMenu = "99";
            string menuOption = "";

            while (menuOption != exitMenu)
            {
                Console.Clear();
                Console.WriteLine("\nThe Bug Stoppers Invoicing System Sub Menu\n==================================================================");
                Person.GetDetails();
                Console.WriteLine("==================================================================");
                Console.WriteLine("1. Display All Invoice Items");
                Console.WriteLine("2. Search Invoice by ID");
                Console.WriteLine("99. Back\nEnter your selected menu option: ");
                menuOption = Console.ReadLine();


                switch (menuOption)
                {
                    case "1":
                        ShowAllInvoiceItems();
                        break;
                    case "2":
                        Console.WriteLine("Please enter the invoice ID: ");
                        int invoiceID = 0;
                        bool result = int.TryParse(Console.ReadLine(), out invoiceID);
                        if (result)
                        {
                            Console.WriteLine(invoiceItemsOptions.FindInvoiceItemByInvoiceID(invoiceID));
                        }
                        else
                        {
                            Console.WriteLine("Please make sure that you insert a number for the id");
                        }
                        break;
                    case "99":
                        break;
                    default:
                        Console.WriteLine("Please review the menu and Enter your selected menu option");
                        break;
                }
                Console.WriteLine("\nPress any key to continue ...");
                Console.ReadKey();
            }
        }

        public static void EmployeeOptionEightSubMenu()
        {
            PaymentRepository _paymentsRepository = new PaymentRepository();
            RepositoryBase<Payment> _paymentsRepositoryBase = new PaymentRepository();
            PaymentOptions paymentOptions = new PaymentOptions(_paymentsRepository, _paymentsRepositoryBase);
            string exitMenu = "99";
            string menuOption = "";

            while (menuOption != exitMenu)
            {
                Console.Clear();
                Console.WriteLine("\nThe Bug Stoppers Invoicing System Sub Menu\n==================================================================");
                Person.GetDetails();
                Console.WriteLine("==================================================================");
                Console.WriteLine("1. Display All Payments");
                Console.WriteLine("2. Search Payment by Date");
                Console.WriteLine("3. Search Payment between Dates");
                Console.WriteLine("4. Search Payment by Method");
                Console.WriteLine("99. Back\nEnter your selected menu option: ");
                menuOption = Console.ReadLine();


                switch (menuOption)
                {
                    case "1":
                        ShowAllPayments();
                        break;
                    case "2":
                        Console.WriteLine("Please enter payment date (dd/MM/yyyy): ");
                        string inputDateSingle = Console.ReadLine();
                        Console.WriteLine(paymentOptions.FindPaymentsbyDate(inputDateSingle));
                        break;
                    case "3":
                        Console.WriteLine("Please enter beginning invoice date (dd/MM/yyyy): ");
                        string inputDate = Console.ReadLine();
                        Console.WriteLine("Please enter ending invoice date (dd/MM/yyyy): ");
                        string inputDateTwo = Console.ReadLine();
                        Console.WriteLine(paymentOptions.FindPaymentsbyBetweenDates(inputDate, inputDateTwo));
                        break;
                    case "4":
                        Console.WriteLine("Please enter the payment method: ");
                        string input = Console.ReadLine();
                        Console.WriteLine(paymentOptions.FindPaymentsByMethod(input));
                        break;
                    case "99":
                        break;
                    default:
                        Console.WriteLine("Please review the menu and Enter your selected menu option");
                        break;
                }
                Console.WriteLine("\nPress any key to continue ...");
                Console.ReadKey();
            }
        }

        public static void EmployeeOptionNineSubMenu()
        {
            NotesRepository _notesRepository = new NotesRepository();
            RepositoryBase<Note> _notesRepositoryBase = new NotesRepository();
            NotesOptions notesOptions = new NotesOptions(_notesRepository, _notesRepositoryBase);
            string exitMenu = "99";
            string menuOption = "";

            while (menuOption != exitMenu)
            {
                Console.Clear();
                Console.WriteLine("\nThe Bug Stoppers Invoicing System Sub Menu\n==================================================================");
                Person.GetDetails();
                Console.WriteLine("==================================================================");
                Console.WriteLine("1. Display All Invoice Notes");
                Console.WriteLine("2. Search Invoice Notes by ID");
                Console.WriteLine("3. Search Invoice Notes by Date");
                Console.WriteLine("4. Search Invoice Notes between Dates");
                Console.WriteLine("99. Back\nEnter your selected menu option: ");
                menuOption = Console.ReadLine();


                switch (menuOption)
                {
                    case "1":
                        ShowAllNotes();
                        break;
                    case "2":
                        Console.WriteLine("Please enter the note ID: ");
                        int noteID = 0;
                        bool result = int.TryParse(Console.ReadLine(), out noteID);
                        if (result)
                        {
                            Console.WriteLine(notesOptions.FindNotesByID(noteID));
                        }
                        else
                        {
                            Console.WriteLine("Please make sure that you insert a number for the id");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Please enter Note date (dd/MM/yyyy): ");
                        string inputDateSingle = Console.ReadLine();
                        Console.WriteLine(notesOptions.FindnotesbyDate(inputDateSingle));
                        break;
                    case "4":
                        Console.WriteLine("Please enter beginning note date (dd/MM/yyyy): ");
                        string inputDate = Console.ReadLine();
                        Console.WriteLine("Please enter ending note (dd/MM/yyyy): ");
                        string inputDateTwo = Console.ReadLine();
                        Console.WriteLine(notesOptions.FindnotesbyBetweenDates(inputDate, inputDateTwo));
                        break;
                    case "99":
                        break;
                    default:
                        Console.WriteLine("Please review the menu and Enter your selected menu option");
                        break;
                }
                Console.WriteLine("\nPress any key to continue ...");
                Console.ReadKey();
            }
        }


        static void ShowAllEmployees()
        {
            EmployeeRepository repository = new EmployeeRepository();
            List<Employee> allOfTheEmployees = repository.ReadGetAllRows();

            Console.WriteLine("\n Option 1 - All Employees");
            allOfTheEmployees.ForEach(b => Console.WriteLine($"ID: {b.EmployeeID}, First Name: {b.FirstName}, Surname: {b.Surname}, Email: {b.Email}, Username: {b.Username}, Address: {b.Address}, Phone Number: {b.PhoneNumber}"));
        }

        static void ShowAllCustomers()
        {
            Console.WriteLine("\nOption 2 - All Customers");
            CustomerRepository repository = new CustomerRepository();
            List<Customer> allOfTheCustomers = repository.ReadGetAllRows();
            allOfTheCustomers.ForEach(b => Console.WriteLine($"ID: {b.CustomerID}, First Name: {b.FirstName}, Surname: {b.Surname}, Email: {b.Email}, Username: {b.Username}, Address: {b.Address}, Phone Number: {b.PhoneNumber}"));
        }

        static void ShowAllProducts()
        {
            CultureInfo ci = new CultureInfo("en-za");
            ProductRepository repository = new ProductRepository();
            List<Product> allOfTheProducts = repository.ReadGetAllRows();
            Console.WriteLine("\nOption 3 - All Products");
            allOfTheProducts.ForEach(b => Console.WriteLine($"ID: {b.ProductID}, Name: {b.ProductName}, Description: {b.Description}, Price: {b.Price.ToString("C", ci)}, Quantity: {b.StockQuantity}"));
        }

        static void ShowAllDiscounts()
        {
            CultureInfo ci = new CultureInfo("en-za");
            DiscountRepository repository = new DiscountRepository();
            List<Discount> allOfTheDiscounts = repository.ReadGetAllRows();
            Console.WriteLine("\nOption 4 - All Discounts");
            allOfTheDiscounts.ForEach(b => Console.WriteLine($"ID: {b.DiscountID}, Name: {b.DiscountName}, Rate: {b.Rate}, Amount: {b.Amount.ToString("C", ci)}"));
        }

        static void ShowAllInvoices()
        {
            Console.WriteLine("\nOption 5 - All Invoices");
            InvoicesRepository invoiceRepository = new InvoicesRepository();
            List<Invoice> allOfTheInvoices = invoiceRepository.ReadGetAllRows();

            CustomerRepository repository = new CustomerRepository();
            List<Customer> allOfTheCustomers = repository.ReadGetAllRows();

            DiscountRepository discountsRepository = new DiscountRepository();
            List<Discount> allOfTheDiscounts = discountsRepository.ReadGetAllRows();
            CultureInfo ci = new CultureInfo("en-za");
            allOfTheInvoices.ForEach(b => Console.WriteLine($"ID: {b.InvoiceID}, Customer Name: {allOfTheCustomers.FirstOrDefault(z => z.CustomerID == b.CustomerID).FirstName + " " + allOfTheCustomers.FirstOrDefault(z => z.CustomerID == b.CustomerID).Surname}, Invoice Date: {b.InvoiceDate.ToString("dd MMMM yyyy HH:mm")}, Payment Due Date: {b.DueDate.ToString("dd MMMM yyyy HH:mm")}, Subtotal: {b.Subtotal}, Tax: {b.Tax}, Discount: {allOfTheDiscounts.FirstOrDefault(c => c.DiscountID == b.DiscountID).DiscountName}, Totat Amount: {b.TotalAmount.ToString("C", ci)}, Status: {b.Status}"));
        }

        static void ShowAllInvoiceItems()
        {
            Console.WriteLine("\nOption 7 - All Invoices Items");
            InvoiceItemsRepository invoiceItemsRepository = new InvoiceItemsRepository();
            List<InvoiceItem> allOfTheInvoiceItems = invoiceItemsRepository.ReadGetAllRows();
            ProductRepository prodRepository = new ProductRepository();
            List<Product> allOfTheProducts = prodRepository.ReadGetAllRows();

            CultureInfo ci = new CultureInfo("en-za");
            allOfTheInvoiceItems.ForEach(b => Console.WriteLine($"ID: {b.InvoiceItemID}, Product Name: {allOfTheProducts.FirstOrDefault(z => z.ProductID == b.ProductID).ProductName}, Quantity: {b.Quantity}, Unit Price: {b.UnitPrice.ToString("C", ci)}, Total Price: {b.TotalPrice.ToString("C", ci)}"));

        }

        static void ShowAllPayments()
        {
            CultureInfo ci = new CultureInfo("en-za");
            PaymentRepository repository = new PaymentRepository();
            List<Payment> allOfThePayments = repository.ReadGetAllRows();
            Console.WriteLine("\n Option 8 - All Payments");
            allOfThePayments.ForEach(b => Console.WriteLine($"ID: {b.PaymentID}, Payment Date: {b.PaymentDate.ToString("dd MMMM yyyy HH:mm")}, Payment Method: {b.PaymentMethod}, Amount: {b.Amount.ToString("C", ci)}"));
        }

        static void ShowAllNotes()
        {
            Console.WriteLine("\nOption 9 - All Invoice Notes");
            NotesRepository notesRepository = new NotesRepository();
            List<Note> allOfTheNotes = notesRepository.ReadGetAllRows();

            CustomerRepository repository = new CustomerRepository();
            List<Customer> allOfTheCustomers = repository.ReadGetAllRows();

            InvoicesRepository invoiceRepository = new InvoicesRepository();
            List<Invoice> allOfTheInvoices = invoiceRepository.ReadGetAllRows();

            EmployeeRepository empRepository = new EmployeeRepository();
            List<Employee> allOfTheEmployees = empRepository.ReadGetAllRows();

            allOfTheNotes.ForEach(b => Console.WriteLine($"ID: {b.NotesID}, Assigned to: {allOfTheCustomers.FirstOrDefault(c => c.CustomerID == allOfTheInvoices.FirstOrDefault(i => i.InvoiceID == b.InvoiceID).CustomerID).FirstName + " "+ allOfTheCustomers.FirstOrDefault(c => c.CustomerID == allOfTheInvoices.FirstOrDefault(i => i.InvoiceID == b.InvoiceID).CustomerID).Surname}, Assignee: {allOfTheEmployees.FirstOrDefault(c => c.EmployeeID == b.EmployeeID).FirstName + " "+ allOfTheEmployees.FirstOrDefault(c => c.EmployeeID == b.EmployeeID).Surname},Date Issued: {b.CreatedDate.ToString("dd MMMM yyyy HH:mm")}"));
        }


    }
}
