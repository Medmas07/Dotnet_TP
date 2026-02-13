using Microsoft.AspNetCore.Http;
using WebApplication1.Models;

namespace WebApplication1.ViewModels;

public class MovieVM
{
    public Movie movie { get; set; }

    public IFormFile? photo { get; set; }
}