using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Agenda.agenda_tsiory;

public partial class AgendaTsioryContext : DbContext
{
    public AgendaTsioryContext()
    {
    }

    public AgendaTsioryContext(DbContextOptions<AgendaTsioryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<ReseauSociaux> ReseauSociauxes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=agenda_tsiory", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.21-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => new { e.IdContact, e.PrenomContact })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("contact");

            entity.Property(e => e.IdContact).HasColumnName("idContact");
            entity.Property(e => e.PrenomContact)
                .HasMaxLength(45)
                .HasColumnName("prenomContact");
            entity.Property(e => e.AdressContact)
                .HasMaxLength(45)
                .HasColumnName("adressContact");
            entity.Property(e => e.DateDeNaissanceContact)
                .HasMaxLength(45)
                .HasColumnName("date_de_naissanceContact");
            entity.Property(e => e.EmailContact)
                .HasMaxLength(45)
                .HasColumnName("emailContact");
            entity.Property(e => e.NomContact)
                .HasMaxLength(45)
                .HasColumnName("nomContact");
            entity.Property(e => e.PhoneContact)
                .HasMaxLength(45)
                .HasColumnName("phoneContact");
            entity.Property(e => e.SitewebContact)
                .HasMaxLength(45)
                .HasColumnName("sitewebContact");
        });

        modelBuilder.Entity<ReseauSociaux>(entity =>
        {
            entity.HasKey(e => e.IdReseauSociaux).HasName("PRIMARY");

            entity.ToTable("reseau_sociaux");

            entity.HasIndex(e => new { e.ContactIdContact, e.ContactPrenomContact }, "fk_Reseau_Sociaux_Contact_idx");

            entity.Property(e => e.IdReseauSociaux)
                .ValueGeneratedNever()
                .HasColumnName("idReseau_Sociaux");
            entity.Property(e => e.ContactIdContact).HasColumnName("Contact_idContact");
            entity.Property(e => e.ContactPrenomContact)
                .HasMaxLength(45)
                .HasColumnName("Contact_prenomContact");
            entity.Property(e => e.LiensReseauSociaux)
                .HasMaxLength(45)
                .HasColumnName("liensReseau_Sociaux");
            entity.Property(e => e.NomReseauSociaux)
                .HasMaxLength(45)
                .HasColumnName("nomReseau_Sociaux");
            entity.Property(e => e.Profil).HasMaxLength(45);
            entity.Property(e => e.ReseauReseauSociaux)
                .HasMaxLength(45)
                .HasColumnName("reseauReseau_Sociaux");

            entity.HasOne(d => d.Contact).WithMany(p => p.ReseauSociauxes)
                .HasForeignKey(d => new { d.ContactIdContact, d.ContactPrenomContact })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Reseau_Sociaux_Contact");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
