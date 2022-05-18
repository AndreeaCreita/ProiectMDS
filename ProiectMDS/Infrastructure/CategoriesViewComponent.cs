using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProiectMDS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.Infrastructure
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly ProiectMDSContext context;

        public CategoriesViewComponent(ProiectMDSContext context)     //dependency injection 
        {
            this.context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await GetCategoriesAsync();
            return View(categories);                          //se face in Shared un folder cu Categories si se creeaza Defalut
        }                                                     //dupa o chemam in Layout

        private Task<List<Category>> GetCategoriesAsync()
        {
            return context.Categories.OrderBy(x => x.Sorting).ToListAsync();
        }
    }
}
