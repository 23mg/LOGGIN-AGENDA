using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LOGGIN_AGENDA.Models;

public partial class DbAccesoContext : DbContext
{
    public DbAccesoContext()
    {
    }

    public DbAccesoContext(DbContextOptions<DbAccesoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__USUARIO__2642B487A44223B9");

            entity.ToTable("USUARIO");

            entity.Property(e => e.IdUsuario).HasColumnName("IdUSUARIO");
            entity.Property(e => e.Clave)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
