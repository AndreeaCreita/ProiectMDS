using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProiectMDS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.Infrastructure
{
    public class MainMenuViewComponent: ViewComponent
    {
        private readonly ProiectMDSContext context;

        public MainMenuViewComponent(ProiectMDSContext context)
        {
            this.context = context;
        }

        //InvokeAsync e o metoda din ViewComponent care face posibila afisarea paginilor (display the pages) 
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var pages = await GetPagesAsync();
            return View(pages);   //view component se gaseste in Shared, in MainMenu cu numele de Default + dupa o invoc in Layout
        }

        private Task<List<Page>> GetPagesAsync()
        {
            return context.Pages.OrderBy(x => x.Sorting).ToListAsync();
        }
    }
}
