using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HamsterConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<Hamster> Hamsters { get; set; }
        public DbSet<MatchData> MatchesData { get; set; }
    }
}
