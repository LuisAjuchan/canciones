namespace Jvasquez.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MusicModel : DbContext
    {
        public MusicModel()
            : base("name=MusicModel")
        {
        }

        public virtual DbSet<Tbl_Canciones> Tbl_Canciones { get; set; }
        public virtual DbSet<Tbl_Generos> Tbl_Generos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tbl_Canciones>()
                .Property(e => e.nombreCanciones)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Canciones>()
                .Property(e => e.interprete)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Generos>()
                .Property(e => e.nombreGenero)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Generos>()
                .HasMany(e => e.Tbl_Canciones)
                .WithRequired(e => e.Tbl_Generos)
                .WillCascadeOnDelete(false);
        }
    }
}
