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
    /// This InvoiceOptions class consists of methods called when a user clicks a menu option in the front-end.
    /// These methods interact with the Repository to extract or remove data from the Repository.
    /// </summary>
    /// <remarks>
    /// 
    /// public InvoiceOptions(InvoicesRepository _invoicesRepository)
    /// A counstructor that initializes the InvoiceOptions Class.
    /// These parameters are used for injection into the class for mock testing.
    /// <param name="_invoicesRepositoryBase">The invoices repository.</param>
    /// 
    /// public string FindInvoiceByID(int invoiceID)
    /// Finds an invoice by ID and returns the invoice details as a string.
    /// <param name="invoiceID">The ID of the invoice to find.</param>
    /// <returns>A string containing the invoice details if found, or a message indicating that the invoice does not exist.</returns>
    /// 
    /// public string FindInvoicesbyDate(string inputDate)
    /// Finds an invoice by date and returns the invoice details as a string.
    /// <param name="inputDate">The date of the invoice to find.</param>
    /// <returns>A string containing the invoice details if found, or a message indicating that the invoice does not exist.</returns>
    /// 
    /// public string FindInvoicesbyBetweenDates(string inputDate, string inputDateTwo)
    /// Finds an invoice by between dates and returns the invoice details as a string.
    /// <param name="inputDate">The beginning date of the invoice to find.</param>
    /// <param name="inputDateTwo">The end date of the invoice to find.</param>
    /// <returns>A string containing the invoice details if found, or a message indicating that the invoice does not exist.</returns>
    /// </remarks>
    public class InvoiceOptions
    {
        InvoicesRepository invoicesRepository;
        DiscountRepository discountsRepository;
        public InvoiceOptions(InvoicesRepository _invoicesRepository, DiscountRepository _discountRepository)
        {
            invoicesRepository = _invoicesRepository;
            discountsRepository = _discountRepository;
        }

        public string FindInvoiceByID(int invoiceID)
        {
            StringBuilder stringBuilder = new StringBuilder();
            CustomerRepository cusRepository = new CustomerRepository();
            List<Customer> allOfTheCustomers = cusRepository.ReadGetAllRows();
            List<Discount> allOfTheDiscounts = discountsRepository.ReadGetAllRows();
            CultureInfo ci = new CultureInfo("en-za");

            bool valid = invoicesRepository.CheckIfIdExists(invoiceID);
            if (valid)
            {
                var invoice = invoicesRepository.ReadRowByID(invoiceID);
                stringBuilder.AppendLine($"ID: {invoice.InvoiceID}, Customer Name: {allOfTheCustomers.FirstOrDefault(z => z.CustomerID == invoice.CustomerID).FirstName + " " + allOfTheCustomers.FirstOrDefault(z => z.CustomerID == invoice.CustomerID).Surname}, Invoice Date: {invoice.InvoiceDate.ToString("dd MMMM yyyy HH:mm")}, Payment Due Date: {invoice.DueDate.ToString("dd MMMM yyyy HH:mm")}, Subtotal: {invoice.Subtotal}, Tax: {invoice.Tax}, Discount: {allOfTheDiscounts.FirstOrDefault(c => c.DiscountID == invoice.DiscountID).DiscountName}, Totat Amount: {invoice.TotalAmount.ToString("C", ci)}, Status: {invoice.Status}");

            }
            else
            {
                stringBuilder.AppendLine("invoice does not exist, Please try again");
            }

            return stringBuilder.ToString();
        }

        public string FindInvoicesbyDate(string inputDate)
        {

            StringBuilder stringBuilder = new StringBuilder();
            if (inputDate != "")
            {
                CustomerRepository cusRepository = new CustomerRepository();
                List<Customer> allOfTheCustomers = cusRepository.ReadGetAllRows();
                List<Discount> allOfTheDiscounts = discountsRepository.ReadGetAllRows();
                CultureInfo ci = new CultureInfo("en-za");
                List<Invoice> invoices = invoicesRepository.ReadRowByDate(inputDate);
                if (invoices.Count > 0)
                {
                    invoices.ForEach(invoice => stringBuilder.AppendLine($"ID: {invoice.InvoiceID}, Customer Name: {allOfTheCustomers.FirstOrDefault(z => z.CustomerID == invoice.CustomerID).FirstName + " " + allOfTheCustomers.FirstOrDefault(z => z.CustomerID == invoice.CustomerID).Surname}, Invoice Date: {invoice.InvoiceDate.ToString("dd MMMM yyyy HH:mm")}, Payment Due Date: {invoice.DueDate.ToString("dd MMMM yyyy HH:mm")}, Subtotal: {invoice.Subtotal}, Tax: {invoice.Tax}, Discount: {allOfTheDiscounts.FirstOrDefault(c => c.DiscountID == invoice.DiscountID).DiscountName}, Totat Amount: {invoice.TotalAmount.ToString("C", ci)}, Status: {invoice.Status}"));
                }
                else
                {
                    stringBuilder.AppendLine("There is no invoice in that date");
                }
            }
            else
            {
                stringBuilder.AppendLine("No Date entered");
            }

            return stringBuilder.ToString();
        }

        public string FindInvoicesbyBetweenDates(string inputDate, string inputDateTwo)
        {
            StringBuilder sb = new StringBuilder();
            if (inputDate != "" && inputDateTwo != "")
            {
                CustomerRepository cusRepository = new CustomerRepository();
                List<Customer> allOfTheCustomers = cusRepository.ReadGetAllRows();
                List<Discount> allOfTheDiscounts = discountsRepository.ReadGetAllRows();
                CultureInfo ci = new CultureInfo("en-za");
                List<Invoice> invoices = invoicesRepository.ReadRowByDate(inputDate, inputDateTwo);
                if (invoices.Count > 0)
                {
                    invoices.ForEach(invoice => sb.AppendLine($"ID: {invoice.InvoiceID}, Customer Name: {allOfTheCustomers.FirstOrDefault(z => z.CustomerID == invoice.CustomerID).FirstName + " " + allOfTheCustomers.FirstOrDefault(z => z.CustomerID == invoice.CustomerID).Surname}, Invoice Date: {invoice.InvoiceDate.ToString("dd MMMM yyyy HH:mm")}, Payment Due Date: {invoice.DueDate.ToString("dd MMMM yyyy HH:mm")}, Subtotal: {invoice.Subtotal}, Tax: {invoice.Tax}, Discount: {allOfTheDiscounts.FirstOrDefault(c => c.DiscountID == invoice.DiscountID).DiscountName}, Totat Amount: {invoice.TotalAmount.ToString("C", ci)}, Status: {invoice.Status}"));
                }
                else
                {
                    sb.AppendLine("There is no invoice between those dates");
                }
            }
            else
            {
                sb.AppendLine("Please enter both beginning and end dates");
            }

            return sb.ToString();
        }

        public void GenerateInvoice(int customerId, int discountID, int employeeID, string note, List<int> productIds, List<int> quantities)
        {
            if (productIds.Count != quantities.Count)
            {
                Console.WriteLine("Number of product IDs does not match the number of quantities.");
                return;
            }

            Invoice invoice = new Invoice
            {
                InvoiceID = invoicesRepository.ReadGetAllRows().Max(c => c.InvoiceID) + 1,
                CustomerID = customerId,
                InvoiceDate = DateTime.Now,
                DiscountID = discountID,
                DueDate = DateTime.Now.AddDays(30),
                Status = "Pending"
            };

            invoicesRepository.AddEntity(invoice);

            double subtotal = 0;
            CultureInfo ci = new CultureInfo("en-za");
            InvoiceItemsRepository invoiceItemsRepository = new InvoiceItemsRepository();
            for (int i = 0; i < productIds.Count; i++)
            {
                int productId = productIds[i];
                int quantity = quantities[i];

                ProductRepository productRepository =  new ProductRepository();
                Product product = productRepository.ReadGetAllRows().FirstOrDefault(p => p.ProductID == productId);
                if (product == null)
                {
                    Console.WriteLine($"Product with ID {productId} not found. Skipping.");
                    continue;
                }

                decimal totalPrice = product.Price * quantity;
                
                InvoiceItem invoiceItem = new InvoiceItem
                {
                    InvoiceItemID = invoiceItemsRepository.ReadGetAllRows().Max(c=>c.InvoiceItemID) + 1,
                    InvoiceID = invoice.InvoiceID,
                    ProductID = productId,
                    Quantity = quantity,
                    UnitPrice = product.Price,
                    TotalPrice = totalPrice
                };

                invoiceItemsRepository.AddEntity(invoiceItem);

                subtotal += (double)totalPrice;
            }

            invoice.Tax = 10;

            double discount = CalculateDiscount(subtotal);

            double discountedSubtotal = subtotal - discount;

            invoice.Subtotal = discountedSubtotal;

            invoice.TotalAmount = discountedSubtotal + (discountedSubtotal * (invoice.Tax / 100));

            invoicesRepository.UpdateEntity(invoice);

            NotesRepository notesRepository = new NotesRepository();
            Note newNote = new Note
            {
                NotesID = notesRepository.ReadGetAllRows().Count + 1,
                InvoiceID = invoice.InvoiceID,
                EmployeeID = employeeID,
                InvoiceNotes = note,
                CreatedDate = DateTime.Now
            };

            notesRepository.AddEntity(newNote);

            Console.WriteLine("=== Invoice Details ===");
            Console.WriteLine($"Invoice ID: {invoice.InvoiceID}");
            Console.WriteLine($"Customer ID: {invoice.CustomerID}");
            Console.WriteLine($"Invoice Date: {invoice.InvoiceDate.ToString("dd MMMM yyyy HH:mm")}");
            Console.WriteLine($"Due Date: {invoice.DueDate.ToString("dd MMMM yyyy HH:mm")}");
            Console.WriteLine($"Subtotal: {invoice.Subtotal.ToString("C", ci)}");
            Console.WriteLine($"Tax: {invoice.Tax}%");
            Console.WriteLine($"Total Amount: {invoice.TotalAmount.ToString("C", ci)}");
            Console.WriteLine($"Status: {invoice.Status}");
            if (newNote.InvoiceNotes != "")
            {
                Console.WriteLine($"Note: {newNote.InvoiceNotes}");
            }
            

            Console.WriteLine("=== Invoice Items ===");
            foreach (var item in invoiceItemsRepository.ReadGetAllRows().Where(c => c.InvoiceID == invoice.InvoiceID))
            {
                Console.WriteLine($"Product ID: {item.ProductID}");
                Console.WriteLine($"Quantity: {item.Quantity}");
                Console.WriteLine($"Unit Price: {item.UnitPrice.ToString("C", ci)}");
                Console.WriteLine($"Total Price: {item.TotalPrice.ToString("C", ci)}");
            }
        }

        private double CalculateDiscount(double subtotal)
        {
            if (subtotal > 1000)
            {
                return subtotal * 0.10; 
            }
            else
            {
                return 0;
            }
        }
    }
}
