using Microsoft.EntityFrameworkCore;
using ProiectMDS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.Infrastructure
{
    public class ProiectMDSContext :DbContext
    {
      //constructor
            public ProiectMDSContext(DbContextOptions<ProiectMDSContext> options)
                : base(options)
            {

            }

        //
            //DbSet of type page -> o sa pot sa accesez tabela Pages din DataBase
            //<Page> -> are type page-> Pages o sa contina field ul din Page.cs
            //cu Id, Title etc

            public DbSet<Page> Pages { get; set; }
            //public DbSet<Category> Categories { get; set; }
            //public DbSet<Product> Products { get; set; }
        
    }
}
