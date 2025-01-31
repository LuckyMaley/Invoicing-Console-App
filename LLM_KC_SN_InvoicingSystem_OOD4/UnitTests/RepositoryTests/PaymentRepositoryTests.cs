using MainCode.Models;
using MainCode.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.RepositoryTests
{
    [TestFixture]
    public class PaymentRepositoryTests
    {
        PaymentRepository repository;
        List<Payment> paymentList;
        List<Payment> payDS;

        [SetUp]
        public void init()
        {
            repository = new PaymentRepository();
            paymentList = new List<Payment>();
            payDS = new List<Payment>()

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

        [TearDown]
        public void teardown()
        {
            paymentList = null;
            repository = null;
            payDS = null;
            
        }


        [Test]
        public void _01Test_ReadGetAllRows_ExpectedReturnAllpayment10_WhenReadGetAllRowsCalled()
        {
            //arrange 
            int noOfPayExpected = 10;
            repository.SetDS(payDS);

            //Act 
            paymentList = repository.ReadGetAllRows();


            //Assert 
            Assert.AreEqual(noOfPayExpected, paymentList.Count);
        }

        [Test]
        public void _02Test_ReadGetAllRows_ExpectedAreNotEqual_WhenReadGetAllRowsCalled()
        {
            //arrange 
            int noOfPayExpected = 15;
            repository.SetDS(payDS);

            //Act 
            paymentList = repository.ReadGetAllRows();


            //Assert 
            Assert.AreNotEqual(noOfPayExpected, paymentList.Count);
        }


        [Test]
        public void _03Test_ReadGetAllRows_ExpectedReturnAllpaymentTrue_WhenAdded1morePayment()
        {

            //arrange 
            Payment payment = new Payment { PaymentID = 11, InvoiceID= 11, PaymentDate=(new DateTime(2024, 01, 04, 11, 13, 12)),PaymentMethod="PayPal",Amount=245.25};
            bool expected = true;
            repository.SetDS(payDS);

            //act
            bool actual = repository.AddEntity(payment);



            //Assert 
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _04DeleteRow_ExpectedToReturnTrue_WhenDelete1Payment()
        {

            //arrange 
            int paymentID = 2;
            bool expected = true;
            repository.SetDS(payDS);

            //act
            bool actual = repository.DeleteRow(paymentID);


            //Assert 
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void _05Test_ReadGetAllRows_ReadgetallrowsisEqualtoPaymentDataSet_WhenReadGetAllRowsCalled()
        {
            //arrange 

            List<Payment> PaymentDSList = new List<Payment>();
            repository.SetDS(payDS);

            //Act 
            paymentList = repository.ReadGetAllRows();
            PaymentDSList = Payment.PaymentsDataset.ToList();
            int noOfPayExpected = PaymentDSList.Count;

            //Assert 
            Assert.AreEqual(noOfPayExpected, paymentList.Count);
        }

        [Test]
        public void _06Test_ReadGetAllRows_ThrowsException_WhenReadGetAllRowsCalledWithNullRepository()
        {
            // Arrange
            repository.SetDS(payDS);


            //Act
            repository = null;

            //Assert 
            Assert.Throws<NullReferenceException>(() => repository.ReadGetAllRows());
        }
    }
}
