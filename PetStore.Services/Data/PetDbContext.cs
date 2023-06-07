using Microsoft.EntityFrameworkCore;
using PetStore.Services.Models;
namespace PetStore.Services.Data
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
