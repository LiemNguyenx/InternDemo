namespace DataAccess.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class dbContext : DbContext
    {
        public dbContext()
            : base("name=dbContext")
        {
        }

        public virtual DbSet<mst_customer> mst_customer { get; set; }
        public virtual DbSet<mst_mail> mst_mail { get; set; }
        public virtual DbSet<mst_system> mst_system { get; set; }
        public virtual DbSet<mst_user> mst_user { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<mst_customer>()
                .Property(e => e.code_cst)
                .IsUnicode(false);

            modelBuilder.Entity<mst_customer>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<mst_customer>()
                .Property(e => e.create_by)
                .IsUnicode(false);

            modelBuilder.Entity<mst_customer>()
                .Property(e => e.update_by)
                .IsUnicode(false);

            modelBuilder.Entity<mst_mail>()
                .Property(e => e.from_address)
                .IsUnicode(false);

            modelBuilder.Entity<mst_mail>()
                .Property(e => e.subject)
                .IsUnicode(false);

            modelBuilder.Entity<mst_mail>()
                .Property(e => e.body)
                .IsUnicode(false);

            modelBuilder.Entity<mst_mail>()
                .Property(e => e.create_by)
                .IsUnicode(false);

            modelBuilder.Entity<mst_mail>()
                .Property(e => e.update_by)
                .IsUnicode(false);

            modelBuilder.Entity<mst_system>()
                .Property(e => e.member_new)
                .IsUnicode(false);

            modelBuilder.Entity<mst_system>()
                .Property(e => e.date_modify)
                .IsUnicode(false);

            modelBuilder.Entity<mst_system>()
                .Property(e => e.admin_new)
                .IsUnicode(false);

            modelBuilder.Entity<mst_user>()
                .Property(e => e.pass_login)
                .IsUnicode(false);

            modelBuilder.Entity<mst_user>()
                .Property(e => e.loginkey)
                .IsUnicode(false);

            modelBuilder.Entity<mst_user>()
                .Property(e => e.mail)
                .IsUnicode(false);

            modelBuilder.Entity<mst_user>()
                .Property(e => e.code_cst)
                .IsUnicode(false);

            modelBuilder.Entity<mst_user>()
                .Property(e => e.create_by)
                .IsUnicode(false);

            modelBuilder.Entity<mst_user>()
                .Property(e => e.update_by)
                .IsUnicode(false);
        }
    }
}
