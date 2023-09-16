using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Modeles
{
    [Owned]
    public class Publisher
    {
        public int Id { get; set; }
        public string Name {get; set;}
    } 
}
