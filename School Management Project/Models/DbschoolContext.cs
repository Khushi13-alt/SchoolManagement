using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace School_Management_Project.Models;

public partial class DbschoolContext : DbContext
{
    public DbschoolContext()
    {
    }

    public DbschoolContext(DbContextOptions<DbschoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblLanguage> TblLanguages { get; set; }

    public virtual DbSet<TblStudent> TblStudents { get; set; }

    public virtual DbSet<TblSubject> TblSubjects { get; set; }

    public virtual DbSet<TblSubjectLanguage> TblSubjectLanguages { get; set; }

    public virtual DbSet<TblTeacher> TblTeachers { get; set; }

    public virtual DbSet<TeacherSubject> TeacherSubjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-7QO2PMK; database=dbschool; Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblLanguage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Lang__3214EC0759AA4292");

            entity.ToTable("tbl_Languages");

            entity.HasIndex(e => e.Name, "UQ__tbl_Lang__737584F6BCB51DEE").IsUnique();

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblStudent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Stud__3214EC072E022BAE");

            entity.ToTable("tbl_Students");

            entity.HasIndex(e => e.Rollnumber, "UQ__tbl_Stud__EBE41F7A1DB7C7F2").IsUnique();

            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Class)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("class");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Rollnumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("rollnumber");
        });

        modelBuilder.Entity<TblSubject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Subj__3214EC0774AE64E7");

            entity.ToTable("tbl_Subjects");

            entity.Property(e => e.Class)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("class");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TblSubjects)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__tbl_Subje__teach__47DBAE45");
        });

        modelBuilder.Entity<TblSubjectLanguage>(entity =>
        {
            entity.HasKey(e => e.SubjectLanguageId).HasName("PK__tbl_Subj__5A549022AD9FB37E");

            entity.ToTable("tbl_SubjectLanguages");

            entity.Property(e => e.SubjectLanguageId).HasColumnName("SubjectLanguageID");
            entity.Property(e => e.LanguageId).HasColumnName("Language_id");
            entity.Property(e => e.SubjectId).HasColumnName("Subject_id");

            entity.HasOne(d => d.Language).WithMany(p => p.TblSubjectLanguages)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbl_Subje__Langu__4CA06362");

            entity.HasOne(d => d.Subject).WithMany(p => p.TblSubjectLanguages)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbl_Subje__Subje__4D94879B");
        });

        modelBuilder.Entity<TblTeacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Teac__3213E83FD1F8C5E3");

            entity.ToTable("tbl_Teachers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Sex)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("sex");
        });

        modelBuilder.Entity<TeacherSubject>(entity =>
        {
            entity.HasKey(e => e.TeacherSubjectId).HasName("PK__TeacherS__FB4DA4262BE799C6");

            entity.Property(e => e.TeacherSubjectId).HasColumnName("TeacherSubjectID");
            entity.Property(e => e.SubjectId).HasColumnName("SubjectID");
            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

            entity.HasOne(d => d.Subject).WithMany(p => p.TeacherSubjects)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__TeacherSu__Subje__48CFD27E");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TeacherSubjects)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__TeacherSu__Teach__49C3F6B7");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
