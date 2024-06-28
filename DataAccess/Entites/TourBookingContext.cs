using DataAccess.Entites;
using DataAccess.SeedData;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class TourBookingContext : DbContext
    {
        public TourBookingContext(DbContextOptions<TourBookingContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; } = null!;

        public DbSet<GioHang> GioHang { get; set; }
        public DbSet<Ve> Ve { get; set; }
        public DbSet<HuongDanVien> HuongDanVien { get; set; }
        public DbSet<Tour> Tour { get; set; }
        public DbSet<DiaDiem> DiaDiem { get; set; }
        public DbSet<LoaiTour> LoaiTour { get; set; }
        public DbSet<KhachSan> KhachSan { get; set; }
        public DbSet<HinhTour> HinhTour { get; set; }
        public DbSet<HinhKhachSan> HinhKhachSan { get; set; }
        public DbSet<DiaDiemTour> DiaDiemTour { get; set; }
        public DbSet<ChiTietTour> ChiTietTour { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   // Configure foreign keys with no cascade delete

            modelBuilder.Entity<GioHang>()
                .HasOne(b => b.User)
                .WithMany()
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Tour>()
                .HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.NguoiTao)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Tour>()
            .HasOne(t => t.ChiTietTour)
            .WithOne(td => td.Tour)
            .HasForeignKey<ChiTietTour>(td => td.TourId)
            .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<DiaDiemTour>()
                .HasOne(tl => tl.Tour)
                .WithMany()
                .HasForeignKey(tl => tl.TourId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<DiaDiemTour>()
                .HasOne(tl => tl.DiaDiem)
                .WithMany()
                .HasForeignKey(tl => tl.DiaDiemId)
                .OnDelete(DeleteBehavior.Restrict);
            // Cấu hình mối quan hệ một-nhiều giữa User và Ve
            modelBuilder.Entity<Ve>()
                .HasOne(v => v.User)
                .WithMany() // Không cần khai báo collection
                .HasForeignKey(v => v.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Cấu hình mối quan hệ một-nhiều giữa Tour và Ve
            modelBuilder.Entity<Ve>()
                .HasOne(v => v.Tour)
                .WithMany() // Không cần khai báo collection
                .HasForeignKey(v => v.TourId)
                .OnDelete(DeleteBehavior.Restrict);
            // Cấu hình mối quan hệ một-nhiều giữa Ve và TourGuide mà không cần ICollection<TourGuide>
            modelBuilder.Entity<HuongDanVien>()
                .HasOne(tg => tg.Ve)
                .WithMany()
                .HasForeignKey(tg => tg.VeId)
                .OnDelete(DeleteBehavior.Restrict);
            // Định nghĩa mối quan hệ giữa User và RefreshToken
            modelBuilder.Entity<RefreshToken>()
                .HasOne(rt => rt.User)
                .WithMany() // Không cần thuộc tính điều hướng
                .HasForeignKey(rt => rt.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Seed();
        }
    }
}
