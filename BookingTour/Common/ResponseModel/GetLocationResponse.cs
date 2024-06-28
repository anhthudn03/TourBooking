namespace BookingTourAPI.Common.ResponseModel
{
    public class GetLocationResponse
    {
        public int Id { get; set; }
        public int NguoiTao { get; set; }
        public int NguoiSua { get; set; }
        public string TenDiaDiem { get; set; }
        public string DiaChi { get; set; }
        public string MoTa { get; set; }
        public string TrangThai { get; set; }
    }
}
