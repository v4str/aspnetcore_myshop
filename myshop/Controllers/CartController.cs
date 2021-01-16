using Microsoft.AspNetCore.Mvc;
using myshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace myshop.Controllers
{
    public class CartController : Controller
    {
        private ApplicationContext db;
        public CartController(ApplicationContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            var session = HttpContext.Request.Cookies["SessionGUID"];
            
            if (!string.IsNullOrEmpty(session))
            {
                var customer = db.Customers;

                var tmp = customer.Where(x => x.CustomerId == session.ToString());

                var res = tmp.SelectMany(c => c.Products).Include(x => x.ProductPhotos).ToList();

                /*var cartSum = res.Select(x => Convert.ToInt32(x.Price)).Sum();*/

                return View(res);
            }
            return View();
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            if (!HttpContext.Request.Cookies.ContainsKey("SessionGUID"))
            {
                Guid guid = Guid.NewGuid();
                HttpContext.Response.Cookies.Append("SessionGUID", guid.ToString());

                Customer customer = new Customer
                {
                    CustomerId = guid.ToString(),
                    Name = "Igor"
                };
                db.Customers.Add(customer);
                db.SaveChanges();


                var product = db.Products.Find(id);
                customer.Products.Add(product);
                db.SaveChanges();

           
                return RedirectToAction("Index","Products");

            }
            else
            {
                try
                {
                    var customer = db.Customers.Find(HttpContext.Request.Cookies["SessionGUID"]);
                    customer.Products.Add(db.Products.Find(id));
                    db.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    TempData["notice"] = "Товар уже есть в корзине";
                    return RedirectToAction("Index", "Products");
                }
                
                
                

            }
            return RedirectToAction("Index", "Products");
        }
    }
}
