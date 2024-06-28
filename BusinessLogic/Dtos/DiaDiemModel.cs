using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos
{
    public class DiaDiemModel
    {
        public int Id { get; set; }
        public int NguoiTao { get; set; }
        public int NguoiSua { get; set; }
        public string TenDiaDiem { get; set; }
        public string DiaChi { get; set; }
        public string MoTa { get; set; }
        public string TrangThai { get; set; }
    }
}
