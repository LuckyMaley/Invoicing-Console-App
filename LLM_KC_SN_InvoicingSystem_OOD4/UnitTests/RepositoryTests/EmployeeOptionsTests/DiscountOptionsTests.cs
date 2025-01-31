using System;
using Moq;
using NUnit.Framework;
using MainCode.Repository;
using MainCode.Repository.EmployeeOptions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainCode.Models;
using MainCode.Repository;
using MainCode.Repository.EmployeeOptions;
using MainCode.Repository.CustomerOptions;

namespace UnitTests.RepositoryTests.EmployeeOptionsTests
{
    [TestFixture]
    public class DiscountOptionsTests
    {
        Mock<DiscountRepository> _mockDiscountsrepository;
        Mock<RepositoryBase<Discount>> _mockDiscountrepositoryBase;
        Mock<IRepository<Discount>> _mockDiscountsIRepository;
        DiscountOptions _DiscountOptions;
        [SetUp]
        public void SetUp()
        {
            _mockDiscountsrepository = new Mock<DiscountRepository>();
            _mockDiscountrepositoryBase = new Mock<RepositoryBase<Discount>>();
            _mockDiscountsIRepository = new Mock<IRepository<Discount>>();
            _DiscountOptions = new DiscountOptions(_mockDiscountsrepository.Object, _mockDiscountrepositoryBase.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockDiscountsrepository = null;
            _mockDiscountrepositoryBase = null;
            _mockDiscountsIRepository = null;
            _DiscountOptions = null;
        }


        [Test]
        public void _01Test_FindDiscountByID_ExpectedReadRowByIDNeverOccurs_WhenDiscountIDDoesNotExist()
        {
            // Arrange
            int discountId = 11;
            var Discount = new Discount { DiscountID = 11, DiscountName = "", Rate = 52.25M, Amount = 525 };
            _mockDiscountsrepository.Setup(repo => repo.CheckIfidExists(discountId)).Returns(false);
            _mockDiscountsrepository.Setup(repo => repo.ReadRowByID(discountId)).Returns(Discount);


            // Act
            string DiscountDetails = _DiscountOptions.FindDiscountByID(discountId);

            // Assert
            _mockDiscountsrepository.Verify(c => c.ReadRowByID(discountId), Times.Never);
        }


        [Test]
        public void _02Test_FindDiscountByID_ExpectedTrue_WhenDiscountDetailExist()

        {
            // Arrange
            int DiscountId = 3;
            var Discount = new Discount { DiscountID = 3, DiscountName = "", Rate = 52.25M, Amount = 525 };
            _mockDiscountsrepository.Setup(repo => repo.CheckIfidExists(DiscountId)).Returns(true);
            _mockDiscountsrepository.Setup(repo => repo.ReadRowByID(DiscountId)).Returns(Discount);

            // Act
            string DiscountDetails = _DiscountOptions.FindDiscountByID(DiscountId);

            // Assert
            _mockDiscountsrepository.Verify(c => c.CheckIfidExists(DiscountId), Times.Once);

        }
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        public void _03Test_FindDiscountByID_ExpectedTrue_WhenDiscountDetailExist(int DiscountId)

        {
            // Arrange

            var Discount = new Discount { DiscountID = 3, DiscountName = "", Rate = 52.25M, Amount = 525 };
            _mockDiscountsrepository.Setup(repo => repo.CheckIfidExists(DiscountId)).Returns(true);
            _mockDiscountsrepository.Setup(repo => repo.ReadRowByID(DiscountId)).Returns(Discount);

            // Act
            string DiscountDetails = _DiscountOptions.FindDiscountByID(DiscountId);

            // Assert
            _mockDiscountsrepository.Verify(c => c.CheckIfidExists(DiscountId), Times.Once);

        }

        [TestCase(1)]
        [TestCase(10)]
        [TestCase(4)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        public void _04Test_FindDiscountByID_ExpectedTrue_WhenDiscountDetailExist(int DiscountId)

        {
            // Arrange
            var Discount = new Discount { DiscountID = 3, DiscountName = "", Rate = 52.25M, Amount = 525 };
            _mockDiscountsrepository.Setup(repo => repo.CheckIfidExists(DiscountId)).Returns(true);
            _mockDiscountsrepository.Setup(repo => repo.ReadRowByID(DiscountId)).Returns(Discount);

            // Act
            string DiscountDetails = _DiscountOptions.FindDiscountByID(DiscountId);

            // Assert
            _mockDiscountsrepository.Verify(c => c.CheckIfidExists(DiscountId), Times.Once);

        }

        [Test]
        public void _05Test_FindDiscountByID_ExpectedTrue_WhenDiscountDetailDoesExist()
        {
            // Arrange
            int DiscountId = 3;
            var Discount = new Discount { DiscountID = 1, DiscountName = "10% Off", Rate = 90.04M, Amount = 471.05 };
            _mockDiscountsrepository.Setup(repo => repo.CheckIfidExists(DiscountId)).Returns(true);
            _mockDiscountsrepository.Setup(repo => repo.ReadRowByID(DiscountId)).Returns(Discount);

            // Act
            string DiscountDetails = _DiscountOptions.FindDiscountByID(DiscountId);

            // Assert
            _mockDiscountsrepository.Verify(c => c.ReadRowByID(DiscountId), Times.Once);
        }

        [Test]
        public void _06Test_FindDiscountByID_Expectedfalse_WhenDiscountDetailDoesExist()
        {
            // Arrange
            int DiscountId = 3;
            var Discount = new Discount { DiscountID = 1, DiscountName = "10% Off", Rate = 90.04M, Amount = 471.05 };
            _mockDiscountsrepository.Setup(repo => repo.CheckIfidExists(DiscountId)).Returns(false);
            _mockDiscountsrepository.Setup(repo => repo.ReadRowByID(DiscountId)).Returns(Discount);

            // Act
            string DiscountDetails = _DiscountOptions.FindDiscountByID(DiscountId);

            // Assert
            _mockDiscountsrepository.Verify(c => c.ReadRowByID(DiscountId), Times.Never);
        }

        [Test]

        public void _07Test_FindDiscountByID_ExpectedTrue_WhenDiscountDetailExist()
        {
            // Arrange
            int DiscountId = 3;
            var Discount = new Discount { DiscountID = 1, DiscountName = "10% Off", Rate = 90.04M, Amount = 471.05 };
            _mockDiscountsrepository.Setup(repo => repo.CheckIfidExists(DiscountId)).Returns(true);
            _mockDiscountsrepository.Setup(repo => repo.ReadRowByID(DiscountId)).Returns(Discount);

            // Act
            string DiscountDetails = _DiscountOptions.FindDiscountByID(DiscountId);

            // Assert
            Assert.IsTrue(DiscountDetails.Contains(Discount.DiscountID.ToString()));
            Assert.IsTrue(DiscountDetails.Contains(Discount.DiscountName));

        }

        [TestCase(1)]
        [TestCase(6)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(4)]
        [TestCase(5)]
        public void _08Test_FindDiscountByID_ExpectedTrue_WhenDiscountDetailExist(int DiscountId)
        {
            // Arrange
            var Discount = new Discount { DiscountID = 1, DiscountName = "10% Off", Rate = 90.04M, Amount = 471.05 };
            _mockDiscountsrepository.Setup(repo => repo.CheckIfidExists(DiscountId)).Returns(true);
            _mockDiscountsrepository.Setup(repo => repo.ReadRowByID(DiscountId)).Returns(Discount);

            // Act
            string DiscountDetails = _DiscountOptions.FindDiscountByID(DiscountId);

            // Assert
            Assert.IsTrue(DiscountDetails.Contains(Discount.DiscountID.ToString()));
            Assert.IsTrue(DiscountDetails.Contains(Discount.DiscountName));

        }

        [Test]
        public void _09Test_FindDiscountByName_ExpectedFalse_WhenDiscountDetailDoesExist()
        {
            // Arrange
            string DiscountName = "Jack";
            var Discount = new Discount { DiscountID = 1, DiscountName = "10% Off", Rate = 90.04M, Amount = 471.05 };
            var DiscountTwo = new Discount { DiscountID = 1, DiscountName = "10% Off", Rate = 90.04M, Amount = 471.05 };
            Queue<Discount> stackDiscounts = new Queue<Discount>();
            List<Discount> list = new List<Discount>();
            list.Add(Discount);
            list.Add(DiscountTwo);
            foreach (var cus in list.Where(c => c.DiscountName == DiscountName).OrderByDescending(c => c.DiscountID).ToList())
            {
                stackDiscounts.Enqueue(cus);
            }
            _mockDiscountsrepository.Setup(repo => repo.GetDiscountByName(DiscountName)).Returns(stackDiscounts);

            // Act
            string DiscountDetails = _DiscountOptions.FindDiscountByName(DiscountName);
            string expected = "No Discount with that first name exists";

            // Assert
            Assert.IsFalse(DiscountDetails.Contains(expected));
        }


        [Test]
        public void _10Test_FindDiscountByName_ExpectedTrue_WhenDiscountDetailDoesNotExist()
        {
            // Arrange
            string DiscountName = "Alfred";
            var Discount = new Discount { DiscountID = 1, DiscountName = "10% Off", Rate = 90.04M, Amount = 471.05 };
            var DiscountTwo = new Discount { DiscountID = 1, DiscountName = "10% Off", Rate = 90.04M, Amount = 471.05 };
            Queue<Discount> stackDiscounts = new Queue<Discount>();
            List<Discount> list = new List<Discount>();
            list.Add(Discount);
            list.Add(DiscountTwo);
            foreach (var cus in list.Where(c => c.DiscountName == DiscountName).OrderByDescending(c => c.DiscountID).ToList())
            {
                stackDiscounts.Enqueue(cus);
            }
            _mockDiscountsrepository.Setup(repo => repo.GetDiscountByName(DiscountName)).Returns(stackDiscounts);

            // Act
            string DiscountDetails = _DiscountOptions.FindDiscountByName(DiscountName);
            string expected = "No discount with that first name exists";

            // Assert
            Assert.IsTrue(DiscountDetails.Contains(expected));
        }


        [Test]
        public void _11Test_AddNewDiscount_ExpectedAddOccurOnce_WhenDiscountDetailCorrectAndIDDoesNotexist()
        {
            // Arrange
            int DiscountId = 3;
            var Discount = new Discount { DiscountID = 1, DiscountName = "10% Off", Rate = 90.04M, Amount = 471.05 };
            _mockDiscountsrepository.Setup(repo => repo.CheckIfidExists(DiscountId)).Returns(false);
            _mockDiscountsrepository.Setup(repo => repo.AddEntity(Discount)).Returns(true);

            // Act
            string DiscountDetails = _DiscountOptions.AddNewDiscount(Discount);

            // Assert
            _mockDiscountsrepository.Verify(c => c.AddEntity(Discount), Times.Once);
        }

        [Test]
        public void _12Test_AddNewDiscount_ExpectedAddneverOccur_WhenDiscountDetailCorrectAndIDAlreadyExist()
        {
            // Arrange

            var Discount = new Discount { DiscountID = 1, DiscountName = "10% Off", Rate = 90.04M, Amount = 471.05 };
            _mockDiscountsrepository.Setup(repo => repo.CheckIfidExists(Discount.DiscountID)).Returns(true);
            _mockDiscountsrepository.Setup(repo => repo.AddEntity(Discount)).Returns(true);

            // Act
            string DiscountDetails = _DiscountOptions.AddNewDiscount(Discount);

            // Assert
            _mockDiscountsrepository.Verify(c => c.AddEntity(Discount), Times.Never);
        }

        [Test]
        public void _13Test_AddNewDiscount_ExpectedSuccessMessage_WhenDiscountDetailCorrectAndIDDoesNotAlreadyExist()
        {
            // Arrange
            var Discount = new Discount { DiscountID = 151, DiscountName = "10% Off", Rate = 90.04M, Amount = 471.05 };
            _mockDiscountsrepository.Setup(repo => repo.CheckIfidExists(Discount.DiscountID)).Returns(false);
            _mockDiscountsrepository.Setup(repo => repo.AddEntity(Discount)).Returns(true);

            // Act
            string DiscountDetails = _DiscountOptions.AddNewDiscount(Discount);
            string expected = "Discount has been added";

            // Assert
            Assert.IsTrue(DiscountDetails.Contains(expected));
        }

        [TestCase(258, "summer", 455.04, 442.25)]
        [TestCase(858, "summer deal", 78.04, 42.25)]
        [TestCase(5958, "spring deal", 47.04, 52.25)]
        [TestCase(758, "10% off", 85.04, 2.25)]
        public void _14Test_AddNewDiscount_ExpectedSuccessMessage_WhenDiscountDetailCorrectAndIDDoesNotAlreadyExist(int DiscountId, string Discountname, Decimal rate, double amount)
        {
            // Arrange
            var Discount = new Discount { DiscountID = DiscountId, DiscountName = Discountname, Rate = rate, Amount = amount };
            _mockDiscountsrepository.Setup(repo => repo.CheckIfidExists(Discount.DiscountID)).Returns(false);
            _mockDiscountsrepository.Setup(repo => repo.AddEntity(Discount)).Returns(true);

            // Act
            string DiscountDetails = _DiscountOptions.AddNewDiscount(Discount);
            string expected = "Discount has been added";

            // Assert
            Assert.IsTrue(DiscountDetails.Contains(expected));
        }

        [Test]
        public void _15Test_AddNewDiscount_ExpectedFailMessage_WhenDiscountDetailCorrectAndIDAlreadyExist()
        {
            // Arrange
            var Discount = new Discount { DiscountID = 1, DiscountName = "10% Off", Rate = 90.04M, Amount = 471.05 };
            _mockDiscountsrepository.Setup(repo => repo.CheckIfidExists(Discount.DiscountID)).Returns(true);
            _mockDiscountsrepository.Setup(repo => repo.AddEntity(Discount)).Returns(true);

            // Act
            string DiscountDetails = _DiscountOptions.AddNewDiscount(Discount);
            string expected = "Discount  already exists";

            // Assert
            Assert.IsTrue(DiscountDetails.Contains(expected));
        }

        [Test]
        public void _16Test_AddNewDiscount_ExpectedFailMessage_WhenAddingErrorOccurs()
        {
            // Arrange
            var Discount = new Discount { DiscountID = 784, DiscountName = "10% Off", Rate = 90.04M, Amount = 471.05 };
            _mockDiscountsrepository.Setup(repo => repo.CheckIfidExists(Discount.DiscountID)).Returns(false);
            _mockDiscountsrepository.Setup(repo => repo.AddEntity(Discount)).Returns(false);

            // Act
            string DiscountDetails = _DiscountOptions.AddNewDiscount(Discount);
            string expected = "An error occured, Discount was not added";

            // Assert
            Assert.IsTrue(DiscountDetails.Contains(expected));
        }

        [Test]
        public void _17Test_UpdateDiscount_ExpectedOccurOnce_WhenUpdatingDiscountCorrectly()
        {
            // Arrange
            var Discount = new Discount { DiscountID = 1, DiscountName = "10% ", Rate = 90.04M, Amount = 471.05 };
            _mockDiscountsrepository.Setup(repo => repo.CheckIfidExists(Discount.DiscountID)).Returns(true);
            _mockDiscountsrepository.Setup(repo => repo.UpdateEntity(Discount)).Returns(true);

            // Act
            string DiscountDetails = _DiscountOptions.UpdateDiscount(Discount);

            // Assert
            _mockDiscountsrepository.Verify(c => c.UpdateEntity(Discount), Times.Once);

        }


    }
}
