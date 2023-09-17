using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Modeles
{
    [Owned]
    [Index(new string[] {nameof(FirstName), nameof(LastName), nameof(BirthDate)}, IsUnique =true)]
    public class Author
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName} ({BirthDate})";
        }
    }
}
