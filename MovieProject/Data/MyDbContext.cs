using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<MovieDirector> MovieDirectors{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieDirector>()
                .HasKey(md => new { md.MovieId, md.DirectorId });

            modelBuilder.Entity<MovieDirector>()
                .HasOne(md => md.Movie)
                .WithMany(m => m.MovieDirectors)
                .HasForeignKey(md => md.MovieId);

            modelBuilder.Entity<MovieDirector>()
                .HasOne(md => md.Director)
                .WithMany(d => d.MovieDirectors)
                .HasForeignKey(md => md.DirectorId);
        }
    }
}
