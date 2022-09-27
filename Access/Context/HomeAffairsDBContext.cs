using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Access.Context
{
    public partial class HomeAffairsDBContext : DbContext
    {
        public HomeAffairsDBContext()
        {
        }

        public HomeAffairsDBContext(DbContextOptions<HomeAffairsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountDetail> AccountDetails { get; set; } = null!;
        public virtual DbSet<ApplicationForm> ApplicationForms { get; set; } = null!;
        public virtual DbSet<Document> Documents { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Startup.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountDetail>(entity =>
            {
                entity.HasKey(e => e.AspNetUserId)
                    .HasName("PK_App].[AccountDetails");

                entity.Property(e => e.AspNetUserId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AppliedBy)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CellNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CountryOfBirth)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstNames)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HomeTelNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.IdNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Initials)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.IsSacitizen).HasColumnName("IsSACitizen");

                entity.Property(e => e.MaidenName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MaritalStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nationality)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PhysicalCity)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhysicalComplex)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhysicalPostalCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhysicalStreetName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhysicalStreetNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhysicalSuburb)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhysicalUnitNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PlaceOfBirth)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCity)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PostalComplex)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCountryCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PostalPostalCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PostalStreetNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PostalSuburb)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PostalUnitNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.WorkTelNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ApplicationForm>(entity =>
            {
                entity.ToTable("ApplicationForm");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ApplicationStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApplicationType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AppliedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovedDate).HasColumnType("datetime");

                entity.Property(e => e.CellNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CountryOfBirth)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.DeclineMessage)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstNames)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HomeTelNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.IdNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Initials)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.IsSacitizen).HasColumnName("IsSACitizen");

                entity.Property(e => e.MaidenName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MaritalStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nationality)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PhysicalCity)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhysicalComplex)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhysicalPostalCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhysicalStreetName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhysicalStreetNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhysicalSuburb)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhysicalUnitNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PlaceOfBirth)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCity)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PostalComplex)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCountryCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PostalPostalCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PostalStreetNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PostalSuburb)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PostalUnitNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubmissionDate).HasColumnType("datetime");

                entity.Property(e => e.Surname)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.WorkTelNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.ToTable("Document");

                entity.Property(e => e.Id)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ApplicationId)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Base64String).IsUnicode(false);

                entity.Property(e => e.DateUploaded).HasColumnType("date");

                entity.Property(e => e.FileName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MimeType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
