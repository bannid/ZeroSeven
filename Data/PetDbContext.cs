using Microsoft.EntityFrameworkCore;
using PetStore.Data;
using PetStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Data
{
    public class PetDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "PetsDB");
        }
        public DbSet<PetModel> Pets { get; set; }

    }
}
