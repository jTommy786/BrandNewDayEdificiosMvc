using System.Data.Entity; 

namespace BrandNewDayEdificiosMvc.Models
{
    public class BrandNewDayDbContext : DbContext
    {
        public BrandNewDayDbContext() : base("name=BrandNewDayDbContext")
        {
        }

        public DbSet<Barrio> Barrios { get; set; }
        public DbSet<Edificio> Edificios { get; set; }
    }
}
