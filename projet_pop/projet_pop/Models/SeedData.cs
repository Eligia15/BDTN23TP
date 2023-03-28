using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using projet_pop.Data;
using projet_pop.Models;
using System;
using System.Linq;



namespace projet_pop.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new projet_popContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<projet_popContext>>()))
            {
                context.Database.EnsureCreated();
                // S’il y a déjà des films dans la base
                if (context.Continent.Any())
                {
                    return; // On ne fait rien
                }
                // Sinon on en ajoute un
                context.Continent.AddRange(
                new Continent
                {
                   Name = "Afrique"
                }
                 );
                if (context.Pays.Any())
                {
                    return; // On ne fait rien
                }
                // Sinon on en ajoute un
                context.Pays.AddRange(
                new Pays
                {
                   Name = "Cameroun",
                   ContinentId = 1
                }
                 );
                if (context.Population.Any())
                {
                    return; // On ne fait rien
                }
                // Sinon on en ajoute un
                context.Population.AddRange(
                new Population
                {
                  population = 29000000,
                  year = 2022,
                  PaysId = 1
                }
                );
                context.SaveChanges();
            }
        }
    }
}