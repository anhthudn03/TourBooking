using DataAccess.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos
{
    public class HuongDanVienModel
    {
        public int Id { get; set; }
        public string HoVaTen { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgaySua { get; set; }
        public string TrangThai { get; set; }
        public int NguoiSua { get; set; }
        public int NguoiTao { get; set; }
        public int? VeId { get; set; }
    }
}
