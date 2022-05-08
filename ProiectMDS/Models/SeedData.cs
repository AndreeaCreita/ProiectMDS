﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProiectMDS.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            //i have access to the data base
            using (var context = new ProiectMDSContext(serviceProvider.GetRequiredService<DbContextOptions<ProiectMDSContext>>()))
            {
                if (context.Pages.Any())
                {
                    return;
                }

                context.Pages.AddRange(
                    new Page
                    {

                        Title = "Home",
                        Slug = "home",
                        Content = "home page",
                        Sorting = 0

                    },
                    new Page
                    {
                        Title = "About Us",
                        Slug = "about-us",
                        Content = "about us page",
                        Sorting = 100

                    },
                    new Page
                    {
                        Title = "Services",
                        Slug = "services",
                        Content = "services page",
                        Sorting = 100

                    },

                    new Page
                    {
                        Title = "Contact",
                        Slug = "contact",
                        Content = "contact page",
                        Sorting = 100

                    }
                );
                context.SaveChanges();
            }
        }
    }
}
