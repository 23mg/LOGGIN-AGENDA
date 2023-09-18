using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LOGGIN_AGENDA.Models;

public partial class DbAgendaContext : DbContext
{
    public DbAgendaContext()
    {
    }

    public DbAgendaContext(DbContextOptions<DbAgendaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Persona> Personas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("PK__Persona__A4788141D10CAEA0");

            entity.ToTable("Persona");

            entity.Property(e => e.IdPersona).HasColumnName("idPersona");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.FechaCita)
                .HasColumnType("date")
                .HasColumnName("fechaCita");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreCompleto");
            entity.Property(e => e.Telefono).HasColumnName("telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
