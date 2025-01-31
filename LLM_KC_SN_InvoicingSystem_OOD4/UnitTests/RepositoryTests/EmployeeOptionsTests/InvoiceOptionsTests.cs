using MainCode.Models;
using MainCode.Repository.EmployeeOptions;
using MainCode.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace UnitTests.RepositoryTests.EmployeeOptionsTests
{
    [TestFixture]
    public class InvoiceOptionsTests
    {
        Mock<InvoicesRepository> _mockInvoicesrepository;
        Mock<DiscountRepository> _mockDiscountsrepository;
        InvoiceOptions _invoicesOptions;
        List<Invoice> invoiceList;
        List<Discount> discounts;

        [SetUp]
        public void SetUp()
        {
            _mockInvoicesrepository = new Mock<InvoicesRepository>();
            _mockDiscountsrepository = new Mock<DiscountRepository>();
            invoiceList = new List<Invoice>()
            {
                new Invoice{ InvoiceID =1,  CustomerID = 1,InvoiceDate = new DateTime(2024,3,4,09,34,00) ,DueDate =  new DateTime(2024,3,29,09,34,00), Subtotal= 834.34,Tax= 12,DiscountID = 1,TotalAmount = 492.96, Status =  "Pending"},
                new Invoice{ InvoiceID=2, CustomerID = 2  ,InvoiceDate = new DateTime(2024,3,5,09,34,00) ,DueDate =  new DateTime(2024,3,25,09,34,00), Subtotal=   511.64,Tax=10,DiscountID = 2 ,TotalAmount = 635.8 , Status =  "Pending"},
                new Invoice{ InvoiceID=3,CustomerID =3 ,InvoiceDate = new DateTime(2024,3,3,09,34,00),DueDate = new DateTime(2024,3,5,2,09,34,00),Subtotal  =591.95,Tax=3,DiscountID = 3,TotalAmount = 728.52, Status =  "Pending"},
            };
            discounts = new List<Discount>()
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
            _invoicesOptions = new InvoiceOptions(_mockInvoicesrepository.Object, _mockDiscountsrepository.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockInvoicesrepository = null;
            _mockDiscountsrepository = null;
            _invoicesOptions = null;
            invoiceList.Clear();
            discounts.Clear();
        }

        [Test]
        public void _01Test_FindInvoiceByID_ExpectedReadRowByIDNeverOccurs_WhenInvoiceIDDoesNotExist()
        {
            // Arrange
            int invoiceId = 11;
            var invoice = new Invoice() { InvoiceID = 11, CustomerID = 1, InvoiceDate = new DateTime(2024, 3, 4, 09, 34, 00), DueDate = new DateTime(2024, 3, 29, 09, 34, 00), Subtotal = 834.34, Tax = 12, DiscountID = 1, TotalAmount = 492.96, Status = "Pending" };

            _mockInvoicesrepository.Setup(repo => repo.CheckIfIdExists(invoiceId)).Returns(false);
            _mockInvoicesrepository.Setup(repo => repo.ReadRowByID(invoiceId)).Returns(invoice);
            _mockDiscountsrepository.Setup(c => c.ReadGetAllRows()).Returns(discounts);

            // Act
            string invoices = _invoicesOptions.FindInvoiceByID(invoiceId);

            // Assert
            _mockInvoicesrepository.Verify(c => c.ReadRowByID(invoiceId), Times.Never);
        }

        [Test]
        public void _02Test_FindInvoiceByID_ExpectedReadRowByIDOccursOnce_WhenInvoiceIDExists()
        {
            // Arrange
            int invoiceId = 11;
            var invoice = new Invoice() { InvoiceID = 11, CustomerID = 1, InvoiceDate = new DateTime(2024, 3, 4, 09, 34, 00), DueDate = new DateTime(2024, 3, 29, 09, 34, 00), Subtotal = 834.34, Tax = 12, DiscountID = 1, TotalAmount = 492.96, Status = "Pending" };

            _mockInvoicesrepository.Setup(repo => repo.CheckIfIdExists(invoiceId)).Returns(true);
            _mockInvoicesrepository.Setup(repo => repo.ReadRowByID(invoiceId)).Returns(invoice);
            _mockDiscountsrepository.Setup(c => c.ReadGetAllRows()).Returns(discounts);

            // Act
            string invoices = _invoicesOptions.FindInvoiceByID(invoiceId);

            // Assert
            _mockInvoicesrepository.Verify(c => c.ReadRowByID(invoiceId), Times.Once);
        }

        [Test]
        public void _03Test_FindInvoiceByID_ExpectedFalse_WhenInvoiceExist()
        {
            // Arrange
            int invoiceId = 11;
            var invoice = new Invoice() { InvoiceID = 11, CustomerID = 1, InvoiceDate = new DateTime(2024, 3, 4, 09, 34, 00), DueDate = new DateTime(2024, 3, 29, 09, 34, 00), Subtotal = 834.34, Tax = 12, DiscountID = 1, TotalAmount = 492.96, Status = "Pending" };

            _mockInvoicesrepository.Setup(repo => repo.CheckIfIdExists(invoiceId)).Returns(true);
            _mockInvoicesrepository.Setup(repo => repo.ReadRowByID(invoiceId)).Returns(invoice);
            _mockDiscountsrepository.Setup(c => c.ReadGetAllRows()).Returns(discounts);

            // Act
            string invoices = _invoicesOptions.FindInvoiceByID(invoiceId);
            string expected = "invoice does not exist, Please try again";

            // Assert
            Assert.IsFalse(invoices.Contains(expected));
        }

        [Test]
        public void _04Test_FindInvoiceByID_ExpectedFalse_WhenInvoiceDoesNotExist()
        {
            // Arrange
            int invoiceId = 11;
            var invoice = new Invoice() { InvoiceID = 11, CustomerID = 1, InvoiceDate = new DateTime(2024, 3, 4, 09, 34, 00), DueDate = new DateTime(2024, 3, 29, 09, 34, 00), Subtotal = 834.34, Tax = 12, DiscountID = 1, TotalAmount = 492.96, Status = "Pending" };

            _mockInvoicesrepository.Setup(repo => repo.CheckIfIdExists(invoiceId)).Returns(false);
            _mockInvoicesrepository.Setup(repo => repo.ReadRowByID(invoiceId)).Returns(invoice);
            _mockDiscountsrepository.Setup(c => c.ReadGetAllRows()).Returns(discounts);

            // Act
            string invoices = _invoicesOptions.FindInvoiceByID(invoiceId);
            string expected = "ID: 11";

            // Assert
            Assert.IsFalse(invoices.Contains(expected));
        }

        [Test]
        public void _05Test_FindInvoiceByID_ExpectedTrue_WhenInvoiceDoesNotExist()
        {
            // Arrange
            int invoiceId = 11;
            var invoice = new Invoice() { InvoiceID = 11, CustomerID = 1, InvoiceDate = new DateTime(2024, 3, 4, 09, 34, 00), DueDate = new DateTime(2024, 3, 29, 09, 34, 00), Subtotal = 834.34, Tax = 12, DiscountID = 1, TotalAmount = 492.96, Status = "Pending" };

            _mockInvoicesrepository.Setup(repo => repo.CheckIfIdExists(invoiceId)).Returns(false);
            _mockInvoicesrepository.Setup(repo => repo.ReadRowByID(invoiceId)).Returns(invoice);
            _mockDiscountsrepository.Setup(c => c.ReadGetAllRows()).Returns(discounts);

            // Act
            string invoices = _invoicesOptions.FindInvoiceByID(invoiceId);
            string expected = "invoice does not exist, Please try again";

            // Assert
            Assert.IsTrue(invoices.Contains(expected));
        }

        [Test]
        public void _06Test_FindInvoiceByDate_ExpectedFalse_WhenInvoiceDoesExist()
        {
            // Arrange
            string date = "04/03/2024";

            _mockInvoicesrepository.Setup(repo => repo.ReadRowByDate(date)).Returns(invoiceList.Where(c => c.InvoiceDate.Date.ToString("dd/MM/yyyy").Equals(date)).ToList());
            _mockDiscountsrepository.Setup(c => c.ReadGetAllRows()).Returns(discounts);

            // Act
            string invoiceDetails = _invoicesOptions.FindInvoicesbyDate(date);
            string expected = "There is no invoice in that date";

            // Assert
            Assert.IsFalse(invoiceDetails.Contains(expected));
        }


        [Test]
        public void _07Test_FindInvoiceByDate_ExpectedTrue_WhenInvoiceDoesNotExist()
        {
            // Arrange
            string date = "17/11/2019";

            _mockInvoicesrepository.Setup(repo => repo.ReadRowByDate(date)).Returns(invoiceList.Where(c => c.InvoiceDate.Date.ToString("dd/MM/yyyy").Equals(date)).ToList());
            _mockDiscountsrepository.Setup(c => c.ReadGetAllRows()).Returns(discounts);

            // Act
            string invoiceDetails = _invoicesOptions.FindInvoicesbyDate(date);
            string expected = "There is no invoice in that date";

            // Assert
            Assert.IsTrue(invoiceDetails.Contains(expected));
        }

        [Test]
        public void _08Test_FindInvoiceByDate_ExpectedTrue_WhenInvoiceDateIsEmpty()
        {
            // Arrange
            string date = "";

            _mockInvoicesrepository.Setup(repo => repo.ReadRowByDate(date)).Returns(invoiceList.Where(c => c.InvoiceDate.Date.ToString("dd/MM/yyyy").Equals(date)).ToList());
            _mockDiscountsrepository.Setup(c => c.ReadGetAllRows()).Returns(discounts);

            // Act
            string invoiceDetails = _invoicesOptions.FindInvoicesbyDate(date);
            string expected = "No Date entered";

            // Assert
            Assert.IsTrue(invoiceDetails.Contains(expected));
        }

        [Test]
        public void _09Test_FindInvoiceByDate_ExpectedOccurOnce_WhenInvoiceDoesExist()
        {
            // Arrange
            string date = "12/11/2019";

            _mockInvoicesrepository.Setup(repo => repo.ReadRowByDate(date)).Returns(invoiceList.Where(c => c.InvoiceDate.Date.ToString("dd/MM/yyyy").Equals(date)).ToList());
            _mockDiscountsrepository.Setup(c => c.ReadGetAllRows()).Returns(discounts);

            // Act
            string invoiceDetails = _invoicesOptions.FindInvoicesbyDate(date);

            // Assert
            _mockInvoicesrepository.Verify(c => c.ReadRowByDate(date), Times.Once);
        }

        [Test]
        public void _10Test_FindInvoiceByDate_ExpectedMoreThanOne_WhenInvoiceDoesExist()
        {
            // Arrange
            invoiceList = new List<Invoice>()
            {
                 new Invoice{ InvoiceID=4,CustomerID =  4,InvoiceDate = new DateTime(2024,3,3,03,34,00),DueDate = new DateTime(2024,3,25,09,34,00), Subtotal=424.03,Tax=4,DiscountID = 4,TotalAmount = 465.82 , Status = "Paid"},
                new Invoice{ InvoiceID=5,CustomerID =5,InvoiceDate = new DateTime(2024,3,3,06,34,00),DueDate = new DateTime(2024,3,5,09,34,00),   Subtotal =267.98,Tax=9,DiscountID = 5,TotalAmount = 850.92, Status =  "Paid"},
                new Invoice{ InvoiceID=6,CustomerID =6,InvoiceDate =  new DateTime(2024,3,3,07,34,00),DueDate =  new DateTime(2024,3,25,09,34,00),  Subtotal =997.89,Tax=8,DiscountID = 6,TotalAmount = 247.52  , Status = "Paid"},
                new Invoice{ InvoiceID=7,CustomerID =7 ,InvoiceDate = new DateTime(2024,3,3,08,34,00),DueDate = new DateTime(2024,3,25,09,34,00),   Subtotal =543.86,Tax=8,DiscountID = 7   ,TotalAmount = 555.31  , Status = "Paid"}
            };
            string date = "03/03/2024";

            _mockInvoicesrepository.Setup(repo => repo.ReadRowByDate(date)).Returns(invoiceList.Where(c => c.InvoiceDate.Date.ToString("dd/MM/yyyy").Equals(date)).ToList());
            _mockDiscountsrepository.Setup(c => c.ReadGetAllRows()).Returns(discounts);

            // Act
            string invoiceDetails = _invoicesOptions.FindInvoicesbyDate(date);

            // Assert
            Assert.IsTrue(invoiceDetails.Contains("ID: 4"));
            Assert.IsTrue(invoiceDetails.Contains("ID: 5"));
        }

        [Test]
        public void _11Test_FindInvoiceByBetweenDate_ExpectedFalse_WhenInvoiceDoesExist()
        {
            // Arrange
            string date = "02/03/2024";
            string dateTwo = "10/03/2024";
            string defaultDateString = "10/08/2008";
            string format = "dd/MM/yyyy";
            CultureInfo ci = new CultureInfo("en-za");

            DateTime beginDateTime;
            DateTime.TryParseExact(date, format, ci, System.Globalization.DateTimeStyles.None, out beginDateTime);

            DateTime endDateTime;
            DateTime.TryParseExact(dateTwo, format, ci, System.Globalization.DateTimeStyles.None, out endDateTime);

            _mockInvoicesrepository.Setup(repo => repo.ReadRowByDate(date, dateTwo)).Returns(invoiceList.Where(c => c.InvoiceDate.Date >= beginDateTime.Date && c.InvoiceDate.Date <= endDateTime.Date).ToList());
            _mockDiscountsrepository.Setup(c => c.ReadGetAllRows()).Returns(discounts);

            // Act
            string invoiceDetails = _invoicesOptions.FindInvoicesbyBetweenDates(date, dateTwo);
            string expected = "There is no invoice between those dates";

            // Assert
            Assert.IsFalse(invoiceDetails.Contains(expected));
        }


        [Test]
        public void _12Test_FindInvoiceByBetweenDate_ExpectedTrue_WhenInvoiceDoesNotExist()
        {
            // Arrange
            string date = "17/11/2019";
            string dateTwo = "21/11/2019";
            string defaultDateString = "10/08/2008";
            string format = "dd/MM/yyyy";
            CultureInfo ci = new CultureInfo("en-za");

            DateTime beginDateTime;
            DateTime.TryParseExact(date, format, ci, System.Globalization.DateTimeStyles.None, out beginDateTime);

            DateTime endDateTime;
            DateTime.TryParseExact(dateTwo, format, ci, System.Globalization.DateTimeStyles.None, out endDateTime);

            _mockInvoicesrepository.Setup(repo => repo.ReadRowByDate(date, dateTwo)).Returns(invoiceList.Where(c => c.InvoiceDate.Date >= beginDateTime.Date && c.InvoiceDate.Date <= endDateTime.Date).ToList());
            _mockDiscountsrepository.Setup(c => c.ReadGetAllRows()).Returns(discounts);

            // Act
            string invoiceDetails = _invoicesOptions.FindInvoicesbyBetweenDates(date, dateTwo);
            string expected = "There is no invoice between those dates";

            // Assert
            Assert.IsTrue(invoiceDetails.Contains(expected));
        }

        [Test]
        public void _13Test_FindInvoiceByBetweenDate_ExpectedTrue_WhenOneInvoiceDateIsEmpty()
        {
            // Arrange
            string date = "";
            string dateTwo = "13/11/2018";
            string defaultDateString = "10/08/2008";
            string format = "dd/MM/yyyy";
            CultureInfo ci = new CultureInfo("en-za");

            DateTime beginDateTime;
            DateTime.TryParseExact(date, format, ci, System.Globalization.DateTimeStyles.None, out beginDateTime);

            DateTime endDateTime;
            DateTime.TryParseExact(dateTwo, format, ci, System.Globalization.DateTimeStyles.None, out endDateTime);

            _mockInvoicesrepository.Setup(repo => repo.ReadRowByDate(date, dateTwo)).Returns(invoiceList.Where(c => c.InvoiceDate.Date >= beginDateTime.Date && c.InvoiceDate.Date <= endDateTime.Date).ToList());
            _mockDiscountsrepository.Setup(c => c.ReadGetAllRows()).Returns(discounts);

            // Act
            string invoiceDetails = _invoicesOptions.FindInvoicesbyBetweenDates(date, dateTwo);
            string expected = "Please enter both beginning and end dates";

            // Assert
            Assert.IsTrue(invoiceDetails.Contains(expected));
        }

        [Test]
        public void _14Test_FindInvoiceByBetweenDate_ExpectedOccurOnce_WhenInvoiceDoesExist()
        {
            // Arrange
            string date = "12/11/2019";
            string dateTwo = "13/11/2018";
            string defaultDateString = "10/08/2008";
            string format = "dd/MM/yyyy";
            CultureInfo ci = new CultureInfo("en-za");

            DateTime beginDateTime;
            DateTime.TryParseExact(date, format, ci, System.Globalization.DateTimeStyles.None, out beginDateTime);

            DateTime endDateTime;
            DateTime.TryParseExact(dateTwo, format, ci, System.Globalization.DateTimeStyles.None, out endDateTime);

            _mockInvoicesrepository.Setup(repo => repo.ReadRowByDate(date, dateTwo)).Returns(invoiceList.Where(c => c.InvoiceDate.Date >= beginDateTime.Date && c.InvoiceDate.Date <= endDateTime.Date).ToList());
            _mockDiscountsrepository.Setup(c => c.ReadGetAllRows()).Returns(discounts);

            // Act
            string invoiceDetails = _invoicesOptions.FindInvoicesbyBetweenDates(date, dateTwo);

            // Assert
            _mockInvoicesrepository.Verify(c => c.ReadRowByDate(date, dateTwo), Times.Once);
        }

        [Test]
        public void _15Test_FindInvoiceByBetweenDate_ExpectedMoreThanOne_WhenInvoiceDoesExist()
        {
            // Arrange
            invoiceList = new List<Invoice>()
            {
                new Invoice{ InvoiceID=4,CustomerID =  4,InvoiceDate = new DateTime(2024,3,3,03,34,00),DueDate = new DateTime(2024,3,25,09,34,00), Subtotal=424.03,Tax=4,DiscountID = 4,TotalAmount = 465.82 , Status = "Paid"},
                new Invoice{ InvoiceID=5,CustomerID =5,InvoiceDate = new DateTime(2024,3,3,06,34,00),DueDate = new DateTime(2024,3,5,09,34,00),   Subtotal =267.98,Tax=9,DiscountID = 5,TotalAmount = 850.92, Status =  "Paid"},
                new Invoice{ InvoiceID=6,CustomerID =6,InvoiceDate =  new DateTime(2024,3,3,07,34,00),DueDate =  new DateTime(2024,3,25,09,34,00),  Subtotal =997.89,Tax=8,DiscountID = 6,TotalAmount = 247.52  , Status = "Paid"},
                new Invoice{ InvoiceID=7,CustomerID =7 ,InvoiceDate = new DateTime(2024,3,3,08,34,00),DueDate = new DateTime(2024,3,25,09,34,00),   Subtotal =543.86,Tax=8,DiscountID = 7   ,TotalAmount = 555.31  , Status = "Paid"},
            };
            string date = "03/03/2024";
            string dateTwo = "03/04/2024";
            string defaultDateString = "10/08/2008";
            string format = "dd/MM/yyyy";
            CultureInfo ci = new CultureInfo("en-za");

            DateTime beginDateTime;
            DateTime.TryParseExact(date, format, ci, System.Globalization.DateTimeStyles.None, out beginDateTime);

            DateTime endDateTime;
            DateTime.TryParseExact(dateTwo, format, ci, System.Globalization.DateTimeStyles.None, out endDateTime);

            _mockInvoicesrepository.Setup(repo => repo.ReadRowByDate(date, dateTwo)).Returns(invoiceList.Where(c => c.InvoiceDate.Date >= beginDateTime.Date && c.InvoiceDate.Date <= endDateTime.Date).ToList());
            _mockDiscountsrepository.Setup(c => c.ReadGetAllRows()).Returns(discounts);

            // Act
            string invoiceDetails = _invoicesOptions.FindInvoicesbyBetweenDates(date, dateTwo);

            // Assert
            Assert.IsTrue(invoiceDetails.Contains("ID: 4"));
            Assert.IsTrue(invoiceDetails.Contains("ID: 5"));
        }

    }
}
