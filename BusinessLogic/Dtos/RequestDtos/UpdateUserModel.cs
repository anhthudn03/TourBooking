using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos.RequestDtos
{
    public class UpdateUserModel
    {
        public string TenDangNhap { get; set; }

        public string MatKhau { get; set; }

        public string Email { get; set; }

        public string HoVaTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
    }
}
