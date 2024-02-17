using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication8.Model
{
    public partial class CONTEXLOCAL : DbContext
    {
        public CONTEXLOCAL()
        {
        }

        public CONTEXLOCAL(DbContextOptions<CONTEXLOCAL> options)
            : base(options)
        {
        }

        public virtual DbSet<DatorHyrning> DatorHyrnings { get; set; } = null!;
        public virtual DbSet<Datorer> Datorers { get; set; } = null!;
        public virtual DbSet<Hyrning> Hyrnings { get; set; } = null!;
        public virtual DbSet<Kunder> Kunders { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\localDB;Initial Catalog=exjobb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatorHyrning>(entity =>
            {
                entity.HasOne(d => d.Dator)
                    .WithMany(p => p.DatorHyrnings)
                    .HasForeignKey(d => d.DatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dator_Hyrning_Dator");

                entity.HasOne(d => d.Hyrnings)
                    .WithMany(p => p.DatorHyrnings)
                    .HasForeignKey(d => d.HyrningsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dator_Hyrning_Hyrning");
            });

            modelBuilder.Entity<Datorer>(entity =>
            {
                entity.HasKey(e => e.DatorId)
                    .HasName("PK__Datorer__C18FF85F2CAC74CE");

                entity.Property(e => e.DatorId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Hyrning>(entity =>
            {
                entity.HasKey(e => e.HyrningsId)
                    .HasName("PK__Hyrning__47E4174B22D77FB1");

                entity.HasOne(d => d.Kund)
                    .WithMany(p => p.Hyrnings)
                    .HasForeignKey(d => d.KundId)
                    .HasConstraintName("FK_Hyrning_Kund");
            });

            modelBuilder.Entity<Kunder>(entity =>
            {
                entity.HasKey(e => e.KundId)
                    .HasName("PK__Kunder__7C0AD0F5EA6BAF3F");

                entity.Property(e => e.KundId).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
