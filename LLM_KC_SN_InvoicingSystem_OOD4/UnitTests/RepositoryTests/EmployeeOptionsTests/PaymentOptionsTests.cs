using MainCode.Models;
using MainCode.Repository.EmployeeOptions;
using MainCode.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainCode.Repository.CustomerOptions;

namespace UnitTests.RepositoryTests.EmployeeOptionsTests
{
    public class PaymentOptionsTests
    {
        Mock<PaymentRepository> _mockpaymentsrepository;
        Mock<RepositoryBase<Payment>> _mockPaymentRepositoryBase;
        PaymentOptions _paymentOptions;
        List<Payment> payments;

        [SetUp]
        public void SetUp()
        {
            _mockpaymentsrepository = new Mock<PaymentRepository>();
            _mockPaymentRepositoryBase = new Mock<RepositoryBase<Payment>>();
            _paymentOptions = new PaymentOptions(_mockpaymentsrepository.Object, _mockPaymentRepositoryBase.Object);


            payments = new List<Payment>()
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
        public void TearDown()
        {
            _mockPaymentRepositoryBase = null;
            _mockpaymentsrepository = null;
            _paymentOptions = null;

            payments.Clear();
        }

        [Test]
        public void _01Test_FindPaymentByDate_ExpectedFalse_WhenPaymentDoesNotExist()
        {
            // Arrange
            string date = "11/11/2025";


            _mockpaymentsrepository.Setup(repo => repo.ReadRowByDate(date)).Returns(payments.Where(c => c.PaymentDate.Date.ToString("dd/MM/yyyy").Equals(date)).ToList());
            _mockpaymentsrepository.Setup(repo => repo.ReadGetAllRows()).Returns(payments);

            // Act        
            string paymentDetails = _paymentOptions.FindPaymentsbyDate(date);
            string expected = "There is no payment in that date";

            // Assert
            Assert.IsFalse(paymentDetails.Contains(expected));

        }



        [Test]
        public void _02Test_FindPaymentByDate_ExpectedTrue_WhenPaymentDoesExistWithId1()
        {
            // Arrange
            string date = "04/01/2024";

            _mockpaymentsrepository.Setup(repo => repo.ReadRowByDate(date)).Returns(payments.Where(c => c.PaymentDate.Date.ToString("dd/MM/yyyy").Equals(date)).ToList());
            _mockpaymentsrepository.Setup(repo => repo.ReadGetAllRows()).Returns(payments);

            // Act
            string paymentDetails = _paymentOptions.FindPaymentsbyDate(date);


            // Assert
            Assert.IsTrue(paymentDetails.Contains("ID: 1"));


        }

        [Test]
        public void _03Test_FindPaymentByDate_ExpectedFalse_WhenDoesntExistWithId31()
        {
            // Arrange
            string date = "04/01/2024";

            _mockpaymentsrepository.Setup(repo => repo.ReadRowByDate(date)).Returns(payments.Where(c => c.PaymentDate.Date.ToString("dd/MM/yyyy").Equals(date)).ToList());
            _mockpaymentsrepository.Setup(repo => repo.ReadGetAllRows()).Returns(payments);

            // Act
            string paymentDetails = _paymentOptions.FindPaymentsbyDate(date);


            // Assert
            Assert.IsFalse(paymentDetails.Contains("ID: 31"));


        }

        [Test]
        public void _04Test_FindPaymentByDate_ExpectedOccurOnce_WhenPaymentDoesExist()
        {
            // Arrange
            string date = "04/01/2024";

            _mockpaymentsrepository.Setup(repo => repo.ReadRowByDate(date)).Returns(payments.Where(c => c.PaymentDate.Date.ToString("dd/MM/yyyy").Equals(date)).ToList());
            _mockpaymentsrepository.Setup(repo => repo.ReadGetAllRows()).Returns(payments);

            // Act
            string paymentDetails = _paymentOptions.FindPaymentsbyDate(date);


            // Assert


            _mockpaymentsrepository.Verify(c => c.ReadRowByDate(date), Times.Once);

        }

        [Test]
        public void _05Test_FindPaymentByBetweenDate_ExpectedFalse_WhenPaymentDoesntExist()
        {
            // Arrange
            string date = "01/02/2025";
            string dateTwo = "10/06/2025";
            string defaultDateString = "10/08/2024";
            string format = "dd/MM/yyyy";
            CultureInfo ci = new CultureInfo("en-za");

            DateTime beginDateTime;
            DateTime.TryParseExact(date, format, ci, System.Globalization.DateTimeStyles.None, out beginDateTime);

            DateTime endDateTime;
            DateTime.TryParseExact(dateTwo, format, ci, System.Globalization.DateTimeStyles.None, out endDateTime);

            _mockpaymentsrepository.Setup(repo => repo.ReadRowByDate(date)).Returns(payments.Where(c => c.PaymentDate.Date >= beginDateTime && c.PaymentDate.Date <= endDateTime.Date).ToList());
            _mockpaymentsrepository.Setup(repo => repo.ReadGetAllRows()).Returns(payments);

            //Act
            string paymentDetails = _paymentOptions.FindPaymentsbyBetweenDates(date, dateTwo);
            string expected = "There is no payment between those dates";

            //Assert
            Assert.IsFalse(paymentDetails.Contains("ID : 1"));

        }

        [Test]
        public void _06Test_FindPaymentByBetweenDate_ExpectedFalse_WhenPaymentDoesExist()
        {
            // Arrange
            string date = "01/02/2024";
            string dateTwo = "10/06/2024";
            string defaultDateString = "10/08/2022";
            string format = "dd/MM/yyyy";
            CultureInfo ci = new CultureInfo("en-za");

            DateTime beginDateTime;
            DateTime.TryParseExact(date, format, ci, System.Globalization.DateTimeStyles.None, out beginDateTime);

            DateTime endDateTime;
            DateTime.TryParseExact(dateTwo, format, ci, System.Globalization.DateTimeStyles.None, out endDateTime);

            _mockpaymentsrepository.Setup(repo => repo.ReadRowByDate(date)).Returns(payments.Where(c => c.PaymentDate.Date >= beginDateTime && c.PaymentDate.Date <= endDateTime.Date).ToList());
            _mockpaymentsrepository.Setup(repo => repo.ReadGetAllRows()).Returns(payments);

            //Act
            string paymentDetails = _paymentOptions.FindPaymentsbyBetweenDates(date, dateTwo);
            string expected = "ID: 04 January 2024";

            //Assert
            Assert.IsFalse(paymentDetails.Contains(expected));

        }

        [Test]
        public void _07Test_FindPaymentByBetweenDate_ExpectedOccurOnce_WhenPaymentDoesExist()
        {
            // Arrange
            List<Payment> PaymentsDataset = new List<Payment>
            {
                new Payment() { PaymentID = 1, InvoiceID = 1, PaymentDate = new DateTime(2024, 01, 04, 11, 13, 12), Amount = 6233.92, PaymentMethod = "PayPal" },
                new Payment() { PaymentID = 2, InvoiceID = 2, PaymentDate = new DateTime(2024, 01, 05, 12, 14, 15), Amount = 5678.71, PaymentMethod = "debit card" },
                new Payment() { PaymentID = 3, InvoiceID = 3, PaymentDate = new DateTime(2024, 05, 24, 10, 15, 12), Amount = 487.14, PaymentMethod = "PayPal" },
            };

            string date = "01/01/2024";
            string dateTwo = "10/06/2024";
            string defaultDateString = "10/08/2022";
            string format = "dd/MM/yyyy";
            CultureInfo ci = new CultureInfo("en-za");

            DateTime beginDateTime;
            DateTime.TryParseExact(date, format, ci, System.Globalization.DateTimeStyles.None, out beginDateTime);

            DateTime endDateTime;
            DateTime.TryParseExact(dateTwo, format, ci, System.Globalization.DateTimeStyles.None, out endDateTime);

            _mockpaymentsrepository.Setup(repo => repo.ReadRowByDate(date, dateTwo)).Returns(payments.Where(c => c.PaymentDate.Date >= beginDateTime && c.PaymentDate.Date <= endDateTime.Date).ToList());
            _mockpaymentsrepository.Setup(repo => repo.ReadGetAllRows()).Returns(PaymentsDataset);

            //Act
            string paymentDetails = _paymentOptions.FindPaymentsbyBetweenDates(date, dateTwo);
            //string expected = "ID: 04 January 2024";

            //Assert
            _mockpaymentsrepository.Verify(c => c.ReadRowByDate(date, dateTwo), Times.Once);

        }

        [Test]
        public void _08Test_FindNoteByBetweenDate_ExpectedTrue_WhenOneNoteDateIsEmpty()
        {
            // Arrange
            List<Payment> PaymentsDataset = new List<Payment>
            {
                new Payment() { PaymentID = 1, InvoiceID = 1, PaymentDate = new DateTime(2024, 01, 04, 11, 13, 12), Amount = 6233.92, PaymentMethod = "PayPal" },
                new Payment() { PaymentID = 2, InvoiceID = 2, PaymentDate = new DateTime(2024, 01, 5, 12, 14, 15), Amount = 5678.71, PaymentMethod = "debit card" },
                new Payment() { PaymentID = 3, InvoiceID = 3, PaymentDate = new DateTime(2024, 05, 24, 10, 15, 12), Amount = 487.14, PaymentMethod = "PayPal" },
            };

            string date = "";
            string dateTwo = "13/11/2024";
            string defaultDateString = "10/08/2008";
            string format = "dd/MM/yyyy";
            CultureInfo ci = new CultureInfo("en-za");

            DateTime beginDateTime;
            DateTime.TryParseExact(date, format, ci, System.Globalization.DateTimeStyles.None, out beginDateTime);

            DateTime endDateTime;
            DateTime.TryParseExact(dateTwo, format, ci, System.Globalization.DateTimeStyles.None, out endDateTime);

            _mockpaymentsrepository.Setup(repo => repo.ReadRowByDate(date)).Returns(PaymentsDataset);
            _mockpaymentsrepository.Setup(c => c.ReadGetAllRows());

            // Act
            string noteDetails = _paymentOptions.FindPaymentsbyBetweenDates(date, dateTwo);
            string expected = "Please enter both beginning and end dates";

            // Assert
            Assert.IsTrue(noteDetails.Contains(expected));
        }

        [Test]
        public void _09Test_FindPaymentByBetweenDate_ExpectedMoreThanOnceOccur_WhenPaymentDoesExist()
        {
            // Arrange
            List<Payment> PaymentsDataset = new List<Payment>
            {
                new Payment() { PaymentID = 1, InvoiceID = 1, PaymentDate = new DateTime(2024, 01, 04, 11, 13, 12), Amount = 6233.92, PaymentMethod = "PayPal" },
                new Payment() { PaymentID = 2, InvoiceID = 2, PaymentDate = new DateTime(2024, 01, 04, 12, 14, 15), Amount = 5678.71, PaymentMethod = "debit card" },
                new Payment() { PaymentID = 3, InvoiceID = 3, PaymentDate = new DateTime(2024, 05, 24, 10, 15, 12), Amount = 487.14, PaymentMethod = "PayPal" },
            };

            string date = "01/01/2024";
            string dateTwo = "10/06/2024";
            string defaultDateString = "10/08/2022";
            string format = "dd/MM/yyyy";
            CultureInfo ci = new CultureInfo("en-za");

            DateTime beginDateTime;
            DateTime.TryParseExact(date, format, ci, System.Globalization.DateTimeStyles.None, out beginDateTime);

            DateTime endDateTime;
            DateTime.TryParseExact(dateTwo, format, ci, System.Globalization.DateTimeStyles.None, out endDateTime);

            _mockpaymentsrepository.Setup(repo => repo.ReadRowByDate(date, dateTwo)).Returns(payments.Where(c => c.PaymentDate.Date >= beginDateTime && c.PaymentDate.Date <= endDateTime.Date).ToList());
            _mockpaymentsrepository.Setup(repo => repo.ReadGetAllRows()).Returns(PaymentsDataset);

            //Act
            string paymentDetails = _paymentOptions.FindPaymentsbyBetweenDates(date, dateTwo);


            //Assert
            Assert.IsTrue(paymentDetails.Contains("ID: 1"));
            Assert.IsTrue(paymentDetails.Contains("ID: 2"));

        }



        [Test]
        public void _10Test_FindPaymentByDate_ExpectedTrue_WhenPaymentDoesExist()
        {
            // Arrange
            string date = "04/01/2024";


            _mockpaymentsrepository.Setup(repo => repo.ReadRowByDate(date)).Returns(payments.Where(c => c.PaymentDate.Date.ToString("dd/MM/yyyy").Equals(date)).ToList());
            _mockpaymentsrepository.Setup(repo => repo.ReadGetAllRows()).Returns(payments);

            // Act        
            string paymentDetails = _paymentOptions.FindPaymentsbyDate(date);
            string expected = "Payment Date: 04 January 2024";

            // Assert
            Assert.IsTrue(paymentDetails.Contains(expected));

        }
    }
} 