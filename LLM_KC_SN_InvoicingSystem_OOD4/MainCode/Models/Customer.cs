using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCode.Models
{
    /// <summary>
    /// This is a Customer model which contains the properties of the customer and the customer dataset.
    /// 
    /// The properties include Customer ID, FirstName, Surname, Email, Username, PasswordHash, Salt, EncryptionType, Address, PhoneNumber.
    /// The customer dataset includes a list of 10 customer records.
    /// </summary>
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string EncrytionType { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public static List<Customer> CustomersDataSet = new List<Customer>()
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
}
