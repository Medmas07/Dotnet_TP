using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using WebApplication1.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Genre> Genres { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var genreId = new Guid("11111111-1111-1111-1111-111111111111");

        // 1️⃣ Seed Genre d'abord
        modelBuilder.Entity<Genre>().HasData(
            new Genre
            {
                Id = genreId,
                Name = "JSON Genre"
            }
        );

        // 2️⃣ Lire JSON
        var json = File.ReadAllText("Movies.json");
        var movies = JsonSerializer.Deserialize<List<Movie>>(json);

        // 3️⃣ Forcer le GenreId
        foreach (var movie in movies)
        {
            movie.GenreId = genreId;
            modelBuilder.Entity<Movie>().HasData(movie);
        }
    }
}