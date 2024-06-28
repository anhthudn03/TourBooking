using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class datainit2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ve_TourId",
                table: "Ve");

            migrationBuilder.DropIndex(
                name: "IX_Ve_UserId",
                table: "Ve");

            migrationBuilder.UpdateData(
                table: "DiaDiem",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1185), new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1182) });

            migrationBuilder.UpdateData(
                table: "DiaDiem",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1189), new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1188) });

            migrationBuilder.UpdateData(
                table: "DiaDiem",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1191), new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1191) });

            migrationBuilder.UpdateData(
                table: "GioHang",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1439), new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1437) });

            migrationBuilder.UpdateData(
                table: "GioHang",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1441), new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1440) });

            migrationBuilder.UpdateData(
                table: "GioHang",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1443), new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1442) });

            migrationBuilder.UpdateData(
                table: "HuongDanVien",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1470), new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1469) });

            migrationBuilder.UpdateData(
                table: "HuongDanVien",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1473), new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1472) });

            migrationBuilder.UpdateData(
                table: "HuongDanVien",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1475), new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1474) });

            migrationBuilder.UpdateData(
                table: "KhachSan",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1506), new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1506) });

            migrationBuilder.UpdateData(
                table: "KhachSan",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1509), new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1508) });

            migrationBuilder.UpdateData(
                table: "KhachSan",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1511), new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1511) });

            migrationBuilder.UpdateData(
                table: "LoaiTour",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1562), new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1562) });

            migrationBuilder.UpdateData(
                table: "LoaiTour",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1564), new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1564) });

            migrationBuilder.UpdateData(
                table: "LoaiTour",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1566), new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1565) });

            migrationBuilder.UpdateData(
                table: "LoaiTour",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1567), new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1567) });

            migrationBuilder.UpdateData(
                table: "Tour",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NgayKhoiHanh", "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 7, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1295), new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1294), new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1292) });

            migrationBuilder.UpdateData(
                table: "Tour",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NgayKhoiHanh", "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 8, 12, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1305), new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1305), new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1304) });

            migrationBuilder.UpdateData(
                table: "Tour",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NgayKhoiHanh", "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 8, 27, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1309), new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1309), new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(1308) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(777), new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(762) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(789), new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(789) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(793), new DateTime(2024, 6, 28, 18, 44, 25, 91, DateTimeKind.Local).AddTicks(792) });

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
            migrationBuilder.DropIndex(
                name: "IX_Ve_TourId",
                table: "Ve");

            migrationBuilder.DropIndex(
                name: "IX_Ve_UserId",
                table: "Ve");

            migrationBuilder.UpdateData(
                table: "DiaDiem",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6082), new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6081) });

            migrationBuilder.UpdateData(
                table: "DiaDiem",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6085), new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6084) });

            migrationBuilder.UpdateData(
                table: "DiaDiem",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6088), new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6087) });

            migrationBuilder.UpdateData(
                table: "GioHang",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6208), new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6207) });

            migrationBuilder.UpdateData(
                table: "GioHang",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6210), new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6209) });

            migrationBuilder.UpdateData(
                table: "GioHang",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6212), new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6211) });

            migrationBuilder.UpdateData(
                table: "HuongDanVien",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6236), new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6235) });

            migrationBuilder.UpdateData(
                table: "HuongDanVien",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6239), new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6238) });

            migrationBuilder.UpdateData(
                table: "HuongDanVien",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6241), new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6240) });

            migrationBuilder.UpdateData(
                table: "KhachSan",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6264), new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6262) });

            migrationBuilder.UpdateData(
                table: "KhachSan",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6267), new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6266) });

            migrationBuilder.UpdateData(
                table: "KhachSan",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6269), new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6268) });

            migrationBuilder.UpdateData(
                table: "LoaiTour",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6315), new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6314) });

            migrationBuilder.UpdateData(
                table: "LoaiTour",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6317), new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6317) });

            migrationBuilder.UpdateData(
                table: "LoaiTour",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6319), new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6319) });

            migrationBuilder.UpdateData(
                table: "LoaiTour",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6321), new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6320) });

            migrationBuilder.UpdateData(
                table: "Tour",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NgayKhoiHanh", "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 7, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6117), new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6116), new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6116) });

            migrationBuilder.UpdateData(
                table: "Tour",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NgayKhoiHanh", "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 8, 12, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6126), new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6125), new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6125) });

            migrationBuilder.UpdateData(
                table: "Tour",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NgayKhoiHanh", "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 8, 27, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6129), new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6128), new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(6128) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(5841), new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(5829) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(5847), new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(5847) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NgaySua", "NgayTao" },
                values: new object[] { new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(5850), new DateTime(2024, 6, 28, 15, 15, 57, 160, DateTimeKind.Local).AddTicks(5850) });

            migrationBuilder.CreateIndex(
                name: "IX_Ve_TourId",
                table: "Ve",
                column: "TourId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ve_UserId",
                table: "Ve",
                column: "UserId",
                unique: true);
        }
    }
}
