﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorFMS.Data.BlazorFMS;

public partial class BlaFMSContext : DbContext
{
    public BlaFMSContext(DbContextOptions<BlaFMSContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Colaboradores> Colaborador { get; set; }

    public virtual DbSet<Sucursales> Sucursal { get; set; }

    public virtual DbSet<SucursalDetalles> SucursalDetalle { get; set; }

    public virtual DbSet<Transportistas> Transportista { get; set; }

    public virtual DbSet<Viaje> Viaje { get; set; }

    public virtual DbSet<WeatherForecast> WeatherForecast { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Colaboradores>(entity =>
        {
            entity.HasKey(e => e.ColaboradorId).HasName("PK__Colabora__28AA72C14A36BECD");

            entity.Property(e => e.ColaboradorId).HasColumnName("ColaboradorID");
            entity.Property(e => e.DireccionCasa)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        modelBuilder.Entity<Sucursales>(entity =>
        {
            entity.HasKey(e => e.SucursalId).HasName("PK__Sucursal__6CB48281B9508136");

            entity.Property(e => e.SucursalId).HasColumnName("SucursalID");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ubicacion)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        modelBuilder.Entity<SucursalDetalles>(entity =>
        {
            entity.HasKey(e => e.SucursalDetalleId).HasName("PK__Sucursal__A0C310A2BB9143DF");

            entity.HasIndex(e => new { e.SucursalId, e.ColaboradorId }, "UQ_SucursalDetalle").IsUnique();

            entity.Property(e => e.SucursalDetalleId).HasColumnName("SucursalDetalleID");
            entity.Property(e => e.ColaboradorId).HasColumnName("ColaboradorID");
            entity.Property(e => e.DistanciaKilometros).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SucursalId).HasColumnName("SucursalID");

            entity.HasOne(d => d.Colaborador).WithMany(p => p.SucursalDetalle)
                .HasForeignKey(d => d.ColaboradorId)
                .HasConstraintName("FK__SucursalD__Colab__5EBF139D");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.SucursalDetalle)
                .HasForeignKey(d => d.SucursalId)
                .HasConstraintName("FK__SucursalD__Sucur__5DCAEF64");
        });

        modelBuilder.Entity<Transportistas>(entity =>
        {
            entity.HasKey(e => e.TransportistaId).HasName("PK__Transpor__A26C7F55584836DA");

            entity.Property(e => e.TransportistaId).HasColumnName("TransportistaID");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TarifaPorKilometro).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        modelBuilder.Entity<Viaje>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Viaje__3214EC273A6CFF64");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ColaboradorId).HasColumnName("ColaboradorID");
            entity.Property(e => e.Distancia).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.TransportistaId).HasColumnName("TransportistaID");
            entity.Property(e => e.UserName).HasMaxLength(50);

            entity.HasOne(d => d.Colaborador).WithMany(p => p.Viaje)
                .HasForeignKey(d => d.ColaboradorId)
                .HasConstraintName("FK__Viaje__Colaborad__5535A963");

            entity.HasOne(d => d.Transportista).WithMany(p => p.Viaje)
                .HasForeignKey(d => d.TransportistaId)
                .HasConstraintName("FK__Viaje__Transport__5629CD9C");
        });

        modelBuilder.Entity<WeatherForecast>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WeatherF__3214EC07E7C0B057");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Summary).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}