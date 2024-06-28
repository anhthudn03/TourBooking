using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos.RequestDtos
{
    public class CreateTourModel
    {
        public int KhachSanId { get; set; }
        public int LoaiTuorId { get; set; }
        public DateTime NgayKhoiHanh { get; set; }
        public string TenTour { get; set; }
        public string MoTa { get; set; }
        public double GiaTour { get; set; }
        public string SoNgay { get; set; }
        public List<IFormFile> Files { get; set; }
    }
}
