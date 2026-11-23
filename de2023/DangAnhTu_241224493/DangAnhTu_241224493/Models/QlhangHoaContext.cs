using Microsoft.EntityFrameworkCore;

namespace DangAnhTu_241224493.Models
{
    public partial class QlhangHoaContext : DbContext
    {
        public QlhangHoaContext()
        {
        }

        public QlhangHoaContext(DbContextOptions<QlhangHoaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HangHoa> HangHoas { get; set; }
        public virtual DbSet<LoaiHang> LoaiHangs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=QLHangHoa;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoaiHang>(entity =>
            {
                entity.HasKey(e => e.MaLoai);
                entity.ToTable("LoaiHang");
                entity.Property(e => e.TenLoai).HasMaxLength(50);
            });

            modelBuilder.Entity<HangHoa>(entity =>
            {
                entity.HasKey(e => e.MaHang);
                entity.ToTable("HangHoa");
                entity.Property(e => e.TenHang).HasMaxLength(50);
                entity.Property(e => e.Anh).HasMaxLength(100);
                entity.Property(e => e.Gia).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.MaLoaiNavigation)
                    .WithMany(p => p.HangHoas)
                    .HasForeignKey(d => d.MaLoai)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}