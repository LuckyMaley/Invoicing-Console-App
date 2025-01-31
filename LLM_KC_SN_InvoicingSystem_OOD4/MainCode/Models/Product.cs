using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCode.Models
{
    /// <summary>
    /// This is a Product model which containsthe properties of the product and the disvount dataset.
    /// 
    /// The properties include ProductID,ProductName ,StockQuantity,Price,Description.
    /// The Product  dataset includes a list of 10 product dataset.
    /// </summary>
    public class Product
    {
        public int ProductID {  get; set; }
        public string ProductName {  get; set; }
        public int StockQuantity {  get; set; }
        public Decimal Price{  get; set; }
        public string Description {  get; set; }

        public static List<Product> ProductsDataSet = new List<Product>()
        {
           new Product() { ProductID = 1,ProductName="Laptop", StockQuantity=50,Price=899.99M,Description="Full HD, Intel Core i5, 8GB RAM, 512GB SSD" },
           new Product() { ProductID = 2,ProductName="Smartphone", StockQuantity=100,Price=899.99M,Description="6.5 AMOLED Display, Snapdragon 888, 128GB, 5G" },
           new Product() { ProductID = 3,ProductName="Smartwatch", StockQuantity=80,Price=899.99M,Description="Waterproof Fitness Tracker, Heart Rate Monitor" },
           new Product() { ProductID = 4,ProductName="Headphones", StockQuantity=150,Price=899.99M,Description="Wireless Over-Ear Headphones, Active Noise Cancellation" },
           new Product() { ProductID = 5,ProductName="Tablet", StockQuantity=70,Price=899.99M,Description="Retina Display, A13 Bionic Chip, 256GB" },
           new Product() { ProductID = 6,ProductName="Computer", StockQuantity=150,Price=1099.99M,Description="QHD Monitor, Intel Core i7, 16GB RAM, 1TB SSD" },
           new Product() { ProductID = 7,ProductName="Gaming Console", StockQuantity=30,Price=499.99M,Description="4K HDR, 1TB Storage, DualSense Wireless Controller" },
           new Product() { ProductID = 8,ProductName="Wireless Router", StockQuantity=90,Price=79.99M,Description="Dual-Band Gigabit Wi-Fi Router, Parental Controls" },
           new Product() { ProductID = 9,ProductName="External Hard Drive", StockQuantity=520,Price=129.99M,Description="2TB Portable USB 3.0 External HDD, Backup Solution" },
           new Product() { ProductID = 10,ProductName="Wireless Mouse", StockQuantity=200,Price=29.99M,Description="Ergonomic Design, Silent Click, USB Receiver" },
        };
    }
}

 