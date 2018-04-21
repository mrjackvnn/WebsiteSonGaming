namespace Model.Framework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SonGamingDbContext : DbContext
    {
        public SonGamingDbContext()
            : base("name=SonGamingDbContext")
        {
        }

        public virtual DbSet<ACCOUNT> ACCOUNT { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.password )
                .IsUnicode(false);
        }
    }
}
