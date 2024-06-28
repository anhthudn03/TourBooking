using DataAccess.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos
{
    public class ChiTietTourModel
    {
        public int TourId { get; set; } 
       
        public int SoLuongNguoi { get; set; }
        public int SoLuongTrong { get; set; }
        public string NoiKhoiHanh { get; set; }
        public string NoiDen { get; set; }
        public string MoTa { get; set; }
        public string PhuongTien { get; set; }
        public double TongGia { get; set; }
        public double GiaMoiNguoi { get; set; }

    }
}
