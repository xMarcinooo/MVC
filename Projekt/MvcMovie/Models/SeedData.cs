using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            if (context.Movie.Any())
            {
                return;
            }

            context.Movie.AddRange(
                new Movie
                {
                    Title = "Inception",
                    Director = "Christopher Nolan",
                    Rating = "9/10"
                },

                new Movie
                {
                    Title = "Interstellar",
                    Director = "Christopher Nolan",
                    Rating = "10/10"
                },

                new Movie
                {
                    Title = "The Matrix",
                    Director = "Lana i Lilly Wachowski",
                    Rating = "9/10"
                },

                new Movie
                {
                    Title = "Rio Bravo",
                    Director = "Howard Hawks",
                    Rating = "7/10"
                }
            );

            context.SaveChanges();
        }
    }
}
