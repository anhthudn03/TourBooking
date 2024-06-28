using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos.RequestDtos
{
    public class UpdateLocationModel
    {
        public string TenDiaDiem { get; set; }
        public string DiaChi { get; set; }
        public string MoTa { get; set; }
        public string TrangThai { get; set; }
    }
}
