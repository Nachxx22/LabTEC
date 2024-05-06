using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LabTecAPI.Models;

public partial class LabManagementContext : DbContext
{
    public LabManagementContext()
    {
    }

    public LabManagementContext(DbContextOptions<LabManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Activo> Activos { get; set; }

    public virtual DbSet<Administradore> Administradores { get; set; }

    public virtual DbSet<Averia> Averias { get; set; }

    public virtual DbSet<Devolucione> Devoluciones { get; set; }

    public virtual DbSet<HorariosLaboratorio> HorariosLaboratorios { get; set; }

    public virtual DbSet<Laboratorio> Laboratorios { get; set; }

    public virtual DbSet<Operadore> Operadores { get; set; }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    public virtual DbSet<Profesore> Profesores { get; set; }

    public virtual DbSet<SesionesOperador> SesionesOperadors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=NACHO-DESKTOP\\SQLEXPRESS;Database=LabManagement;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activo>(entity =>
        {
            entity.HasKey(e => e.Placa).HasName("PK__Activos__8310F99C38CC3939");

            entity.Property(e => e.Placa)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ImagenUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ImagenURL");
            entity.Property(e => e.Marca)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Ocupado) // Añadir la configuración para el nuevo campo
                .IsRequired() // Hace que el campo sea no nulo
                .HasDefaultValue(false); // Establece un valor por defecto
        });

        modelBuilder.Entity<Administradore>(entity =>
        {
            entity.HasKey(e => e.Correo).HasName("PK__Administ__60695A18EB52D153");

            entity.Property(e => e.Correo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Averia>(entity =>
        {
            entity.HasKey(e => e.AveriaId).HasName("PK__Averias__440A143789B0F081");

            entity.Property(e => e.AveriaId).HasColumnName("AveriaID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DevolucionId).HasColumnName("DevolucionID");

            entity.HasOne(d => d.Devolucion).WithMany(p => p.Averia)
                .HasForeignKey(d => d.DevolucionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Devolucion_ID");
        });

        modelBuilder.Entity<Devolucione>(entity =>
        {
            entity.HasKey(e => e.DevolucionId).HasName("PK__Devoluci__28E7B0E78C1697B8");

            entity.Property(e => e.DevolucionId).HasColumnName("DevolucionID");
            entity.Property(e => e.Carnet)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EstadoFinalDelActivo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PrestamoId).HasColumnName("PrestamoID");

            entity.HasOne(d => d.CarnetNavigation).WithMany(p => p.Devoluciones)
                .HasForeignKey(d => d.Carnet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Carnet_Devoluciones");

            entity.HasOne(d => d.Prestamo).WithMany(p => p.Devoluciones)
                .HasForeignKey(d => d.PrestamoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prestamo_ID");
        });

        modelBuilder.Entity<HorariosLaboratorio>(entity =>
        {
            entity.HasKey(e => e.HorarioId).HasName("PK__Horarios__BB881A9E7662EA34");

            entity.Property(e => e.HorarioId).HasColumnName("HorarioID");
            entity.Property(e => e.CédulaProfesor)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LaboratorioNombre)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.CédulaProfesorNavigation).WithMany(p => p.HorariosLaboratorios)
                .HasForeignKey(d => d.CédulaProfesor)
                .HasConstraintName("FK_CédulaProfesor");

            entity.HasOne(d => d.LaboratorioNombreNavigation).WithMany(p => p.HorariosLaboratorios)
                .HasForeignKey(d => d.LaboratorioNombre)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HorariosLaboratorios_Laboratorios");
        });

        modelBuilder.Entity<Laboratorio>(entity =>
        {
            entity.HasKey(e => e.Nombre).HasName("PK__Laborato__75E3EFCE9E18FBEF");

            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Facilidades)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Operadore>(entity =>
        {
            entity.HasKey(e => e.Carnet).HasName("PK__Operador__5E387B4C17008D69");

            entity.HasIndex(e => e.Correo, "UQ__Operador__60695A19736FA00A").IsUnique();

            entity.Property(e => e.Carnet)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Apellido)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Cedula) // Añadir la configuración para el nuevo campo
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Aprobado) // Añadir la configuración para el nuevo campo
                .IsRequired() // Hace que el campo sea no nulo
                .HasDefaultValue(false); // Establece un valor por defecto
        });

        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.HasKey(e => e.PrestamoId).HasName("PK__Prestamo__AA58A080596FACAC");

            entity.Property(e => e.PrestamoId).HasColumnName("PrestamoID");
            entity.Property(e => e.Carnet)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CarnetEstudiante)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Cedula)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Placa)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NecesitaAprobacion) // Añadir la configuración para el nuevo campo
                .IsRequired() // Hace que el campo sea no nulo
                .HasDefaultValue(false); // Establece un valor por defecto
            entity.Property(e => e.EstadoAprobacion) // Añadir la configuración para el nuevo campo
                .IsRequired() // Hace que el campo sea no nulo
                .HasDefaultValue(false); // Establece un valor por defecto
            entity.Property(e => e.Entregado) // Añadir la configuración para el nuevo campo
                .IsRequired() // Hace que el campo sea no nulo
                .HasDefaultValue(false); // Establece un valor por defecto

            entity.HasOne(d => d.CarnetNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.Carnet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Carnet_Prestamos");

            entity.HasOne(d => d.CedulaNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.Cedula)
                .HasConstraintName("FK_Cedula_Profesores");

            entity.HasOne(d => d.PlacaNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.Placa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Placa_Activos");
        });

        modelBuilder.Entity<Profesore>(entity =>
        {
            entity.HasKey(e => e.Cédula).HasName("PK__Profesor__F12AB288FBE7311D");

            entity.HasIndex(e => e.Correo, "UQ__Profesor__60695A19DC64459F").IsUnique();

            entity.Property(e => e.Cédula)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Apellido)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SesionesOperador>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SesionesOperador");

            entity.Property(e => e.Carnet)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.CarnetNavigation).WithMany()
                .HasForeignKey(d => d.Carnet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Carnet_Operadores");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
