using MainCode.Models;
using MainCode.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCode.Repository.EmployeeOptions
{
    public class DiscountOptions
    {
        private DiscountRepository discountRepository;
        private RepositoryBase<Discount> discountRepositoryBase;
        
        public DiscountOptions(DiscountRepository _discountsRepository, RepositoryBase<Discount> _discountsRepositoryBase)
        {
            discountRepository = _discountsRepository;
            discountRepositoryBase = _discountsRepositoryBase;
            
        }

        public virtual string FindDiscountByID(int discountID)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool valid = discountRepository.CheckIfidExists(discountID);
            if (valid)
            {
                var dis = discountRepository.ReadRowByID(discountID);
                stringBuilder.AppendLine($"DiscountID: {dis.DiscountID}, DiscountName: {dis.DiscountName}, DiscountRate: {dis.Rate}, DiscountAmount: {dis.Amount}");
            }
            else
            {
                stringBuilder.AppendLine("Discount does not exist, Please try again");
            }

            return stringBuilder.ToString();
        }

        public string FindDiscountByName(string adName)
        {


            StringBuilder stringBuilder = new StringBuilder();
            List<Discount> discountList = new List<Discount>();
            discountList = Discount.DiscountsDataSet.ToList();
            var disStck = new Stack<Discount>();
            var disName = discountList.Where(a => a.DiscountName == adName).OrderByDescending(a => a.DiscountID);
            foreach (var d in disName)
            {
                disStck.Push(d);
            }
            if (disStck.Count > 0)
            {
                var dis = disStck.Pop();
                stringBuilder.AppendLine($"DiscountID: {dis.DiscountID}, DiscountName: {dis.DiscountName}, DiscountRate: {dis.Rate}, DiscountAmount: {dis.Amount}");

            }
            else
            {
                stringBuilder.AppendLine("No discount with that first name exists");
            }
            return stringBuilder.ToString();

        }

        public string AddNewDiscount(Discount discount)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (!discountRepository.CheckIfidExists(discount.DiscountID))
            {
                bool result = discountRepository.AddEntity(discount);
                if (result)
                {
                    stringBuilder.AppendLine("Discount has been added");
                    discountRepository.ReadGetAllRows();
                }
                else
                {
                    stringBuilder.AppendLine("An error occured, Discount was not added");
                }
            }
            else
            {
                stringBuilder.AppendLine("Discount  already exists");
            }

            return stringBuilder.ToString();
        }

        public string UpdateDiscount(Discount discount)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool check = discountRepository.CheckIfidExists(discount.DiscountID);
            if (check)
            {
                bool result = discountRepository.UpdateEntity(discount);
                if (result)
                {
                    discountRepository.ReadGetAllRows();
                    stringBuilder.AppendLine("Discount has been updated");
                }
                else
                {
                    stringBuilder.AppendLine("Error Occured, Discount was not updated");
                }
            }
            else
            {
                stringBuilder.AppendLine("Discount does not exist");
            }

            return stringBuilder.ToString();
        }

        public string RemoveDiscount(int discountId)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool exists = discountRepository.CheckIfidExists(discountId);
            if (exists)
            {

                bool result = discountRepository.DeleteRow(discountId);
                if (result)
                {
                    stringBuilder.AppendLine("Discount has been deleted");
                    discountRepository.ReadGetAllRows();
                }
                else
                {
                    stringBuilder.AppendLine("Error Occured, Discount not removed");
                }

            }
            else
            {
                stringBuilder.AppendLine("Discount ID does not exist");
            }
            return stringBuilder.ToString();
        }
       
    }
}
