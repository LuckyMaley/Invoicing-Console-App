using MainCode;
using MainCode.Models;
using MainCode.Repository;
using MainCode.Repository.EmployeeOptions;
using MainCode.Repository.EmployeeOptions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.RepositoryTests.EmployeeOptionsTests
{
    [TestFixture]
    public class EmployeeOptionsTests
    {
        Mock<EmployeeRepository> _mockEmployeesrepository;
        Mock<RepositoryBase<Employee>> _mockEmployeeRepositoryBase;
        MainCode.Repository.EmployeeOptions.EmployeeOptions _employeeOptions;

        [SetUp]
        public void SetUp()
        {
            _mockEmployeesrepository = new Mock<EmployeeRepository>();
            _mockEmployeeRepositoryBase = new Mock<RepositoryBase<Employee>>();
            _employeeOptions = new MainCode.Repository.EmployeeOptions.EmployeeOptions(_mockEmployeesrepository.Object, _mockEmployeeRepositoryBase.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockEmployeesrepository = null;
            _mockEmployeeRepositoryBase = null;
            _employeeOptions = null;
        }

        [Test]
        public void _01Test_FindEmployeeByID_ExpectedReadRowByIDNeverOccurs_WhenEmployeeIDDoesNotExist()
        {
            // Arrange
            int employeeId = 11;
            var employee = new Employee { EmployeeID = 11, FirstName = "Mack", Surname = "Harris", Email = "Harrisj11@gmail.com", Username = "Harris01", Address = "23 West street, 4001", PhoneNumber = "0675744355", Role = "Employee" };
            _mockEmployeesrepository.Setup(repo => repo.CheckIfIdExists(employeeId)).Returns(false);
            _mockEmployeesrepository.Setup(repo => repo.ReadRowByID(employeeId)).Returns(employee);

            // Act
            string employeeDetails = _employeeOptions.FindEmployeeByID(employeeId);

            // Assert
            _mockEmployeesrepository.Verify(c => c.ReadRowByID(employeeId), Times.Never);
        }

        [Test]
        public void _02Test_FindEmployeeByID_ExpectedReadRowByIDOccursOnce_WhenEmployeeIDExists()
        {
            // Arrange
            int employeeId = 3;
            var employee = new Employee { EmployeeID = 3, FirstName = "Jack", Surname = "Harrison", Email = "Harrionj01@gmail.com", Username = "Harrison01", Address = "230 West street, 4001", PhoneNumber = "0675647385", Role = "Employee" };
            _mockEmployeesrepository.Setup(repo => repo.CheckIfIdExists(employeeId)).Returns(true);
            _mockEmployeesrepository.Setup(repo => repo.ReadRowByID(employeeId)).Returns(employee);

            // Act
            string employeeDetails = _employeeOptions.FindEmployeeByID(employeeId);

            // Assert
            _mockEmployeesrepository.Verify(c => c.ReadRowByID(employeeId), Times.Once);
        }

        [Test]
        public void _03Test_FindEmployeeByID_ExpectedTrue_WhenEmployeeDetailExist()
        {
            // Arrange
            int employeeId = 3;
            var employee = new Employee { EmployeeID = 3, FirstName = "Jack", Surname = "Harrison", Email = "Harrionj01@gmail.com", Username = "Harrison01", Address = "230 West street, 4001", PhoneNumber = "0675647385", Role = "Employee" };
            _mockEmployeesrepository.Setup(repo => repo.CheckIfIdExists(employeeId)).Returns(true);
            _mockEmployeesrepository.Setup(repo => repo.ReadRowByID(employeeId)).Returns(employee);

            // Act
            string employeeDetails = _employeeOptions.FindEmployeeByID(employeeId);

            // Assert
            Assert.IsTrue(employeeDetails.Contains(employee.EmployeeID.ToString()));
            Assert.IsTrue(employeeDetails.Contains(employee.FirstName));
            Assert.IsTrue(employeeDetails.Contains(employee.Surname));
            Assert.IsTrue(employeeDetails.Contains(employee.Email));
            Assert.IsTrue(employeeDetails.Contains(employee.Username));
            Assert.IsTrue(employeeDetails.Contains(employee.Address));
            Assert.IsTrue(employeeDetails.Contains(employee.PhoneNumber));
        }

        [Test]
        public void _04Test_FindEmployeeByID_ExpectedFalse_WhenEmployeeDetailDoesNotExist()
        {
            // Arrange
            int employeeId = 3;
            var employee = new Employee { EmployeeID = 3, FirstName = "Jack", Surname = "Harrison", Email = "Harrionj01@gmail.com", Username = "Harrison01", Address = "230 West street, 4001", PhoneNumber = "0675647385", Role = "Employee" };
            _mockEmployeesrepository.Setup(repo => repo.CheckIfIdExists(employeeId)).Returns(false);
            _mockEmployeesrepository.Setup(repo => repo.ReadRowByID(employeeId)).Returns(employee);

            // Act
            string employeeDetails = _employeeOptions.FindEmployeeByID(employeeId);

            // Assert
            Assert.IsFalse(employeeDetails.Contains(employee.EmployeeID.ToString()));
            Assert.IsFalse(employeeDetails.Contains(employee.FirstName));
            Assert.IsFalse(employeeDetails.Contains(employee.Surname));
            Assert.IsFalse(employeeDetails.Contains(employee.Email));
            Assert.IsFalse(employeeDetails.Contains(employee.Username));
            Assert.IsFalse(employeeDetails.Contains(employee.Address));
            Assert.IsFalse(employeeDetails.Contains(employee.PhoneNumber));
        }

        [Test]
        public void _05Test_FindEmployeeByID_ExpectedTrue_WhenEmployeeDetailDoesNotExist()
        {
            // Arrange
            int employeeId = 3;
            var employee = new Employee { EmployeeID = 3, FirstName = "Jack", Surname = "Harrison", Email = "Harrionj01@gmail.com", Username = "Harrison01", Address = "230 West street, 4001", PhoneNumber = "0675647385", Role = "Employee" };
            _mockEmployeesrepository.Setup(repo => repo.CheckIfIdExists(employeeId)).Returns(false);
            _mockEmployeesrepository.Setup(repo => repo.ReadRowByID(employeeId)).Returns(employee);

            // Act
            string employeeDetails = _employeeOptions.FindEmployeeByID(employeeId);
            string expected = "Employee does not exist, Please try again";

            // Assert
            Assert.IsTrue(employeeDetails.Contains(expected));
        }

        [Test]
        public void _06Test_FindEmployeeByName_ExpectedFalse_WhenEmployeeDetailDoesExist()
        {
            // Arrange
            string employeeName = "Jack";
            var employee = new Employee { EmployeeID = 3, FirstName = "Jack", Surname = "Harrison", Email = "Harrionj01@gmail.com", Username = "Harrison01", Address = "230 West street, 4001", PhoneNumber = "0675647385", Role = "Employee" };
            var employeeTwo = new Employee { EmployeeID = 5, FirstName = "Zack", Surname = "Wake", Email = "Wakez007@gmail.com", Username = "Wakez007", Address = "28 Sandton avenue, 2001", PhoneNumber = "0745667386", Role = "Employee" };
            Stack<Employee> stackEmployees = new Stack<Employee>();
            List<Employee> list = new List<Employee>();
            list.Add(employee);
            list.Add(employeeTwo);
            foreach (var adm in list.Where(c => c.FirstName == employeeName).OrderByDescending(c => c.EmployeeID).ToList())
            {
                stackEmployees.Push(adm);
            }
            _mockEmployeesrepository.Setup(repo => repo.GetEmployeeByName(employeeName)).Returns(stackEmployees);

            // Act
            string employeeDetails = _employeeOptions.FindEmployeeByFirstName(employeeName);
            string expected = "No employee with that first name exists";

            // Assert
            Assert.IsFalse(employeeDetails.Contains(expected));
        }


        [Test]
        public void _07Test_FindEmployeeByName_ExpectedTrue_WhenEmployeeDetailDoesNotExist()
        {
            // Arrange
            string employeeName = "Alfred";
            var employee = new Employee { EmployeeID = 3, FirstName = "Jack", Surname = "Harrison", Email = "Harrionj01@gmail.com", Username = "Harrison01", Address = "230 West street, 4001", PhoneNumber = "0675647385", Role = "Employee" };
            var employeeTwo = new Employee { EmployeeID = 5, FirstName = "Zack", Surname = "Wake", Email = "Wakez007@gmail.com", Username = "Wakez007", Address = "28 Sandton avenue, 2001", PhoneNumber = "0745667386", Role = "Employee" };
            Stack<Employee> stackEmployees = new Stack<Employee>();
            List<Employee> list = new List<Employee>();
            list.Add(employee);
            list.Add(employeeTwo);
            foreach (var adm in list.Where(c => c.FirstName == employeeName).OrderByDescending(c => c.EmployeeID).ToList())
            {
                stackEmployees.Push(adm);
            }
            _mockEmployeesrepository.Setup(repo => repo.GetEmployeeByName(employeeName)).Returns(stackEmployees);

            // Act
            string employeeDetails = _employeeOptions.FindEmployeeByFirstName(employeeName);
            string expected = "No employee with that first name exists";

            // Assert
            Assert.IsTrue(employeeDetails.Contains(expected));
        }

        [Test]
        public void _08Test_FindEmployeeByName_ExpectedTrue_WhenEmployeeNameIsEmpty()
        {
            // Arrange
            string employeeName = "";
            var employee = new Employee { EmployeeID = 3, FirstName = "Jack", Surname = "Harrison", Email = "Harrionj01@gmail.com", Username = "Harrison01", Address = "230 West street, 4001", PhoneNumber = "0675647385", Role = "Employee" };
            var employeeTwo = new Employee { EmployeeID = 5, FirstName = "Zack", Surname = "Wake", Email = "Wakez007@gmail.com", Username = "Wakez007", Address = "28 Sandton avenue, 2001", PhoneNumber = "0745667386", Role = "Employee" };
            Stack<Employee> stackEmployees = new Stack<Employee>();
            List<Employee> list = new List<Employee>();
            list.Add(employee);
            list.Add(employeeTwo);
            foreach (var adm in list.Where(c => c.FirstName == employeeName).OrderByDescending(c => c.EmployeeID).ToList())
            {
                stackEmployees.Push(adm);
            }
            _mockEmployeesrepository.Setup(repo => repo.GetEmployeeByName(employeeName)).Returns(stackEmployees);

            // Act
            string employeeDetails = _employeeOptions.FindEmployeeByFirstName(employeeName);
            string expected = "No employee with that first name exists";

            // Assert
            Assert.IsTrue(employeeDetails.Contains(expected));
        }

        [Test]
        public void _09Test_FindEmployeeByName_ExpectedOccurOnce_WhenEmployeeDetailDoesExist()
        {
            // Arrange
            string employeeName = "Alfred";
            var employee = new Employee { EmployeeID = 3, FirstName = "Jack", Surname = "Harrison", Email = "Harrionj01@gmail.com", Username = "Harrison01", Address = "230 West street, 4001", PhoneNumber = "0675647385", Role = "Employee" };
            var employeeTwo = new Employee { EmployeeID = 5, FirstName = "Zack", Surname = "Wake", Email = "Wakez007@gmail.com", Username = "Wakez007", Address = "28 Sandton avenue, 2001", PhoneNumber = "0745667386", Role = "Employee" };
            Stack<Employee> stackEmployees = new Stack<Employee>();
            List<Employee> list = new List<Employee>();
            list.Add(employee);
            list.Add(employeeTwo);
            foreach (var adm in list.Where(c => c.FirstName == employeeName).OrderByDescending(c => c.EmployeeID).ToList())
            {
                stackEmployees.Push(adm);
            }
            _mockEmployeesrepository.Setup(repo => repo.GetEmployeeByName(employeeName)).Returns(stackEmployees);

            // Act
            string employeeDetails = _employeeOptions.FindEmployeeByFirstName(employeeName);

            // Assert
            _mockEmployeesrepository.Verify(c => c.GetEmployeeByName(employeeName), Times.Once);
        }

        [Test]
        public void _10Test_FindEmployeeByName_ExpectedMoreThanOneJack_WhenEmployeeDetailDoesExist()
        {
            // Arrange
            string employeeName = "Jack";
            var employee = new Employee { EmployeeID = 3, FirstName = "Jack", Surname = "Harrison", Email = "Harrionj01@gmail.com", Username = "Harrison01", Address = "230 West street, 4001", PhoneNumber = "0675647385", Role = "Employee" };
            var employeeTwo = new Employee { EmployeeID = 5, FirstName = "Zack", Surname = "Wake", Email = "Wakez007@gmail.com", Username = "Wakez007", Address = "28 Sandton avenue, 2001", PhoneNumber = "0745667386", Role = "Employee" };
            var employeeThree = new Employee { EmployeeID = 9, FirstName = "Jack", Surname = "Fermin", Email = "Ferminj47@gmail.com", Username = "Ferminj47", Address = "100 Everton street, 6001", PhoneNumber = "0746277885", Role = "Employee" };
            Stack<Employee> stackEmployees = new Stack<Employee>();
            List<Employee> list = new List<Employee>();
            list.Add(employee);
            list.Add(employeeTwo);
            list.Add(employeeThree);
            foreach (var adm in list.Where(c => c.FirstName == employeeName).OrderByDescending(c => c.EmployeeID).ToList())
            {
                stackEmployees.Push(adm);
            }
            _mockEmployeesrepository.Setup(repo => repo.GetEmployeeByName(employeeName)).Returns(stackEmployees);

            // Act
            string employeeDetails = _employeeOptions.FindEmployeeByFirstName(employeeName);
            string expected = "First Name: Jack, Surname: Harrison";
            string expectedTwo = "First Name: Jack, Surname: Fermin";

            // Assert
            Assert.IsTrue(employeeDetails.Contains(expected));
            Assert.IsTrue(employeeDetails.Contains(expectedTwo));
        }

        [Test]
        public void _11Test_FindEmployeeByFullName_ExpectedFalse_WhenEmployeeDetailDoesExist()
        {
            // Arrange
            string employeeName = "Jack";
            string employeeSurname = "Harrison";
            var employee = new Employee { EmployeeID = 3, FirstName = "Jack", Surname = "Harrison", Email = "Harrionj01@gmail.com", Username = "Harrison01", Address = "230 West street, 4001", PhoneNumber = "0675647385", Role = "Employee" };
            var employeeTwo = new Employee { EmployeeID = 5, FirstName = "Zack", Surname = "Wake", Email = "Wakez007@gmail.com", Username = "Wakez007", Address = "28 Sandton avenue, 2001", PhoneNumber = "0745667386", Role = "Employee" };
            Stack<Employee> stackEmployees = new Stack<Employee>();
            List<Employee> list = new List<Employee>();
            list.Add(employee);
            list.Add(employeeTwo);
            foreach (var adm in list.Where(c => c.FirstName == employeeName && c.Surname == employeeSurname).OrderByDescending(c => c.EmployeeID).ToList())
            {
                stackEmployees.Push(adm);
            }
            _mockEmployeesrepository.Setup(repo => repo.GetEmployeeByName(employeeName, employeeSurname)).Returns(stackEmployees);

            // Act
            string employeeDetails = _employeeOptions.FindEmployeeByFullName(employeeName, employeeSurname);
            string expected = "No employee with that fullname exists";

            // Assert
            Assert.IsFalse(employeeDetails.Contains(expected));
        }


        [Test]
        public void _12Test_FindEmployeeByFullName_ExpectedTrue_WhenEmployeeDetailDoesNotExist()
        {
            // Arrange
            string employeeName = "Alfred";
            string employeeSurname = "Savage";
            var employee = new Employee { EmployeeID = 3, FirstName = "Jack", Surname = "Harrison", Email = "Harrionj01@gmail.com", Username = "Harrison01", Address = "230 West street, 4001", PhoneNumber = "0675647385", Role = "Employee" };
            var employeeTwo = new Employee { EmployeeID = 5, FirstName = "Zack", Surname = "Wake", Email = "Wakez007@gmail.com", Username = "Wakez007", Address = "28 Sandton avenue, 2001", PhoneNumber = "0745667386", Role = "Employee" };
            Stack<Employee> stackEmployees = new Stack<Employee>();
            List<Employee> list = new List<Employee>();
            list.Add(employee);
            list.Add(employeeTwo);
            foreach (var adm in list.Where(c => c.FirstName == employeeName && c.Surname == employeeSurname).OrderByDescending(c => c.EmployeeID).ToList())
            {
                stackEmployees.Push(adm);
            }
            _mockEmployeesrepository.Setup(repo => repo.GetEmployeeByName(employeeName, employeeSurname)).Returns(stackEmployees);

            // Act
            string employeeDetails = _employeeOptions.FindEmployeeByFullName(employeeName, employeeSurname);
            string expected = "No employee with that fullname exists";

            // Assert
            Assert.IsTrue(employeeDetails.Contains(expected));
        }

        [Test]
        public void _13Test_FindEmployeeByFullName_ExpectedTrue_WhenEmployeeNameIsEmpty()
        {
            // Arrange
            string employeeName = "";
            string employeeSurname = "";
            var employee = new Employee { EmployeeID = 3, FirstName = "Jack", Surname = "Harrison", Email = "Harrionj01@gmail.com", Username = "Harrison01", Address = "230 West street, 4001", PhoneNumber = "0675647385", Role = "Employee" };
            var employeeTwo = new Employee { EmployeeID = 5, FirstName = "Zack", Surname = "Wake", Email = "Wakez007@gmail.com", Username = "Wakez007", Address = "28 Sandton avenue, 2001", PhoneNumber = "0745667386", Role = "Employee" };
            Stack<Employee> stackEmployees = new Stack<Employee>();
            List<Employee> list = new List<Employee>();
            list.Add(employee);
            list.Add(employeeTwo);
            foreach (var adm in list.Where(c => c.FirstName == employeeName && c.Surname == employeeSurname).OrderByDescending(c => c.EmployeeID).ToList())
            {
                stackEmployees.Push(adm);
            }
            _mockEmployeesrepository.Setup(repo => repo.GetEmployeeByName(employeeName, employeeSurname)).Returns(stackEmployees);

            // Act
            string employeeDetails = _employeeOptions.FindEmployeeByFullName(employeeName, employeeSurname);
            string expected = "No employee with that fullname exists";

            // Assert
            Assert.IsTrue(employeeDetails.Contains(expected));
        }

        [Test]
        public void _14Test_FindEmployeeByFullName_ExpectedTrue_WhenEmployeeFirstNameIsEmptyButSurnameIsNot()
        {
            // Arrange
            string employeeName = "";
            string employeeSurname = "Harrision";
            var employee = new Employee { EmployeeID = 3, FirstName = "Jack", Surname = "Harrison", Email = "Harrionj01@gmail.com", Username = "Harrison01", Address = "230 West street, 4001", PhoneNumber = "0675647385", Role = "Employee" };
            var employeeTwo = new Employee { EmployeeID = 5, FirstName = "Zack", Surname = "Wake", Email = "Wakez007@gmail.com", Username = "Wakez007", Address = "28 Sandton avenue, 2001", PhoneNumber = "0745667386", Role = "Employee" };
            Stack<Employee> stackEmployees = new Stack<Employee>();
            List<Employee> list = new List<Employee>();
            list.Add(employee);
            list.Add(employeeTwo);
            foreach (var adm in list.Where(c => c.FirstName == employeeName && c.Surname == employeeSurname).OrderByDescending(c => c.EmployeeID).ToList())
            {
                stackEmployees.Push(adm);
            }
            _mockEmployeesrepository.Setup(repo => repo.GetEmployeeByName(employeeName, employeeSurname)).Returns(stackEmployees);

            // Act
            string employeeDetails = _employeeOptions.FindEmployeeByFullName(employeeName, employeeSurname);
            string expected = "No employee with that fullname exists";

            // Assert
            Assert.IsTrue(employeeDetails.Contains(expected));
        }

        [Test]
        public void _15Test_FindEmployeeByFullName_ExpectedOccurOnce_WhenEmployeeDetailDoesExist()
        {
            // Arrange
            string employeeName = "Alfred";
            string employeeSurname = "Bateman";
            var employee = new Employee { EmployeeID = 3, FirstName = "Jack", Surname = "Harrison", Email = "Harrionj01@gmail.com", Username = "Harrison01", Address = "230 West street, 4001", PhoneNumber = "0675647385", Role = "Employee" };
            var employeeTwo = new Employee { EmployeeID = 5, FirstName = "Zack", Surname = "Wake", Email = "Wakez007@gmail.com", Username = "Wakez007", Address = "28 Sandton avenue, 2001", PhoneNumber = "0745667386", Role = "Employee" };
            Stack<Employee> stackEmployees = new Stack<Employee>();
            List<Employee> list = new List<Employee>();
            list.Add(employee);
            list.Add(employeeTwo);
            foreach (var adm in list.Where(c => c.FirstName == employeeName && c.Surname == employeeSurname).OrderByDescending(c => c.EmployeeID).ToList())
            {
                stackEmployees.Push(adm);
            }
            _mockEmployeesrepository.Setup(repo => repo.GetEmployeeByName(employeeName, employeeSurname)).Returns(stackEmployees);

            // Act
            string employeeDetails = _employeeOptions.FindEmployeeByFullName(employeeName, employeeSurname);

            // Assert
            _mockEmployeesrepository.Verify(c => c.GetEmployeeByName(employeeName, employeeSurname), Times.Once);
        }

        [Test]
        public void _16Test_AddNewEmployee_ExpectedAddOccurOnce_WhenEmployeeDetailCorrectAndEmailDoesNotAlreadyExist()
        {
            // Arrange
            var employee = new Employee { EmployeeID = 3, FirstName = "Jack", Surname = "Harrison", Email = "Harrionj01@gmail.com", Username = "Harrison01", Address = "230 West street, 4001", PhoneNumber = "0675647385", Role = "Employee" };
            _mockEmployeesrepository.Setup(repo => repo.CheckIfEmailExists(employee.Email)).Returns(false);
            _mockEmployeesrepository.Setup(repo => repo.AddEntity(employee)).Returns(true);

            // Act
            string employeeDetails = _employeeOptions.AddNewEmployee(employee);

            // Assert
            _mockEmployeesrepository.Verify(c => c.AddEntity(employee), Times.Once);
        }

        [Test]
        public void _17Test_AddNewEmployee_ExpectedAddneverOccur_WhenEmployeeDetailCorrectAndEmailAlreadyExist()
        {
            // Arrange
            var employee = new Employee { EmployeeID = 3, FirstName = "Jack", Surname = "Harrison", Email = "Harrionj01@gmail.com", Username = "Harrison01", Address = "230 West street, 4001", PhoneNumber = "0675647385", Role = "Employee" };
            _mockEmployeesrepository.Setup(repo => repo.CheckIfEmailExists(employee.Email)).Returns(true);
            _mockEmployeesrepository.Setup(repo => repo.AddEntity(employee)).Returns(true);

            // Act
            string employeeDetails = _employeeOptions.AddNewEmployee(employee);

            // Assert
            _mockEmployeesrepository.Verify(c => c.AddEntity(employee), Times.Never);
        }

        [Test]
        public void _18Test_AddNewEmployee_ExpectedSuccessMessage_WhenEmployeeDetailCorrectAndEmailDoesNotAlreadyExist()
        {
            // Arrange
            var employee = new Employee { EmployeeID = 3, FirstName = "Jack", Surname = "Harrison", Email = "Harrionj01@gmail.com", Username = "Harrison01", Address = "230 West street, 4001", PhoneNumber = "0675647385", Role = "Employee" };
            _mockEmployeesrepository.Setup(repo => repo.CheckIfEmailExists(employee.Email)).Returns(false);
            _mockEmployeesrepository.Setup(repo => repo.AddEntity(employee)).Returns(true);

            // Act
            string employeeDetails = _employeeOptions.AddNewEmployee(employee);
            string expected = "Employee has been added";

            // Assert
            Assert.IsTrue(employeeDetails.Contains(expected));
        }

        [Test]
        public void _19Test_AddNewEmployee_ExpectedFailMessage_WhenEmployeeDetailCorrectAndEmailAlreadyExist()
        {
            // Arrange
            var employee = new Employee { EmployeeID = 3, FirstName = "Jack", Surname = "Harrison", Email = "Harrionj01@gmail.com", Username = "Harrison01", Address = "230 West street, 4001", PhoneNumber = "0675647385", Role = "Employee" };
            _mockEmployeesrepository.Setup(repo => repo.CheckIfEmailExists(employee.Email)).Returns(true);
            _mockEmployeesrepository.Setup(repo => repo.AddEntity(employee)).Returns(true);

            // Act
            string employeeDetails = _employeeOptions.AddNewEmployee(employee);
            string expected = "Employee with that email already exists";

            // Assert
            Assert.IsTrue(employeeDetails.Contains(expected));
        }

        [Test]
        public void _20Test_AddNewEmployee_ExpectedFailMessage_WhenAddingErrorOccurs()
        {
            // Arrange
            var employee = new Employee { EmployeeID = 3, FirstName = "Jack", Surname = "Harrison", Email = "Harrionj01@gmail.com", Username = "Harrison01", Address = "230 West street, 4001", PhoneNumber = "0675647385", Role = "Employee" };
            _mockEmployeesrepository.Setup(repo => repo.CheckIfEmailExists(employee.Email)).Returns(false);
            _mockEmployeesrepository.Setup(repo => repo.AddEntity(employee)).Returns(false);

            // Act
            string employeeDetails = _employeeOptions.AddNewEmployee(employee);
            string expected = "An error occured, employee was not added";

            // Assert
            Assert.IsTrue(employeeDetails.Contains(expected));
        }

        [Test]
        public void _21Test_UpdateEmployee_ExpectedOccurOnce_WhenUpdatingEmployeeCorrectly()
        {
            // Arrange
            var employee = new Employee { EmployeeID = 3, FirstName = "Jack", Surname = "Harrison", Email = "Harrionj01@gmail.com", Username = "Harrison01", Address = "230 West street, 4001", PhoneNumber = "0675647385", Role = "Employee" };
            _mockEmployeesrepository.Setup(repo => repo.CheckIfIdExists(employee.EmployeeID)).Returns(true);
            _mockEmployeesrepository.Setup(repo => repo.UpdateEntity(employee)).Returns(true);

            // Act
            string employeeDetails = _employeeOptions.UpdateEmployee(employee);

            // Assert
            _mockEmployeesrepository.Verify(c => c.UpdateEntity(employee), Times.Once);
            
        }

        [Test]
        public void _22Test_UpdateEmployee_ExpectedSuccessMessage_WhenUpdatingEmployeeCorrectly()
        {
            // Arrange
            var employee = new Employee { EmployeeID = 3, FirstName = "Jack", Surname = "Harrison", Email = "Harrionj01@gmail.com", Username = "Harrison01", Address = "230 West street, 4001", PhoneNumber = "0675647385", Role = "Employee" };
            _mockEmployeesrepository.Setup(repo => repo.CheckIfIdExists(employee.EmployeeID)).Returns(true);
            _mockEmployeesrepository.Setup(repo => repo.UpdateEntity(employee)).Returns(true);

            // Act
            string employeeDetails = _employeeOptions.UpdateEmployee(employee);
            string expected = "Employee has been updated";

            // Assert
            Assert.IsTrue(employeeDetails.Contains(expected));
        }

        [Test]
        public void _23Test_UpdateEmployee_ExpectedNeverOccur_WhenUpdatingEmployeeIdNotFound()
        {
            // Arrange
            var employee = new Employee { EmployeeID = 3, FirstName = "Jack", Surname = "Harrison", Email = "Harrionj01@gmail.com", Username = "Harrison01", Address = "230 West street, 4001", PhoneNumber = "0675647385", Role = "Employee" };
            _mockEmployeesrepository.Setup(repo => repo.CheckIfIdExists(employee.EmployeeID)).Returns(false);
            _mockEmployeesrepository.Setup(repo => repo.UpdateEntity(employee)).Returns(false);

            // Act
            string employeeDetails = _employeeOptions.UpdateEmployee(employee);

            // Assert
            _mockEmployeesrepository.Verify(c => c.UpdateEntity(employee), Times.Never);
        }

        [Test]
        public void _24Test_UpdateEmployee_ExpectedDoNotExist_WhenUpdatingEmployeeIDNotFound()
        {
            // Arrange
            var employee = new Employee { EmployeeID = 3, FirstName = "Jack", Surname = "Harrison", Email = "Harrionj01@gmail.com", Username = "Harrison01", Address = "230 West street, 4001", PhoneNumber = "0675647385", Role = "Employee" };
            _mockEmployeesrepository.Setup(repo => repo.CheckIfIdExists(employee.EmployeeID)).Returns(false);
            _mockEmployeesrepository.Setup(repo => repo.UpdateEntity(employee)).Returns(false);

            // Act
            string employeeDetails = _employeeOptions.UpdateEmployee(employee);
            string expected = "Employee does not exist";

            // Assert
            Assert.IsTrue(employeeDetails.Contains(expected));
        }

        [Test]
        public void _25Test_UpdateEmployee_ExpectedErrorOccured_WhenUpdatingEmployeeDoesNotExist()
        {
            // Arrange
            var employee = new Employee { EmployeeID = 3, FirstName = "Jack", Surname = "Harrison", Email = "Harrionj01@gmail.com", Username = "Harrison01", Address = "230 West street, 4001", PhoneNumber = "0675647385", Role = "Employee" };
            _mockEmployeesrepository.Setup(repo => repo.CheckIfIdExists(employee.EmployeeID)).Returns(true);
            _mockEmployeesrepository.Setup(repo => repo.UpdateEntity(employee)).Returns(false);

            // Act
            string employeeDetails = _employeeOptions.UpdateEmployee(employee);
            string expected = "Error Occured, Employee was not updated";

            // Assert
            Assert.IsTrue(employeeDetails.Contains(expected));
        }

        [Test]
        public void _26Test_RemoveEmployee_ExpectedOccurOnce_WhenUpdatingEmployeeCorrectly()
        {
            // Arrange
            var employee = new Employee { EmployeeID = 3, FirstName = "Jack", Surname = "Harrison", Email = "Harrionj01@gmail.com", Username = "Harrison01", Address = "230 West street, 4001", PhoneNumber = "0675647385", Role = "Employee" };
            _mockEmployeesrepository.Setup(repo => repo.CheckIfIdExists(employee.EmployeeID)).Returns(true);
            _mockEmployeesrepository.Setup(repo => repo.DeleteRow(employee.EmployeeID)).Returns(true);

            // Act
            string employeeDetails = _employeeOptions.RemoveEmployee(employee.EmployeeID);
            

            // Assert
            _mockEmployeesrepository.Verify(c => c.DeleteRow(employee.EmployeeID), Times.Once);

        }

        [Test]
        public void _27Test_RemoveEmployee_ExpectedDeletedMessage_WhenUpdatingEmployeeCorrectly()
        {
            // Arrange
            var employee = new Employee { EmployeeID = 3, FirstName = "Jack", Surname = "Harrison", Email = "Harrionj01@gmail.com", Username = "Harrison01", Address = "230 West street, 4001", PhoneNumber = "0675647385", Role = "Employee" };
            _mockEmployeesrepository.Setup(repo => repo.CheckIfIdExists(employee.EmployeeID)).Returns(true);
            _mockEmployeesrepository.Setup(repo => repo.DeleteRow(employee.EmployeeID)).Returns(true);

            // Act
            string employeeDetails = _employeeOptions.RemoveEmployee(employee.EmployeeID);
            string expected = "Employee has been deleted";

            // Assert
            Assert.IsTrue(employeeDetails.Contains(expected));
        }

        [Test]
        public void _28Test_RemoveEmployee_ExpectedNeverOccur_WhenUpdatingEmployeeIdNotFound()
        {
            // Arrange
            var employee = new Employee { EmployeeID = 3, FirstName = "Jack", Surname = "Harrison", Email = "Harrionj01@gmail.com", Username = "Harrison01", Address = "230 West street, 4001", PhoneNumber = "0675647385", Role = "Employee" };
            _mockEmployeesrepository.Setup(repo => repo.CheckIfIdExists(employee.EmployeeID)).Returns(false);
            _mockEmployeesrepository.Setup(repo => repo.DeleteRow(employee.EmployeeID)).Returns(false);

            // Act
            string employeeDetails = _employeeOptions.RemoveEmployee(employee.EmployeeID);

            // Assert
            _mockEmployeesrepository.Verify(c => c.DeleteRow(employee.EmployeeID), Times.Never);
        }

        [Test]
        public void _29Test_RemoveEmployee_ExpectedDoNotExist_WhenUpdatingEmployeeIDNotFound()
        {
            // Arrange
            var employee = new Employee { EmployeeID = 3, FirstName = "Jack", Surname = "Harrison", Email = "Harrionj01@gmail.com", Username = "Harrison01", Address = "230 West street, 4001", PhoneNumber = "0675647385", Role = "Employee" };
            _mockEmployeesrepository.Setup(repo => repo.CheckIfIdExists(employee.EmployeeID)).Returns(false);
            _mockEmployeesrepository.Setup(repo => repo.DeleteRow(employee.EmployeeID)).Returns(false);

            // Act
            string employeeDetails = _employeeOptions.RemoveEmployee(employee.EmployeeID);
            string expected = "Employee ID does not exist";

            // Assert
            Assert.IsTrue(employeeDetails.Contains(expected));
        }

        [Test]
        public void _30Test_RemoveEmployee_ExpectedErrorOccured_WhenUpdatingEmployeeDoesNotExist()
        {
            // Arrange
            var employee = new Employee { EmployeeID = 3, FirstName = "Jack", Surname = "Harrison", Email = "Harrionj01@gmail.com", Username = "Harrison01", Address = "230 West street, 4001", PhoneNumber = "0675647385", Role = "Employee" };
            _mockEmployeesrepository.Setup(repo => repo.CheckIfIdExists(employee.EmployeeID)).Returns(true);
            _mockEmployeesrepository.Setup(repo => repo.DeleteRow(employee.EmployeeID)).Returns(false);

            // Act
            string employeeDetails = _employeeOptions.RemoveEmployee(employee.EmployeeID);
            string expected = "Error Occured, Employee not removed";

            // Assert
            Assert.IsTrue(employeeDetails.Contains(expected));
        }

        [Test]
        public void _31Test_FindEmployeeByID_ExpectedThrowsException_WhenReadRowByIDThrowsNullException()
        {
            // Arrange
            int employeeId = 1;


            // Act
            _mockEmployeesrepository.Setup(repo => repo.CheckIfIdExists(employeeId)).Returns(true);
            _mockEmployeesrepository.Setup(repo => repo.ReadRowByID(employeeId)).Throws(new NullReferenceException());

            // Assert
            Assert.Throws<NullReferenceException>(() => _employeeOptions.FindEmployeeByID(employeeId));
        }

        [Test]
        public void _32Test_FindEmployeeByID_ExpectedDoesNotThrowException_WhenCheckIfIdExistsIsFalse()
        {
            // Arrange
            int employeeId = 11;


            // Act
            _mockEmployeesrepository.Setup(repo => repo.CheckIfIdExists(employeeId)).Returns(false);
            _mockEmployeesrepository.Setup(repo => repo.ReadRowByID(employeeId)).Throws(new NullReferenceException());

            // Assert
            Assert.DoesNotThrow(() => _employeeOptions.FindEmployeeByID(employeeId));
        }

    }
}
