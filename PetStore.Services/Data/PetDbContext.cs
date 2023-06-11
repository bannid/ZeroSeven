using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PetStore.Services.Models;
namespace PetStore.Services.Data
{
    public class PetDbContext: DbContext
    {
        IConfiguration _config;
        public PetDbContext(IConfiguration configuration)
        {
            _config = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _config.GetValue<string>("AppSettings:ConnectionString");
            optionsBuilder.UseSqlServer(connectionString);
        }
        public DbSet<PetDto> Pets { get; set; }
        public DbSet<PetType> PetTypes { get; set; }
    }
}
