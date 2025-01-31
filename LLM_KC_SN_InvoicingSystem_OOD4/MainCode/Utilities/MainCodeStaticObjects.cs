using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Repository.Hierarchy;



[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]

namespace MainCode.Utilities
{
    /// <summary>
    ///  A summary about MainCodeStaticObjects Class
    ///  </summary>
    /// <remarks>
    ///  These remarks explain more about the MainCodeStaticObjects class and methods 
    ///  
    /// public struct Person
    /// This struct defines the person that has logged on to the system.
    /// It includes the person's details such as id, firstName, surname, passwordHash, salt, and encryptionType.
    /// 
    /// Person person
    /// This is a person object that is used when initialising a new Person.  
    /// 
    ///  </remarks>
    public class MainCodeStaticObjects
    {
        public static readonly ILog loggerMainCode = LogManager.GetLogger("MainCode methods");
        public struct Person
        {
            private static int id;
            private static string firstName;
            private static string surname;
            private static string username;
            private static string passwordHash;
            private static string salt;
            private static string encryptionType;

            public static int Id
            {
                get { return id; }
                set { id = value; }
            }

            public static string FirstName
            {
                get { return firstName; }
                set { firstName = value; }
            }

            public static string Surname
            {
                get { return surname; }
                set { surname = value; }
            }

            public static string UserNname
            {
                get { return username; }
                set { username = value; }
            }

            public static string PasswordHash
            {
                get { return passwordHash; }
                set { passwordHash = value; }
            }

            public static string Salt
            {
                get { return salt; }
                set { salt = value; }
            }
            public static string EncryptionType
            {
                get { return encryptionType; }
                set { encryptionType = value; }
            }

            public Person(int id, string fName, string lName, string userName, string passHash, string saltType, string encType)
            {
                Id = id;
                FirstName = fName;
                Surname = lName;
                UserNname = userName;
                PasswordHash = passHash;
                Salt = saltType;
                EncryptionType = encType;
            }

            public static void GetDetails() => Console.WriteLine($"User Logged in: {FirstName} {Surname}");
        }

        public static Person person;
    }
}
