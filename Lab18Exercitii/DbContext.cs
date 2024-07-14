using Lab18Exercitii.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab18Exercitii
{
    public class CarDbContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<Key> Keys { get; set; }
        public DbSet<TechnicalBook> TechnicalBooks { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\cursC#\Lab18Exercitii\Lab18Exercitii\VehicleDB.mdf;Integrated Security=True");
        }
    }
}
