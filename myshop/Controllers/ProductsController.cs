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
            var tmp = db.Products.Include(x => x.ProductPhotos);
            
            
            return View(await tmp.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await db.Products.Include(x => x.ProductPhotos).FirstOrDefaultAsync(m => m.ProductId == id);

            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }
        
    }
}
