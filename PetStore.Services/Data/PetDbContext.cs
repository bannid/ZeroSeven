using Microsoft.EntityFrameworkCore;

namespace PetStore.Services
{
    public class PetDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "PetsDB");
        }
        public DbSet<Pet> Somethings { get; set; }
    }
}
