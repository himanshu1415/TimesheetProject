using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Timesheet.Models
{
    public partial class TimesheetDBContext : DbContext
    {
        

        public TimesheetDBContext(DbContextOptions<TimesheetDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminEmployee> AdminEmployee { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Userlogin> Userlogin { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminEmployee>(entity =>
            {
                entity.HasKey(e => e.AdminId)
                    .HasName("PK__AdminEmp__719FE4E8A4EB53B2");

                entity.Property(e => e.AdminId)
                    .HasColumnName("AdminID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AdminEmail)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AdminName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.AdminEmployee)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__AdminEmpl__Emplo__5070F446");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AdminEmployee)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__AdminEmpl__RoleI__5165187F");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeEmail)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.JoiningDate).HasColumnType("date");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Employee__RoleID__4D94879B");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__Roles__8AFACE3A322697B5");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Rolename)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Userlogin>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__Userlogi__536C85E52ADA9398");

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Userlogin)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Userlogin__RoleI__3F466844");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
