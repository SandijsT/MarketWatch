using System;
using System.Collections.Generic;
using DatabaseLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace SSWebScraper.Contexts;

public partial class resourceContext : DbContext
{
    public resourceContext()
    {
    }

    public resourceContext(DbContextOptions<resourceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BodyTypeLanguage> BodyTypeLanguages { get; set; }

    public virtual DbSet<CategoryLanguage> CategoryLanguages { get; set; }

    public virtual DbSet<EngineDisplacementTypeLanguage> EngineDisplacementTypeLanguages { get; set; }

    public virtual DbSet<FuelTypeLanguage> FuelTypeLanguages { get; set; }

    public virtual DbSet<LubodyType> LubodyTypes { get; set; }

    public virtual DbSet<Lucategory> Lucategories { get; set; }

    public virtual DbSet<LuengineDisplacementType> LuengineDisplacementTypes { get; set; }

    public virtual DbSet<LufuelType> LufuelTypes { get; set; }

    public virtual DbSet<Lumodel> Lumodels { get; set; }

    public virtual DbSet<LupostType> LupostTypes { get; set; }

    public virtual DbSet<LutransmissionType> LutransmissionTypes { get; set; }

    public virtual DbSet<ModelLanguage> ModelLanguages { get; set; }

    public virtual DbSet<PostTypeLanguage> PostTypeLanguages { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<TransmissionTypeLanguage> TransmissionTypeLanguages { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\LOCAL;Database=resource;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BodyTypeLanguage>(entity =>
        {
            entity.HasKey(e => new { e.BodyTypeId, e.LanguageId });

            entity.ToTable("BodyTypeLanguage");

            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.BodyType).WithMany(p => p.BodyTypeLanguages)
                .HasForeignKey(d => d.BodyTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BodyTypeLanguage_BodyTypeId");
        });

        modelBuilder.Entity<CategoryLanguage>(entity =>
        {
            entity.HasKey(e => new { e.CategoryId, e.LanguageId });

            entity.ToTable("CategoryLanguage");

            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.CategoryLanguages)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CategoryLanguage_CategoryId");
        });

        modelBuilder.Entity<EngineDisplacementTypeLanguage>(entity =>
        {
            entity.HasKey(e => new { e.EngineDisplacementTypeId, e.LanguageId });

            entity.ToTable("EngineDisplacementTypeLanguage");

            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.EngineDisplacementType).WithMany(p => p.EngineDisplacementTypeLanguages)
                .HasForeignKey(d => d.EngineDisplacementTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EngineDisplacementTypeLanguage_EngineDisplacementTypeId");
        });

        modelBuilder.Entity<FuelTypeLanguage>(entity =>
        {
            entity.HasKey(e => new { e.FuelTypeId, e.LanguageId });

            entity.ToTable("FuelTypeLanguage");

            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.FuelType).WithMany(p => p.FuelTypeLanguages)
                .HasForeignKey(d => d.FuelTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FuelTypeLanguage_FuelTypeId");
        });

        modelBuilder.Entity<LubodyType>(entity =>
        {
            entity.HasKey(e => e.BodyTypeId);

            entity.ToTable("LUBodyType");

            entity.Property(e => e.BodyTypeId).ValueGeneratedNever();
            entity.Property(e => e.BodyType).IsRequired();
        });

        modelBuilder.Entity<Lucategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId);

            entity.ToTable("LUCategory");

            entity.Property(e => e.CategoryId).ValueGeneratedNever();
            entity.Property(e => e.Category).IsRequired();
        });

        modelBuilder.Entity<LuengineDisplacementType>(entity =>
        {
            entity.HasKey(e => e.EngineDisplacementTypeId);

            entity.ToTable("LUEngineDisplacementType");

            entity.Property(e => e.EngineDisplacementTypeId).ValueGeneratedNever();
            entity.Property(e => e.EngineDisplacement).HasColumnType("decimal(19, 2)");
            entity.Property(e => e.EngineDisplacementType)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<LufuelType>(entity =>
        {
            entity.HasKey(e => e.FuelTypeId);

            entity.ToTable("LUFuelType");

            entity.Property(e => e.FuelTypeId).ValueGeneratedNever();
            entity.Property(e => e.FuelType)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<Lumodel>(entity =>
        {
            entity.HasKey(e => e.ModelId);

            entity.ToTable("LUModel");

            entity.Property(e => e.ModelId).ValueGeneratedNever();
            entity.Property(e => e.Manufacturer)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Model)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<LupostType>(entity =>
        {
            entity.HasKey(e => e.PostTypeId);

            entity.ToTable("LUPostType");

            entity.Property(e => e.PostTypeId).ValueGeneratedNever();
            entity.Property(e => e.PostType)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<LutransmissionType>(entity =>
        {
            entity.HasKey(e => e.TransmissionTypeId);

            entity.ToTable("LUTransmissionType");

            entity.Property(e => e.TransmissionTypeId).ValueGeneratedNever();
            entity.Property(e => e.TransmissionType)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<ModelLanguage>(entity =>
        {
            entity.HasKey(e => new { e.ModelId, e.LanguageId });

            entity.ToTable("ModelLanguage");

            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Model).WithMany(p => p.ModelLanguages)
                .HasForeignKey(d => d.ModelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ModelLanguage_ModelId");
        });

        modelBuilder.Entity<PostTypeLanguage>(entity =>
        {
            entity.HasKey(e => new { e.PostTypeId, e.LanguageId });

            entity.ToTable("PostTypeLanguage");

            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.PostType).WithMany(p => p.PostTypeLanguages)
                .HasForeignKey(d => d.PostTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PostTypeLanguage_PostTypeId");
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.ToTable("Rating");

            entity.Property(e => e.AveragePrice).HasColumnType("decimal(19, 2)");

            entity.HasOne(d => d.BodyType).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.BodyTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rating_LUBodyType");

            entity.HasOne(d => d.EngineDisplacementType).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.EngineDisplacementTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rating_LUEngineDisplacementType");

            entity.HasOne(d => d.FuelType).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.FuelTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rating_LUFuelType");

            entity.HasOne(d => d.Model).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.ModelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rating_LUModel");

            entity.HasOne(d => d.TransmissionType).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.TransmissionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rating_LUTransmissionType");
        });

        modelBuilder.Entity<TransmissionTypeLanguage>(entity =>
        {
            entity.HasKey(e => new { e.TransmissionTypeId, e.LanguageId });

            entity.ToTable("TransmissionTypeLanguage");

            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.TransmissionType).WithMany(p => p.TransmissionTypeLanguages)
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
            entity.Property(e => e.TiendDate).HasColumnName("TIEndDate");
            entity.Property(e => e.Title).HasMaxLength(2048);

            entity.HasOne(d => d.BodyType).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.BodyTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vehicle_LUBodyType");

            entity.HasOne(d => d.Category).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vehicle_LUCategory");

            entity.HasOne(d => d.EngineDisplacementType).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.EngineDisplacementTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vehicle_LUEngineDisplacementType");

            entity.HasOne(d => d.FuelType).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.FuelTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vehicle_LUFuelType");

            entity.HasOne(d => d.Model).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.ModelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vehicle_LUModel");

            entity.HasOne(d => d.PostType).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.PostTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vehicle_LUPostType");

            entity.HasOne(d => d.TransmissionType).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.TransmissionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vehicle_LUTransmissionType");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
