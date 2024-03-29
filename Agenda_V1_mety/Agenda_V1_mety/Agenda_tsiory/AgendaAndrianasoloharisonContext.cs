using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Agenda_V1_mety.Agenda_tsiory;

public partial class AgendaAndrianasoloharisonContext : DbContext
{
    public AgendaAndrianasoloharisonContext()
    {
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
    public object ReseauSociaux { get; internal set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=172.31.69.115;port=3306;user=tsiory;password=1234;database=agenda_andrianasoloharison", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.2.0-mysql"));
        //=> optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=agenda_andrianasoloharison", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.2.0-mysql"));



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
                .HasColumnType("enum('Amis','Collegue')")
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
            entity.Property(e => e.ReseauSociau)
                .HasMaxLength(45)
                .HasColumnName("Reseau_sociaux");

            entity.HasOne(d => d.ContactIdcontactNavigation).WithMany(p => p.ReseauSociaux)
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
            entity.HasKey(e => new { e.Idtask, e.TodolistIdtodolist, e.TodolistContactIdcontact })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("task");

            entity.HasIndex(e => new { e.TodolistIdtodolist, e.TodolistContactIdcontact }, "fk_task_todolist1_idx");

            entity.Property(e => e.Idtask)
                .ValueGeneratedOnAdd()
                .HasColumnName("idtask");
            entity.Property(e => e.TodolistIdtodolist).HasColumnName("todolist_idtodolist");
            entity.Property(e => e.TodolistContactIdcontact).HasColumnName("todolist_contact_idcontact");
            entity.Property(e => e.Description)
                .HasMaxLength(45)
                .HasColumnName("description");
            entity.Property(e => e.Nomtask)
                .HasMaxLength(45)
                .HasColumnName("nomtask");

            entity.HasOne(d => d.Todolist).WithMany(p => p.Tasks)
                .HasForeignKey(d => new { d.TodolistIdtodolist, d.TodolistContactIdcontact })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_task_todolist1");
        });

        modelBuilder.Entity<Todolist>(entity =>
        {
            entity.HasKey(e => new { e.Idtodolist, e.ContactIdcontact })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("todolist");

            entity.HasIndex(e => e.ContactIdcontact, "fk_todolist_contact1_idx");

            entity.Property(e => e.Idtodolist)
                .ValueGeneratedOnAdd()
                .HasColumnName("idtodolist");
            entity.Property(e => e.ContactIdcontact).HasColumnName("contact_idcontact");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Descriptionl)
                .HasMaxLength(45)
                .HasColumnName("descriptionl");

            entity.HasOne(d => d.ContactIdcontactNavigation).WithMany(p => p.Todolists)
                .HasForeignKey(d => d.ContactIdcontact)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_todolist_contact1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
