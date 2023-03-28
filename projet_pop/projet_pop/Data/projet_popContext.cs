using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projet_pop.Models;

namespace projet_pop.Data
{
    public class projet_popContext : DbContext
    {
        public projet_popContext (DbContextOptions<projet_popContext> options)
            : base(options)
        {
        }

        public DbSet<projet_pop.Models.Continent> Continent { get; set; } = default!;

        public DbSet<projet_pop.Models.Pays>? Pays { get; set; }

        public DbSet<projet_pop.Models.Population>? Population { get; set; }
    }
}
