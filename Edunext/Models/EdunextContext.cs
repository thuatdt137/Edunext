using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Edunext.Models;

public partial class EdunextContext : DbContext
{
    public EdunextContext()
    {
    }

    public EdunextContext(DbContextOptions<EdunextContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Assignment> Assignments { get; set; }

    public virtual DbSet<AssignmentSubmission> AssignmentSubmissions { get; set; }

    public virtual DbSet<ClassEnrollment> ClassEnrollments { get; set; }

    public virtual DbSet<ClassSlotContent> ClassSlotContents { get; set; }

    public virtual DbSet<Classroom> Classrooms { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Slot> Slots { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=Edunext;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assignment>(entity =>
        {
            entity.HasKey(e => e.AssignmentId).HasName("PK__assignme__DA8918149919EB8D");

            entity.ToTable("assignments");

            entity.Property(e => e.AssignmentId).HasColumnName("assignment_id");
            entity.Property(e => e.ClassSlotId).HasColumnName("class_slot_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.Status)
                .HasDefaultValue(true)
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");

            entity.HasOne(d => d.ClassSlot).WithMany(p => p.Assignments)
                .HasForeignKey(d => d.ClassSlotId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__assignmen__class__5535A963");
        });

        modelBuilder.Entity<AssignmentSubmission>(entity =>
        {
            entity.HasKey(e => e.SubmissionId).HasName("PK__assignme__9B53559592D3C123");

            entity.ToTable("assignment_submissions");

            entity.Property(e => e.SubmissionId).HasColumnName("submission_id");
            entity.Property(e => e.AssignmentId).HasColumnName("assignment_id");
            entity.Property(e => e.Feedback).HasColumnName("feedback");
            entity.Property(e => e.FileLink)
                .HasMaxLength(255)
                .HasColumnName("file_link");
            entity.Property(e => e.Grade)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("grade");
            entity.Property(e => e.SubmissionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("submission_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Assignment).WithMany(p => p.AssignmentSubmissions)
                .HasForeignKey(d => d.AssignmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__assignmen__assig__59063A47");

            entity.HasOne(d => d.User).WithMany(p => p.AssignmentSubmissions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__assignmen__user___59FA5E80");
        });

        modelBuilder.Entity<ClassEnrollment>(entity =>
        {
            entity.HasKey(e => e.EnrollmentId).HasName("PK__class_en__6D24AA7A9E6BC9DA");

            entity.ToTable("class_enrollments");

            entity.Property(e => e.EnrollmentId).HasColumnName("enrollment_id");
            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.EnrollmentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("enrollment_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Class).WithMany(p => p.ClassEnrollments)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__class_enr__class__4222D4EF");

            entity.HasOne(d => d.User).WithMany(p => p.ClassEnrollments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__class_enr__user___4316F928");
        });

        modelBuilder.Entity<ClassSlotContent>(entity =>
        {
            entity.HasKey(e => e.ClassSlotId).HasName("PK__class_sl__D3C5C607CDFFC6B0");

            entity.ToTable("class_slot_contents");

            entity.Property(e => e.ClassSlotId).HasColumnName("class_slot_id");
            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.SlotId).HasColumnName("slot_id");

            entity.HasOne(d => d.Class).WithMany(p => p.ClassSlotContents)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__class_slo__class__48CFD27E");

            entity.HasOne(d => d.Slot).WithMany(p => p.ClassSlotContents)
                .HasForeignKey(d => d.SlotId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__class_slo__slot___49C3F6B7");
        });

        modelBuilder.Entity<Classroom>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__classroo__FDF4798686519007");

            entity.ToTable("classrooms");

            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.ClassName)
                .HasMaxLength(255)
                .HasColumnName("class_name");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.SemesterId).HasColumnName("semester_id");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

            entity.HasOne(d => d.Course).WithMany(p => p.Classrooms)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__classroom__cours__3D5E1FD2");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Classrooms)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__classroom__teach__3E52440B");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__comments__E7957687F24BEE12");

            entity.ToTable("comments");

            entity.Property(e => e.CommentId).HasColumnName("comment_id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Question).WithMany(p => p.Comments)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__comments__questi__5070F446");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__comments__user_i__5165187F");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__courses__8F1EF7AE6535509B");

            entity.ToTable("courses");

            entity.HasIndex(e => e.CourseCode, "UQ__courses__AB6B45F103E2EF26").IsUnique();

            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.CourseCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("course_code");
            entity.Property(e => e.CourseName)
                .HasMaxLength(255)
                .HasColumnName("course_name");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK__question__2EC21549DC7B11A8");

            entity.ToTable("questions");

            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.ClassSlotId).HasColumnName("class_slot_id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.FromTime)
                .HasColumnType("datetime")
                .HasColumnName("from_time");
            entity.Property(e => e.Status)
                .HasDefaultValue(true)
                .HasColumnName("status");
            entity.Property(e => e.ToTime)
                .HasColumnType("datetime")
                .HasColumnName("to_time");

            entity.HasOne(d => d.ClassSlot).WithMany(p => p.Questions)
                .HasForeignKey(d => d.ClassSlotId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__questions__class__4D94879B");
        });

        modelBuilder.Entity<Slot>(entity =>
        {
            entity.HasKey(e => e.SlotId).HasName("PK__slots__971A01BB20D271D5");

            entity.ToTable("slots");

            entity.Property(e => e.SlotId).HasColumnName("slot_id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.SlotName)
                .HasMaxLength(255)
                .HasColumnName("slot_name");
            entity.Property(e => e.SlotOrder).HasColumnName("slot_order");

            entity.HasOne(d => d.Course).WithMany(p => p.Slots)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__slots__course_id__45F365D3");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__users__B9BE370FA00220FC");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "UQ__users__AB6E6164F23AD1D8").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.Status)
                .HasDefaultValue(true)
                .HasColumnName("status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
