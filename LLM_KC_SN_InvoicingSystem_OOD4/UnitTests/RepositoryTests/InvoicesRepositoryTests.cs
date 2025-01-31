using Castle.Core.Resource;
using MainCode.Models;
using MainCode.Repository;
using Microsoft.VisualBasic;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.RepositoryTests
{
    public class InvoicesRepositoryTests
    {
        InvoicesRepository repository;
        List<Invoice> invoicesList;
        List<Invoice> invDS;

        [SetUp]
        public void init()
        {
            repository = new InvoicesRepository();
            invoicesList = new List<Invoice>();

            invDS = new List<Invoice>()
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

        [TearDown]
        public void teardown()
        {
            invoicesList = null;
            repository = null;
            invDS = null;

            
        }


        [Test]
        public void _01Test_ReadGetAllRows_ExpectedReturnAllInvoices10_WhenReadGetAllRowsCalled()
        {
            //arrange 
            int noOfInvExpected = 10;
            repository.SetDS(invDS);

            //Act 
            invoicesList = repository.ReadGetAllRows();


            //Assert 
            Assert.AreEqual(noOfInvExpected, invoicesList.Count);
        }

        [Test]
        public void _02Test_ReadGetAllRows_ExpectedAreNotEqual_WhenReadGetAllRowsCalled()
        {
            //arrange 
            int noOfInvExpected = 15;
            repository.SetDS(invDS);

            //Act 
            invoicesList = repository.ReadGetAllRows();


            //Assert 
            Assert.AreNotEqual(noOfInvExpected, invoicesList.Count);
        }


        [Test]
        public void _03Test_ReadGetAllRows_ExpectedReturnAllInvoiceTrue_WhenAdded1moreInvoice()
        {

            //arrange 
            Invoice invoice = new Invoice {InvoiceID = 11,  CustomerID = 11,InvoiceDate = new DateTime(2024, 4, 4, 09, 34, 00) ,DueDate = new DateTime(2024, 4, 29, 09, 34, 00), Subtotal = 874.34,Tax = 15,DiscountID = 11,TotalAmount = 432.96, Status = "Paid"};
            bool expected = true;
            repository.SetDS(invDS);

            //act
            bool actual = repository.AddEntity(invoice);



            //Assert 
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _04Test_DeleteRow_ExpectedToReturnTrue_WhenDelete1Invoice()
        {

            //arrange 
            int invoiceID = 10;
            bool expected = true;
            repository.SetDS(invDS);

            //act
            bool actual = repository.DeleteRow(invoiceID);


            //Assert 
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void _05Test_ReadGetAllRows_ExpectedReadgetallrowsisEqualtoInvoiceDataSet_WhenReadGetAllRowsCalled()
        {
            //arrange 

            List<Invoice> invoiceDSList = new List<Invoice>();
            repository.SetDS(invDS);

            //Act 
            invoicesList = repository.ReadGetAllRows();
            invoiceDSList = Invoice.InvoicesDataSet.ToList();
            int noOfInvExpected = invoiceDSList.Count;

            //Assert 
            Assert.AreEqual(noOfInvExpected, Invoice.InvoicesDataSet.Count);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void _06Test_ReadRowByID_Expected1RowEachTestCase_WhenExistingInvIDIsPassedIn(int id)
        {
            //Arrange
            Invoice invoices = new Invoice();
            repository.SetDS(invDS);

            //Act
            invoices = repository.ReadRowByID(id);

            //Assert
            Assert.IsNotNull(invoices);

        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void _07Test_ReadRowByID_ExpectedAreTheSameEachTestCase_WhenExistingInvIDIsPassedIn(int id)
        {
            //Arrange
            Invoice invoiceOne = new Invoice();
            Invoice theSameInvoice = new Invoice();
            repository.SetDS(invDS);

            //Act
            invoiceOne = repository.ReadRowByID(id);
            theSameInvoice = Invoice.InvoicesDataSet.FirstOrDefault(c => c.InvoiceID == id);

            //Assert
            Assert.AreEqual(invoiceOne.InvoiceID, theSameInvoice.InvoiceID);

        }

        [Test]
        public void _08Test_ReadGetAllRows_ThrowsException_WhenReadGetAllRowsCalledWithNullRepository()
        {
            // Arrange
            repository.SetDS(invDS);


            //Act
            repository = null;

            //Assert 
            Assert.Throws<NullReferenceException>(() => repository.ReadGetAllRows());
        }
    }
}
