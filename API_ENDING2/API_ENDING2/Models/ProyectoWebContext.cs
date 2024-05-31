using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API_ENDING2.Models;

public partial class ProyectoWebContext : DbContext
{
    public ProyectoWebContext()
    {
    }

    public ProyectoWebContext(DbContextOptions<ProyectoWebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adjudicado> Adjudicados { get; set; }

    public virtual DbSet<Incluye> Incluyes { get; set; }

    public virtual DbSet<Inmobiliaria> Inmobiliaria { get; set; }

    public virtual DbSet<Litigio> Litigios { get; set; }

    public virtual DbSet<Litigioso> Litigiosos { get; set; }

    public virtual DbSet<Propiedad> Propiedads { get; set; }

    public virtual DbSet<Remate> Remates { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Adjudicado>(entity =>
        {
            entity.HasKey(e => e.IdAdjudicado).HasName("PK__Adjudica__7B6F1B26E880CCDD");

            entity.ToTable("Adjudicado");

            entity.Property(e => e.IdAdjudicado).HasColumnName("id_Adjudicado");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Calle)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("calle");
            entity.Property(e => e.Colonia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("colonia");
            entity.Property(e => e.Consideraciones)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("consideraciones");
            entity.Property(e => e.Cp).HasColumnName("cp");
            entity.Property(e => e.Curp)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("curp");
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.EstadoAdjudicacion).HasColumnName("estadoAdjudicacion");
            entity.Property(e => e.IdRemate).HasColumnName("id_Remate");
            entity.Property(e => e.Municipio)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("municipio");
            entity.Property(e => e.Nombres)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.Num)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("num");
            entity.Property(e => e.Rfc)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("rfc");
            entity.Property(e => e.SemafonoEscrituracion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("semafono_escrituracion");
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdRemateNavigation).WithMany(p => p.Adjudicados)
                .HasForeignKey(d => d.IdRemate)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Adjudicad__id_Re__5629CD9C");
        });

        modelBuilder.Entity<Incluye>(entity =>
        {
            entity.HasKey(e => new { e.IdPropiedad, e.IdLitigioso, e.IdLitigio, e.IdAdjudicado }).HasName("PK__Incluye__7E003D0BB1CB86E6");

            entity.ToTable("Incluye");

            entity.Property(e => e.IdPropiedad).HasColumnName("id_Propiedad");
            entity.Property(e => e.IdLitigioso).HasColumnName("id_Litigioso");
            entity.Property(e => e.IdLitigio).HasColumnName("id_Litigio");
            entity.Property(e => e.IdAdjudicado).HasColumnName("id_Adjudicado");

            entity.HasOne(d => d.oAdjudicado).WithMany(p => p.Incluyes)
                .HasForeignKey(d => d.IdAdjudicado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Incluye__id_Adju__5BE2A6F2");

            entity.HasOne(d => d.oLitigio).WithMany(p => p.Incluyes)
                .HasForeignKey(d => d.IdLitigio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Incluye__id_Liti__5AEE82B9");

            entity.HasOne(d => d.oLitigioso).WithMany(p => p.Incluyes)
                .HasForeignKey(d => d.IdLitigioso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Incluye__id_Liti__59FA5E80");

            entity.HasOne(d => d.oPropiedad).WithMany(p => p.Incluyes)
                .HasForeignKey(d => d.IdPropiedad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Incluye__id_Prop__59063A47");
        });

        modelBuilder.Entity<Inmobiliaria>(entity =>
        {
            entity.HasKey(e => e.IdInmobiliaria).HasName("PK__Inmobili__C02F5BD6B8A92DA8");

            entity.Property(e => e.IdInmobiliaria).HasColumnName("id_Inmobiliaria");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("razon_social");
            entity.Property(e => e.Rfc)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("rfc");
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Litigio>(entity =>
        {
            entity.HasKey(e => e.IdLitigio).HasName("PK__Litigio__86FC4C7D72EF50AE");

            entity.ToTable("Litigio");

            entity.Property(e => e.IdLitigio).HasColumnName("id_Litigio");
            entity.Property(e => e.AdeudoTotal).HasColumnName("adeudo_total");
            entity.Property(e => e.EdoJuzgado)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("edo_juzgado");
            entity.Property(e => e.Expediente)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("expediente");
            entity.Property(e => e.IdLitigioso).HasColumnName("id_Litigioso");
            entity.Property(e => e.IdRemate).HasColumnName("id_Remate");
            entity.Property(e => e.Juzgado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("juzgado");
            entity.Property(e => e.Procedimiento)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("procedimiento");

            entity.HasOne(d => d.oLitigioso).WithMany(p => p.Litigios)
                .HasForeignKey(d => d.IdLitigioso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Litigio__id_Liti__52593CB8");

            entity.HasOne(d => d.oRemate).WithMany(p => p.Litigios)
                .HasForeignKey(d => d.IdRemate)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Litigio__id_Rema__534D60F1");
        });

        modelBuilder.Entity<Litigioso>(entity =>
        {
            entity.HasKey(e => e.IdLitigioso).HasName("PK__Litigios__2CB95D6504C15A59");

            entity.ToTable("Litigioso");

            entity.Property(e => e.IdLitigioso).HasColumnName("id_Litigioso");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Calle)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("calle");
            entity.Property(e => e.Colonia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("colonia");
            entity.Property(e => e.Cp).HasColumnName("cp");
            entity.Property(e => e.Curp)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("curp");
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Municipio)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("municipio");
            entity.Property(e => e.Nombres)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.Num)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("num");
            entity.Property(e => e.Rfc)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("rfc");
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Propiedad>(entity =>
        {
            entity.HasKey(e => e.IdPropiedad).HasName("PK__Propieda__F23AE260EC7E718C");

            entity.ToTable("Propiedad");

            entity.Property(e => e.IdPropiedad).HasColumnName("id_Propiedad");
            entity.Property(e => e.Altitud).HasColumnName("altitud");
            entity.Property(e => e.Calle)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("calle");
            entity.Property(e => e.Colonia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("colonia");
            entity.Property(e => e.Cp).HasColumnName("cp");
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Latitud).HasColumnName("latitud");
            entity.Property(e => e.Municipio)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("municipio");
            entity.Property(e => e.Num)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("num");
            entity.Property(e => e.Subtipo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("subtipo");
            entity.Property(e => e.SuperficieCons).HasColumnName("superficie_cons");
            entity.Property(e => e.SuperficieTerreno).HasColumnName("superficie_terreno");
        });

        modelBuilder.Entity<Remate>(entity =>
        {
            entity.HasKey(e => e.IdRemate).HasName("PK__Remate__FB7BB6E145E10540");

            entity.ToTable("Remate");

            entity.Property(e => e.IdRemate).HasColumnName("id_Remate");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Fiscalia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fiscalia");
            entity.Property(e => e.IdInmobiliaria).HasColumnName("id_Inmobiliaria");

            entity.HasOne(d => d.oInmobiliaria).WithMany(p => p.Remates)
                .HasForeignKey(d => d.IdInmobiliaria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Remate__id_Inmob__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
