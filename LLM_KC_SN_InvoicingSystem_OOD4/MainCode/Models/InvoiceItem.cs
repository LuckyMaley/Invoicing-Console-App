using MainCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCode.Models
{
    /// <summary>
    /// This is a InvoiceItems model which contains the properties of the invoiceItems and the invoiceItems dataset.
    /// 
    /// The properties include InvoiceItemId, InvoiceId, ProductId, Quantity, UnitPrice, TotalPrice.
    /// The invoiceItems dataset includes a list of 10 invoiceItems records.
    /// </summary>
    public class InvoiceItem
    {
        public int InvoiceItemID { get; set; }
        public int InvoiceID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

        public static List<InvoiceItem> InvoiceItemsDataSet = new List<InvoiceItem>
        {
            new InvoiceItem{InvoiceItemID= 1 ,InvoiceID= 1,ProductID =	1, Quantity=1,UnitPrice=254.95m,TotalPrice= 492.96m},
            new InvoiceItem{InvoiceItemID= 2,InvoiceID= 2,ProductID = 2, Quantity=	2,UnitPrice=222.44m,TotalPrice=	927.46m},
            new InvoiceItem{InvoiceItemID= 3,InvoiceID= 3,ProductID = 3, Quantity=	3,UnitPrice=480.44m,TotalPrice=	249.1m},
            new InvoiceItem{InvoiceItemID= 4,InvoiceID= 4,ProductID = 4, Quantity=4,UnitPrice=	371.25m,TotalPrice=	844.68m},
            new InvoiceItem{InvoiceItemID= 5,InvoiceID= 5,ProductID = 5, Quantity=	5,UnitPrice=396.61m,TotalPrice=	297.2m},
            new InvoiceItem{InvoiceItemID= 6,InvoiceID= 6,ProductID = 6, Quantity=	6,UnitPrice=287.31m,TotalPrice = 188.45m},
            new InvoiceItem{InvoiceItemID= 7,InvoiceID= 7,ProductID = 7, Quantity=	7,UnitPrice=112.99m,TotalPrice=	592.94m},
            new InvoiceItem{InvoiceItemID= 8,InvoiceID= 8,ProductID = 8, Quantity=8,UnitPrice=	404.77m,TotalPrice=	77.69m},
            new InvoiceItem{InvoiceItemID= 9,InvoiceID= 9,ProductID = 9, Quantity=	9,UnitPrice=351.13m,TotalPrice=	601.55m},
            new InvoiceItem{InvoiceItemID= 10,InvoiceID=10,ProductID = 10, Quantity=10,UnitPrice=177.68m,TotalPrice=457.97m},
         
        };
    }
}











