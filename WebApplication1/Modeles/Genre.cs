using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Modeles
{
    [Owned]
    [Index(nameof(Name), IsUnique = true)]
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
