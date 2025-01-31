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
    public class DiscountRepositoryTests
    {
        DiscountRepository repository;
        List<Discount> discountList;
        List<Discount> disDS;

        [SetUp]
        public void init()
        {
            repository = new DiscountRepository();
            discountList = new List<Discount>();
            disDS = new List<Discount>()
            {
                new Discount(){DiscountID=1,DiscountName="10% Off",Rate=90.04M,Amount=471.05},
                new Discount(){DiscountID=2,DiscountName="No Discount",Rate=86.93M,Amount=5582.01},
                new Discount(){DiscountID=3,DiscountName="20% Off",Rate=71.68M,Amount=2422.84},
                new Discount(){DiscountID=4,DiscountName="Special Promotion",Rate=62.14M,Amount=1079.64},
                new Discount(){DiscountID=5,DiscountName="sclawson4",Rate=41.55M,Amount=345.66},
                new Discount(){DiscountID=6,DiscountName="Holiday Sale",Rate=26.18M,Amount=7729.9},
                new Discount(){DiscountID=7,DiscountName="Summer Sale",Rate=38.56M,Amount=9089.21},
                new Discount(){DiscountID=8,DiscountName="Clearance Sale",Rate=30.04M,Amount=7249.33},
                new Discount(){DiscountID=9,DiscountName="No Discount",Rate=64.51M,Amount=5993.71},
                new Discount(){DiscountID=10,DiscountName="10% off",Rate=88.71M,Amount=5585.85}
            };

        }

        [TearDown]
        public void teardown()
        {
            discountList = null;
            repository = null;
            disDS = null;
        }


        [Test]
        public void _01Test_ReadGetAllRows_ExpectedReturnAllDiscount10_WhenReadGetAllRowsCalled()
        {
            //arrange 
            int noOfCDisExpected = 10;
            repository.SetDS(disDS);

            //Act 
            discountList = repository.ReadGetAllRows();



            //Assert 
            Assert.AreEqual(noOfCDisExpected, discountList.Count);
        }

        [Test]
        public void _02Test_ReadGetAllRows_ExpectedAreNotEqual_WhenReadGetAllRowsCalled()
        {
            //arrange 
            int noOfDisExpected = 15;
            repository.SetDS(disDS);

            //Act 
            discountList = repository.ReadGetAllRows();



            //Assert 
            Assert.AreNotEqual(noOfDisExpected, discountList.Count);
        }


        [Test]
        public void _03Test_ReadGetAllRows_ExpectedReturnAllSiscountTrue_WhenAdded1Discount()
        {

            //arrange 
            Discount discount = new Discount { DiscountID = 1, DiscountName = "", Rate = 90.04M, Amount = 5245.42 };
            bool expected = true;
            repository.SetDS(disDS);

            //act
            bool actual = repository.AddEntity(discount);




            //Assert 
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _04DeleteRow_ExpectedToReturnTrue_WhenDelete1Discount()
        {

            //arrange 
            int DiscountID = 2;
            bool expected = true;
            repository.SetDS(disDS);

            //act
            bool actual = repository.DeleteRow(DiscountID);



            //Assert 
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void _05Test_ReadGetAllRows_ReadgetallrowsisEqualtoDataSet_WhenReadGetAllRowsCalled()
        {
            //arrange 

            List<Discount> discountDSList = new List<Discount>();
            repository.SetDS(disDS);

            //Act 
            discountList = repository.ReadGetAllRows();
            discountDSList = Discount.DiscountsDataSet.ToList();
            int noOfDisExpected = discountDSList.Count;

            //Assert 
            Assert.AreEqual(noOfDisExpected, discountList.Count);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void _06Test_ReadRowByID_ExpectedAreTheSameEachTestCase_WhenExistingSiscountIDIsPassedIn(int id)
        {
            //Arrange
            Discount DiscountOne = new Discount();
            Discount theSameDiscountOne = new Discount();
            repository.SetDS(disDS);

            //Act
            DiscountOne = repository.ReadRowByID(id);
            theSameDiscountOne = Discount.DiscountsDataSet.FirstOrDefault(c => c.DiscountID == id);


            //Assert
            Assert.AreEqual(DiscountOne.DiscountID, theSameDiscountOne.DiscountID);

        }
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void _06DeleteRow_ExpectedToReturn9Discounts_WhenDelete1Discount(int disID)
        {

            //arrange 
            int DiscountID = disID;
            repository.SetDS(disDS);

            //act
            bool result = repository.DeleteRow(DiscountID);
            int actual = repository.ReadGetAllRows().Count;
            int expected = 9;


            //Assert 
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void _07Test_ReadGetAllRows_ThrowsException_WhenReadGetAllRowsCalledWithNullRepository()
        {
            // Arrange
            repository.SetDS(disDS);


            //Act
            repository = null;

            //Assert 
            Assert.Throws<NullReferenceException>(() => repository.ReadGetAllRows());
        }
    }
}
