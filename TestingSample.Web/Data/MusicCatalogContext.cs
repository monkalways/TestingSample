using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestingSample.Web.Models;

namespace TestingSample.Web.Data
{
    public class MusicCatalogContext : DbContext
    {
        public MusicCatalogContext (DbContextOptions<MusicCatalogContext> options)
            : base(options)
        {
        }

        public DbSet<TestingSample.Web.Models.Artist> Artists { get; set; }
        public DbSet<TestingSample.Web.Models.Album> Albums { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>().ToTable("Artist");
            modelBuilder.Entity<Album>().ToTable("Album");

        }
    }
}
