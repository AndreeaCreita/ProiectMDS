using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Infrastructure;
using ProiectMDS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ProiectMDS.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    [Area("Admin")]
    public class PagesController : Controller
    {
        //metoda Index o sa returneze toate pages
        //am nevoie de o dependency pe care sa o injectez in clasa ca sa iau data base context
        //ca sa inject dependencies in controller am nevoie de constructori

        private readonly ProiectMDSContext context;
        //constructor
        public PagesController(ProiectMDSContext context)
        {
            this.context = context; //ca sa le pot folosi context sau metode sau actions
        }

        //GET /admin/ pages
        public async Task<IActionResult> Index() //IactionResults catch all for returns
        {
            IQueryable<Page> pages = from p in context.Pages orderby p.Sorting select p;
            List<Page> pagesList = await pages.ToListAsync();

            return View(pagesList);
        }

        //GET /admin/ pages/details/5
        public async Task<IActionResult> Details(int id) //IactionResults catch all for returns
        {
            Page page = await context.Pages.FirstOrDefaultAsync(x => x.Id == id);
            if (page == null)
            {
                return NotFound();
            }
            return View(page);
        }

        //GET /admin/ pages/create/5
        public IActionResult Create() => View();

        // POST /admin/ pages/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Page page) //IactionResults catch all for returns
        {
            if (ModelState.IsValid)
            {
                page.Slug = page.Title.ToLower().Replace(" ", "-");
                page.Sorting = 100;

                var slug = await context.Pages.FirstOrDefaultAsync(x => x.Slug == page.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "The page already exists.");
                    return View(page);
                }

                context.Add(page);
                await context.SaveChangesAsync();

                TempData["Success"] = "The page has been added!";


                return RedirectToAction("Index");
            }

            return View(page);
        }

        //GET /admin/ pages/edit/5
        public async Task<IActionResult> Edit(int id) //IactionResults catch all for returns
        {
            Page page = await context.Pages.FindAsync(id);
            if (page == null)
            {
                return NotFound();
            }
            return View(page);
        }

        // POST /admin/ pages/edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Page page) //IactionResults catch all for returns
        {
            if (ModelState.IsValid)
            {
                page.Slug = page.Id == 1 ? "home" : page.Title.ToLower().Replace(" ", "-");

                var slug = await context.Pages.Where(x => x.Id != page.Id).FirstOrDefaultAsync(x => x.Slug == page.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "The page already exists.");
                    return View(page);
                }

                context.Update(page);
                await context.SaveChangesAsync();

                TempData["Success"] = "The page has been edited!";


                return RedirectToAction("Edit", new { id = page.Id });
            }

            return View(page);
        }

        //GET /admin/ pages/delete/5
        public async Task<IActionResult> Delete(int id) //IactionResults catch all for returns
        {
            Page page = await context.Pages.FindAsync(id);
            if (page == null)
            {
                TempData["Error"] = "The page does not exist!";
            }
            else
            {
                context.Pages.Remove(page);
                await context.SaveChangesAsync();

                TempData["Success"] = "The page has been deleted!";
            }
            return RedirectToAction("Index");
        }

        // POST /admin/pages/reorder
        [HttpPost]
        public async Task<IActionResult> Reorder(int[] id)
        {
            int count = 1;

            foreach (var pageId in id)
            {
                Page page = await context.Pages.FindAsync(pageId);
                page.Sorting = count;
                context.Update(page);
                await context.SaveChangesAsync();
                count++;
            }

            return Ok();
        }
    }
}