using System;
using System.Collections.Generic;
using Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public partial class CoursContext : DbContext
{
    public CoursContext()
    {
    }

    public CoursContext(DbContextOptions<CoursContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Classe> Classes { get; set; }

    public virtual DbSet<Cour> Cours { get; set; }

    public virtual DbSet<Enseignant> Enseignants { get; set; }

    public virtual DbSet<Matiere> Matieres { get; set; }

    public virtual DbSet<Salle> Salles { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // => optionsBuilder.UseNpgsql("Host=localhost;Database=cours;Username=postgres;Password=heheboi");

// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. 
// You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. 
// For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Classe>(entity =>
        {
            entity.HasKey(e => e.Numclasse).HasName("pk_classe");

            entity.ToTable("classe");

            entity.Property(e => e.Numclasse)
                .HasMaxLength(10)
                .HasColumnName("numclasse");
            entity.Property(e => e.Niveau)
                .HasMaxLength(5)
                .HasColumnName("niveau");
            entity.Property(e => e.Parcours)
                .HasMaxLength(7)
                .HasColumnName("parcours");
        });

        modelBuilder.Entity<Cour>(entity =>
        {
            entity.HasKey(e => e.Numcours).HasName("pk_cours");

            entity.ToTable("cours");

            entity.HasIndex(e => e.Numclasse, "i_fk_cours_classe");

            entity.HasIndex(e => e.Numenseignant, "i_fk_cours_enseignant");

            entity.HasIndex(e => e.Codematiere, "i_fk_cours_matiere");

            entity.HasIndex(e => e.Numsalle, "i_fk_cours_salle");

            entity.Property(e => e.Numcours).HasColumnName("numcours");
            entity.Property(e => e.Codematiere)
                .HasMaxLength(5)
                .HasColumnName("codematiere");
            entity.Property(e => e.Date)
                .HasColumnName("date");
                // .HasConversion(
                //     v => v.ToString("yyyy-MM-dd"),
                //     v => DateOnly.Parse(v)
                // );
            entity.Property(e => e.Heuredebut)
                .HasColumnName("heuredebut")
                .HasConversion(
                    v => v.ToTimeSpan(), // Convert TimeOnly to TimeSpan for storage
                    v => TimeOnly.FromTimeSpan(v) // Convert TimeSpan to TimeOnly for retrieval
                );
                // .HasConversion(
                //     v => v.ToString("HH:mm:ss"),
                //     v => TimeOnly.Parse(v)
                // );
            entity.Property(e => e.Heurefin)
                .HasColumnName("heurefin")
                .HasConversion(
                    v => v.ToTimeSpan(), // Convert TimeOnly to TimeSpan for storage
                    v => TimeOnly.FromTimeSpan(v) // Convert TimeSpan to TimeOnly for retrieval
                );
                // .HasConversion(
                //     v => v.ToString("HH:mm:ss"),
                //     v => TimeOnly.Parse(v)
                // );
            entity.Property(e => e.Numclasse)
                .HasMaxLength(10)
                .HasColumnName("numclasse");
            entity.Property(e => e.Numenseignant).HasColumnName("numenseignant");
            entity.Property(e => e.Numsalle).HasColumnName("numsalle");

            entity.HasOne(d => d.CodematiereNavigation).WithMany(p => p.Cours)
                .HasForeignKey(d => d.Codematiere)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cours_matiere");

            entity.HasOne(d => d.NumclasseNavigation).WithMany(p => p.Cours)
                .HasForeignKey(d => d.Numclasse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cours_classe");

            entity.HasOne(d => d.NumenseignantNavigation).WithMany(p => p.Cours)
                .HasForeignKey(d => d.Numenseignant)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cours_enseignant");

            entity.HasOne(d => d.NumsalleNavigation).WithMany(p => p.Cours)
                .HasForeignKey(d => d.Numsalle)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cours_salle");
        });

        modelBuilder.Entity<Enseignant>(entity =>
        {
            entity.HasKey(e => e.Numenseignant).HasName("pk_enseignant");

            entity.ToTable("enseignant");

            entity.Property(e => e.Numenseignant).HasColumnName("numenseignant");
            entity.Property(e => e.Civiliteenseignant)
                .HasMaxLength(30)
                .HasColumnName("civiliteenseignant");
            entity.Property(e => e.Nomenseignant)
                .HasMaxLength(30)
                .HasColumnName("nomenseignant");
            entity.Property(e => e.Prenomenseignant)
                .HasMaxLength(30)
                .HasColumnName("prenomenseignant");
        });

        modelBuilder.Entity<Matiere>(entity =>
        {
            entity.HasKey(e => e.Codematiere).HasName("pk_matiere");

            entity.ToTable("matiere");

            entity.Property(e => e.Codematiere)
                .HasMaxLength(5)
                .HasColumnName("codematiere");
            entity.Property(e => e.Nommatiere)
                .HasMaxLength(30)
                .HasColumnName("nommatiere");
        });

        modelBuilder.Entity<Salle>(entity =>
        {
            entity.HasKey(e => e.Numsalle).HasName("pk_salle");

            entity.ToTable("salle");

            entity.Property(e => e.Numsalle)
                .ValueGeneratedNever()
                .HasColumnName("numsalle");
            entity.Property(e => e.Designsalle)
                .HasMaxLength(5)
                .HasColumnName("designsalle");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
