using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCode.Models
{
    /// <summary>
    /// This is a Employee model which contains the properties of the employee and the employee dataset.
    /// 
    /// The properties include Employee ID, FirstName, Surname, Email, Username, PasswordHash, Salt, EncryptionType, Address, PhoneNumber, Role.
    /// The employee dataset includes a list of 10 employee records.
    /// </summary>
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string EncrytionType { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public string Role { get; set; }

        public static List<Employee> EmployeesDataSet = new List<Employee>()
        {
            new Employee{EmployeeID = 121332,  FirstName="Zandile", Surname ="Zimela", Email="Zzimela@gmail.com", Username="Zzimela", PasswordHash = "8f86f5ead3a5c29a3d9e62f65922b2b11799a7b85e6b1cfcd6f6d3e734eab07d", Salt = "salt", EncrytionType = "sha256", Address = "25 Zuma avenue, 2001", PhoneNumber = "074396748", Role = "Manager"},
            new Employee{EmployeeID = 471332, FirstName = "Elga", Surname="Cantopher", Email ="ecantopher0@biblegateway.com", Username ="ecantopher0", PasswordHash="$2a$04$CxZLWn1raGDTrWpkxy9zNO7DKkYGhU1/yENALdyuZ9e8vucevKwvi",Salt = "salt", EncrytionType="sha256", Address="8 Merchant Point", PhoneNumber ="689-657-2674", Role="Chief Design Engineer" },
            new Employee{EmployeeID = 357312, FirstName = "Gasparo", Surname="Turpin", Email ="gturpin1@si.edu", Username ="gturpin1", PasswordHash="$2a$04$bn7TzRHspIDmD8ayT1LeM.0fIX.hdTPOOn7mxDR6EZaK0Iy2YWI9y",Salt = "salt", EncrytionType="sha256", Address="24 Amoth Street", PhoneNumber ="196-950-8155", Role="Analyst" },
            new Employee{EmployeeID = 925470, FirstName = "Harlin", Surname="Venny", Email ="hvenny2@hao123.com", Username ="hvenny2", PasswordHash="$2a$04$Hby0lq0yszo.Qeg6TZGlwOUEG0IHL768yAsw0dFZiAit31O7rERM6",Salt = "salt", EncrytionType="sha256", Address="290571 Sunbrook Alley", PhoneNumber ="196-950-8155", Role="Designer" },
            new Employee{EmployeeID = 677538, FirstName = "Roshelle", Surname="Maiden", Email ="rmaiden3@vimeo.com", Username ="rmaiden3", PasswordHash="$2a$04$S/ZS4NLsgTwL29deXACUsOdGuLI1EB/KAv4IyidjlbivFSKkVP0Ra",Salt = "salt", EncrytionType="sha256", Address="207 Delladonna Drive", PhoneNumber ="310-145-9782", Role="Graphic Designer" },
            new Employee{EmployeeID = 393411, FirstName = "Kesley", Surname="Abatelli", Email ="kabatelli4@canalblog.com", Username ="kabatelli4", PasswordHash="$2a$04$IK0/hcwQdAKFjr91KuE3feVT.IlKlD0odhvvTHZzv7Et1Jps/tdsC",Salt = "salt", EncrytionType="sha256", Address="14 Mayer Junction", PhoneNumber ="597-725-9204", Role="Marketing Specialist" },
            new Employee{EmployeeID = 794744, FirstName = "Merridie", Surname="Bucky", Email ="mbucky5@house.gov", Username ="mbucky5", PasswordHash="$2a$04$4Vfp33faG5jVCVoAnJVypeVKqPfqnm086BmePn4zAM2H2V0zrzw3K",Salt = "salt", EncrytionType="sha256", Address="06 Paget Crossing", PhoneNumber ="597-725-9204", Role="Data Analyst" },
            new Employee{EmployeeID = 192351, FirstName = "Lawry", Surname="Purdom", Email ="lpurdom6@kickstarter.com", Username ="lpurdom6", PasswordHash="$2a$04$rLCYe1pV4MvzlNRF80j27uYxGDzLnzxRsVJ1ngqvjMWSNwL8Minp.",Salt = "salt", EncrytionType="sha256", Address="0 Prairieview Point", PhoneNumber ="866-316-2624", Role="Product Engineer" },
            new Employee{EmployeeID = 632724, FirstName = "Bekki", Surname="Chavrin", Email ="bchavrin7@gmail.com", Username ="bchavrin7", PasswordHash="$2a$04$JaCdt35igDHBmixX1ApsleRc.yYUwxCM/gmeDCLXiAzQxWhjjGrke",Salt = "salt", EncrytionType="sha256", Address="35347 Eliot Place", PhoneNumber ="405-920-9719", Role="Information Systems Manager" },
            new Employee{EmployeeID = 322829, FirstName = "Orazio", Surname="Littley", Email ="olittley8@gmail.com", Username ="olittley8", PasswordHash="$2a$04$wErmYfmMcZ1vPMkjxaqVRuKqS2mrq1cM355c6RpKrI6MUAUt/xvuG",Salt = "salt", EncrytionType="sha256", Address="5268 Division Parkway", PhoneNumber ="268-407-0285", Role="Information Systems Manager" }

        };
    }
}
