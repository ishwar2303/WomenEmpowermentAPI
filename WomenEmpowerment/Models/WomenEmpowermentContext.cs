using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WomenEmpowerment.Models
{
    public partial class WomenEmpowermentContext : DbContext
    {
        public WomenEmpowermentContext()
        {
        }

        public WomenEmpowermentContext(DbContextOptions<WomenEmpowermentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Ngo> Ngos { get; set; }
        public virtual DbSet<NgoApplication> NgoApplications { get; set; }
        public virtual DbSet<NgoContactDetail> NgoContactDetails { get; set; }
        public virtual DbSet<NgoCourse> NgoCourses { get; set; }
        public virtual DbSet<NgoDetail> NgoDetails { get; set; }
        public virtual DbSet<Trainee> Trainees { get; set; }
        public virtual DbSet<TraineeAddressDetail> TraineeAddressDetails { get; set; }
        public virtual DbSet<TraineeApplication> TraineeApplications { get; set; }
        public virtual DbSet<TraineeFamilyDetail> TraineeFamilyDetails { get; set; }
        public virtual DbSet<TraineeNgoCourse> TraineeNgoCourses { get; set; }
        public virtual DbSet<TraineePersonalDetail> TraineePersonalDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=WomenEmpowerment;User Id=sa;Password=Baisla1999@");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.HasIndex(e => e.Username, "UQ__Admin__536C85E47A2B9F52")
                    .IsUnique();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ngo>(entity =>
            {
                entity.HasIndex(e => e.Username, "UQ__Ngos__536C85E43CE3B4BF")
                    .IsUnique();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NgoApplication>(entity =>
            {
                entity.ToTable("NgoApplication");

                entity.Property(e => e.ActionDate).HasColumnType("date");

                entity.Property(e => e.RequestDate).HasColumnType("date");

                entity.HasOne(d => d.Ngo)
                    .WithMany(p => p.NgoApplications)
                    .HasForeignKey(d => d.NgoId)
                    .HasConstraintName("FK__NgoApplic__NgoId__5629CD9C");
            });

            modelBuilder.Entity<NgoContactDetail>(entity =>
            {
                entity.HasKey(e => e.NgoContactDetailsId)
                    .HasName("PK__NgoConta__8CF9F27BE375EE18");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.District)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Ngo)
                    .WithMany(p => p.NgoContactDetails)
                    .HasForeignKey(d => d.NgoId)
                    .HasConstraintName("FK__NgoContac__NgoId__534D60F1");
            });

            modelBuilder.Entity<NgoCourse>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.NgoCoursesId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Course)
                    .WithMany()
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__NgoCourse__Cours__59063A47");

                entity.HasOne(d => d.Ngo)
                    .WithMany()
                    .HasForeignKey(d => d.NgoId)
                    .HasConstraintName("FK__NgoCourse__NgoId__5812160E");
            });

            modelBuilder.Entity<NgoDetail>(entity =>
            {
                entity.HasKey(e => e.NgoDetailsId)
                    .HasName("PK__NgoDetai__932D6F9263892AF5");

                entity.HasIndex(e => e.OrganisationName, "UQ__NgoDetai__1B62E33DA5E03527")
                    .IsUnique();

                entity.HasIndex(e => e.Pan, "UQ__NgoDetai__C5709805D5343317")
                    .IsUnique();

                entity.Property(e => e.ChairmanName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.OrganisationName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Pan)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SecretaryName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Website)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Ngo)
                    .WithMany(p => p.NgoDetails)
                    .HasForeignKey(d => d.NgoId)
                    .HasConstraintName("FK__NgoDetail__NgoId__5070F446");
            });

            modelBuilder.Entity<Trainee>(entity =>
            {
                entity.HasIndex(e => e.Username, "UQ__Trainees__536C85E4BE5C991B")
                    .IsUnique();

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TraineeAddressDetail>(entity =>
            {
                entity.HasKey(e => e.AddressDetailsId)
                    .HasName("PK__TraineeA__FE78D90B711FD9C6");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.District)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.TraineeAddressDetails)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK__TraineeAd__Train__440B1D61");
            });

            modelBuilder.Entity<TraineeApplication>(entity =>
            {
                entity.ToTable("TraineeApplication");

                entity.Property(e => e.ActionDate).HasColumnType("date");

                entity.Property(e => e.RequestDate).HasColumnType("date");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.TraineeApplications)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK__TraineeAp__Train__46E78A0C");
            });

            modelBuilder.Entity<TraineeFamilyDetail>(entity =>
            {
                entity.HasKey(e => e.FamilyDetailsId)
                    .HasName("PK__TraineeF__41067C259C0CB4ED");

                entity.Property(e => e.FatherDesignation)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FatherName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.HusbandName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MotherDesignation)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MotherName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.TraineeFamilyDetails)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK__TraineeFa__Train__412EB0B6");
            });

            modelBuilder.Entity<TraineeNgoCourse>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.TraineeNgoCourseId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TraineeNgoCourseID");

                entity.HasOne(d => d.Course)
                    .WithMany()
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__TraineeNg__Cours__5CD6CB2B");

                entity.HasOne(d => d.Ngo)
                    .WithMany()
                    .HasForeignKey(d => d.NgoId)
                    .HasConstraintName("FK__TraineeNg__NgoId__5BE2A6F2");

                entity.HasOne(d => d.Trainee)
                    .WithMany()
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK__TraineeNg__Train__5AEE82B9");
            });

            modelBuilder.Entity<TraineePersonalDetail>(entity =>
            {
                entity.HasKey(e => e.PersonalDetailsId)
                    .HasName("PK__TraineeP__63B46EE6EFE7532E");

                entity.HasIndex(e => e.EmailId, "UQ__TraineeP__7ED91ACEBD3FB17C")
                    .IsUnique();

                entity.HasIndex(e => e.Aadhaar, "UQ__TraineeP__C4B333697B7DC6E1")
                    .IsUnique();

                entity.HasIndex(e => e.Pan, "UQ__TraineeP__C57098056DD7BA52")
                    .IsUnique();

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DisabilityType)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaritalStatus)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Pan)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Religion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.TraineePersonalDetails)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK__TraineePe__Train__3E52440B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
