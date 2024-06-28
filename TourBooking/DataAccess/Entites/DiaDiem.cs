using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entites
{
    [Table("DiaDiem")]
    public class DiaDiem
    {
        public int Id { get; set; }
        public int NguoiTao { get; set; }
        [ForeignKey("NguoiTao")]
        public User User { get; set; }
        public int NguoiSua { get; set; }

        public string TenDiaDiem { get; set; }
        public string DiaChi { get; set; }
        public string MoTa { get; set; }
        public string TrangThai { get; set; }

        public DateTime NgayTao { get; set; }
        public DateTime NgaySua { get; set; }

    }
}
