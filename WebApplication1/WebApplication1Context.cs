using Microsoft.EntityFrameworkCore;
using WebApplication1.Modeles;

namespace WebApplication1
{
    public class WebApplication1Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=book_store.db");
        }

        public WebApplication1Context() 
        { 
/*           Database.EnsureDeleted();
            Database.EnsureCreated();
            var genre = new Genre()
            {
                Name = "Фантастика"
            };
            var publisher = new Publisher()
            {
                Name = "АСТ"
            };
            var employee = new Employee()
            {
                Name = "Федор"
            };
            var customer = new Customer()
            {
                Name = "Анна",
                Address = "Зорге"
            };
            var author = new Author()
            {
                BirthDate = DateOnly.Parse("01.02.1964"),
                FirstName = "Ольга",
                LastName = "Ускова"
            };
            var book = new Book()
            {
                Title = "Этюды черни",
                Price = 899,
                Count = 15,
                AgeRestriction = 18,
                Author = author,
                Genre = genre,
                Publisher = publisher
            };
            Genres.Add(genre);
            Publishers.Add(publisher);
            Employees.Add(employee);
            Customers.Add(customer);
            Authors.Add(author);
            Books.Add(book); 

            SaveChanges();
*/          
        }

        public DbSet<Author> Authors => Set<Author>();
        public DbSet<Genre> Genres => Set<Genre>();
        public DbSet<Publisher> Publishers => Set<Publisher>();

        public DbSet<Book> Books => Set<Book>();
        public DbSet<Customer> Customers => Set<Customer>();

        public DbSet<Employee> Employees => Set<Employee>();


    }
}
