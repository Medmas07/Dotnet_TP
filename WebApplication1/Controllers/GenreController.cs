using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class GenreController : Controller
{
    private readonly ApplicationDbContext _db;

    public GenreController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        return View(_db.Genres.ToList());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Genre genre)
    {
        if (ModelState.IsValid)
        {
            _db.Genres.Add(genre);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(genre);
    }

    public IActionResult Edit(Guid id)
    {
        var genre = _db.Genres.Find(id);
        if (genre == null) return NotFound();
        return View(genre);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Genre genre)
    {
        _db.Genres.Update(genre);
        _db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(Guid id)
    {
        var genre = _db.Genres.Find(id);
        if (genre == null) return NotFound();
        return View(genre);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(Guid id)
    {
        var genre = _db.Genres.Find(id);
        if (genre != null)
        {
            _db.Genres.Remove(genre);
            _db.SaveChanges();
        }
        return RedirectToAction(nameof(Index));
    }
}