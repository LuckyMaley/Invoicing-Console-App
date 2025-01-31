using NUnit.Framework;
using MainCode;
using MainCode.Repository;
using MainCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace UnitTests.RepositoryTests
{
    [TestFixture]
    public class CustomerRepositoryTests
    {
        CustomerRepository repository;
        List<Customer> customerList;
        List<Customer> cusDS;

        [SetUp]
        public void init()
        {
            repository = new CustomerRepository();
            customerList = new List<Customer>();
            cusDS = new List<Customer>()
            {
                new Customer{CustomerID = 1, FirstName = "Zack", Surname ="Efron", Email = "Efronz@gmail.com", Username = "Efronz", PasswordHash = "9b81a5d42b17f2674440e0fd17299352c4b2250a9070e49b2e800a4f1069768a", Salt = "salt", EncrytionType = "sha256", Address = "15 Zuma avenue, 2001", PhoneNumber = "074396748"},
                new Customer{CustomerID = 2, FirstName = "Katharyn", Surname = "Maybey", Email = "kmaybey0@gmail.com",PasswordHash = "$2a$04$EXUViAJAhyAFA2eFlBJdP.yHNtQZ7.b2IndjUgwFwc1InDh90cZeG", Salt = "Salt", EncrytionType = "sha256", Address = "22310 Schmedeman Parkway", PhoneNumber ="368-346-0788" },
                new Customer{CustomerID = 3, FirstName = "Lanni", Surname = "Measom", Email = "lmeasom1@networkadvertising.org", Username = "lmeasom1", PasswordHash = "$2a$04$wNfIJrMZrwPQakteJFtRg.PjUxjRNeW4zXV5BAKqzUnnhQEdbqDxi", Salt = "salt", EncrytionType= "sha256", Address= "6 Kim Place", PhoneNumber = "991-219-0321" },
                new Customer{CustomerID = 4, FirstName = "Laying", Surname = "Woolaston", Email = "mwoolaston2@soup.io", Username = "mwoolaston2", PasswordHash = "$2a$04$yIbAcmN7pnvr3Kx4uRetbO0kNMaiibHJWjE82C64XOfC7EJ2d/jbC", Salt = "salt", EncrytionType= "sha256", Address= "8 Saint Paul Pass", PhoneNumber = "404-725-6084" },
                new Customer{CustomerID = 5, FirstName = "Linda", Surname = "Hamby", Email = "lhamby3@a8.net", Username = "lhamby3", PasswordHash = "$2a$04$0GqQHdkme.z/3JgHbtJJ0uWFl24K9UHoHvXzsMgHPr6tFaAJZTQ4", Salt = "salt", EncrytionType= "sha256", Address= "09060 Hanover Trail", PhoneNumber = "879-880-7372" },
                new Customer{CustomerID = 6, FirstName = "Ernesto", Surname = "Bartaloni", Email = "ebartaloni4@intel.com", Username = "ebartaloni4", PasswordHash = "$2a$04$hUzIpXpM56L5n8CMc7t7tO3Fj2u5sSD4Cgmx6teV8HD/bKDsz8TJK", Salt = "salt", EncrytionType= "sha256", Address= "0 Garrison Crossing", PhoneNumber = "799-505-6110" },
                new Customer{CustomerID = 7, FirstName = "Tarra", Surname = "MacGinney", Email = "tmacginney5@goodreads.com", Username = "tmacginney5", PasswordHash = "$2a$04$8bg08g1Kn5NiXYPzHOM8JeM/ylN3nnmMnYNKc34jUKohFOdtZrakC", Salt = "salt", EncrytionType= "sha256", Address= "36383 Hallows Place", PhoneNumber = "122-564-5165" },
                new Customer{CustomerID = 8, FirstName = "Cacilia", Surname = "Rhodef", Email = "crhodef6@shutterfly.com", Username = "crhodef6", PasswordHash = "$2a$04$d8M5ZTAbUGOSdanN.aNDHePuKw9zyjX3jEkZA0pMzg1r3PnkFhuJu", Salt = "salt", EncrytionType= "sha256", Address= "0148 Little Fleur Hill", PhoneNumber = "640-914-6862" },
                new Customer{CustomerID = 9, FirstName = "Kerr", Surname = "Ivashkin", Email = "kivashkin7@salon.com", Username = "kivashkin7", PasswordHash = "$2a$04$pfcMMOIDclufIB9buK4pG.WCFPrM.71o5sWTx1g/WepPtEvR8r1Hm", Salt = "salt", EncrytionType= "sha256", Address= "3113 Clyde Gallagher Crossing", PhoneNumber = "733-331-0434" },
                new Customer{CustomerID = 10, FirstName = "Emelda", Surname = "Guinnane", Email = "eguinnane8@discovery.com", Username = "eguinnane8", PasswordHash = "$2a$04$tirp.r4yA599Xq3OI3aYCea46Xgoxd1GrtneIzv5fR4FYH07MvIDG", Salt = "salt", EncrytionType= "sha256", Address= "656 Menomonie Hill", PhoneNumber = "656-188-2034" }
            };
        }

        [TearDown]
        public void teardown()
        {
            customerList = null;
            repository = null;
            cusDS = null;
        }


        [Test]
        public void _01Test_ReadGetAllRows_ExpectedReturnAllCustomer10_WhenReadGetAllRowsCalled()
        {
            //arrange 
            int noOfCustExpected = 10;
            repository.SetDS(cusDS);

            //Act 
            customerList = repository.ReadGetAllRows();


            //Assert 
            Assert.AreEqual(noOfCustExpected, customerList.Count);
        }

        [Test]
        public void _02Test_ReadGetAllRows_ExpectedAreNotEqual_WhenReadGetAllRowsCalled()
        {
            //arrange 
            int noOfCustExpected = 15;
            repository.SetDS(cusDS);

            //Act 
            customerList = repository.ReadGetAllRows();


            //Assert 
            Assert.AreNotEqual(noOfCustExpected, customerList.Count);
        }


        [Test]
        public void _03Test_ReadGetAllRows_ExpectedReturnAllCustomerTrue_WhenAdded1moreCustomer()
        {

            //arrange 
            Customer customer = new Customer { CustomerID = 11, FirstName = " Sisanda", Surname = "Ndlovu", Email = "Nosiphondlovu@gmail.com", PasswordHash = "9b81a5d42b17f2674440e0fd17299352c4b2250a9070e49b2e800a4f1069768a", Salt = "SALT", EncrytionType = "sha256", Address = "120 crystalValleu", PhoneNumber = "0856048759" };
            bool expected = true;
            repository.SetDS(cusDS);

            //act
            bool actual = repository.AddEntity(customer);
            


            //Assert 
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _04DeleteRow_ExpectedToReturnTrue_WhenDelete1Customer()
        {

            //arrange 
            int customerID = 10;
            bool expected = true;
            repository.SetDS(cusDS);

            //act
            bool actual = repository.DeleteRow(customerID);


            //Assert 
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _05Test_ReadGetAllRows_ExpectedReturn11Customers_WhenAdded1moreCustomer()
        {

            //arrange 
            Customer customer = new Customer { CustomerID = 11, FirstName = " Sisanda", Surname = "Ndlovu", Email = "Nosiphondlovu@gmail.com", PasswordHash = "9b81a5d42b17f2674440e0fd17299352c4b2250a9070e49b2e800a4f1069768a", Salt = "SALT", EncrytionType = "sha256", Address = "120 crystalValleu", PhoneNumber = "0856048759" };
            repository.SetDS(cusDS);

            //act
            bool result = repository.AddEntity(customer);
            int actual = repository.ReadGetAllRows().Count;
            int expected = 11;

            //Assert 
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void _06DeleteRow_ExpectedToReturn9Customers_WhenDelete1Customer(int cusID)
        {

            //arrange 
            int customerID = cusID;
            repository.SetDS(cusDS);

            //act
            bool result = repository.DeleteRow(customerID);
            int actual = repository.ReadGetAllRows().Count;
            int expected = 9;


            //Assert 
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void _07Test_ReadGetAllRows_ExpectedReadgetallrowsisEqualtoCustomerDataSet_WhenReadGetAllRowsCalled()
        {
            //arrange 
            repository.SetDS(cusDS);
            List<Customer> customerDSList = new List<Customer>();

            //Act 
            customerList = repository.ReadGetAllRows();
            customerDSList = Customer.CustomersDataSet.ToList();
            int noOfCustExpected = customerDSList.Count;

            //Assert 
            Assert.AreEqual(noOfCustExpected, customerList.Count);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void _08Test_ReadRowByID_Expected1RowEachTestCase_WhenExistingCustIDIsPassedIn(int id)
        {
            //Arrange
            Customer customer = new Customer();
            repository.SetDS(cusDS);

            //Act
            customer = repository.ReadRowByID(id);

            //Assert
            Assert.IsNotNull(customer);

        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void _10Test_ReadRowByID_ExpectedAreTheSameEachTestCase_WhenExistingCustIDIsPassedIn(int id)
        {
            //Arrange
            Customer customerOne = new Customer();
            Customer theSameCustomer = new Customer();
            repository.SetDS(cusDS);

            //Act
            customerOne = repository.ReadRowByID(id);
            theSameCustomer = Customer.CustomersDataSet.FirstOrDefault(c => c.CustomerID == id);

            //Assert
            Assert.AreEqual(customerOne.CustomerID, theSameCustomer.CustomerID);

        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void _11Test_CheckIfIDExists_ExpectedToReturnTrue_WhenCustomerIDExists(int cusID)
        {

            //arrange 
            int customerID = cusID;
            bool expected = true;
            repository.SetDS(cusDS);

            //act
            bool actual = repository.CheckIfIdExists(customerID);


            //Assert 
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Efronz@gmail.com")]
        [TestCase("kmaybey0@gmail.com")]
        [TestCase("lmeasom1@networkadvertising.org")]
        [TestCase("mwoolaston2@soup.io")]
        [TestCase("lhamby3@a8.net")]
        public void _12Test_CheckIfEmailExists_ExpectedToReturnTrue_WhenEmailExists(string email)
        {

            //arrange 
            string customerEmail = email;
            bool expected = true;
            repository.SetDS(cusDS);

            //act
            bool actual = repository.CheckIfEmailExists(email);


            //Assert 
            Assert.AreEqual(expected, actual);
        }

        [TestCase(12)]
        [TestCase(22)]
        [TestCase(23)]
        [TestCase(24)]
        [TestCase(25)]
        public void _13Test_CheckIfIDExists_ExpectedToReturnFalse_WhenCustomerIDDoesNotExist(int cusID)
        {

            //arrange 
            int customerID = cusID;
            repository.SetDS(cusDS);

            //act
            bool actual = repository.CheckIfIdExists(customerID);


            //Assert 
            Assert.IsFalse(actual);
        }

        [TestCase("Sfronk@gmail.com")]
        [TestCase("kmabe0@gmail.com")]
        [TestCase("lmeashoma1@networkadvertising.org")]
        [TestCase("moolaston2@sop.io")]
        [TestCase("lharmb3@a8.net")]
        public void _14Test_CheckIfEmailExists_ExpectedToReturnFalse_WhenEmailDoesNotExist(string email)
        {

            //arrange 
            string customerEmail = email;
            repository.SetDS(cusDS);

            //act
            bool actual = repository.CheckIfEmailExists(customerEmail);


            //Assert 
            Assert.IsFalse(actual);
        }

        [Test]
        public void _15Test_ReadGetAllRows_ExpectedThrowsException_WhenReadGetAllRowsCalledWithNullRepository()
        {
            // Arrange
            repository.SetDS(cusDS);


            //Act
            repository = null;

            //Assert 
            Assert.Throws<NullReferenceException>(() => repository.ReadGetAllRows());
        }

        [Test]
        public void _16Test_ReadGetAllRows_ExpectedDoesNotThrowException_WhenReadGetAllRowsCalledWithRepositoryWithData()
        {
            // Arrange
            repository.SetDS(cusDS);
            
            //Act
            repository.ReadGetAllRows();

            //Assert 
            Assert.DoesNotThrow(() => repository.ReadGetAllRows());
        }

    }
}
