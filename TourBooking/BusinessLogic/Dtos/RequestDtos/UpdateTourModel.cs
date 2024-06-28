using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos.RequestDtos
{
    public class UpdateTourModel
    {
        public int KhachSanId { get; set; }
        public int CategoryTourId { get; set; }
        public DateTime NgayKhoiHanh { get; set; }
        public string TenTour { get; set; }
        public string MoTa { get; set; }
        public double Gia { get; set; }
        public string SoNgay { get; set; }
        public string TrangThai { get; set; }
        public List<IFormFile> Files { get; set; }
    }
}
