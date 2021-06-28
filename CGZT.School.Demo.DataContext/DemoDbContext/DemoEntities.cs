using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CGZT.School.Demo.DataContext.DemoDataModels;

#nullable disable

namespace CGZT.School.Demo.DataContext.DemoDbContext
{
    public partial class DemoEntities : DbContext
    {
        public DemoEntities()
        {
        }

        public DemoEntities(DbContextOptions<DemoEntities> options)
            : base(options)
        {
        }

        public virtual DbSet<DemoTNotification> DemoTNotifications { get; set; }
        public virtual DbSet<DemoTNotificationRecipient> DemoTNotificationRecipients { get; set; }
        public virtual DbSet<DemoTStudent> DemoTStudents { get; set; }
        public virtual DbSet<DemoTTeacher> DemoTTeachers { get; set; }
        public virtual DbSet<DemoTTeacherStudentMapping> DemoTTeacherStudentMappings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("cgzt")
                .HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<DemoTNotification>(entity =>
            {
                entity.ToTable("Demo_T_Notification");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DemoTTeacherId).HasColumnName("Demo_T_TeacherId");

                entity.Property(e => e.Notification)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.HasOne(d => d.DemoTTeacher)
                    .WithMany(p => p.DemoTNotifications)
                    .HasForeignKey(d => d.DemoTTeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Demo_T_NotificationTeacherId");
            });

            modelBuilder.Entity<DemoTNotificationRecipient>(entity =>
            {
                entity.ToTable("Demo_T_NotificationRecipient");

                entity.HasIndex(e => new { e.DemoTNotificationId, e.DemoTStudentId }, "UC_NotificationRecipient")
                    .IsUnique();

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DemoTNotificationId).HasColumnName("Demo_T_NotificationId");

                entity.Property(e => e.DemoTStudentId).HasColumnName("Demo_T_StudentId");

                entity.Property(e => e.IsNotificationSent)
                    .IsRequired()
                    .HasDefaultValueSql("('false')");

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.HasOne(d => d.DemoTNotification)
                    .WithMany(p => p.DemoTNotificationRecipients)
                    .HasForeignKey(d => d.DemoTNotificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NotificationRecipientNotificationId");

                entity.HasOne(d => d.DemoTStudent)
                    .WithMany(p => p.DemoTNotificationRecipients)
                    .HasForeignKey(d => d.DemoTStudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NotificationRecipientStudentId");
            });

            modelBuilder.Entity<DemoTStudent>(entity =>
            {
                entity.ToTable("Demo_T_Student");

                entity.HasIndex(e => e.Email, "UQ__Demo_T_S__A9D10534CF72B0DE")
                    .IsUnique();

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.IsSuspend)
                    .IsRequired()
                    .HasDefaultValueSql("('false')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);
            });

            modelBuilder.Entity<DemoTTeacher>(entity =>
            {
                entity.ToTable("Demo_T_Teacher");

                entity.HasIndex(e => e.Email, "UQ__Demo_T_T__A9D10534B2C5EC6B")
                    .IsUnique();

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.IsSuspend)
                    .IsRequired()
                    .HasDefaultValueSql("('false')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);
            });

            modelBuilder.Entity<DemoTTeacherStudentMapping>(entity =>
            {
                entity.ToTable("Demo_T_TeacherStudentMapping");

                entity.HasIndex(e => new { e.DemoTTeacherId, e.DemoTStudentId }, "UC_TeacherStudentMapping")
                    .IsUnique();

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DemoTStudentId).HasColumnName("Demo_T_StudentId");

                entity.Property(e => e.DemoTTeacherId).HasColumnName("Demo_T_TeacherId");

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.HasOne(d => d.DemoTStudent)
                    .WithMany(p => p.DemoTTeacherStudentMappings)
                    .HasForeignKey(d => d.DemoTStudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeacherStudentMappingStudentId");

                entity.HasOne(d => d.DemoTTeacher)
                    .WithMany(p => p.DemoTTeacherStudentMappings)
                    .HasForeignKey(d => d.DemoTTeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeacherStudentMappingTeacherId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
