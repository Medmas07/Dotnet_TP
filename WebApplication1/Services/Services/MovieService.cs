using ASPCoreFirstApp.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

public class MovieService : IMovieService
{
    private readonly ApplicationDbContext _context;

    public MovieService(ApplicationDbContext context)
    {
        _context = context;
    }

    // ✔ Tous les films avec Genre
    public List<Movie> GetAll()
    {
        return _context.Movies
            .Include(m => m.Genre)
            .ToList();
    }

    // ✔ Films Action avec stock > 0
    public List<Movie> GetActionMoviesInStock()
    {
        return _context.Movies
            .Include(m => m.Genre)
            .Where(m => m.Genre!.Name == "Action" && m.Stock > 0)
            .ToList();
    }

    // ✔ Films ordonnés par Date puis Titre
    public List<Movie> GetOrderedMovies()
    {
        return _context.Movies
            .OrderBy(m => m.DateAjoutMovie)
            .ThenBy(m => m.Name)
            .ToList();
    }

    // ✔ Nombre total de films
    public int GetTotalMovies()
    {
        return _context.Movies.Count();
    }

    // ✔ Jointure Movie + Genre (DTO propre)
    public List<MovieGenreDTO> GetMoviesWithGenre()
    {
        return _context.Movies
            .Join(_context.Genres,
                movie => movie.GenreId,
                genre => genre.Id,
                (movie, genre) => new MovieGenreDTO
                {
                    Title = movie.Name,
                    Genre = genre.Name
                })
            .ToList();
    }

    // ✔ Top 3 genres populaires (basé sur nombre de films)
    public List<Genre> GetTop3Genres()
    {
        return _context.Genres
            .Include(g => g.Movies)
            .OrderByDescending(g => g.Movies!.Count)
            .Take(3)
            .ToList();
    }

    // ✔ Clients abonnés avec remise > 10%
    public List<Customer> GetSubscribedCustomers()
    {
        return _context.Customers
            .Where(c => c.IsSubscribed && c.Discount > 10)
            .ToList();
    }
}