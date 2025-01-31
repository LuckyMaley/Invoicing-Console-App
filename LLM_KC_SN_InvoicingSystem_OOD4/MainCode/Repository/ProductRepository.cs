using MainCode.Models;
using MainCode.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCode.Repository
{

    /// <summary>
    ///  A summary about ProductRepository Class
    ///  </summary>
    /// <remarks>
    ///  These remarks explain more about the ProductRepository class and methods 
    ///  public virtual List&lt;Product&gt; ReadGetAllRows()
    ///  This method clones the product from the predefines list products to allproducts
    ///  <returns>
    ///  this method returns the list containing all products with variable name products
    ///  </returns> 
    ///  </remarks>
    public class ProductRepository : RepositoryBase<Product>, IRepository<Product>
    {
        private static List<Product> allProducts;
        public ProductRepository()
        {
            allProducts = ReadGetAllRows();
        }
        public virtual List<Product> ReadGetAllRows()
        {
            allProducts = new List<Product>();
            foreach(var product in Product.ProductsDataSet)
            {
                allProducts.Add(new Product()
                {
                    ProductID = product.ProductID,
                    ProductName = product.ProductName,
                    StockQuantity = product.StockQuantity,
                    Price = product.Price,
                    Description = product.Description,

                });
            }
            return allProducts;
        }

        public void SetDS(List<Product> products)
        {
            allProducts = products;
            Product.ProductsDataSet = allProducts;
        }

        public override bool AddEntity(Product entity)
        {
            MainCodeStaticObjects.loggerMainCode.Info("Adding Product");
            bool returnVal = false;
            try
            {
                Product.ProductsDataSet.Add(entity);
                returnVal = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error, cannot add Product" + ex.ToString());
                MainCodeStaticObjects.loggerMainCode.Error("Error, cannot add Product");
            }
            return returnVal;
        }

        public override bool DeleteRow(int id)
        {
            MainCodeStaticObjects.loggerMainCode.Info("Adding Product");
            bool returnVal = false;
            try
            {
                var ds = allProducts.FirstOrDefault(c => c.ProductID == id);
                if (ds != null)
                {
                    allProducts.RemoveAll(c => c.ProductID == id);
                    Product.ProductsDataSet.RemoveAll(c => c.ProductID == id);
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error, cannot delete Product" + ex.ToString());
                MainCodeStaticObjects.loggerMainCode.Error("Error, cannot add Product");
            }

            return returnVal;
        }

        public override bool UpdateEntity(Product entity)
        {
            MainCodeStaticObjects.loggerMainCode.Info("Adding Product");
            bool returnVal = false;
            try
            {
                var product = Product.ProductsDataSet.FirstOrDefault(a => a.ProductID == entity.ProductID);
                product.ProductID=entity.ProductID;
                product.ProductName=entity.ProductName;
                product.StockQuantity=entity.StockQuantity;
                product.Price=entity.Price;
                product.Description=entity.Description;
                returnVal = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error, cannot update Product" + ex.ToString());
                MainCodeStaticObjects.loggerMainCode.Error("Error, cannot add Product");
            }

            return returnVal;
        }

        public virtual bool CheckIfIdExists(int id)
        {
            ProductRepository prodRepository = new ProductRepository();
            List<Product> allOfTheProducts = prodRepository.ReadGetAllRows();
            int count = 0;
            foreach (var product in allOfTheProducts)
            {
                if (product.ProductID == id)
                {
                    count++;
                }
            }
            bool result = count > 0 ? true : false;
            return result;
        }

        public  virtual Product ReadRowByID(int id)
        {
            ProductRepository prodRepository = new ProductRepository();
            List<Product> allOfTheProducts = prodRepository.ReadGetAllRows();
            Product product = allOfTheProducts.FirstOrDefault(c => c.ProductID == id);
            return product;
        }

        public virtual  Queue<Product> GetProductByName(string name)
        {
            ProductRepository productsRepository = new ProductRepository();
            var prodlist = productsRepository.ReadGetAllRows();
            var products = new Queue<Product>();
            var productslistDesc = prodlist.Where(c => c.ProductName == name).OrderByDescending(c => c.ProductID);
            foreach (var prod in productslistDesc)
            {
                products.Enqueue(prod);
            }
            return products;
        }


    }

}
