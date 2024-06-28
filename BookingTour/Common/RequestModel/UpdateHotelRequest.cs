namespace BookingTourAPI.Common.RequestModel
{
    public class UpdateHotelRequest
    {
        public string TenKhachSan { get; set; }
        public string DiaChi { get; set; }
        public int NguoiSua { get; set; }
        public string MoTa { get; set; }
        public int SoPhong { get; set; }
        public List<IFormFile> File { get; set; }
    }
}
