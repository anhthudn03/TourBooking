using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos.RequestDtos
{
    public class UpdateHotelModel
    {
        public string TenKhachSan { get; set; }
        public string DiaChi { get; set; }
        public int NguoiSua { get; set; }
        public string MoTa { get; set; }
        public int SoPhong { get; set; }
        public List<IFormFile> File { get; set; }
    }
}
