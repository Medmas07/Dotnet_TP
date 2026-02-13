using ASPCoreFirstApp.Models;
using WebApplication1.Models;

namespace ASPCoreFirstApp.ViewModels
{
    public class MovieCustomerViewModel
    {
        public Customer? Customer { get; set; }
        public List<Movie>? Movies { get; set; }
    }
}