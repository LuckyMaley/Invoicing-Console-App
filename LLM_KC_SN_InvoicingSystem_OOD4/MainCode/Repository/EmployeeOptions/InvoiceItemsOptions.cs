using MainCode.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCode.Repository.EmployeeOptions
{
    /// <summary>
    /// This InvoiceItemsOptions class consists of methods called when a user clicks a menu option in the front-end.
    /// These methods interact with the Repository to extract or remove data from the Repository.
    /// </summary>
    /// <remarks>
    /// 
    /// public InvoiceItemsOptions(InvoiceItemsRepository _invoiceItemsRepository, InvoicesRepository _invoicesRepository)
    /// A counstructor that initializes the InvoiceItemsOptions Class.
    /// These parameters are used for injection into the class for mock testing.
    /// <param name="_invoiceItemsRepository">The invoiceItemss repository.</param>
    /// <param name="_invoicesRepository">The invoices repository.</param>
    /// 
    /// public string FindInvoiceItemsByInvoiceID(int invoiceID)
    /// Finds an invoice by ID and returns the invoice items as a string.
    /// <param name="invoiceID">The ID of the invoice to find.</param>
    /// <returns>A string containing the invoice items if found, or a message indicating that the invoice does not exist.</returns>
    ///</remarks>
    public class InvoiceItemsOptions
    {
        InvoiceItemsRepository invoiceItemsRepository;
        InvoicesRepository invoicesRepository;

        public InvoiceItemsOptions(InvoiceItemsRepository _invoiceItemsRepository, InvoicesRepository _invoicesRepository)
        {
            invoiceItemsRepository = _invoiceItemsRepository;
            invoicesRepository = _invoicesRepository;
        }

        public string FindInvoiceItemByInvoiceID(int invoiceID)
        {
            List<InvoiceItem> invoiceItems = invoiceItemsRepository.ReadGetAllRows();
            ProductRepository prodRepository = new ProductRepository();
            List<Product> allOfTheProducts = prodRepository.ReadGetAllRows();
            StringBuilder stringBuilder = new StringBuilder();
            CultureInfo ci = new CultureInfo("en-za");

            bool valid = invoicesRepository.CheckIfIdExists(invoiceID);
            if (valid)
            {
                var invoiceItemsList = invoiceItemsRepository.ReadByInvoiceID(invoiceID);
                invoiceItemsList.ForEach(b => stringBuilder.AppendLine($"ID: {b.InvoiceItemID}, Product Name: {allOfTheProducts.FirstOrDefault(z => z.ProductID == b.ProductID).ProductName}, Quantity: {b.Quantity}, Unit Price: {b.UnitPrice.ToString("C", ci)}, Total Price: {b.TotalPrice.ToString("C", ci)}"));

            }
            else
            {
                stringBuilder.AppendLine("invoice does not exist, Please try again");
            }


            return stringBuilder.ToString();
        }
    }
}
