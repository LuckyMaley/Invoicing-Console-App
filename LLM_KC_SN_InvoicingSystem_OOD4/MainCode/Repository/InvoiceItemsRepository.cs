using MainCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using log4net;
using MainCode.Utilities;
using log4net.Repository.Hierarchy;





namespace MainCode.Repository
{
    /// <summary>
    ///  A summary about InvoiceItemsRepository Class
    ///  </summary>
    /// <remarks>
    ///  These remarks explain more about the InvoiceItemsRepository class and methods 
    ///  public virtual List&lt;InvoiceItems&gt; ReadGetAllRows()
    ///  This method clones the invoiceItems from the predefines list invoiceItems to allinvoiceItems
    ///  <returns>
    ///  this method returns the list containing all InvoiceItems with variable name invoiceItems
    ///  </returns> 
    ///  </remarks>
    

    public class InvoiceItemsRepository : RepositoryBase<InvoiceItem>, IRepository<InvoiceItem>
    {
        private List<InvoiceItem> allInvoiceItems;

        public InvoiceItemsRepository()
        {
            allInvoiceItems = ReadGetAllRows();
        }

        public virtual InvoiceItem ReadRowByID(int id)
        {
            InvoiceItem invoiceItem = allInvoiceItems.FirstOrDefault(c => c.InvoiceItemID == id);
            return invoiceItem;
        }

        public void SetDS(List<InvoiceItem> invoiceItems)
        {
            allInvoiceItems = invoiceItems;
            InvoiceItem.InvoiceItemsDataSet = allInvoiceItems;
        }

        public virtual List<InvoiceItem> ReadByInvoiceID(int id)
        {
            MainCodeStaticObjects.loggerMainCode.Info("ReadByInvoiceID");
            

            InvoiceItemsRepository repository = new InvoiceItemsRepository();
            List<InvoiceItem> allOfTheInvoiceItems = repository.ReadGetAllRows();
            IEnumerable<InvoiceItem> invoiceItems = allOfTheInvoiceItems.Where(c => c.InvoiceID == id);
            List<InvoiceItem> invoiceItemsList = new List<InvoiceItem>();
            if (invoiceItems != null)
            {
                invoiceItemsList = invoiceItems.ToList();
            }
            else
            {
                invoiceItemsList = null;
                MainCodeStaticObjects.loggerMainCode.Error("Invoice ID is null");
            }
            return invoiceItemsList;
        }

        public virtual bool CheckIfIdExists(int id)
        {
            var InvItemCheck = allInvoiceItems.FirstOrDefault(c => c.InvoiceItemID == id);
            bool valid = false;
            if (InvItemCheck != null)
            {
                valid = true;
            }
            return valid;
        }

        public override bool AddEntity(InvoiceItem entity)
        {
            bool returnVal = false;
            try
            {
                MainCodeStaticObjects.loggerMainCode.Info("Adding InvoiceItem here");
                
                InvoiceItem.InvoiceItemsDataSet.Add(entity);
                returnVal = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error, cannot add invoice" + ex.ToString());
                MainCodeStaticObjects.loggerMainCode.Error("Error, cannot add invoice");
            }
            return returnVal;

        }

        public override bool DeleteRow(int id)
        {
            bool returnVal = false;
            try
            {
                MainCodeStaticObjects.loggerMainCode.Info("Deleting InvoiceItem");
                
                var ds = allInvoiceItems.FirstOrDefault(c => c.InvoiceItemID == id);
                if (ds != null)
                {
                    allInvoiceItems.RemoveAll(c => c.InvoiceItemID == id);
                    InvoiceItem.InvoiceItemsDataSet.RemoveAll(c => c.InvoiceItemID == id);
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error, cannot delete invoice" + ex.ToString());
                MainCodeStaticObjects.loggerMainCode.Error("Error, cannot delete invoice");
            }

            return returnVal;
        }

        public override bool UpdateEntity(InvoiceItem entity)
        {
            bool returnVal = false;
            try
            {
                MainCodeStaticObjects.loggerMainCode.Info("Updating InvoiceItem");
                
                var invoiceItem = InvoiceItem.InvoiceItemsDataSet.FirstOrDefault(c => c.InvoiceItemID == entity.InvoiceItemID);

                invoiceItem.InvoiceItemID = entity.InvoiceItemID;
                invoiceItem.InvoiceID = entity.InvoiceID;
                invoiceItem.ProductID = entity.ProductID;
                invoiceItem.Quantity = entity.Quantity;
                invoiceItem.UnitPrice = entity.UnitPrice;
                invoiceItem.TotalPrice = entity.TotalPrice;
                
                returnVal = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error, cannot update invoiceItem" + ex.ToString());
                MainCodeStaticObjects.loggerMainCode.Error("Error, cannot update invoiceItem");
            }

            return returnVal;
        }


        public virtual List<InvoiceItem> ReadGetAllRows()
        {
            allInvoiceItems = new List<InvoiceItem>();
            foreach (var ite in InvoiceItem.InvoiceItemsDataSet)
            {
                allInvoiceItems.Add(new InvoiceItem()
                {
                    InvoiceItemID= ite.InvoiceItemID,
                    InvoiceID= ite.InvoiceID,
                    ProductID= ite.ProductID,
                    Quantity= ite.Quantity,
                    UnitPrice= ite.UnitPrice,
                    TotalPrice= ite.TotalPrice,
                  
                }
                );
            }
            return allInvoiceItems;

        }
    }
}
