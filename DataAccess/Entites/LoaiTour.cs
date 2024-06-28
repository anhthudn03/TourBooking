using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entites
{
    [Table("LoaiTour")]

    public class LoaiTour
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public string TrangThai { get; set; }
        public int NguoiSua { get; set; }
        public int NguoiTao { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgaySua { get; set; }

    }
}
