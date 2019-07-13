namespace WpfApp1.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Dbmodel : DbContext
    {
        public Dbmodel()
            : base("name=Dbmodel")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(e => e.Usuario)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Senha)
                .IsUnicode(false);
        }
    }
}
