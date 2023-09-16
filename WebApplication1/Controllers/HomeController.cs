using Microsoft.AspNetCore.Mvc;
using WebApplication1.Modeles;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        IndexViewModel GetDefaultViewModel()
        {
             List<Book> books;
            List<Publisher> publishers;
            using (WebApplication1Context db = new())
            {
                books = db.Books.ToList();
                publishers = db.Publishers.ToList();
            }
            return new IndexViewModel() { books = books, publishers = publishers };
        }
        public IActionResult Index() {
           
            return View(GetDefaultViewModel());
        }
        [HttpPost]
        public IActionResult CartAdd(string title) {
            return View("Index", GetDefaultViewModel());
        }

        [HttpPost]
        public IActionResult PublisherCreate(Publisher publisher)
        {
            using (WebApplication1Context db = new())
            {
                db.Publishers.Add(publisher);
                db.SaveChanges();
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

        public struct IndexViewModel
        {
            public List<Book> books;
            public Book? book;
            public List<Publisher> publishers;

        }
    }
}
