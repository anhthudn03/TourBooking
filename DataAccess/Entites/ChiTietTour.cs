using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entites
{
    [Table("ChiTietTour")]
    public class ChiTietTour
    {
        [Key,ForeignKey("TourId")]
        public int TourId { get; set; } // Khóa chính và khóa ngoại tới Tour
        public Tour Tour { get; set; } // Quan hệ một-một với Tour
        //Số người tối đa của tour
        public int SoLuongNguoi { get; set; }
        //Số slot trống của tour
        public int SoLuongTrong { get; set; }
        //Địa Điểm khởi hành
        public string NoiKhoiHanh { get; set; }
        //Điểm đến
        public string NoiDen { get; set; }
        public string MoTa { get; set; }
        public string PhuongTien { get; set; }
        public double TongGia { get; set; }
        public double GiaMoiNguoi { get; set; }

    }
}
