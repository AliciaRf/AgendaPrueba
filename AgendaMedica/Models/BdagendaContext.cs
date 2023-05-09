using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AgendaMedica.Models;

public partial class BdagendaContext : DbContext
{
    public BdagendaContext()
    {
    }

    public BdagendaContext(DbContextOptions<BdagendaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agendum> Agenda { get; set; }

    public virtual DbSet<Especialidad> Especialidads { get; set; }

    public virtual DbSet<LoginUsuario> LoginUsuarios { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Prevision> Previsions { get; set; }

    public virtual DbSet<Profesional> Profesionals { get; set; }

    public virtual DbSet<Sector> Sectors { get; set; }

    public virtual DbSet<TipoAtencion> TipoAtencions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=DESKTOP-RVLJI2G\\SQLEXPRESS; initial catalog=BDAgenda; user id=sa;password=Ariquelme;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agendum>(entity =>
        {
            entity.HasKey(e => e.IdAgen);

            entity.Property(e => e.IdAgen).HasColumnName("id_agen");
            entity.Property(e => e.FechaAgen)
                .HasColumnType("date")
                .HasColumnName("fecha_agen");
            entity.Property(e => e.HoraAgen).HasColumnName("hora_agen");
            entity.Property(e => e.IdPrev).HasColumnName("id_prev");
            entity.Property(e => e.IdSector).HasColumnName("id_sector");
            entity.Property(e => e.IdeEsp).HasColumnName("ide_esp");
            entity.Property(e => e.RutPac)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("rut_pac");
            entity.Property(e => e.RutPro)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("rut_pro");
            entity.Property(e => e.RutUs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("rut_us");

            entity.HasOne(d => d.IdPrevNavigation).WithMany(p => p.Agenda)
                .HasForeignKey(d => d.IdPrev)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Agenda_Prevision");

            entity.HasOne(d => d.IdSectorNavigation).WithMany(p => p.Agenda)
                .HasForeignKey(d => d.IdSector)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Agenda_Sector");

            entity.HasOne(d => d.IdeEspNavigation).WithMany(p => p.Agenda)
                .HasForeignKey(d => d.IdeEsp)
                .HasConstraintName("FK_Agenda_Especialidad");

            entity.HasOne(d => d.RutPacNavigation).WithMany(p => p.Agenda)
                .HasForeignKey(d => d.RutPac)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Agenda_Paciente");

            entity.HasOne(d => d.RutProNavigation).WithMany(p => p.Agenda)
                .HasForeignKey(d => d.RutPro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Agenda_Profesional");

            entity.HasOne(d => d.RutUsNavigation).WithMany(p => p.Agenda)
                .HasForeignKey(d => d.RutUs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Agenda_Login_usuario");
        });

        modelBuilder.Entity<Especialidad>(entity =>
        {
            entity.HasKey(e => e.IdEsp);

            entity.ToTable("Especialidad");

            entity.Property(e => e.IdEsp).HasColumnName("id_esp");
            entity.Property(e => e.IdeAte).HasColumnName("ide_ate");
            entity.Property(e => e.NombreEsp)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nombre_esp");

            entity.HasOne(d => d.IdeAteNavigation).WithMany(p => p.Especialidads)
                .HasForeignKey(d => d.IdeAte)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Especialidad_Tipo_atencion");
        });

        modelBuilder.Entity<LoginUsuario>(entity =>
        {
            entity.HasKey(e => e.RutUs);

            entity.ToTable("Login_usuario");

            entity.Property(e => e.RutUs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("rut_us");
            entity.Property(e => e.ApellidoUs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido_us");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            entity.Property(e => e.NombreUs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_us");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.RutPac);

            entity.ToTable("Paciente");

            entity.Property(e => e.RutPac)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("rut_pac");
            entity.Property(e => e.ApellidosPac)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellidos_pac");
            entity.Property(e => e.DireccionPac)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("direccion_pac");
            entity.Property(e => e.EdadPac).HasColumnName("edad_pac");
            entity.Property(e => e.EmailPac)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("email_pac");
            entity.Property(e => e.FonoPac)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("fono_pac");
            entity.Property(e => e.NombrePac)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_pac");
        });

        modelBuilder.Entity<Prevision>(entity =>
        {
            entity.HasKey(e => e.IdPrev);

            entity.ToTable("Prevision");

            entity.Property(e => e.IdPrev).HasColumnName("id_prev");
            entity.Property(e => e.NombrePrev)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nombre_prev");
        });

        modelBuilder.Entity<Profesional>(entity =>
        {
            entity.HasKey(e => e.RutPro);

            entity.ToTable("Profesional");

            entity.Property(e => e.RutPro)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("rut_pro");
            entity.Property(e => e.ApellidoPro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido_pro");
            entity.Property(e => e.EmailPro)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("email_pro");
            entity.Property(e => e.FonoPro)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("fono_pro");
            entity.Property(e => e.IdEsp).HasColumnName("id_esp");
            entity.Property(e => e.NombrePro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_pro");

            entity.HasOne(d => d.IdEspNavigation).WithMany(p => p.Profesionals)
                .HasForeignKey(d => d.IdEsp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Profesional_Especialidad");
        });

        modelBuilder.Entity<Sector>(entity =>
        {
            entity.HasKey(e => e.IdSector);

            entity.ToTable("Sector");

            entity.Property(e => e.IdSector).HasColumnName("id_sector");
            entity.Property(e => e.Sector1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sector");
        });

        modelBuilder.Entity<TipoAtencion>(entity =>
        {
            entity.HasKey(e => e.IdAte).HasName("PK_Atencion");

            entity.ToTable("Tipo_atencion");

            entity.Property(e => e.IdAte).HasColumnName("id_ate");
            entity.Property(e => e.DescripcionAte)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("descripcion_ate");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
