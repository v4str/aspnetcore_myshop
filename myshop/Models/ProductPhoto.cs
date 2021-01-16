using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myshop.Models
{
    public class ProductPhoto
    {
        [Key]
        public int Id { get; set; }
        public string URL { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
