using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entites
{
    [Table("KhachSan")]
    public class KhachSan
    {
        public int Id { get; set; }
        public string TenKhachSan { get; set; }
        public string DiaChi { get; set; }
        public int NguoiTao { get; set; }
        [ForeignKey("NguoiTao")]
        public User User { get; set; }
        public string TrangThai { get; set; }
        public int NguoiSua { get; set; }

        public string MoTa { get; set; }
        public int SoPhong { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgaySua { get; set; }

    }
}
