using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos.RequestDtos
{
    public class CreateUserModel
    {
        public string TenDangNHap { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
        public string ChucVu { get; set; }
        public string HoVaTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
    }
}
