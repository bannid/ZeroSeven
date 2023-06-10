using Microsoft.EntityFrameworkCore;
using PetStore.Services.Models;
namespace PetStore.Services.Data
{
    public class PetDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:devserverbanni.database.windows.net,1433;Initial Catalog=PetStore;Persist Security Info=False;User ID=bannidhaliwal;Password=Zer0Seven;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
        public DbSet<PetDto> Pets { get; set; }
        public DbSet<PetType> PetTypes { get; set; }
    }
}
