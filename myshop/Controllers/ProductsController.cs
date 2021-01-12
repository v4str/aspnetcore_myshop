using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace myshop.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationContext db;
        public ProductsController(ApplicationContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.Products.ToListAsync());
        }

        public async Task<IActionResult> AddToCart(int? id)
        {
            if (string.IsNullOrWhiteSpace(HttpContext.Request.Cookies["SessionGUID"]))
            {
                Guid guid = Guid.NewGuid();
                var cookie = new HttpCookie("SessionGUID");
                cookie.Value = guid;
            }
            else
            {
                
            }
            return View();
        }
    }
}
