using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EtudePop.Models;

namespace EtudePop.Data
{
    public class EtudePopContext : DbContext
    {
        public EtudePopContext (DbContextOptions<EtudePopContext> options)
            : base(options)
        {
        }

        public DbSet<EtudePop.Models.Pays> Pays { get; set; } = default!;

        public DbSet<EtudePop.Models.Population>? Population { get; set; }
    }
}
