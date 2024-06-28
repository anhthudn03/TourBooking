using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos
{
    public class LoaiTourModel
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
