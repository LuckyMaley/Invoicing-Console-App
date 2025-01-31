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
    public class EmployeeRepositoryTests
    {
        EmployeeRepository repository;
        List<Employee> employeeList;
        List<Employee> empDS;

        [SetUp]
        public void init()
        {
            repository = new EmployeeRepository();
            employeeList = new List<Employee>();
            empDS = new List<Employee> 
            {
                new Employee{EmployeeID = 121332,  FirstName="Zandile", Surname ="Zimela", Email="Zzimela@gmail.com", Username="Zzimela", PasswordHash = "8f86f5ead3a5c29a3d9e62f65922b2b11799a7b85e6b1cfcd6f6d3e734eab07d", Salt = "salt", EncrytionType = "sha256", Address = "25 Zuma avenue, 2001", PhoneNumber = "074396748", Role = "Manager"},
                new Employee{EmployeeID = 200000, FirstName = "Elga", Surname="Cantopher", Email ="ecantopher0@biblegateway.com", Username ="ecantopher0", PasswordHash="$2a$04$CxZLWn1raGDTrWpkxy9zNO7DKkYGhU1/yENALdyuZ9e8vucevKwvi",Salt = "salt", EncrytionType="sha256", Address="8 Merchant Point", PhoneNumber ="689-657-2674", Role="Chief Design Engineer" },
                new Employee{EmployeeID = 210000, FirstName = "Gasparo", Surname="Turpin", Email ="gturpin1@si.edu", Username ="gturpin1", PasswordHash="$2a$04$bn7TzRHspIDmD8ayT1LeM.0fIX.hdTPOOn7mxDR6EZaK0Iy2YWI9y",Salt = "salt", EncrytionType="sha256", Address="24 Amoth Street", PhoneNumber ="196-950-8155", Role="Analyst" },
                new Employee{EmployeeID = 220000, FirstName = "Harlin", Surname="Venny", Email ="hvenny2@hao123.com", Username ="hvenny2", PasswordHash="$2a$04$Hby0lq0yszo.Qeg6TZGlwOUEG0IHL768yAsw0dFZiAit31O7rERM6",Salt = "salt", EncrytionType="sha256", Address="290571 Sunbrook Alley", PhoneNumber ="196-950-8155", Role="Designer" },
                new Employee{EmployeeID = 230000, FirstName = "Roshelle", Surname="Maiden", Email ="rmaiden3@vimeo.com", Username ="rmaiden3", PasswordHash="$2a$04$S/ZS4NLsgTwL29deXACUsOdGuLI1EB/KAv4IyidjlbivFSKkVP0Ra",Salt = "salt", EncrytionType="sha256", Address="207 Delladonna Drive", PhoneNumber ="310-145-9782", Role="Graphic Designer" },
                new Employee{EmployeeID = 240000, FirstName = "Kesley", Surname="Abatelli", Email ="kabatelli4@canalblog.com", Username ="kabatelli4", PasswordHash="$2a$04$IK0/hcwQdAKFjr91KuE3feVT.IlKlD0odhvvTHZzv7Et1Jps/tdsC",Salt = "salt", EncrytionType="sha256", Address="14 Mayer Junction", PhoneNumber ="597-725-9204", Role="Marketing Specialist" },
                new Employee{EmployeeID = 794744, FirstName = "Merridie", Surname="Bucky", Email ="mbucky5@house.gov", Username ="mbucky5", PasswordHash="$2a$04$4Vfp33faG5jVCVoAnJVypeVKqPfqnm086BmePn4zAM2H2V0zrzw3K",Salt = "salt", EncrytionType="sha256", Address="06 Paget Crossing", PhoneNumber ="597-725-9204", Role="Data Analyst" },
                new Employee{EmployeeID = 192351, FirstName = "Lawry", Surname="Purdom", Email ="lpurdom6@kickstarter.com", Username ="lpurdom6", PasswordHash="$2a$04$rLCYe1pV4MvzlNRF80j27uYxGDzLnzxRsVJ1ngqvjMWSNwL8Minp.",Salt = "salt", EncrytionType="sha256", Address="0 Prairieview Point", PhoneNumber ="866-316-2624", Role="Product Engineer" },
                new Employee{EmployeeID = 632724, FirstName = "Bekki", Surname="Chavrin", Email ="bchavrin7@gmail.com", Username ="bchavrin7", PasswordHash="$2a$04$JaCdt35igDHBmixX1ApsleRc.yYUwxCM/gmeDCLXiAzQxWhjjGrke",Salt = "salt", EncrytionType="sha256", Address="35347 Eliot Place", PhoneNumber ="405-920-9719", Role="Information Systems Manager" },
                new Employee{EmployeeID = 322829, FirstName = "Orazio", Surname="Littley", Email ="olittley8@gmail.com", Username ="olittley8", PasswordHash="$2a$04$wErmYfmMcZ1vPMkjxaqVRuKqS2mrq1cM355c6RpKrI6MUAUt/xvuG",Salt = "salt", EncrytionType="sha256", Address="5268 Division Parkway", PhoneNumber ="268-407-0285", Role="Information Systems Manager" }
            };
        }

        [TearDown]
        public void teardown()
        {
            employeeList = null;
            repository = null;
            empDS = null;

            
        }

        [Test]
        public void _01Test_ReadGetAllRows_ExpectedReturnAllemployee10_WhenReadGetAllRowsCalled()
        {
            //arrange 
            int noOfEmpExpected = 10;
            repository.SetDS(empDS);

            //Act 
            employeeList = repository.ReadGetAllRows();


            //Assert 
            Assert.AreEqual(noOfEmpExpected, employeeList.Count);
        }

        [Test]
        public void _02Test_ReadGetAllRows_ExpectedAreNotEqual_WhenReadGetAllRowsCalled()
        {
            //arrange 
            int noOfEmpExpected = 15;
            repository.SetDS(empDS);

            //Act 
            employeeList = repository.ReadGetAllRows();


            //Assert 
            Assert.AreNotEqual(noOfEmpExpected, employeeList.Count);
        }

        [Test]
        public void _03Test_ReadGetAllRows_ExpectedReturnAllemployeeTrue_WhenAdded1employee()
        {

            //arrange 
            Employee employee = new Employee { EmployeeID = 1, FirstName = " Sisanda", Surname = "Ndlovu", Email = "Nosiphondlovu@gmail.com", PasswordHash = "9b81a5d42b17f2674440e0fd17299352c4b2250a9070e49b2e800a4f1069768a", Salt = "SALT", EncrytionType = "sha256", Address = "120 crystalValleu", PhoneNumber = "0856048759" };
            bool expected = true;
            repository.SetDS(empDS);

            //act
            bool actual = repository.AddEntity(employee);

            //Assert 
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _04DeleteRow_ExpectedToReturnTrue_WhenDelete1Employee()
        {

            //arrange 
            int employeeID = 121332;
            bool expected = true;
            repository.SetDS(empDS);

            //act
            bool actual = repository.DeleteRow(employeeID);

            //Assert 
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void _05Test_ReadGetAllRows_ExpectedReadgetallrowsisEqualtoEmployeeDataSet_WhenReadGetAllRowsCalled()
        {
            //arrange 

            List<Employee> employeeDSList = new List<Employee>();
            repository.SetDS(empDS);

            //Act 
            employeeList = repository.ReadGetAllRows();
            employeeDSList = Employee.EmployeesDataSet.ToList();
            int noOfEmpExpected = employeeDSList.Count;

            //Assert 
            Assert.AreEqual(noOfEmpExpected, employeeList.Count);
        }

        [TestCase(200000)]
        [TestCase(210000)]
        [TestCase(220000)]
        [TestCase(230000)]
        [TestCase(240000)]
        public void _06DeleteRow_ExpectedToReturn9Employees_WhenDelete1Employee(int cusID)
        {

            //arrange 
            int employeeID = cusID;
            repository.SetDS(empDS);

            //act
            bool result = repository.DeleteRow(employeeID);
            int actual = repository.ReadGetAllRows().Count;
            int expected = 9;


            //Assert 
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void _07Test_ReadGetAllRows_ExpectedReadgetallrowsisEqualtoEmployeeDataSet_WhenReadGetAllRowsCalled()
        {
            //arrange 
            repository.SetDS(empDS);
            List<Employee> employeeDSList = new List<Employee>();

            //Act 
            employeeList = repository.ReadGetAllRows();
            employeeDSList = Employee.EmployeesDataSet.ToList();
            int noOfCustExpected = employeeDSList.Count;

            //Assert 
            Assert.AreEqual(noOfCustExpected, employeeList.Count);
        }

        [TestCase(200000)]
        [TestCase(210000)]
        [TestCase(220000)]
        [TestCase(230000)]
        [TestCase(240000)]
        public void _08Test_ReadRowByID_Expected1RowEachTestCase_WhenExistingCustIDIsPassedIn(int id)
        {
            //Arrange
            Employee employee = new Employee();
            repository.SetDS(empDS);

            //Act
            employee = repository.ReadRowByID(id);

            //Assert
            Assert.IsNotNull(employee);

        }

        [TestCase(200000)]
        [TestCase(210000)]
        [TestCase(220000)]
        [TestCase(230000)]
        [TestCase(240000)]
        public void _10Test_ReadRowByID_ExpectedAreTheSameEachTestCase_WhenExistingCustIDIsPassedIn(int id)
        {
            //Arrange
            Employee employeeOne = new Employee();
            Employee theSameEmployee = new Employee();
            repository.SetDS(empDS);

            //Act
            employeeOne = repository.ReadRowByID(id);
            theSameEmployee = Employee.EmployeesDataSet.FirstOrDefault(c => c.EmployeeID == id);

            //Assert
            Assert.AreEqual(employeeOne.EmployeeID, theSameEmployee.EmployeeID);

        }

        [TestCase(200000)]
        [TestCase(210000)]
        [TestCase(220000)]
        [TestCase(230000)]
        [TestCase(240000)]
        public void _11Test_CheckIfIDExists_ExpectedToReturnTrue_WhenEmployeeIDExists(int cusID)
        {

            //arrange 
            int employeeID = cusID;
            bool expected = true;
            repository.SetDS(empDS);

            //act
            bool actual = repository.CheckIfIdExists(employeeID);


            //Assert 
            Assert.AreEqual(expected, actual);
        }

        [TestCase("ecantopher0@biblegateway.com")]
        [TestCase("hvenny2@hao123.com")]
        [TestCase("mbucky5@house.gov")]
        [TestCase("kabatelli4@canalblog.com")]
        [TestCase("lpurdom6@kickstarter.com")]
        public void _12Test_CheckIfEmailExists_ExpectedToReturnTrue_WhenEmailExists(string email)
        {

            //arrange 
            string employeeEmail = email;
            bool expected = true;
            repository.SetDS(empDS);

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
        public void _13Test_CheckIfIDExists_ExpectedToReturnFalse_WhenEmployeeIDDoesNotExist(int cusID)
        {

            //arrange 
            int employeeID = cusID;
            repository.SetDS(empDS);

            //act
            bool actual = repository.CheckIfIdExists(employeeID);


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
            string employeeEmail = email;
            repository.SetDS(empDS);

            //act
            bool actual = repository.CheckIfEmailExists(employeeEmail);


            //Assert 
            Assert.IsFalse(actual);
        }

        [Test]
        public void _15Test_ReadGetAllRows_ThrowsException_WhenReadGetAllRowsCalledWithNullRepository()
        {
            // Arrange
            repository.SetDS(empDS);


            //Act
            repository = null;

            //Assert 
            Assert.Throws<NullReferenceException>(() => repository.ReadGetAllRows());
        }

        [Test]
        public void _16Test_ReadGetAllRows_ExpectedDoesNotThrowException_WhenReadGetAllRowsCalledWithRepositoryWithData()
        {
            // Arrange
            repository.SetDS(empDS);

            //Act
            repository.ReadGetAllRows();

            //Assert 
            Assert.DoesNotThrow(() => repository.ReadGetAllRows());
        }

    }
}
