using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtshopWebApp.Data
{
    public class ArtshopDataContext : DbContext
    {
        //protected readonly IConfiguration Configuration;
        public ArtshopDataContext(DbContextOptions<ArtshopDataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
        //public DbSet<Djelo> Djela {  get; set; }
        //public DbSet<Autor> Autori { get; set; }
    }
}
