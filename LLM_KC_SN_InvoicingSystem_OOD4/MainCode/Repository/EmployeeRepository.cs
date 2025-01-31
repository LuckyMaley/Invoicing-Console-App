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
    /// <summary>
    ///  A summary about EmployeeRepository Class
    ///  </summary>
    /// <remarks>
    ///  These remarks explain more about the EmployeeRepository class and methods 
    ///  public virtual List&lt;Employee&gt; ReadGetAllRows()
    ///  This method clones the employees from the predefines list employees to allemployees
    ///  <returns>
    ///  this method returns the list containing all employees with variable name employees
    ///  </returns> 
    ///  </remarks>
    public class EmployeeRepository : RepositoryBase<Employee>, IRepository<Employee>
    {
        private static List<Employee> allEmployees;

        public EmployeeRepository()
        {
            allEmployees = ReadGetAllRows();
        }

        public virtual List<Employee> ReadGetAllRows()
        {
            loggerMainCode.Info("Employee Repository: ReadGetAll method - gets all employees");
            allEmployees = new List<Employee>();
            foreach (var emp in Employee.EmployeesDataSet)
            {
                allEmployees.Add(new Employee()
                {
                    EmployeeID = emp.EmployeeID,
                    FirstName = emp.FirstName,
                    Surname = emp.Surname,
                    Email = emp.Email,
                    Username = emp.Username,
                    PasswordHash = emp.PasswordHash,
                    Salt = emp.Salt,
                    EncrytionType = emp.EncrytionType,
                    Address = emp.Address,
                    PhoneNumber = emp.PhoneNumber,
                    Role = emp.Role

                });
            }

            return allEmployees;
        }

        public void SetDS(List<Employee> employees)
        {
            allEmployees = employees;
            Employee.EmployeesDataSet = allEmployees;
        }

        

        public virtual Employee ReadRowByID(int id)
        {
            loggerMainCode.Info("Employee Repository: ReadRowByID method - gets all employees");
            Employee emp = new Employee();
            try
            {
                emp = allEmployees.FirstOrDefault(c => c.EmployeeID == id);
            }
            catch (Exception ex)
            {
                loggerMainCode.Error(ex.Message);
                Console.WriteLine(ex.Message.ToString());
            }
             
            return emp;
        }

        public virtual bool CheckIfIdExists(int id)
        {
            loggerMainCode.Info("Employee Repository: CheckIfIdExists method - checks if employee email exists");
            var DScheck = allEmployees.FirstOrDefault(c => c.EmployeeID == id);
            bool valid = false;
            if (DScheck != null)
            {
                valid = true;
            }
            return valid;
        }

        public virtual bool CheckIfEmailExists(string email)
        {
            loggerMainCode.Info("Employee Repository: CheckIfEmailExists method - checks if employee email exists");
            var DScheck = allEmployees.FirstOrDefault(c => c.Email == email);
            bool valid = false;
            if (DScheck != null)
            {
                valid = true;
            }
            return valid;
        }

        public override bool AddEntity(Employee entity)
        {
            bool returnVal = false;
            try
            {
                loggerMainCode.Info("Employee Repository: AddEntity method - adds new employee");
                Employee.EmployeesDataSet.Add(entity);
                returnVal = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error, cannot add employee" + ex.ToString());
                loggerMainCode.Error("Error, cannot add employee" + ex.ToString());
            }
            return returnVal;

        }

        public override bool DeleteRow(int id)
        {
            bool returnVal = false;
            try
            {
                loggerMainCode.Info("Employee Repository: DeleteRow method - deletes an employee");
                var ds = allEmployees.FirstOrDefault(c => c.EmployeeID == id);
                if (ds != null)
                {
                    allEmployees.RemoveAll(c => c.EmployeeID == id);
                    Employee.EmployeesDataSet.RemoveAll(c => c.EmployeeID == id);
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error, cannot delete employee" + ex.ToString());
                loggerMainCode.Error("Error, cannot delete employee" + ex.ToString());
            }

            return returnVal;
        }


        public override bool UpdateEntity(Employee entity)
        {
            bool returnVal = false;
            try
            {
                loggerMainCode.Info("Employee Repository: UpdateEntity method - updates an employee");
                var employee = Employee.EmployeesDataSet.FirstOrDefault(c => c.EmployeeID == entity.EmployeeID);
                employee.EmployeeID = entity.EmployeeID;
                employee.FirstName = entity.FirstName;
                employee.Surname = entity.Surname;
                employee.Email = entity.Email;
                employee.Username = entity.Username;
                employee.Address = entity.Address;
                employee.PhoneNumber = entity.PhoneNumber;
                employee.Role = entity.Role;
                returnVal = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error, cannot update employee" + ex.ToString());
                loggerMainCode.Error("Error, cannot update employee" + ex.ToString());
            }

            return returnVal;
        }

        public virtual Stack<Employee> GetEmployeeByName(string name)
        {
            loggerMainCode.Info("Employee Repository: GetEmployeeByName method - gets an employee by name");
            EmployeeRepository employeesRepository = new EmployeeRepository();
            var employeelist = employeesRepository.ReadGetAllRows();
            var employees = new Stack<Employee>();
            try
            {
                var employeeslistDesc = employeelist.Where(c => c.FirstName == name).OrderByDescending(c => c.EmployeeID);
                foreach (var emp in employeeslistDesc)
                {
                    employees.Push(emp);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                loggerMainCode.Error(ex.Message);
            }
            return employees;
        }

        public virtual Stack<Employee> GetEmployeeByName(string name, string surName)
        {
            loggerMainCode.Info("Employee Repository: GetEmployeeByName method - gets an employee by name and surname");
            EmployeeRepository employeesRepository = new EmployeeRepository();
            var employeelist = employeesRepository.ReadGetAllRows();
            var employees = new Stack<Employee>();
            try
            {
                foreach (var employee in employeelist.Where(c => c.FirstName == name && c.Surname == surName).OrderByDescending(c => c.EmployeeID))
                {
                    employees.Push(employee);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                loggerMainCode.Error(ex.Message);
            }
            return employees;
        }
    }
}
