namespace WebApplication1.Models;

public class Movie
{
    public int Id { get; set; }
    public string? Name { get; set; }
    // Relation
    public Guid GenreId { get; set; }
    public Genre? Genre { get; set; }
    //  TP3
    public string? ImageFile { get; set; }
    public DateTime? DateAjoutMovie { get; set; }
    public int Stock { get; set; }

}
