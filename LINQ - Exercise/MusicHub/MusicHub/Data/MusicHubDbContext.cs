using Microsoft.EntityFrameworkCore;
using MusicHub.Data.Models;
using P03_FootballBetting.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicHub.Data
{
    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {

        }

        public MusicHubDbContext(DbContextOptions options)
            :base(options)
        {

        }

       public DbSet<Album> Albums { get; set; }
       public DbSet<Performer> Performers { get; set; }
       public DbSet<Producer> Producers { get; set; }
       public DbSet<Song> Songs { get; set; }
       public DbSet<SongPerformer> SongPerformers { get; set; }
       public DbSet<Writer> Writers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SongPerformer>(e =>
            {
                //Configuration for current entity(PlayerStatistics)
                //Composite Key Creation

                e.HasKey(sp => new { sp.SongId, sp.PerforemrId });
            });
        }

    }
}
