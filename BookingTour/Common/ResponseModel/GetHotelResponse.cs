namespace BookingTourAPI.Common.ResponseModel
{
    public class GetHotelResponse
    {
        public int Id { get; set; }
        public string TenKhachSan { get; set; }
        public string DiaChi { get; set; }
        public int NguoiTao { get; set; }
        public string TrangThai { get; set; }
        public int NguoiSua { get; set; }
        public string MoTa { get; set; }
        public int SoPhong { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgaySua { get; set; }
    }
}
