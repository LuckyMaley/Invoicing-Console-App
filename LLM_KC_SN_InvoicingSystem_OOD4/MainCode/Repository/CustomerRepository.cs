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
    public partial class CustomerRepository: RepositoryBase<Customer>, IRepository<Customer>
    {
        private static List<Customer> allCustomers;

        public CustomerRepository()
        {
            allCustomers = ReadGetAllRows();
        }

        public virtual partial List<Customer> ReadGetAllRows();

        public virtual Customer ReadRowByID(int id)
        {
            loggerMainCode.Info("Customer Repository: ReadRowByID method - passing in an id of the customer");
            Customer customer = allCustomers.FirstOrDefault(c => c.CustomerID == id);
            return customer;
        }

        public virtual bool CheckIfIdExists(int id)
        {
            loggerMainCode.Info("Customer Repository: ChecksIfIdExists method - passing in an id of the customer");
            var DScheck = allCustomers.FirstOrDefault(c => c.CustomerID == id);
            bool valid = false;
            if (DScheck != null)
            {
                valid = true;
            }
            return valid;
        }

        public virtual bool CheckIfEmailExists(string email)
        {
            loggerMainCode.Info("Customer Repository: ChecksIfEmailExists method - passing in an email of the customer");
            var DScheck = allCustomers.FirstOrDefault(c => c.Email == email);
            bool valid = false;
            if (DScheck != null)
            {
                valid = true;
            }
            return valid;
        }

        public override bool AddEntity(Customer entity)
        {
            bool returnVal = false;
            try
            {
                loggerMainCode.Info("Customer Repository: AddEntity method - adding a new customer object");
                Customer.CustomersDataSet.Add(entity);
                returnVal = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error, cannot add customer" + ex.ToString());
                loggerMainCode.Error("Error, cannot add customer" + ex.ToString());
            }
            return returnVal;

        }

        public override bool DeleteRow(int id)
        {
            bool returnVal = false;
            try
            {
                loggerMainCode.Info("Customer Repository: DeleteRow method - deleting a customer object");
                var ds = allCustomers.FirstOrDefault(c => c.CustomerID == id);
                if (ds != null)
                {
                    allCustomers.RemoveAll(c => c.CustomerID == id);
                    Customer.CustomersDataSet.RemoveAll(c => c.CustomerID == id);
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error, cannot delete customer" + ex.ToString());
                loggerMainCode.Error("Error, cannot delete customer" + ex.ToString());
            }

            return returnVal;
        }

    }
}
