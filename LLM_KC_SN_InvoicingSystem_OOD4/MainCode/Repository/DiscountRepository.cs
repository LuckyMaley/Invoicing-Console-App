using MainCode.Models;
using MainCode.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Repository.Hierarchy;


namespace MainCode.Repository
{
    /// <summary>
    ///  A summary about DiscountRepository Class
    ///  </summary>
    /// <remarks>
    ///  These remarks explain more about the DiscountRepository class and methods 
    ///  public virtual List&lt;Discount&gt; ReadGetAllRows()
    ///  This method clones the discounts from the predefines list discounts to alldiscounts
    ///  <returns>
    ///  this method returns the list containing all discounts with variable name discounts
    ///  </returns> 
    ///  </remarks>

    public class DiscountRepository : RepositoryBase<Discount>
    {
        private static List<Discount> allDiscounts;

        public DiscountRepository()
        {
            allDiscounts = ReadGetAllRows();
        }
        public virtual List<Discount> ReadGetAllRows()
        {
            allDiscounts = new List<Discount>();
            foreach(var discount in Discount.DiscountsDataSet)
            {
                allDiscounts.Add(new Discount()
                {
                    DiscountID = discount.DiscountID,
                    DiscountName = discount.DiscountName,
                    Rate = discount.Rate,
                    Amount = discount.Amount,

                });
            }

            return allDiscounts;
        }

        public void SetDS(List<Discount> discounts)
        {
            allDiscounts = discounts;
            Discount.DiscountsDataSet = allDiscounts;
        }
        public virtual Discount ReadRowByID(int id)
        {
            Discount discount= allDiscounts.FirstOrDefault(a => a.DiscountID==id);
            return discount;
        }
        public override bool AddEntity(Discount entity)
        {
            MainCodeStaticObjects.loggerMainCode.Info("Adding Discount");
            bool returnVal = false;
            try
            {
                Discount.DiscountsDataSet.Add(entity);
                returnVal = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error, cannot add  discount" + ex.ToString());
                MainCodeStaticObjects.loggerMainCode.Error("Error, cannot add Discount");
            }
            return returnVal;
        }

        public override bool DeleteRow(int id)
        {
            MainCodeStaticObjects.loggerMainCode.Info("Delete Discount");
            bool returnVal = false;
            try
            {
                var ds = allDiscounts.FirstOrDefault(c => c.DiscountID == id);
                if (ds != null)
                {
                    allDiscounts.RemoveAll(c => c.DiscountID == id);
                    Discount.DiscountsDataSet.RemoveAll(c => c.DiscountID == id);
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
                MainCodeStaticObjects.loggerMainCode.Error("Error, cannot delete Discount");
                Console.WriteLine("Error, cannot delete discount" + ex.ToString());
            }

            return returnVal;
        }

        public override bool UpdateEntity(Discount entity)
        {
            MainCodeStaticObjects.loggerMainCode.Info("Update Discount");
            bool returnVal = false;
            try
            {
                var discount = Discount.DiscountsDataSet.FirstOrDefault(a => a.DiscountID == entity.DiscountID);
                discount.DiscountID = entity.DiscountID;
                discount.DiscountName = entity.DiscountName;
                discount.Rate = entity.Rate;
                discount.Amount = entity.Amount;

                returnVal = true;
            }
            catch (Exception ex)
            {
                MainCodeStaticObjects.loggerMainCode.Error("Error, cannot dupdate Discount");
                Console.WriteLine("Error, cannot update discount" + ex.ToString());
            }

            return returnVal;
        }

        public virtual bool CheckIfidExists(int id)
        {
              var DScheck = allDiscounts.FirstOrDefault(c => c.DiscountID == id);
              bool valid = false;
              if (DScheck != null)
              {
                  valid = true;
              }
              return valid;
        }

        public virtual Queue<Discount> GetDiscountByName(string name)
        {
            DiscountRepository DiscountsRepository = new DiscountRepository();
            var Discountlist = DiscountsRepository.ReadGetAllRows();
            var Discounts = new Queue<Discount>();
            foreach (var Discount in Discountlist.Where(c => c.DiscountName == name ))
            {
                Discounts.Enqueue(Discount);
            }
            return Discounts;
        }
    }
}
