using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Modeles
{
    [Index(nameof(Name), IsUnique = true)]
    public abstract class User
    {
        public string Name { get; set; }
        public string Password { get; set; }

    }
}
