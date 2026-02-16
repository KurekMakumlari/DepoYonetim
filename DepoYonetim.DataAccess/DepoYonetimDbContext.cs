using System.Data.Entity;
using DepoYonetim.Models.Entities;

namespace DepoYonetim.DataAccess
{
    public class DepoYonetimDbContext : DbContext
    {
        public DepoYonetimDbContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<TblUrun> Urunler { get; set; }
        public DbSet<TblLot> Lotlar { get; set; }
        public DbSet<TblKoli> Koliler { get; set; }
        public DbSet<TblKullanici> Kullanicilar { get; set; }
        public DbSet<TblRole> Roller { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblUrun>().ToTable("Tbl_Urun").HasKey(x => x.ID);
            modelBuilder.Entity<TblLot>().ToTable("Tbl_Lot").HasKey(x => x.ID);
            modelBuilder.Entity<TblKoli>().ToTable("Tbl_Koli").HasKey(x => x.Id);
            modelBuilder.Entity<TblKullanici>().ToTable("Tbl_Kullanici").HasKey(x => x.ID);
            modelBuilder.Entity<TblRole>().ToTable("Tbl_Role").HasKey(x => x.ID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
