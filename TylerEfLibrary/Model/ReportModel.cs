namespace TylerEfLibrary
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Runtime.Serialization;

    public partial class ReportModel : DbContext
    {
        public ReportModel()
            : base("name=ReportModel")
        {
        }
        
        public virtual DbSet<tblCategoryType> tblCategoryTypes { get; set; }
        
        public virtual DbSet<tblConfluenceLink> tblConfluenceLinks { get; set; }
        
        public virtual DbSet<tblEmailReminder> tblEmailReminders { get; set; }
        public virtual DbSet<tblReportRole> tblReportRoles { get; set; }
        public virtual DbSet<tblReport> tblReports { get; set; }
        
        public virtual DbSet<tblReportType> tblReportTypes { get; set; }
        
        public virtual DbSet<tblReview> tblReviews { get; set; }
        public virtual DbSet<tblRole> tblRoles { get; set; }
        
        public virtual DbSet<tblState> tblStates { get; set; }
        public virtual DbSet<tblUserRole> tblUserRoles { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblCategoryType>()
                .Property(e => e.ConcurrencyID)
                .IsUnicode(false);

            modelBuilder.Entity<tblCategoryType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<tblCategoryType>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<tblCategoryType>()
                .HasMany(e => e.tblReports)
                .WithRequired(e => e.tblCategoryType)
                .HasForeignKey(e => e.CategoryTypeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblConfluenceLink>()
                .Property(e => e.text)
                .IsUnicode(false);

            modelBuilder.Entity<tblConfluenceLink>()
                .Property(e => e.link)
                .IsUnicode(false);

            modelBuilder.Entity<tblConfluenceLink>()
                .HasMany(e => e.tblReports)
                .WithRequired(e => e.tblConfluenceLink)
                .HasForeignKey(e => e.ConfluencePage)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<tblReport>()
                .Property(e => e.ReportName)
                .IsUnicode(false);

            modelBuilder.Entity<tblReport>()
                .Property(e => e.Frequency)
                .IsUnicode(false);

            modelBuilder.Entity<tblReport>()
                .Property(e => e.FileFormatType)
                .IsUnicode(false);

            modelBuilder.Entity<tblReport>()
                .Property(e => e.Website)
                .IsUnicode(false);

            modelBuilder.Entity<tblReport>()
                .Property(e => e.Notes)
                .IsUnicode(false);

            modelBuilder.Entity<tblReport>()
                .HasMany(e => e.tblEmailReminders)
                .WithOptional(e => e.tblReport)
                .HasForeignKey(e => e.reportID)
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<tblReport>()
                .HasMany(e => e.tblReportRoles)
                .WithOptional(e => e.tblReport)
                .HasForeignKey(e => e.reportId);

            modelBuilder.Entity<tblReportType>()
                .Property(e => e.ConcurrencyID)
                .IsUnicode(false);

            modelBuilder.Entity<tblReportType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<tblReportType>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<tblReportType>()
                .HasMany(e => e.tblReports)
                .WithRequired(e => e.tblReportType)
                .HasForeignKey(e => e.ReportTypeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblReview>()
                .HasMany(e => e.tblReports)
                .WithOptional(e => e.tblReview)
                .HasForeignKey(e => e.LastReviewID)
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<tblRole>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tblRole>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<tblRole>()
                .HasMany(e => e.tblReportRoles)
                .WithRequired(e => e.tblRole)
                .HasForeignKey(e => e.roleId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblRole>()
                .HasMany(e => e.tblUserRoles)
                .WithRequired(e => e.tblRole)
                .HasForeignKey(e => e.roleId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblState>()
                .Property(e => e.abbreviation)
                .IsUnicode(false);

            modelBuilder.Entity<tblState>()
                .Property(e => e.commonName)
                .IsUnicode(false);

            modelBuilder.Entity<tblState>()
                .HasMany(e => e.tblReports)
                .WithRequired(e => e.tblState)
                .HasForeignKey(e => e.State)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<tblUser>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .HasMany(e => e.tblUserRoles)
                .WithRequired(e => e.tblUser)
                .HasForeignKey(e => e.userId)
                .WillCascadeOnDelete(false);
        }
    }
}
