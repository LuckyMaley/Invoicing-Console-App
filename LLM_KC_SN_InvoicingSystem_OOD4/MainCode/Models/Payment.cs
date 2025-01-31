using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCode.Models
{
    /// <summary>
    /// This is a Payment model which containsthe properties of the payment and the disvount dataset.
    /// 
    /// The properties include  PaymentID,InvoiceID ,PaymentDate,PaymentMethod,Amount.
    /// The Payment  dataset includes a list of 10 payment dataset.
    /// </summary>
    public class Payment
    {
        public int PaymentID {  get; set; }
        public int InvoiceID {  get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod {  get; set; }
        public double Amount { get; set; }

        public static List<Payment> PaymentsDataset = new List<Payment>()
        {
            new Payment() {  PaymentID = 1, InvoiceID= 1,PaymentDate= new DateTime(2024,01,04,11,13,12), Amount= 6233.92,  PaymentMethod="PayPal"},
            new Payment() {  PaymentID = 2, InvoiceID= 2,PaymentDate= new DateTime(2024,01,5,12,14,15), Amount= 5678.71,  PaymentMethod="debit card"},
            new Payment() {  PaymentID = 3, InvoiceID= 3,PaymentDate= new DateTime(2024,05,24,10,15,12), Amount= 487.14,  PaymentMethod="PayPal"},
            new Payment() {  PaymentID = 4, InvoiceID= 4,PaymentDate= new DateTime(2024,07,14,09,13,52), Amount= 7333.71,  PaymentMethod="credit card"},
            new Payment() {  PaymentID = 5, InvoiceID= 5,PaymentDate= new DateTime(2024,11,12,10,25,45), Amount= 9807.81,  PaymentMethod="PayPal"},
            new Payment() {  PaymentID = 6, InvoiceID= 6,PaymentDate= new DateTime(2024,01,11,05,25,30), Amount= 8308.03,  PaymentMethod="debit card"},
            new Payment() {  PaymentID = 7, InvoiceID= 7,PaymentDate= new DateTime(2024,01,13,13,33,10), Amount= 7112.68,  PaymentMethod="credit card"},
            new Payment() {  PaymentID = 8, InvoiceID= 8,PaymentDate= new DateTime(2024,02,10,12,38,45), Amount= 7739.86,  PaymentMethod="PayPal"},
            new Payment() {  PaymentID = 9, InvoiceID= 9,PaymentDate= new DateTime(2024,04,05,10,40,46), Amount= 9815.18,  PaymentMethod="PayPal"},
            new Payment() {  PaymentID = 10, InvoiceID= 10,PaymentDate= new DateTime(2024,06,10,11,55,10), Amount= 5878.71,  PaymentMethod="credit card"}

        };

    }
}






