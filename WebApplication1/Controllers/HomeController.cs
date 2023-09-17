using Microsoft.AspNetCore.Mvc;
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

        IndexViewModel GetDefaultViewModel(string search)
        {
            List<Book> books;
            List<Publisher> publishers;
            List<Genre> genres;
            List<Author> authors;
            using (WebApplication1Context db = new())
            {
                books = search != null ? db.Books.Where(b => b.Title.ToLower().Contains(search.ToLower())).ToList() : db.Books.ToList();
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
        public IActionResult Index(string search)
        {
            // return RedirectToAction("Index", "Employee");
            return View(GetDefaultViewModel(search));
        }
    }
    
}
