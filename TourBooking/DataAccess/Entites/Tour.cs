using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entites
{
    [Table("Tour")]
    public class Tour
    {
        public int Id { get; set; }
        public int KhachSanId { get; set; }
        [ForeignKey("KhachSanId")]
        public KhachSan KhachSan { get; set; }

        public int NguoiTao { get; set; }
        [ForeignKey("NguoiTao")]
        public User User { get; set; }
        public int NguoiSua { get; set; }
        public int LoaiTuorId { get; set; }
        [ForeignKey("LoaiTuorId")]
        public LoaiTour LoaiTour { get; set; }
        public DateTime NgayKhoiHanh { get; set; }
        public string TenTour { get; set; }
        public string MoTa { get; set; }
        public double GiaTour { get; set; }
        public string SoNgay { get; set; }
        public string TrangThai { get; set; }

        public DateTime NgayTao { get; set; }
        public DateTime NgaySua { get; set; }
        public ChiTietTour? ChiTietTour { get; set; } // Quan hệ một-một với ChiTietTour

    }
}
