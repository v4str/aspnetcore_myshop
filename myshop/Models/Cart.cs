﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myshop.Models
{
    public class Cart
    {
        public string CartId { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
