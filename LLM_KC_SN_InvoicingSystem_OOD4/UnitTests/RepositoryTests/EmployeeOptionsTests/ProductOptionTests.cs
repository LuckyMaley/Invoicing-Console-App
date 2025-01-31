
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
using System.Diagnostics;

namespace UnitTests.RepositoryTests.EmployeeOptionsTests
{
    [TestFixture]
    public class ProductOptionsTests
    {
        Mock<ProductRepository> _mockProductsrepository;
        Mock<RepositoryBase<Product>> _mockProductrepositoryBase;
        Mock<IRepository<Product>> _mockProductsIRepository;
        ProductOptions _ProductOptions;
        [SetUp]
        public void SetUp()
        {
            _mockProductsrepository = new Mock<ProductRepository>();
            _mockProductrepositoryBase = new Mock<RepositoryBase<Product>>();
            _mockProductsIRepository = new Mock<IRepository<Product>>();
            _ProductOptions = new ProductOptions(_mockProductsrepository.Object, _mockProductrepositoryBase.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockProductsrepository = null;
            _mockProductrepositoryBase = null;
            _mockProductsIRepository = null;
            _ProductOptions = null;
        }


        [Test]
        public void _01Test_FindProductByID_ExpectedReadRowByIDNeverOccurs_WhenProductIDDoesNotExist()
        {
            // Arrange
            int ProductId = 11;
            var Product = new Product { ProductID = 1, ProductName = "Laptop", StockQuantity = 50, Price = 899.99M, Description = "Full HD, Intel Core i5, 8GB RAM, 512GB SSD" };
            _mockProductsrepository.Setup(repo => repo.CheckIfIdExists(ProductId)).Returns(false);
            _mockProductsrepository.Setup(repo => repo.ReadRowByID(ProductId)).Returns(Product);


            // Act
            string ProductDetails = _ProductOptions.FindProductByID(ProductId);

            // Assert
            _mockProductsrepository.Verify(c => c.ReadRowByID(ProductId), Times.Never);
        }


        [Test]
        public void _02Test_FindProductByID_ExpectedTrue_WhenProductDetailExist()

        {
            // Arrange
            int ProductId = 3;
            var Product = new Product { ProductID = 1, ProductName = "Laptop", StockQuantity = 50, Price = 899.99M, Description = "Full HD, Intel Core i5, 8GB RAM, 512GB SSD" };
            _mockProductsrepository.Setup(repo => repo.CheckIfIdExists(ProductId)).Returns(true);
            _mockProductsrepository.Setup(repo => repo.ReadRowByID(ProductId)).Returns(Product);

            // Act
            string ProductDetails = _ProductOptions.FindProductByID(ProductId);

            // Assert
            _mockProductsrepository.Verify(c => c.CheckIfIdExists(ProductId), Times.Once);

        }
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        public void _03Test_FindProductByID_ExpectedTrue_WhenProductDetailExist(int ProductId)

        {
            // Arrange

            var Product = new Product { ProductID = 1, ProductName = "Laptop", StockQuantity = 50, Price = 899.99M, Description = "Full HD, Intel Core i5, 8GB RAM, 512GB SSD" };
            _mockProductsrepository.Setup(repo => repo.CheckIfIdExists(ProductId)).Returns(true);
            _mockProductsrepository.Setup(repo => repo.ReadRowByID(ProductId)).Returns(Product);

            // Act
            string ProductDetails = _ProductOptions.FindProductByID(ProductId);

            // Assert
            _mockProductsrepository.Verify(c => c.CheckIfIdExists(ProductId), Times.Once);

        }

        [TestCase(1)]
        [TestCase(10)]
        [TestCase(4)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        public void _04Test_FindProductByID_ExpectedTrue_WhenProductDetailExist(int ProductId)

        {
            // Arrange
            var Product = new Product { ProductID = 1, ProductName = "Laptop", StockQuantity = 50, Price = 899.99M, Description = "Full HD, Intel Core i5, 8GB RAM, 512GB SSD" };
            _mockProductsrepository.Setup(repo => repo.CheckIfIdExists(ProductId)).Returns(true);
            _mockProductsrepository.Setup(repo => repo.ReadRowByID(ProductId)).Returns(Product);

            // Act
            string ProductDetails = _ProductOptions.FindProductByID(ProductId);

            // Assert
            _mockProductsrepository.Verify(c => c.CheckIfIdExists(ProductId), Times.Once);

        }

        [Test]
        public void _05Test_FindProductByID_ExpectedTrue_WhenProductDetailDoesExist()
        {
            // Arrange
            int ProductId = 3;
            var Product = new Product { ProductID = 1, ProductName = "Laptop", StockQuantity = 50, Price = 899.99M, Description = "Full HD, Intel Core i5, 8GB RAM, 512GB SSD" };
            _mockProductsrepository.Setup(repo => repo.CheckIfIdExists(ProductId)).Returns(true);
            _mockProductsrepository.Setup(repo => repo.ReadRowByID(ProductId)).Returns(Product);

            // Act
            string ProductDetails = _ProductOptions.FindProductByID(ProductId);

            // Assert
            _mockProductsrepository.Verify(c => c.ReadRowByID(ProductId), Times.Once);
        }

        [Test]
        public void _06Test_FindProductByID_Expectedfalse_WhenProductDetailDoesExist()
        {
            // Arrange
            int ProductId = 3;
            var Product = new Product { ProductID = 1, ProductName = "Laptop", StockQuantity = 50, Price = 899.99M, Description = "Full HD, Intel Core i5, 8GB RAM, 512GB SSD" };
            _mockProductsrepository.Setup(repo => repo.CheckIfIdExists(ProductId)).Returns(false);
            _mockProductsrepository.Setup(repo => repo.ReadRowByID(ProductId)).Returns(Product);

            // Act
            string ProductDetails = _ProductOptions.FindProductByID(ProductId);

            // Assert
            _mockProductsrepository.Verify(c => c.ReadRowByID(ProductId), Times.Never);
        }

        [Test]

        public void _07Test_FindProductByID_ExpectedTrue_WhenProductDetailExist()
        {
            // Arrange
            int ProductId = 3;
            var Product = new Product { ProductID = 1, ProductName = "Laptop", StockQuantity = 50, Price = 899.99M, Description = "Full HD, Intel Core i5, 8GB RAM, 512GB SSD" };
            _mockProductsrepository.Setup(repo => repo.CheckIfIdExists(ProductId)).Returns(true);
            _mockProductsrepository.Setup(repo => repo.ReadRowByID(ProductId)).Returns(Product);

            // Act
            string ProductDetails = _ProductOptions.FindProductByID(ProductId);

            // Assert
            Assert.IsTrue(ProductDetails.Contains(Product.ProductID.ToString()));
            Assert.IsTrue(ProductDetails.Contains(Product.ProductName));

        }

        [TestCase(1)]
        [TestCase(6)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(4)]
        [TestCase(5)]
        public void _08Test_FindProductByID_ExpectedTrue_WhenProductDetailExist(int ProductId)
        {
            // Arrange
            var Product = new Product { ProductID = 1, ProductName = "Laptop", StockQuantity = 50, Price = 899.99M, Description = "Full HD, Intel Core i5, 8GB RAM, 512GB SSD" };
            _mockProductsrepository.Setup(repo => repo.CheckIfIdExists(ProductId)).Returns(true);
            _mockProductsrepository.Setup(repo => repo.ReadRowByID(ProductId)).Returns(Product);

            // Act
            string ProductDetails = _ProductOptions.FindProductByID(ProductId);

            // Assert
            Assert.IsTrue(ProductDetails.Contains(Product.ProductID.ToString()));
            Assert.IsTrue(ProductDetails.Contains(Product.ProductName));

        }

        [Test]
        public void _09Test_FindProductByName_ExpectedFalse_WhenProductDetailDoesExist()
        {
            // Arrange
            string ProductName = "Jack";
            var Product = new Product { ProductID = 1, ProductName = "Laptop", StockQuantity = 50, Price = 899.99M, Description = "Full HD, Intel Core i5, 8GB RAM, 512GB SSD" };
            var ProductTwo = new Product { ProductID = 1, ProductName = "Laptop", StockQuantity = 50, Price = 899.99M, Description = "Full HD, Intel Core i5, 8GB RAM, 512GB SSD" };
            Queue<Product> stackProducts = new Queue<Product>();
            List<Product> list = new List<Product>();
            list.Add(Product);
            list.Add(ProductTwo);
            foreach (var cus in list.Where(c => c.ProductName == ProductName).OrderByDescending(c => c.ProductID).ToList())
            {
                stackProducts.Enqueue(cus);
            }
            _mockProductsrepository.Setup(repo => repo.GetProductByName(ProductName)).Returns(stackProducts);

            // Act
            string ProductDetails = _ProductOptions.FindProductByName(ProductName);
            string expected = "No Product with that first name exists";

            // Assert
            Assert.IsFalse(ProductDetails.Contains(expected));
        }


        [Test]
        public void _10Test_FindProductByName_ExpectedTrue_WhenProductDetailDoesNotExist()
        {
            // Arrange
            string ProductName = "Lap";
            var Product = new Product { ProductID = 1, ProductName = "Laptop", StockQuantity = 50, Price = 899.99M, Description = "Full HD, Intel Core i5, 8GB RAM, 512GB SSD" };
            var ProductTwo = new Product { ProductID = 1, ProductName = "Laptop", StockQuantity = 50, Price = 899.99M, Description = "Full HD, Intel Core i5, 8GB RAM, 512GB SSD" };
            Queue<Product> stackProducts = new Queue<Product>();
            List<Product> list = new List<Product>();
            list.Add(Product);
            list.Add(ProductTwo);
            foreach (var cus in list.Where(c => c.ProductName == ProductName).OrderByDescending(c => c.ProductID).ToList())
            {
                stackProducts.Enqueue(cus);
            }
            _mockProductsrepository.Setup(repo => repo.GetProductByName(ProductName)).Returns(stackProducts);

            // Act
            string ProductDetails = _ProductOptions.FindProductByName(ProductName);
            string expected = "No product with that name exists";

            // Assert
            Assert.IsTrue(ProductDetails.Contains(expected));
        }

        [Test]
        public void _11Test_AddNewProduct_ExpectedAddOccurOnce_WhenProductDetailCorrectAndIDDoesNotexist()
        {
            // Arrange
            int ProductId = 1;
            var Product = new Product { ProductID = 1, ProductName = "Laptop", StockQuantity = 50, Price = 899.99M, Description = "Full HD, Intel Core i5, 8GB RAM, 512GB SSD" };
            _mockProductsrepository.Setup(repo => repo.CheckIfIdExists(ProductId)).Returns(false);
            _mockProductsrepository.Setup(repo => repo.AddEntity(Product)).Returns(true);

            // Act
            string ProductDetails = _ProductOptions.AddNewProduct(Product);

            // Assert
            _mockProductsrepository.Verify(c => c.AddEntity(Product), Times.Once);
        }

        [Test]
        public void _12Test_AddNewProduct_ExpectedSuccessMessage_WhenProductDetailCorrectAndIDDoesNotAlreadyExist()
        {
            // Arrange
            var Product = new Product { ProductID = 151, ProductName = "Laptop", StockQuantity = 50, Price = 899.99M, Description = "Full HD, Intel Core i5, 8GB RAM, 512GB SSD" };
            _mockProductsrepository.Setup(repo => repo.CheckIfIdExists(Product.ProductID)).Returns(false);
            _mockProductsrepository.Setup(repo => repo.AddEntity(Product)).Returns(true);

            // Act
            string ProductDetails = _ProductOptions.AddNewProduct(Product);
            string expected = "Product has been added";

            // Assert
            Assert.IsTrue(ProductDetails.Contains(expected));
        }


        [TestCase(1425, "Wireless", 755, 5.25, "Full HD, Intel Core i5, 8GB RAM, 512GB SSD")]
        [TestCase(125, "Wireless mouse", 85, 475.25, "Full HD, Intel Core i5, 8GB RAM, 512GB SSD")]
        [TestCase(25, "Tablet", 485, 475.25, "Full HD, Intel Core i5, 8GB RAM, 512GB SSD")]
        [TestCase(15, "Iphone", 485, 75.25, "Full HD, Intel Core i5, 8GB RAM, 512GB SSD")]
        [TestCase(51, "wireless gaming", 125, 45.25, "Full HD, Intel Core i5, 8GB RAM, 512GB SSD")]
        public void _13Test_AddNewProduct_ExpectedSuccessMessage_WhenProductDetailCorrectAndIDDoesNotAlreadyExist(int productID, string productName, int stockQuantity, Decimal price, string description)
        {
            // Arrange
            var Product = new Product { ProductID = productID, ProductName = productName, StockQuantity = stockQuantity, Price = price, Description = description };
            _mockProductsrepository.Setup(repo => repo.CheckIfIdExists(Product.ProductID)).Returns(false);
            _mockProductsrepository.Setup(repo => repo.AddEntity(Product)).Returns(true);

            // Act
            string ProductDetails = _ProductOptions.AddNewProduct(Product);
            string expected = "Product has been added";

            // Assert
            Assert.IsTrue(ProductDetails.Contains(expected));
        }

        [Test]
        public void _14Test_UpdateProduct_ExpectedOccurOnce_WhenUpdatingProductCorrectly()
        {
            // Arrange
            var Product = new Product { ProductID = 1, ProductName = "Laptop", StockQuantity = 50, Price = 899.99M, Description = "Full HD, Intel Core i5, 8GB RAM, 512GB SSD" };
            _mockProductsrepository.Setup(repo => repo.CheckIfIdExists(Product.ProductID)).Returns(true);
            _mockProductsrepository.Setup(repo => repo.UpdateEntity(Product)).Returns(true);

            // Act
            string ProductDetails = _ProductOptions.UpdateProduct(Product);

            // Assert
            _mockProductsrepository.Verify(c => c.UpdateEntity(Product), Times.Once);

        }

    }
}


