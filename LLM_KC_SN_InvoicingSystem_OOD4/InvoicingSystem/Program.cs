using MainCode.Repository;
using MainCode.Utilities;
using log4net;
using log4net.Repository.Hierarchy;



[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]

namespace InvoicingSystem;

class Program
{
    private static readonly ILog logger = LogManager.GetLogger("Program.main method");
    static void Main(string[] args)
    {
        Console.Title = "OOD Project - The Bug Stoppers Invoicing System";
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.ForegroundColor = ConsoleColor.White;

        Console.Clear();
        try
        {
            logger.Info("Application is working: start");


            string exitMenu = "x";
            string menuOption = "";
            CustomerLoginHandller customerLoginHandller = new CustomerLoginHandller();
            EmployeeLoginHandler employeeLoginHandler = new EmployeeLoginHandler();
            customerLoginHandller.SetSuccessor(employeeLoginHandler);
            while (menuOption != exitMenu)
            {
                Console.WriteLine("\nThe Bug Stoppers Invoicing System Main Menu\n==================================================================");
                Console.WriteLine("1. Login");
                Console.WriteLine("x. Exit\nEnter your selected menu option: ");
                menuOption = Console.ReadLine();

                if (menuOption == "X")
                {
                    menuOption = menuOption.ToLower();
                }

                switch (menuOption)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("\nThe Bug Stoppers Invoicing System Main Menu\n==================================================================");
                        Console.WriteLine("Enter your username (b to go to Main Menu): ");
                        string userName = Console.ReadLine();
                        customerLoginHandller.Login(ref userName);
                        break;
                    case "x":
                        Console.WriteLine("Goodbye");
                        break;
                    default:
                        Console.WriteLine("Please review the menu and Enter your selected menu option");
                        break;
                }
                Console.WriteLine("\nPress any key to continue ...");
                Console.ReadKey();
            }

        }
        catch (Exception exception)
        {
           logger.Error(exception.Message);
        }


    }
}