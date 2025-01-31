using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCode.Models
{
    /// <summary>
    /// This is a Invoice model which contains the properties of the invoice and the invoice dataset.
    /// 
    /// The properties include InvoiceId, CustomerId, InvoiceDate, DueDate, Subtotal, Tax, DiscountId,TotalAmount,Status .
    /// The invoice dataset includes a list of 10 invoice records.
    /// </summary>
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public int CustomerID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public double Subtotal { get; set; }
        public int Tax { get; set; }
        public int DiscountID { get; set; }
        public double TotalAmount { get; set; }
        public string  Status { get; set; }

        public static List<Invoice> InvoicesDataSet = new List<Invoice>
        {
            new Invoice{ InvoiceID =1,  CustomerID = 1,InvoiceDate = new DateTime(2024,3,4,09,34,00) ,DueDate =  new DateTime(2024,3,29,09,34,00), Subtotal= 834.34,Tax= 12,DiscountID = 1,TotalAmount = 492.96, Status =  "Pending"},
            new Invoice{ InvoiceID=2, CustomerID = 2  ,InvoiceDate = new DateTime(2024,3,5,09,34,00) ,DueDate =  new DateTime(2024,3,25,09,34,00), Subtotal=   511.64,Tax=10,DiscountID = 2 ,TotalAmount = 635.8 , Status =  "Pending"},
            new Invoice{ InvoiceID=3,CustomerID =3 ,InvoiceDate = new DateTime(2024,3,3,09,34,00),DueDate = new DateTime(2024,3,5,2,09,34,00),Subtotal  =591.95,Tax=3,DiscountID = 3,TotalAmount = 728.52, Status =  "Pending"},
            new Invoice{ InvoiceID=4,CustomerID =  4,InvoiceDate = new DateTime(2024,3,3,03,34,00),DueDate = new DateTime(2024,3,25,09,34,00), Subtotal=424.03,Tax=4,DiscountID = 4,TotalAmount = 465.82 , Status = "Paid"},
            new Invoice{ InvoiceID=5,CustomerID =5,InvoiceDate = new DateTime(2024,3,3,06,34,00),DueDate = new DateTime(2024,3,5,09,34,00),   Subtotal =267.98,Tax=9,DiscountID = 5,TotalAmount = 850.92, Status =  "Paid"},
            new Invoice{ InvoiceID=6,CustomerID =6,InvoiceDate =  new DateTime(2024,3,3,07,34,00),DueDate =  new DateTime(2024,3,25,09,34,00),  Subtotal =997.89,Tax=8,DiscountID = 6,TotalAmount = 247.52  , Status = "Paid"},
            new Invoice{ InvoiceID=7,CustomerID =7 ,InvoiceDate = new DateTime(2024,3,3,08,34,00),DueDate = new DateTime(2024,3,25,09,34,00),   Subtotal =543.86,Tax=8,DiscountID = 7   ,TotalAmount = 555.31  , Status = "Paid"},
            new Invoice{ InvoiceID=8,CustomerID =8 ,InvoiceDate = new DateTime(2024,3,3,01,34,00),DueDate = new DateTime(2024,3,25,09,34,00),  Subtotal =449.51,Tax=12,DiscountID = 8  ,TotalAmount = 163.18  , Status = "Overdue"},
            new Invoice{ InvoiceID=9,CustomerID =9 ,InvoiceDate = new DateTime(2024,3,3,02,34,00),DueDate = new DateTime(2024,3,25,09,34,00), Subtotal =472.01,Tax=9,DiscountID = 9,TotalAmount = 107.9 , Status = "Overdue"},            
            new Invoice{ InvoiceID=10, CustomerID =10,InvoiceDate =  new DateTime(2024,3,5,09,34,00),DueDate = new DateTime(2024,3,25,09,34,00),   Subtotal =410.66,Tax= 14,DiscountID = 10,TotalAmount = 322.18   , Status = "Overdue"},

        };
    }
}











