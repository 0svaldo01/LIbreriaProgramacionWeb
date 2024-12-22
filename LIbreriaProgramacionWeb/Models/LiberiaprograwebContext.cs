using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace LIbreriaProgramacionWeb.Models;

public partial class LiberiaprograwebContext : DbContext
{
    public LiberiaprograwebContext()
    {
    }

    public LiberiaprograwebContext(DbContextOptions<LiberiaprograwebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Generosliterarios> Generosliterarios { get; set; }

    public virtual DbSet<Libros> Libros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=liberiaprograweb", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Generosliterarios>(entity =>
        {
            entity.HasKey(e => e.IdGenero).HasName("PRIMARY");

            entity.ToTable("generosliterarios");

            entity.Property(e => e.NombreGenero).HasMaxLength(100);
        });

        modelBuilder.Entity<Libros>(entity =>
        {
            entity.HasKey(e => e.IdLibro).HasName("PRIMARY");

            entity.ToTable("libros");

            entity.HasIndex(e => e.IdGenero, "IdGenero");

            entity.Property(e => e.Autor).HasMaxLength(150);
            entity.Property(e => e.Titulo).HasMaxLength(200);

            entity.HasOne(d => d.IdGeneroNavigation).WithMany(p => p.Libros)
                .HasForeignKey(d => d.IdGenero)
                .HasConstraintName("libros_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
