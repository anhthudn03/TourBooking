using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class adddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoaiTour",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiSua = table.Column<int>(type: "int", nullable: false),
                    NguoiTao = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiTour", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDangNHap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChucVu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoVaTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiaDiem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NguoiTao = table.Column<int>(type: "int", nullable: false),
                    NguoiSua = table.Column<int>(type: "int", nullable: false),
                    TenDiaDiem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaDiem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiaDiem_User_NguoiTao",
                        column: x => x.NguoiTao,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KhachSan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhachSan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTao = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiSua = table.Column<int>(type: "int", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoPhong = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachSan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KhachSan_User_NguoiTao",
                        column: x => x.NguoiTao,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    RefreshTokenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssuedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpriedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JwtId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.RefreshTokenId);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HinhKhachSan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KhachSanId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HinhKhachSan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HinhKhachSan_KhachSan_KhachSanId",
                        column: x => x.KhachSanId,
                        principalTable: "KhachSan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tour",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KhachSanId = table.Column<int>(type: "int", nullable: false),
                    NguoiTao = table.Column<int>(type: "int", nullable: false),
                    NguoiSua = table.Column<int>(type: "int", nullable: false),
                    LoaiTuorId = table.Column<int>(type: "int", nullable: false),
                    NgayKhoiHanh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenTour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaTour = table.Column<double>(type: "float", nullable: false),
                    SoNgay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tour_KhachSan_KhachSanId",
                        column: x => x.KhachSanId,
                        principalTable: "KhachSan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tour_LoaiTour_LoaiTuorId",
                        column: x => x.LoaiTuorId,
                        principalTable: "LoaiTour",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tour_User_NguoiTao",
                        column: x => x.NguoiTao,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietTour",
                columns: table => new
                {
                    TourId = table.Column<int>(type: "int", nullable: false),
                    SoLuongNguoi = table.Column<int>(type: "int", nullable: false),
                    SoLuongTrong = table.Column<int>(type: "int", nullable: false),
                    NoiKhoiHanh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhuongTien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TongGia = table.Column<double>(type: "float", nullable: false),
                    GiaMoiNguoi = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietTour", x => x.TourId);
                    table.ForeignKey(
                        name: "FK_ChiTietTour_Tour_TourId",
                        column: x => x.TourId,
                        principalTable: "Tour",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DiaDiemTour",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaDiemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaDiemTour", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiaDiemTour_DiaDiem_DiaDiemId",
                        column: x => x.DiaDiemId,
                        principalTable: "DiaDiem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiaDiemTour_Tour_TourId",
                        column: x => x.TourId,
                        principalTable: "Tour",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GioHang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GioHang_Tour_TourId",
                        column: x => x.TourId,
                        principalTable: "Tour",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GioHang_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HinhTour",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HinhTour", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HinhTour_Tour_TourId",
                        column: x => x.TourId,
                        principalTable: "Tour",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ve",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    NguoiSua = table.Column<int>(type: "int", nullable: true),
                    SoNguoi = table.Column<int>(type: "int", nullable: false),
                    HoVaTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PTTT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayDat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TongTien = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ve", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ve_Tour_TourId",
                        column: x => x.TourId,
                        principalTable: "Tour",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ve_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HuongDanVien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoVaTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiSua = table.Column<int>(type: "int", nullable: false),
                    NguoiTao = table.Column<int>(type: "int", nullable: false),
                    VeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HuongDanVien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HuongDanVien_Ve_VeId",
                        column: x => x.VeId,
                        principalTable: "Ve",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "HuongDanVien",
                columns: new[] { "Id", "Email", "HoVaTen", "NgaySua", "NgayTao", "NguoiSua", "NguoiTao", "SDT", "TrangThai", "VeId" },
                values: new object[,]
                {
                    { 1, "john@example.com", "John Doe", new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(425), new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(424), 0, 0, "1112223333", "Available", null },
                    { 2, "jane@example.com", "Jane Smith", new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(429), new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(428), 0, 0, "4445556666", "Available", null },
                    { 3, "mike@example.com", "Mike Johnson", new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(432), new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(431), 0, 0, "7778889999", "Busy", null }
                });

            migrationBuilder.InsertData(
                table: "LoaiTour",
                columns: new[] { "Id", "NgaySua", "NgayTao", "NguoiSua", "NguoiTao", "Ten", "TrangThai" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(527), new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(526), 0, 0, "Adventure Tours", "Active" },
                    { 2, new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(530), new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(529), 0, 0, "Cultural Tours", "Active" },
                    { 3, new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(532), new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(532), 0, 0, "Beach Vacations", "Active" },
                    { 4, new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(535), new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(534), 0, 0, "City Breaks", "Active" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "ChucVu", "DiaChi", "Email", "HoVaTen", "MatKhau", "NgaySinh", "NgaySua", "NgayTao", "SDT", "TenDangNHap", "TrangThai" },
                values: new object[,]
                {
                    { 1, "User", "123 User St", "admin@example.com", "User User", "admin123", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(13), new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(2), "1234567890", "admin", "Active" },
                    { 2, "User", "456 User Ave", "user1@example.com", "Regular User", "user123", new DateTime(1995, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(20), new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(19), "9876543210", "user1", "Active" },
                    { 3, "Guide", "789 Guide Rd", "guide1@example.com", "Tour Guide", "guide123", new DateTime(1988, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(24), new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(23), "5555555555", "guide1", "Active" }
                });

            migrationBuilder.InsertData(
                table: "DiaDiem",
                columns: new[] { "Id", "DiaChi", "MoTa", "NgaySua", "NgayTao", "NguoiSua", "NguoiTao", "TenDiaDiem", "TrangThai" },
                values: new object[,]
                {
                    { 1, "Paris, France", "City of Love", new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(246), new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(245), 0, 1, "Paris", "Active" },
                    { 2, "Tokyo, Japan", "Vibrant Metropolis", new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(250), new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(249), 0, 1, "Tokyo", "Active" },
                    { 3, "New York, USA", "The Big Apple", new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(252), new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(252), 0, 1, "New York", "Active" }
                });

            migrationBuilder.InsertData(
                table: "KhachSan",
                columns: new[] { "Id", "DiaChi", "MoTa", "NgaySua", "NgayTao", "NguoiSua", "NguoiTao", "SoPhong", "TenKhachSan", "TrangThai" },
                values: new object[,]
                {
                    { 1, "1 Champs-Élysées, Paris", "5-star hotel in the heart of Paris", new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(462), new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(461), 0, 1, 200, "Luxury Paris KhachSan", "Open" },
                    { 2, "1-1-1 Shibuya, Tokyo", "Modern hotel with a view of Tokyo skyline", new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(466), new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(465), 0, 1, 300, "Tokyo Skyline KhachSan", "Open" },
                    { 3, "5th Avenue, New York", "Iconic New York hotel", new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(469), new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(468), 0, 1, 400, "New York Plaza", "Open" }
                });

            migrationBuilder.InsertData(
                table: "HinhKhachSan",
                columns: new[] { "Id", "KhachSanId", "Url" },
                values: new object[,]
                {
                    { 1, 1, "https://example.com/paris_hotel.jpg" },
                    { 2, 2, "https://example.com/tokyo_hotel.jpg" },
                    { 3, 3, "https://example.com/nyc" }
                });

            migrationBuilder.InsertData(
                table: "Tour",
                columns: new[] { "Id", "GiaTour", "KhachSanId", "LoaiTuorId", "MoTa", "NgayKhoiHanh", "NgaySua", "NgayTao", "NguoiSua", "NguoiTao", "SoNgay", "TenTour", "TrangThai" },
                values: new object[,]
                {
                    { 1, 100.0, 1, 1, "Explore the iconic Eiffel Tower", new DateTime(2024, 7, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(288), new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(287), new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(286), 0, 1, "1", "Eiffel Tower Adventure", "Available" },
                    { 2, 150.0, 2, 2, "Taste the best sushi in Tokyo", new DateTime(2024, 8, 12, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(298), new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(297), new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(296), 0, 1, "2", "Tokyo Sushi Experience", "Available" },
                    { 3, 200.0, 3, 3, "Enjoy a Broadway musical in New York", new DateTime(2024, 8, 27, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(303), new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(302), new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(301), 0, 1, "3", "NYC Broadway Show", "Available" }
                });

            migrationBuilder.InsertData(
                table: "DiaDiemTour",
                columns: new[] { "Id", "DiaDiemId", "TourId", "TrangThai" },
                values: new object[,]
                {
                    { 1, 1, 1, "ACTIVE" },
                    { 2, 2, 2, "ACTIVE" },
                    { 3, 3, 3, "ACTIVE" }
                });

            migrationBuilder.InsertData(
                table: "GioHang",
                columns: new[] { "Id", "NgaySua", "NgayTao", "TourId", "TrangThai", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(389), new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(388), 1, "Confirmed", 2 },
                    { 2, new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(392), new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(391), 2, "Pending", 2 },
                    { 3, new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(395), new DateTime(2024, 6, 28, 19, 36, 54, 620, DateTimeKind.Local).AddTicks(394), 3, "Confirmed", 3 }
                });

            migrationBuilder.InsertData(
                table: "HinhTour",
                columns: new[] { "Id", "TourId", "Url" },
                values: new object[,]
                {
                    { 1, 1, "https://example.com/eiffel.jpg" },
                    { 2, 2, "https://example.com/sushi.jpg" },
                    { 3, 3, "https://example.com/broadway.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiaDiem_NguoiTao",
                table: "DiaDiem",
                column: "NguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_DiaDiemTour_DiaDiemId",
                table: "DiaDiemTour",
                column: "DiaDiemId");

            migrationBuilder.CreateIndex(
                name: "IX_DiaDiemTour_TourId",
                table: "DiaDiemTour",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_GioHang_TourId",
                table: "GioHang",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_GioHang_UserId",
                table: "GioHang",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HinhKhachSan_KhachSanId",
                table: "HinhKhachSan",
                column: "KhachSanId");

            migrationBuilder.CreateIndex(
                name: "IX_HinhTour_TourId",
                table: "HinhTour",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_HuongDanVien_VeId",
                table: "HuongDanVien",
                column: "VeId");

            migrationBuilder.CreateIndex(
                name: "IX_KhachSan_NguoiTao",
                table: "KhachSan",
                column: "NguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tour_KhachSanId",
                table: "Tour",
                column: "KhachSanId");

            migrationBuilder.CreateIndex(
                name: "IX_Tour_LoaiTuorId",
                table: "Tour",
                column: "LoaiTuorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tour_NguoiTao",
                table: "Tour",
                column: "NguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_Ve_TourId",
                table: "Ve",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_Ve_UserId",
                table: "Ve",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietTour");

            migrationBuilder.DropTable(
                name: "DiaDiemTour");

            migrationBuilder.DropTable(
                name: "GioHang");

            migrationBuilder.DropTable(
                name: "HinhKhachSan");

            migrationBuilder.DropTable(
                name: "HinhTour");

            migrationBuilder.DropTable(
                name: "HuongDanVien");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "DiaDiem");

            migrationBuilder.DropTable(
                name: "Ve");

            migrationBuilder.DropTable(
                name: "Tour");

            migrationBuilder.DropTable(
                name: "KhachSan");

            migrationBuilder.DropTable(
                name: "LoaiTour");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
