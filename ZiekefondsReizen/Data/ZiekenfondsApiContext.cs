using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZiekefondsReizen.Models;
using System.Numerics;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZiekefondsReizen.Data
{
    public class ZiekenfondsApiContext : IdentityDbContext<CustomUser>
    {
        public ZiekenfondsApiContext(DbContextOptions<ZiekenfondsApiContext> options) : base(options) { } 

        public DbSet<Groepsreis> Groepsreizen { get; set; }
        public DbSet<Activiteit> activiteiten { get; set; }
        public DbSet<Bestemming> bestemmingen { get; set; }
        public DbSet<Kind> kinderen { get; set; }
        public DbSet<Deelnemer> deelnemers { get; set; }
        public DbSet<Opleiding> opleidingen { get; set; }
        public DbSet<Onkosten> onkosten { get; set; }
        public DbSet<Review> reviews { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Groepsreis>().ToTable("Groepsreis");
            modelBuilder.Entity<Activiteit>().ToTable("Activiteit");
            modelBuilder.Entity<Bestemming>().ToTable("Bestemming");
            modelBuilder.Entity<Deelnemer>().ToTable("Deelnemer");

            modelBuilder.Entity<Kind>().ToTable("Kind");

            modelBuilder.Entity<Opleiding>().ToTable("Opleiding");
            modelBuilder.Entity<Onkosten>().ToTable("Onkosten");


            modelBuilder.Entity<Review>().ToTable("Review");
            //relaties
            modelBuilder.Entity<Groepsreis>()
                .HasOne(g => g.Bestemming)
                .WithMany(b => b.Groepsreizen)
                .HasForeignKey(g => g.BestemmingId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Bestemming>()
                .HasMany(b => b.Reviews)
                .WithOne(r => r.Bestemming)
                .HasForeignKey(r => r.BestemmingId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Opleiding>()
                .HasOne(o => o.OpleidingVereist)
                .WithMany()
                .HasForeignKey(o => o.OpleidingVereistId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Onkosten>()
                 .HasOne(o => o.Groepsreis)
                 .WithMany(g => g.Onkosten)
                 .HasForeignKey(o => o.groepsreisId)
                 .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Deelnemer>()
                .HasOne(d =>d.Groepsreis)
                .WithMany(g=>g.Deelnemers)
                .HasForeignKey(d => d.GroepsreisId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Deelnemer>()
                .HasOne(d => d.Kind)
                .WithMany(k => k.Deelnames)
                .HasForeignKey(d => d.KindId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Bestemming)
                .WithMany(b => b.Reviews)
                .HasForeignKey(r =>  r.BestemmingId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
