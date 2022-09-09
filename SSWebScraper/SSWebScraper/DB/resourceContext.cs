using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SSWebScraper.Models;

namespace SSWebScraper.DB
{
    public partial class resourceContext : DbContext
    {
        public resourceContext()
        {
        }

        public resourceContext(DbContextOptions<resourceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BodyTypeLanguage> BodyTypeLanguages { get; set; } = null!;
        public virtual DbSet<CategoryLanguage> CategoryLanguages { get; set; } = null!;
        public virtual DbSet<EngineDisplacementTypeLanguage> EngineDisplacementTypeLanguages { get; set; } = null!;
        public virtual DbSet<FuelTypeLanguage> FuelTypeLanguages { get; set; } = null!;
        public virtual DbSet<LUBodyType> LUBodyTypes { get; set; } = null!;
        public virtual DbSet<LUCategory> LUCategories { get; set; } = null!;
        public virtual DbSet<LUEngineDisplacementType> LUEngineDisplacementTypes { get; set; } = null!;
        public virtual DbSet<LUFuelType> LUFuelTypes { get; set; } = null!;
        public virtual DbSet<LUModel> LUModels { get; set; } = null!;
        public virtual DbSet<LUPostType> LUPostTypes { get; set; } = null!;
        public virtual DbSet<LUTransmissionType> LUTransmissionTypes { get; set; } = null!;
        public virtual DbSet<ModelLanguage> ModelLanguages { get; set; } = null!;
        public virtual DbSet<PostTypeLanguage> PostTypeLanguages { get; set; } = null!;
        public virtual DbSet<TransmissionTypeLanguage> TransmissionTypeLanguages { get; set; } = null!;
        public virtual DbSet<Vehicle> Vehicles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=resource;Integrated Security=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BodyTypeLanguage>(entity =>
            {
                entity.HasKey(e => new { e.BodyTypeId, e.LanguageId });

                entity.ToTable("BodyTypeLanguage");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.BodyType)
                    .WithMany(p => p.BodyTypeLanguages)
                    .HasForeignKey(d => d.BodyTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BodyTypeLanguage_BodyTypeId");
            });

            modelBuilder.Entity<CategoryLanguage>(entity =>
            {
                entity.HasKey(e => new { e.CategoryId, e.LanguageId });

                entity.ToTable("CategoryLanguage");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CategoryLanguages)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CategoryLanguage_CategoryId");
            });

            modelBuilder.Entity<EngineDisplacementTypeLanguage>(entity =>
            {
                entity.HasKey(e => new { e.EngineDisplacementTypeId, e.LanguageId });

                entity.ToTable("EngineDisplacementTypeLanguage");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.EngineDisplacementType)
                    .WithMany(p => p.EngineDisplacementTypeLanguages)
                    .HasForeignKey(d => d.EngineDisplacementTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EngineDisplacementTypeLanguage_EngineDisplacementTypeId");
            });

            modelBuilder.Entity<FuelTypeLanguage>(entity =>
            {
                entity.HasKey(e => new { e.FuelTypeId, e.LanguageId });

                entity.ToTable("FuelTypeLanguage");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.FuelType)
                    .WithMany(p => p.FuelTypeLanguages)
                    .HasForeignKey(d => d.FuelTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FuelTypeLanguage_FuelTypeId");
            });

            modelBuilder.Entity<LUBodyType>(entity =>
            {
                entity.HasKey(e => e.BodyTypeId);

                entity.ToTable("LUBodyType");
            });

            modelBuilder.Entity<LUCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("LUCategory");

                entity.Property(e => e.CategoryId).ValueGeneratedNever();
            });

            modelBuilder.Entity<LUEngineDisplacementType>(entity =>
            {
                entity.HasKey(e => e.EngineDisplacementTypeId);

                entity.ToTable("LUEngineDisplacementType");

                entity.Property(e => e.EngineDisplacement).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.EngineDisplacementType).HasMaxLength(100);
            });

            modelBuilder.Entity<LUFuelType>(entity =>
            {
                entity.HasKey(e => e.FuelTypeId);

                entity.ToTable("LUFuelType");

                entity.Property(e => e.FuelType).HasMaxLength(100);
            });

            modelBuilder.Entity<LUModel>(entity =>
            {
                entity.HasKey(e => e.ModelId);

                entity.ToTable("LUModel");

                entity.Property(e => e.Manufacturer).HasMaxLength(100);

                entity.Property(e => e.Model).HasMaxLength(100);
            });

            modelBuilder.Entity<LUPostType>(entity =>
            {
                entity.HasKey(e => e.PostTypeId);

                entity.ToTable("LUPostType");

                entity.Property(e => e.PostType).HasMaxLength(100);
            });

            modelBuilder.Entity<LUTransmissionType>(entity =>
            {
                entity.HasKey(e => e.TransmissionTypeId);

                entity.ToTable("LUTransmissionType");

                entity.Property(e => e.TransmissionType).HasMaxLength(100);
            });

            modelBuilder.Entity<ModelLanguage>(entity =>
            {
                entity.HasKey(e => new { e.ModelId, e.LanguageId });

                entity.ToTable("ModelLanguage");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.ModelLanguages)
                    .HasForeignKey(d => d.ModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ModelLanguage_ModelId");
            });

            modelBuilder.Entity<PostTypeLanguage>(entity =>
            {
                entity.HasKey(e => new { e.PostTypeId, e.LanguageId });

                entity.ToTable("PostTypeLanguage");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.PostType)
                    .WithMany(p => p.PostTypeLanguages)
                    .HasForeignKey(d => d.PostTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostTypeLanguage_PostTypeId");
            });

            modelBuilder.Entity<TransmissionTypeLanguage>(entity =>
            {
                entity.HasKey(e => new { e.TransmissionTypeId, e.LanguageId });

                entity.ToTable("TransmissionTypeLanguage");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.TransmissionType)
                    .WithMany(p => p.TransmissionTypeLanguages)
                    .HasForeignKey(d => d.TransmissionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransmissionTypeLanguage_TransmissionTypeId");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(e => e.PostId);

                entity.ToTable("Vehicle");

                entity.Property(e => e.Color).HasMaxLength(50);

                entity.Property(e => e.Link).HasMaxLength(2048);

                entity.Property(e => e.Price).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.TIendDate).HasColumnName("TIEndDate");

                entity.Property(e => e.Title).HasMaxLength(2048);

                entity.HasOne(d => d.BodyType)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.BodyTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicle_LUBodyType");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicle_LUCategory");

                entity.HasOne(d => d.EngineDisplacementType)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.EngineDisplacementTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicle_LUEngineDisplacementType");

                entity.HasOne(d => d.FuelType)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.FuelTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicle_LUFuelType");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.ModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicle_LUModel");

                entity.HasOne(d => d.PostType)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.PostTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicle_LUPostType");

                entity.HasOne(d => d.TransmissionType)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.TransmissionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicle_LUTransmissionType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
