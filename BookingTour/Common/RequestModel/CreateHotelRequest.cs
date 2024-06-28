namespace BookingTourAPI.Common.RequestModel
{
    public class CreateHotelRequest
    {
        public string TenKhachSan { get; set; }
        public string KhachSan { get; set; }
        public string DiaChi { get; set; }
        public int SoPhong { get; set; }
        public List<IFormFile> Files { get; set; }

    }
}
