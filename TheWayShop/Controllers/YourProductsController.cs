using TheWayShop.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheWayShop.Models;

namespace TheWayShop.Controllers
{
    public class YourItemsController : Controller
    {
        private readonly TheWayShopContext _context;

        public YourItemsController(TheWayShopContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                var value = HttpContext.Session.GetString("Id");

                return View(await _context.YourItems.Where(x => x.UserId == Convert.ToInt32(value)).ToListAsync());
            }
            else
                return RedirectToAction("UserLogin", "Login");
        }


        // GET: YourItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var YourItems = await _context.YourItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (YourItems == null)
            {
                return NotFound();
            }

            return View(YourItems);
        }
        public IActionResult NoItem()
        {
            return View();
        }

        // GET: YourItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: YourItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Item,Brand,Category,Price")] YourItems YourItems)
        {
            if (ModelState.IsValid)
            {
                //YourItems.UserId = Convert.ToInt32(HttpContext.Session.GetString("Id"));
                _context.Add(YourItems);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(YourItems);
        }

        // GET: YourItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var YourItems = await _context.YourItems.FindAsync(id);
            if (YourItems == null)
            {
                return NotFound();
            }
            return View(YourItems);
        }

        // POST: YourItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Item,Brand,Category,Price")] YourItems YourItems)
        {
            if (id != YourItems.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var item = _context.YourItems.FirstOrDefault(x => x.Id == YourItems.Id);
                    item.Id = YourItems.Id;
                    item.Item = YourItems.Item;
                    item.Price = YourItems.Price;
                    item.Brand = YourItems.Brand;
                    item.Category = YourItems.Category;
                    _context.YourItems.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YourItemsExists(YourItems.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(YourItems);
        }

        // GET: YourItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var YourItems = await _context.YourItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (YourItems == null)
            {
                return NotFound();
            }

            return View(YourItems);
        }

        // POST: YourItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var YourItems = await _context.YourItems.FindAsync(id);
            _context.YourItems.Remove(YourItems);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YourItemsExists(int id)
        {
            return _context.YourItems.Any(e => e.Id == id);
        }



    }
}
