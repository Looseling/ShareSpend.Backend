using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpend.Domain.Entities
{
    public class ProcessedReecipt
    {
        public string MerchantName { get; set; }
        public string Address { get; set; }
        public List<Product> ListOfProducts { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }
    }

    public class Product
    {
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
    }
}