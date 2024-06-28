namespace BookingTourAPI.Common.RequestModel
{
    public class UpdateUserRequest
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
