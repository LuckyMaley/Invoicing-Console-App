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
    public class EmployeeLoginHandler : LoginHandler
    {
        public bool LoginCheck(string username)
        {
            var employee = new Employee();
            bool valid = false;
            try
            {
                MainCodeStaticObjects.loggerMainCode.Info("EmployeeLoginHandler: LoginCheck method- passing in a username");
                EmployeeRepository employeesRepository = new EmployeeRepository();
                employee = employeesRepository.ReadGetAllRows().FirstOrDefault(c => c.Username == username);
                valid = employee != null ? true : false;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                loggerMainCode.Error(ex.Message);
            }
            return valid;
        }

        public override void Login(ref string userName)
        {
            char exitMenu = 'b';
            char menuOption = ' ';
            int count = 0;
            while (menuOption != exitMenu)
            {
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
                    menuOption = 'b';
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
                        menuOption = 'b';
                        userName = "";
                        break;
                }
            }
            if (count == 1)
            {
                try
                {
                    loggerMainCode.Info("Employee Login Handler - Employee is logging in");
                    EmployeeRepository employeesRepository = new EmployeeRepository();
                    string username = userName;
                    var employee = employeesRepository.ReadGetAllRows().FirstOrDefault(c => c.Username == username);
                    person = new Person(employee.EmployeeID, employee.FirstName, employee.Surname, employee.Username, employee.PasswordHash, employee.Salt, employee.EncrytionType);
                    MenuOptions.EmployeeMenu();
                    userName = "z";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    loggerMainCode.Info(ex.Message);
                }

            }
        }
    }
}
