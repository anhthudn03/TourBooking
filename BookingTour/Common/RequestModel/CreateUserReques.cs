using System.ComponentModel.DataAnnotations;

namespace BookingTourAPI.Common.RequestModel
{
    public class CreateUserReques
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
