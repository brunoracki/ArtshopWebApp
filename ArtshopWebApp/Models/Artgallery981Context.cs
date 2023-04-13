using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ArtshopWebApp.Models;

public partial class Artgallery981Context : DbContext
{
    public Artgallery981Context()
    {
    }

    public Artgallery981Context(DbContextOptions<Artgallery981Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Autor> Autors { get; set; }

    public virtual DbSet<Djelo> Djelos { get; set; }

    public virtual DbSet<Izlozba> Izlozbas { get; set; }

    public virtual DbSet<Kupac> Kupacs { get; set; }

    public virtual DbSet<Ponudum> Ponuda { get; set; }

    public virtual DbSet<Umjizlozba> Umjizlozbas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=dpg-cgrd1go2qv2bi020irdg-a.frankfurt-postgres.render.com;Database=artgallery_981;Username=postgresql;Password=chV5PN9Uuy5ghf5w5Y14gHSBbOVJbvNB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Idadmin).HasName("admin_pkey");

            entity.ToTable("admin");

            entity.Property(e => e.Idadmin)
                .ValueGeneratedNever()
                .HasColumnName("idadmin");
            entity.Property(e => e.Korisnickoime)
                .HasMaxLength(30)
                .HasColumnName("korisnickoime");
            entity.Property(e => e.Lozinka)
                .HasMaxLength(30)
                .HasColumnName("lozinka");
        });

        modelBuilder.Entity<Autor>(entity =>
        {
            entity.HasKey(e => e.Idautor).HasName("autor_pkey");

            entity.ToTable("autor");

            entity.Property(e => e.Idautor)
                .ValueGeneratedNever()
                .HasColumnName("idautor");
            entity.Property(e => e.Adresa)
                .HasMaxLength(20)
                .HasColumnName("adresa");
            entity.Property(e => e.Datrod).HasColumnName("datrod");
            entity.Property(e => e.Drzava)
                .HasMaxLength(20)
                .HasColumnName("drzava");
            entity.Property(e => e.Ime)
                .HasMaxLength(20)
                .HasColumnName("ime");
            entity.Property(e => e.Mjestorod)
                .HasMaxLength(30)
                .HasColumnName("mjestorod");
            entity.Property(e => e.Postbroj).HasColumnName("postbroj");
            entity.Property(e => e.Prezime)
                .HasMaxLength(20)
                .HasColumnName("prezime");
            entity.Property(e => e.Telbroj)
                .HasMaxLength(20)
                .HasColumnName("telbroj");
        });

        modelBuilder.Entity<Djelo>(entity =>
        {
            entity.HasKey(e => e.Iddjelo).HasName("djelo_pkey");

            entity.ToTable("djelo");

            entity.Property(e => e.Iddjelo)
                .ValueGeneratedNever()
                .HasColumnName("iddjelo");
            entity.Property(e => e.Cijenadjelo).HasColumnName("cijenadjelo");
            entity.Property(e => e.Godinadjelo).HasColumnName("godinadjelo");
            entity.Property(e => e.Idautor).HasColumnName("idautor");
            entity.Property(e => e.Imgdjelo).HasColumnName("imgdjelo");
            entity.Property(e => e.Natpisdjelo)
                .HasMaxLength(30)
                .HasColumnName("natpisdjelo");
            entity.Property(e => e.Opisdjelo)
                .HasMaxLength(150)
                .HasColumnName("opisdjelo");
            entity.Property(e => e.Tipdjelo)
                .HasMaxLength(20)
                .HasColumnName("tipdjelo");

            entity.HasOne(d => d.IdautorNavigation).WithMany(p => p.Djelos)
                .HasForeignKey(d => d.Idautor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("djelo_idautor_fkey");
        });

        modelBuilder.Entity<Izlozba>(entity =>
        {
            entity.HasKey(e => e.Idizlozba).HasName("izlozba_pkey");

            entity.ToTable("izlozba");

            entity.Property(e => e.Idizlozba)
                .ValueGeneratedNever()
                .HasColumnName("idizlozba");
            entity.Property(e => e.Drzava)
                .HasMaxLength(30)
                .HasColumnName("drzava");
            entity.Property(e => e.Imegalerija)
                .HasMaxLength(30)
                .HasColumnName("imegalerija");
            entity.Property(e => e.Kraj).HasColumnName("kraj");
            entity.Property(e => e.Mjesto)
                .HasMaxLength(30)
                .HasColumnName("mjesto");
            entity.Property(e => e.Pocetak).HasColumnName("pocetak");
            entity.Property(e => e.Postbroj).HasColumnName("postbroj");
        });

        modelBuilder.Entity<Kupac>(entity =>
        {
            entity.HasKey(e => e.Idkupac).HasName("kupac_pkey");

            entity.ToTable("kupac");

            entity.Property(e => e.Idkupac)
                .ValueGeneratedNever()
                .HasColumnName("idkupac");
            entity.Property(e => e.Adresa)
                .HasMaxLength(30)
                .HasColumnName("adresa");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .HasColumnName("email");
            entity.Property(e => e.Ime)
                .HasMaxLength(20)
                .HasColumnName("ime");
            entity.Property(e => e.Korisnickoime)
                .HasMaxLength(30)
                .HasColumnName("korisnickoime");
            entity.Property(e => e.Lozinka)
                .HasMaxLength(30)
                .HasColumnName("lozinka");
            entity.Property(e => e.Mjesto)
                .HasMaxLength(30)
                .HasColumnName("mjesto");
            entity.Property(e => e.Postbroj).HasColumnName("postbroj");
            entity.Property(e => e.Prezime)
                .HasMaxLength(20)
                .HasColumnName("prezime");
            entity.Property(e => e.Telbroj)
                .HasMaxLength(20)
                .HasColumnName("telbroj");
            entity.Property(e => e.Zemlja)
                .HasMaxLength(30)
                .HasColumnName("zemlja");
        });

        modelBuilder.Entity<Ponudum>(entity =>
        {
            entity.HasKey(e => e.Idponuda).HasName("ponuda_pkey");

            entity.ToTable("ponuda");

            entity.Property(e => e.Idponuda)
                .ValueGeneratedNever()
                .HasColumnName("idponuda");
            entity.Property(e => e.Cijenaponuda).HasColumnName("cijenaponuda");
            entity.Property(e => e.Datumponuda).HasColumnName("datumponuda");
            entity.Property(e => e.Iddjelo).HasColumnName("iddjelo");
            entity.Property(e => e.Idkupac).HasColumnName("idkupac");

            entity.HasOne(d => d.IddjeloNavigation).WithMany(p => p.Ponuda)
                .HasForeignKey(d => d.Iddjelo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ponuda_iddjelo_fkey");

            entity.HasOne(d => d.IdkupacNavigation).WithMany(p => p.Ponuda)
                .HasForeignKey(d => d.Idkupac)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ponuda_idkupac_fkey");
        });

        modelBuilder.Entity<Umjizlozba>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("umjizlozba");

            entity.Property(e => e.Iddjelo).HasColumnName("iddjelo");
            entity.Property(e => e.Idizlozba).HasColumnName("idizlozba");

            entity.HasOne(d => d.IddjeloNavigation).WithMany()
                .HasForeignKey(d => d.Iddjelo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("umjizlozba_iddjelo_fkey");

            entity.HasOne(d => d.IdizlozbaNavigation).WithMany()
                .HasForeignKey(d => d.Idizlozba)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("umjizlozba_idizlozba_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
