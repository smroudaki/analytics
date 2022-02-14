using System;
using Analytics.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Analytics.Models
{
    public partial class AnalyticsContext : IdentityDbContext<ApplicationUser>
    {
        public AnalyticsContext()
        {
        }

        public AnalyticsContext(DbContextOptions<AnalyticsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Code> Code { get; set; }
        public virtual DbSet<CodeGroup> CodeGroup { get; set; }
        public virtual DbSet<IpAddress> IpAddress { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<PageVisit> PageVisit { get; set; }
        public virtual DbSet<Session> Session { get; set; }
        public virtual DbSet<Visitor> Visitor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.IsDelete)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.NationalCode)
                    .HasMaxLength(128);

                entity.Property(e => e.RegisteredDate)
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedDate)
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Code>(entity =>
            {
                entity.Property(e => e.DisplayValue)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.CodeGroup)
                    .WithMany(p => p.Code)
                    .HasForeignKey(d => d.CodeGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Code_CodeGroup");
            });

            modelBuilder.Entity<CodeGroup>(entity =>
            {
                entity.Property(e => e.DisplayKey)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<IpAddress>(entity =>
            {
                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Isp)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.RawValue).IsRequired();
            });

            modelBuilder.Entity<PageVisit>(entity =>
            {
                entity.Property(e => e.BrowserInfo).IsRequired();

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PageUrl).IsRequired();

                entity.Property(e => e.Referrer).IsRequired();

                entity.Property(e => e.UserAgent).IsRequired();

                entity.Property(e => e.WindowSize)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.BrowserCode)
                    .WithMany(p => p.PageVisitBrowserCode)
                    .HasForeignKey(d => d.BrowserCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PageVisit_Code");

                entity.HasOne(d => d.Log)
                    .WithMany(p => p.PageVisit)
                    .HasForeignKey(d => d.LogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PageVisit_Log");

                entity.HasOne(d => d.PlatformCode)
                    .WithMany(p => p.PageVisitPlatformCode)
                    .HasForeignKey(d => d.PlatformCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PageVisit_Code1");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.HasOne(d => d.Visitor)
                    .WithMany(p => p.Session)
                    .HasForeignKey(d => d.VisitorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Session_Visitor");
            });

            modelBuilder.Entity<Visitor>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IpAddress)
                    .WithMany(p => p.Visitor)
                    .HasForeignKey(d => d.IpAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Visitor_IpAddress");

                entity.HasOne(d => d.TypeCode)
                    .WithMany(p => p.Visitor)
                    .HasForeignKey(d => d.TypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Visitor_Code");
            });

            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
