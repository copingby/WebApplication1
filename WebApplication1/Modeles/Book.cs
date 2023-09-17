using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Modeles
{
    [Index(nameof(Title), IsUnique =true)]
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public decimal Price { get; set; }  
        public int Count { get; set; }
        public Author Author { get; set; }
        public Publisher Publisher { get; set; }
        public int AgeRestriction { get; set; } 
    }
}
