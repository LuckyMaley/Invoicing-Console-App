using MainCode;
using MainCode.Models;
using MainCode.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCode.Repository.EmployeeOptions
{
    public class ProductOptions
    {
        private ProductRepository productsRepository;
        private RepositoryBase<Product> productsRepositoryBase;
        public ProductOptions(ProductRepository _productsRepository, RepositoryBase<Product> _productsRepositoryBase)
        {
            productsRepository = _productsRepository;
            productsRepositoryBase = _productsRepositoryBase;
        }

        public virtual string  FindProductByID(int prodID)
        {
            StringBuilder sb = new StringBuilder();
            
            bool valid = productsRepository.CheckIfIdExists(prodID);
            if (valid)
            {
                var product = productsRepository.ReadRowByID(prodID);
                CultureInfo ci = new CultureInfo("en-za");
                sb.AppendLine($"ID: {product.ProductID}, Name: {product.ProductName}, Description: {product.Description}, Price: {product.Price.ToString("C", ci)}, Quantity: {product.StockQuantity}");
            }
            else
            {
                sb.AppendLine("Product does not exist, Please try again");
            }
            return sb.ToString();
        }

        public string FindProductByName(string prodName)
        {
            CultureInfo ci = new CultureInfo("en-za");
            

            StringBuilder stringBuilder = new StringBuilder();
            Queue<Product> products = productsRepository.GetProductByName(prodName);
            if (products.Count > 0)
            {
                while (products.Count != 0)
                {
                    var product = products.Dequeue();
                    stringBuilder.AppendLine($"ID: {product.ProductID}, Name: {product.ProductName}, Description: {product.Description}, Price: {product.Price.ToString("C", ci)}, Quantity: {product.StockQuantity}");
                }
            }
            else
            {
                stringBuilder.AppendLine("No product with that name exists");
            }
            return stringBuilder.ToString();
        }


        public string AddNewProduct(Product product)
        {
            StringBuilder sb = new StringBuilder();
            bool resultVal = productsRepository.AddEntity(product);
            if (resultVal)
            {
                sb.AppendLine("Product has been added");
                productsRepository.ReadGetAllRows();
            }
            
            return sb.ToString();
        }

        public string UpdateProduct(Product product)
        {
            StringBuilder sb = new StringBuilder();
            
            bool result = productsRepository.UpdateEntity(product);
            if (result)
            {
                productsRepository.ReadGetAllRows();
                sb.AppendLine("Product has been updated");
            }
                                
            return sb.ToString();
        }

        public string RemoveProduct(int prodId)
        {
            StringBuilder stringBuilder = new StringBuilder();
            
            bool result = productsRepository.DeleteRow(prodId);
            if (result)
            {
                stringBuilder.AppendLine("Product has been deleted");
                productsRepository.ReadGetAllRows();
            }
                                
            return stringBuilder.ToString();
        }
    }
}
