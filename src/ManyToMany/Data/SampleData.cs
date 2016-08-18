using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ManyToMany.Models;

namespace ManyToMany.Data
{
    public class SampleData
    {
        public async static Task Initialize(IServiceProvider serviceProvider) {
            var db = serviceProvider.GetService<ApplicationDbContext>();
            await db.Database.EnsureCreatedAsync();

            if (!db.MovieActors.Any()) {
                db.Movies.AddRange(
                    new Movie { Title = "Enders Game" },
                    new Movie { Title = "Star Wars" }
                    );
                db.SaveChanges();

                db.Actors.AddRange(
                    new Actor { FirstName = "Asa", LastName = "Butterfield" },
                    new Actor { FirstName = "Liam", LastName = "Neson" }
                    );
                db.SaveChanges();

                db.MovieActors.AddRange(
                    new MovieActor {
                        MovieId = db.Movies.FirstOrDefault(m => m.Title == "Enders Game").Id,
                        ActorId = db.Actors.FirstOrDefault(a => a.LastName == "Butterfield").Id
                    },

                    new MovieActor {
                        MovieId = db.Movies.FirstOrDefault(m => m.Title == "Star Wars").Id,
                        ActorId = db.Actors.FirstOrDefault(a => a.LastName == "Neson").Id
                    }
                    );
                db.SaveChanges();
            }
        }
    }
}
