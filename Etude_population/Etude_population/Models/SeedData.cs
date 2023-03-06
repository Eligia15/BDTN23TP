using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Etude_population.Data;
using System;
using System.Linq;
namespace Etude_population.Models;
public static class SeedData // Ajout d’une nouvelle classe SeedData dans Models pour créer la base et ajouter un film si besoin
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new Etude_populationContext(
        serviceProvider.GetRequiredService<
        DbContextOptions<Etude_populationContext>>()))
        {
            context.Database.EnsureCreated();
            // S’il y a déjà des pays dans la base
            if (context.Pays.Any())
            {
                return; // On ne fait rien
            }

            // S’il y a déjà une population dans la base
            if (context.Population.Any())
            {
                return; // On ne fait rien
            }

            // Sinon on en ajoute un
            context.Pays.AddRange(
            new Pays
            {
                Name = "Cameroun",
                Continent= "Afrique"
            }
            );

            context.Population.AddRange(
            new Population
            {
                Nombre = 7000000,
                Pays_app = Cameroun,
                Annee = 2020
            }
            );
            context.SaveChanges();
        }
    }
}

