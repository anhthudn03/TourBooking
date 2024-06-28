using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entites
{
    [Table("Ve")]
    public class Ve
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int TourId { get; set; }
        [ForeignKey("TourId")]
        public Tour Tour { get; set; }
        public int? NguoiSua { get; set; }
        public int SoNguoi { get; set; }
        public string HoVaTen { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public string PTTT { get; set; }
        public string TrangThai { get; set; } = string.Empty;
        public DateTime NgayDat { get; set; }
        public DateTime NgaySua { get; set; }
        public double TongTien { get; set; }
    }
}
