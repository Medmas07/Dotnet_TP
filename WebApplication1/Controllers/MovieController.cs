using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers;

public class MovieController : Controller
{
    private readonly ApplicationDbContext _db;

    private readonly IWebHostEnvironment _env;

    public MovieController(ApplicationDbContext db, IWebHostEnvironment env)
    {
        _db = db;
        _env = env;
    }


    // INDEX + TRI + PAGINATION
    public IActionResult Index(string sortOrder, int page = 1)
    {
        int pageSize = 5;

        var movies = _db.Movies.Include(m => m.Genre).AsQueryable();

        ViewData["NameSort"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

        switch (sortOrder)
        {
            case "name_desc":
                movies = movies.OrderByDescending(m => m.Name);
                break;
            default:
                movies = movies.OrderBy(m => m.Name);
                break;
        }

        var pagedMovies = movies
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return View(pagedMovies);
    }

    public IActionResult Details(int id)
    {
        var movie = _db.Movies
            .Include(m => m.Genre)
            .FirstOrDefault(m => m.Id == id);

        if (movie == null)
            return NotFound();

        return View(movie);
    }

    public IActionResult Create()
    {
        ViewBag.Genres = new SelectList(_db.Genres, "Id", "Name");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(MovieVM model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            return View(model);
        }

        if (model.photo == null)
            return Content("File not uploaded");

        var fileName = Guid.NewGuid() + Path.GetExtension(model.photo.FileName);
        var path = Path.Combine(_env.WebRootPath, "images", fileName);

        using (var stream = new FileStream(path, FileMode.Create))
        {
            model.photo.CopyTo(stream);
        }

        var movie = new Movie
        {
            Name = model.movie.Name,
            GenreId = model.movie.GenreId,
            DateAjoutMovie = model.movie.DateAjoutMovie,
            ImageFile = fileName
        };

        _db.Movies.Add(movie);
        _db.SaveChanges();

        return RedirectToAction(nameof(Index));
    }


    public IActionResult Edit(int id)
    {
        var movie = _db.Movies.Find(id);
        if (movie == null) return NotFound();

        ViewBag.Genres = new SelectList(_db.Genres, "Id", "Name", movie.GenreId);
        return View(movie);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Movie movie)
    {
        if (ModelState.IsValid)
        {
            _db.Movies.Update(movie);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        return View(movie);
    }

    public IActionResult Delete(int id)
    {
        var movie = _db.Movies.Include(m => m.Genre)
            .FirstOrDefault(m => m.Id == id);

        if (movie == null) return NotFound();

        return View(movie);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var movie = _db.Movies.Find(id);
        if (movie != null)
        {
            _db.Movies.Remove(movie);
            _db.SaveChanges();
        }

        return RedirectToAction(nameof(Index));
    }
}
