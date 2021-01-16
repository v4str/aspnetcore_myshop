using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myshop.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<ProductPhoto> ProductPhotos { get; set; } = new List<ProductPhoto>();
    }
}
