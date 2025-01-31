using log4net.Repository.Hierarchy;
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
    ///  A summary about CustomerRepository Class
    ///  </summary>
    /// <remarks>
    ///  These remarks explain more about the CustomerRepository class and methods
    ///  
    ///  public virtual List&lt;Customer&gt; ReadGetAllRows()
    ///  This method clones the customers from the predefines list customers to allcustomers
    ///  <returns>
    ///  this method would return the list containing all customers  with variable name customers
    ///  </returns>
    ///  </remarks>
    public partial class CustomerRepository
    {

        public virtual partial List<Customer> ReadGetAllRows()
        {
            

            
            loggerMainCode.Info("Customer Read Get All method - reads all rows in the customer dataset");
            allCustomers = new List<Customer>();
            try
            {
                foreach (var cust in Customer.CustomersDataSet)
                {
                    allCustomers.Add(new Customer()
                    {
                        CustomerID = cust.CustomerID,
                        FirstName = cust.FirstName,
                        Surname = cust.Surname,
                        Email = cust.Email,
                        Username = cust.Username,
                        PasswordHash = cust.PasswordHash,
                        Salt = cust.Salt,
                        EncrytionType = cust.EncrytionType,
                        Address = cust.Address,
                        PhoneNumber = cust.PhoneNumber,

                    });
                }
            }
            catch (Exception ex)
            {
                loggerMainCode.Error(ex.Message);
                Console.WriteLine(ex.ToString());
            }
            return allCustomers;
        }

        public void SetDS(List<Customer> customers)
        {
            allCustomers = customers;
            Customer.CustomersDataSet = allCustomers;
        }

        

        public override bool UpdateEntity(Customer entity)
        {
            bool returnVal = false;
            try
            {
                loggerMainCode.Info("Customer Update Method - Updating customer details");
                var customer = Customer.CustomersDataSet.FirstOrDefault(c => c.CustomerID == entity.CustomerID);
                customer.CustomerID = entity.CustomerID;
                customer.FirstName = entity.FirstName;
                customer.Surname = entity.Surname;
                customer.Email = entity.Email;
                customer.Username = entity.Username;
                customer.Address = entity.Address;
                customer.PhoneNumber = entity.PhoneNumber;
                returnVal = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error, cannot update customer" + ex.ToString());
                loggerMainCode.Error("Error, cannot update customer" + ex.ToString());
            }

            return returnVal;
        }

        public virtual Queue<Customer> GetCustomerByName(string name)
        {
            loggerMainCode.Info("Customer Repository: GetCustomerByName method - passing in customer name");
            CustomerRepository customersRepository = new CustomerRepository();
            var customerlist = customersRepository.ReadGetAllRows();
            var customers = new Queue<Customer>();
            try
            {

                foreach (var customer in customerlist.Where(c => c.FirstName == name))
                {
                    customers.Enqueue(customer);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                loggerMainCode.Error(ex.Message.ToString());
            }
            return customers;
        }

        public virtual Queue<Customer> GetCustomerByName(string name, string surName)
        {
            loggerMainCode.Info("Customer Repository: GetCustomerByName method - passing in customer name and surname");
            CustomerRepository customersRepository = new CustomerRepository();
            var customerlist = customersRepository.ReadGetAllRows();
            var customers = new Queue<Customer>();
            try
            {
                foreach (var customer in customerlist.Where(c => c.FirstName == name && c.Surname == surName))
                {
                    customers.Enqueue(customer);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                loggerMainCode.Error(ex.Message.ToString());
            }
            return customers;
        }
    }
}
