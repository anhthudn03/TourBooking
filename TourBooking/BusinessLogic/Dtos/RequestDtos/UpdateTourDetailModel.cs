using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos.RequestDtos
{
    public class UpdateTourDetailModel
    {
        public int TongSoLuongNguoi { get; set; }
        public int SoLuongTrong { get; set; }
        public string DiemXuatPhat { get; set; }
        public string DiemDen { get; set; }
        public string MoTa { get; set; }
        public string PhuongTien { get; set; }
        public double TongTen { get; set; }
        public double GiaMoiNguoi { get; set; }
    }
}
