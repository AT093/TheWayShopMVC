using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheWayShop.Data;
using TheWayShop.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TheWayShop.Controllers
{
    public class ItemController : Controller
    {
        private readonly TheWayShopContext _context;

        public ItemController(TheWayShopContext context)
        {
            _context = context;
        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
          return View(await _context.Items.ToListAsync());
        }
        public async Task<IActionResult> AddItem(int? id)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                var value = HttpContext.Session.GetString("Id");

                YourItems buyBook = new YourItems();
                var book = _context.Items.Where(x => x.Id == id).FirstOrDefault();
                buyBook.Item = book.Item;
                buyBook.Brand = book.Brand;
                buyBook.Category = book.Category;
                buyBook.Price = book.Price;
                buyBook.UserId = Convert.ToInt32(value);
                _context.Add(buyBook);
                await _context.SaveChangesAsync();
                return RedirectToAction("UserIndex", "Items");
            }
            else
                return RedirectToAction("UserLogin", "Login");
        }

    }
}
