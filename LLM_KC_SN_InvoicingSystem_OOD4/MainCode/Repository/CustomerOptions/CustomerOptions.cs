using MainCode.Models;
using MainCode.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCode.Repository.CustomerOptions
{
    public class CustomerOptions
    {
        public static void ViewMyInvoices(int customerId)
        {
            MainCodeStaticObjects.loggerMainCode.Info("Customer Options: ViewMyInvoices method- passing in a customer ID");
            CustomerRepository customerRepository = new CustomerRepository();
            List<Customer> customerList = customerRepository.ReadGetAllRows();
            Customer customer = customerList.FirstOrDefault(c => c.CustomerID == customerId);

            if (customer != null)
            {
                Console.WriteLine($"=== Invoices for {customer.FirstName} {customer.Surname} ===");
                InvoicesRepository invoicesRepository = new InvoicesRepository();
                IEnumerable<Invoice> invoices = invoicesRepository.ReadGetAllRows().Where(c => c.CustomerID == customerId);
                CultureInfo ci = new CultureInfo("en-za");
                if (invoices != null)
                {
                    foreach (Invoice invoice in invoices)
                    {
                        Console.WriteLine($"Invoice Number: {invoice.InvoiceID}");
                        Console.WriteLine($"Date: {invoice.InvoiceDate.ToString("dd MMMM yyyy HH:mm")}");
                        Console.WriteLine($"Total Amount: {invoice.TotalAmount.ToString("C", ci)}");
                        Console.WriteLine($"Status: {invoice.Status}");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("No Invoices available");
                    MainCodeStaticObjects.loggerMainCode.Info("No Invoices available");
                }
            }
            else
            {
                Console.WriteLine("Customer not found.");
                MainCodeStaticObjects.loggerMainCode.Info("Customer not found");
            }
        }

        public static void ViewInvoiceDetails(int customerId)
        {
            MainCodeStaticObjects.loggerMainCode.Info("Customer Options: ViewInvoiceDetails method- passing in a customer ID");
            Console.WriteLine("View Invoice Details");

            CustomerRepository customerRepository = new CustomerRepository();
            List<Customer> customerList = customerRepository.ReadGetAllRows();
            Customer customer = customerList.FirstOrDefault(c => c.CustomerID == customerId);

            if (customer != null)
            {
                Console.WriteLine($"=== Invoices for {customer.FirstName} {customer.Surname} ===");
                InvoicesRepository invoicesRepository = new InvoicesRepository();
                IEnumerable<Invoice> invoices = invoicesRepository.ReadGetAllRows().Where(c => c.CustomerID == customerId);
                CultureInfo ci = new CultureInfo("en-za");
                if (invoices != null)
                {
                    foreach (Invoice invoice in invoices)
                    {
                        Console.WriteLine($"Invoice Number: {invoice.InvoiceID}");
                        Console.WriteLine($"Date: {invoice.InvoiceDate.ToString("dd MMMM yyyy HH:mm")}");
                        Console.WriteLine($"Total Amount: {invoice.TotalAmount.ToString("C", ci)}");
                        Console.WriteLine($"Status: {invoice.Status}");
                        Console.WriteLine();
                    }

                    Console.Write("Enter the invoice ID to view details: ");
                    int invoiceNumber = 0;
                    bool valid = int.TryParse(Console.ReadLine(), out invoiceNumber);
                    if (valid)
                    {
                        var selectedInvoice = invoices.FirstOrDefault(c => c.CustomerID == customerId && c.InvoiceID == invoiceNumber);

                        if (selectedInvoice != null)
                        {
                            InvoiceItemsRepository invoiceItemsRepository = new InvoiceItemsRepository();
                            List<InvoiceItem> invoiceItemsList = invoiceItemsRepository.ReadGetAllRows().Where(c => c.InvoiceID == selectedInvoice.InvoiceID).ToList();
                            ProductRepository prodRepository = new ProductRepository();
                            List<Product> allOfTheProducts = prodRepository.ReadGetAllRows();
                            Console.WriteLine($"=== Invoice Details ===");
                            Console.WriteLine($"Invoice ID: {selectedInvoice.InvoiceID}");
                            Console.WriteLine($"Invoice Items: ");
                            invoiceItemsList.ForEach(b => Console.WriteLine($"ID: {b.InvoiceItemID}, Product Name: {allOfTheProducts.FirstOrDefault(z => z.ProductID == b.ProductID).ProductName}, Quantity: {b.Quantity}, Unit Price: {b.UnitPrice.ToString("C", ci)}, Total Price: {b.TotalPrice.ToString("C", ci)}"));

                            Console.WriteLine($"Date: {selectedInvoice.InvoiceDate.ToString("dd MMMM yyyy HH:mm")}");
                            Console.WriteLine($"Total Amount: {selectedInvoice.TotalAmount.ToString("C", ci)}");
                            Console.WriteLine($"Status: {selectedInvoice.Status}");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Invoice not found.");
                            MainCodeStaticObjects.loggerMainCode.Info("Invoice not found");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Invoices available");
                        MainCodeStaticObjects.loggerMainCode.Info("No Invoices available");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a number");
                    MainCodeStaticObjects.loggerMainCode.Info("Please enter a number");
                }
            }
            else
            {
                Console.WriteLine("Customer not found.");
                MainCodeStaticObjects.loggerMainCode.Info("Customer not found");
            }
        }

        public static void MakePayment(int customerId)
        {
            MainCodeStaticObjects.loggerMainCode.Info("Customer Options: MakePayment method- passing in a customer ID");
            Console.WriteLine("Make Payment");
            CultureInfo ci = new CultureInfo("en-za");
            CustomerRepository customerRepository = new CustomerRepository();
            List<Customer> customerList = customerRepository.ReadGetAllRows();
            Customer customer = customerList.FirstOrDefault(c => c.CustomerID == customerId);

            if (customer != null)
            {
                Console.WriteLine($"=== Unpaid Invoices for {customer.FirstName} {customer.Surname} ===");
                InvoicesRepository invoicesRepository = new InvoicesRepository();
                IEnumerable<Invoice> invoices = invoicesRepository.ReadGetAllRows().Where(c => c.CustomerID == customerId);
                if (invoices.Count() > 0)
                {

                    foreach (Invoice invoice in invoices)
                    {
                        if (invoice.Status != "Paid")
                        {
                            Console.WriteLine($"Invoice ID: {invoice.InvoiceID}");
                            Console.WriteLine($"Total Amount: {invoice.TotalAmount.ToString("C", ci)}");
                            Console.WriteLine();
                        }
                    }

                    Console.Write("Enter the invoice ID to make a payment: ");
                    string invoiceNumber = Console.ReadLine();
                    int invID = 0;
                    bool valid = int.TryParse(invoiceNumber, out invID);
                    if (valid)
                    {
                        Invoice selectedInvoice = invoices.FirstOrDefault(i => i.InvoiceID == invID);

                        if (selectedInvoice != null)
                        {
                            selectedInvoice.Status = "Paid";
                            invoicesRepository.UpdateEntity(selectedInvoice);
                            PaymentRepository paymentRepository = new PaymentRepository();
                            Payment payment = new Payment()
                            {
                                PaymentID = paymentRepository.ReadGetAllRows().Max(c => c.PaymentID) + 1,
                                InvoiceID = selectedInvoice.InvoiceID,
                                PaymentDate = DateTime.Now,
                                PaymentMethod = "debit card",
                                Amount = selectedInvoice.TotalAmount
                            };
                            paymentRepository.AddEntity(payment);  
                            Console.WriteLine("Payment successful.");
                            MainCodeStaticObjects.loggerMainCode.Info("Payment successful");
                        }
                        else
                        {
                            Console.WriteLine("Invoice not found.");
                            MainCodeStaticObjects.loggerMainCode.Info("Invoice not found");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a number for the ID");
                        MainCodeStaticObjects.loggerMainCode.Info("Please enter a number for the ID");
                    }
                }
                else
                {
                    Console.WriteLine("No unpaid invoices available");
                    MainCodeStaticObjects.loggerMainCode.Info("No unpaid invoices available");
                }
            }
            else
            {
                Console.WriteLine("Customer not found.");
                MainCodeStaticObjects.loggerMainCode.Info("Customer not found");
            }
        }

        public static void ViewPaymentHistory(int customerId)
        {
            MainCodeStaticObjects.loggerMainCode.Info("Customer Options: ViewPaymentHistory method- passing in a customer ID");
            Console.WriteLine("View Payment History");
            CultureInfo ci = new CultureInfo("en-za");
            CustomerRepository customerRepository = new CustomerRepository();
            List<Customer> customerList = customerRepository.ReadGetAllRows();
            Customer customer = customerList.FirstOrDefault(c => c.CustomerID == customerId);

            if (customer != null)
            {
                Console.WriteLine($"=== Payment History for {customer.FirstName} {customer.Surname} ===");
                InvoicesRepository invoicesRepository = new InvoicesRepository();
                IEnumerable<Invoice> invoices = invoicesRepository.ReadGetAllRows().Where(c => c.CustomerID == customerId && c.Status == "Paid");

                foreach (Invoice invoice in invoices)
                {
                    if (invoice.Status == "Paid")
                    {
                        Console.WriteLine($"Invoice Number: {invoice.InvoiceID}");
                        Console.WriteLine($"Date: {invoice.InvoiceDate.ToString("dd MMMM yyyy HH:mm")}");
                        Console.WriteLine($"Total Amount: {invoice.TotalAmount.ToString("C", ci)}");
                        Console.WriteLine("Payment Status: Paid");
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                MainCodeStaticObjects.loggerMainCode.Info("Customer not found");
                Console.WriteLine("Customer not found.");
            }
        }

        public static string UpdateContactInformation(Customer customer)
        {
            MainCodeStaticObjects.loggerMainCode.Info("Customer Options: UpdateCustomerInformation method- passing in an object of customer");
            CustomerRepository customersRepository = new CustomerRepository();
            List<Customer> customerList = customersRepository.ReadGetAllRows();
            StringBuilder stringBuilder = new StringBuilder();
            bool check = customersRepository.CheckIfIdExists(customer.CustomerID);
            if (check)
            {
                bool result = customersRepository.UpdateEntity(customer);
                if (result)
                {
                    customersRepository.ReadGetAllRows();
                    stringBuilder.AppendLine("Customer has been updated");
                    MainCodeStaticObjects.loggerMainCode.Info("Customer has been updated");
                }
                else
                {
                    MainCodeStaticObjects.loggerMainCode.Info("Error Occured, Customer was not updated");
                    stringBuilder.AppendLine("Error Occured, Customer was not updated");
                }
            }
            else
            {
                MainCodeStaticObjects.loggerMainCode.Info("Customer does not exist");
                stringBuilder.AppendLine("Customer does not exist");
            }

            return stringBuilder.ToString();
        }

        public static void ViewContactInformation(int customerId)
        {
            MainCodeStaticObjects.loggerMainCode.Info("Customer Options: ViewCustomerInformation method- passing in a customer ID");
            CustomerRepository repository = new CustomerRepository();
            Customer customer = repository.ReadGetAllRows().FirstOrDefault(c => c.CustomerID == customerId);
            Console.WriteLine($"Your Contact Information");
            Console.WriteLine($"ID: {customer.CustomerID}");
            Console.WriteLine($"First Name: {customer.FirstName}");
            Console.WriteLine($"Surname: {customer.Surname}");
            Console.WriteLine($"Email: {customer.Email}");
            Console.WriteLine($"Username: {customer.Username}");
            Console.WriteLine($"Address: {customer.Address}");
            Console.WriteLine($"Phone Number: {customer.PhoneNumber}");
        }
    }
}
