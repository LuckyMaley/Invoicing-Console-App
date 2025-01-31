using MainCode;
using MainCode.Models;
using MainCode.Repository;
using MainCode.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCode.Repository.EmployeeOptions
{
    /// <summary>
    /// This EmployeeOptions class consists of methods called when a user clicks a menu option in the front-end.
    /// These methods interact with the Repository to extract or remove data from the Repository.
    /// </summary>
    /// <remarks>
    /// 
    /// public EmployeeOptions(EmployeeRepository _employeesRepository, RepositoryBase&lt;Employee&gt; _employeesRepositoryBase)
    /// A counstructor that initializes the EmployeeOptions Class.
    /// These parameters are used for injection into the class for mock testing.
    /// <param name="_employeesRepository">The employees repository.</param>
    /// <param name="_employeesRepositoryBase">The employees IRepository.</param>
    /// 
    /// public string FindEmployeeByID(int employeeID)
    /// Finds an employee by ID and returns their details as a string.
    /// <param name="employeeID">The ID of the employee to find.</param>
    /// <returns>A string containing the employee details if found, or a message indicating that the employee does not exist.</returns>
    /// 
    /// public string FindEmployeeByFirstName(string empName)
    /// Finds employees by their First Name and returns their details as a string.
    /// <param name="empName">The Name of the employee or employees to find.</param>
    /// <returns>A string containing the employee details if found, or a message indicating that the employee does not exist.</returns>
    /// 
    /// public string FindEmployeeByFullName(string empName, string lName)
    /// Finds employees by their FullName and returns their details as a string.
    /// <param name="empName">The Name of the employee or employees to find.</param>
    /// <param name="lName">The Surname of the employee or employees to find.</param>
    /// <returns>A string containing the employee details if found, or a message indicating that the employee does not exist.</returns>
    /// 
    /// public string AddNewEmployee(Employee employee)
    /// Adds a new employee to the repository and returns a string that shows whether it was successful or not.
    /// <param name="employee">The employee object of the employee to add.</param>
    /// <returns>A string containing a message indicating that the employee has been added or not.</returns>
    /// 
    /// public string UpdateEmployee(Employee employee)
    /// Updates employee to the repository and returns a string that shows whether it was successful or not.
    /// <param name="employee">The employee object of the employee to update.</param>
    /// <returns>A string containing a message indicating that the employee has been updated or not.</returns>
    /// 
    /// public string RemoveEmployee(int employeeId)
    /// Removes employee from the repository and returns a string that shows whether it was successful or not.
    /// <param name="employeeId">The employee Id of the employee to remove as an integer type.</param>
    /// <returns>A string containing a message indicating that the employee has been removed or not.</returns>
    /// 
    /// </remarks>
    ///
    public class EmployeeOptions
    {
        private EmployeeRepository employeesRepository;
        private RepositoryBase<Employee> employeesRepositoryBase;
        public EmployeeOptions(EmployeeRepository _employeesRepository, RepositoryBase<Employee> _employeesRepositoryBase)
        {
            employeesRepository = _employeesRepository;
            employeesRepositoryBase = _employeesRepositoryBase;
        }

        public string FindEmployeeByID(int employeeID)
        {
            MainCodeStaticObjects.loggerMainCode.Info("EmployOptions: FindEmployeeByID - passing in employeeID");
            StringBuilder stringBuilder = new StringBuilder();
            bool valid = employeesRepository.CheckIfIdExists(employeeID);
            if (valid)
            {
                Employee employee = employeesRepository.ReadRowByID(employeeID);
                stringBuilder.AppendLine($"ID: {employee.EmployeeID}, First Name: {employee.FirstName}, Surname: {employee.Surname}, Email: {employee.Email}, Username: {employee.Username}, Address: {employee.Address}, Phone Number: {employee.PhoneNumber}");
            }
            else
            {
                MainCodeStaticObjects.loggerMainCode.Info("Employee does not exist, Please try again");
                stringBuilder.AppendLine("Employee does not exist, Please try again");
            }

            return stringBuilder.ToString();
        }

        public string FindEmployeeByFirstName(string empName)
        {

            MainCodeStaticObjects.loggerMainCode.Info("EmployOptions: FindEmployeeByFirstName - passing empName");
            StringBuilder stringBuilder = new StringBuilder();
            Stack<Employee> employees = employeesRepository.GetEmployeeByName(empName);
            if (employees.Count > 0)
            {
                while (employees.Count != 0)
                {
                    var employee = employees.Pop();
                    stringBuilder.AppendLine($"ID: {employee.EmployeeID}, First Name: {employee.FirstName}, Surname: {employee.Surname}, Email: {employee.Email}, Username: {employee.Username}, Address: {employee.Address}, Phone Number: {employee.PhoneNumber}");
                }
            }
            else
            {
                MainCodeStaticObjects.loggerMainCode.Info("No employee with that first name exists");
                stringBuilder.AppendLine("No employee with that first name exists");
            }
            return stringBuilder.ToString();

        }

        public string FindEmployeeByFullName(string empName, string lName)
        {
            MainCodeStaticObjects.loggerMainCode.Info("EmployOptions: FindEmployeeByFullName - passing in empNamme and lastname");
            StringBuilder stringBuilder = new StringBuilder();
            Stack<Employee> employees = employeesRepository.GetEmployeeByName(empName, lName);
            if (employees.Count > 0)
            {
                while (employees.Count != 0)
                {
                    var employee = employees.Pop();
                    stringBuilder.AppendLine($"ID: {employee.EmployeeID}, First Name: {employee.FirstName}, Surname: {employee.Surname}, Email: {employee.Email}, Username: {employee.Username}, Address: {employee.Address}, Phone Number: {employee.PhoneNumber}");
                }

            }
            else
            {
                MainCodeStaticObjects.loggerMainCode.Info("No employee with that fullname exists");
                stringBuilder.AppendLine("No employee with that fullname exists");
            }
            return stringBuilder.ToString();
        }

        public string AddNewEmployee(Employee employee)
        {
            MainCodeStaticObjects.loggerMainCode.Info("EmployOptions: AddNewEmployee - passing in employee oobject");
            StringBuilder stringBuilder = new StringBuilder();
            if (!employeesRepository.CheckIfEmailExists(employee.Email))
            {
                bool result = employeesRepository.AddEntity(employee);
                if (result)
                {
                    MainCodeStaticObjects.loggerMainCode.Info("Employee has been added");
                    stringBuilder.AppendLine("Employee has been added");
                    employeesRepository.ReadGetAllRows();
                }
                else
                {
                    MainCodeStaticObjects.loggerMainCode.Info("An error occured, employee was not added");
                    stringBuilder.AppendLine("An error occured, employee was not added");
                }
            }
            else
            {
                MainCodeStaticObjects.loggerMainCode.Info("Employee with that email already exists");
                stringBuilder.AppendLine("Employee with that email already exists");
            }

            return stringBuilder.ToString();
        }

        public string UpdateEmployee(Employee employee)
        {
            MainCodeStaticObjects.loggerMainCode.Info("EmployOptions: UpdateEmployee - passing in an employee object");
            StringBuilder stringBuilder = new StringBuilder();
            bool check = employeesRepository.CheckIfIdExists(employee.EmployeeID);
            if (check)
            {
                bool result = employeesRepository.UpdateEntity(employee);
                if (result)
                {
                    employeesRepository.ReadGetAllRows();
                    stringBuilder.AppendLine("Employee has been updated");
                    MainCodeStaticObjects.loggerMainCode.Info("Employee has been updated");
                }
                else
                {
                    stringBuilder.AppendLine("Error Occured, Employee was not updated");
                    MainCodeStaticObjects.loggerMainCode.Info("Error Occured, Employee was not updated");
                }
            }
            else
            {
                stringBuilder.AppendLine("Employee does not exist");
                MainCodeStaticObjects.loggerMainCode.Info("Employee does not exist");
            }

            return stringBuilder.ToString();
        }

        public string RemoveEmployee(int employeeId)
        {
            MainCodeStaticObjects.loggerMainCode.Info("EmployOptions: RemoveEmployee - passing in an employee ID");
            StringBuilder stringBuilder = new StringBuilder();
            bool exists = employeesRepository.CheckIfIdExists(employeeId);
            if (exists)
            {

                bool result = employeesRepository.DeleteRow(employeeId);
                if (result)
                {
                    MainCodeStaticObjects.loggerMainCode.Info("Employee has been deleted");
                    stringBuilder.AppendLine("Employee has been deleted");
                    employeesRepository.ReadGetAllRows();
                }
                else
                {
                    stringBuilder.AppendLine("Error Occured, Employee not removed");
                    MainCodeStaticObjects.loggerMainCode.Info("Error Occured, Employee not removed");
                }

            }
            else
            {
                stringBuilder.AppendLine("Employee ID does not exist");
                MainCodeStaticObjects.loggerMainCode.Info("Employee ID does not exist");
            }
            return stringBuilder.ToString();
        }
    }
}
