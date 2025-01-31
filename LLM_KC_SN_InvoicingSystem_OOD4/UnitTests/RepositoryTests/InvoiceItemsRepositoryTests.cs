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
    public  class InvoiceItemsRepositoryTests
    {
        InvoiceItemsRepository repository;
        List<InvoiceItem> invoiceItemsList;
        List<InvoiceItem> invDS;

        [SetUp]
        public void init()
        {
            repository = new InvoiceItemsRepository();
            invoiceItemsList = new List<InvoiceItem>();
            invDS = new List<InvoiceItem>() {
               new InvoiceItem{InvoiceItemID= 1 ,InvoiceID= 1,ProductID = 1, Quantity=1,UnitPrice=254.95m,TotalPrice= 528.84m},
               new InvoiceItem{InvoiceItemID= 2,InvoiceID= 2,ProductID = 2, Quantity= 2,UnitPrice=222.44m,TotalPrice= 927.46m},
               new InvoiceItem{InvoiceItemID= 3,InvoiceID= 3,ProductID = 3, Quantity= 3,UnitPrice=480.44m,TotalPrice= 249.1m},
               new InvoiceItem{InvoiceItemID= 4,InvoiceID= 4,ProductID = 4, Quantity=4,UnitPrice= 371.25m,TotalPrice= 844.68m},
               new InvoiceItem{InvoiceItemID= 5,InvoiceID= 5,ProductID = 5, Quantity= 5,UnitPrice=396.61m,TotalPrice= 297.2m},
               new InvoiceItem{InvoiceItemID= 6,InvoiceID= 6,ProductID = 6, Quantity= 6,UnitPrice=287.31m,TotalPrice = 188.45m},
               new InvoiceItem{InvoiceItemID= 7,InvoiceID= 7,ProductID = 7, Quantity= 7,UnitPrice=112.99m,TotalPrice= 592.94m},
               new InvoiceItem{InvoiceItemID= 8,InvoiceID= 8,ProductID = 8, Quantity=8,UnitPrice= 404.77m,TotalPrice= 77.69m},
               new InvoiceItem{InvoiceItemID= 9,InvoiceID= 9,ProductID = 9, Quantity= 9,UnitPrice=351.13m,TotalPrice= 601.55m},
               new InvoiceItem{InvoiceItemID= 10,InvoiceID=10,ProductID = 10, Quantity=10,UnitPrice=177.68m,TotalPrice=457.97m},
            };

        }

        [TearDown]
        public void teardown()
        {
            invoiceItemsList = null;
            repository = null;
            invDS = null;
            
        }

        [Test]
        public void _01Test_ReadGetAllRows_ExpectedReturnAllinvoiceItems10_WhenReadGetAllRowsCalled()
        {
            //arrange 
            int noOfInvExpected = 10;
            repository.SetDS(invDS);

            //Act 
            invoiceItemsList = repository.ReadGetAllRows();


            //Assert 
            Assert.AreEqual(noOfInvExpected, invoiceItemsList.Count);
        }

        [Test]
        public void _02Test_ReadGetAllRows_ExpectedAreNotEqual_WhenReadGetAllRowsCalled()
        {
            //arrange 
            int noOfCustExpected = 15;
            repository.SetDS(invDS);

            //Act 
            invoiceItemsList = repository.ReadGetAllRows();


            //Assert 
            Assert.AreNotEqual(noOfCustExpected, invoiceItemsList.Count);
        }

        
        [Test]
        public void _03Test_ReadGetAllRows_ExpectedReturnAllInvoiceItemTrue_WhenAdded1moreinvoiceItem()
        {

            //arrange 
            InvoiceItem invoiceItem = new InvoiceItem { InvoiceItemID=11,InvoiceID=11, ProductID =11, Quantity=25,  UnitPrice= 524.25M, TotalPrice= 6525.25M };
            bool expected = true;
            repository.SetDS(invDS);

            //act
            bool actual = repository.AddEntity(invoiceItem);


            //Assert 
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _04DeleteRow_ExpectedToReturnTrue_WhenDelete1invoiceItem()
        {

            //arrange 
            int customerID = 10;
            bool expected = true;
            repository.SetDS(invDS);

            //act
            bool actual = repository.DeleteRow(customerID);


            //Assert 
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void _05Test_ReadGetAllRows_ExpectedReadgetallrowsisEqualtoinvoiceItemDataSet_WhenReadGetAllRowsCalled()
        {
            //arrange 

            List<InvoiceItem> invoiceItemsDSList = new List<InvoiceItem>();
            repository.SetDS(invDS);

            //Act 
            invoiceItemsList = repository.ReadGetAllRows();
            invoiceItemsDSList = InvoiceItem.InvoiceItemsDataSet.ToList();
            int noOfInvExpected = invoiceItemsDSList.Count;

            //Assert 
            Assert.AreEqual(noOfInvExpected, invoiceItemsList.Count);
        }

        [Test]
        public void _06Test_ReadGetAllRows_ThrowsException_WhenReadGetAllRowsCalledWithNullRepository()
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
