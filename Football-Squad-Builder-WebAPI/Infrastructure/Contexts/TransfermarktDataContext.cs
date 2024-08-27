using Infrastructure.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contexts
{
    public class TransfermarktDataContext : DbContext
    {
        public TransfermarktDataContext()
        {
        }


        public TransfermarktDataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CompetitionEntity>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<CompetitionEntity>()
                .HasMany(e => e.Clubs)
                .WithOne(e => e.Competition)
                .HasForeignKey(e => e.CompetitionId)
                .IsRequired();

            modelBuilder.Entity<ClubEntity>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<ClubEntity>()
                .HasOne(e => e.Competition)
                .WithMany(e => e.Clubs)
                .HasForeignKey(e => e.CompetitionId)
                .IsRequired();

            modelBuilder.Entity<ClubEntity>()
               .HasMany(e => e.Players)
               .WithOne(e => e.Club)
               .HasForeignKey(e => e.ClubId)
               .IsRequired();

            modelBuilder.Entity<PlayerEntity>()
               .HasKey(e => e.Id);

            modelBuilder.Entity<PlayerEntity>()
                .HasOne(e => e.Club)
                .WithMany(e => e.Players)
                .HasForeignKey(e => e.ClubId)
                .IsRequired();



            base.OnModelCreating(modelBuilder);
        }
    }
}
