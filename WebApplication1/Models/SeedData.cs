using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new ApplicationDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

        if (context.Genres.Any())
            return; // Base déjà remplie

        var genre1 = new Genre { Id = Guid.NewGuid(), Name = "Action" };
        var genre2 = new Genre { Id = Guid.NewGuid(), Name = "Comedy" };
        var genre3 = new Genre { Id = Guid.NewGuid(), Name = "Drama" };

        context.Genres.AddRange(genre1, genre2, genre3);

        context.Movies.AddRange(
            new Movie { Name = "Fast & Furious", GenreId = genre1.Id },
            new Movie { Name = "The Hangover", GenreId = genre2.Id },
            new Movie { Name = "Joker", GenreId = genre3.Id },
            new Movie { Name = "Mission Impossible", GenreId = genre1.Id }
        );

        context.SaveChanges();
    }
}