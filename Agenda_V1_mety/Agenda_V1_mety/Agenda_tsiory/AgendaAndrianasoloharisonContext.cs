using System;
using System.Collections.Generic;
using Agenda_V1_mety.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Agenda_V1_mety.Service.DAO;

namespace Agenda_V1_mety.Agenda_tsiory;

public partial class AgendaAndrianasoloharisonContext : DbContext
{
    //method to get the connection string je supprime si ça marche pas

    ConnectionString_Manager _connectionString_Manager;

    public AgendaAndrianasoloharisonContext()
    {
        _connectionString_Manager = new ConnectionString_Manager();
    }

    public AgendaAndrianasoloharisonContext(DbContextOptions<AgendaAndrianasoloharisonContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Profilsreseau> Profilsreseaus { get; set; }

    public virtual DbSet<ReseauSociaux> ReseauSociauxes { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<Todolist> Todolists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //connection en local
    => optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=agenda_andrianasoloharison", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.2.0-mysql"));
    //connection à distance
    //        => optionsBuilder.UseMySql("server=172.31.69.115;port=3306;user=tsiory;password=1234;database=agenda_andrianasoloharison", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.2.0-mysql"));

    //Protection des informations sensibles dans la connexion string
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    if (!optionsBuilder.IsConfigured)
    //    {
    //        optionsBuilder.UseMySql(_connectionString_Manager.ConString, Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.26-mysql"));
    //    }
    //}


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Idcontact).HasName("PRIMARY");

            entity.ToTable("contact");

            entity.Property(e => e.Idcontact).HasColumnName("idcontact");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Datenaissance).HasColumnName("datenaissance");
            entity.Property(e => e.Email).HasMaxLength(45);
            entity.Property(e => e.Nom)
                .HasMaxLength(45)
                .HasColumnName("nom");
            entity.Property(e => e.Phone).HasMaxLength(45);
            entity.Property(e => e.Prenom)
                .HasMaxLength(45)
                .HasColumnName("prenom");
            entity.Property(e => e.Reseau).HasMaxLength(45);
            entity.Property(e => e.Sexe)
                .HasColumnType("enum('Masculin','Feminin')")
                .HasColumnName("sexe");
            entity.Property(e => e.Statut)
                .HasColumnType("enum('Amis','Collegue','Famille')")
                .HasColumnName("statut");
            entity.Property(e => e.Ville).HasMaxLength(45);
        });

        modelBuilder.Entity<Profilsreseau>(entity =>
        {
            entity.HasKey(e => e.Idprofilsreseau).HasName("PRIMARY");

            entity.ToTable("profilsreseau");

            entity.HasIndex(e => e.ReseauSociauxIdreseauSociaux, "fk_profilsreseau_reseau_sociaux1_idx");

            entity.Property(e => e.Idprofilsreseau).HasColumnName("idprofilsreseau");
            entity.Property(e => e.Datecreation).HasColumnName("datecreation");
            entity.Property(e => e.Namereseau)
                .HasMaxLength(45)
                .HasColumnName("namereseau");
            entity.Property(e => e.ReseauSociauxIdreseauSociaux).HasColumnName("reseau_sociaux_idreseau_sociaux");

            entity.HasOne(d => d.ReseauSociauxIdreseauSociauxNavigation).WithMany(p => p.Profilsreseaus)
                .HasForeignKey(d => d.ReseauSociauxIdreseauSociaux)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_profilsreseau_reseau_sociaux1");
        });

        modelBuilder.Entity<ReseauSociaux>(entity =>
        {
            entity.HasKey(e => e.IdreseauSociaux).HasName("PRIMARY");

            entity.ToTable("reseau_sociaux");

            entity.HasIndex(e => e.ContactIdcontact, "fk_reseau_sociaux_contact1_idx");

            entity.Property(e => e.IdreseauSociaux).HasColumnName("idreseau_sociaux");
            entity.Property(e => e.ContactIdcontact).HasColumnName("contact_idcontact");
            entity.Property(e => e.Liens).HasMaxLength(45);
            entity.Property(e => e.Profil).HasMaxLength(45);
            entity.Property(e => e.ReseauSociaux1)
                .HasMaxLength(45)
                .HasColumnName("Reseau_sociaux");

            entity.HasOne(d => d.ContactIdcontactNavigation).WithMany(p => p.ReseauSociauxes)
                .HasForeignKey(d => d.ContactIdcontact)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_reseau_sociaux_contact1");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => new { e.IdStatus, e.ContactIdcontact, e.ContactIdcontact1 })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("status");

            entity.HasIndex(e => e.ContactIdcontact1, "fk_Status_contact_idx");

            entity.Property(e => e.IdStatus)
                .ValueGeneratedOnAdd()
                .HasColumnName("idStatus");
            entity.Property(e => e.ContactIdcontact).HasColumnName("contact_idcontact");
            entity.Property(e => e.ContactIdcontact1).HasColumnName("contact_idcontact1");
            entity.Property(e => e.Status1)
                .HasMaxLength(45)
                .HasColumnName("Status");

            entity.HasOne(d => d.ContactIdcontact1Navigation).WithMany(p => p.Statuses)
                .HasForeignKey(d => d.ContactIdcontact1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Status_contact");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Idtask).HasName("PRIMARY");

            entity.ToTable("task");

            entity.HasIndex(e => e.TodolistIdtodolist, "fk_task_todolist1_idx");

            entity.Property(e => e.Idtask).HasColumnName("idtask");
            entity.Property(e => e.Description)
                .HasMaxLength(45)
                .HasColumnName("description");
            entity.Property(e => e.Nomtask)
                .HasMaxLength(45)
                .HasColumnName("nomtask");
            entity.Property(e => e.TodolistIdtodolist).HasColumnName("todolist_idtodolist");

            entity.HasOne(d => d.TodolistIdtodolistNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.TodolistIdtodolist)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_task_todolist1");
        });

        modelBuilder.Entity<Todolist>(entity =>
        {
            entity.HasKey(e => e.Idtodolist).HasName("PRIMARY");

            entity.ToTable("todolist");

            entity.Property(e => e.Idtodolist).HasColumnName("idtodolist");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Descriptionl)
                .HasMaxLength(45)
                .HasColumnName("descriptionl");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
