using MainCode.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MainCode.Utilities.MainCodeStaticObjects;

namespace MainCode.Repository
{
    /// <summary>
    ///  A summary about InvoiceRepository Class
    ///  </summary>
    /// <remarks>
    ///  These remarks explain more about the InvoiceRepository class and methods 
    ///  public virtual List&lt;Invoice&gt; ReadGetAllRows()
    ///  This method clones the Invoice from the predefines list invoice to allinvoice
    ///  <returns>
    ///  this method returns the list containing all invoice with variable name invoice
    ///  </returns> 
    ///  </remarks>
    public class InvoicesRepository : RepositoryBase<Invoice>, IRepository<Invoice>
    {
        private List<Invoice> allInvoices;

        public InvoicesRepository()
        {
            allInvoices = ReadGetAllRows(); 
        }

      


        public virtual Invoice ReadRowByID(int id)
        {
            loggerMainCode.Info("Invoice Repository: ReadRowByID method - passing in an id of the Invoice");

            Invoice invoice = allInvoices.FirstOrDefault(c => c.InvoiceID == id);
            return invoice;
        }

        public virtual bool CheckIfIdExists(int id)
        {
            loggerMainCode.Info("Invoice Repository: ChecksIfIdExists method - passing in an id of the invoice");

            var InvCheck = allInvoices.FirstOrDefault(c => c.InvoiceID == id);
            bool valid = false;
            if (InvCheck != null)
            {
                valid = true;
            }
            return valid;
        }

        public override bool AddEntity(Invoice entity)
        {
            bool returnVal = false;
            try
            {
                loggerMainCode.Info("Invoices Repository: Add method - adds a Invoice");

                Invoice.InvoicesDataSet.Add(entity);
                returnVal = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error, cannot add invoice" + ex.ToString());
                loggerMainCode.Error("Error, cannot add invoice" + ex.ToString());
            }
            return returnVal;

        }

        public override bool DeleteRow(int id)
        {
            bool returnVal = false;
            try
            {
                loggerMainCode.Info("Invoices Repository: DeleteMethod method - adds a invoice");

                var ds = allInvoices.FirstOrDefault(c => c.InvoiceID == id);
                if (ds != null)
                {
                    allInvoices.RemoveAll(c => c.InvoiceID == id);
                    Invoice.InvoicesDataSet.RemoveAll(c => c.InvoiceID == id);
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error, cannot delete invoice" + ex.ToString());
                loggerMainCode.Error("Error, cannot delete invoice" + ex.ToString());
            }

            return returnVal;
        }

        public override bool UpdateEntity(Invoice entity)
        {
            bool returnVal = false;
            try
            {
                loggerMainCode.Info("Invoices Repository: UpdateMethod  - updates a invoice");
                var invoice = Invoice.InvoicesDataSet.FirstOrDefault(c => c.InvoiceID == entity.InvoiceID);

                invoice.InvoiceID = entity.InvoiceID;
                invoice.CustomerID = entity.CustomerID;
                invoice.InvoiceDate = entity.InvoiceDate;
                invoice.DueDate = entity.DueDate;
                invoice.Subtotal = entity.Subtotal;
                invoice.Tax = entity.Tax;
                invoice.DiscountID = entity.DiscountID;
                invoice.TotalAmount = entity.TotalAmount;
                invoice.Status = entity.Status;

                returnVal = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error, cannot update invoice" + ex.ToString());
                loggerMainCode.Error("Error, cannot update invoice" + ex.ToString());
            }

            return returnVal;
        }

        public virtual List<Invoice> ReadGetAllRows()
        {
            allInvoices = new List<Invoice>();
            foreach (var inv in Invoice.InvoicesDataSet)
            {
                loggerMainCode.Info("Invoices Repository: ReadGetAllRows method - reads rows");

                allInvoices.Add(new Invoice()
                {
                    InvoiceID= inv.InvoiceID,
                    CustomerID= inv.CustomerID,
                    InvoiceDate= inv.InvoiceDate,
                    DueDate= inv.DueDate,
                    Subtotal= inv.Subtotal,
                    Tax = inv.Tax,
                    DiscountID= inv.DiscountID,
                    TotalAmount= inv.TotalAmount,
                    Status= inv.Status,                   

                }
                );
            }
            return allInvoices;

        }

        public void SetDS(List<Invoice> invoices)
        {
            allInvoices = invoices;
            Invoice.InvoicesDataSet = allInvoices;
        }

        public virtual List<Invoice> ReadRowByDate(string date)
        {
            loggerMainCode.Info("Invoice Repository: ReadRowByDate method - passing in an date of the invoice");

            InvoicesRepository repository = new InvoicesRepository();
            List<Invoice> allOfTheInvoicess = repository.ReadGetAllRows();

            string defaultDateString = "10/08/2008";
            string format = "dd/MM/yyyy";
            CultureInfo ci = new CultureInfo("en-za");

            DateTime dateTime;
            if (!DateTime.TryParseExact(date, format, ci, System.Globalization.DateTimeStyles.None, out dateTime))
            {
                dateTime = DateTime.ParseExact(defaultDateString, format, ci);
            }
            IEnumerable<Invoice> invoice = allOfTheInvoicess.Where(c => c.InvoiceDate.Date == dateTime.Date);
            List<Invoice> invoices = new List<Invoice>();
            if (invoice != null)
            {
                invoices = invoice.ToList();
            }
            else
            {
                invoices = null;
            }
            return invoices;
        }

        public virtual List<Invoice> ReadRowByDate(string beginDate, string endDate)
        {
            loggerMainCode.Info("Invoice Repository: ReadRowByDate method - passing in dates of the invoice");

            InvoicesRepository repository = new InvoicesRepository();
            List<Invoice> allOfTheInvoicess = repository.ReadGetAllRows();

            string defaultDateString = "10/08/2008";
            string format = "dd/MM/yyyy";
            CultureInfo ci = new CultureInfo("en-za");

            DateTime beginDateTime;
            if (!DateTime.TryParseExact(beginDate, format, ci, System.Globalization.DateTimeStyles.None, out beginDateTime))
            {
                beginDateTime = DateTime.ParseExact(defaultDateString, format, ci);
            }

            DateTime endDateTime;
            if (!DateTime.TryParseExact(endDate, format, ci, System.Globalization.DateTimeStyles.None, out endDateTime))
            {
                endDateTime = DateTime.ParseExact(defaultDateString, format, ci);
            }
            IEnumerable<Invoice> invoice = allOfTheInvoicess.Where(c => c.InvoiceDate.Date >= beginDateTime.Date && c.InvoiceDate.Date <= endDateTime.Date);
            List<Invoice> invoices = new List<Invoice>();
            if (invoice != null)
            {
                invoices = invoice.ToList();
            }
            else
            {
                invoices = null;
            }
            return invoices;
        }
    }
}
