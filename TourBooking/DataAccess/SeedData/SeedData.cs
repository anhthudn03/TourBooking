using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SeedData
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Users
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, TenDangNHap = "admin", MatKhau = "admin123", Email = "admin@example.com", ChucVu = "User", NgayTao = DateTime.Now, NgaySua = DateTime.Now, HoVaTen = "User User", NgaySinh = new DateTime(1990, 1, 1), DiaChi = "123 User St", SDT = "1234567890", TrangThai = "Active" },
                new User { Id = 2, TenDangNHap = "user1", MatKhau = "user123", Email = "user1@example.com", ChucVu = "User", NgayTao = DateTime.Now, NgaySua = DateTime.Now, HoVaTen = "Regular User", NgaySinh = new DateTime(1995, 5, 15), DiaChi = "456 User Ave", SDT = "9876543210", TrangThai = "Active" },
                new User { Id = 3, TenDangNHap = "guide1", MatKhau = "guide123", Email = "guide1@example.com", ChucVu = "Guide", NgayTao = DateTime.Now, NgaySua = DateTime.Now, HoVaTen = "Tour Guide", NgaySinh = new DateTime(1988, 10, 20), DiaChi = "789 Guide Rd", SDT = "5555555555", TrangThai = "Active" }
            );

            // Locations
            modelBuilder.Entity<DiaDiem>().HasData(
                new DiaDiem { Id = 1, NguoiTao = 1, TenDiaDiem = "Paris", DiaChi = "Paris, France", MoTa = "City of Love", NgayTao = DateTime.Now, NgaySua = DateTime.Now, TrangThai = "Active" },
                new DiaDiem { Id = 2, NguoiTao = 1, TenDiaDiem = "Tokyo", DiaChi = "Tokyo, Japan", MoTa = "Vibrant Metropolis", NgayTao = DateTime.Now, NgaySua = DateTime.Now, TrangThai = "Active" },
                new DiaDiem { Id = 3, NguoiTao = 1, TenDiaDiem = "New York", DiaChi = "New York, USA", MoTa = "The Big Apple", NgayTao = DateTime.Now, NgaySua = DateTime.Now, TrangThai = "Active" }
            );

            // Tours
            modelBuilder.Entity<Tour>().HasData(
                new Tour { Id = 1, KhachSanId = 1, NguoiTao = 1, LoaiTuorId = 1, TenTour = "Eiffel Tower Adventure", MoTa = "Explore the iconic Eiffel Tower", GiaTour = 100, SoNgay = "1", NgayTao = DateTime.Now, NgaySua = DateTime.Now, NgayKhoiHanh = DateTime.Now.AddDays(30), TrangThai = "Available" },
                new Tour { Id = 2, KhachSanId = 2, NguoiTao = 1, LoaiTuorId = 2, TenTour = "Tokyo Sushi Experience", MoTa = "Taste the best sushi in Tokyo", GiaTour = 150, SoNgay = "2", NgayTao = DateTime.Now, NgaySua = DateTime.Now, NgayKhoiHanh = DateTime.Now.AddDays(45), TrangThai = "Available" },
                new Tour { Id = 3, KhachSanId = 3, NguoiTao = 1, LoaiTuorId = 3, TenTour = "NYC Broadway Show", MoTa = "Enjoy a Broadway musical in New York", GiaTour = 200, SoNgay = "3", NgayTao = DateTime.Now, NgaySua = DateTime.Now, NgayKhoiHanh = DateTime.Now.AddDays(60), TrangThai = "Available" }
            );

            // TourLocations
            modelBuilder.Entity<DiaDiemTour>().HasData(
                new DiaDiemTour { Id = 1, TourId = 1, DiaDiemId = 1,TrangThai = "ACTIVE" },
                new DiaDiemTour { Id = 2, TourId = 2, DiaDiemId = 2, TrangThai = "ACTIVE" },
                new DiaDiemTour { Id = 3, TourId = 3, DiaDiemId = 3, TrangThai = "ACTIVE" }
            );

            // TourImages
            modelBuilder.Entity<HinhTour>().HasData(
                new HinhTour { Id = 1, TourId = 1, Url = "https://example.com/eiffel.jpg"},
                new HinhTour {Id = 2, TourId = 2, Url = "https://example.com/sushi.jpg" },
                new HinhTour {Id = 3, TourId = 3, Url = "https://example.com/broadway.jpg" }
            );

            // Bookings
            modelBuilder.Entity<GioHang>().HasData(
                new GioHang { Id = 1, UserId = 2, TourId = 1, TrangThai = "Confirmed", NgayTao = DateTime.Now, NgaySua = DateTime.Now },
                new GioHang { Id = 2, UserId = 2, TourId = 2, TrangThai = "Pending", NgayTao = DateTime.Now, NgaySua = DateTime.Now },
                new GioHang { Id = 3, UserId = 3, TourId = 3, TrangThai = "Confirmed", NgayTao = DateTime.Now, NgaySua = DateTime.Now }
            );

            // TourGuides
            modelBuilder.Entity<HuongDanVien>().HasData(
                new HuongDanVien { Id = 1, HoVaTen = "John Doe", SDT = "1112223333", Email = "john@example.com", NgayTao = DateTime.Now, NgaySua = DateTime.Now,  TrangThai = "Available" },
                new HuongDanVien { Id = 2, HoVaTen = "Jane Smith", SDT = "4445556666", Email = "jane@example.com", NgayTao = DateTime.Now, NgaySua = DateTime.Now, TrangThai = "Available" },
                new HuongDanVien { Id = 3, HoVaTen = "Mike Johnson", SDT = "7778889999", Email = "mike@example.com", NgayTao = DateTime.Now, NgaySua = DateTime.Now, TrangThai = "Busy" }
            );

            // Hotels
            modelBuilder.Entity<KhachSan>().HasData(
                new KhachSan { Id = 1, TenKhachSan = "Luxury Paris KhachSan", DiaChi = "1 Champs-Élysées, Paris", NguoiTao = 1, MoTa = "5-star hotel in the heart of Paris", SoPhong = 200, NgayTao = DateTime.Now, NgaySua = DateTime.Now, TrangThai = "Open" },
                new KhachSan { Id = 2, TenKhachSan = "Tokyo Skyline KhachSan", DiaChi = "1-1-1 Shibuya, Tokyo", NguoiTao = 1, MoTa = "Modern hotel with a view of Tokyo skyline", SoPhong = 300, NgayTao = DateTime.Now, NgaySua = DateTime.Now, TrangThai = "Open" },
                new KhachSan { Id = 3, TenKhachSan = "New York Plaza", DiaChi = "5th Avenue, New York", NguoiTao = 1, MoTa = "Iconic New York hotel", SoPhong = 400, NgayTao = DateTime.Now, NgaySua = DateTime.Now, TrangThai = "Open" }
            );

            // HotelImages
            modelBuilder.Entity<HinhKhachSan>().HasData(
                new HinhKhachSan {Id = 1, KhachSanId = 1, Url = "https://example.com/paris_hotel.jpg" },
                new HinhKhachSan {Id = 2, KhachSanId = 2, Url = "https://example.com/tokyo_hotel.jpg" },
                new HinhKhachSan
                {
                    Id = 3,
                    KhachSanId = 3,
                    
                    Url = "https://example.com/nyc"
                });
            modelBuilder.Entity<LoaiTour>().HasData(
           new LoaiTour
           {
               Id = 1,
               Ten = "Adventure Tours",
               NgayTao = DateTime.Now,
               NgaySua = DateTime.Now,
               TrangThai = "Active"
           },
           new LoaiTour
           {
               Id = 2,
               Ten = "Cultural Tours",
               NgayTao = DateTime.Now,
               NgaySua = DateTime.Now,
               TrangThai = "Active"
           },
           new LoaiTour
           {
               Id = 3,
               Ten = "Beach Vacations",
               NgayTao = DateTime.Now,
               NgaySua = DateTime.Now,
               TrangThai = "Active"
           },
           new LoaiTour
           {
               Id = 4,
               Ten = "City Breaks",
               NgayTao = DateTime.Now,
               NgaySua = DateTime.Now,
               TrangThai = "Active"
           }
       );
        }
    }
}

