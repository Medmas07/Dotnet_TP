using ASPCoreFirstApp.Models;
using WebApplication1.Models;

public interface IMovieService
{
    List<Movie> GetAll();

    List<Movie> GetActionMoviesInStock();

    List<Movie> GetOrderedMovies();

    int GetTotalMovies();

    List<MovieGenreDTO> GetMoviesWithGenre();

    List<Genre> GetTop3Genres();

    List<Customer> GetSubscribedCustomers();
}