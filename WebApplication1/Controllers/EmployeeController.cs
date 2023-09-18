using Microsoft.AspNetCore.Mvc;
using WebApplication1.Modeles;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        IndexViewModel GetDefaultViewModel()
        {
            List<Book> books;
            List<Publisher> publishers;
            List<Genre> genres;
            List<Author> authors;
            using (WebApplication1Context db = new())
            {
                books = db.Books.ToList();
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
        public IActionResult Index()
        {

            return View(GetDefaultViewModel());
        }
        [HttpPost]
        public IActionResult CartAdd(string title)
        {
            return View("Index", GetDefaultViewModel());
        }

        [HttpPost]
        public IActionResult PublisherCreate(Publisher publisher)
        {
            using (WebApplication1Context db = new())
            {
                db.Publishers.Add(publisher);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                }

            }
            return View("Index", GetDefaultViewModel());
        }

        [HttpPost]
        public IActionResult PublisherDelete(Publisher publisher)
        {
            using (WebApplication1Context db = new())
            {
                db.Publishers.Remove(publisher);

                db.SaveChanges();
            }
            return View("Index", GetDefaultViewModel());
        }

        [HttpPost]
        public IActionResult GenreCreate(Genre genre)
        {
            using (WebApplication1Context db = new())
            {
                db.Genres.Add(genre);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                }

            }
            return View("Index", GetDefaultViewModel());
        }

        [HttpPost]
        public IActionResult GenreDelete(Genre genre)
        {
            using (WebApplication1Context db = new())
            {
                db.Genres.Remove(genre);
                db.SaveChanges();
            }
            return View("Index", GetDefaultViewModel());
        }

        [HttpPost]
        public IActionResult AuthorCreate(Author author)
        {
            using (WebApplication1Context db = new())
            {
                db.Authors.Add(author);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                }

            }
            return View("Index", GetDefaultViewModel());
        }

        [HttpPost]
        public IActionResult AuthorDelete(Author author)
        {
            using (WebApplication1Context db = new())
            {
                db.Authors.Remove(author);
                db.SaveChanges();
            }
            return View("Index", GetDefaultViewModel());
        }

        [HttpPost]
        public IActionResult BookCreate(string Title, int Count, int Price, int Publisher, int Genre, int Author)
        {

            using (WebApplication1Context db = new())
            {
                var book = new Book()
                {
                    Title = Title,
                    Count = Count,
                    Price = Price,
                    Publisher = db.Publishers.Where(p => p.Id == Publisher).Single(),
                    Genre = db.Genres.Where(p => p.Id == Genre).Single(),
                    Author = db.Authors.Where(p => p.Id == Author).Single()
                };
                db.Books.Add(book);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                }

            }
            return View("Index", GetDefaultViewModel());
        }

        [HttpPost]
        public IActionResult BookDelete(Book book)
        {
            using (WebApplication1Context db = new())
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }
            return View("Index", GetDefaultViewModel());
        }

        public struct IndexViewModel
        {
            public List<Book> books;
            public Book? book;
            public List<Publisher> publishers;
            public List<Genre> genres;
            public List<Author> authors;

        }
    }
}
