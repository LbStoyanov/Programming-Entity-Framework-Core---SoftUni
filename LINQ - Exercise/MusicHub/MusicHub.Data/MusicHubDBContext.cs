using Microsoft.EntityFrameworkCore;
using MusicHub.Data.Models;
using P03_FootballBetting.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicHub.Data
{
    public class MusicHubDBContext : DbContext
    {
        public MusicHubDBContext()
        {

        }

        public MusicHubDBContext(DbContextOptions options)
            :base(options)
        {

        }

        DbSet<Album> Albums { get; set; }
        DbSet<Performer> Performers { get; set; }
        DbSet<Producer> Producers { get; set; }
        DbSet<Song> Songs { get; set; }
        DbSet<SongPerformer> SongPerformers { get; set; }
        DbSet<Writer> Writers { get; set; }

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
