using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProiectMDS.Infrastructure;
using ProiectMDS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.Controllers
{
    public class PagesController : Controller
    {
        private readonly ProiectMDSContext context;
        //constructor
        public PagesController(ProiectMDSContext context)
        {
            this.context = context; //ca sa le pot folosi context sau metode sau actions
        }
        //GET/ or/ slug
        public async Task<IActionResult> Page(string slug)   //afisarea paginilor -> are legatura cu Startup ca prima pagina sa fie by default cea cu Parfu
        {
            if (slug == null)                                 //daca se scrie in url un alt slug atunci se va duce la pagina respectiva
            {
                return View(await context.Pages.Where(x => x.Slug == "home").FirstOrDefaultAsync());
            }

            Page page = await context.Pages.Where(x => x.Slug == slug).FirstOrDefaultAsync();

            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }
    }
}
