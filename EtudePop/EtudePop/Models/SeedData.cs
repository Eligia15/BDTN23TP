﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EtudePop.Data;
using System;
using System.Linq;
namespace EtudePop.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new EtudePopContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<EtudePopContext>>()))
            {
                context.Database.EnsureCreated();
                // S’il y a déjà des films dans la base
                if (context.Pays.Any())
                {
                    return; // On ne fait rien
                }
                // Sinon on en ajoute un
                context.Pays.AddRange(
                new Pays
                {
                    Name = "France",
                    Continent = "Europe"
                }
                );
                if (context.Population.Any())
                {
                    return; // On ne fait rien
                }
                // Sinon on en ajoute un
                context.Population.AddRange(
                new Population           {
                    Nombre= 2000000,
                    Annee = 2021,
                    id_pays = 1
                }
                
                );
                context.SaveChanges();
            }
        }

    }
}