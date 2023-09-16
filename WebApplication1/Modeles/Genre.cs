using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Modeles
{
    [Owned]
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
