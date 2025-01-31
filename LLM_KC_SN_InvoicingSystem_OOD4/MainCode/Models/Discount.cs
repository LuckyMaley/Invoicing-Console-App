using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCode.Models
{
    /// <summary>
    /// This is a Discount model which containsthe properties of the discount and the disvount dataset.
    /// 
    /// The properties include DiscountID,Name,Rate,Amount
    /// The Discount  dataset includes a list of 10 discount dataset.
    /// </summary>
    public class Discount
    {
        public int DiscountID {  get; set; }
        public string DiscountName { get; set; }
        public Decimal Rate { get; set; }
        public double Amount { get; set; }

        public static List<Discount> DiscountsDataSet = new List<Discount>()
        {
            new Discount(){DiscountID=1,DiscountName="10% Off",Rate=90.04M,Amount=471.05},
            new Discount(){DiscountID=2,DiscountName="No Discount",Rate=86.93M,Amount=5582.01},
            new Discount(){DiscountID=3,DiscountName="20% Off",Rate=71.68M,Amount=2422.84},
            new Discount(){DiscountID=4,DiscountName="Special Promotion",Rate=62.14M,Amount=1079.64},
            new Discount(){DiscountID=5,DiscountName="sclawson4",Rate=41.55M,Amount=345.66},
            new Discount(){DiscountID=6,DiscountName="Holiday Sale",Rate=26.18M,Amount=7729.9},
            new Discount(){DiscountID=7,DiscountName="Summer Sale",Rate=38.56M,Amount=9089.21},
            new Discount(){DiscountID=8,DiscountName="Clearance Sale",Rate=30.04M,Amount=7249.33},
            new Discount(){DiscountID=9,DiscountName="No Discount",Rate=64.51M,Amount=5993.71},
            new Discount(){DiscountID=10,DiscountName="10% off",Rate=88.71M,Amount=5585.85}
        };
    }
}

