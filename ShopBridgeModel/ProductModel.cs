using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridgeModel
{
    public  class ProductModel
    {
        public int Product_Id { get; set; }
        public string Product_Categories { get; set; }
        public string Product_Name { get; set; }
        public decimal Price { get; set; }
        public string Product_Discription { get; set; }
        public DateTime? Product_MFG_Date { get; set; }
    }
}
