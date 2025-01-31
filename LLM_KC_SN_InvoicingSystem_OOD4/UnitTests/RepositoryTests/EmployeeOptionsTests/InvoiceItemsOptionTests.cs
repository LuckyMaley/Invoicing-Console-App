using MainCode.Repository.EmployeeOptions;
using MainCode.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainCode.Models;

namespace UnitTests.RepositoryTests.EmployeeOptionsTests
{
    [TestFixture]
    public class InvoiceItemsOptionTests
    {
        Mock<InvoiceItemsRepository> _mockInvoiceItemsrepository;
        Mock<InvoicesRepository> _mockInvoicesrepository;
        InvoiceItemsOptions _invoiceItemsOptions;
        List<InvoiceItem> invoiceItemsList;

        [SetUp]
        public void SetUp()
        {
            _mockInvoiceItemsrepository = new Mock<InvoiceItemsRepository>();
            _mockInvoicesrepository = new Mock<InvoicesRepository>();
            invoiceItemsList = new List<InvoiceItem>()
            {
                new InvoiceItem {InvoiceItemID=1, InvoiceID=11, ProductID=1, Quantity=1, UnitPrice=2100.99m},
                new InvoiceItem {InvoiceItemID=2, InvoiceID=11, ProductID=2, Quantity=1, UnitPrice=2700.99m},
                new InvoiceItem {InvoiceItemID=3, InvoiceID=12, ProductID=3, Quantity=1, UnitPrice=900.99m}
            };
            _invoiceItemsOptions = new InvoiceItemsOptions(_mockInvoiceItemsrepository.Object, _mockInvoicesrepository.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockInvoiceItemsrepository = null;
            _mockInvoicesrepository = null;
            _invoiceItemsOptions = null;
            invoiceItemsList.Clear();
        }

        [Test]
        public void _01Test_FindInvoiceItemsByID_ExpectedReadRowByIDNeverOccurs_WhenInvoiceItemIDDoesNotExist()
        {
            // Arrange
            int invoiceId = 11;
            
            _mockInvoicesrepository.Setup(repo => repo.CheckIfIdExists(invoiceId)).Returns(false);
            _mockInvoiceItemsrepository.Setup(repo => repo.ReadByInvoiceID(invoiceId)).Returns(invoiceItemsList);

            // Act
            string invoiceItems = _invoiceItemsOptions.FindInvoiceItemByInvoiceID(invoiceId);

            // Assert
            _mockInvoiceItemsrepository.Verify(c => c.ReadRowByID(invoiceId), Times.Never);
        }

        [Test]
        public void _02Test_FindInvoiceItemsByID_ExpectedReadRowByIDOccursOnce_WhenInvoiceItemIDExists()
        {
            // Arrange
            int invoiceId = 11;
            _mockInvoicesrepository.Setup(repo => repo.CheckIfIdExists(invoiceId)).Returns(true);
            _mockInvoiceItemsrepository.Setup(repo => repo.ReadByInvoiceID(invoiceId)).Returns(invoiceItemsList.Where(c => c.InvoiceID == invoiceId).ToList());

            // Act
            string invoiceItems = _invoiceItemsOptions.FindInvoiceItemByInvoiceID(invoiceId);

            // Assert
            _mockInvoiceItemsrepository.Verify(c => c.ReadByInvoiceID(invoiceId), Times.Once);
        }

        [Test]
        public void _03Test_FindInvoiceItemsByID_ExpectedFalse_WhenInvoiceItemsExist()
        {
            // Arrange
            int invoiceId = 11;
            _mockInvoicesrepository.Setup(repo => repo.CheckIfIdExists(invoiceId)).Returns(true);
            _mockInvoiceItemsrepository.Setup(repo => repo.ReadByInvoiceID(invoiceId)).Returns(invoiceItemsList);

            // Act
            string invoiceItems = _invoiceItemsOptions.FindInvoiceItemByInvoiceID(invoiceId);
            string expected = "invoice does not exist, Please try again";

            // Assert
            Assert.IsFalse(invoiceItems.Contains(expected));
        }

        [Test]
        public void _04Test_FindInvoiceItemsByID_ExpectedFalse_WhenInvoiceItemsDoesNotExist()
        {
            // Arrange
            int invoiceId = 11;
            _mockInvoicesrepository.Setup(repo => repo.CheckIfIdExists(invoiceId)).Returns(false);
            _mockInvoiceItemsrepository.Setup(repo => repo.ReadByInvoiceID(invoiceId)).Returns(invoiceItemsList);

            // Act
            string invoiceItems = _invoiceItemsOptions.FindInvoiceItemByInvoiceID(invoiceId);
            string expected = "ID: 11";

            // Assert
            Assert.IsFalse(invoiceItems.Contains(expected));
        }

        [Test]
        public void _05Test_FindInvoiceItemsByID_ExpectedTrue_WhenInvoiceItemsDoesNotExist()
        {
            // Arrange
            int invoiceId = 11;
            _mockInvoicesrepository.Setup(repo => repo.CheckIfIdExists(invoiceId)).Returns(false);
            _mockInvoiceItemsrepository.Setup(repo => repo.ReadByInvoiceID(invoiceId)).Returns(invoiceItemsList);

            // Act
            string invoiceItems = _invoiceItemsOptions.FindInvoiceItemByInvoiceID(invoiceId);
            string expected = "invoice does not exist, Please try again";

            // Assert
            Assert.IsTrue(invoiceItems.Contains(expected));
        }
    }
}
