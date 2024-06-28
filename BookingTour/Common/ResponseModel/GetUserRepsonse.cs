using System.ComponentModel.DataAnnotations;

namespace BookingTourAPI.Common.ResponseModel
{
    public class GetUserRepsonse
    {
        public int Id { get; set; }
        public string TenDangNHap { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
        public string ChucVu { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgaySua { get; set; }
        public string HoVaTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string TrangThai { get; set; }

    }
}
