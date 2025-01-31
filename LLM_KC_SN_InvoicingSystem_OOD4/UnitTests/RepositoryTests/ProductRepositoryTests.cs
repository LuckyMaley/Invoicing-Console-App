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
    public class ProductRepositoryTests
    {
        ProductRepository repository;
        List<Product> productList;
        List<Product> prodDS;

        [SetUp]
        public void init()
        {
            prodDS = new List<Product>()
            {
               new Product() { ProductID = 1,ProductName="Laptop", StockQuantity=50,Price=899.99M,Description="Full HD, Intel Core i5, 8GB RAM, 512GB SSD" },
               new Product() { ProductID = 2,ProductName="Smartphone", StockQuantity=100,Price=899.99M,Description="6.5 AMOLED Display, Snapdragon 888, 128GB, 5G" },
               new Product() { ProductID = 3,ProductName="Smartwatch", StockQuantity=80,Price=899.99M,Description="Waterproof Fitness Tracker, Heart Rate Monitor" },
               new Product() { ProductID = 4,ProductName="Headphones", StockQuantity=150,Price=899.99M,Description="Wireless Over-Ear Headphones, Active Noise Cancellation" },
               new Product() { ProductID = 5,ProductName="Tablet", StockQuantity=70,Price=899.99M,Description="Retina Display, A13 Bionic Chip, 256GB" },
               new Product() { ProductID = 6,ProductName="Computer", StockQuantity=150,Price=1099.99M,Description="QHD Monitor, Intel Core i7, 16GB RAM, 1TB SSD" },
               new Product() { ProductID = 7,ProductName="Gaming Console", StockQuantity=30,Price=499.99M,Description="4K HDR, 1TB Storage, DualSense Wireless Controller" },
               new Product() { ProductID = 8,ProductName="Wireless Router", StockQuantity=90,Price=79.99M,Description="Dual-Band Gigabit Wi-Fi Router, Parental Controls" },
               new Product() { ProductID = 9,ProductName="External Hard Drive", StockQuantity=520,Price=129.99M,Description="2TB Portable USB 3.0 External HDD, Backup Solution" },
               new Product() { ProductID = 10,ProductName="Wireless Mouse", StockQuantity=200,Price=29.99M,Description="Ergonomic Design, Silent Click, USB Receiver" },
            };

            repository = new ProductRepository();
            productList = new List<Product>();
        }

        [TearDown]
        public void teardown()
        {

            productList = null;
            repository = null;
            prodDS = null;
        }

        [Test]
        public void _01Test_ReadGetAllRows_ExpectedReturnAllproduct10_WhenReadGetAllRowsCalled()
        {
            //arrange 
            int noOfProdExpected = 10;
            repository.SetDS(prodDS);

            //Act 
            productList = repository.ReadGetAllRows();


            //Assert 
            Assert.AreEqual(noOfProdExpected, productList.Count);
        }

        [Test]
        public void _02Test_ReadGetAllRows_ExpectedAreNotEqual_WhenReadGetAllRowsCalled()
        {
            //arrange 
            int noOfPayExpected = 15;
            repository.SetDS(prodDS);

            //Act 
            productList = repository.ReadGetAllRows();


            //Assert 
            Assert.AreNotEqual(noOfPayExpected, productList.Count);
        }


        [Test]
        public void _03Test_ReadGetAllRows_ExpectedReturnAllProductTrue_WhenAdded1moreProduct()
        {

            //arrange 
            Product product = new Product { ProductID = 11, ProductName = "Jack", StockQuantity = 50, Price = 524.525M, Description = "" };
            bool expected = true;
            repository.SetDS(prodDS);

            //act
            bool actual = repository.AddEntity(product);



            //Assert 
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _04DeleteRow_ExpectedToReturnTrue_WhenDelete1Product()
        {

            //arrange 
            int productID = 2;
            bool expected = true;
            repository.SetDS(prodDS);

            //act
            bool actual = repository.DeleteRow(productID);


            //Assert 
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void _06Test_ReadRowByID_ExpectedAreTheSameEachTestCase_WhenExistingSiscountIDIsPassedIn(int id)
        {
            //Arrange
            Product ProductOne = new Product();
            Product theSameProductOne = new Product();
            repository.SetDS(prodDS);

            //Act
            ProductOne = repository.ReadRowByID(id);
            theSameProductOne = Product.ProductsDataSet.FirstOrDefault(c => c.ProductID == id);


            //Assert
            Assert.AreEqual(ProductOne.ProductID, theSameProductOne.ProductID);

        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void _06DeleteRow_ExpectedToReturn9Products_WhenDelete1Product(int cusID)
        {

            //arrange 
            int ProductID = cusID;
            repository.SetDS(prodDS);

            //act
            bool result = repository.DeleteRow(ProductID);
            int actual = repository.ReadGetAllRows().Count;
            int expected = 9;


            //Assert 
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _07Test_ReadGetAllRows_ThrowsException_WhenReadGetAllRowsCalledWithNullRepository()
        {
            // Arrange
            repository.SetDS(prodDS);
            
            
            //Act
            repository = null;

            //Assert 
            Assert.Throws<NullReferenceException>(() => repository.ReadGetAllRows());
        }

    }
}

