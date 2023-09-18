using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApplication1.Modeles;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public struct IndexViewModel
        {
            public List<Book> books;
            public Book? book;
            public List<Publisher> publishers;
            public List<Genre> genres;
            public List<Author> authors;

        }

        IndexViewModel GetDefaultViewModel(string search, int[] search_authors, 
            int[] search_publishers, int[] search_genres)
        {
            List<Book> books;
            List<Publisher> publishers;
            List<Genre> genres;
            List<Author> authors;
           
            using (WebApplication1Context db = new())
            {
                bool selector(Book b)
                {
                    string genre_state, author_state, publisher_state;

                    return
                        (search != null ? b.Title.ToLower().Contains(search.ToLower()) : true)
                        && (search_authors.Length == 0 || search_authors.Contains(b.Author.Id))
                        && (search_publishers.Length == 0 || search_publishers.Contains(b.Publisher.Id))
                        && (search_genres.Length == 0 || search_genres.Contains(b.Genre.Id))
                        /*&& (search_publishers.TryGetValue(b.Publisher.Id, out publisher_state) ? publisher_state.Equals("on") : false)
                        && (search_genres.TryGetValue(b.Genre.Id, out genre_state) ? genre_state.Equals("on") : false)*/;
                }
                books = db.Books
                    .Include(b => b.Genre)
                    .Include(b => b.Author)
                    .Include(b => b.Publisher)
                        .Where(selector).ToList();

                publishers = db.Publishers.ToList();
                genres = db.Genres.ToList();
                authors = db.Authors.ToList();

            }
            return new IndexViewModel()
            {
                books = books,
                publishers = publishers,
                genres = genres,
                authors = authors
            };
        }
        public IActionResult Index(string search, int[] authors, int[] publishers, int[] genres/*, Dictionary<int, string> publishers, 
            Dictionary<int, string> genres*/)
        {
            // return RedirectToAction("Index", "Employee");
            return View(GetDefaultViewModel(search, authors, publishers, genres));
            //authors, publishers, genres));
        }
    }
    
}
