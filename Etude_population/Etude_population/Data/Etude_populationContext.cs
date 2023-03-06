using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Etude_population.Models;

namespace Etude_population.Data
{
    public class Etude_populationContext : DbContext
    {
        public Etude_populationContext (DbContextOptions<Etude_populationContext> options)
            : base(options)
        {
        }

        public DbSet<Etude_population.Models.Pays> Pays { get; set; } = default!;

        public DbSet<Etude_population.Models.Population> Population { get; set; }
    }
}
